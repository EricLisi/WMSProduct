var router = "/SystemManage/Organize",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_FullName" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: true,//是否属性结构 
        ExpandColumn: "F_EnCode",
        searchActionUrl: router + '/GetTreeGridJson',//查询API
        colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: '名称', name: 'F_FullName', width: 200, align: 'left' },
            { label: '编码', name: 'F_EnCode', width: 220, align: 'left' },
            {
                label: '分类', name: 'F_CategoryId', width: 80, align: 'left',
                formatter: function (cellvalue) {
                    if (cellvalue == "Group") {
                        return "集团";
                    } else if (cellvalue == "Company") {
                        return "公司";
                    } else if (cellvalue == "Department") {
                        return "部门";
                    } else if (cellvalue == "WorkGroup") {
                        return "小组";
                    }
                }
            },
            {
                label: '创建时间', name: 'F_CreatorTime', width: 150, align: 'left',
                formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
            },
            { label: '备注', name: 'F_Description', width: 400, align: 'left' }
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "机构",//模块名 
        Width: "700px",//宽
        Height: "550px"//高
    };


InitPage(router, searchSetting, gridSetting, formSetting);