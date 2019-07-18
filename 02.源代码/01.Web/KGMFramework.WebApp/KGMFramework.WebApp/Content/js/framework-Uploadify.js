var router = $.request('router');
$(function () {
    $('#upEx').fileinput({
        language: 'zh',
        uploadUrl: '/' + router + '/UploadifyFile',
        allowedFileExtensions: ['xlsx', 'xls'],
        uploadsync: true
    }).on("fileuploaded", function (event, data, previewId, index) {
        if (router == 'AssetInformation') {
            if (data.response.message == "未读取到文件") {
                $.modalMsg(data.response.message, data.response.state);
                $.modalClose();
            }
            else {
                data.response.message = data.response.message.replace("上传成功!", "");
                var data = data.response.message;
                var id = guid();
                sessionStorage.setItem(id, data);
                ////弹出一个对话框
                $.modalOpen({
                    id: "AssetInformation",
                    title: '导入结果',
                    url: '/AssetManage/AssetInformation/DaoRu?id=' + escape(id),
                    width: "650px",
                    height: "500px",
                    closeBtn: 1,
                    callBack: function (iframeId) {

                    }
                });

                $.modalClose();
            }
        } else if (router == "StockMake") {
            alert(2222);
        }
            
        else {
            $.modalMsg(data.response.message, data.response.state);
            $.modalClose();
        }
    });
})

