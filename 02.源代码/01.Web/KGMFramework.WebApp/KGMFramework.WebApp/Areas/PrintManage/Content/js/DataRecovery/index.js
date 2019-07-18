var colModel;//jqgrid的列
var router = "/PrintManage/Document",                                             //当前页面路由 
    $pageEvents = {
        doBeforeInit: function () {
            $('#layout').css("height", $(window).height() + "px")
            $('#layout').layout();
            return true;
        }
    },
searchSetting = {                                             //查询设置
    setPostData: function () {
        return { keyword: $('#txt_keyword').val() + '&1', searchFiled: "F_PROTOCOL_ID|F_LABEL_ID|F_VERSION|F_COUNTRY" };
    }
},
gridSetting = {                                             //列表设置对象
    treegrid: false,//是否树性结构
    pager: "#gridPager",//分页控件
    searchActionUrl: router + '/GetGridJsonPagination',//查询API
    colModel: GetGridColumns({ page: "/PrintManage/Document" })
},
formSetting = {                                             //Form设置对象
    moduleName: "",//模块名 
    Width: "800px",//宽
    Height: "570px",//高
};

InitPage(router, searchSetting, gridSetting, formSetting);
/*************************************************************************************
                    按钮
*******************************************************************************************/

//恢复
function DataRecovery() {
    $.modalConfirm("注：您确定要恢复该行数据吗？", function (r) {
        if (r) {
            var selectedRows = $("#gridList").jqGridRowValue();
            $.ajax({
                url: "/PrintManage/Document/DataRecoveryC",
                data: { F_Id: selectedRows.F_Id },
                type: "post",
                dataType: "json",
                success: function (data) {
                    if (data) {
                        $.modalMsg("恢复成功！", "success");
                        $.currentWindow().$("#gridList").trigger("reloadGrid");
                    }
                }
            })
        }
    });
}