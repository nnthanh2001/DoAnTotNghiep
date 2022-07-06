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
           
            var data = { "request": "register"};
            var option = { url: signInHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.get()

        });
        $('[jsaction="notification"]').off('click').on('click', function () {
            alert("Bạn chưa đăng nhập! Vui lòng đăng nhập để tiến hành thanh toán...")

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
    }
    that.bindValue = function () {
        var UserName = $.trim($('[data_value="userName"]').val());
        var Password = $.trim($('[data_value="password"]').val());
        if (UserName != "") {
            if (isEmail(UserName) == false) {
                alert("Email không chính xác, vui lòng nhập lại!")
                return false;
            }
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
                alert('Chưa nhập tên tài khoản!');
                return false;
            }
            if (passwordRegister == '') {
                alert('Chưa nhập mật khẩu!');
                return false;
            }
            if (email == '') {
                alert('Chưa nhập email!');
                return false;
            }
            else {
                if (isEmail(email) == false) {
                    alert("Email không chính xác, vui lòng nhập lại!")
                    return false;
                }
            }
            if (phone == '') {
                alert('Chưa nhập số điện thoại');
                return false;
            }
            if (address == '') {
                alert('Chưa nhập địa chỉ!');
                return false;
            }
        }
        else {
            alert('Bạn chưa điền đầy đủ thông tin!');
            return false;
        }

        var json = { "userName": userNameRegister, "password": passwordRegister, "email": email, "phone": phone, "address": address, "roleID": 5, "userHandle": "khach-hang", "statusID": 1 };
        var doc = JSON.stringify(json);
        return doc;
    };
    that.result = function (json) {

        console.log(json);
        alert(json.message);
        if (json.message == "Đăng nhập thành công!") {
            window.location.href = json.href;
        }
    };
};
