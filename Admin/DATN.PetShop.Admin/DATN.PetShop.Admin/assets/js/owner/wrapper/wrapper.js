var request = new window.Restful();
var signIn = new window.SignIn();
var addProduct = new window.addProduct();
var editProduct = new window.editProduct();
var addUser = new window.addUser();
$(function () {
    signIn.init();
    addProduct.init();
    editProduct.init();
    addUser.init();
});