
$(document).ready(function () {
    $("#password-view").on("click", function () {
        var type = $("#password").attr('type') === "text" ? "password" : "text";
        $("#password").prop('type', type);
    });

    $("#confirm-view").on("click", function () {
        var type = $("#confirm").attr('type') == "text" ? "password" : "text";
        $("#confirm").prop('type', type);
    });

    $("#password-view-login").on("click", function () {
        var type = $("#login-password").attr('type') == "text" ? "password" : "text";
        $("#login-password").prop('type', type);
    });
})