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


        $('[jsaction="Order"]').off('click').on('click', function () {
            var data = { "request": "order" };
            var option = { url: orderHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.post();
            
        });
    };

    that.result = function (json) {

        console.log(json);
        executeExample('basicMessage');
        window.location.href = json.href;
    };
};