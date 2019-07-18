var router = "/WmsManage/Allocation",//当前页面路由 

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
        { label: '单据号', name: 'F_EnCode', width: 150, align: 'left' },
        { label: '制单人', name: 'F_Maker', width: 100, align: 'left' },
        {
            label: '单据日期', name: 'F_Date', width: 120, align: 'left', formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
        },
        { label: '审核人', name: 'F_Verify', width: 100, align: 'left' },
        {
            label: '审核日期', name: 'F_AccountDate', width: 120, align: 'left',
            formatter: function (cellvalue) {
                if (cellvalue == "1900-01-01 00:00:00") {
                    return "";
                } else {
                    return cellvalue;
                }
            }
        },
        {
            label: '审核状态', name: 'F_Status', width: 100, align: 'center',
            formatter: function (cellvalue) {
                if (cellvalue>=1) {
                    return "<i class=\"fa fa-toggle-on\"></i>";
                }
                else {
                    return "<i class=\"fa fa-toggle-off\"></i>";
                }
            }
        },
        { label: '备注', name: 'F_Description', width: 200, align: 'left' }]//grid的显示列
},
formSetting = {//Form设置对象
    formType: 'tab',//当为tab时,显示为tab模式
    dataId: 'regAdd',
    moduleName: "调拨单",//模块名 
    //Width: "900px",//宽
    //Height: "550px",//高
    addBtn: null,
    editBtn: null,
    doBeforeEdit: function (key) {//修改之前  
        if (!Document().bVerify(key, "编辑")) {
            return false;
        }
        return true;
    },
    doBeforeDelete: function (key) {//删除之前
        if (!Document().bVerify(key, "删除")) {
            return false;
        }
        return true;
    },
    doBeforeVerify: function (key) {//删除之前
        if (!Document().bVerify(key, "审核", 1)) {
            return false;
        }
        return true;
    },
}

InitPage(router, searchSetting, gridSetting, formSetting);


var Document = function () {
    return {
        bVerify: function (key, title, state) {// 单据3种状态 0 待打印标签 1 已打印标签待审核 2 已审核
            if (!state) {
                state = 0
            }
            var info = false
            $.ajax({
                url: router+"/GetFormJson1?keyValue=" + key,
                type: "get",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data) {
                        if (data.F_Status > state) {
                            $.modalMsg("当前单据已审核或打印卡片,不允许" + title + "!", "error");
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
        },inStock: function () {
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