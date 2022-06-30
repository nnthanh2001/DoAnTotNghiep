var request = new window.Restful();
var signIn = new window.SignIn();
var product = new window.Product();
var user = new window.User();
$(function () {
    signIn.init();
    product.init();
    user.init();
});