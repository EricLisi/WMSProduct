var router = "/WmsManage/Goods",                            //当前页面路由 
    $pageEvents = {
        doBeforeInit: function () {
            $('#layout').css("height", $(window).height() + "px")
            $('#layout').layout();
            treeView();
            return true;
        }
    },
     searchSetting = {                                           //查询设置
         setPostData: function () {
             return { keyword: $("#txt_keyword").val() + "|" + $("#itemTree").getCurrentNode().id, searchFiled: "F_FullName|F_CategoryID" };
         }
     },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构 
        ExpandColumn: "F_EnCode",

        searchActionUrl: router + '/GetGridJsonEmptyIfNull',//查询API
        colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: '产品名称', name: 'F_FullName', width: 150, align: 'left' },
            { label: '产品编码', name: 'F_EnCode', width: 100, align: 'left' },
            { label: '规格型号', name: 'F_SpecifModel', width: 100, align: 'left' },
            { label: '单位', name: 'F_Unit', width: 100, align: 'left' },
            { label: '销售价格', name: 'F_SellingPrice', width: 100, align: 'left' },
            { label: '采购价格', name: 'F_PurchasePrice', width: 100, align: 'left' },
            { label: '基本税率', name: 'F_BasicRate', width: 100, align: 'left' },
            { label: '长(m)', name: 'F_Long', width: 100, align: 'left' },
            { label: '宽(m)', name: 'F_Wide', width: 100, align: 'left' },
            { label: '高(m)', name: 'F_Height', width: 100, align: 'left' },
            { label: '体积(m³)', name: 'F_Volume', width: 100, align: 'left' },
            { label: '净重(kg)', name: 'F_NetWeight', width: 100, align: 'left' },
            { label: '毛重(kg)', name: 'F_GrossWeight', width: 100, align: 'left' },
            {
                label: '创建时间', name: 'F_CreatorTime', width: 80, align: 'left',
                formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
            },
            {
                label: '是否启用批次', name: 'F_OpenBatch', width: 80, align: 'left',
                formatter: function (cellvalue) {
                    if (cellvalue) {
                        return "<i class=\"fa fa-toggle-on\"></i>";
                    }
                    else {
                        return "<i class=\"fa fa-toggle-off\"></i>";
                    }
                }
            },
            { label: '备注', name: 'F_Description', width: 200, align: 'left' },
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "产品",//模块名 
        Width: "700px",//宽
        Height: "550px",//高
        doBeforeAdd: function () {
            if ($("#itemTree").getCurrentNode() == null || $("#itemTree").getCurrentNode() == undefined) {
                alert("请先选择产品分类");
                return false;
            }
            var itemId = $("#itemTree").getCurrentNode().id;
            var itemName = $("#itemTree").getCurrentNode().text;
            if (!itemId) {
                return false;
            }
            $formSetting.formPrefix = itemName + "》";
            $formSetting.addParms = "?itemId=" + itemId;
            return true;
        },
        doBeforeEdit: function () {
            var itemId = $("#itemTree").getCurrentNode().id;
            var itemName = $("#itemTree").getCurrentNode().text;
            if (!itemId) {
                return false;
            }

            $formSetting.formPrefix = itemName + "》";
            $formSetting.editParms = "&itemId=" + itemId;
            return true;
        },
        doBeforeDelete: function (key) {//删除之前
            if (!bDelete(key, "删除")) {
                return false;
            }
            return true;
        },
    };


InitPage(router, searchSetting, gridSetting, formSetting);

function btn_itemstype() {
    $.modalOpen({
        id: "ItemsType",
        title: "产品分类",
        url: "/WmsManage/Category/Index",
        width: "800px",
        height: "550px",
        btn: null,
    });
}

function treeView() {
    $("#itemTree").treeview({
        url: "/WmsManage/Category/GetTreeJson",
        onnodeclick: function (item) {
            $("#txt_keyword").val('');
            $('#btn_search').trigger("click");
        }
    });
}

function bDelete(key) {
    var info = false;
    $.ajax({
        url: "/WmsManage/Goods/GetFormJson1?keyValue=" + key,
        type: "get",
        dataType: "json",
        async: false,
        success: function (data) {
            console.log(data)
            if (data.length > 0) {
                $.modalMsg("此产品存在库存中，不允许", "error");
                info = false
            }
            else {
                info = true
            }
        }
    });
    return info;
}

/*
    导出Excel
*/
function ExportExcel1(options) {
    console.info(options);
    options.searchId = $searchId;
    options.parmlist = [{ Key: "type", Value: "type" }, { Key: "cDepCode", Value: "cDepCode" }]
    console.log(options);
    FileOper.ExportExcel(options)
}

function btnPrint() {
    //获取打印的行
    var grid = $("#gridList");
    var selectId = grid.jqGrid("getGridParam", "selrow");//选择行的ID
    if (selectId == null || selectId == undefined) {
        $.modalMsg("请选中一行", "error");
        return false;
    }
    var keyValue = grid.jqGridRowValue().F_Id;
    var batchIs = true;
    $.ajax({
        url: "/WmsManage/Goods/GetOpenBatch?keyValue=" + keyValue,
        type: "get",
        dataType: "json",
        success: function (data) {
            batchIs = data;
            console.log(batchIs)

            $.modalOpen({
                id: "PrintForm",
                title: "条码打印",
                url: router + "/PrintForm?keyValue=" + keyValue + '&show=1' + '&batchIsT=' + batchIs,
                width: formSetting.Width,
                height: formSetting.Height,
                callBack: function (iframeId) {
                    //判断是否开启批次管理

                    if (batchIs != false) {
                        var batch = $(top.frames[iframeId].document).find("#form1").find("#F_Batch").val()
                        if (batch == "" || batch == null) {
                            $.modalMsg("批次不能为空", "error");
                            return false;
                        }
                    }

                    $.modalConfirm("注：您确定要打印条码吗？", function (r) {
                        var _form = $(top.frames[iframeId].document).find("#form1")
                        var params = _form.formSerialize();
                        if (r) {
                            $.modalOpen({
                                id: "Print",
                                title: "条码打印",
                                url: "/Print/Index?fileName=pro&sourceName=goods&sourceData=" + (params.F_Qty + '|' + params.F_Batch + '|' + keyValue),
                                width: "800px",
                                height: "500px",
                                btn: null
                            });
                        }
                    })
                },
                success: function () {

                }
            });
        }
    })


}
