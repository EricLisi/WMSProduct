var router = "/SystemManage/TerminalListSetting";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        $("#F_ParentId").bindSelect({
            url: "/SystemManage/TerminalListSetting/GetTreeSelectJson",
        });
    }
}

//初始化窗体
InitForm(router, formSetting);