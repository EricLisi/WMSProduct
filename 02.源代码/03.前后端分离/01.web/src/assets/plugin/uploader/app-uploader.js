/*
 * 版 本 Learun-ADMS V7.0.0 力软敏捷开 发 框架(http://www.app.cn)
 * Copyright (c) 2013-2018 上海力软 信息技术有限公司
 * 创建人：力软-前端开发组
 * 日 期：2017.05.24
 * 描 述：app-uploader 表单附件选择插件
 */
(function ($, app) {
    "use strict";

    $.appUploader = {
        init: function ($self) {
            var dfop = $self[0]._appUploader.dfop;
            $.appUploader.initRender($self, dfop);
        },
        initRender: function ($self, dfop) {
            $self.attr('type', 'app-Uploader').addClass('appUploader-wrap');
            var $wrap = $('<div class="appUploader-input" ></div>');

            var $btnGroup = $('<div class="appUploader-btn-group"></div>');
            var $uploadBtn = $('<a id="appUploader_uploadBtn_' + dfop.id + '" class="btn btn-success appUploader-input-btn">上传</a>');
            var $downBtn = $('<a id="appUploader_downBtn_' + dfop.id + '" class="btn btn-danger appUploader-input-btn">下载</a>');

            $self.append($wrap);

            $btnGroup.append($uploadBtn);
            $btnGroup.append($downBtn);
            $self.append($btnGroup);

            $uploadBtn.on('click', $.appUploader.openUploadForm);
            $downBtn.on('click', $.appUploader.openDownForm);
           
        },
        openUploadForm: function () {
            var $btn = $(this);
            var $self = $btn.parents('.appUploader-wrap');
            var dfop = $self[0]._appUploader.dfop;
            app.layerForm({
                id: dfop.id,
                title: dfop.placeholder,
                url: top.$.rootUrl + '/LR_SystemModule/Annexes/UploadForm?keyVaule=' + dfop.value + "&extensions=" + dfop.extensions,
                width: 600,
                height: 400,
                maxmin: true,
                btn: null,
                end: function () {
                    app.HTTP_REQUEST_UTILS.httpAsync('GET',top.$.rootUrl + '/LR_SystemModule/Annexes/GetFileNames?folderId=' + dfop.value, function (res) {
                        if (res.code == app.httpCode.success) {
                            $('#' + dfop.id).find('.appUploader-input').text(res.info);
                        }
                    });
                }
            });
        },
        openDownForm: function () {
            var $btn = $(this);
            var $self = $btn.parents('.appUploader-wrap');
            var dfop = $self[0]._appUploader.dfop;
            app.layerForm({
                id: dfop.id,
                title: dfop.placeholder,
                url: top.$.rootUrl + '/LR_SystemModule/Annexes/DownForm?keyVaule=' + dfop.value,
                width: 600,
                height: 400,
                maxmin: true,
                btn: null
            });
        }
    };

    $.fn.appUploader = function (op) {
        var $this = $(this);
        if (!!$this[0]._appUploader) {
            return $this;
        }
        var dfop = {
            placeholder: '上传附件',
            isUpload: true,
            isDown: true,
            extensions: ''
        }

        $.extend(dfop, op || {});
        dfop.id = $this.attr('id');
        dfop.value = app.newGuid();

        $this[0]._appUploader = { dfop: dfop };
        $.appUploader.init($this);
    };

    $.fn.appUploaderSet = function (value) {
        var $self = $(this);
        var dfop = $self[0]._appUploader.dfop;
        dfop.value = value;
        app.HTTP_REQUEST_UTILS.httpAsync('GET',top.$.rootUrl + '/LR_SystemModule/Annexes/GetFileNames?folderId=' + dfop.value, function (res) {
            if (res.code == app.httpCode.success) {
                $('#' + dfop.id).find('.appUploader-input').text(res.info);
            }
        });
    }

    $.fn.appUploaderGet = function () {
        var $this = $(this);
        var dfop = $this[0]._appUploader.dfop;
        return dfop.value;
    }
})(jQuery, top.app);