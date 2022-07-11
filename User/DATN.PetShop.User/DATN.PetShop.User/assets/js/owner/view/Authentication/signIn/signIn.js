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
            var data = { "request": "signIn", "_id": id, "data": json };
            var option = { url: signInHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.post()

        });
        $('[jsaction="register"]').off('click').on('click', function () {
            var json = that.registerValue();
            console.log(data);
            var data = { "request": "register", "data": json };
            var option = { url: signInHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.post()

        });
        $('[jsaction="signOut"]').off('click').on('click', function () {

            var data = { "request": "register" };
            var option = { url: signInHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.get()

        });
        $('[jsaction="notification"]').off('click').on('click', function () {
            executeExample('check-login');

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
    function isEmail(email) {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return regex.test(email);
    };
    function isPassword(password) {
        var regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$/;
        return regex.test(password);
    };
    that.bindValue = function () {
        var UserName = $.trim($('[data_value="userName"]').val());
        var Password = $.trim($('[data_value="password"]').val());
        if (UserName != "") {
            if (isEmail(UserName) == false) {
                executeExample(Swal.fire('Email không chính xác, vui lòng nhập lại!'));
                return false;
            }
        }

        if (isPassword(Password) == false) {
            executeExample(Swal.fire('Mật khẩu phải chứa ít nhất 8 kí tự, tối đa 15 kí tự, một chữ số, một kí tự đặc biệt và một chữ in hoa!'));
            return false;

        }
        var json = { "userName": UserName, "password": Password };
        var doc = JSON.stringify(json);
        return doc;
    };
    that.registerValue = function () {
        var userNameRegister = $.trim($('[data_value="userNameRegister"]').val());
        var passwordRegister = $.trim($('[data_value="passwordRegister"]').val());
        var email = $.trim($('[data_value="email"]').val());
        var phone = $.trim($('[data_value="phone"]').val());
        var address = $.trim($('[data_value="address"]').val());

        if (userNameRegister != '' || passwordRegister != '' || email != '' || phone != '' || address != '') {
            if (userNameRegister == '') {
                executeExample(Swal.fire('Chưa nhập tên tài khoản!'));
                return false;
            }
            if (passwordRegister == '') {
                executeExample(Swal.fire('Chưa nhập mật khẩu!'));
                return false;
            }
            else {
                if (isPassword(passwordRegister) == false) {
                    executeExample(Swal.fire('Mật khẩu phải chứa ít nhất 8 kí tự, tối đa 15 kí tự, một chữ số, một kí tự đặc biệt và một chữ in hoa!'));
                    return false;

                }
            }
            if (email == '') {
                executeExample(Swal.fire('Chưa nhập Email!'));
                return false;
            }
            else {
                if (isEmail(email) == false) {
                    executeExample(Swal.fire('Email không chính xác, vui lòng nhập lại!'));
                    return false;
                }
            }
            if (phone == '') {
                executeExample(Swal.fire('Chưa nhập số điện thoại!'));
                return false;
            }
            else {
                if (phone <= 1000000000 || phone >= 100000000000) {
                    executeExample(Swal.fire('Vui lòng nhập đúng số điện thoại!'));
                    return false;
                }
            }
            if (address == '') {
                executeExample(Swal.fire('Chưa nhập địa chỉ!'));
                return false;
            }
        }
        else {
            executeExample(Swal.fire('Bạn chưa điền đầy đủ thông tin!'));
            return false;
        }

        var json = { "userName": userNameRegister, "password": passwordRegister, "email": email, "phone": phone, "address": address, "roleID": 5, "userHandle": "khach-hang", "statusID": 1 };
        var doc = JSON.stringify(json);
        return doc;
    };
    that.result = function (json) {

        console.log(json.message);
        executeExample(Swal.fire(json.message));
        if (json.message == "Đăng nhập thành công!") {
            
            window.location.href = json.href;
        }
    };
};
