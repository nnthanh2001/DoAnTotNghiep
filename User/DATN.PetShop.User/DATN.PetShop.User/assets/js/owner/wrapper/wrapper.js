var request = new window.Restful();
var signIn = new window.SignIn();
var cart = new window.Cart();
var product = new window.Product();
$(function () {
    signIn.init();
    cart.init();
    product.init();
});