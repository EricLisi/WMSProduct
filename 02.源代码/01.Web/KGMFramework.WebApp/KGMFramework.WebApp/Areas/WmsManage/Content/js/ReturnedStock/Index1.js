var router = "/WmsManage/PurchaseOutStock";//当前页面路由
var bodyData=[],
searchSetting = {//查询设置
    setPostData: function () {
        return { keyword: $("#txt_keyword").val(), searchFiled: "F_EnCode/F_Maker" };
    }
},
gridSetting = {//列表设置对象
    treegrid: false,//是否树性结构 
    searchActionUrl: router + '/GetGridJsonPagination',//查询方法
    pager: "#gridPager",//分页控件
    multiselect: true,//是否多选
    colModel: [
        {
            label: "查看明细", name: "Operating", width: 80,
            formatter: function (cellvalue) {
                return "<span class=\"btn btn-primary edit\"  onclick=\"SeeDetail(this)\"><i class=\"fa fa-eye\"></i></span>";
            }
        },

         { label: '出库编号', name: 'F_Id', width: 150, align: 'left', hidden: true, key: true },
        { label: '单据号', name: 'F_EnCode', width: 150, align: 'left' },
             { label: '客户', name: 'F_CustomerName', width: 150, align: 'left' },
          { label: '联系人', name: 'F_Contacts', width: 100, align: 'left' },
           { label: '联系电话', name: 'F_TelePhone', width: 100, align: 'left' },
          { label: '地址', name: 'F_Address', width: 150, align: 'left' },
        { label: '制单人', name: 'F_Operator', width: 100, align: 'left' },
        {
            label: '单据日期', name: 'F_Date', width: 120, align: 'left', formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
        },
        { label: '审核人', name: 'F_AuditingUser', width: 100, align: 'left' },
        {
            label: '审核日期', name: 'F_VeriDate', width: 120, align: 'left', formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
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
},
formSetting = {//Form设置对象
    formType: 'tab',//当为tab时,显示为tab模式
    dataId: 'regAdd',
    moduleName: "入库单",//模块名 
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

InitPage(router, searchSetting, gridSetting);






function SeeDetail(_this) {
    var id = _this.parentNode.parentNode.id;

    var modalOpts = {
        id: "SeeDetail",
        title: "查看明细",
        url: "/WmsManage/ReturnedStock/OutStockList?keyValue=" + id,
        width: "850px",
        height: "540px"
    }
    modalOpts.title = "查看明细"
    modalOpts.isClosed = true;

    modalOpts.callBack = function (iframeId, index) {

        var _grid = $(top.frames[iframeId].document).find("#gridList");
        var selectId = _grid.jqGrid("getGridParam", "selrow");//选择行的ID

        if (selectId == null || selectId == undefined) {
            $.modalMsg("请选中一行", "error");
            return false;
        }
        var data = _grid.jqGridRowValue();

        $.ajax({
            url: '/WmsManage/ReturnedStock/PostJson',
            dataType: "json",
            type: "post",
            data: {
                list:data
            },

        })
    }
    $.modalOpen(modalOpts);
    
}
