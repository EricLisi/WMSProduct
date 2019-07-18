var router = "/WmsManage/InStock";//当前页面路由
var bodyData=[],

searchSetting = {//查询设置
    setPostData: function () {
        return { keyword: $("#txt_keyword").val(), searchFiled: "F_OrderNo/F_VendorName/F_GoodsName" };
    }
},
gridSetting = {//列表设置对象
    treegrid: false,//是否树性结构 
    searchActionUrl: router + '/GetGridJsonPagination',//查询方法
    pager: "#gridPager",//分页控件
    multiselect: true,//是否多选
    viewrecords: true,//显示记录
    colModel: [
        { label: "主键", name: "F_Id", key: true, hidden: true },
        { label: '单据号', name: 'F_OrderNo', width: 150, align: 'left' },
        {
            label: '供应商', name: 'F_VendorName', width: 150, align: 'left',
        },
        {
            label: '供应商', name: 'F_Vendor', width: 120, align: 'left',hidden:true
        },
        { label: "产品编号", name: "F_GoodsId", hidden: true },
        { label: "产品编号", name: "F_FreeTerm1", hidden: true },
        { label: '产品名称', name: 'F_GoodsName', width: 100, align: 'left' },
        { label: '产品编码', name: 'F_EnCode', width: 100, align: 'left', hidden: true, },
        { label: '规格型号', name: 'F_SpecifModel', width: 100, align: 'left', hidden: true, },
        { label: '入库数量', name: 'F_InStockNum', width: 80, align: 'right' },
        { label: '单位', name: 'F_Unit', width: 100, align: 'left' },
        { label: '入库仓库Id', hidden: true, name: 'F_WarehouseId', width: 100, },
        { label: '入库货位Id', hidden: true, name: 'F_CargoPositionId', width: 100 },
        {
            label: '退货仓库', name: 'F_WarehouseName', index: 'F_WarehouseName', width: 150,
        }, //选择仓库
        {
            label: '退货货位', name: 'F_CargoPositionName', index: 'F_CargoPositionName', width: 150,
        },
        {
            label: '选择批次', name: 'F_SerialNum', index: 'F_SerialNum', width: 150
        },
          {
              label: '货位数量', name: 'F_Num', index: 'F_Num', width: 150,
          },
        {
            label: '采购价格', name: 'F_PurchasePrice', width: 100, align: 'left', hidden: true,
        },
        { label: '总金额', name: 'F_AllAmount', width: 100, align: 'left', hidden: true, },
        { label: '备注', name: 'F_Description', width: 200, align: 'left', hidden: true, }]//grid的显示列
},
formSetting = {//Form设置对象
    formType: 'tab',//当为tab时,显示为tab模式
    dataId: 'regAdd',
    moduleName: "入库单",//模块名 
    //Width: "900px",//宽
    //Height: "550px",//高
    addBtn: null,
    editBtn: null,
    doBeforeEdit: function (key) {//修改之前  
        if (!Document().bVerify(key, "编辑")) {
            return false;
        }
        return true;
    },
    doBeforeDelete: function (key) {//删除之前
        if (!Document().bVerify(key, "删除")) {
            return false;
        }
        return true;
    },
    doBeforeVerify: function (key) {//删除之前
        if (!Document().bVerify(key, "审核", 1)) {
            return false;
        }
        return true;
    },
}

InitPage(router, searchSetting, gridSetting, formSetting);

