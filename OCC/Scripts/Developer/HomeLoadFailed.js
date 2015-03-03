$(function () {    
    $("#CloseErrorMessage").on("click", CloseError);
});

function CloseError() {
    $("#ErrorMessage").hide();
};
