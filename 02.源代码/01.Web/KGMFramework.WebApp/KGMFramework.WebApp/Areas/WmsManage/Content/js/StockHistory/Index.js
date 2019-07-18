var keyValue = $.request('keyValue');//选中行

var router = "/WmsManage/StockHistory",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_ENCODE/GOODSNAME/WHNAME" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构 
        pager: "#gridPager",//分页控件
        viewrecords: true,//显示记录  
        searchActionUrl: router + '/GetGridJsonPagination',//查询API
        colModel: [
            { label: "主键", name: "F_ID", hidden: true, key: true },
            { label: "单据号", name: "F_ENCODE", width: 150, align: 'left' },
            { label: "批次", name: "F_BATCH", width: 150, align: 'left' },
            {
                label: '供应商', name: 'F_VENDORNAME', width: 150, align: 'left'
            },
            { label: '仓库编码', name: 'WHCODE', width: 100, align: 'left' },
            { label: '仓库名称', name: 'WHNAME', width: 100, align: 'left' },
            { label: '仓位编码', name: 'POSCODE', width: 100, align: 'left' },
            { label: '产品编码', name: 'GOODSCODE', width: 100, align: 'left' },
            { label: '产品名称', name: 'GOODSNAME', width: 100, align: 'left' },
            { label: '操作类型', name: 'F_BLLCATEGORY', width: 100, align: 'left' },
            { label: '数量', name: 'F_OperationNum', width: 100, align: 'right' },
            { label: '单位', name: 'F_UNIT', width: 100, align: 'left' },
            { label: '联系人', name: 'F_Contacts', width: 100, align: 'left' },
            { label: '联系电话', name: 'F_TELEPHONE', width: 100, align: 'left' },
            { label: '地址', name: 'F_ADDRESS', width: 250, align: 'left', hidden: true },
            { label: '制单人', name: 'F_Maker', width: 100, align: 'left' },
            { label: '审核人', name: 'F_VERIFY', width: 100, align: 'left' },
            {
                label: '审核日期', name: 'F_VERIDATE', width: 120, align: 'left',
                formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' },
                advsearch: {
                    type: "date"
                }
            },
            {
                label: '时间', name: 'F_CREATORTIME', width: 80, align: 'left',
                formatter: "date",
                formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
            },
            { label: '备注', name: 'F_DESCRIPTION', width: 300, align: 'left' }
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
