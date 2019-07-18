var router = "/WmsManage/Warehouse";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function initControl() {
     
    },
    initSuccess: function (data) {         //窗体初始化 
        $formSetting.form.formSerialize(data);
        if ($formSetting.bShow == 1 || $formSetting.bVerify == 1) {
            $formSetting.form.find('.form-control,select,input').attr("disabled", "disabled");
            $formSetting.form.find('div.ckbox label').attr('for', '');
        }
        if (!!$formSetting.keyValue) {
            $("#F_EnCode").attr('disabled', 'disabled');
        }
    },
}
//初始化窗体
InitForm(router, formSetting);