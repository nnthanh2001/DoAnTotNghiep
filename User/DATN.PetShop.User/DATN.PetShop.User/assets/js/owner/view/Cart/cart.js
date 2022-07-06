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
            alert("Thêm vào giỏ hàng thành công");
            location.reload(true);
            
        });
        $('[jsaction="deleteItemButton"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var data = { "request": "deleteItem", "_id": id };
            var option = { url: cartHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.delete();
            location.reload(true);
            
        });
        $('[jsaction="deleteAllButton"]').off('click').on('click', function () {
            
            var data = { "request": "deleteAll" };
            var option = { url: cartHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.delete();
            location.reload(true);
        });
        $('[jsaction="checkOut"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var json = that.bindValue();
            console.log(json);
            var data = { "request": "order", "_id": id, "data": json };
            var option = { url: cartHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.post();
            

        });
        $('[jsaction="checkListProduct"]').off('click').on('click', function () {
            alert("Trong giỏ hàng không có sản phẩm nào không thể thanh toán!");
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