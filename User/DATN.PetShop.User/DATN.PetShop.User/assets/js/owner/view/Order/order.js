﻿;
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


        $('[jsaction="Order"]').off('click').on('click', function () {
            var data = { "request": "order" };
            var option = { url: orderHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.post();
            alert("Đơn hàng của bạn đã được nhận. Cảm ơn bạn đã mua hàng");

        });
    };

    that.result = function (json) {

        console.log(json);
        //window.location.href = json.href;
    };
};