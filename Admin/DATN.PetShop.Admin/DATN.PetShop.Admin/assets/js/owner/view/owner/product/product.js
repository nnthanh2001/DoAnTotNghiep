;
var Product = function () {
    var that = this;
    var productHandlerUrl = "handleRequest/Owner/Product/product.aspx";
    var vars = {

    };
    that.Construction = function () {

    };
    that.Construction();
    that.init = function () {
        that.event();
    };
    that.event = function () {
        $('[jsaction="addProductButton"]').off('click').on('click', function () {
            var json = that.bindValue();
            console.log(json);
            var data = { "request": "addProduct", "data": json };
            var option = { url: productHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.post();



        });
        $('[jsaction="editProductButton"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var json = that.update();
            console.log(json);
            var data = { "request": "edit", "_id": id, "data": json };
            var option = { url: productHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.put();

        });
        $('[jsaction="deleteProductButton"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var data = { "request": "deleteProduct", "_id": id };
            var option = { url: productHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            executeExample('handleDismiss');
            /* request.delete();*/


        });
        //$('[jsaction="search"]').keypress(function (event) {
        //    var keycode = (event.keyCode ? event.keyCode : event.which);
        //    if (keycode == '13') {
        //        var id = $.trim($('[value=""]').val());
        //        var data = { "request": "searchProduct", "_id": id };
        //        var option = { url: productHandlerUrl, data: data, callback: that.result };
        //        request.constructor(option);
        //        request.get();
        //        alert("tìm kiếm");
        //    }
        //});
        $('[jsaction="search"]').keypress(function (event) {
            var keycode = (event.keyCode ? event.keyCode : event.which);
            if (keycode == '13') {
                changeUrl(a.attr('href'));
            }

        });
        //$('a').click(function () {
        //    changeUrl(a.attr('href'));
        //});
        //$('a').attr('href', '#');
        //$('button').off('click').on('click', function (e) {
        //    if (e.keyCode == 13) {
        //        //event
        //    }
        //});
    };

    that.bindValue = function () {
        var productName = $.trim($('[data_value="productName"]').val());
       
        var image = $.trim($('[data_value="image"]').val());
        var quantity = $.trim($('[data_value="quantity"]').val());
        var price = $.trim($('[data_value="price"]').val());
        var petTypeID = $.trim($('[data_value="petTypeID"]').val());
        var statusID = $.trim($('[data_value="statusID"]').val());
        var categoryID = $.trim($('[data_value="categoryID"]').val());
        var description = $.trim($('[data_value="description"]').val());
        var productHandle = $.trim($('[data_value="productHandle"]').val());
        var usingExpired = $('[data_value="usingExpired"]')[0].checked;
        var bestProductExpired = $.trim($('[data_value="bestProductExpired"]').val());

        if (productName == null || productName == "") {
            executeExample(Swal.fire('Bạn phải nhập tên sản phẩm!'));
            return null;
        }
        if (quantity <= 0) {
            executeExample(Swal.fire('Bạn phải nhập số lượng sản phẩm!'));
            return null;
        }
        if (price == 0) {
            executeExample(Swal.fire('Bạn phải nhập giá bán sản phẩm!'));
            return null;
        } else {
            if (price <= 1000) {
                executeExample(Swal.fire('Giá bán không phù hợp!'));
                return null;
            }
        }
        if (description == null || description == "") {
            executeExample(Swal.fire('Bạn phải nhập mô tả sản phẩm!'));
            return null;
        }
        //if (image == null || image == "") {
        //    executeExample(Swal.fire('Bạn phải thêm ảnh cho sản phẩm!'));
        //    return null;
        //}


        var json = { "productName": productName, "productID": 0, "image": image, "quantity": quantity, "price": price, "petTypeID": petTypeID, "statusID": statusID, "categoryID": categoryID, "description": description, "productHandle": productHandle, "usingExpired": usingExpired, "bestProductExpired": bestProductExpired, };
        var doc = JSON.stringify(json);
        return doc;
    };

    that.update = function () {
        var productName = $.trim($('[data_value="productName"]').val());

        var image = $.trim($('[data_value="image"]').val());
        var quantity = $.trim($('[data_value="quantity"]').val());
        var productID = $.trim($('[data_value="productID"]').val());
        var price = $.trim($('[data_value="price"]').val());
        var petTypeID = $.trim($('[data_value="petTypeID"]').val());
        var statusID = $.trim($('[data_value="statusID"]').val());
        var categoryID = $.trim($('[data_value="categoryID"]').val());
        var description = $.trim($('[data_value="description"]').val());
        var productHandle = $.trim($('[data_value="productHandle"]').val());
        var usingExpired = $('[data_value="usingExpired"]')[0].checked;
        var bestProductExpired = $.trim($('[data_value="bestProductExpired"]').val());

        if (productName == null || productName == "") {
            executeExample(Swal.fire('Bạn phải nhập tên sản phẩm!'));
            return null;
        }
        if (quantity <= 0) {
            executeExample(Swal.fire('Bạn phải nhập số lượng sản phẩm!'));
            return null;
        }
        if (price == 0) {
            executeExample(Swal.fire('Bạn phải nhập giá bán sản phẩm!'));
            return null;
        } else {
            if (price <= 1000) {
                executeExample(Swal.fire('Giá bán không phù hợp!'));
                return null;
            }
        }
        if (description == null || description == "") {
            executeExample(Swal.fire('Bạn phải nhập mô tả sản phẩm!'));
            return null;
        }
        //if (image == null || image == "") {
        //    executeExample(Swal.fire('Bạn phải thêm ảnh cho sản phẩm!'));
        //    return null;
        //}


        var json = { "productName": productName, "productID": productID, "image": image, "quantity": quantity, "price": price, "petTypeID": petTypeID, "statusID": statusID, "categoryID": categoryID, "description": description, "productHandle": productHandle, "usingExpired": usingExpired, "bestProductExpired": bestProductExpired, };
        var doc = JSON.stringify(json);
        return doc;
    };

    that.result = function (json) {
        console.log(json.message);



        //swalWithBootstrapButtons.fire(
        //    'Xóa!',
        //    'Xóa sản phẩm thành công!',
        //    'success'
        //    )
        executeExample(Swal.fire(json.message));
        window.location.href = json.href;
    };
};