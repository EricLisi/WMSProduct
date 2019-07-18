var router = "/WmsManage/Warehouse";//当前页面路由
var bodyData = [];//表体数据

searchSetting = {//查询设置
    setPostData: function () {
        return { keyword: $("#txt_keyword").val(), searchFiled: "F_EnCode/F_FullName" };
    },
    doBeforeSubmit: function () {
        alert(222);
        return false;
    }
},
gridSetting = {//列表设置对象
    treegrid: false,//是否树性结构 
    //ExpandColumn: "F_Id",
    searchActionUrl: router + '/GetGridJsonPagination',//查询API
    pager: "#gridPager",//分页控件
    //multiselect: true,//是否多选
    viewrecords: true,//显示记录  
    colModel: [
           { label: "仓库编号", name: "F_Id", hidden: true, key: true },
            { label: "仓库编码", name: "F_EnCode", width: 100, align: 'left' },
            { label: "仓库名称", name: "F_FullName", width: 100, align: 'left' },
            { label: "联系人", name: "F_Contacts", width: 70, align: 'left' },
            { label: "电话", name: "F_TelePhone", width: 120, align: 'left' },
            { label: "地址", name: "F_Address", width: 120, align: 'left' },
          //  { label: "所属区域", name: "F_AreaId", width: 100, align: 'left' },
            { label: "备注", name: "F_Description", width: 100, align: 'left' },
             {
                 label: "仓库状态", name: "F_EnabledMark", width: 100, align: 'left',
                 formatter: function (cellvalue) {
                     if (cellvalue == true) {
                         return "<i class=\"fa fa-toggle-on\"></i>";
                     } else {
                         return "<i class=\"fa fa-toggle-off\"></i>";
                     }
                 }
             },
             {
                 label: "货位状态", name: "F_CarGoMark", width: 100, align: 'left',
                 formatter: function (cellvalue) {
                     if (cellvalue == true) {
                         return "<i class=\"fa fa-toggle-on\"></i>";
                     } else {
                         return "<i class=\"fa fa-toggle-off\"></i>";
                     }
                 }
             },
    ]
},
formSetting = {//Form设置对象

    moduleName: "仓库",//模块名 
    Width: "550px",//宽
    Height: "400px",//高
    doBeforeSubmit: function () {
        alert(222);
        return false;
    },
    doBeforeSubmit: function () {
        alert(222);
        return false;
    }


}
function btn_EnMark(name, state) {
    var keyValue = $("#gridList").jqGridRowValue().F_Id;
    var stateName = "禁用"; var ShowName = "货位";
    var selectId = $("#gridList").jqGrid("getGridParam", "selrow");//选择行的ID
    if (selectId == null || selectId == undefined) {
        $.modalMsg("请选中一行", "error");
        return false;
    }
    if (state == false) {
       
        $.ajax({
            url: router + "/WarStatus?keyValue="+keyValue,
            datatype: 'json',
            success: function (data) {
                if (data == "Fasle") {
                    $.modalMsg("此仓库货位尚存在产品，请先转移产品", "error");
                    return false;
                }
            }
        })
    }



    var rowData = $("#gridList").jqGrid('getRowData', selectId);//获取选中行的数据
    if (name != "F_EnabledMark" && state == true) {
        if (rowData.F_EnabledMark == "<i class=\"fa fa-toggle-off\"></i>") {
            $.modalMsg("请先启用仓库", "error");
            return false;
        }
    }
    if (name == "F_EnabledMark" && state == true && rowData.F_EnabledMark == "<i class=\"fa fa-toggle-on\"></i>") {
        $.modalMsg("仓库已启用", "error");
        return false;
    }
    if (name == "F_EnabledMark" && state == false && rowData.F_EnabledMark == "<i class=\"fa fa-toggle-off\"></i>") {
        $.modalMsg("仓库已禁用", "error");
        return false;
    }

    if (name != "F_EnabledMark" && state == true && rowData.F_CarGoMark == "<i class=\"fa fa-toggle-on\"></i>") {
        $.modalMsg("货位已启用", "error");
        return false;
    }
    if (name != "F_EnabledMark" && state == false && rowData.F_CarGoMark == "<i class=\"fa fa-toggle-off\"></i>") {
        $.modalMsg("货位已禁用", "error");
        return false;
    }


    if (state) {
        stateName = "启用";
    }
    if (name == "F_EnabledMark") {
        ShowName = "仓库";
    }
    $.modalConfirm("注：是否" + stateName + ShowName + "？", function (r) {
        if (r) {
            $.submitForm({
                url: router + '/UpMark',
                param: { keyValue: keyValue, Name: name, State: state },
                success: function (data) {
                    $.currentWindow().$("#gridList").trigger("reloadGrid");
                }
            })
        }
    });
}

//删除事件

function btn_deleteFrom() {
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

    $.ajax({
        url: router + "/WarStatus?keyValue=" + keyValue,
        datatype: 'json',
        success: function (data) {
            if (data == "Fasle") {
                $.modalMsg("此仓库货位尚存在产品，请先转移产品", "error");
                return false;
            }
        }
    })


    $.deleteForm({
        url: $formSetting.delUrl,
        param: { keyValue: keyValue },
        success: function () {
            $gridList.resetSelection();
            $gridList.trigger("reloadGrid");
        }
    })
}

InitPage(router, searchSetting, gridSetting, formSetting);