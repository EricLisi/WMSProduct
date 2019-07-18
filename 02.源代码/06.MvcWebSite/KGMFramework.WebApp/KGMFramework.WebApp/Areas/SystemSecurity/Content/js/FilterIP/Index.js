var router = "/SystemSecurity/FilterIP",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_StartIP/F_EndIP" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构
        searchActionUrl: router + '/GetGridJson',//查询API
        colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            {
                label: '策略类型', name: 'F_Type', width: 80, align: 'left',
                formatter: function (cellvalue, options, rowObject) {
                    if (cellvalue == true) {
                        return '<span class=\"label label-success\">允许访问</span>';
                    } else if (cellvalue == false) {
                        return '<span class=\"label label-default\">拒绝访问</span>';
                    }
                }
            },
            { label: '起始IP', name: 'F_StartIP', width: 200, align: 'left' },
            { label: '结束IP', name: 'F_EndIP', width: 200, align: 'left' },
            { label: '创建人员', name: 'F_CreatorUserId', width: 100, align: 'left' },
            {
                label: '创建时间', name: 'F_CreatorTime', width: 100, align: 'left',
                formatter: "date", formatoptions: { srcformat: 'Y-m-d H:i', newformat: 'Y-m-d H:i' }
            },
            { label: '备注', name: 'F_Description', width: 300, align: 'left' }
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "策略",//模块名 
        Width: "450px",//宽
        Height: "400px"//高
    };


InitPage(router, searchSetting, gridSetting, formSetting);