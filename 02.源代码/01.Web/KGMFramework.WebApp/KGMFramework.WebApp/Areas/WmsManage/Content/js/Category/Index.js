var router = "/WmsManage/Category",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_FullName"};
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid:true,//是否属性结构 
        ExpandColumn: "F_EnCode",
        searchActionUrl: router + '/GetTreeGridJson',//查询API
        colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            //{ label: '父节点', name: 'F_ParentId', width: 100, align: 'left' },
            { label: '类型名称', name: 'F_FullName', width: 150, align: 'left' },
            { label: '类型编码', name: 'F_EnCode', width: 100, align: 'left' },
            {
                label: '创建时间', name: 'F_CreatorTime', width: 80, align: 'left',
                formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
            },
            { label: '备注', name: 'F_Description', width: 300, align: 'left' }
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "产品分类",//模块名 
        Width: "450px",//宽
        Height: "400px"//高
    };


InitPage(router, searchSetting, gridSetting, formSetting);