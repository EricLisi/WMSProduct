var router = "/WmsManage/Position",                            //当前页面路由  
    pageEvents = {
        doBeforeInit: function () {//设置默认值、控件初始化
            $("#F_Status").select2({
                minimumResultsForSearch: -1
            });

            $(".dropdown-menu").click(function (e) {
                e.stopPropagation();
            })
            $('.toolbar').authorizeButton()
            return true;
        }
    },
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_EnCode/F_FullName" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: true,//是否属性结构  
        ExpandColumn: "F_EnCode",
        searchActionUrl: router + '/GetTreeGridJson',//查询API
        colModel: [
            { label: '名称', name: 'F_FullName', width: 150, align: 'left' },
            { label: '编号', name: 'F_EnCode', width: 100, align: 'left' },
            { label: '所属仓库', name: 'F_WarehouseName', width: 100, align: 'left' },
            {
                label: '货位属性', name: 'F_Property', width: 100, align: 'left',
                formatter: function (cellvalue) {

                    var rvalue = '正常品区域'
                    switch (cellvalue) {
                        case 0:
                            rvalue = '正常品区域'
                            break;
                        case 1:
                            rvalue = '待定品区域'
                            break;
                        case 2:
                            rvalue = '坏品区域'
                    }
                    return rvalue;
                }
            },
            {
                label: '货位类型', name: 'F_Type', width: 100, align: 'left',
                formatter: function (cellvalue) {

                    var rvalue = '<span class="label label-primary" style="font-size:14px">启用</span>'
                    switch (cellvalue) {
                        case 0:
                            rvalue = '整货区域'
                            break;
                        case 1:
                            rvalue = '散货区域'
                            break;
                    }
                    return rvalue;
                }
            },
            {

                label: '货位状态', name: 'F_EnabledMark', width: 100, align: 'left', formatter: function (cellvalue) {

                    var rvalue = '<span class="label label-primary" style="font-size:14px">启用</span>'
                    switch (cellvalue) {
                        case true:
                            rvalue = '<span class="label label-success" style="font-size:14px">启用</span>'
                            break;
                        case false:
                            rvalue = '<span class="label label-danger" style="font-size:14px">禁用</span>'
                            break;
                    }
                    return rvalue;
                }
            },
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: '备注', name: 'F_Description', width: 150, align: 'left' },
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象

        moduleName: "货位",//模块名 
        Width: "768px",//宽
        Height: "510px",//高
    
    };


InitPage(router, searchSetting, gridSetting, formSetting, pageEvents);
function btn_EnMark(status) {
    var selectId = $('#gridList').jqGrid('getGridParam', 'selrow');//获取选中行
    if (selectId == null) {//判断是否被选中
        $.modalMsg("请选中一行", "error");
        return false;
    }
    var DataMask = $("#gridList").jqGrid('getRowData', selectId).F_EnabledMark;//获取选中行的EnableMark
    if (DataMask.indexOf("启用") > 0 && status == true) {//判断是否已启用
        $.modalMsg("货位已启用", "error");
        return false;
    }
    if (DataMask.indexOf("禁用") > 0 && status == false) {//判断是否已禁用
        $.modalMsg("货位已禁用", "error");
        return false;
    }

    $.ajax({//调用方法更改状态图
        url: router + '/UpEnMark',
        data: {
            status: status,
            Id: selectId
        },
        success: function (data) {
            var result = JSON.parse(data);
            if (!result.bSuccess) {//返回信息
                $.modalMsg(result.message, "error");
                return false;
            }
            jQuery("#gridList").trigger("reloadGrid");

        }
    })
}


function AddsPosition() {

    var modalOpts = {
        id: "saveAssetDetail",
        title: "添加货位",
        url: "/WmsManage/Position/Form1",
        width: "500px",
        height: "400px"
    }
    modalOpts.title = "添加货位";
    modalOpts.isClosed = true;
    modalOpts.callBack = function (iframeId, index) {
        var _form = $(top.frames[iframeId].document).find("#form1");
        var data = _form.formSerialize();
        var rows = $("#gridList").jqGrid('getRowData');
        if (data.F_BenginNum < 0 && data.F_EndNum > 99) {//限制序号在1-99之间
            $.modalMsg("序号在1-99之间", "error");
            return false;
        }


        $.ajax({
            url: router + "/SubmitForm1",
            data: data,
            success: function (data) {
                var result = JSON.parse(data);//返回信息
                if (result.bSuccess) {
                    $.modalMsg(result.message, "success");
                }
                else {
                    $.modalMsg(result.message, "error");

                }
                jQuery("#gridList").trigger("reloadGrid");
            }
        })
    }


    $.modalOpen(modalOpts);

}

function Delete() {
    var selectId = $('#gridList').jqGrid('getGridParam', 'selrow');
    if (selectId == null) {
        $.modalMsg("请选中一行", "error");
        return false;
    }
    var rowData = $("#gridList").jqGrid('getRowData', selectId);
    var str;
    if (rowData.expanded == "true") {
        str = "注：删除时会一同删除附属货位，您确认要删除吗？";
    } else {
        str="注：您确定要删除吗？"
    }
        $.modalConfirm(str, function (r) {
            if (r) {



                $.ajax({
                    url: router + "/DeleteForm?keyValue=" + selectId,
                    keyValue: selectId,
                    success: function (data) {
                        var result = JSON.parse(data);//返回信息
                        if (result.bSuccess) {
                            $.modalMsg(result.message, "success");
                        }
                        else {
                            $.modalMsg(result.message, "error");

                        }
                        jQuery("#gridList").trigger("reloadGrid");
                    }
                })

            } else {
                return false;
            }
        })
  

}