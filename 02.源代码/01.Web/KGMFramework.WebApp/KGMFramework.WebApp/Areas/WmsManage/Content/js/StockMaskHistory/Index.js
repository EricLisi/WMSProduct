var router = "/WmsManage/StockMaskHistory";//当前页面路由
var bodyData = [];//表体数据

searchSetting = {//查询设置
    setPostData: function () {
        return { keyword: $("#txt_keyword").val(), searchFiled: "F_EnCode/F_GoodsName" };
    },
    doBeforeSubmit: function () {
        alert(222);
        return false;
    }
},
gridSetting = {//列表设置对象
    treegrid: false,//是否树性结构 
    //ExpandColumn: "F_Id",
    searchActionUrl: router + '/GetGridJsonPagination',//查询API
    pager: "#gridPager",//分页控件
    //multiselect: true,//是否多选
    viewrecords: true,//显示记录  
    colModel: [
        { label: "产品编码", name: "GOODSCODE", width: 120, align: 'left' },
        { label: "盘点产品", name: "F_GoodsName", width: 120, align: 'left' },
        { label: "盘点单据", name: "F_EnCode", width: 120, align: 'left' },
        { label: "库存数量", name: "F_Number", width: 80, align: 'left' },
        { label: "盘点数量", name: "F_RealNumber", width: 80, align: 'left' },
        { label: "差异数", name: "F_DiffNumber", width: 80, align: 'left' },
        { label: "产品单位", name: "F_Unit", width: 70, align: 'left' },
        { label: "货位编码", name: "CPOCODE", width: 120, align: 'left' },
        { label: "盘点货位", name: "F_CargoPositionName", width: 120, align: 'left' },
        { label: "仓库编码", name: "WHCODE", width: 120, align: 'left' },
        { label: "盘点仓库", name: "F_WarehouseName", width: 120, align: 'left' },
        { label: "产品批次", name: "F_Batch", width: 120, align: 'left' }
    ]
},
formSetting = {//Form设置对象

    moduleName: "仓库",//模块名 
    Width: "550px",//宽
    Height: "400px",//高
    doBeforeSubmit: function () {

        return false;
    },
    doBeforeSubmit: function () {

        return false;
    }


}


InitPage(router, searchSetting, gridSetting, formSetting);

function ExportExcel1(options) {
    options.searchId = $searchId;
    options.parmlist = [{ Key: "type", Value: "type" }, { Key: "cDepCode", Value: "cDepCode" }]
    console.log(options);
    FileOper.ExportExcel(options)
}
