$(document).ready(function () {

    $('select').select2();

    $('#Cover').on('change', function () {

        if (this.files.length > 0) {
            $('.cover-preview')
                .attr('src', window.URL.createObjectURL(this.files[0]))
                .removeClass('d-none');
        }
    });

});


