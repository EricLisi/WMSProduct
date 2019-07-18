var $router = "",                                                //当前页面路由 
    $parentGridId = "gridList",                                           //父窗体的gridid
    $formSetting = {                                           //窗体设置
        keyValue: $.request("keyValue"),   //keyValue
        bShow: $.request("show"),          //是否只显示
        bVerify: $.request("verify"),          //是否只显示
        form: $('#form1'),                 //表单
        formInfoUrl: "/GetFormJson",       //获取窗体信息的Url   
        formSubmitUrl: "/SubmitForm",      //窗体提交Url
        formSubmitMutiUrl: "/SubmitFormMuti",      //窗体多表提交Url
        initFormEvent: undefined,          //自身的窗体初始化事件
        initSuccess: function (data) {         //窗体初始化 
            $formSetting.form.formSerialize(data);
            if ($formSetting.bShow == 1 || $formSetting.bVerify == 1) {
                $formSetting.form.find('.form-control,select,input').attr("disabled", "disabled");
                $formSetting.form.find('div.ckbox label').attr('for', '');
            }
        },
        doAfterInitSuccess: undefined,
        doBeforeSubmit: undefined,
        submitSuccess: function () {    //窗体提交成功事件
            $.currentWindow().$("#" + $parentGridId).resetSelection();
            $.currentWindow().$("#" + $parentGridId).trigger("reloadGrid");
        }
    }

/*
    初始化页面变量
    router:模块路由
    formSetting:窗体设置 
*/
function InitForm(router, formSetting, parentGridId) {
    $router = router;//设置路由 

    if (parentGridId != null || parentGridId != undefined) {
        $parentGridId = parentGridId
    } else {
        $parentGridId = 'gridList'
    }

    $formSetting = $.extend($formSetting, formSetting);
}
//窗体设置
//if ($formSetting != null || $formSetting != undefined) {
//    if (formSetting.keyValue != null || formSetting.keyValue != undefined) {
//        $formSetting.keyValue = formSetting.keyValue
//    } else {
//        $formSetting.keyValue = $.request("keyValue")
//    }
//    if (formSetting.bShow != null || formSetting.bShow != undefined) {
//        $formSetting.bShow = formSetting.bShow
//    } else {
//        $formSetting.bShow = $.request("show")
//    }
//    if (formSetting.form != null || formSetting.form != undefined) {
//        $formSetting.form = formSetting.form
//    } else {
//        $formSetting.form = $('#form1')
//    }
//    if (formSetting.formInfoUrl != null || formSetting.formInfoUrl != undefined) {
//        $formSetting.formInfoUrl = formSetting.formInfoUrl
//    } else {
//        $formSetting.formInfoUrl = "/GetFormJson"
//    }
//    if (formSetting.formSubmitUrl != null || formSetting.formSubmitUrl != undefined) {
//        $formSetting.formSubmitUrl = formSetting.formSubmitUrl
//    } else {
//        $formSetting.formSubmitUrl = "/SubmitForm"
//    }
//    if (formSetting.initFormEvent != null || formSetting.initFormEvent != undefined) {
//        $formSetting.initFormEvent = formSetting.initFormEvent
//    }
//    if (formSetting.initSuccess != null || formSetting.initSuccess != undefined) {
//        $formSetting.initSuccess = formSetting.initSuccess
//    }
//    else {//默认初始化窗体事件
//        $formSetting.initSuccess = function (data) {
//            $formSetting.form.formSerialize(data);
//            if ($formSetting.bShow == 1) {
//                $formSetting.form.find('.form-control,select,input').attr("disabled", "disabled");
//                $formSetting.form.find('div.ckbox label').attr('for', '');
//            }
//        }
//    }
//    if (formSetting.submitSuccess != null || formSetting.submitSuccess != undefined) {
//        $formSetting.submitSuccess = formSetting.submitSuccess
//    } else {
//        $formSetting.submitSuccess = function () {    //窗体提交成功事件
//            $.currentWindow().$("#" + $parentGridId).resetSelection();
//            $.currentWindow().$("#" + $parentGridId).trigger("reloadGrid");
//        }
//    }
//    if (formSetting.doBeforeSubmit != null || formSetting.doBeforeSubmit != undefined) {
//        $formSetting.doBeforeSubmit = formSetting.doBeforeSubmit
//    }
//}
