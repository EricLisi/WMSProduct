var router = "/WmsManage/InStockNotice",                            //当前页面路由  
     pageEvents = {
         doBeforeInit: function () {//设置默认值、控件初始化
             $("#F_SDate").DefalutMonthFirst();
             $("#F_EDate").DefalutDate();
             $("#F_Status").select2({
                 minimumResultsForSearch: -1
             });
             $("#F_Supplier").select2({
                 minimumResultsForSearch: -1
             });
             $("#F_Supplier").bindSelect({
                 url: "/WmsManage/Supplier/GetSelectJson"
             });
             $(".dropdown-menu").click(function (e) {
                 e.stopPropagation();
             })
             $('.toolbar').authorizeButton();
             return true;
         }
     },
    searchSetting = {                                           //查询设置
        setPostData: function () {
            var paramlist = {
                F_EnCode: $("#F_EnCode").val(),
                F_Supplier: $("#F_Supplier").val(),
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
         searchActionUrl: router + '/GetListGridJsonPagination',//查询API
         colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            {
                label: '状态', name: 'F_Status', width: 100, align: 'left', formatter: function (cellvalue) {
                    var rvalue = '<span class="label label-primary" style="font-size:14px">待审核</span>'
                    switch (cellvalue) {
                        case 1:
                            rvalue = '<span class="label label-success" style="font-size:14px">已审核</span>'
                            break;
                        case 2:
                            rvalue = '<span class="label label-danger" style="font-size:14px">已关闭</span>'
                            break;
                        case 3:
                            rvalue = '<span class="label label-danger" style="font-size:14px">已弃审</span>'
                            break;
                    }
                    return rvalue;
                }
            },
            { label: '单据号', name: 'F_EnCode', width: 150, align: 'left' },
            { label: '供应商', name: 'F_SupplierName', width: 150, align: 'left' },
            { label: '制单人', name: 'F_Maker', width: 100, align: 'left' },
            {
                label: '单据时间', name: 'F_Date', width: 150, align: 'left', formatter: function (cellvalue) {
                    if (cellvalue == "1900-01-01 00:00:00") {
                        return ''
                    }
                    return cellvalue;
                }
            },
            { label: '审核人', name: 'F_Verifier', width: 100, align: 'left' },
            {
                label: '审核时间', name: 'F_Veridate', width: 150, align: 'left', formatter: function (cellvalue) {
                    if (cellvalue == "1900-01-01 00:00:00") {
                        return ''
                    }
                    return cellvalue;
                }
            },
            { label: '备注', name: 'F_Description', width: 150, align: 'left' },
         ]//grid的显示列 
     },
    formSetting = {                                             //Form设置对象
        moduleName: "入库通知单",//模块名 
        formType: 'tab'
        //Width: top.$(window).width() + "px",//宽
        //Height: top.$(window).height() + "px",//高 
    };


InitPage(router, searchSetting, gridSetting, formSetting, pageEvents);