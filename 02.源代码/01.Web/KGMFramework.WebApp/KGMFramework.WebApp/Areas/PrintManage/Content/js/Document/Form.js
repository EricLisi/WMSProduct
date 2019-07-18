var router = "/PrintManage/Document";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        $('#wizard').wizard().on('change', function (e, data) {
            var $next = $("#btn_next");
            if (data.direction == "next") {
                switch (data.step) {
                    case 1:
                        $next.attr('disabled', 'disabled');
                        break;
                    default:
                        break;
                }
            } else {
                $next.removeAttr('disabled');
            }
        });
    }
}

//初始化窗体
InitForm(router, formSetting);