/// <reference path="../jquery-2.1.3.intellisense.js" />
function SubmitCheck(event) {
    event.preventDefault();
    $("#ErrorMessageText").html("");
    $("#ErrorMessage").hide();
    var name = $("#Name").val();
    var surname = $("#Surname").val();
    $.post("/Ajax/ValidateNameSurname",
        { name: name, surname: surname },
        function (data) {
            ValidationResult(data, name, surname);
        })
};

$(function () {
    $("#CreateGuestForm").on("submit", SubmitCheck);
    $("#CloseErrorMessage").on("click", CloseError);
    //$('.ui.form').form({
    //    name: {
    //        identifier: 'Name',
    //        rules: [
    //          {
    //              type: 'empty',
    //              prompt: 'Please enter guest First-Name'
    //          }
    //        ]
    //    },
    //    surname: {
    //        identifier: 'Surname',
    //        rules: [
    //          {
    //              type: 'empty',
    //              prompt: 'Please enter guest Second-Name'
    //          }
    //        ]
    //    }
    //});
});

function ValidationResult(data, name, surname) {
    if (data == true) {
        $("#ErrorMessage").show();
        if ((name != "") && (surname != "")) {
            $("#ErrorMessageText").html("Guest " + name + " " + surname + " has already been invited.")
        }
        
    }
    else {
        $("#CreateGuestForm").unbind("submit").submit();
    }
};

function CloseError() {
    $("#ErrorMessage").hide();
};

