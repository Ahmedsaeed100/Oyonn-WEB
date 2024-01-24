

function Getproducts(product_id) {

    $.ajax({
        url: ViewUrl + "products/productDataLoadByID?product_id=" + product_id + "",
        method: "GET",
        dataType: "json",
        success: function (data) {

            $("#product_id").val(data[0].product_id);
            $("#product_name_ar").val(data[0].product_name_ar);
            $("#product_name_en").val(data[0].product_name_en);
            $("#company_id").val(data[0].company_id);
            $('#company_id').selectpicker('refresh');

            $(window).scrollTop(0);
           



        },
        error: function (err) {
            console.log(err)
        }
    });
}
function Delete() {

    $("#datable_1").on("click", ".js-delete", function () {
        var button = $(this);

        Swal.fire({
            title: 'هل انت متاكد?',
            text: "من حذف البيانات !",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    url: ViewUrl + "products/Deleteproducts/" + parseInt(button.attr("data-id")),
                    method: "POST",
                    success: function (data) {
                        if (data == 1) {
                            button.closest('tr').remove();

                        } else {
                            CanNotDeleteTableUsed();
                        }
                    },
                    error: function (jqXHR, exception) {
                        CanNotDeleteTableUsed();
                    }
                });
                Swal.fire(
                    'Deleted!',
                    'تم الحذف بنجاج',
                    'success'
                );
            }
        });
    });
}




