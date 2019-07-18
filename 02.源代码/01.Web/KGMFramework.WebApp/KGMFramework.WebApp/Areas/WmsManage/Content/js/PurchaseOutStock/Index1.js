var type = $.request('type')
var router = "/WmsManage/PurchaseOutStock",//当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val() + "|" + getOrderType(type), searchFiled: "F_EnCode/F_Department|F_OrderType" };
        }
    },
    gridSetting = getGridOptions(),
    formSetting = getFormOptions()

InitPage(router, searchSetting, gridSetting, formSetting);

var Document = function () {
    return {
        bVerify: function (key, title, state) {// 单据3种状态 0 待审核 1 已审核
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
                        if (data.F_Status > state) {
                            $.modalMsg("当前单据已审核,不允许" + title + "!", "error");
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



/**
            获取列表设置
        */
function getGridOptions() {

    var gridOpts = {                                             //列表设置对象
        treegrid: false,//是否属性结构  
        searchActionUrl: router + '/GetGridJson',//查询API
        pager: "#gridPager",//分页控件 
        viewrecords: true,//显示记录  
        multiselect: true,//复选框
        postData: {searchFiled: "F_OrderType" },
        colModel: [
         { label: '出库编号', name: 'F_Id', width: 200, align: 'left', hidden: true, key: true },
        { label: '单据号', name: 'F_EnCode', width: 200, align: 'left' },
             { label: '客户', name: 'F_CustomerName', width: 150, align: 'left' },
          { label: '联系人', name: 'F_Contacts', width: 150, align: 'left' },
           { label: '电话', name: 'F_TelePhone', width: 200, align: 'left' },
          { label: '地址', name: 'F_Address', width: 150, align: 'left' },
           {
               label: '批次状态', name: 'F_OutSMark', width: 200, align: 'left',
               formatter: function (cellvalue) {
                   if (cellvalue == "0") { return "产品未出库" }
                   if (cellvalue == "1") { return "产品已出库" }
               }
           },
        { label: '操作人', name: 'F_Operator', width: 100, align: 'left' },
        {
            label: '单据日期', name: 'F_Date', width: 120, align: 'left', formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
        },
        { label: '审核人', name: 'F_AuditingUser', width: 100, align: 'left' },
        {
            label: '审核日期', name: 'F_Date', width: 120, align: 'left', formatter: function (cellvalue) {
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

                if (cellvalue == "True") {
                    return "<i class=\"fa fa-toggle-on\"></i>";
                } else {
                    return "<i class=\"fa fa-toggle-off\"></i>";
                }

            }
        },
        { label: '备注', name: 'F_Description', width: 200, align: 'left' }]//grid的显示列
    }


}

/**
    获取弹出窗体的设置
*/
function getFormOptions() {
    var formOpts = {                                             //Form设置对象
        moduleName: getOrderType(type),//模块名 
        Width: "1000px",//宽
        Height: "610px",//高
        addBtn: null,
        editBtn: null,
        dataId: "",
        formType: 'tab',//当为tab时,显示为tab模式 
        addParms: '?type=' + type,//新增url参数 
        editParms: '&type=' + type,//编辑url参数 
        deteailParms: '&type=' + type,//查看明细url参数  
        verifyParms: '&type=' + type,//查看明细url参数  
        deleteParms: '&type=' + type,//删除的参数 

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
  


    return formOpts;
}
