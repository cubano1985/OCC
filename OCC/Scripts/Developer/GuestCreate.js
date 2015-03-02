/// <reference path="../jquery-2.1.3.intellisense.js" />
function SubmitCheck(event) {
    event.preventDefault();
    var name = $("#Name").val();
    var surname = $("#Surname").val();
    $.post("/Ajax/ValidateNameSurname",
        { name: name, surname: surname },
        function (data) {
            ValidationResult(data, name, surname);
        })
};

$(function () {
    $("#CreateSubmit").on("submit", SubmitCheck);
    $("#CloseErrorMessage").on("click", CloseError);
});

function ValidationResult(data, name, surname) {
    if (data == true) {
        $("#ErrorMessage").show();
        $("#ErrorMessageText").html("Guest " + name + " " + surname + " has already been invited.")
    }
    else {
        $("#CreateSubmit").unbind("submit").submit();
    }
};

function CloseError() {
    $("#ErrorMessage").hide();
};