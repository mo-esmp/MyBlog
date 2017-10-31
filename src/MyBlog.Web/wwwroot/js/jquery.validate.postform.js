function removeAllTagsAndTrim(html) {
    return !html ? "" : $.trim(html.replace(/(<([^>]+)>)/ig, ""));
}

function validateEditor(id, triggerValidation) {
    if (triggerValidation) {
        $('form').valid();
        return;
    }
    var content = CKEDITOR.instances[id].getData().replace(/(<([^>]+)>)/ig, '');
    content = content.replace(/&nbsp;/gi, '');

    if ($.trim(content).length === 0) {
        var editorArea = $('#cke_' + id);
        $(editorArea).parent('div.input-control').removeClass('success').addClass('error-state');

        return false;
    }

    return true;
}

$.validator.setDefaults({
    ignore: ':hidden:not(textarea, input#Tags)',
    highlight: function (element) {
        $(element).closest('.form-group').addClass('has-error');
    },
    unhighlight: function (element) {
        $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
    },
    errorElement: 'span',
    errorClass: 'help-block',
    errorPlacement: function (error, element) {
        if (element.parent('.input-group').length) {
            error.insertAfter(element.parent());
        } else {
            error.insertAfter(element);
        }
    }
});

$.validator.setDefaults({});

$.validator.methods.originalRequired = $.validator.methods.required;

$.validator.addMethod("required", function (value, element, param) {
    if ($(element).is('textarea:hidden')) {
        return validateEditor($(element).attr('id'), false);
    } else {
        value = removeAllTagsAndTrim(value);
        if (!value) {
            return false;
        }
    }

    return $.validator.methods.originalRequired.call(this, value, element, param);
}, $.validator.messages.required);

$(function () {
    $('form').each(function () {
        $(this).find('div.form-group').each(function () {
            if ($(this).find('span.field-validation-error').length > 0) {
                $(this).addClass('has-error');
            }
        });
    });

    if (typeof CKEDITOR === 'undefined') {
        return;
    }
    setTimeout(function () {
        for (var i in CKEDITOR.instances) {
            var name = CKEDITOR.instances[i].name;
            CKEDITOR.on('instanceReady', function (evt) {
                var editor = $('.cke_wysiwyg_frame').contents().find('body.cke_editable');
                if (editor.length > 0) {
                    $(editor).keyup(function () {
                        validateEditor(name, true);
                    });
                }
            });
        }
    }, 1000);
});