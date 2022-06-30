;
var Cart = function () {
    var that = this;
    var cartHandlerUrl = "handleRequest/Cart/cart.aspx";
    var vars = {

    };
    that.Construction = function () {

    };
    that.Construction();
    that.init = function () {
        that.event();
    };
    that.event = function () {
        $('[jsaction="addItemToCartButton"]').off('click').on('click', function () {
            alert("Thêm vào giỏ hàng thành công");
           
            var id = $(this).attr('value');
            var data = { "request": "addItem", "_id": id };
            var option = { url: cartHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.post();
            
        });
        $('[jsaction=""]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var json = that.bindValue();
            console.log(json);
            var data = { "request": "edit", "_id": id, "data": json };
            var option = { url: cartHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.put();
            alert("Đã lưu thay đổi");
        });
        $('[jsaction="deleteItemButton"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var data = { "request": "deleteItem", "_id": id };
            var option = { url: cartHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.delete();
            alert("Xóa sản phẩm thành công");
        });
    };
    that.bindValue = function () {
        var productName = $.trim($('[data_value="productName"]').val());
        var price = $.trim($('[data_value="price"]').val());
        var json = { "productName": productName, "price": price};
        var doc = JSON.stringify(json);
        return doc;
    };
    //that.bindValue = function () {
    //    var productName = $.trim($('[data_value="productName"]').val());
    //    var productID = $.trim($('[data_value="productID"]').val());
    //    var quantity = $.trim($('[data_value="quantity"]').val());
    //    var price = $.trim($('[data_value="price"]').val());
    //    var petTypeID = $.trim($('[data_value="petTypeID"]').val());
    //    var statusID = $.trim($('[data_value="statusID"]').val());
    //    var categoryID = $.trim($('[data_value="categoryID"]').val());
    //    var description = $.trim($('[data_value="description"]').val());
    //    var productHandle = $.trim($('[data_value="productHandle"]').val());
    //    var usingExpired = $('[data_value="usingExpired"]')[0].checked;
    //    var bestProductExpired = $.trim($('[data_value="bestProductExpired"]').val());

    //    var json = { "productName": productName, "productID": productID, "quantity": quantity, "price": price, "petTypeID": petTypeID, "statusID": statusID, "categoryID": categoryID, "description": description, "productHandle": productHandle, "usingExpired": usingExpired, "bestProductExpired": bestProductExpired, };
    //    var doc = JSON.stringify(json);
    //    return doc;
    //};
    that.result = function (json) {

        console.log(json);
        //window.location.href = json.href;
    };
};