var type = $.request('type')

var router = "/WmsManage/PurchaseOutStock",//当前页面路由        
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val() + "|" + getOrderType(type), searchFiled: "F_EnCode/F_Operator|F_OrderType" };
        }
    },
    gridSetting = getGridOptions(),
    formSetting = getFormOptions()

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

InitPage(router, searchSetting, gridSetting, formSetting);

var Document = function () {
    return {
        bVerify: function (key, title, state) {// 单据3种状态 0 待审核 1 已审核
            if (!state) {
                state = 0;
            }
            var info = false;
            $.ajax({
                url: router + "/GetFormJson?keyValue=" + key,
                type: "get",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data) {
                        if (data.F_Status == 1) {
                            $.modalMsg("当前单据已审核,不允许" + title + "!", "error");
                            info = false;
                        }
                        if (data.F_Status >= 2) {
                            $.modalMsg("当前单据已完成,不允许" + title + "!", "error");
                            info = false;
                        }
                        else {
                            info = true;
                        }
                    } else {
                        $.modalMsg("未能获取单据信息!", "error");
                        info = false;
                    }
                }
            });

            return info;
        }
    }
}




/**
            获取列表设置
        */
function getGridOptions() {
    var gridOpts = {                                             //列表设置对象
        treegrid: false,//是否属性结构  
        searchActionUrl: router + '/GetGridJsonPagination?sortFiled= F_EnCode ',//查询API
        pager: "#gridPager",//分页控件 
        sortname: "F_CreatorTime desc",//排序字段
        viewrecords: true,//显示记录  
        multiselect: false,//复选框
        postData: { keyword: getOrderType(type), searchFiled: "F_OrderType" },
        colModel: [
            { label: '出库编号', name: 'F_Id', width: 150, align: 'left', hidden: true, key: true },
            { label: '单据号', name: 'F_EnCode', width: 150, align: 'left' },
            { label: '客户', name: 'F_CustomerName', width: 150, align: 'left' },
            { label: '联系人', name: 'F_Contacts', width: 100, align: 'left' },
            { label: '联系电话', name: 'F_TelePhone', width: 100, align: 'left' },
            { label: '地址', name: 'F_Address', width: 150, align: 'left' },
            { label: '制单人', name: 'F_Operator', width: 100, align: 'left' },
            {
                label: '单据日期', name: 'F_Date', width: 120, align: 'left',
                formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' },
                advsearch: {
                    type: "date"
                }
            },
            { label: '审核人', name: 'F_AuditingUser', width: 100, align: 'left' },
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

                    //if (cellvalue >= 1) {
                    //    return "<i class=\"fa fa-toggle-on\"></i>";
                    //} else {
                    //    return "<i class=\"fa fa-toggle-off\"></i>";
                    //}
                }
            },
        { label: '备注', name: 'F_Description', width: 200, align: 'left' },
        ]//grid的显示列
    }


    return gridOpts;

}

/**
    获取弹出窗体的设置
*/
function getFormOptions() {
    var formOpts = {                                             //Form设置对象
        // moduleName: getOrderType(type),//模块名 
        //Width: "1000px",//宽
        //Height: "610px",//高
        moduleName: "出库通知",//模块名
        addBtn: null,
        editBtn: null,
        dataId: "",
        formType: 'tab',//当为tab时,显示为tab模式 
        //addParms: '?type=' + type,//新增url参数 
        //editParms: '&type=' + type,//编辑url参数 
        //deteailParms: '&type=' + type,//查看明细url参数  
        //verifyParms: '&type=' + type,//查看明细url参数  
        //deleteParms: '&type=' + type,//删除的参数 

        doBeforeEdit: function (key) {//修改之前  
            var rowId = $gridList.jqGrid('getGridParam', 'selrow');
            var rowData = $gridList.jqGrid('getRowData', rowId);
            var msg = "";

            if (rowData.F_Status1 == 1) {
                msg = "单据已经审核,不允许修改"
            } else if (rowData.F_Status1 == 4) {
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
            } else if (rowData.F_Status1 == 4) {
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


    return formOpts;
}
