var router = "/WmsManage/PurchaseInStockReturn";//当前页面路由

searchSetting = {//查询设置
    setPostData: function () {
        return { keyword: $("#txt_keyword").val(), searchFiled: "F_EnCode/F_FullName" };
    }
},
gridSetting = {//列表设置对象
    treegrid: false,//是否树性结构 
    searchActionUrl: router + '/GetGridJsonPagination',//查询方法
    multiselect: true,//是否多选
    viewrecords: true,//显示记录  
    colModel: [
        { label: "主键", name: "F_Id", hidden: true, key: true },
        { label: "产品编号", name: "F_GoodsId", hidden: true },
        { label: "产品编号", name: "F_FreeTerm1", hidden: true },
        { label: '单据号', name: 'F_OrderNo', width: 150, align: 'left' },
        { label: '产品名称', name: 'F_GoodsName', width: 150, align: 'left' },
        { label: '产品编码', name: 'F_EnCode', width: 100, align: 'left' },
        { label: '规格型号', name: 'F_SpecifModel', width: 100, align: 'left' },
        { label: '入库数量', name: 'F_InStockNum', width: 100, align: 'right' },
        { label: '退货数量', name: 'F_ReturnNum', width: 100, align: 'right' },
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
            label: '选择批次', name: 'F_SerialNum', index: 'F_CargoPositionName', width: 150
        },
        { label: '数量', name: 'F_Num', index: 'F_Num', width: 100 },
        {
            label: '采购价格', name: 'F_PurchasePrice', width: 100, align: 'left'
        },
        { label: '总金额', name: 'F_AllAmount', width: 100, align: 'left' },
        { label: '保质期(天)', name: 'F_ShelfLife', width: 100, align: 'left' },
    ]
},
formSetting = {//Form设置对象
    formType: 'tab',//当为tab时,显示为tab模式
    dataId: 'regAdd',
    moduleName: "入库单",//模块名 
}

InitPage(router,searchSetting, gridSetting, formSetting);



//获取总金额总数量
function completeMethod() {
    var sum_Fy = $("#gridList").getCol('F_ReturnNum', false, 'sum');
    var sum_qntqFy = $("#gridList").getCol('F_AllAmount', false, 'sum');
    $("#gridList").footerData('set', { "F_EnCode": '合计：', F_ReturnNum: sum_Fy, F_AllAmount: sum_qntqFy });

    $("#totalqty").html(sum_Fy)
    $("#totalmomey").html(sum_qntqFy)
}

