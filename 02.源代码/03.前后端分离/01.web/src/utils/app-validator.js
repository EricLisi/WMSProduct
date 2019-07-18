/*
 * 描 述：表单数据验证完整性
 */
(function ($, app) {
    "use strict";
    
    $.appValidformMessage = function ($this, errormsg) {
        /*错误处理*/
        $this.addClass('app-field-error');
        $this.parent().append('<div class="app-field-error-info" title="' + errormsg + '！"><i class="fa fa-info-circle"></i></div>');
        var validatemsg = $this.parent().find('.form-item-title').text() + ' ' + errormsg;
        //app.alert.error('表单信息输入有误,请检查！</br>' + validatemsg);
        //app.MODAL_UTILS.warning('表单信息输入有误,请检查！</br>' + validatemsg);
        if ($this.attr('type') == 'appselect') {
            $this.on('change', function () {
                removeErrorMessage($(this));
            });
        }
        else if ($this.attr('type') == 'formselect') {
            $this.on('change', function () {
                removeErrorMessage($(this));
            });
        }
        else if ($this.hasClass('app-input-wdatepicker')) {
            $this.on('change', function () {
                var $input = $(this);
                if ($input.val()) {
                    removeErrorMessage($input);
                }
            });
        }
        else {
            $this.on('input propertychange', function () {
                var $input = $(this);
                if ($input.val()) {
                    removeErrorMessage($input);
                }
            });
        }
    };

    $.fn.appRemoveValidMessage = function () {
        removeErrorMessage($(this));
    }

    $.fn.appValidform = function () {
        var validateflag = true;
        var validHelper = app.BASE_UTILS.dataValidator;
        var formdata = $(this).appGetFormData();

        $(this).find("[isvalid=yes]").each(function () {        	
            var $this = $(this);

            if ($this.parent().find('.app-field-error-info').length > 0) {
                validateflag = false;
                return true;
            }

            var checkexpession = $(this).attr("checkexpession");
            var checkfn = validHelper['is' + checkexpession];
            if (!checkexpession || !checkfn) { return false; }
            var errormsg = $(this).attr("errormsg") || "";

            var id = $this.attr('id');
            var value = formdata[id];

            //var type = $this.attr('type');
            //if (type == 'appselect') {
            //    value = $this.appselectGet();
            //}
            //else if (type == 'formselect') {
            //    value = $this.appformselectGet();
            //}
            //else {
            //    value = $this.val();
            //}
            var r = { code: true, msg: '' };        
            if (checkexpession == 'LenNum' || checkexpession == 'LenNumOrNull' || checkexpession == 'LenStr' || checkexpession == 'LenStrOrNull') {
                var len = $this.attr("length");
                r = checkfn(value, len);
            } else {
                r = checkfn(value);
            } 
            if (!r.code) {
                validateflag = false;
                $.appValidformMessage($this, errormsg + r.msg);
            }
        }); 
        return validateflag;
    }

    function removeErrorMessage($obj) {
        $obj.removeClass('app-field-error');
        $obj.parent().find('.app-field-error-info').remove();
    }

})(window.jQuery, top.app);