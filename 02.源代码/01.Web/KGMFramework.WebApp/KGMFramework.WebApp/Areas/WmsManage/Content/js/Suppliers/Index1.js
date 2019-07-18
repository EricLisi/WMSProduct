var router = "/WmsManage/Suppliers",                            //当前页面路由 
    $pageEvents = {
        doBeforeInit: function () {
            $('#layout').css("height", $(window).height() + "px")
            $('#layout').layout();
            treeView();
            return true;
        }
    },
     searchSetting = {                                           //查询设置
         setPostData: function () {
             return { keyword: $("#txt_keyword").val() + "|" + $("#itemTree").getCurrentNode().id, searchFiled: "F_FullName|F_CategoryID" };
         }
     },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构 
        ExpandColumn: "F_EnCode",
        searchActionUrl: router + '/GetGridJsonPagination',//查询API
        multiselect: true,//复选框
        colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: '产品名称', name: 'F_FullName', width: 150, align: 'left' },
            { label: '产品编码', name: 'F_EnCode', width: 100, align: 'left' },
            { label: '规格型号', name: 'F_SpecifModel', width: 100, align: 'left' },
            { label: '单位', name: 'F_Unit', width: 100, align: 'left' },
            {
                label: '创建时间', name: 'F_CreatorTime', width: 80, align: 'left',
                formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
            },
            { label: '备注', name: 'F_Description', width: 200, align: 'left' }
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "产品",//模块名 
        Width: "750px",//宽
        Height: "430px",//高
    };


InitPage(router, searchSetting, gridSetting, formSetting);

function treeView() {
    $("#itemTree").treeview({
        url: "/WmsManage/SperCategory/GetTreeJson",
        onnodeclick: function (item) {
            $("#txt_keyword").val('');
            $('#btn_search').trigger("click");
        }
    });
}