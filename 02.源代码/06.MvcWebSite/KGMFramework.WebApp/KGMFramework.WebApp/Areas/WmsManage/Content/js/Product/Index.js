var router = "/WmsManage/Product",                            //当前页面路由  
     pageEvents = {
         doBeforeInit: function () {//设置默认值、控件初始化
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
                F_FullName: $("#F_FullName").val(),
                F_ShortCode: $("#F_ShortCode").val(),
                F_ShortName: $("#F_ShortName").val(),
                F_Standard: $("#F_Standard").val(),
                F_Brand: $("#F_Brand").val(),
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
            { label: '产品编码', name: 'F_EnCode', width: 100, align: 'left' },
            { label: '产品名称', name: 'F_FullName', width: 100, align: 'left' },
            { label: '代码', name: 'F_ShortCode', width: 100, align: 'left' },
            { label: '别名', name: 'F_ShortName', width: 100, align: 'left' },
            { label: '规格', name: 'F_Standard', width: 100, align: 'left' },
            { label: '品牌', name: 'F_Brand', width: 100, align: 'left' },
            { label: '单位', name: 'F_Unit', width: 100, align: 'left' },
            { label: '包装规格', name: 'F_Package', width: 100, align: 'left' },
            { label: '颜色', name: 'F_Color', width: 100, align: 'left' },
            {
                label: "批次管理", name: "F_BatchManagement", width: 80, align: "center",
                formatter: function (cellvalue) {
                    return cellvalue == true ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
                }
            },
            {
                label: "序列号管理", name: "F_SnManagement", width: 80, align: "center",
                formatter: function (cellvalue) {
                    return cellvalue == true ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
                }
            },
            {
                label: "效期管理", name: "F_EffectiveManagement", width: 80, align: "center",
                formatter: function (cellvalue) {
                    return cellvalue == true ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
                }
            },
            { label: '长（m）', name: 'F_Length', width: 100, align: 'left' },
            { label: '高（m）', name: 'F_Height', width: 100, align: 'left' },
            { label: '宽（m）', name: 'F_Width', width: 100, align: 'left' },
            { label: '净重（kg）', name: 'F_NetWeight', width: 100, align: 'left' },
            { label: '毛重（kg）', name: 'F_Weight', width: 100, align: 'left' },
            { label: '采购价格', name: 'F_PurchasePrice', width: 100, align: 'left' },
            { label: '销售价格', name: 'F_SalesPrice', width: 100, align: 'left' }, {
                label: '创建时间', name: 'F_CreatorTime', width: 150, align: 'left', formatter: function (cellvalue) {
                    if (cellvalue == "1900-01-01 00:00:00") {
                        return ''
                    }
                    return cellvalue;
                }
            }
         ]//grid的显示列 
     },
    formSetting = {                                             //Form设置对象
        moduleName: "产品",//模块名 
        Width: "790px",//宽
        Height: "520px"//高 
    };


InitPage(router, searchSetting, gridSetting, formSetting, pageEvents);