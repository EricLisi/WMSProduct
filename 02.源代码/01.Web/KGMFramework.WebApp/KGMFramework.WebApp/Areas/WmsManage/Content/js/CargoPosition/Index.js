var router = "/WmsManage/CargoPosition";//当前页面路由
var keyValue = $.request('keyValue');//选中行
var bodyData = [];//表体数据

searchSetting = {//查询设置
    setPostData: function () {
        return { keyword: $("#txt_keyword").val(), searchFiled: "F_EnCode/F_FullName" };
    }
},
gridSetting = {//列表设置对象
    treegrid: false,//是否树性结构 
    sortable: true,
    //  multiselect: true,//是否多选
    sortorder: 'desc',
    pager: "#gridPager",//分页控件
    sortname: 'F_EnCode',
    searchActionUrl: router + '/GetGridJsonPagination',//查询API
    colModel: [
              { label: "货位Id", name: "F_Id", width: 100, align: 'left', hidden: true },
             { label: "货位编号", name: "F_EnCode", width: 100, align: 'left' },
            { label: "货位名称", name: "F_FullName", width: 150, align: 'left' },
            { label: "仓库名称", name: "F_WarehouseName", width: 100, align: 'left' },
            { label: "单位", name: "F_Unit", width: 100, align: 'left' },
             { label: "备注", name: "F_Description", width: 80, align: 'left' },
                        {
                            label: "货位状态", name: "F_EnabledMark", width: 100, align: 'left',
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

    moduleName: "货位",//模块名 
    Width: "400px",//宽addParms
    Height: "350px",//高


}

InitPage(router, searchSetting, gridSetting);


function btn_EnMark(state) {

    var keyValue = $("#gridList").jqGridRowValue().F_Id;
    var selectId = $("#gridList").jqGrid("getGridParam", "selrow");//选择行的ID
    if (selectId == null || selectId == undefined) {
        $.modalMsg("请选中一行", "error");
        return false;
    }
    if (state == false) {

        $.ajax({
            url: router + "/WarStatus?keyValue=" + keyValue,

            datatype: 'json',
            success: function (data) {
                if (data == "False") {
                    $.modalMsg("此仓库货位尚存在产品，请先转移产品", "error");
                    return false;
                }
            }
        })
    }



    var rowData = $("#gridList").jqGrid('getRowData', selectId);//获取选中行的数据
    if (state == true && rowData.F_EnabledMark == "<i class=\"fa fa-toggle-on\"></i>") {
        $.modalMsg("货位已启用", "error");
        return false;
    }
    if (state == false && rowData.F_EnabledMark == "<i class=\"fa fa-toggle-off\"></i>") {
        $.modalMsg("货位已禁用", "error");
        return false;
    }

    var stateName = "禁用";
    if (state) {
        stateName = "启用";
    }

    $.modalConfirm("注：是否" + stateName + "货位？", function (r) {
        if (r) {
            $.submitForm({
                url: router + '/UpMark',
                param: { keyValue: keyValue, State: state },
                success: function (data) {
                    jQuery("#gridList").trigger("reloadGrid");
                    // $.currentWindow().$("#gridList").trigger("reloadGrid");
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
            if (data == "False") {
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



function AddCarGo() {
    var modalOpts = {
        id: "saveAssetDetail",
        title: "添加货位",
        url: "/WmsManage/CargoPosition/Form1",
        width: "500px",
        height: "400px"
    }
    modalOpts.title = "添加货位";
    modalOpts.isClosed = false;
    modalOpts.callBack = function (iframeId, index) {
        var _form = $(top.frames[iframeId].document).find("#form1");
        var data = _form.formSerialize();
        $.ajax({
            url: router + "/SubmitForm1",
            data: data,
            success: function (data) {
                var data = JSON.parse(data)
                if (data.state == "success") {
                    $.modalMsg('添加成功！', "success");
                } else {
                    $.modalMsg(data.message, "error");
                }
                $("#gridList").trigger('reloadGrid');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.loading(false);
                $.modalMsg(errorThrown, "error");
            },
            beforeSend: function () {
                $.loading(true);
            },
            complete: function () {
                $.loading(false);
            }
        })

    }
    $.modalOpen(modalOpts);

}