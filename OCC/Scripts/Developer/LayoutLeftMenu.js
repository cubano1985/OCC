/// <reference path="../jquery-2.1.3.intellisense.js" />
$(function () {
    $('.ui.dropdown').dropdown();
    $("#saveAllGuests").on("click", SaveAll);
    $("#saveAttendingGuests").on("click", SaveAttending)
})

function SaveAll() {
    $.post("/Ajax/SaveAllGuests", null, function (data) {
        alert("Full guest list was saved to " + data);
    })
}

function SaveAttending() {
    $.post("/Ajax/SaveAttendingGuests", null, function (data) {
        alert("Only Attending guest list was saved to " + data);
    })
}