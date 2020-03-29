$(function () {
    $("#tblArama").on("click", ".btnAra", function () {
        alert("click");
    });
});
function CheckDataTypeIsValid(dataElement) {
    var value = $(dataElement).val();
    if (value == '') {
        $(dataElement).valid("false");
    }
    else {
        $(dataElement).valid();
    }
}