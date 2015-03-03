/// <reference path="../jquery-2.1.3.intellisense.js" />
$(function () {
    $("#CreateGuestForm").on("submit", SubmitCheck);
    $("#CloseErrorMessage").on("click", CloseError);
});

//Validation function that prevents submit, uses Ajax to check if guest was already invited.
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

//Takes action according to validation result, shows message when there are problems or submits the form otherwise.
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

//Function to hide error message.
function CloseError() {
    $("#ErrorMessage").hide();
};

