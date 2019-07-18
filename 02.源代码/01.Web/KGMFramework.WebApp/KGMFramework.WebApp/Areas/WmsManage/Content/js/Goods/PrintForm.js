var batchIs = $.request('batchIsT');
var router = "/WmsManage/Goods";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function initControl() {
        $("#F_ParentId").bindSelect({
            url: "/WmsManage/Goods/GetTreeSelectJson"
        });
        $("#F_CategoryID").bindSelect({
            url: "/WmsManage/Category/GetTreeSelectJson"
        });
    },
    doAfterInitSuccess: function () {
        if (batchIs!="true") {
            $("#F_Qty").removeAttr('disabled')
        }
        else {
            $("#F_Batch").removeAttr('disabled')
            $("#F_Qty").removeAttr('disabled')
        }
    },
}

//初始化窗体
InitForm(router, formSetting);
