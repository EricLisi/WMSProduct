var router = "/SystemManage/TerminalListSetting",                            //当前页面路由 
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
            { label: '编号', name: 'F_EnCode', width: 150, align: 'left' },
            { label: '显示值', name: 'F_Display', width: 200, align: 'left' },
            { label: '文本框类型', name: 'F_Type', width: 150, align: 'left' },
            { name: 'F_ParentId', hidden: true },
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "终端列表设置",//模块名 
        Width: "450px",//宽
        Height: "460px",//高
        doBeforeEdit: function () {
            if ($("#gridList").jqGridRowValue().F_ParentId == "0") {
                $.modalMsg("该项不可编辑", "warning");
                return;
            }
            return true;
        },
    };


InitPage(router, searchSetting, gridSetting, formSetting);