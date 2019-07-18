var router = "/SystemManage/ItemsType",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_ItemCode/F_ItemName" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: true,//是否属性结构   
        ExpandColumn: "F_EnCode",
        searchActionUrl: router + '/GetTreeGridJson',//查询API
        colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: '名称', name: 'F_FullName', width: 200, align: 'left' },
            { label: '编号', name: 'F_EnCode', width: 150, align: 'left' },
            { label: '排序', name: 'F_SortCode', width: 80, align: 'center' },
            {
                label: "有效", name: "F_EnabledMark", width: 60, align: "center",
                formatter: function (cellvalue) {
                    return cellvalue == true ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
                }
            },
            { label: "备注", name: "F_Description", index: "F_Description", width: 200, align: "left" }
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "字典分类",//模块名 
        Width: "450px",//宽
        Height: "380px"//高 
    };


InitPage(router, searchSetting, gridSetting, formSetting);
 