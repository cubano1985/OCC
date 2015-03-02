/// <reference path="../jquery-2.1.3.intellisense.js" />
$('.ui.checkbox')
  .checkbox();

$(function () {
    $(".checked").prop("checked", "checked");
    $(".guestResponse").on("click", GuestStatusChange);
});

function GuestStatusChange(element) {
    var radioCaller = $(element.target);
    var id = radioCaller.data("guest-id");
    var status = radioCaller.data("guest-status");
    $.post("/Ajax/ChangeStatus", { guestId: id, newStatus: status });
};