var router = "/WmsManage/ReturnedStock";//当前页面路由
var bodyData = [];//表体数据

searchSetting = {//查询设置
    setPostData: function () {
        return { keyword: $("#txt_keyword").val(), searchFiled: "F_EnCode/F_FullName" };
    }
},
gridSetting = {//列表设置对象
    treegrid: false,//是否树性结构 
    //ExpandColumn: "F_Id",
    searchActionUrl: router + '/GetJsonList',//查询API
    pager: "#gridPager",//分页控件
    multiselect: true,//复选框
    //multiselect: true,//是否多选
    viewrecords: true,//显示记录  
    colModel: [
  { label: "主键", name: "F_Id", key: true, hidden: true, },
  { label: '操作', name: 'F_GoodsName', width: 100, align: 'left' },
            { label: '产品名称', name: 'F_GoodsName', width: 100, align: 'left' },
             { label: '产品编码', name: 'F_EnCode', width: 100, align: 'left' },
             { label: '规格型号', name: 'F_SpecifModel', width: 100, align: 'left' },
            { label: '出库数量', name: 'F_OutStockNum', width: 100, align: 'left', editable: true },
            { label: '单位', name: 'F_Unit', width: 50, align: 'left' },
            { label: '备注', name: 'F_Description', width: 50, align: 'left' },
            { label: '出库仓库', name: 'F_WarehouseName', width: 50, align: 'left' },
            { label: '出库货位', name: 'F_CargoPositionName', width: 50, align: 'left' },
            { label: '选择批次', name: 'F_Batch', width: 50, align: 'left' },

             { label: '货位数量', name: 'F_Num', width: 100, align: 'left' },

         { label: '采购价格', name: 'F_SellingPrice', width: 100, align: 'left' },
        { label: '总金额', name: 'F_TotalAmount', width: 100, align: 'left' },
        { label: '保质期（天）', name: 'F_ShelfLife', width: 100, align: 'left' },
        { label: '产品Id', hidden: true, name: 'F_GoodsId', width: 100, align: 'left' },
         { label: '产品Id', hidden: true, name: 'F_CargoPositionId', width: 100, align: 'left' },
          { label: '产品Id', hidden: true, name: 'F_WarehouseId', width: 100, align: 'left' },
    ]
},
formSetting = {//Form设置对象

    moduleName: "仓库",//模块名 
    Width: "550px",//宽
    Height: "450px",//高


}


InitPage(router, searchSetting, gridSetting, formSetting);