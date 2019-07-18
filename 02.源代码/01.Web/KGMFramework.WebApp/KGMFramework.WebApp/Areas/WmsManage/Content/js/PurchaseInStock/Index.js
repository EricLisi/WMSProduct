var router = "/WmsManage/PurchaseInStock",//当前页面路由 

searchSetting = {//查询设置
    setPostData: function () {
        return { keyword: $("#txt_keyword").val(), searchFiled: "F_EnCode/F_Maker" };
    }
},
gridSetting = {//列表设置对象
    treegrid: false,//是否树性结构 
    searchActionUrl: router + '/GetGridJsonPagination?sortFiled= F_EnCode ',//查询方法
    pager: "#gridPager",//分页控件
    sortname: "F_CreatorTime desc",//排序字段
    //multiselect: true,//是否多选
    colModel: [
        { label: "主键", name: "F_Id", hidden: true, key: true },
        { label: '单据号', name: 'F_EnCode', width: 150, align: 'left' },
        {
            label: '供应商', name: 'F_VendorName', width: 150, align: 'left',
        },
        { label: '联系人', name: 'F_Contacts', width: 100, align: 'left' },
        { label: '联系电话', name: 'F_TelePhone', width: 100, align: 'left' },
        { label: '制单人', name: 'F_Maker', width: 100, align: 'left' },
        { label: '总金额', name: 'F_TotalAmount', width: 100, align: 'left' },
        {
            label: '单据日期', name: 'F_Date', width: 120, align: 'left',
            formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' },
            advsearch: {
                type: "date"
            }
        },
        { label: '审核人', name: 'F_Verify', width: 100, align: 'left' },
        {
            label: '审核日期', name: 'F_VeriDate', width: 120, align: 'left',
            formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' },
            advsearch: {
                type: "date"
            }
        },
        {
            label: '单据状态', name: 'F_Status1', width: 100, align: 'left', hidden: true,
            formatter: function (cellvalue, options, rowObject) {
                return rowObject.F_Status
            }
        },
        {
            label: '单据状态', name: 'F_Status', width: 100, align: 'center',
            formatter: function (cellvalue) {
                if (cellvalue == 0) {
                    return '<span style="color:red">待审核</span>';
                }
                else if (cellvalue == 1) {
                    return '<span style="color:orange">已审核</span>';
                }
                else if (cellvalue > 2) {
                    return '<span style="color:#1abc9c">已完成</span>';
                }
                else {
                    return '<span style="color:red">待审核</span>';
                }
                //if (cellvalue >= 1) {
                //    return "<i class=\"fa fa-toggle-on\"></i>";
                //}
                //else {
                //    return "<i class=\"fa fa-toggle-off\"></i>";
                //}
            }
        },
        //{
        //    label: '完成操作状态', name: 'F_State', width: 100, align: 'center',
        //    formatter: function (cellvalue) {
        //        if (cellvalue >= 1) {
        //            return "<i class=\"fa fa-toggle-on\"></i>";
        //        }
        //        else {
        //            return "<i class=\"fa fa-toggle-off\"></i>";
        //        }
        //    }
        //},
        { label: '备注', name: 'F_Description', width: 200, align: 'left' }]//grid的显示列
},
formSetting = {//Form设置对象
    formType: 'tab',//当为tab时,显示为tab模式
    dataId: 'regAdd',
    moduleName: "入库通知",//模块名 
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
        } else if (rowData.F_Status1 == 5) {
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
        } else if (rowData.F_Status1 == 5) {
            msg = "单据已经完成,不允许删除"
        }
        if (msg != "") {
            $.modalMsg(msg, "error");
            return false;
        }
        return true;
    },
    doBeforeVerify: function (key) {//审核之前
        var rowId = $gridList.jqGrid('getGridParam', 'selrow');
        var rowData = $gridList.jqGrid('getRowData', rowId);
        var msg = "";

        if (rowData.F_Status1 == 1) {
            msg = "单据已经审核,不允许重复审核"
        } else if (rowData.F_Status1 == 5) {
            msg = "单据已经完成,不允许审核"
        } 

        if (msg != "") {
            $.modalMsg(msg, "error");
            return false;
        }
        return true;
    },
}

InitPage(router, searchSetting, gridSetting, formSetting);

function btn_Noverify() {
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
        status = $gridList.jqGridRowValue().F_Status1;
    }

    if (status == 0) {
        $.modalMsg("单据未审核，不允许弃审", "error");
        return false;
    } else if (status >1) {
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

var Document = function () {
    return {
        bVerify: function (key, title, state) {// 单据3种状态 0 待打印标签 1 已打印标签待审核 2 已审核
            if (!state) {
                state = 0
            }
            var info = false
            $.ajax({
                url: "/WmsManage/PurchaseInStock/GetFormJson?keyValue=" + key,
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
        },
        printBarcode: function () {
            var selectId = $("#gridList").jqGrid("getGridParam", "selrow");//选择行的ID
            if (selectId == null || selectId == undefined) {
                $.modalMsg("请选中一行", "error");
                return false;
            }
            //得到选中行
            var data = $("#gridList").jqGridRowValue();


            $.modalOpen({
                id: "Print",
                title: "条码打印",
                url: "/Print/Index?fileName=demo&sourceName=printbarcode&sourceData=" + escape(data.F_EnCode + '|' + selectId),
                width: "700px",
                height: "500px",
                btn: null
            });
        }, inStock: function () {
            selectId = $gridList.jqGrid("getGridParam", "selrow");//选择行的ID
            if (selectId == null || selectId == undefined) {
                $.modalMsg("请选中一行", "error");
                return false;
            }
            if ($formSetting.doBeforeInStock != null && $formSetting.doBeforeInStock != undefined) {
                if (!$formSetting.doBeforeInStock()) {
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
                var title = (($formSetting.formPrefix == undefined ? "" : $formSetting.formPrefix) + "确认操作");
                var url = $formSetting.formUrl + "?keyValue=" + keyValue + "&code=" + code + "&show=1" + ($formSetting.detailParms == undefined ? "" : $formSetting.detailParms);
                $.nfinetab.addTab2(url, title, keyValue);
            }
        }
    }
}