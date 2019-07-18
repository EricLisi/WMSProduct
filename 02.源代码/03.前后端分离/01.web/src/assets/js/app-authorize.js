/*
 * 描 述：权限验证模块
 */
(function ($, app) {
    "use strict";

    $.fn.appAuthorizeJfGrid = function (op) {
        var _headData = [];
        $.each(op.headData, function (id, item) {
            if (!!appModuleColumnList[item.name.toLowerCase()]) {
                _headData.push(item);
            }
        });
        op.headData = _headData;
        $(this).appgrid(op);
    }

    $(function () { 
        function btnAuthorize() { 
            var appModuleButtonList = app.APP_GLOBE_STORE.LOGIN_USER_BUTTON;

            if (appModuleButtonList) {      
                var $container = $('[app-authorize="yes"]');
                // $container.find('[id]').each(function () {
                //     var $this = $(this); 
                //     var id = $this.attr('id');  
                //     if (!appModuleButtonList[id]) {
                //         $this.remove();
                //     }
                // });
                // $container.find('.dropdown-menu').each(function () {
                //     var $this = $(this);
                //     if ($this.find('li').length == 0) {
                //         $this.remove();
                //     }
                // });
                $container.css({ 'display': 'inline-block' });
            }
            else {
                setTimeout(btnAuthorize,100);
            }
        }
        btnAuthorize();
    });

})(window.jQuery, top.app);