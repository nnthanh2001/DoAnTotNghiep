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
        $('[jsaction="signIn"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var json = that.bindValue();
            console.log(data);
            var data = { "request": "signIn", "data": json };
            var option = { url: signInHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.post()
               
        });

        //$('[data_value="userName"]').off('keypress keyup').on('keypress keyup', function (e) {
        //    var keycode = e.keyCode;
        //    if (keycode === 13) {
        //        var id = $(this).attr('value');
        //        var data = that.bindValue();
        //    } else {

        //        //check email valid,...
        //    };
            
        //});
    };

    that.bindValue = function () {
        var userName =$.trim($('[data_value="userName"]').val());
        var password = $.trim($('[data_value="password"]').val());
        var json = { "UserName": userName, "Password": password };
        var doc = JSON.stringify(json);
        return doc;
    };
    that.result = function (json) {

        console.log(json);       
        window.location.href = json.href;
    };
};
