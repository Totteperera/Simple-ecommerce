﻿$(document).ready(function () {
    $('.js-product')
        .off('')
        .on('click', '.js-add-to-cart', function () {
            var productId = $(this).data('id');
            var form = $('#__AjaxAntiForgeryForm');
            var token = $('input[name="__RequestVerificationToken"]', form).val();
            var url = $(this).data('url');

            $.ajax({
                url: url,
                type: 'POST',
                data: {
                    __RequestVerificationToken: token,
                    id: productId
                },
                success: function (result) {
                    console.log(result);
                }
            });
        });
});