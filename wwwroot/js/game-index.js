$(document).ready(function () {

    $('.js-delete').on('click', function () {

        var btn = $(this);
        var id = btn.data('id');

        const swal = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-danger mx-2",
                cancelButton: "btn btn-light"
            },
            buttonsStyling: false
        });

        swal.fire({
            title: "Are you sure that you need to delete this game?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            reverseButtons: true
        }).then((result) => {

            if (result.isConfirmed) {

                $.ajax({
                    url: '/Games/Delete/' + id,
                    type: 'DELETE',

                    success: function () {

                        btn.closest('tr').remove();

                        swal.fire({
                            title: "Deleted!",
                            text: "Your game has been deleted.",
                            icon: "success"
                        });

                    },

                    error: function (xhr) {

                        if (xhr.status === 400) {

                            swal.fire({
                                title: "Cannot Delete!",
                                text: "This game cannot be deleted.",
                                icon: "warning"
                            });

                        }
                        else {

                            swal.fire({
                                title: "Error!",
                                text: "Something went wrong.",
                                icon: "error"
                            });

                        }

                    }
                });

            }

        });

    });

});