var keyValue = $.request('keyValue');//选中行
var verify = $.request('verify');//选中行
var router = "/WmsManage/PurchaseInStock";//当前页面路由
var bodyData = [];//表体数据
var Init = false;
formSetting = {
    initFormEvent: function initControl() { //画面初始化事件 
        $("#F_Date").DefalutDate()
        Grid().getData().init();
        Document().bindVendor().setVisiable();

        $("#F_Vendor").bindSelect({
            url: "/WmsManage/Suppliers/GetSelectJson"
        }).on("select2:select", function () {
            $.ajax({
                url: "/WmsManage/Suppliers/GetFormJson?keyValue=" + $("#F_Vendor").val(),
                type: "get",
                dataType: "json",
                success: function (data) {
                    $("#F_Contacts").val(data.F_Contacts);
                    $("#F_TelePhone").val(data.F_TelePhone);
                }
            });
        });
        $("#F_WarehouseId").bindSelect({
            url: "/WmsManage/Warehouse/GetSelectJson"
        });
        var warId = localStorage.getItem('WarehouseId');
        var isAdmin = localStorage.getItem('IsAdmin');
        if (isAdmin == "false") {
            $("#F_WarehouseId").val([warId]).trigger("change");
            $("#F_WarehouseId").attr("disabled", "disabled");
        }
    },
    initSuccess: function (data) {//窗体初始化 
        $formSetting.form.formSerialize(data);
        if ($formSetting.bShow == 1 || $formSetting.bVerify == 1 || $formSetting.bVerify == 2) {
            $formSetting.form.find('.form-control,select,input').attr("disabled", "disabled");
            $formSetting.form.find('div.ckbox label').attr('for', '');
        }
    },

}
InitForm(router, formSetting);

/**
 *  基础设置
 */
var Document = function () {
    return {
        bindVendor: function () {//绑定供应商

            return Document();
        },
        setVisiable: function () {//设置画面可见
            if (!keyValue) {//新建
                $("#btn_Printbarcode").hide();
                $("#btn_PrintLable").hide();
                $("#btn_verify").hide();
                $("#btn_noverify").hide();
                $("#btn_instock").hide();
                $("#btn_noverify").hide();
            } else if (!!$.request('show')) {//查看
                $("#btn_verify").hide();
                $("#btn_noverify").hide();
                $("#btn_instock").hide();
                $("#btn_save").hide();
                $("#rowTools").hide();
                $("#btn_noverify").hide();
                $("#rowToolsEdit").hide();
                $("#gridList").setGridParam().hideCol("Operating");
            } else if (!!$.request('verify') && verify == 1) {//审核
                $("#btn_save").hide();
                $("#rowTools").hide();
                $("#btn_PrintLable").hide();
                $("#btn_noverify").hide();
                $("#btn_Printbarcode").hide();
                $("#rowToolsEdit").hide();
                $("#btn_instock").hide();
                $("#gridList").setGridParam().hideCol("Operating");
            } else if (!!$.request('verify') && verify == 2) {//反审核
                $("#btn_verify").hide();
                $("#btn_save").hide();
                $("#rowTools").hide();
                $("#btn_PrintLable").hide();
                $("#btn_Printbarcode").hide();
                $("#rowToolsEdit").hide();
                $("#btn_instock").hide();
                $("#gridList").setGridParam().hideCol("Operating");
            } else {
                $("#btn_PrintLable").hide();
                $("#btn_noverify").hide();
                $("#btn_Printbarcode").hide();
                $("#btn_verify").hide();
                $("#btn_noverify").hide();
                $("#btn_instock").hide();
            }
            return Document();
        },
        bVerify: function (key, state) { //单据是否已经审核
            // 单据3种状态 0 待打印标签 1 已打印标签待审核 2 已审核  
            if (key == "") {
                return true;
            }
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
                        if (data.F_Status > state) {//单据已经审核
                            $.modalMsg("当前单据已审核,不允许修改!", "error");
                            info = false
                        }
                        else {
                            info = true
                        }
                    } else {
                        $.modalMsg("未能获取单据信息,请确认当前单据是否已经删除!", "error");
                        info = false
                    }
                }
            });

            return info;
        }
    }
}


/**
 *  工具栏
 */
var Tools = function () {
    var modalOpts = {
        id: "saveAssetDetail",
        title: "修改行",
        url: "/WmsManage/Goods/Index1?keyValue=" + keyValue,
        width: "1000px",
        height: "600px"
    }

    return {
        setBatchEditVisable: function (visiabled) {
            var batchedit = $(".mybatchEdit")
            for (var i = 0; i < batchedit.length; i++) {
                if (visiabled) {
                    $(batchedit[i]).show()
                }
                else {
                    $(batchedit[i]).hide()
                }
            }
        },
        add: function () {//添加行 
            if (!Document().bVerify(keyValue)) {
                return false;
            }

            modalOpts.title = "添加行";
            modalOpts.isClosed = true;
            modalOpts.callBack = function (iframeId, index) {

                var _grid = $(top.frames[iframeId].document).find("#gridList");
                var selectId = _grid.jqGrid("getGridParam", "selrow");//选择行的ID

                if (selectId == null || selectId == undefined) {
                    $.modalMsg("请选中一行", "error");
                    return false;
                }
                var data = _grid.jqGridRowValue();
                //console.log(data)

                for (var i = 0; i < data.length; i++) {
                    if (Grid().exists(data[i].F_EnCode)) {
                        continue;
                    }
                    data[i].F_GoodsId = data[i].F_Id
                    data[i].F_GoodsName = data[i].F_FullName

                    data[i].F_FreeTerm2 = 1;
                    data[i].F_InStockNum = data[i].F_FreeTerm2

                    data[i].F_AllAmount = parseInt(data[i].F_InStockNum) * parseFloat(data[i].F_PurchasePrice)

                    bodyData.push(data[i]);
                }
                //console.log(bodyData)

                Grid().reload();
            }

            $.modalOpen(modalOpts);
        },
        edit: function () {
            if (!Document().bVerify(keyValue)) {
                return false;
            }

            var selectId = $("#gridList").jqGrid("getGridParam", "selrow");//选择行的ID
            if (selectId == null || selectId == undefined) {
                $.modalMsg("请选中一行", "error");
                return false;
            }

            var modalOpts = {
                id: "saveAssetDetail",
                title: "修改行",
                url: "/WmsManage/PurchaseInStock/AssetForm?keyValue=" + keyValue,
                width: "800px",
                height: "480px"
            }


            modalOpts.isClosed = true;
            modalOpts.callBack = function (iframeId, index) {
                var _form = $(top.frames[iframeId].document).find("#form1");
                if (!_form.formValid()) {
                    return false;
                }

                var data = _form.formSerialize()

                for (var i = 0; i < bodyData.length; i++) {
                    if (bodyData[i].F_Id == data.F_Id) {
                        //更新
                        $.each(data, function (k, v) {
                            if (k != '__RequestVerificationToken') {
                                bodyData[i][k] = data[k]
                            }
                        })
                        //console.log(data)
                        break;
                    }
                }
                Grid().reload();
            }

            modalOpts.success = function (layero, index, layer) {
                var body = layer.getChildFrame('body', index);//建立父子联系 
                var _form = body.find("#form1");
                var data = $("#gridList").jqGridRowValue();//取当前选中的数据 

                if (data.length) {
                    _form.formSerialize(data[0]);//赋值 
                    body.find("#select2-F_WarehouseId-container").html(data[0]["F_WarehouseName"]).attr('title', data[0]["F_WarehouseName"])
                    body.find("#select2-F_GoodsId-container").html(data[0]["F_GoodsName"]).attr('title', data[0]["F_GoodsName"])
                    body.find("#select2-F_CargoPositionId-container").html(data[0]["F_CargoPositionName"]).attr('title', data[0]["F_CargoPositionName"])
                } else {
                    _form.formSerialize(data);//赋值
                    body.find("#select2-F_WarehouseId-container").html(data["F_WarehouseName"]).attr('title', data["F_WarehouseName"])
                    body.find("#select2-F_GoodsId-container").html(data["F_GoodsName"]).attr('title', data["F_GoodsName"])
                    body.find("#select2-F_CargoPositionId-container").html(data["F_CargoPositionName"]).attr('title', data["F_CargoPositionName"])
                }
            }

            $.modalOpen(modalOpts);
        },
        del: function () {
            if (!Document().bVerify(keyValue)) {
                return false;
            }

            var _grid = $("#gridList");
            var selectId = _grid.jqGrid("getGridParam", "selarrrow");//选择行的ID
            if (selectId == null || selectId == undefined) {
                $.modalMsg("请选中一行", "error");
                return false;
            }

            var rows = $("#gridList").jqGridRowValue();

            var ids = ''
            for (var i = 0; i < rows.length; i++) {
                for (var j = 0; j < bodyData.length; j++) {
                    if (bodyData[j].F_Id == rows[i].F_Id) {
                        bodyData.splice(j, 1)
                    }
                }
            }

            Grid().reload();

        },
        save: function () {//保存单据  
            if (!Document().bVerify(keyValue)) {
                return false;
            }
            Tools().EndBathEdit();
            var _form = $("#form1");
            if (!_form.formValid()) {
                return false;
            }
            if (bodyData.length == 0) {
                $.modalMsg("请至少输入一条记录!", "error");
                return false;
            }

            //for (var i = 0; i < bodyData.length; i++) {

            //    if (bodyData[i].F_WarehouseName == "请选择仓库" || bodyData[i].F_WarehouseName == "" || bodyData[i].F_WarehouseName == undefined) {

            //        $.modalMsg(bodyData[i].F_GoodsName + "，请选择仓库", "error");
            //        return false;
            //    }
            //    if (bodyData[i].F_CargoPositionName == "请选择货位" || bodyData[i].F_CargoPositionName == "该仓库下暂无货位" || bodyData[i].F_CargoPositionName == "" || bodyData[i].F_WarehouseName == undefined) {

            //        $.modalMsg(bodyData[i].F_GoodsName + "，请选择货位", "error");
            //        return false;
            //    }

            //    if (bodyData[i].F_SerialNum == "" || bodyData[i].F_WarehouseName == undefined) {

            //        $.modalMsg(bodyData[i].F_GoodsName + "，请输入批次", "error");
            //        return false;
            //    }
            //}

            for (var i = 0; i < bodyData.length; i++) {
                if (bodyData[i].F_InStockNum <= 0) {
                    $.modalMsg(bodyData[i].F_GoodsName + "，入库数量不可以小于零", "error");
                    return false;
                }
            }

            for (var i = 0; i < bodyData.length; i++) {
                $.modalConfirm("注：您确定要保存单据吗？", function (r) {
                    if (r) {
                        var data = _form.formSerialize();

                        data.dInfo = bodyData
                        data.F_VendorName = $("#F_Vendor").find("option:selected").text();
                        data.F_WarehouseName = $("#F_WarehouseId").find("option:selected").text();
                        data.F_TotalAmount = $("#gridList").getCol('F_AllAmount', false, 'sum');
                        $.submitForm({
                            url: router + "/SubmitFormMuti",
                            param: data,
                            success: function (result) {
                                if (result.state == 'success') {
                                    $("#btn_createCode").show();
                                    keyValue = result.data.F_Id
                                    $("#F_EnCode").val(result.data.F_EnCode)

                                    $.modalMsg("保存成功", "success");
                                    //$("#btn_Printbarcode").show();
                                } else {
                                    $.modalMsg(result.message, "error");
                                }
                            }
                        })
                    }
                })

            }

        },
        verify: function () {//审核单据  
            if (!Document().bVerify(keyValue, 1)) {
                return false;
            }

            var _form = $("#form1");
            if (!_form.formValid()) {
                return false;
            }
            if (bodyData.length == 0) {
                $.modalMsg("请至少输入一条记录!", "error");
                return false;
            }
            $.modalConfirm("注：您确定要审核单据吗？", function (r) {
                if (r) {
                    var data = _form.formSerialize();
                    data.orderId = keyValue
                    data.orderNo = $("#F_EnCode").val()
                    data.dInfo = bodyData
                    data.F_WarehouseName = $("#F_WarehouseId").find("option:selected").text();

                    $.submitForm({
                        url: router + "/VerifyList1",
                        param: data,
                        success: function (result) {
                            if (result.state == 'success') {
                                if (result.message == '单据已被审核') {
                                    $.modalMsg(result.message, "error");
                                } else {
                                    $.modalMsg(result.message, "success");
                                }

                            } else {
                                $.modalMsg(result.message, "error");
                            }
                        }
                    })
                }
            })
        },
        noverify: function () {//审核单据  
            if (!Document().bVerify(keyValue, 1)) {
                return false;
            }
            var _form = $("#form1");
            if (!_form.formValid()) {
                return false;
            }
            $.modalConfirm("注：您确定要弃审单据吗？", function (r) {
                if (r) {
                    var data = _form.formSerialize();
                    data.orderId = keyValue

                    $.submitForm({
                        url: router + "/NoVerifyList",
                        param: data,
                        success: function (result) {
                            if (result.state == 'success') {
                                if (result.message != '弃审成功') {
                                    $.modalMsg(result.message, "error");
                                } else {
                                    $.modalMsg(result.message, "success");
                                }

                            } else {
                                $.modalMsg(result.message, "error");
                            }
                        }
                    })
                }
            })
        },
        //批量编辑
        BeginBathEdit: function (_this) {
            if (bodyData.length == 0) {
                $.modalMsg("请至少输入一条记录!", "error");
                return false;
            }

            if (!Document().bVerify(keyValue)) {
                return false;
            }

            //隐藏批量操作，显示取消编辑，显示批量保存
            $(_this).next().show();
            $(_this).next().next().show();
            $(_this).hide();
            var ids = $("#gridList").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var row = $("#gridList").jqGrid('editRow', ids[i], true);
            }
            $("#gridList").setGridParam().hideCol("Operating");

            var _that = this;
            _that.setBatchEditVisable(true)

        },
        //批量保存
        EndBathEdit: function (_this) {
            //显示批量操作，隐藏取消编辑，隐藏批量保存
            $(_this).prev().show();
            $(_this).hide();
            $(_this).next().hide();
            //获取表格内所有行的Id
            var ids = $("#gridList").jqGrid('getDataIDs');

            //循环保存
            for (var i = 0; i < ids.length; i++) {
                var row = $("#gridList").jqGrid('saveRow', ids[i], true);

                var rowData = $("#gridList").jqGrid("getRowData", ids[i]);
                $("#gridList").jqGrid('setCell', ids[i], "F_AllAmount", parseInt(rowData.F_InStockNum) * parseFloat(rowData.F_PurchasePrice));
            }

            completeMethod();


            $("#gridList").setGridParam().showCol("Operating");

            var _that = this;
            _that.setBatchEditVisable(false)
        },
        //结束编辑
        CancelEdit: function (_this) {
            //显示批量操作，隐藏取消编辑，隐藏批量保存
            $(_this).prev().prev().show();
            $(_this).hide();
            $(_this).prev().hide();
            //退出编辑状态
            var ids = $("#gridList").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                $('#gridList').jqGrid('restoreRow', ids[i]);
            }
            //显示操作列


            var ids = $("#gridList").jqGrid('getDataIDs');
            for (var i = 1; i <= ids.length; i++) {
                for (var j = 0; j < 9; j++) {
                    //$("#gridList").jqGrid("restoreCell", ids[i], j);
                    $("#gridList").jqGrid("restoreCell", i, j);
                    //$('#gridList').restoreCell(i, j)
                }

            }

            $("#gridList").setGridParam().showCol("Operating");
            var _that = this;
            _that.setBatchEditVisable(false)
        },
        printBarcode: function () {
            $.modalOpen({
                id: "Print",
                title: "通知单打印",
                url: "/Print/Index?fileName=pinstock&sourceName=printInStock&sourceData=" + keyValue,
                width: "800px",
                height: "550px",
                btn: null
            });
        },
        printLable: function () {

            var _grid = $("#gridList");
            var selectId = _grid.jqGrid("getGridParam", "selarrrow");//选择行的ID
            if (selectId == null || selectId == undefined || selectId.length == 0) {
                $.modalMsg("请选中一行进行打印标签", "error");
                return false;
            }
            if (selectId.length > 1) {
                $.modalMsg("只能选一行", "error");
                return false;
            }
            var rows = $("#gridList").jqGridRowValue();
            var goodsId = rows[0].F_GoodsId;

            //console.log(goodsId)
            var batchIs = true;
            $.ajax({
                url: "/WmsManage/Goods/GetOpenBatch?keyValue=" + goodsId,
                type: "get",
                dataType: "json",
                success: function (data) {
                    batchIs = data;
                    //console.log(batchIs)

                    $.modalOpen({
                        id: "PrintForm",
                        title: "标签打印",
                        url: "/WmsManage/Goods/PrintForm?keyValue=" + goodsId + '&show=1' + '&batchIsT=' + batchIs,
                        width: "700px",
                        height: "550px",
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
                                        url: "/Print/Index?fileName=pro&sourceName=goods&sourceData=" + (params.F_Qty + '|' + params.F_Batch + '|' + goodsId),
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

        },
    }
}

/**
    *  列表对象
    */
var Grid = function () {
    var height = window.screen.availHeight;
    var formHeight = $("#filterTable").height()
    height = (height - formHeight - 226) * 0.95;
    var ele = $("#gridList");
    return {
        getData: function () {
            if (keyValue) {
                $.ajax({
                    url: '/WmsManage/PurchaseInStock/GetFormJson1?keyValue=' + keyValue,
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        bodyData = data;
                    }
                });
            }
            else {
                bodyData = [];
            }

            return Grid();
        },
        exists: function (F_EnCode) {//判断当前资产编码是否存在
            var exists = false;
            for (var i = 0; i < bodyData.length; i++) {
                if (bodyData[i].F_EnCode == F_EnCode) {
                    exists = true;
                    break;
                }
            }

            return exists;
        },
        gridColums: [
            {
                label: "操作", name: "Operating", width: 50, formatter: function (cellvalue, options, rowObject) {
                    return "<span class=\"btn btn-primary edit\"  onclick=\"beginEdit(this)\"><i class=\"fa fa-edit\"></i></span>" +
                        "<span class=\"btn btn-danger finish\" onclick=\"return endEdit(this)\" style=\"display:none\" ><i class=\"fa fa-check\"></i></span>"
                }
            },
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: "产品编号", name: "F_GoodsId", hidden: true },
            { label: "产品编号", name: "F_FreeTerm1", hidden: true },
            { label: '产品名称', name: 'F_GoodsName', width: 120, align: 'left' },
            { label: '产品编码', name: 'F_EnCode', width: 100, align: 'left' },
            { label: '规格型号', name: 'F_SpecifModel', width: 100, align: 'left' },
            { label: '批次号', name: 'F_SerialNum', width: 100, align: 'left', sortable: false, editable: true, hidden: true },
            {
                label: '入库数量', name: 'F_InStockNum', width: 100, align: 'right', editable: true, editrules: {
                    custom: true,
                    custom_func: function (value, colNames) {
                        var reg = /^\d+$/;

                        if (reg.test(value)) {
                            return [true];
                        }
                        return [false, colNames + "请输入整数"];
                    }
                }
            },
            { label: '单位', name: 'F_Unit', width: 60, align: 'left' },
            //{ label: '入库仓库Id', hidden: true, name: 'F_WarehouseId', width: 100, sortable: false, editable: true, align: 'left', edittype: 'text' },
            //{ label: '入库货位Id', hidden: true, name: 'F_CargoPositionId', width: 100, sortable: false, editable: true, align: 'left', edittype: 'text' },
            //{
            //    label: '入库仓库', name: 'F_WarehouseName', index: 'F_WarehouseName', width: 150, sortable: false, editable: true, edittype: 'select', editoptions: {
            //        value: GetWar(), //设置所属角色下拉框的内容
            //        dataEvents: [//给当前控件追加事件处理  
            //            {
            //                type: 'change',                 //下拉选择的时候  
            //                fn: function (e) {              //触发方法  
            //                    //获取当前下拉框的id名字（这是点击编辑按钮时才需要的，因为点击编辑按钮后，schoolName的下拉框会变成1_WareId,其中”1“是行号）  
            //                    var itemName = this.id;
            //                    var i = itemName.lastIndexOf("_");
            //                    var str = itemName.substr(0, itemName.lastIndexOf("_", i - 1));
            //                    var selectNum = itemName.match(/^\d+/);//（这是点击编辑按钮时才需要的）将id中的数字获取出来  
            //                    var WareId = this.value; //获取选中的角色名称 
            //                    getUsername(str, WareId, this); //调用获取角色下对应用户信息data的方法  
            //                }
            //            }
            //        ]
            //    }
            //}, //选择仓库
            //{
            //    label: '入库货位', name: 'F_CargoPositionName', index: 'F_CargoPositionName', width: 150, sortable: false, editable: true, edittype: 'select', editoptions: {
            //        value: GetCar(),
            //        dataEvents: [{//给当前控件追加事件处理  
            //            type: 'change',                 //下拉选择的时候  
            //            fn: function (e) {              //触发方法  
            //                var CarGoId = this.value; //获取选中的角色名称 
            //                GetCargoWare(this); //调用获取角色下对应用户信息data的方法  
            //            }
            //        }]
            //    },
            //},
            {
                label: '采购价格', name: 'F_PurchasePrice', width: 100, align: 'left', editable: true,
            },
            {
                label: '总金额', name: 'F_AllAmount', width: 100, align: 'right',
                formatter: 'currency', formatoptions: { thousandsSeparator: ",", decimalSeparator: ".", prefix: "￥" }
            },
            { label: '保质期(天)', name: 'F_ShelfLife', width: 100, align: 'left' },
            //{
            //    label: '操作', align: 'left', width: 100,
            //    formatter: function (cellvalue) {
            //        return "<input type=\"button\" class=\"btn  btn-primary\" value=\"入库\" />";
            //    }
            //}
        ],//grid的显示列 
        init: function () {
            ele.dataGrid({
                treeGrid: false,
                datatype: "local",
                data: bodyData,
                height: height,
                //bCellEdit: true,
                multiselect: true,
                footerrow: true,
                //获取总金额总数量
                gridComplete: completeMethod,
                colModel: this.gridColums,
                cellSubmit: 'remote'

            });

            return Grid();
        },
        reload: function () {
            ele.jqGrid('setGridParam', {
                data: bodyData
            }).trigger('reloadGrid');
            return Grid();
        }

    }
}

//获取总金额总数量
function completeMethod() {

    var sum_Fy = $("#gridList").getCol('F_InStockNum', false, 'sum');
    var sum_qntqFy = $("#gridList").getCol('F_AllAmount', false, 'sum');
    $("#gridList").footerData('set', { F_SpecifModel: '合计：', F_InStockNum: '入库数量：' + sum_Fy, F_PurchasePrice: '总金额：' + sum_qntqFy });

    if (!Init) {
        const colprefix = 'jqgh_'
        //增加批设按钮
        var cols = Grid().gridColums
        for (var i = 0; i < cols.length; i++) {
            var item = cols[i];
            if (item.editable) {
                var colId = colprefix + 'gridList_' + item.name;
                var col = $("#" + colId);//得到列标题对象
                if (!!col) {
                    var editType = 'text'
                    if (!!item.edittype) {
                        editType = item.edittype
                    }

                    var value = "";
                    if (item.edittype == "select" && !!item.editoptions.value) {
                        value = item.editoptions.value
                    }
                    col.append('<a href="#" class="text-primary mybatchEdit" style="margin-left:5px;display:none;" onclick="BatchSet(\'' + item.name + '\',\'' + editType + '\',\'' + item.label + '\',\'' + value + '\')">批设</a>')
                }
            }
        }

        Init = true
    }
}


function BatchSet(filed, editType, name, data) {//
    var value;
    switch (editType) {
        case "text":
            var setNum = prompt("请输入" + name, 100);
            break;
        case "select":
            alert(data)
            break;
        default:
            prompt("请输入" + name);
            break;
    }

    //通过filed读取到属于哪一列
    //修改列值 
    var ids = $("#gridList").jqGrid('getDataIDs');
    var rowData = $("#gridList").jqGrid("getRowData", ids[i]);
    if (setNum != "" && setNum != null) {
        value = setNum;
    }
    //获取所有行数
    for (var i = 0; i < ids.length; i++) {
        var _this = $("#" + ids[i] + "_" + filed)
        if (!!_this && _this.length > 0) {
            _this.val(value)
        }
    }

    completeMethod();
}


/*获取仓位Id 仓库Id*/
function GetCargoWare(_this) {
    var goodsId = _this.parentNode.parentNode.id;
    //赋值
    $("input#" + goodsId + "_F_WarehouseId").val($("select#" + goodsId + "_F_WarehouseName option:selected").val())
    $("input#" + goodsId + "_F_CargoPositionId").val($("select#" + goodsId + "_F_CargoPositionName option:selected").val())
}

//开始编辑
function beginEdit(_this) {

    if (!Document().bVerify(keyValue)) {
        return false;
    }

    var id = _this.parentNode.nextElementSibling;
    //alert(id.innerText);
    $(_this).next().show();
    $(_this).hide();
    $("#gridList").jqGrid('editRow', id.innerText, true);

    return false
}

function amount(_this) {
    var id = _this.parentNode.parentNode.id;

    var rowData = $("#gridList").jqGrid("getRowData", id);
    $("#gridList").jqGrid('setCell', id, "F_AllAmount", parseInt(rowData.F_InStockNum) * parseFloat(rowData.F_PurchasePrice));
}


//结束编辑
function endEdit(_this) {
    //var goodsId = _this.parentNode.parentNode.id;
    ////批次号
    //var pc = $("input#" + goodsId + "_F_SerialNum").val();
    ////仓库
    //var ware = $("select#" + goodsId + "_F_WarehouseName").val();
    ////仓位
    //var cargo = $("select#" + goodsId + "_F_CargoPositionName").val();

    //if (ware == "0" || ware == "" || cargo == "" || cargo == "0") {
    //    $.modalMsg("仓库或仓位信息输入不正确", "error");
    //    return true
    //}
    //else if (pc == "") {
    //    $.modalMsg("批次号不能为空", "error");
    //    return true
    //}
    //else {
    var id = _this.parentNode.nextElementSibling;
    //    var ver = $("#gridList").jqGrid('editRow', id.innerText, false);
    //    if (ver) {
    $(_this).prev().show();
    $(_this).hide();

    //var id = _this.parentNode.nextElementSibling;
    $("#gridList").jqGrid('saveRow', id.innerText);
    amount(_this)
    completeMethod()
    return false
}
//    }

//}

//获取仓库
function GetWar() {
    //动态生成select内容 
    var str = "";
    $.ajax({
        //type: "post",
        async: false,
        url: "/WmsManage/PurchaseOutStock/GetWarSelectJson",
        success: function (data) {//通过后台获取到到数据源
            if (data != null) {//如果不为空，就循环遍历数据源
                var jsonobj = eval(data);
                var length = jsonobj.length;
                str = "请选择仓库" + ':' + "请选择仓库" + ';';

                for (var i = 0; i < length; i++) {
                    if (i != length - 1) {
                        str += jsonobj[i].id + ":" + jsonobj[i].text + ";";

                    } else {
                        str += jsonobj[i].id + ":" + jsonobj[i].text;// 这里是option里面的 value:label ,我的是Id，text
                    }
                }
            }
        }
    });
    return str;
}

/*****获取角色下对应的用户名列表 **************/
function getUsername(selectNum, WareId, _this) {
    var str = ""; //用来存放option值  
    //将增加操作的弹出菜单中的WareId的下拉框内容清空（因为每次切换内容都需要变更）  
    $("select#F_WarehouseName")
    $("select#_F_CargoPositionName").empty();
    //将修改操作中的1_WareId（1是行号）的下拉框内容清空（因为每次切换内容都需要变更）  
    $("select#" + selectNum + "_F_CargoPositionName").empty();
    if (WareId == '') {
        str += "<option value='0'>" + "请选择仓库" + "</option>";
    }
    else {
        $.ajax({
            url: "/WmsManage/PurchaseOutStock/GetCarGoFrom",
            async: false,
            cache: false,
            dataType: "json",
            data: { keyValue: WareId },//传入角色id，到后台获取json
            success: function (data) {
                var jsonobj = eval(data);
                if (jsonobj.length > 0) {//如果不为空，就循环遍历数据源
                    var length = jsonobj.length;
                    for (var i = 0; i < length; i++) {
                        str += "<option value='" + jsonobj[i].id + "'>" + jsonobj[i].text + "</option>"
                    }
                } else {
                    str += "<option value='0'>" + "该仓库下暂无货位" + "</option>";
                }
            }
        });
    }        //} //获取下面下拉框username对象 
    var username = $("select#_F_CargoPositionName");
    username.append(str);
    //获取下面下拉框selectNum_username对象 
    var username2 = $("select#" + selectNum + "_F_CargoPositionName");
    username2.append(str);//渲染option 
    GetCargoWare(_this);
}

//初始化货位
function GetCar() {
    //动态生成select内容 

    str = "0" + ':' + "请选择货位" + ';';
    $.ajax({
        //type: "post",
        async: false,
        url: "/WmsManage/PurchaseOutStock/GetCarSelectJson",
        success: function (data) {//通过后台获取到到数据源
            if (data != null) {//如果不为空，就循环遍历数据源
                var jsonobj = eval(data);
                id = jsonobj[0].id;
                var length = jsonobj.length;
                for (var i = 0; i < length; i++) {
                    if (i != length - 1) {
                        str += jsonobj[i].id + ":" + jsonobj[i].text + ";";
                    } else {
                        str += jsonobj[i].id + ":" + jsonobj[i].text;// 这里是option里面的 value:label ,我的是Id，text
                    }
                }
            }
        }
    });

    return str;
}
