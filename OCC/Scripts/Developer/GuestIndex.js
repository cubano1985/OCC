/// <reference path="../jquery-2.1.3.intellisense.js" />
$(function () {
    $(".checked").prop("checked", "checked");
    $(".guestResponse").on("click", GuestStatusChange);
    $('.ui.checkbox').checkbox();
});

//Function that uses Ajax to invoke controller action to chance guest status.
function GuestStatusChange(element) {
    var radioCaller = $(element.target);
    var id = radioCaller.data("guest-id");
    var status = radioCaller.data("guest-status");
    $.post("/Ajax/ChangeStatus", { guestId: id, newStatus: status });
};