var router = "/SystemManage/ModuleButton";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        $("#F_Location").select2({ minimumResultsForSearch: -1 })
        $("#F_ParentId").bindSelect({
            url: "/SystemManage/ModuleButton/GetTreeSelectJson",
            param: { keyValue: $.request("keyValue") },
        });
    },
    doBeforeSubmit: function (param) {//提交事务前处理 
        if (!!!$.request("moduleId")) {
            $.modalMsg("请先选择模块", "error"); 
            return false;
        }
        param["F_ModuleId"] = $.request("moduleId");
        return true;
    }
}

//初始化窗体
InitForm(router, formSetting);