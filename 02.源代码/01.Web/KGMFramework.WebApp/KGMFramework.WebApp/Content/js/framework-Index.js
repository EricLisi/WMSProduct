var $gridList = $("#" + $gridSetting.id);//grid对象 
var $btnSearch = $("#" + $searchSetting.btnSearch)//查询按钮对象
var $searchPostData = undefined;//查询发送数据
var $searchId = $gridSetting.id + $router + $Id;

function gridList() {
    $gridList.dataGrid({
        treeGrid: $gridSetting.treegrid,
        treeGridModel: $gridSetting.treeGridModel,
        ExpandColumn: $gridSetting.ExpandColumn,
        url: $gridSetting.searchActionUrl,
        height: $gridSetting.height == null ? $gridSetting.pager == undefined || $gridSetting.pager == "" ? $(window).height() - 96 : $(window).height() - 128 : $gridSetting.height,
        colModel: $gridSetting.colModel,
        pager: $gridSetting.pager,
        sortname: $gridSetting.sortname,
        postData: $gridSetting.postData, //发送数据  
        viewrecords: $gridSetting.viewrecords,
        bCellEdit: $gridSetting.bCellEdit,
        multiselect: $gridSetting.multiselect
    });
}

//新增事件
function btn_add() {
    if ($formSetting.formType == "tab") {
        var title = ($formSetting.formPrefix == undefined ? "" : $formSetting.formPrefix) + "新增" + $formSetting.moduleName;
        var url = $formSetting.formUrl + ($formSetting.addParms == undefined ? "" : $formSetting.addParms);
        $.nfinetab.addTab2(url, title, $formSetting.dataId);
    } else {
        if ($formSetting.doBeforeAdd != null && $formSetting.doBeforeAdd != undefined) {
            if (!$formSetting.doBeforeAdd()) {
                return false;
            }
        }
        $.modalOpen({
            id: "Form",
            title: ($formSetting.formPrefix == undefined ? "" : $formSetting.formPrefix) + "新增" + $formSetting.moduleName,
            url: $formSetting.formUrl + ($formSetting.addParms == undefined ? "" : $formSetting.addParms),
            width: $formSetting.Width,
            height: $formSetting.Height,
            callBack: function (iframeId) {
                top.frames[iframeId].submitForm();
            },
            isClosed: false,
            btn: $formSetting.addBtn
        });
    }
}

//编辑事件
function btn_edit() {
    var selectId = $gridList.jqGrid("getGridParam", "selrow");//选择行的ID
    if (selectId == null || selectId == undefined) {
        $.modalMsg("请选中一行", "error");
        return false;
    }

    var keyValue;
    var rows = $gridList.jqGridRowValue()

    var code = "";
    if (rows.length) {
        keyValue = rows[0].F_Id;
        code = rows[0].F_Id;
    }
    else {
        keyValue = rows.F_Id;
        code = rows.F_EnCode;
    }

    if ($formSetting.doBeforeEdit != null && $formSetting.doBeforeEdit != undefined) {
        if (!$formSetting.doBeforeEdit(keyValue)) {
            return false;
        }
    }


    if ($formSetting.formType == "tab") {
        var title = (($formSetting.formPrefix == undefined ? "" : $formSetting.formPrefix) + "修改" + $formSetting.moduleName) + (code == "" ? code : "[" + code + "]");
        var url = $formSetting.formUrl + "?keyValue=" + keyValue + ($formSetting.editParms == undefined ? "" : $formSetting.editParms);
        $.nfinetab.addTab2(url, title, keyValue);
    } else {
        $.modalOpen({
            id: "Form",
            title: ($formSetting.formPrefix == undefined ? "" : $formSetting.formPrefix) + "修改" + $formSetting.moduleName,
            url: $formSetting.formUrl + "?keyValue=" + keyValue + ($formSetting.editParms == undefined ? "" : $formSetting.editParms),
            width: $formSetting.Width,
            height: $formSetting.Height,
            callBack: function (iframeId) {
                top.frames[iframeId].submitForm();
            },
            btn: $formSetting.editBtn,
            success: function () {
                if ($formSetting.successEdit != null && $formSetting.successEdit != undefined) {
                    $formSetting.successEdit();
                }
            },
        });
    }
}

//删除事件
function btn_delete() {
    selectId = $gridList.jqGrid("getGridParam", "selrow");//选择行的ID
    if (selectId == null || selectId == undefined) {
        $.modalMsg("请选中一行", "error");
        return false;
    }
    var keyValue = "";
    if ($gridSetting.multiselect) {
        keyValue = $gridList.jqGrid("getGridParam", "selarrrow").toString();
    }
    else {
        keyValue = $gridList.jqGridRowValue().F_Id;
    }

    if ($formSetting.doBeforeDelete != null && $formSetting.doBeforeDelete != undefined) {
        if (!$formSetting.doBeforeDelete(keyValue)) {
            return false;
        }
    }

    $.deleteForm({
        url: $formSetting.delUrl,
        param: { keyValue: keyValue },
        success: function () {
            $gridList.resetSelection();
            $gridList.trigger("reloadGrid");
        }
    })
}

//查看事件
function btn_details() {
    selectId = $gridList.jqGrid("getGridParam", "selrow");//选择行的ID
    if (selectId == null || selectId == undefined) {
        $.modalMsg("请选中一行", "error");
        return false;
    }
    if ($formSetting.doBeforeDetails != null && $formSetting.doBeforeDetails != undefined) {
        if (!$formSetting.doBeforeDetails()) {
            return false;
        }
    }

    var keyValue;
    var rows = $gridList.jqGridRowValue()
    var code = "";
    if (rows.length) {
        keyValue = rows[0].F_Id;
        code = rows[0].F_Id;
    }
    else {
        keyValue = rows.F_Id;
        code = rows.F_EnCode;
    }

    if ($formSetting.formType == "tab") {
        var title = (($formSetting.formPrefix == undefined ? "" : $formSetting.formPrefix) + "查看" + $formSetting.moduleName) + (code == "" ? code : "[" + code + "]");
        var url = $formSetting.formUrl + "?keyValue=" + keyValue + "&code=" + code + "&show=1" + ($formSetting.detailParms == undefined ? "" : $formSetting.detailParms);
        $.nfinetab.addTab2(url, title, keyValue);
    } else {
        $.modalOpen({
            id: "Details",
            title: ($formSetting.formPrefix == undefined ? "" : $formSetting.formPrefix) + "查看" + $formSetting.moduleName,
            url: $formSetting.formUrl + "?keyValue=" + keyValue + "&show=1" + ($formSetting.detailParms == undefined ? "" : $formSetting.detailParms),
            width: $formSetting.Width,
            height: $formSetting.Height,
            btn: $formSetting.detailBtn == undefined ? null : $formSetting.detailBtn,
            success: function () {
                if ($formSetting.successDetails != null && $formSetting.successDetails != undefined) {
                    $formSetting.successDetails();
                }

            },
        });
    }
}



//审核事件
function btn_verify() {
    selectId = $gridList.jqGrid("getGridParam", "selrow");//选择行的ID
    if (selectId == null || selectId == undefined) {
        $.modalMsg("请选中一行", "error");
        return false;
    }

    var keyValue;
    var code = "";
    if ($gridSetting.multiselect) {
        keyValue = $gridList.jqGrid("getGridParam", "selrow");
    }
    else {
        keyValue = $gridList.jqGridRowValue().F_Id;
        code = $gridList.jqGridRowValue().F_EnCode;
    }

    if ($formSetting.doBeforeVerify != null && $formSetting.doBeforeVerify != undefined) {
        if (!$formSetting.doBeforeVerify(keyValue)) {
            return false;
        }
    }

    if ($formSetting.formType == "tab") {
        var title = (($formSetting.formPrefix == undefined ? "" : $formSetting.formPrefix) + "审核" + $formSetting.moduleName) + (code == "" ? code : "[" + code + "]");
        var url = $formSetting.formUrl + "?keyValue=" + keyValue + "&code=" + code + "&verify=1" + ($formSetting.verifyParms == undefined ? "" : $formSetting.verifyParms);
        $.nfinetab.addTab2(url, title, keyValue);
    } else {
        $.modalOpen({
            id: "Veirfy",
            title: ($formSetting.formPrefix == undefined ? "" : $formSetting.formPrefix) + "审核" + $formSetting.moduleName,
            url: $formSetting.formUrl + "?keyValue=" + keyValue + "&verify=1" + ($formSetting.verifyParms == undefined ? "" : $formSetting.verifyParms),
            width: $formSetting.Width,
            height: $formSetting.Height,
            btn: $formSetting.detailBtn == undefined ? null : $formSetting.detailBtn,
            success: function () {
                if ($formSetting.successVerify != null && $formSetting.successVerify != undefined) {
                    $formSetting.successVerify();
                }

            },
        });
    }
}

/*
    导出Excel
*/
function ExportExcel(options) {
    options.searchId = $searchId;
    FileOper.ExportExcel(options)
}


//高级查询
function AdvenSearch() {
    $.AdvenSearch({
        router: $router,
        searchId: $searchId
    })
}

/*
    窗体初始化事件
*/
$(function () {
    if ($pageEvents.doBeforeInit != null && $pageEvents.doBeforeInit != undefined) {
        if (!$pageEvents.doBeforeInit()) {
            return false;
        }
    }
    if ($gridList) {
        gridList();
    }
    if ($btnSearch) {
        if ($searchSetting.searchEvent) {
            $btnSearch.click(function () {
                if ($searchSetting.doBeforeSearch) {
                    $searchSetting.doBeforeSearch();
                }
                $searchSetting.searchEvent();
                if ($searchSetting.doAfterSearch) {
                    $searchSetting.doAfterSearch();
                }
            });
        }
        else {
            $btnSearch.click(function () {
                if ($searchSetting.doBeforeSearch) {
                    $searchSetting.doBeforeSearch();
                }
                if ($searchSetting.setPostData != null && $searchSetting.setPostData != undefined) {
                    $searchPostData = $searchSetting.setPostData();
                }

                $searchPostData.list = "";
                sessionStorage.setItem($searchId, JSON.stringify({ type: 0, data: JSON.stringify({ Condition: JSON.stringify($searchPostData) }) }));
                $gridList.jqGrid('setGridParam', {
                    postData: $searchPostData
                }).trigger('reloadGrid');
                if ($searchSetting.doAfterSearch) {
                    $searchSetting.doAfterSearch();
                }
            });
        }

    }
    if ($pageEvents.doAfterInit != null && $pageEvents.doAfterInit != undefined) {
        if (!$pageEvents.doAfterInit()) {
            return false;
        }
    }
})

