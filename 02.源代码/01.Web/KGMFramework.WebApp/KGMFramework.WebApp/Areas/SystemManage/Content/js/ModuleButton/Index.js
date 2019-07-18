var router = "/SystemManage/ModuleButton",                            //当前页面路由
    moduleId = $.request("moduleId"),
    pageEvents = {
        doBeforeInit: function () {//设置postdata
            $gridSetting.postData = { keyword: moduleId, searchFiled: "F_ModuleId" }
            return true;
        }
    },
    searchSetting = {                                           //查询设置
        setPostData: function () { 
            return { keyword: $("#txt_keyword").val() + "|" + moduleId, searchFiled: "F_FullName|F_ModuleId" };
        }
    },
     gridSetting = {                                             //列表设置对象
         treegrid: true,//是否属性结构 
         ExpandColumn: "F_Location",
         searchActionUrl: router + '/GetTreeGridJson',//查询API
         colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: '名称', name: 'F_FullName', width: 150, align: 'left' },
            {
                label: '位置', name: 'F_Location', width: 80, align: 'left',
                formatter: function (cellvalue) {
                    if (cellvalue == 1) {
                        return "初始";
                    } else {
                        return "选中";
                    }
                }
            },
            { label: '事件', name: 'F_JsEvent', width: 150, align: 'left' },
            { label: '连接', name: 'F_UrlAddress', width: 270, align: 'left' },
            {
                label: "分开", name: "F_Split", width: 60, align: "center",
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
                label: "有效", name: "F_EnabledMark", width: 60, align: "center", autowidth: false,
                formatter: function (cellvalue) {
                    return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
                }
            }
         ]//grid的显示列 
     },
    formSetting = {                                             //Form设置对象
        moduleName: "按钮",//模块名 
        Width: "700px",//宽
        Height: "530px",//高
        editParms: "&moduleId=" + moduleId,
        addParms: "?moduleId=" + moduleId
    };


InitPage(router, searchSetting, gridSetting, formSetting, pageEvents);