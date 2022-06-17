var request = new window.Restful();
var signIn = new window.SignIn();
var addProduct = new window.addProduct();
var editProduct = new window.editProduct();
$(function () {
    signIn.init();
    addProduct.init();
    editProduct.init();
});