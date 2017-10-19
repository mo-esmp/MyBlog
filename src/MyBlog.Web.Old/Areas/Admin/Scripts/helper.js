helper = {
    deleteFromTable: function (url, selector) {
        $('.table').on('click', selector, function (e) {
            confirm("آیا مطمئن هستید میخواهید این آیتم را حذف نمایید ؟");
            e.preventDefault();
            var anchor = $(this);
            var id = $(anchor).attr('data-id');
            $.ajax({
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ id: id }),
                dataType: 'json',
                processData: false,
                type: 'POST',
                url: url,
                success: function (result) {
                    if (result === true) {
                        $(anchor).parent('td').parent('tr').fadeOut('slow', function () {
                            $(this).remove();
                        });
                    }
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    alert(textStatus + ' ' + xmlHttpRequest.status + " " + errorThrown);
                }
            });
        });
    },

    initialContactMessagePage: function () {
        "use strict";

        //When unchecking the checkbox
        $("#check-all").on('ifUnchecked', function (event) {
            //Uncheck all checkboxes
            $("input[type='checkbox']", ".table-mailbox").iCheck("uncheck");
        });
        //When checking the checkbox
        $("#check-all").on('ifChecked', function (event) {
            //Check all checkboxes
            $("input[type='checkbox']", ".table-mailbox").iCheck("check");
        });

        $('#deleteButton').on('click', function () {
            if ($('.table').find('input[type=checkbox]:checked').size() > 0) {
                $('#confirmModal').modal();
            } else {
                $('#confirmModal2').modal();
            }
        });

        $('#confirmButton').on('click', function () {
            var idList = [];
            $('.table').find('input[type=checkbox]:checked').each(function () {
                idList.push($(this).attr('value'));
            });
            if (idList.length > 0) {
                $.ajax({
                    url: '/admin/contactmessage/deletemessage',
                    type: 'POST',
                    data: JSON.stringify({ idList: idList }),
                    dataType: 'json',
                    processData: false,
                    contentType: 'application/json; charset=utf-8',
                    success: function (result) {
                        if (result === true) {
                            idList.forEach(function (id) {
                                var selector = '.delete-box[data-id="' + id + '"]';
                                $(selector).parent('div').parent('td').parent('tr').fadeOut('slow', function () {
                                    $(this).remove();
                                });
                            });
                        } else {
                            alert("علمیات حذف با خطا مواجه شد");
                        }
                        $("#confirmModal").modal('hide');
                    },
                    error: function (xmlHttpRequest, textStatus, errorThrown) {
                        $("#confirmModal").modal('hide');
                        alert(textStatus + ' ' + xmlHttpRequest.status + " " + errorThrown);
                    }
                });
            }
        });

        $('#notNewButton').on('click', function () {
            updateMessage(false);
        });

        $('#isNewButton').on('click', function () {
            updateMessage(true);
        });

        function updateMessage(isNew) {
            var idList = [];
            $('.table').find('input[type=checkbox]:checked').each(function () {
                idList.push($(this).attr('value'));
            });
            if (idList.length > 0) {
                $.ajax({
                    url: '/admin/contactmessage/updatemessage',
                    type: 'POST',
                    data: JSON.stringify({ idList: idList, isNew: isNew }),
                    dataType: 'json',
                    processData: false,
                    contentType: 'application/json; charset=utf-8',
                    success: function (result) {
                        if (result === true) {
                            idList.forEach(function (id) {
                                var selector = '.delete-box[data-id="' + id + '"]';
                                if (isNew)
                                    $(selector).parent('div').parent('td').parent('tr').addClass('unread');
                                else
                                    $(selector).parent('div').parent('td').parent('tr').removeClass('unread');
                            });
                        } else {
                            alert("علمیات بروز رسانی با خطا مواجه شد");
                        }
                    },
                    error: function (xmlHttpRequest, textStatus, errorThrown) {
                        alert(textStatus + ' ' + xmlHttpRequest.status + " " + errorThrown);
                    }
                });
            }
        }
    }
};