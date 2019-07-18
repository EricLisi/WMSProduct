var router = "/WmsManage/Product",                            //当前页面路由 
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        //$("#F_ParentId").bindSelect({
        //    url: "/SystemManage/ItemsType/GetTreeSelectJson"
        //});

        $("#F_ProductClassId").bindSelect({
            url: "/SystemManage/ItemsData/GetSelectJsonByType",
            param: { type: "ProductClass" }
        });
    }
}

//初始化窗体
InitForm(router, formSetting);
