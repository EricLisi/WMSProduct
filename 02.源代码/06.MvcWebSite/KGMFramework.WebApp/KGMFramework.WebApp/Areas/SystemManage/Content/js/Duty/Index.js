var router = "/SystemManage/Duty",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_EnCode/F_FullName" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构 
        pager: "#gridPager",//分页控件
        sortname: "F_EnCode",//排序字段
        viewrecords: true,//显示记录  
        searchActionUrl: router + '/GetGridJsonPagination',//查询API
        colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: '岗位名称', name: 'F_FullName', width: 150, align: 'left' },
            { label: '岗位编号', name: 'F_EnCode', width: 150, align: 'left' },
            {
                label: '归属机构', name: 'F_OrganizeId', width: 150, align: 'left',
                formatter: function (cellvalue, options, rowObject) {
                    return top.clients.organize[cellvalue] == null ? "" : top.clients.organize[cellvalue].fullname;
                }
            },
            {
                label: '创建时间', name: 'F_CreatorTime', width: 80, align: 'left',
                formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
            },
            {
                label: "有效", name: "F_EnabledMark", width: 60, align: "center",
                formatter: function (cellvalue) {
                    return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
                }
            },
            { label: '备注', name: 'F_Description', width: 300, align: 'left' }
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "岗位",//模块名 
        Width: "768px",//宽
        Height: "380px"//高
    };


InitPage(router, searchSetting, gridSetting, formSetting);



