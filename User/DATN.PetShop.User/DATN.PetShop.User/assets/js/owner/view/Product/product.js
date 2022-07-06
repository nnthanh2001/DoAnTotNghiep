;
var Product = function () {
    var that = this;
    var productHandlerUrl = "handleRequest/Product/ProductFilter.aspx";
    var vars = {

    };
    that.Construction = function () {

    };
    that.Construction();
    that.init = function () {
        that.event();
    };
    that.event = function () {
        $('[jsaction="filterProductByCategory"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var data = { "request": "filterProduct", "_id": id };
            var option = { url: productHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.get();

        });
    };
    $('[jsaction="deleteProductButton"]').off('click').on('click', function () {
        var id = $(this).attr('value');
        var data = { "request": "deleteProduct", "_id": id };
        var option = { url: productHandlerUrl, data: data, callback: that.result };
        request.constructor(option);
        request.delete();
        alert("Xóa sản phẩm thành công");
    });
    that.bindValue = function () {

    };

    that.result = function (json) {

        console.log(json);

    };
};