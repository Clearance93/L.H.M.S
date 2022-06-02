 
$(document).ready(function () {
    $('#myTable').DataTable();

$('#theme').on("change", function () {
    var item = $("#theme option:selected").text();

    $.post("/Home/SetTheme", {
        data: item
    });
});

//$(function Loading() {
//    $('input[type=checkbox]').prop("disabled", true);
//    $(this).prop('disabled', true);
//    $('select').prop('disabled', true)

//    $(".progress").hide("fede");
//});

//$.ajax(
//    $(".;progress").show("fade", function () {
//        $(".alert-success").fadeto(2000, 500).slideUp(500, function () {
//            $('input[type=checkbox]').prop("disabled", false);
//            $("#SaveSelectedUser").prop('disabled', false);
//            $('select').prop('disabled', false);
//        });

//        $('input[type=checkbox]').prop("disabled", false);
//        $("#SaveSelectedUser").prop('disabled', false);
//        $('select').prop('disabled', false);
//    })
//)

