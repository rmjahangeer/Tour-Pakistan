function ValidateFields(e) {
        var missingCounter = 0;
        var fields = $('.mandatory'); //Array for all textboxes
        var inCompleteFields ="";
        for (var i = 0; i < fields.length; i++) {
            var value = $(fields[i]).val();
            if (value.toString().length == 0) {


                $(fields[i]).css('border-color', 'red');
                if (!$(fields[i]).hasClass("select2me")) {
                    missingCounter++;
                    inCompleteFields += "<br/>" + ($(fields[i]).attr('placeholder') + (i + 1 == fields.length ? "" : ", "));
                }

            } else if (!$(fields[i]).hasClass("select2me")) {
                $(fields[i]).css('border-color', 'gainsboro');
            }

            //check select2 DDL
            if ($(fields[i]).hasClass("select2me") && $(fields[i]).attr("id").indexOf('s2id') == -1 && value.toString().length == 0) {
                $(fields[i]).parent().css('border', '1px solid red');
                missingCounter++;
            }
            else if ($(fields[i]).hasClass("select2me") && $(fields[i]).attr("id").indexOf('s2id') == -1) {
                $(fields[i]).parent().css('border', 'none');
            }
        }
        if (missingCounter > 0) {
            toastr.error("Please Enter Fields:" + inCompleteFields);
            //if (e != null) {
               
            //    e.preventDefault();
            //}
            return false;
        }
    
    return true;
}

function ValidateFieldsByClass(ClassName) {
    var missingCounter = 0;
    var fields = $('.'+ClassName); //Array for all textboxes
    var inCompleteFields = "";
    for (var i = 0; i < fields.length; i++) {
        var value = $(fields[i]).val();
        if (value.toString().length == 0) {
            //checking session
            //if ((!document.getElementById("RoleName").value == "SuperAdmin") &&  ($(fields[i])[0].id == "ExpiryDate")){
            //    continue;
            //}
            missingCounter++;
            $(fields[i]).css('border-color', 'red');
            inCompleteFields += "<br/>" + ($(fields[i]).attr('id') + (i + 1 == fields.length ? "" : ", "));
        }
        else
            $(fields[i]).css('border-color', 'gainsboro');
    }
    if (missingCounter > 0) {
        toastr.error("Please Enter Fields:" + inCompleteFields);
        //if (e != null) {

        //    e.preventDefault();
        //}
        return false;
    }

    return true;
}

function validateRadioButtons() {
    var radioButtons = $("input[type=radio]");
    var counter = -1;
    for (var i = 0; i < radioButtons.length; i++) {
        if (radioButtons[i].checked) {
            counter = i;
        }
    }
    if (counter == -1) {
        toastr.error("Please select MergeVarMaps Tags");
        return false;
    } else {
        return true;
    }
}

$(document).ready(function () {
    if ($('#errorMSG').length == 0)
        return;
    if ($('#errorMSG').val().length > 0)
        toastr.error($('#errorMSG').val());
});