'use strict';
var postKey = 'myBlogPost';
var expireDayCount = 3;

function initializePage(isEditMode, tags) {
    CKEDITOR.replace('Content', {
        contentsLangDirection: 'rtl',
        filebrowserImageUploadUrl: '/base/uploadimage'
    });
    setTimeout(function () { $('.cke_top').addClass('cke_rtl'); }, 1000);

    var elt = initializeTagsInput();
    if (isEditMode) {
        rebindTags(elt, tags);
        retrievePostEditMode(elt);
    } else {
        retrievePost(elt);
    }

    setInterval(savePostTemporary, 30000);

    $('#Title').blur(function() {
        var title = $(this).val();
        var slug = slugify(title);
        $('#Slug').val(slug);
    });

    $('form').submit(function () {
        if ($(this).valid()) {
            clearSavedPost();
        }
    });
}

function slugify(text) {
    var slug = text.toString().toLowerCase().trim()
        .replace(/\s+/g, '-')           // Replace spaces with -
        .replace(/&/g, '-and-')         // Replace & with 'and'
        .replace(/[^\a-z0-9-\u0600-\u06FF\-]+/g, '')       // Remove all non-word chars
        .replace(/\-\-+/g, '-');        // Replace multiple - with single -

    if (slug.length > 100) {
        slug = slug.substring(0, 100);
    }

    if(slug.substr(slug.length - 1) === '-') {
        slug = slug.substring(0, slug.length - 1);
    }

    return slug;
}

function initializeTagsInput() {
    var tags = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('text'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        prefetch: '/admin/api/tags'
    });
    tags.initialize();

    var elt = $('#Tags');
    elt.tagsinput({
        itemValue: 'value',
        itemText: 'text',
        typeaheadjs: {
            name: 'tags',
            displayKey: 'text',
            source: tags.ttAdapter()
        }
    });

    $('.bootstrap-tagsinput').addClass('left-text form-control').css({ 'border-radius': '0', 'width': '100%;' });
    return elt;
}

function rebindTags(elt, tags) {
    $.each(tags, function (index, tag) {
        elt.tagsinput('add', { 'value': tag.value, 'text': tag.text });
    });
}

function retrievePost(elt) {
    var localPost = getLocalPost();
    if (localPost === null) {
        return;
    }

    localPost = JSON.parse(localPost);
    var diffDays = calculateDiffDays(localPost);
    if (diffDays > expireDayCount) {
        clearSavedPost();
        return;
    }
    if (confirm('Previous post has been saved locally, do you want load it again ?')) {
        $('#Title').val(localPost.title);
        CKEDITOR.instances['Content'].setData(localPost.content);
        rebindTags(elt, localPost.tags);
    }
}

function retrievePostEditMode(elt) {
    var localPost = getLocalPost();
    if (localPost === null) {
        return;
    }

    localPost = JSON.parse(localPost);
    var postId = $('Id').val();
    if (localPost.id !== postId) {
        return;
    }

    var currentPost = getCurrentPost();
    var diffDays = calculateDiffDays(localPost);
    if (diffDays > expireDayCount || comparePost(currentPost, localPost)) {
        clearSavedPost();
        return;
    }

    if (confirm('Post has been edited, do you want load it again ?')) {
        $('#Title').val(localPost.title);
        CKEDITOR.instances['Content'].setData(localPost.content);
        rebindTags(elt, localPost.tags);
    }
}

function getCurrentPost() {
    var id = $('Id').val();
    var title = $('#Title').val();
    var content = CKEDITOR.instances['Content'].getData();
    var tags = $('#Tags').tagsinput('items');
    var createDate = new Date().toISOString();
    var post = { 'id': id, 'title': title, 'content': content, 'tags': tags, createDate: createDate };

    return post;
}

function getLocalPost() {
    var localPost = localStorage.getItem(postKey);
    var sessionPost = sessionStorage.getItem(postKey);
    var savedPost = sessionPost || localPost;
    if (savedPost === null) {
        return null;
    }

    return savedPost;
}

function calculateDiffDays(localPost) {
    var createdDate = new Date(localPost.createDate);
    var currentDate = new Date();
    var oneDay = 24 * 60 * 60 * 1000;
    var diffDays = Math.round(Math.abs((createdDate.getTime() - currentDate.getTime()) / (oneDay)));
    return diffDays;
}

function comparePost(currentPost, savedPost) {
    var isSamePost = true;

    if (currentPost.title !== savedPost.title || currentPost.content !== savedPost.content) {
        isSamePost = false;
    }

    for (var i = 0, len = savedPost.tags.length; i < len; i++) {
        var result = $.grep(currentPost.tags, function (currentTag) {
            return (currentTag.value === savedPost.tags[i].value && currentTag.text === savedPost.tags[i].text);
        });

        if (result.length === 0) {
            isSamePost = false;
        }
    }

    return isSamePost;
}

function savePostTemporary() {
    var post = getCurrentPost();
    if ($.trim(post.title).length === 0 && $.trim(post.content).length === 0) {
        return;
    }

    post = JSON.stringify(post);
    localStorage.setItem(postKey, post);
    sessionStorage.setItem(postKey, post);
}

function clearSavedPost() {
    localStorage.removeItem(postKey);
    sessionStorage.removeItem(postKey);
}