function OnBegin() {
    alert("This is the OnBegin Callback");
}
function OnSuccess(data) {
    $('.reviewForm-content').val('');
    $('#Name').val('');
}
function OnFailure(request, error) {
    alert("This is the OnFailure Callback:" + error);
}
function OnComplete(request, status) {
    alert("This is the OnComplete Callback: " + status);
}