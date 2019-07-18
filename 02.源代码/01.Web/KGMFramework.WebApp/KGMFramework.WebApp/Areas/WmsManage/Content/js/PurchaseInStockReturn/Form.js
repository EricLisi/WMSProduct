var keyValue = $.request('keyValue');//选中行
var router = "/WmsManage/PurchaseInStockReturn";//当前页面路由
var bodyData = [];//表体数据
var bodyfid = "";

formSetting = {
    initFormEvent: function initControl() { //画面初始化事件 
        $("#F_Date").DefalutDate()
        Grid().getData().init();
        Document().bindVendor().setVisiable();
    }

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
                $("#btn_verify").hide();
                $("#btn_noverify").hide();
                $("#btn_instock").hide();
            } else if (!!$.request('show')) {//查看
                $("#btn_verify").hide();
                //$("#btn_Printbarcode").hide();
                $("#btn_noverify").hide();
                $("#btn_instock").hide();
                $("#btn_save").hide();
                $("#rowTools").hide();
                $("#rowToolsEdit").hide();
                $("#gridList").setGridParam().hideCol("Operating");
            } else if (!!$.request('verify')) {//审核
                $("#btn_save").hide();
                $("#rowTools").hide();
                $("#rowToolsEdit").hide();
                $("#btn_instock").hide();
                $("#gridList").setGridParam().hideCol("Operating");
            } else {
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
                url: "/WmsManage/PurchaseInStockReturn/GetFormJson?keyValue=" + key,
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
        url: "/WmsManage/PurchaseInStock/Index1",
        width: "1000px",
        height: "600px",
        btns: 1,
    }

    return {
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
                console.log(data)
                //判断是否为同一供应商
                var supplier = "";
                for (var i = 0; i < data.length; i++) {
                    if (i == 0) {
                        supplier = data[i].F_VendorName;
                    }
                    if (data[i].F_VendorName!=supplier&&i>0) {
                        $.modalMsg("所选则的供应商不一致，请重新选择", "error");
                        return false;
                    }
                }
                //判断修改时是否为同一供应商
                if (bodyData.length>1) {
                    if (supplier != $("#F_VendorName").val()) {
                        $.modalMsg("所选则的供应商不一致，请重新选择", "error");
                        return false;
                    }
                }

                if (data.length >= 1) {

                    $("#F_Vendor").val(data[0].F_Vendor);
                    $("#F_VendorName").val(data[0].F_VendorName);

                    $.ajax({
                        url: "/WmsManage/Suppliers/GetGridJson?keyword=" + data[0].F_Vendor + "&&searchFiled=F_Id",
                        async: false,
                        success: function (data) {
                            var res = eval(data)
                            $("#F_Contacts").val(res[0].F_Contacts)
                            $("#F_TelePhone").val(res[0].F_TelePhone)
                            $("#F_Address").val(res[0].F_Address)
                        }
                    });

                    for (var i = 0; i < data.length; i++) {
                        //判读是否存在
                        if (Grid().exists(data[i].F_Id)) {
                            continue;
                        }

                        data[i].F_ReturnNum = data[i].F_InStockNum;
                        data[i].F_Supplier = data[i].F_VendorName;

                        data[i].F_AllAmount = parseInt(data[i].F_ReturnNum) * parseFloat(data[i].F_PurchasePrice)

                        bodyData.push(data[i]);
                    }
                }
                
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
                        console.log(data)
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

            var _form = $("#form1");
            if (!_form.formValid()) {
                return false;
            }
            if (bodyData.length == 0) {
                $.modalMsg("请至少输入一条记录!", "error");
                return false;
            }
            Tools().EndBathEdit();

            for (var i = 0; i < bodyData.length; i++) {

                if (bodyData[i].F_WarehouseName == "请选择仓库" || bodyData[i].F_WarehouseName == "" || bodyData[i].F_WarehouseName == undefined) {

                    $.modalMsg(bodyData[i].F_GoodsName + "请选择仓库", "error");
                    return false;
                }
                if (bodyData[i].F_CargoPositionName == "请选择货位" || bodyData[i].F_CargoPositionName == " 该仓库下暂无货位" || bodyData[i].F_CargoPositionName == "" || bodyData[i].F_WarehouseName == undefined) {

                    $.modalMsg(bodyData[i].F_GoodsName + "请选择货位", "error");
                    return false;
                }

                if (bodyData[i].F_SerialNum == "请选择批次" || bodyData[i].F_SerialNum == " 该仓库下暂无批次" || bodyData[i].F_SerialNum == "" || bodyData[i].F_SerialNum == undefined) {

                    $.modalMsg(bodyData[i].F_GoodsName + "请选择批次", "error");
                    return false;
                }
                console.info(bodyData[i]);
                //alert(parseInt(bodyData[i].F_ReturnNum) +" "+ parseInt(bodyData[i].F_Num));
                if (parseInt(bodyData[i].F_ReturnNum) - parseInt(bodyData[i].F_Num) > 0) {

                    $.modalMsg("第" + (i + 1) + "行中" + bodyData[i].F_GoodsName + "：产品数量不足，请重新选择", "error");

                    return false;
                }
              
            }
 
            for (var i = 0; i < bodyData.length; i++) {


                $.modalConfirm("注：您确定要保存单据吗？", function (r) {
                    if (r) {
                        var data = _form.formSerialize();
                        data.F_Id = keyValue;
                        console.info(data)

                        data.dInfo = bodyData
                        console.info(data)
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
        //产品入库
        instock: function () {
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

            //$.modalConfirm("注：您确定要入库吗？", function (r) {
            //    if (r) {
            //        var data=null;
            //        data.dInfo = bodyData
            //        console.info(data)
            //        $.ajax({
            //            url: router + "/inStock",
            //            param: data,
            //            success: function (result) {
            //                if (result == '操作成功') {
            //                    $("#btn_noverify").hide();

            //                    $.modalMsg("入库成功", "success");
            //                } else {
            //                    $.modalMsg(result, "error");
            //                }
            //            }
            //        })
            //    }
            //})

            var modalOpts = {
                id: "saveGoodsInStock",
                title: "产品入库",
                url: "/WmsManage/PurchaseInStock/InstockForm",
                width: "450px",
                height: "340px"
            }
            modalOpts.title = "产品入库"
            modalOpts.isClosed = true;
            modalOpts.callBack = function (iframeId, index) {
                var _form = $(top.frames[iframeId].document).find("#form1");
                var data = _form.formSerialize();

                data.dInfo = bodyData
                console.info(data)
                $.submitForm({
                    url: router + "/inStock",
                    param: data,
                    success: function (result) {
                        //$(top.frames[iframeId].document).find("#form1").isClosed();
                        if (result.state == 'success') {
                            $("#btn_noverify").hide();

                            $.modalMsg("入库成功", "success");
                        } else {
                            $.modalMsg(result.message, "error");
                        }
                    }
                })
            }
            $.modalOpen(modalOpts);
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

                    console.log(data)
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
                $("#gridList").jqGrid('setCell', ids[i], "F_AllAmount", parseInt(rowData.F_ReturnNum) * parseFloat(rowData.F_PurchasePrice));
            }

            completeMethod();


            $("#gridList").setGridParam().showCol("Operating");
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
       

            $("#gridList").setGridParam().showCol("Operating");
        },
        printBarcode: function () {
            $.modalOpen({
                id: "Print",
                title: "条码打印",
                url: "/Print/Index?fileName=instock&sourceName=printbarcode&sourceData=" + escape($("#F_EnCode").val() + '|' + keyValue),
                width: "1000px",
                height: "800px",
                btn: null
            });
        }
    }
}

/**
    *  列表对象
    */
var Grid = function () {
    var height = window.screen.availHeight;
    var formHeight = $("#filterTable").height()
    height = (height - formHeight - 230) * 0.95;
    var ele = $("#gridList");
    return {
        getData: function () {
            if (keyValue) {
                $.ajax({
                    url: '/WmsManage/PurchaseInStockReturn/GetFormJson2?keyValue=' + keyValue,
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        bodyData = data;
                        console.log(data)
                    }
                });
            }
            else {
                bodyData = [];
            }

            return Grid();
        },
        exists: function (F_Id) {//判断当前资产编码是否存在
            var exists = false;
            for (var i = 0; i < bodyData.length; i++) {
                if (bodyData[i].F_Id == F_Id) {
                    exists = true;
                    break;
                }
            }

            return exists;
        },
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
                colModel: [
                    {
                        label: "操作", name: 'Operating', width: 50, formatter: function (cellvalue, options, rowObject) {
                            return "<span class=\"btn btn-primary edit\"  onclick=\"beginEdit(this)\"><i class=\"fa fa-edit\"></i></span>" +
                                       "<span class=\"btn btn-danger finish\" onclick=\"return endEdit(this)\" style=\"display:none\" ><i class=\"fa fa-check\"></i></span>"
                        }
                    },
                    { label: "主键", name: "F_Id", hidden: true, key: true },
                    { label: "产品编号", name: "F_GoodsId", hidden: true },
                    { label: "产品编号", name: "F_FreeTerm1", hidden: true },
                    { label: '单据号', name: 'F_OrderNo', width: 150, align: 'left' },
                    { label: '供应商', name: 'F_Vendor', hidden: true },
                    { label: '供应商', name: 'F_VendorName', width: 100, align: 'left' },
                    { label: '产品名称', name: 'F_GoodsName', width: 100, align: 'left' },
                    { label: '产品编码', name: 'F_EnCode', width: 100, align: 'left' },
                    { label: '规格型号', name: 'F_SpecifModel', width: 100, align: 'left' },
                    { label: '入库数量', name: 'F_InStockNum', width: 100, align: 'right' },
                    { label: '退货数量', name: 'F_ReturnNum', width: 100, align: 'right', editable: true },
                    { label: '单位', name: 'F_Unit', width: 100, align: 'left' },
                    { label: '入库仓库Id', hidden: true, name: 'F_WarehouseId', width: 100, sortable: false, editable: true, align: 'left', edittype: 'text', editoptions: {}, },
                    { label: '入库货位Id', hidden: true, name: 'F_CargoPositionId', width: 100, sortable: false, editable: true, align: 'left', edittype: 'text', editoptions: {}, },
                    {
                        label: '退货仓库', name: 'F_WarehouseName', index: 'F_WarehouseName', width: 150, sortable: false, editable: true, edittype: 'select', editoptions: {
                            value: GetWar(), //设置所属角色下拉框的内容
                            dataEvents: [//给当前控件追加事件处理  
                                {
                                    type: 'change',                 //下拉选择的时候  
                                    fn: function (e) {              //触发方法  
                                        //获取当前下拉框的id名字（这是点击编辑按钮时才需要的，因为点击编辑按钮后，schoolName的下拉框会变成1_WareId,其中”1“是行号）  
                                        var itemName = this.id;
                                        var i = itemName.lastIndexOf("_");
                                        var str = itemName.substr(0, itemName.lastIndexOf("_", i - 1));
                                        var selectNum = itemName.match(/^\d+/);//（这是点击编辑按钮时才需要的）将id中的数字获取出来  
                                        var WareId = this.value; //获取选中的仓库名称 
                                        GetCargoSel(str, WareId, this); //调用获取仓库下对应货位信息data的方法  
                                    }
                                }
                            ]
                        }
                    }, //选择仓库
                    {
                        label: '退货货位', name: 'F_CargoPositionName', index: 'F_CargoPositionName', width: 150, sortable: false, editable: true, edittype: 'select', editoptions: {
                            value: GetCar(),
                            dataEvents: [{//给当前控件追加事件处理  
                                type: 'change',                 //下拉选择的时候  
                                fn: function (e) {
                                    var CarGoId = this.value; //触发方法  
                                    GetCargoWare(CarGoId, this);      //调用获取角色下对应用户信息data的方法  
                                }
                            }]
                        },
                    },
                    {
                        label: '选择批次', name: 'F_SerialNum', index: 'F_CargoPositionName', width: 150, sortable: false, editable: true, edittype: 'select', editoptions: {
                            value: GetBatch(),
                            dataEvents: [{//给当前控件追加事件处理  
                                type: 'change',                 //下拉选择的时候  
                                fn: function (e) {              //触发方法  
                                    var Batch = this.value; //获取选中的角色名称 
                                    GetNum(Batch, this); //调用获取角色下对应用户信息data的方法  
                                }
                            }
                            ]
                        },
                    },
                    { label: '货位数量', name: 'F_Num', index: 'F_Num', width: 100 },
                      {
                          label: '采购价格', name: 'F_PurchasePrice', width: 100, align: 'right', editable: true,
                          formatter: 'currency', formatoptions: { thousandsSeparator: ",", decimalSeparator: ".", prefix: "￥" }
                      },
                    { label: '总金额', name: 'F_AllAmount', width: 100, align: 'left', formatter: 'currency', formatoptions: { thousandsSeparator: ",", decimalSeparator: ".", prefix: "￥" } },
                    //{
                    //    label: '操作', align: 'left', width: 100,
                    //    formatter: function (cellvalue) {
                    //        return "<input type=\"button\" class=\"btn  btn-primary\" value=\"入库\" />";
                    //    }
                    //}
                ]//grid的显示列 
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
    var sum_Fy = $("#gridList").getCol('F_ReturnNum', false, 'sum');
    var insertnum = $("#gridList").getCol('F_InStockNum', false, 'sum');
    var sum_qntqFy = $("#gridList").getCol('F_AllAmount', false, 'sum');
    $("#gridList").footerData('set', { "F_GoodsName": '合计：', F_EnCode: '退货数量：' + sum_Fy, F_SpecifModel: '入库数量：' + insertnum, F_InStockNum: '总金额：' + sum_qntqFy });

    $("#totalqty").html(sum_Fy)
    $("#totalmomey").html(sum_qntqFy)
}




//开始编辑
function beginEdit(_this) {
    if (!Document().bVerify(keyValue)) {
        return false;
    }

    var id = _this.parentNode.nextElementSibling;

    $(_this).next().show();
    $(_this).hide();
    $("#gridList").jqGrid('editRow', id.innerText, true);

    return false
}

function amount(_this) {
    var id = _this.parentNode.parentNode.id;
    var rowData = $("#gridList").jqGrid("getRowData", id);
    $("#gridList").jqGrid('setCell', id, "F_AllAmount", parseInt(rowData.F_ReturnNum) * parseFloat(rowData.F_PurchasePrice));
}


//结束编辑
function endEdit(_this) {
    //var goodsId = _this.parentNode.parentNode.id;

    //var goodsId = _this.parentNode.parentNode.id;
    ////仓库
    //var ware = $("select#" + goodsId + "_F_WarehouseName").val();
    ////仓位
    //var cargo = $("select#" + goodsId + "_F_CargoPositionName").val();
    ////入库数量
    //var instock = _this.parentNode.parentNode.firstChild.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.nextElementSibling.innerText;
    ////退货数量
    //var returnstock = $("#" + goodsId + "_F_ReturnNum").val();

    //if (ware == "请选择仓库" || ware == "" || cargo == "" || cargo == "请选择仓库" || cargo == "请选择货位" || cargo == "该仓库下暂无货位") {
    //    $.modalMsg("仓库或仓位信息输入不正确", "error");
    //    return true
    //}
    //else if (returnstock > instock) {
    //    $.modalMsg("退货数量不能大于入库数量！", "error");
    //    return true
    //}
    //else {
        $(_this).prev().show();
        $(_this).hide();

        var id = _this.parentNode.nextElementSibling;
        $("#gridList").jqGrid('saveRow', id.innerText);
        amount(_this)
        completeMethod();
        return false
    //}

}

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

/*****获取仓位信息 **************/
function GetCargoSel(selectNum, WareId, _this) {
    var str = ""; //用来存放option值  
    //将增加操作的弹出菜单中的WareId的下拉框内容清空（因为每次切换内容都需要变更）  
    $("select#F_WarehouseName")
    $("select#F_CargoPositionName").empty();
    //将修改操作中的1_WareId（1是行号）的下拉框内容清空（因为每次切换内容都需要变更）  
    $("select#" + selectNum + "_F_CargoPositionName").empty();
    if (WareId == '') {
        str += "<option value='0'>" + "请选择仓库" + "</option>";
    }
    else {
        var id = "";
        $.ajax({
            url: "/WmsManage/PurchaseOutStock/GetCarGoFrom",
            async: false,
            cache: false,
            dataType: "json",
            data: { keyValue: WareId },//传入角色id，到后台获取json
            success: function (data) {
                console.info(data);
                var jsonobj = eval(data);
                if (jsonobj.length > 0) {//如果不为空，就循环遍历数据源
                    var length = jsonobj.length;
                    for (var i = 0; i < length; i++) {
                        str += "<option value='" + jsonobj[i].id + "'>" + jsonobj[i].text + "</option>"
                    }
                } else {
                    str += "<option>" + "该仓库下暂无货位" + "</option>";
                }
                id = jsonobj[0].id;
            }
        });
    }  //获取下面下拉框username对象 
    var username = $("select#_F_CargoPositionName");
    username.append(str);
    //获取下面下拉框selectNum_username对象 
    var username2 = $("select#" + selectNum + "_F_CargoPositionName");
    username2.append(str);//渲染option 
    GetCargoWare(id, _this);
}

/*获取仓位Id 仓库Id*/
function GetCargoWare(CarGoid, _this) {
    var Batch = "";
    var id = _this.parentNode.parentNode.id;
    var rowData = $("#gridList").jqGrid("getRowData", id);
    var GoosId = rowData.F_GoodsId;

    var str = ""; //用来存放option值  
    //将增加操作的弹出菜单中的WareId的下拉框内容清空（因为每次切换内容都需要变更）  
    $("select#_F_SerialNum").empty();
    $("select#" + id + "_F_SerialNum").empty();

    if (CarGoid == '') {
        str += "<option value='0'>" + "该货位下暂无该产品的批次" + "</option>";
    }
    else {
        $.ajax({
            url: "/WmsManage/PurchaseOutStock/GetBatch",
            async: false,
            cache: false,
            dataType: "json",
            data: { CarGoid: CarGoid, GoodsId: GoosId },//传入角色id，到后台获取json
            success: function (data) {
                var jsonobj = eval(data);
                if (jsonobj.length > 0) {//如果不为空，就循环遍历数据源
                    var length = jsonobj.length;
                    for (var i = 0; i < length; i++) {
                        if (jsonobj[0] == "" && length == 1) {
                            str += "<option value='0'>" + "该货位下暂无该产品的批次" + "</option>";
                        }

                        if (jsonobj[i] == "") {
                            continue;
                        }
                        else {
                            str += "<option value='" + jsonobj[i] + "'>" + jsonobj[i] + "</option>";
                        }

                    }
                } else {
                    str += "<option value='0'>" + "该货位下暂无该产品的批次" + "</option>";
                }
                Batch = data[0];
            }
        });
    }        //} //获取下面下拉框username对象 
    var username = $("select#_F_SerialNum");
    username.append(str);
    //获取下面下拉框selectNum_username对象 
    var username2 = $("select#" + id + "_F_SerialNum");
    username2.append(str);//渲染option 
    GetNum(Batch, _this);
}

/*获取数量*/
function GetNum(Batch, _this) {
    var id = _this.parentNode.parentNode.id;
    var rowData = $("#gridList").jqGrid("getRowData", id);
    var GoosId = rowData.F_GoodsId;
    var WareId = $("select#" + id + "_F_WarehouseName option:selected").val()
    var CarGoid = $("select#" + id + "_F_CargoPositionName option:selected").val()
    var num = $("input#" + id + "_F_Num").val()

    $("#gridList").jqGrid('setCell', id, "F_WarehouseId", $("select#" + id + "_F_WarehouseName option:selected").val());
    $("#gridList").jqGrid('setCell', id, "F_CargoPositionId", $("select#" + id + "_F_CargoPositionName option:selected").val());


    $.ajax({
        async: false,
        data: {
            GoodsId: GoosId,
            WarId: WareId,
            CarId: CarGoid,
            Batch: Batch
        },
        url: "/WmsManage/PurchaseOutStock/GetNum",
        success: function (data) {//通过后台获取到到数据源

            if (data == "") {
                $("#gridList").jqGrid('setCell', id, "F_Num", "0");

            } else {
                $("#gridList").jqGrid('setCell', id, "F_Num", data);

            }

        }

    })
}

//初始化货位
function GetCar() {
    //动态生成select内容 
    var id = "";
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

/*初始化批次*/
function GetBatch() {
    //动态生成select内容 
    str = "0" + ':' + "请选择批次" + ';';
    $.ajax({
        dataType: "json",
        async: false,
        url: "/WmsManage/PurchaseOutStock/GetBatchSelectJson",
        success: function (data) {//通过后台获取到到数据源
            console.info(data);
            if (data != null) {//如果不为空，就循环遍历数据源
                var jsonobj = eval(data);
                id = jsonobj[0].id;
                var length = jsonobj.length;
                for (var i = 0; i < length; i++) {
                    if (data[i] == "") {
                        continue;
                    }
                    if (i != length - 1) {
                        str += jsonobj[i] + ":" + jsonobj[i] + ";";
                    } else {
                        str += jsonobj[i] + ":" + jsonobj[i];// 这里是option里面的 value:label ,我的是Id，text
                    }
                }
            }
        }
    });

    return str;
}