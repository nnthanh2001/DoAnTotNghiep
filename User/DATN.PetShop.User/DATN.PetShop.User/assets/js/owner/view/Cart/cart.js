;
var Cart = function () {
    var that = this;
    var cartHandlerUrl = "handleRequest/Cart/cart.aspx";
    var vars = {

    };
    that.Construction = function () {

    };
    that.Construction();
    that.init = function () {
        that.event();
    };
    that.event = function () {
        $('[jsaction="addItemToCartButton"]').off('click').on('click', function () {
            alert("Thêm vào giỏ hàng thành công");
            var id = $(this).attr('value');
            var data = { "request": "addItem", "_id": id };
            var option = { url: cartHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.post();
            
        });
        $('[jsaction="deleteItemButton"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var data = { "request": "deleteItem", "_id": id };
            var option = { url: cartHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.delete();
            alert("Xóa sản phẩm thành công");
        });
    };
    that.bindValue = function () {
        var userName = $.trim($('[data_value="userName"]').val());
        var email = $.trim($('[data_value="email"]').val());
        var addressDelivery = $.trim($('[data_value="addressDelivery"]').val());
        var phone = $.trim($('[data_value="phone"]').val());
        var json = { "userName": userName, "email": email, "addressDelivery": addressDelivery, "phone": phone};
        var doc = JSON.stringify(json);
        return doc;
    };
    that.result = function (json) {

        console.log(json);
        //window.location.href = json.href;
    };
};