var router = "/WmsManage/Goods";    //当前页面路由
var keyValue = $.request('keyValue');//选中行
//自己的初始化事件
formSetting = {
    initFormEvent: function initControl() {
        $("#F_ParentId").bindSelect({
            url: "/WmsManage/Goods/GetTreeSelectJson"
        });
        $("#F_CategoryID").bindSelect({
            url: "/WmsManage/Category/GetTreeSelectJson"
        });
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
    doBeforeSubmit: function (params) {
        //提交前操作，将itemId 设置为当前ItemId
        params["F_CategoryID"] = $.request("itemId");
        return true;
    }
}

//初始化窗体
InitForm(router, formSetting);
