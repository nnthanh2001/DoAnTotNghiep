;
var Order = function () {
    var that = this;
    var orderHandlerUrl = "handleRequest/Owner/Order/order.aspx";
    var vars = {

    };
    that.Construction = function () {

    };
    that.Construction();
    that.init = function () {
        that.event();
    };
    that.event = function () {
        $('[jsaction="OrderDetail"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var data = { "request": "orderDetail", "_id": id};
            var option = { url: orderHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.get();
            
        });
        
    };

    that.bindValue = function () {
      
        var doc = JSON.stringify(json);
        return doc;
    };
    that.result = function (json) {

        console.log(json);
        window.location.href = json.href;
    };
};