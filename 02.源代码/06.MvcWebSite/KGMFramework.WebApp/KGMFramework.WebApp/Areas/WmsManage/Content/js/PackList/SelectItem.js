var router = "/WmsManage/PackList",                            //当前页面路由  
     pageEvents = {
         doBeforeInit: function () {//设置默认值、控件初始化
             $("#F_SDate").DefalutMonthFirst();
             $("#F_EDate").DefalutDate();
             $("#F_Status").select2({
                 minimumResultsForSearch: -1
             });
             $("#F_Supplier").bindSelect({
                 url: "/WmsManage/Supplier/GetSelectJson"
             });
             $("#F_Warehouse").bindSelect({
                 url: "/WmsManage/Warehouse/GetSelectJson"
             });
             $(".dropdown-menu").click(function (e) {
                 e.stopPropagation();
             })
             $('.toolbar').authorizeButton()
             return true;
         }
     },
    searchSetting = {                                           //查询设置
        setPostData: function () {
            var paramlist = {
                F_EnCode: $("#F_EnCode").val(),
                F_Supplier: $("#F_Supplier").val(),
                F_Warehouse: $("#F_Warehouse").val(),
                F_Status: $("#F_Status").val(),
                F_SDate: $("#F_SDate").val(),
                F_EDate: $("#F_EDate").val(),
            }

            return { filterStr: JSON.stringify(paramlist) };
        },
        doAfterSearch: function () {
            //关闭当前搜索框
            $("#btndropmenu").trigger('click')
        }
    },
     gridSetting = {                                             //列表设置对象
         treegrid: false,//是否属性结构  
         searchActionUrl: router + '/GetListGridJsonPaginationBySel',//查询API
         colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: '单据号', name: 'F_EnCode', width: 150, align: 'left' },
            { label: '客户', name: 'F_CustomerName', width: 150, align: 'left' },
             { label: '仓库', name: 'F_WarehouseName', width: 150, align: 'left' },
             { label: '客户', name: 'F_CustomerId', width: 150, align: 'left', hidden: true },
             { label: '仓库', name: 'F_WarehouseId', width: 150, align: 'left', hidden: true},
             { label: '制单人', name: 'F_Maker', width: 100, align: 'left' },
            {
                label: '单据时间', name: 'F_Date', width: 150, align: 'left', formatter: function (cellvalue) {
                    if (cellvalue == "1900-01-01 00:00:00") {
                        return ''
                    }
                    return cellvalue;
                }
             }, {
                label: '状态', name: 'F_EnabledMark', width: 100, align: 'left', formatter: function (cellvalue) {
                     var rvalue = '<span class="label label-primary" style="font-size:14px">待审核</span>'
                     switch (cellvalue) {
                         case true:
                             rvalue = '<span class="label label-success" style="font-size:14px">已审核</span>'
                             break;
                         case false:
                             rvalue = '<span class="label label-primary" style="font-size:14px">待审核</span>'
                             break;
                     }
                     return rvalue;
                 }
             },
            { label: '审核人', name: 'F_Verify', width: 100, align: 'left' },
            { label: '审核时间', name: 'F_VeriDate', width: 150, align: 'left' },
            { label: '备注', name: 'F_Description', width: 150, align: 'left' },
         ]//grid的显示列 
     },
    formSetting = {                                             //Form设置对象
        moduleName: "入库单",//模块名 
        formType: 'tab'
        //Width: top.$(window).width() + "px",//宽
        //Height: top.$(window).height() + "px",//高 
    };


InitPage(router, searchSetting, gridSetting, formSetting, pageEvents);