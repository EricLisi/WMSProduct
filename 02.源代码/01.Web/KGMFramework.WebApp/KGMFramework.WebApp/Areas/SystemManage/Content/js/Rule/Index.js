var router = "/SystemManage/Rule",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_EnCode/F_FullName" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构  
        searchActionUrl: router + '/GetGridJsonPagination',//查询API
        pager: "#gridPager",//分页控件
        sortname: "F_Type asc,F_FullName desc",//排序字段
        viewrecords: true,//显示记录  
        colModel: [
            { label: '主键', name: 'F_Id', hidden: true, key: true },
            { label: '编码', name: 'F_EnCode', width: 80, align: 'center' },
            { label: '名称', name: 'F_FullName', width: 100, align: 'center' },
            {
                label: '类型', name: 'F_Type', width: 100, align: 'center',
                formatter: function (cellvalue, options, rowObject) {
                    if (cellvalue == true) {
                        return '定长分隔';
                    } else {
                        return '符号分隔';
                    }
                }
            },
            { label: '分隔符', name: 'F_Split', width: 80, align: 'center' },
            { label: '描述', name: 'F_Description', width: 100, align: 'left' },
           
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "条码规则",//模块名 
        Width: "745px",//宽
        Height: "480px",//高
        addBtn: null,
        editBtn: null,
    };


InitPage(router, searchSetting, gridSetting, formSetting);
