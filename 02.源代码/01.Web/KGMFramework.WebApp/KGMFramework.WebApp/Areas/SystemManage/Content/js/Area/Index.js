var router = "/SystemManage/Area",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_FullName" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: true,//是否属性结构 
        ExpandColumn: "F_CreatorTime",
        searchActionUrl: router + '/GetTreeGridJson',//查询API
        colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: '名称', name: 'F_FullName', width: 200, align: 'left' },
            {
                label: '创建时间', name: 'F_CreatorTime', width: 80, align: 'left',
                formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
            },
            {
                label: "有效", name: "F_EnabledMark", width: 60, align: "center",
                formatter: function (cellvalue) {
                    return cellvalue == true ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
                }
            },
            { label: '备注', name: 'F_Description', width: 300, align: 'left' }
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "区域",//模块名 
        Width: "450px",//宽
        Height: "380px"//高
    };


InitPage(router, searchSetting, gridSetting, formSetting);