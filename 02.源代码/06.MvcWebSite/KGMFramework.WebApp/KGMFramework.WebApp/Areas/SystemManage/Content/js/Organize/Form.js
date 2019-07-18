var router = "/SystemManage/Organize";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        $("#F_CategoryId").select2({ minimumResultsForSearch: -1 })
        $("#F_ParentId").bindSelect({
            url: "/SystemManage/Organize/GetTreeSelectJson",
        });
    }
}

//初始化窗体
InitForm(router, formSetting);