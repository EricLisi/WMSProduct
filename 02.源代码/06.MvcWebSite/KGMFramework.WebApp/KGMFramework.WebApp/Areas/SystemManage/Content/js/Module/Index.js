var router = "/SystemManage/Module",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_FullName" };
        }
    },
gridSetting = {                                             //列表设置对象
    treegrid: true,//是否属性结构 
    ExpandColumn: "F_UrlAddress", 
    searchActionUrl: router + '/GetTreeGridJson',//查询API 
    colModel: [
        { label: "主键", name: "F_Id", hidden: true, key: true },
        { label: '名称', name: 'F_FullName', width: 200, align: 'left' },
        { label: '连接', name: 'F_UrlAddress', width: 260, align: 'left' },
        {
            label: '目标', name: 'F_Target', width: 80, align: 'center',
            formatter: function (cellvalue) {
                if (cellvalue == "expand") {
                    return "无页面";
                } else if (cellvalue == "iframe") {
                    return "框架页";
                } else if (cellvalue == "open") {
                    return "弹出页";
                }
                else if (cellvalue == "blank") {
                    return "新窗口";
                }
            }
        },
        {
            label: "菜单", name: "F_IsMenu", width: 60, align: "center",
            formatter: function (cellvalue) {
                return cellvalue == true ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
            }
        },
        {
            label: "展开", name: "F_IsExpand", width: 60, align: "center",
            formatter: function (cellvalue) {
                return cellvalue == true ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
            }
        },
        {
            label: "公共", name: "F_IsPublic", width: 60, align: "center",
            formatter: function (cellvalue) {
                return cellvalue == true ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
            }
        },
       {
           label: "有效", name: "F_EnabledMark", width: 60, align: "center",
           formatter: function (cellvalue) {
               return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
           }
       },
    { label: '介绍', name: 'F_Description', width: 300, align: 'left' },
    ]
},
formSetting = {                                             //Form设置对象
    moduleName: "菜单",//模块名 
    Width: "768px",//宽
    Height: "460px"//高
};


InitPage(router, searchSetting, gridSetting, formSetting);

function btn_modulebutton() {
    var keyValue = $gridList.jqGridRowValue().F_Id;
    if (!!!keyValue) {
        $.modalMsg("请先选择模块", "error");
        return false;
    }
    $.modalOpen({
        id: "modulebutton",
        title: "系统按钮",
        url: "/SystemManage/ModuleButton/Index?moduleId=" + keyValue,
        width: "950px",
        height: "600px",
        btn: null,
    });
}
