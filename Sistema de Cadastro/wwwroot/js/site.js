// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function setDataTable(id) {
    $(id).DataTable();

}

$(document).ready(function() {

    setDataTable('#table-contacts');
    setDataTable("#table-users");
})


$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

