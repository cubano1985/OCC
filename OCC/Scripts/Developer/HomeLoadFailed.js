$(function () {    
    $("#CloseErrorMessage").on("click", CloseError);
});

//Function to hide error message.
function CloseError() {
    $("#ErrorMessage").hide();
};
