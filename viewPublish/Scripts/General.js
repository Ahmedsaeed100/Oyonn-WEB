//var ViewUrl = "http://localhost:62894/";
var ViewUrl = "http://oyonn.com/";




function SearhData() {
    var Sdata = $("#SearchText").val();
    window.location = ViewUrl + "Search/Index?Data_Name=" + Sdata + "";
}

function ShiftVal() {
    var today = new Date();
    var Late = today.getHours()


    var x;
    if (Late <= 14)
    {
        x = 1;
       
    }
    else {
        x = 2;
    }
    $('#C_ShiftID').val(x).trigger('chosen:updated');
}

function CanNotDeleteTableUsed() {
    Swal.fire(
        'warning!',
        'لا يمكن الحذف مستخدم ',
        'error'
    );
   
}


function ClearData() {
    //remove hidden type
    //applay it to all pages
    jQuery("input[type='text']").each(function () {
        this.value = '';
        $(".MasterID").attr("readonly", false);
    });


    $("span.clear").text("0");
    $(".form-control").val('');
    jQuery(".hiddenId ").each(function () {
        this.value = 0;
      
    });
    // Clear class chosen-select
    $("select").each(function () {
        $(this).val("");
    });

    // Clear Checkbox
    $("input[type='checkbox']").each(function () {
        $(this).prop('checked', false);
    });

     //Clear Number
    $("input[type='number']").each(function () {
        $(this).val('');
    });
    $("input[type='hidden']").each(function () {
        $(this).val('0');
    });
    $("textarea").each(function () {
        $(this).val('');
    });

    //$(".all").each(function () {
    //    $(this).attr('src', imagepath + "noimage.png").width(130).height(130);
    //    $(this).attr("data-img", 0);
    //});

    //$('.fileinput-exists').each(function () {
    //    $(this).closest('.fileinput').fileinput('clear');
    //});


    //// Return Button To Add State
    //if ($('#Updatedata').is(':visible')) {
    //    $('#Updatedata').hide();
    //    $('#Adddata').show();
    //}

}



