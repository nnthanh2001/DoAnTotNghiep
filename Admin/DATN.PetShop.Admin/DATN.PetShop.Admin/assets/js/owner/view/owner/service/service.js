;
var Service = function () {
    var that = this;
    var serviceHandlerUrl = "handleRequest/Owner/Service/service.aspx";
    var vars = {

    };
    that.Construction = function () {

    };
    that.Construction();
    that.init = function () {
        that.event();
    };
    that.event = function () {
        $('[jsaction="addServiceButton"]').off('click').on('click', function () {
            var json = that.bindValue();
            console.log(json);
            var data = { "request": "addProduct", "data": json };
            var option = { url: serviceHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.post();
            alert("Thêm dịch vụ thành công");
        });
        $('[jsaction="editServiceButton"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var json = that.bindValue();
            console.log(json);
            var data = { "request": "edit", "_id": id, "data": json };
            var option = { url: serviceHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.put();
            alert("Đã lưu thay đổi");
        });
        $('[jsaction="deleteServiceButton"]').off('click').on('click', function () {
            var id = $(this).attr('value');
            var data = { "request": "deleteProduct", "_id": id };
            var option = { url: serviceHandlerUrl, data: data, callback: that.result };
            request.constructor(option);
            request.delete();
            alert("Xóa dịch vụ thành công");
        });
    };

    that.bindValue = function () {
        var serviceName = $.trim($('[data_value="serviceName"]').val());
        var serviceID = $.trim($('[data_value="serviceID"]').val());
        var image = $.trim($('[data_value="image"]').val());
        var condition = $.trim($('[data_value="condition"]').val());
        var price = $.trim($('[data_value="price"]').val());
        var unit = $.trim($('[data_value="unit"]').val());
        var statusID = $.trim($('[data_value="statusID"]').val());
        var description = $.trim($('[data_value="description"]').val());
       

        var json = { "serviceName": serviceName, "serviceID": serviceID, "image": image, "condition": condition, "price": price, "unit": unit, "statusID": statusID, "description": description};
        var doc = JSON.stringify(json);
        return doc;
    };
    that.result = function (json) {

        console.log(json);
        window.location.href = json.href;
    };
};