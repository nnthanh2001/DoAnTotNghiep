;
var addUser = function () {
    var that = this;
    var usertHandlerUrl = "handleRequest/User/AddUser/addUser.aspx";
   
    var vars = {

    };
    that.Construction = function () {

    };
    that.Construction();
    that.init = function () {
        that.event();
    };
    that.event = function () {
        $('[jsaction="addUserButton"]').off('click').on('click', function () {
            alert("Thêm nhân viên thành công");
            var json = that.bindValue();
            console.log(json);
            var data = { "request": "addUser", "data": json };
            var option = { url: usertHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.post();
        });
    };

    that.bindValue = function () {
        var userName = $.trim($('[data_value="userName"]').val());
        var userID = $.trim($('[data_value="userID"]').val());
        var roleID = $.trim($('[data_value="roleID"]').val());
        var email = $.trim($('[data_value="email"]').val());
        var address = $.trim($('[data_value="address"]').val());
        var phone = $.trim($('[data_value="phone"]').val());
        var password = $.trim($('[data_value="password"]').val());
        var statusID = $.trim($('[data_value="statusID"]').val());
       

        var json = { "userName": userName, "userID": userID, "roleID": roleID, "email": email, "address": address, "phone": phone, "password": password,"statusID": statusID };
        var doc = JSON.stringify(json);
        return doc;
    };
    that.result = function (json) {

        console.log(json);
        window.location.href = json.href;
    };
};