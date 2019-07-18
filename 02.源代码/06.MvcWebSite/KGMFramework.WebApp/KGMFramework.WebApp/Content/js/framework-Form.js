$(function () {
    //先执行自身的初始化事件
    if ($formSetting.initFormEvent != null && $formSetting.initFormEvent != undefined) {
        $formSetting.initFormEvent();
    }
    //alert($router + $formSetting.formInfoUrl) 

    //在执行共通的事件
    if (!!$formSetting.keyValue) {
        $.ajax({
            url: $router + $formSetting.formInfoUrl,
            data: { keyValue: $formSetting.keyValue },
            dataType: "json",
            async: false,
            success: function (data) {
                $formSetting.initSuccess(data);
                if ($formSetting.doAfterInitSuccess) {
                    $formSetting.doAfterInitSuccess(data)
                }
            }
        });
    }
}); 

function submitForm() {
    if (!$formSetting.form.formValid()) {
        return false;
    }
    var params = $formSetting.form.formSerialize();
    //alert(JSON.stringify(params));
    if ($formSetting.doBeforeSubmit != null && $formSetting.doBeforeSubmit != undefined) {
        if (!$formSetting.doBeforeSubmit(params)) {
            return false;
        }
    }
    $.submitForm({
        url: $router + $formSetting.formSubmitUrl + "?keyValue=" + $formSetting.keyValue,
        param: params,
        success: function (data) {
            //alert(url);
            if ($formSetting.submitSuccess != null && $formSetting.submitSuccess != undefined) {
                $formSetting.submitSuccess(data);
            }

        }
    })
}

/*
    多表提交
*/
function submitFormMuti(dataOptions) { 
    if (!$formSetting.form.formValid()) {
        return false;
    }

    var params = {};
    //将自有参数添加进parms
    if (dataOptions) {
        for (var i = 0; i < dataOptions.length; i++) {
            params[dataOptions[i]["parmKey"]] = dataOptions[i]["parmValue"];
        }
    }
    if ($formSetting.doBeforeSubmit != null && $formSetting.doBeforeSubmit != undefined) {
        $formSetting.doBeforeSubmit(params);
    }
    $.submitForm({
        url: $router + $formSetting.formSubmitMutiUrl + "?keyValue=" + $formSetting.keyValue,
        param: params,
        success: function () {
            if ($formSetting.submitSuccess != null && $formSetting.submitSuccess != undefined) {
                $formSetting.submitSuccess();
            }
        }
    })
}