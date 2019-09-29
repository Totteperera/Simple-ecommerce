$(document).ready(function () {
    $('.js-product')
        .off('')
        .on('click', '.js-add-to-cart', function () {
            var productId = $(this).data('id');
            var form = $('#__AjaxAntiForgeryForm');
            var token = $('input[name="__RequestVerificationToken"]', form).val();

        });
});