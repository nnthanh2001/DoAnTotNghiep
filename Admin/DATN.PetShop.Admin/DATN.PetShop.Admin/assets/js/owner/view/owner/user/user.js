;
var User = function () {
    var that = this;
    var usertHandlerUrl = "handleRequest/Owner/User/user.aspx";

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
            var json = that.bindValue();
            console.log(json);
            var data = { "request": "addUser", "data": json };
            var option = { url: usertHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.post();
            alert("Thêm nhân viên thành công");
        });
        $('[jsaction="editUserButton"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var json = that.bindValue();
            console.log(json);
            var data = { "request": "editUser", "_id": id, "data": json };
            var option = { url: usertHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.put();
            alert("Đã lưu thay đổi");
        });
        $('[jsaction="deleteUserButton"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var data = { "request": "deleteUser", "_id": id };
            var option = { url: usertHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.delete();
            alert("Xóa thành công");
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


        var json = { "userName": userName, "userID": userID, "roleID": roleID, "email": email, "address": address, "phone": phone, "password": password, "statusID": statusID };
        var doc = JSON.stringify(json);
        return doc;
    };
    that.result = function (json) {

        console.log(json);
        window.location.href = json.href;
    };
};