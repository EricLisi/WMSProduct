var keyValue = $.request('keyValue');
var router = "/SystemManage/RuleDeatil";    //当前页面路由
$parentGridId = 'gridData',
//自己的初始化事件
formSetting = {
    initFormEvent: function initControl() {
        $("#F_FullName").bindSelect({
            url: "/SystemManage/ItemsData/GetSelectJsonByType",
            param: { type: "2020" }
        });
        $("#F_Type").select2({
            minimumResultsForSearch: -1
        });
        $("#F_GenerateRule").select2({
            minimumResultsForSearch: -1
        });

        $("#F_GenerateFormatter").select2({
            minimumResultsForSearch: -1
        });
    }
}
//初始化窗体
InitForm(router, formSetting, undefined, undefined);

//编辑解析标识checkbox是否选中
var flag = true;
function AnalyCheck(checked) {
    if (checked) {
        document.getElementById("F_Table").readOnly = false;
        document.getElementById("F_ValueFiled").readOnly = false;
        document.getElementById("F_DisplayFiled").readOnly = false;
        document.getElementById("F_Condition").readOnly = false;
    }
    else {
        document.getElementById("F_Table").readOnly = 'true';
        document.getElementById("F_ValueFiled").readOnly = 'true';
        document.getElementById("F_DisplayFiled").readOnly = 'true';
        document.getElementById("F_Condition").readOnly = 'true';
    }
}
//自动生成
function GenerateCheck(checked) {
    if (checked) {
        document.getElementById("F_GenerateRule").disabled = false;
        document.getElementById("F_GenerateFormatter").disabled = false;
        document.getElementById("F_GenerateLength").readOnly = false;
    }
    else {
        document.getElementById("F_GenerateRule").disabled = 'true';
        document.getElementById("F_GenerateFormatter").disabled = 'true';
        document.getElementById("F_GenerateLength").readOnly = 'true';
    }
}

