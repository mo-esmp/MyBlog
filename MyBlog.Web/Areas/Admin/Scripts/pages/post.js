function initializePage(isEditMode, tags) {
    CKEDITOR.replace('Post_Content', {
        contentsLangDirection: 'rtl',
        filebrowserImageUploadUrl: '/base/uploadimage'
    });
    setTimeout(function () { $('.cke_top').addClass('cke_rtl'); }, 1000);

    var elt = initializeTagsInput();
    if (isEditMode) {
        rebindTags(elt, tags);
        retrivePostEditMode(elt);
    } else {
        retrivePost(elt);
    }

    setInterval(savePostTemprorary, 30000);

    $('form').submit(function () {
        if ($(this).valid()) {
            localStorage.removeItem('savedPost');
        }
    });
}

function initializeTagsInput() {
    var tags = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('text'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        prefetch: '/admin/post/gettags'
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

function retrivePost(elt) {
    var savedPost = window.localStorage.getItem('savedPost');
    if (savedPost === null) {
        return;
    }

    savedPost = JSON.parse(savedPost);
    var createdDate = new Date(savedPost.createDate);
    var currentDate = new Date();

    var oneDay = 24 * 60 * 60 * 1000;
    var diffDays = Math.round(Math.abs((createdDate.getTime() - currentDate.getTime()) / (oneDay)));

    if (diffDays < 3) {
        if (confirm('Prevoius post has been cached, do you want load it again ?')) {
            $('#Post_Title').val(savedPost.title);
            CKEDITOR.instances['Post_Content'].setData(savedPost.content);
            rebindTags(elt, savedPost.tags);
        }

        return;
    }

    localStorage.setItem('savedPost', '');
}

function retrivePostEditMode(elt) {
    var savedPost = window.localStorage.getItem('savedPost');
    if (savedPost === null) {
        return;
    }

    savedPost = JSON.parse(savedPost);
    var postId = $('#Post_Id').val();
    if (savedPost.id !== postId) {
        return;
    }

    var createdDate = new Date(savedPost.createDate);
    var currentDate = new Date();

    var oneDay = 24 * 60 * 60 * 1000;
    var diffDays = Math.round(Math.abs((createdDate.getTime() - currentDate.getTime()) / (oneDay)));

    var currentPost = getCurrentPost();
    if (diffDays < 3 && !comparePost(currentPost, savedPost)) {
        if (confirm('Post has been edited, do you want load it again ?')) {
            $('#Post_Title').val(savedPost.title);
            CKEDITOR.instances['Post_Content'].setData(savedPost.content);
            rebindTags(elt, savedPost.tags);
        }

        return;
    }

    localStorage.setItem('savedPost', '');
}

function getCurrentPost() {
    var id = $('#Post_Id').val();
    var title = $('#Post_Title').val();
    var content = CKEDITOR.instances['Post_Content'].getData().replace(/(<([^>]+)>)/ig, '');
    var tags = $('#Tags').tagsinput('items');
    var createDate = new Date().toISOString();
    var post = { 'id': id, 'title': title, 'content': content, 'tags': tags, createDate: createDate };

    return post;
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

function savePostTemprorary() {
    var post = getCurrentPost();
    if ($.trim(post.title).length === 0 && $.trim(post.content).length === 0) {
        return;
    }

    post = JSON.stringify(post);
    localStorage.setItem('savedPost', post);
}