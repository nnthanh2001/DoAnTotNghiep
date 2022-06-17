;
var SignIn = function () {
    var that = this;
    var signInHandlerUrl = "handleRequest/Authentication/signIn/signIn.aspx";
    var vars = {

    };
    that.Construction = function () {

    };
    that.Construction();
    that.init = function () {
        that.event();
    };
    that.event = function () {
        $('[jsaction="productDetail"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var json = that.bindValue();
            console.log(data);
            var data = { "request": "productDetail", "data": json };
            var option = { url: signInHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.post();
        });

       
    };

    that.bindValue = function () {
        var userName = $.trim($('[data_value="_id"]').val());
        
        var json = { "_id": _id};
        var doc = JSON.stringify(json);
        return doc;
    };
    that.result = function (json) {

        console.log(json);
        window.location.href = json.href;
    };
};
