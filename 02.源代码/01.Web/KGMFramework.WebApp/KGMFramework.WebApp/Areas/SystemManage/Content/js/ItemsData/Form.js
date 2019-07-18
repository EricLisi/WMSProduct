var router = "/SystemManage/ItemsData";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        $("#F_Target").select2({
            minimumResultsForSearch: -1
        });
        $("#F_ParentId").bindSelect({
            url: "/SystemManage/Module/GetTreeSelectJson",
        });
    },
    doBeforeSubmit: function (params) {
        //提交前操作，将itemId 设置为当前ItemId
        params["F_ItemId"] = $.request("itemId");
        return true;
    }
}

//初始化窗体
InitForm(router, formSetting);