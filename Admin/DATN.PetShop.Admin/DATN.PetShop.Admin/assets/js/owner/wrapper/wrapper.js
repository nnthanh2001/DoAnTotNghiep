var request = new window.Restful();
var signIn = new window.SignIn();
var product = new window.Product();
var user = new window.User();
var order = new window.Order();
var service = new window.Service();

$(function () {
    signIn.init();
    product.init();
    user.init();
    order.init();
    service.init();
});