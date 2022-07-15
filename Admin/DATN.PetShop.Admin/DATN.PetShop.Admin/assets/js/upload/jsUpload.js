$(document).ready(function () {
    $("#btnUpload").unbind("click").click(function () {
        $('#fileUploadVersion').val('');
        $('#fileUploadVersion').click();
    });
    $('#fileUploadVersion').unbind('change').change(function () {
        var image = $('#fileUploadVersion')[0].files;
        var file = image;
        var formData = new FormData();
        for (var i = 0; i < file.length; i++) {
            //formData.append('data', dataPost);
            formData.append('file' + i, file[i]);
            formData.append('type' + i, file[i].type);
            formData.append('name' + i, file[i].name);
            formData.append('size' + i, file[i].size);
        };
        //formData.append('upload_type', upload_type);            
        formData.append('flag', "ajax.upload");
        var options = {};
        var percentComplete = 0;
        options.xhr = function () {
            var xhr = new window.XMLHttpRequest();
            xhr.upload.addEventListener("progress", function (evt) {
                if (evt.lengthComputable) { console.log(evt.lengthComputable); }
            }, false);

            return xhr;
        };
        options.url = "assets/ajax/upload.ashx";
        options.type = "POST";
        options.data = formData;
        options.contentType = false;
        options.processData = false;
        options.success = function (result) {
            if (result !== "") {
                if (result === "-1") { //dinh dang file ko hop le
                    alert("Định dạng tệp ko hợp lệ: .exe, .msi, .rar");
                } else if (result === "-2") { //file > 5M
                    alert("Tệp tải lên phải < 300M");
                } else {
                    var kq = jQuery.parseJSON(unescape(result));
                    $('[data-img="upload"] img').attr("src", kq[0].url);
                    $('[data_value="image"]').val(kq[0].url);
                }
            }
        };
        options.error = function (err) {
            options.error = function (err) {
                try {
                    alert(err.statusText);
                } catch (ex) {
                    console.log(ex);
                }
            };
        };
        $.ajax(options);
    });
});