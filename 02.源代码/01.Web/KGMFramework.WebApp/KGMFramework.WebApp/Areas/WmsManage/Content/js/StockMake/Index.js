//var keyValue = $.request('keyValue');//选中行
var router = "/WmsManage/StockMake",//当前页面路由 

searchSetting = {//查询设置
    setPostData: function () {
        return { keyword: $("#txt_keyword").val(), searchFiled: "F_EnCode/F_Maker" };
    }
},
gridSetting = {//列表设置对象
    treegrid: false,//是否树性结构 
    searchActionUrl: router + '/GetGridJsonPagination',//查询方法
    pager: "#gridPager",//分页控件
    //multiselect: true,//是否多选
    colModel: [
        { label: "主键", name: "F_Id", hidden: true, key: true },
        { label: '单据号', name: 'F_EnCode', width: 120, align: 'center' },
        { label: '制单人', name: 'F_Operator', width: 100, align: 'center' },
        { label: '单据日期', name: 'F_date', width: 100, align: 'center', formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' } },
        { label: '盘点仓库', name: 'F_WarehouseName', width: 120, align: 'center' },
        { label: '盘点货位', name: 'F_CargoPositionName', width: 120, align: 'center' },
         {
             label: '单据状态', name: 'F_Status1', width: 100, align: 'left', hidden: true,
             formatter: function (cellvalue, options, rowObject) {
                 return rowObject.F_Status
             }
         },
        {
            label: '审核状态', name: 'F_Status', width: 100, align: 'center',
            formatter: function (cellvalue) {
                if (cellvalue == 0) {
                    return '<span style="color:red">待审核</span>';
                }
                else if (cellvalue == 1) {
                    return '<span style="color:orange">已审核</span>';
                }
                else if (cellvalue > 1) {
                    return '<span style="color:green">已完成</span>';
                }
            }
        },
        { label: '审核人', name: 'F_Verify', width: 100, align: 'center' },
        { label: '审核时间', name: 'F_VeriDate', width: 100, align: 'center', formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' } },
        { label: '备注', name: 'F_Description', width: 100, align: 'left' }
    ]
},
formSetting = {//Form设置对象
    formType: 'tab',//当为tab时,显示为tab模式
    dataId: 'pdAdd',
    moduleName: "产品盘点",//模块名 
    //Width: "900px",//宽
    //Height: "550px",//高
    addBtn: null,
    editBtn: null,
    doBeforeEdit: function (key) {//修改之前  
        var rowId = $gridList.jqGrid('getGridParam', 'selrow');
        var rowData = $gridList.jqGrid('getRowData', rowId);
        var msg = "";

        if (rowData.F_Status1 == 1) {
            msg = "单据已经审核,不允许修改"
        } else if (rowData.F_Status1 > 1) {
            msg = "单据已经完成,不允许修改"
        }
        if (msg != "") {
            $.modalMsg(msg, "error");
            return false;
        }
        return true;
    },
    doBeforeDelete: function (key) {//删除之前
        var rowId = $gridList.jqGrid('getGridParam', 'selrow');
        var rowData = $gridList.jqGrid('getRowData', rowId);
        var msg = "";

        if (rowData.F_Status1 == 1) {
            msg = "单据已经审核,不允许删除"
        } else if (rowData.F_Status1 > 1) {
            msg = "单据已经完成,不允许删除"
        }
        if (msg != "") {
            $.modalMsg(msg, "error");
            return false;
        }
        return true;
    },
    doBeforeVerify: function (key) {//删除之前
        var rowId = $gridList.jqGrid('getGridParam', 'selrow');
        var rowData = $gridList.jqGrid('getRowData', rowId);
        var msg = "";

        if (rowData.F_Status1 == 1) {
            msg = "单据已经审核,不允许重复审核"
        } else if (rowData.F_Status1 > 1) {
            msg = "单据已经完成,不允许审核"
        }

        if (msg != "") {
            $.modalMsg(msg, "error");
            return false;
        }
        return true;
    },
}


var Document = function () {
    return {
        bVerify: function (key, title, state) {// 单据3种状态 0 待打印标签 1 已打印标签待审核 2 已审核
            if (!state) {
                state = 0
            }
            var info = false
            $.ajax({
                url: router + "/GetFormJson?keyValue=" + key,
                type: "get",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data) {
                        if (data.F_Status == 1) {
                            $.modalMsg("当前单据已审核,不允许" + title + "!", "error");
                            info = false
                        }
                        if (data.F_Status > 1) {
                            $.modalMsg("当前单据已完成,不允许" + title + "!", "error");
                            info = false
                        }
                        else {
                            info = true
                        }
                    } else {
                        $.modalMsg("未能获取单据信息!", "error");
                        info = false
                    }
                }
            });

            return info;
        }
    }
}


InitPage(router, searchSetting, gridSetting, formSetting);

function btn_Noverify() {
    var selectId = $gridList.jqGrid("getGridParam", "selrow");//选择行的ID
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
        status = $gridList.jqGridRowValue().F_Status1;
    }

    if (status == 0) {
        $.modalMsg("单据未审核，不允许弃审", "error");
        return false;
    } else if (status > 1) {
        $.modalMsg("单据已完成，不允许弃审", "error");
        return false;
    }

    if ($formSetting.formType == "tab") {
        var title = (($formSetting.formPrefix == undefined ? "" : $formSetting.formPrefix) + "弃审" + $formSetting.moduleName) + (code == "" ? code : "[" + code + "]");
        var url = $formSetting.formUrl + "?keyValue=" + keyValue + "&code=" + code + "&verify=2" + ($formSetting.verifyParms == undefined ? "" : $formSetting.verifyParms);
        $.nfinetab.addTab2(url, title, keyValue);
    } else {
        $.modalOpen({
            id: "Veirfy",
            title: ($formSetting.formPrefix == undefined ? "" : $formSetting.formPrefix) + "弃审" + $formSetting.moduleName,
            url: $formSetting.formUrl + "?keyValue=" + keyValue + "&verify=2" + ($formSetting.verifyParms == undefined ? "" : $formSetting.verifyParms),
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