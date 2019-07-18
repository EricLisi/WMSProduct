var router = "/WmsManage/Position";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        $("#F_Type").select2({
            minimumResultsForSearch: -1
        });
        $("#F_Property").select2({
            minimumResultsForSearch: -1
        });

        $("#F_Type").select2({
            minimumResultsForSearch: -1
        });
        $("#F_WarehouseId").bindSelect({
            url: "/WmsManage/Warehouse/GetSelectJson"
        });

        $("#F_ParentId").bindSelect({
            url: "/WmsManage/Position/GetTreeSelectJson"
        });
    }
}

//初始化窗体
InitForm(router, formSetting);


 