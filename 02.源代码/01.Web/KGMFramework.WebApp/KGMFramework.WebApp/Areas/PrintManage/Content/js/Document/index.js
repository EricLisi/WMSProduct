var xm, bq, bb;//项目，标签，版本
var bl = 0;//0是搜索，1是tree点击查询
var colModel;//jqgrid的列
var router = "/PrintManage/Document",                                             //当前页面路由 
    $pageEvents = {
        doBeforeInit: function () {
            $('#layout').css("height", $(window).height() + "px")
            $('#layout').layout({
                west: {
                    size: 300
                }
            });
            treeView();
            return true;
        }
    },
searchSetting = {                                             //查询设置
    setPostData: function () {
        if (bl == 1) {//判断是Tree查询还是搜索
            bl = 0;
            return { keyword: xm + "|" + bq + "|" + bb + "&0", searchFiled: "F_PROTOCOL_ID|F_LABEL_ID|F_VERSION" };
        }
        return { keyword: $('#txt_keyword').val() + "&0", searchFiled: "F_PROTOCOL_ID|F_LABEL_ID|F_VERSION|F_COUNTRY" };
    }
},
gridSetting = {                                             //列表设置对象
    treegrid: false,//是否树性结构
    pager: "#gridPager",//分页控件
    multiselect: true,//是否多选
    searchActionUrl: router + '/GetGridJsonPagination',//查询API
    colModel:GetGridColumns({ page: "/PrintManage/Document" })
},
formSetting = {                                             //Form设置对象
    moduleName: "",//模块名 
    Width: "800px",//宽
    Height: "570px",//高
    doBeforeEdit: function () {
        var selectedRows = $("#gridList").jqGrid("getGridParam", "selrow");
        if (selectedRows == null || selectedRows == undefined) {
            $.modalMsg("请至少选中一行", "error");
            return;
        }
        var rowData = $("#gridList").jqGrid("getRowData", selectedRows);
        if (rowData.F_EnabledMark == "已审核") {
            var a = jQuery("#gridList").jqGrid('getInd', selectedRows);
            $.modalMsg("第" + a + "行已审核，不允许编辑！", "warning");
            return;
        }
        return true;
    },
    doBeforeDelete: function () {
        return check('已审核', '已经审核不能删除');
    },
    doBeforeDetails: function () {
        var selectedRows = $("#gridList").jqGrid("getGridParam", "selrow");
        if (selectedRows == null || selectedRows == undefined) {
            $.modalMsg("请至少选中一行", "error");
            return false;
        }
        return true;
    },
    delUrl: "/PrintManage/Document/DeleteForm?bLogicDelete=true"
};

InitPage(router, searchSetting, gridSetting, formSetting);

/************************************************
          初始化
**************************************************/
//Column初始化
//function colModel_init() {
//    var arry = GetGridColumns({ page: "/PrintManage/Document" });
//    var entity = {
//        label: '审核状态',
//        name: 'F_EnabledMark',
//        width: 100, align: 'left',
//        formatter: function (cellvalue, options, rowObject) {
//            if (cellvalue) {
//                return '已审核';
//            }
//            return '未审核';
//        }
//    }
//    arry.splice(5, 0, entity);
//    return arry;
//}

//树形
function treeView() {
    $("#itemTree").treeview({
        url: "/PrintManage/Document/GetTreeJson",
        onnodeclick: function (item) {
            bl = 1;
            xm = undefined;
            bq = undefined;
            bb = undefined;
            var info = item.id.split('|');
            for (var i = 0; i < info.length; i++) {
                if (i == 0) {
                    xm = info[i].substring(3)
                }
                else if (i == 1) {
                    bq = info[i].substring(3)
                }
                else if (i == 2) {
                    bb = info[i].substring(3)
                }
            }
            $('#btn_search').trigger("click");
        }
    });
}

/************************************************
                           搜索  
************************************************/
//高级搜索
function btnSearchCondition() {
    $.modalOpen({
        id: "btnSearchCondition",
        title: "高级搜索",
        url: "/PrintManage/Document/Search?gridId=gridList",
        width: "400px",
        height: "310px",
        callBack: function (iframeId) {
            top.frames[iframeId].Search();
        }, btn: ['确定', '关闭']
    });
}
/***************************************************
                        按钮
***************************************************/
//打印
function print() {
    if (check("未审核", "未审核，不能打印！")) {
        var selectedRows = $("#gridList").jqGrid("getGridParam", "selarrrow");
        $.modalOpen({
            id: "Print",
            title: "打印",
            url: "/Print/Index?fileName=demo&sourceName=Source&sourceData=" + selectedRows.toString(),
            width: $.currentWindow().width + "px",
            height: $.currentWindow().height + "px",
            btn: null
        });
    }
}

//审核
function btn_audit() {
    if (check("已审核", "已审核，无需审核！")) {
        $.modalConfirm("注：您确定要审核吗？", function (r) {
            if (r) {
                var selectedRows = $("#gridList").jqGrid("getGridParam", "selarrrow");
                $.ajax({
                    url: "/PrintManage/Document/Audit",
                    data: { F_Id: selectedRows.toString(), state: 1 },
                    type: "post",
                    dataType: "json",
                    success: function (data) {
                        if (data) {
                            $.modalMsg("审核成功！", "success");
                            $.currentWindow().$("#gridList").trigger("reloadGrid");
                        }
                    }
                })
            }
        });
    }
}

//弃审
function btn_qaudit() {
    if (check("未审核", "未审核，不能弃审！")) {
        $.modalConfirm("注：您确定要弃审该项吗？", function (r) {
            if (r) {
                var selectedRows = $("#gridList").jqGrid("getGridParam", "selarrrow");
                $.ajax({
                    url: "/PrintManage/Document/Audit",
                    data: { F_Id: selectedRows.toString(), state: 0 },
                    type: "post",
                    dataType: "json",
                    success: function (data) {
                        if (true) {
                            $.modalMsg("弃审成功！", "success");
                            $.currentWindow().$("#gridList").trigger("reloadGrid");
                        }
                    }
                })
            }
        });
    }
}

//多选
function check(state, msg) {
    var selectedRows = $("#gridList").jqGrid("getGridParam", "selarrrow");
    if (selectedRows == null || selectedRows == undefined || selectedRows == "") {
        $.modalMsg("请至少选中一行", "error");
        return;
    }
    var str = selectedRows.toString();
    var arry = str.split(",");
    for (var i = 0; i < arry.length; i++) {
        var rowData = $("#gridList").jqGrid("getRowData", arry[i]);
        if (rowData.F_EnabledMark == state) {
            var a = $("#gridList").jqGrid('getInd', rowData.F_Id);
            $.modalMsg("第" + a + "行" + msg, "warning");
            return false;
        }
    }
    return true;
}