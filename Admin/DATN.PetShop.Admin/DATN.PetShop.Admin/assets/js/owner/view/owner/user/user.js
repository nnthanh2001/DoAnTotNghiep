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

        });
        $('[jsaction="editUserButton"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var json = that.bindValue();
            console.log(json);
            var data = { "request": "editUser", "_id": id, "data": json };
            var option = { url: usertHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.put();

        });
        $('[jsaction="deleteUserButton"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var data = { "request": "deleteUser", "_id": id };
            var option = { url: usertHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            executeExample('handleDismiss');
            

        });
    };
    function isEmail(email) {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(email);
    }
    function isPassword(password) {
        var regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$/;
        return regex.test(password);
    }

    that.bindValue = function () {
        var userName = $.trim($('[data_value="userName"]').val());
        /*var date = $.trim($('[data_value="date"]').val());*/

        var roleID = $.trim($('[data_value="roleID"]').val());
        var email = $.trim($('[data_value="email"]').val());
        var address = $.trim($('[data_value="address"]').val());
        var phone = $.trim($('[data_value="phone"]').val());
        var password = $.trim($('[data_value="password"]').val());
        var reTypePassword = $.trim($('[data_value="reTypePassword"]').val());
        var statusID = $.trim($('[data_value="statusID"]').val());


        if (userName == null || userName == "") {
            executeExample(Swal.fire('Bạn phải nhập tên nhân viên!'));
            return null;
        }
        if (phone <= 1000000000 && phone >= 100000000000) {
            executeExample(Swal.fire('Vui lòng nhập đúng số điện thoại!'));
            return null;
        }

        if (email == null || email == "") {
            executeExample(Swal.fire('Bạn phải nhập email!'));
            return null;
        } else {
            if (isEmail(email) == false) {
                executeExample(Swal.fire('Email không chính xác, vui lòng nhập lại!'));
                return false;
            }
        }
        if (address == null || address == "") {
            executeExample(Swal.fire('Bạn phải nhập địa chỉ!'));
            return null;
        }
        if (password == null || password == "") {
            executeExample(Swal.fire('Bạn phải nhập mật khẩu!'));
            return null;
        }else {
            if (isPassword(password) == false) {
                executeExample(Swal.fire('Mật khẩu phải chứa ít nhất 8 kí tự, tối đa 15 kí tự, một chữ số, một kí tự đặc biệt và một chữ in hoa!'));
                return false;
            }
        }

        if (reTypePassword == null || reTypePassword == "") {
            executeExample(Swal.fire('Bạn phải nhập lại mật khẩu!'));
            return null;
        } else {
            if (reTypePassword != password) {
                executeExample(Swal.fire('Mật khẩu không khớp!'));
                return null;
            }
        }

        var json = { "userName": userName, "userID": 0, "roleID": roleID, "email": email, "address": address, "phone": phone, "password": password, "statusID": statusID };
        var doc = JSON.stringify(json);
        return doc;
    };
    that.result = function (json) {
        console.log(json.message);
        executeExample(Swal.fire(json.message));
        window.location.href = json.href;
    };
};