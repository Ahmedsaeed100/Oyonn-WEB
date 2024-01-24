function editclient(client_id, client_status_id) {

   
   
    $("#client_ide").val(client_id);
            
    $("#client_status_idedite").val(client_status_id);
    $('#client_status_idedite').selectpicker('refresh');

            




        
}

function Postclient_status() {

    Swal.fire({
        title: 'هل انت متاكد ?',
        text: "من اجراء التعديل!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes!'
    }).then((result) => {
        if (result.value) {
          


            var data = {
                client_status_id: $('#client_status_idedite').val(),

                client_id: $('#client_ide').val(),


            };

            $.ajax({
                url: ViewUrl + "client/Postupdateclient_status",
                method: "POST",
                data: JSON.stringify(data),
                contentType: "application/json",
                success: function (data) {
                    if (data == 1) {
                        Swal.fire(
                            'Information',
                            'تم الحفظ',
                            'success'
                        );


                        setTimeout(function () {
                            window.location.reload();
                        }, 2000);
                    }
                    else {

                        Swal.fire(
                            'warning!',
                            'حدث خطاء ما',
                            'error'
                        );
                    }
                },
                complete: function () {


                },
                error: function (jqXHR, exception) {
                    // Your error handling logic here..

                }
            });
        }
    });
}


function client_shopDataLoad(client_id) {
    $.ajax({
        type: "GET",
        url: ViewUrl + "client/client_shopDataLoad?client_id=" + client_id + "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            $('#client_shopData').empty();

            if (data != null) {
                var row = 0;
                $.each(data, function (i, d) {
                    row += 1;
                    var html = '<div class="panel-group" id="accordion_1" role="tablist" aria-multiselectable="true">';
                        html +='<div class="panel panel-primary">';
                            html +='<div class="panel-heading" role="tab" id="headingOne_1">';
                    html += '<h4 class="panel-title"> <a role="button" data-toggle="collapse" data-parent="#accordion_1" href="#collapseOne_1' + row + '" aria-expanded="true" aria-controls="collapseOne_1' + row +'"> '+d.shop_Name+' </a> </h4>';
                                html +='</div>';
                    html += '<div id="collapseOne_1' + row +'" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne_1">';



                    html += '<div class="row clearfix">';
                    html += '<div class="col-lg-12 col-md-12 col-sm-12">';
                    html += '<div class="card">';
                    html += '<div class="body">';
                    html += '<div class="row clearfix">';
                    html += '<div class="col-lg-12 col-md-12 col-sm-12">';
                    html += '<div class="card">';
                    html += '<div class="body">';
                    html += '<div class="row clearfix">';
                    html += '<div class="col-lg-12 col-md-12 col-sm-12">';
                    html += '<div class="input-group">';
                    html += '<span class="input-group-addon"> <i class="material-icons">info</i> </span>';
                    html += '<div class="form-line">';
                    html += '<label class="form-control ">' + d.shop_Name +'</label>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                                                                  
                    html += '</div>';
                    html += '<div class="row clearfix  m-t-10">';
                    html += '<div class="col-lg-12 col-md-12 col-sm-12">';
                    html += '<div class="input-group">';
                    html += '<span class="input-group-addon"> <i class="material-icons">info</i> </span>';
                    html += '<div class="form-line">';
                    html += '<label class="form-control ">' + d.area.area_name +'</label>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';


                    html += '</div>';
                    html += '<div class="row clearfix  m-t-10">';
                    html += '<div class="col-lg-12 col-md-12 col-sm-12">';
                    html += '<div class="input-group">';
                    html += '<span class="input-group-addon"> <i class="material-icons">info</i> </span>';
                    html += '<div class="form-line">';
                    html += '<label class="form-control ">' + d.city.city_name + '</label>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';

                   

                    html += '</div>';
                    html += '<div class="row clearfix  m-t-10">';
                    html += ' <div class="col-lg-12 col-md-12 col-sm-12">';
                    html += '<div class="input-group">';
                    html += '<span class="input-group-addon"> <i class="material-icons">info</i> </span>';
                    html += '<div class="form-line">';
                    html += ' <label class="form-control ">' + d.Shop_mobile +'</label>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';

                    html += '</div>';
                    html += '<div class="row clearfix  m-t-10">';
                    html += ' <div class="col-lg-12 col-md-12 col-sm-12">';
                    html += '<div class="input-group">';
                    html += '<span class="input-group-addon"> <i class="material-icons">info</i> </span>';
                    html += '<div class="form-line">';
                    html += '<label class="form-control ">' + d.shop_phone +'</label>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';

                    html += '</div>';
                    html += '<div class="row clearfix  m-t-10">';
                    html += '<div class="col-lg-12 col-md-12 col-sm-12">';
                    html += '<div class="input-group">';
                    html += '<span class="input-group-addon"> <i class="material-icons">info</i> </span>';
                    html += '<div class="form-line">';
                    html += '<label class="form-control ">';
                    html += '<label class="form-control ">' + d.shop_address +'</label>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';

                    html += '</div>';
                    html += '<div class="row clearfix  m-t-10">';

                    html += '<div class="col-lg-6 col-md-6 col-sm-12">';
                    html += '<div class="input-group">';
                    html += '<span class="input-group-addon"> <i class="material-icons">info</i> </span>';
                    html += '<div class="form-line">';
                    html += '<img src="' + d.shop_img+'" style="width:300px;height:160px" />';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';

                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += ' </div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';
                    html += '</div>';

                    
                    

                    $('#client_shopData').append(html);
                })

            }
        },
        error: function (err) {
            console.log(err)
        }
    });
}