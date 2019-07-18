var router = "/SystemManage/Duty";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        $("#F_OrganizeId").bindSelect({
            url: "/SystemManage/Organize/GetTreeSelectJson",
        });
    }
}

//初始化窗体
InitForm(router, formSetting);