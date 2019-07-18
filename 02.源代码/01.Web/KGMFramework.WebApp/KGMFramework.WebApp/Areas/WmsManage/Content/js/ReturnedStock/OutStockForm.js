var router = "/WmsManage/Goods",                            //当前页面路由 
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
             return { keyword: $("#txt_keyword").val() + "|" + $("#itemTree").getCurrentNode().id, searchFiled: "F_EnCode|F_FreeTerm1" };
         }
     },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构 
        ExpandColumn: "F_EnCode",
        searchActionUrl: '/WmsManage/PurchaseOutStock/GetGridJsonPagination',//查询API
        multiselect: true,//复选框
        colModel: [
         { label: '出库编号', name: 'F_Id', width: 200, align: 'left', hidden: true, key: true },
        { label: '单据号', name: 'F_EnCode', width: 200, align: 'left' },
        { label: '客户', name: 'F_CustomerName', width: 150, align: 'left' },
         { label: '联系人', name: 'F_Contacts', width: 150, align: 'left' },
          { label: '电话', name: 'F_TelePhone', width: 200, align: 'left' },
          { label: '地址', name: 'F_Address', width: 150, align: 'left' },
        { label: '操作人', name: 'F_Operator', width: 100, align: 'left' },
        {
            label: '单据日期', name: 'F_Date', width: 120, align: 'left', formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
        },
        { label: '审核人', name: 'F_AuditingUser', width: 100, align: 'left' },
        {
            label: '审核日期', name: 'F_Date', width: 120, align: 'left', formatter: function (cellvalue) {
                if (cellvalue == "1900-01-01 00:00:00") {
                    return "";
                } else {
                    return cellvalue;
                }
            }
        },
        {
            label: '审核状态', name: 'F_Status', width: 100, align: 'center',
            formatter: function (cellvalue) {

                if (cellvalue == "True") {
                    return "<i class=\"fa fa-toggle-on\"></i>";
                } else {
                    return "<i class=\"fa fa-toggle-off\"></i>";
                }

            }
        },
        { label: '备注', name: 'F_Description', width: 200, align: 'left' }]
    },//grid的显示列

    formSetting = {                                             //Form设置对象
        moduleName: "产品",//模块名 
        Width: "750px",//宽
        Height: "430px",//高
    };


InitPage(router, searchSetting, gridSetting, formSetting);

function treeView() {
    $("#itemTree").treeview({
        url: "/WmsManage/CusterCategory/GetTreeJson",
        onnodeclick: function (item) {
            $("#txt_keyword").val('');
            $('#btn_search').trigger("click");
        }
    });
}