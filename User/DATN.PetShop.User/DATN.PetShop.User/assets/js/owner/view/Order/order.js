;
var Order = function () {
    var that = this;
    var orderHandlerUrl = "handleRequest/Order/Order.aspx";
    var vars = {

    };
    that.Construction = function () {

    };
    that.Construction();
    that.init = function () {
        that.event();
    };
    that.event = function () {
       
        $('[jsaction="checkOut"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var json = that.bindValue();
            console.log(json);
            var data = { "request": "order", "_id": id, "data": json };
            var option = { url: orderHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.post();

        });
        $('[jsaction="Order"]').off('click').on('click', function () {
            alert("Đơn hàng của bạn đã được nhận. Cảm ơn bạn đã mua hàng");
            var id = $(this).attr('value');
            var json = that.bindValue();
            console.log(json);
            var data = { "request": "edit", "_id": id, "data": json };
            var option = { url: orderHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.post();

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
    that.result = function (json) {

        console.log(json);
        //window.location.href = json.href;
    };
};