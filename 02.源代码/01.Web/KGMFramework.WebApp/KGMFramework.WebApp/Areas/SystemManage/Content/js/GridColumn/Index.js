var router = "/SystemManage/GridColumn",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_FullName" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: true,//是否属性结构 
        ExpandColumn: "F_EnCode",
        searchActionUrl: router + '/GetTreeGridJson',//查询API
        colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: '名称', name: 'F_FullName', width: 200, align: 'left' },
            { label: '编号', name: 'F_EnCode', width: 150, align: 'left' },
            { label: '父节点', name: 'F_ParentId', hidden: true },
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "列表设置",//模块名 
        Width: "700px",//宽
        Height: "600px",//高
    };


InitPage(router, searchSetting, gridSetting, formSetting);

function btn_copy() {
    var selectedRows = $("#gridList").jqGridRowValue().F_ParentId;
    if (selectedRows != 0) {
        $.modalMsg("请选择父节点，进行复制！", "warning");
        return;
    }
    $.modalOpen({
        id: "copy",
        title: "复制列表设置",
        url: "/SystemManage/GridColumn/Copy?F_Id=" + $("#gridList").jqGridRowValue().F_Id,
        width: "450px",
        height: "380px",
        callBack: function (iframeId) {
            top.frames[iframeId].Copy();
        }, btn: ['确定', '关闭']
    });
}