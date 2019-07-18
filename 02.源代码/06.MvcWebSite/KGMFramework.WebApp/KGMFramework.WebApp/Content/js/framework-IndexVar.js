/*
共通的index的变量
*/

var $router = "",                                                //当前页面路由 
    $Id=guid(),
    $pageEvents = {
        doBeforeInit: undefined,//共通初始化之前执行
        doAfterInit: undefined,//共通初始化之后执行
    },
    $searchSetting = {                                           //查询设置
        btnSearch: "btn_search",//查询按钮的
        setPostData: undefined,//抛送的参数
        searchEvent: undefined,//查询事件
        doBeforeSearch: undefined,//查询前操作的事件
        doAfterSearch: undefined,//查询后操作的事件
    },
    $gridSetting = {                                             //列表设置对象
        id: "gridList",//id
        treegrid: false,//是否属性结构
        bCellEdit: false,//是否单元格编辑
        multiselect: false,//是否多选
        treeGridModel: "adjacency",//类型
        ExpandColumn: "",
        searchActionUrl: "",//查询API
        colModel: undefined,//grid的显示列 
        colModelUrl: undefined,//动态获取ColumnModel的url
        pager: "",//分页控件
        sortname: "",//排序字段
        viewrecords: true//显示记录
    },
    $formSetting = {                                             //Form设置对象
        formType: undefined,//当为tab时,显示为tab模式
        dataId: undefined,
        moduleName: "",//模块名
        formUrl: "",//FormUrl
        delUrl: "",//FormUrl
        formPrefix: undefined,//窗体前缀
        addParms: undefined,//新增url参数
        addBtn: undefined,//新增时显示的按钮
        doBeforeAdd: undefined,//查看新增按钮之前的操作
        editParms: undefined,//编辑url参数
        editBtn: undefined,//编辑时显示的按钮
        doBeforeEdit: undefined,//查看编辑按钮之前的操作
        deteailParms: undefined,//查看明细url参数 
        deteailBtn: undefined,//编辑时显示的按钮
        doBeforeDetails: undefined,//查看明细按钮之前的操作
        verifyParms: undefined,//查看明细url参数 
        verifyBtn: undefined,//编辑时显示的按钮
        doBeforeVerify: undefined,//审核按钮之前的操作
        deleteParms: undefined,//删除的参数
        deleteBtn: undefined,//编辑时显示的按钮
        doBeforeDelete: undefined,//删除按钮之前的操作 
        Width: "700px",//宽
        Height: "460px"//高
    };

/*
    初始化页面变量
    router:模块路由
    searchSetting:查询设置
    gridSetting:列表设置
    formSetting:弹出窗设置
*/
function InitPage(router, searchSetting, gridSetting, formSetting, events) {
    $router = router;//设置路由 
    $pageEvents = $.extend($pageEvents, events);
    $searchSetting = $.extend($searchSetting, searchSetting);

    $gridSetting = $.extend($gridSetting, gridSetting);
    if (!$gridSetting.colModel) {
        if ($gridSetting.colModelUrl) {
            $.ajax({
                url: $gridSetting.colModelUrl,//"/Areas/SystemManage/Content/js/Module/data.js",//json文件位置
                type: "GET",//请求方式为get
                async: false,
                dataType: "script", //返回数据格式为json
                success: function (data) {//请求成功完成后要执行的方法
                    $gridSetting.colModel = eval(data);
                }
            })
        }
        else {
            $gridSetting.colModel = [];
        }
    }

    var _defaultFormSetting = {
        formUrl: router + "/Form",
        delUrl: router + "/DeleteForm"
    }
    $formSetting = $.extend($formSetting, _defaultFormSetting);
    $formSetting = $.extend($formSetting, formSetting);
}

//if (events != null || events != undefined) {
//    if (events.doBeforeInit != null || events.doBeforeInit != undefined) {
//        $pageEvents.doBeforeInit = events.doBeforeInit
//    }
//    if (events.doAfterInit != null || events.doAfterInit != undefined) {
//        $pageEvents.doAfterInit = events.doAfterInit
//    }
//}
//设置查询
//if (searchSetting != null || searchSetting != undefined) {
//    if (searchSetting.btnSearch != null || searchSetting.btnSearch != undefined) {
//        $searchSetting.btnSearch = searchSetting.btnSearch
//    } else {
//        $searchSetting.btnSearch = "btn_search";
//    }
//    if (searchSetting.setPostData != null || searchSetting.setPostData != undefined) {
//        $searchSetting.setPostData = searchSetting.setPostData
//    }
//    if (searchSetting.searchEvent != null || searchSetting.searchEvent != undefined) {
//        $searchSetting.searchEvent = searchSetting.searchEvent
//    }
//    if (searchSetting.doBeforeSearch != null || searchSetting.doBeforeSearch != undefined) {
//        $searchSetting.doBeforeSearch = searchSetting.doBeforeSearch
//    }
//    if (searchSetting.doAfterSearch != null || searchSetting.doAfterSearch != undefined) {
//        $searchSetting.doAfterSearch = searchSetting.doAfterSearch
//    }
//}
//else {
//    $searchSetting.btnSearch = "btn_search";
//}
//设置列表
//if (gridSetting != null || gridSetting != undefined) {
//    if (gridSetting.id != null || gridSetting.id != undefined) {
//        $gridSetting.id = gridSetting.id
//    } else {
//        $gridSetting.id = "gridList";
//    }
//    if (gridSetting.multiselect != null || gridSetting.multiselect != undefined) {
//        $gridSetting.multiselect = gridSetting.multiselect
//    } else {
//        $gridSetting.multiselect = false;
//    }
//    if (gridSetting.bCellEdit != null || gridSetting.bCellEdit != undefined) {
//        $gridSetting.bCellEdit = gridSetting.bCellEdit
//    } else {
//        $gridSetting.bCellEdit = false;
//    }
//    if (gridSetting.treegrid != null || gridSetting.treegrid != undefined) {
//        $gridSetting.treegrid = gridSetting.treegrid
//    }
//    if (gridSetting.treeGridModel != null || gridSetting.treeGridModel != undefined) {
//        $gridSetting.treeGridModel = gridSetting.treeGridModel
//    } else {
//        $gridSetting.treeGridModel = "adjacency";
//    }
//    if (gridSetting.ExpandColumn != null || gridSetting.ExpandColumn != undefined) {
//        $gridSetting.ExpandColumn = gridSetting.ExpandColumn
//    }
//    if (gridSetting.searchActionUrl != null || gridSetting.searchActionUrl != undefined) {
//        $gridSetting.searchActionUrl = gridSetting.searchActionUrl
//    }
//    if (gridSetting.colModel != null || gridSetting.colModel != undefined) {
//        $gridSetting.colModel = gridSetting.colModel
//    }
//    if (gridSetting.pager != null || gridSetting.pager != undefined) {
//        $gridSetting.pager = gridSetting.pager
//    }
//    if (gridSetting.sortname != null || gridSetting.sortname != undefined) {
//        $gridSetting.sortname = gridSetting.sortname
//    }
//    if (gridSetting.viewrecords != null || gridSetting.viewrecords != undefined) {
//        $gridSetting.viewrecords = gridSetting.viewrecords
//    } else {
//        $gridSetting.viewrecords = true;
//    }

//    if (gridSetting.onSelectRow != null || gridSetting.onSelectRow != undefined) {
//        $gridSetting.onSelectRow = gridSetting.onSelectRow;
//    }
//}
////设置弹出窗
//if (formSetting != null || formSetting != undefined) {
//    if (formSetting.moduleName != null || formSetting.moduleName != undefined) {
//        $formSetting.moduleName = formSetting.moduleName;
//    }
//    if (formSetting.formUrl != null || formSetting.formUrl != undefined) {
//        $formSetting.formUrl = formSetting.formUrl;
//    } else {
//        $formSetting.formUrl = $router + "/Form"
//    }
//    if (formSetting.formPrefix != null || formSetting.formPrefix != undefined) {
//        $formSetting.formPrefix = formSetting.formPrefix;
//    }
//    if (formSetting.delUrl != null || formSetting.delUrl != undefined) {
//        $formSetting.delUrl = formSetting.delUrl;
//    } else {
//        $formSetting.delUrl = $router + "/DeleteForm"
//    }
//    if (formSetting.addParms != null || formSetting.addParms != undefined) {
//        $formSetting.addParms = formSetting.addParms;
//    }
//    if (formSetting.addBtn != null || formSetting.addBtn != undefined) {
//        $formSetting.addBtn = formSetting.addBtn;
//    }
//    if (formSetting.editParms != null || formSetting.editParms != undefined) {
//        $formSetting.editParms = formSetting.editParms;
//    }
//    if (formSetting.editBtn != null || formSetting.editBtn != undefined) {
//        $formSetting.editBtn = formSetting.editBtn;
//    }
//    if (formSetting.deteailParms != null || formSetting.deteailParms != undefined) {
//        $formSetting.deteailParms = formSetting.deteailParms;
//    }
//    if (formSetting.deteailBtn != null || formSetting.deteailBtn != undefined) {
//        $formSetting.deteailBtn = formSetting.deteailBtn;
//    }
//    if (formSetting.doBeforeAdd != null || formSetting.doBeforeAdd != undefined) {
//        $formSetting.doBeforeAdd = formSetting.doBeforeAdd;
//    }
//    if (formSetting.doBeforeEdit != null || formSetting.doBeforeEdit != undefined) {
//        $formSetting.doBeforeEdit = formSetting.doBeforeEdit;
//    }
//    if (formSetting.doBeforeDetails != null || formSetting.doBeforeDetails != undefined) {
//        $formSetting.doBeforeDetails = formSetting.doBeforeDetails;
//    }
//    if (formSetting.doBeforeDelete != null || formSetting.doBeforeDelete != undefined) {
//        $formSetting.doBeforeDelete = formSetting.doBeforeDelete;
//    }
//    if (formSetting.Width != null || formSetting.Width != undefined) {
//        $formSetting.Width = formSetting.Width;
//    }
//    if (formSetting.Height != null || formSetting.Height != undefined) {
//        $formSetting.Height = formSetting.Height;
//    }
//}
