var keyValue = $.request('keyValue');//选中行

var router = "/WmsManage/InReturnHistory",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_EnCode/F_GoodsName/F_WarehouseName" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构 
        pager: "#gridPager",//分页控件
        viewrecords: true,//显示记录  
        searchActionUrl: router + '/GetGridJsonPagination',//查询API
        colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: "单据号", name: "F_EnCode", width: 150, align: 'left' },
            { label: "批次号", name: "F_Batch", width: 150, align: 'left' },
            {
                label: '供应商', name: 'F_VendorName', width: 150, align: 'left',
            },
            { label: '联系人', name: 'F_Contacts', width: 100, align: 'left' },
            { label: '联系电话', name: 'F_TelePhone', width: 100, align: 'left' },
            { label: '退货地址', name: 'F_Address', width: 250, align: 'left' },
            { label: '制单人', name: 'F_Maker', width: 100, align: 'left' },
            { label: '审核人', name: 'F_Verify', width: 100, align: 'left' },
            {
                label: '审核日期', name: 'F_VeriDate', width: 120, align: 'left',
                formatter: function (cellvalue) {
                    if (cellvalue == "1900-01-01 00:00:00") {
                        return "";
                    } else {
                        return cellvalue;
                    }
                }
            },
            { label: '产品名称', name: 'F_GoodsName', width: 100, align: 'left' },
            { label: '入库数量', name: 'F_InStockNum', width: 100, align: 'right' },
            { label: '退货数量', name: 'F_ReturnNum', width: 100, align: 'right' },
            { label: '单位', name: 'F_Unit', width: 100, align: 'left' },
            { label: '仓库名称', name: 'F_WarehouseName', width: 100, align: 'left' },
            { label: '仓位名称', name: 'F_CargoPositionName', width: 100, align: 'left' },
            { label: '规格型号', name: 'F_SpecifModel', width: 100, align: 'left' },
            {
                label: '销售价格', name: 'F_SellingPrice', width: 80, align: 'right',
                formatter: 'currency', formatoptions: { thousandsSeparator: ",", decimalSeparator: ".", prefix: "￥" }
            },
            {
                label: '采购价格', name: 'F_PurchasePrice', width: 80, align: 'right',
                formatter: 'currency', formatoptions: { thousandsSeparator: ",", decimalSeparator: ".", prefix: "￥" }
            },
            {
                label: '退货时间', name: 'F_CreatorTime', width: 80, align: 'left',
                formatter: "date",
                formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
            },
            { label: '备注', name: 'F_Description', width: 300, align: 'left' }
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "库存",//模块名 
        Width: "650px",//宽
        Height: "630px"//高
    };


InitPage(router, searchSetting, gridSetting, formSetting);

function ExportExcel1(options) {
    options.searchId = $searchId;
    options.parmlist = [{ Key: "type", Value: "type" }, { Key: "cDepCode", Value: "cDepCode" }]
    console.log(options);
    FileOper.ExportExcel(options)
}
