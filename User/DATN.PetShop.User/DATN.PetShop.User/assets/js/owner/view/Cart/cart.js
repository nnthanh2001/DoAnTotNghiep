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
            executeExample('handleDismiss');
        });
        $('[jsaction="deleteAllButton"]').off('click').on('click', function () {

            var data = { "request": "deleteAll" };
            var option = { url: cartHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.delete();
            location.reload(true);

        });

        $('[jsaction="checkListProduct"]').off('click').on('click', function () {
            executeExample('basicMessage');
        });
    };
    that.bindValue = function () {

        var userName = $.trim($('[data_value="userName"]').val());
        var email = $.trim($('[data_value="email"]').val());
        var addressDelivery = $.trim($('[data_value="addressDelivery"]').val());
        var phone = $.trim($('[data_value="phone"]').val());

        var json = { "userName": userName, "email": email, "addressDelivery": addressDelivery, "phone": phone };
        var doc = JSON.stringify(json);
        return doc;
    };

    that.addItemToCart = function () {
        executeExample('mixin');
        if (request != null) {
            location.reload(true);
        }
    };

    that.result = function (json) {

        console.log(json);
        that.addItemToCart();
        window.location.href = json.href;


    };
};