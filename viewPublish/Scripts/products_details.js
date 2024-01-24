

function Getproducts_detailsData(product_details_id) {

    $.ajax({
        url: ViewUrl + "products_details/product_detailsDataLoadByID?product_details_id=" + product_details_id + "",
        method: "GET",
        dataType: "json",
        success: function (data) {

            $("#product_details_id").val(data[0].product_details_id);
            $("#product_name_ar").val(data[0].product_name_ar);
            $("#product_name_en").val(data[0].product_name_en);
            $("#product_quantity").val(data[0].product_quantity);
            $("#product_price").val(data[0].product_price);
            
            $("#product_id").val(data[0].product_id);
            $('#product_id').selectpicker('refresh');

            $('#blah').attr("src", data[0].product_img);

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
                    url: ViewUrl + "products_details/Deleteproducts_details/" + parseInt(button.attr("data-id")),
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
                    'Deletion completed successfully.',
                    'success'
                );
            }
        });
    });
}




function product_detailsIMG(product_details_id) {

    $.ajax({
        url: ViewUrl + "products_details/product_detailsDataLoadByID?product_details_id=" + product_details_id + "",
        method: "GET",
        dataType: "json",
        success: function (data) {


            console.log(JSON.stringify(data));


            


            $('#NewsDetailsIMG').attr("src", data[0].product_img);



        },
        error: function (err) {
            console.log(err)
        }
    });
}
