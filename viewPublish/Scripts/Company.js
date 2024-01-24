

function GetcompanyData(company_id) {
  
    $.ajax({
        url: ViewUrl + "company/CompanyDataLoadByID?company_id=" + company_id + "",
        method: "GET",
        dataType: "json",
        success: function (data) {

            $("#company_id").val(data[0].company_id);
            $("#company_name_ar").val(data[0].company_name_ar);
            $("#company_name_en").val(data[0].company_name_en);
            $("#company_phone").val(data[0].company_phone);
            $("#company_address").val(data[0].company_address);
            $("#company_mobile").val(data[0].company_mobile);

          
            $('#blah').attr("src", data[0].company_img);

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
                    url: ViewUrl + "company/DeleteCurrency/" + parseInt(button.attr("data-id")),
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




function GetCompanyDetails(company_id) {
   
    $.ajax({
        url: ViewUrl + "company/CompanyDataLoadByID?company_id=" + company_id + "",
        method: "GET",
        dataType: "json",
        success: function (data) {


            console.log(JSON.stringify(data));


            $('#NewsDetailsDetails').empty();

            //$("#NewsID").val(data[0].NewsID);
            ;
            $("#NewsDetailsDetails").append(data[0].company_address);


            $('#NewsDetailsIMG').attr("src", data[0].company_img);
    


        },
        error: function (err) {
            console.log(err);
        }
    });
}
