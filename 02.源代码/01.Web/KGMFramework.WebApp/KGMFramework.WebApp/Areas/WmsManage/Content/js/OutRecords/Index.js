var keyValue = $.request('keyValue');//选中行
var type = $.request('type');
var cDepCode = $.request('cDepCode');
var router = "/WmsManage/OutRecords",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_GoodsName/F_WarehouseName" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构 
        pager: "#gridPager",//分页控件
        viewrecords: true,//显示记录  
        searchActionUrl: router + '/GetGridJsonPagination',//查询API
        colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: '出库单据', name: 'F_Batch', width: 100, align: 'left' },
             { label: '产品编号', name: 'F_EnCode', width: 100, align: 'left' },
             { label: '产品名称', name: 'F_GoodsName', width: 100, align: 'left' },
            { label: '出库数量', name: 'F_OutStockNum', width: 100, align: 'left' },
            { label: '出库仓库', name: 'F_WarehouseName', width: 100, align: 'left' },
            { label: '出库仓位', name: 'F_CargoPositionName', width: 100, align: 'left' },
            { label: '出库时间', name: 'F_CreatorTime', width: 80, align: 'left', formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' } },
           { label: '客户', name: 'F_CustomerName', width: 100, align: 'left' },
           { label: '联系人', name: 'F_Contacts', width: 100, align: 'left' },
             { label: '电话', name: 'F_TelePhone', width: 100, align: 'left' },
             { label: '地址', name: 'F_Address', width: 100, align: 'left' },
            { label: '操作人', name: 'F_Operator', width: 100, align: 'left' },
            { label: '出库仓库', name: 'F_WarehouseName', width: 100, align: 'left' },
            { label: '备注', name: 'F_Description', width: 300, align: 'left' }
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "库存",//模块名 
        Width: "650px",//宽
        Height: "630px"//高
    };


InitPage(router, searchSetting, gridSetting, formSetting);

function btn_OutExcel(options) {
    options.searchId = $searchId;
    options.parmlist = [{ Key: "type", Value: type }, { Key: "cDepCode", Value: cDepCode }]
    console.log(options);
    FileOper.ExportExcel(options)
}

