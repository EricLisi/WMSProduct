var keyValue = $.request('keyValue');//选中行
var router = "/WmsManage/Allocation";//当前页面路由
var bodyData = [];//表体数据

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
            $("#F_Vendor").bindSelect({
                url: "/BasicContentManage/Supplier/GetSelectJson",
            });

            return Document();
        },
        setVisiable: function () {//设置画面可见
            if (!keyValue) {//新建
                $("#btn_Printbarcode").hide();
                $("#btn_verify").hide();
                $("#btn_noverify").hide();
                $("#btn_instock").hide();
                $("#btn_outstock").hide();
            } else if (!!$.request('show')) {//查看
                $("#btn_verify").hide();
                $("#btn_noverify").hide();
                //$("#btn_Printbarcode").hide();
                $("#btn_instock").hide();
                $("#btn_outstock").hide();
                $("#btn_save").hide();
                $("#rowTools").hide();
                $("#rowToolsEdit").hide();
                $("#gridList").setGridParam().hideCol("Operating");
            } else if (!!$.request('verify')) {//审核
                $("#btn_save").hide();
                $("#rowTools").hide();
                $("#rowToolsEdit").hide();
                $("#btn_instock").hide();
                $("#btn_outstock").hide();
                $("#gridList").setGridParam().hideCol("Operating");
            } else {
                $("#btn_Printbarcode").hide();
                $("#btn_verify").hide();
                $("#btn_noverify").hide();
                $("#btn_instock").hide();
                $("#btn_outstock").hide();
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
                url: "/WmsManage/Allocation/GetFormJson?keyValue=" + key,
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
                for (var i = 0; i < data.length; i++) {
                    if (Grid().exists(data[i].F_EnCode)) {
                        continue;
                    }
                    data[i].F_GoodsId = data[i].F_Id
                    data[i].F_GoodsName = data[i].F_FullName
                    data[i].F_FreeTerm2 = 1;
                    data[i].F_DbNum = data[i].F_FreeTerm2

                    data[i].F_AllAmount = parseInt(data[i].F_DbNum) * parseFloat(data[i].F_PurchasePrice)


                    bodyData.push(data[i]);
                }

                //判断调出仓库与调入仓库是否不一致
                //var out = $(top.frames[iframeId].document).find("#form1 #F_OutWareId").find("option:selected").val();
                //var inware = $(top.frames[iframeId].document).find("#form1 #F_InWareId").find("option:selected").val();
                //if (out == inware) {
                //    $.modalMsg("调出仓库不能与调入仓库相同！", "error");
                //    return false;
                //}

                //var data = _form.formSerialize()

                //data.F_Id = Grid()
                //data.F_OutWareName = $(top.frames[iframeId].document).find("#form1 #F_OutWareId").find("option:selected").text();
                //data.F_InWareName = $(top.frames[iframeId].document).find("#form1 #F_InWareId").find("option:selected").text();

                //bodyData.push(data);

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

            modalOpts.title = "修改行";
            modalOpts.isClosed = true;
            modalOpts.callBack = function (iframeId, index) {
                var _form = $(top.frames[iframeId].document).find("#form1");

                if (!_form.formValid()) {
                    return false;
                }

                //判断调出仓库与调入仓库是否不一致
                var out = $(top.frames[iframeId].document).find("#form1 #F_OutWareId").find("option:selected").val();
                var inware = $(top.frames[iframeId].document).find("#form1 #F_InWareId").find("option:selected").val();
                if (out == inware) {
                    $.modalMsg("调出仓库不能与调入仓库相同！", "error");
                    return false;
                }

                var data = _form.formSerialize()
                //获取调入调出仓库
                data.F_OutWareName = $(top.frames[iframeId].document).find("#form1 #F_OutWareId").find("option:selected").text();
                data.F_InWareName = $(top.frames[iframeId].document).find("#form1 #F_InWareId").find("option:selected").text();
                console.log(data)
                for (var i = 0; i < bodyData.length; i++) {
                    if (bodyData[i].F_Id == data.F_Id) {
                        //更新
                        $.each(data, function (k, v) {
                            if (k != '__RequestVerificationToken') {
                                bodyData[i][k] = data[k]
                            }
                        })
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
                    body.find("#select2-F_GoodsId-container").html(data[0]["F_GoodsName"]).attr('title', data[0]["F_GoodsName"])
                    body.find("#F_Id-container").html(data[0]["F_Id"])
                    body.find("#select2-F_OutWareId-container").html(data[0]["F_OutWareName"]).attr('title', data[0]["F_OutWareName"])
                    body.find("#select2-F_InWareId-container").html(data[0]["F_InWareName"]).attr('title', data[0]["F_InWareName"])
                } else {
                    _form.formSerialize(data);//赋值 
                    body.find("#select2-F_FullName-container").html(data["F_GoodsName"]).attr('title', data["F_GoodsName"])
                    body.find("#select2-F_OutWareId-container").html(data["F_OutWareName"]).attr('title', data["F_OutWareName"])
                    body.find("#select2-F_InWareId-container").html(data["F_InWareName"]).attr('title', data["F_InWareName"])
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
        reloadgrid: function () {
            Grid().reload();
        },
        save: function (_this) {//保存单据 
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

            for (var i = 0; i < bodyData.length; i++) {

                if (bodyData[i].F_OutWareName == "请选择仓库" || bodyData[i].F_OutWareName == "" || bodyData[i].F_OutWareName == undefined) {

                    $.modalMsg(bodyData[i].F_GoodsName + "，请选择调出仓库", "error");
                    return false;
                }
                if (bodyData[i].F_InWareName == "请选择仓库" || bodyData[i].F_InWareName == "" || bodyData[i].F_InWareName == undefined) {

                    $.modalMsg(bodyData[i].F_GoodsName + "，请选择调入仓库", "error");
                    return false;
                }
                if (bodyData[i].F_OutCargoPositionName == "请选择货位" || bodyData[i].F_OutCargoPositionName == "该仓库下暂无货位" || bodyData[i].F_OutCargoPositionName == "" || bodyData[i].F_OutCargoPositionName == undefined) {

                    $.modalMsg(bodyData[i].F_GoodsName + "，请选择调出货位", "error");
                    return false;
                }
                if (bodyData[i].F_InCargoPositionName == "请选择货位" || bodyData[i].F_InCargoPositionName == "该仓库下暂无货位" || bodyData[i].F_InCargoPositionName == "" || bodyData[i].F_InCargoPositionName == undefined) {

                    $.modalMsg(bodyData[i].F_GoodsName + "，请选择调出货位", "error");
                    return false;
                }
                if (bodyData[i].F_OutWareName == bodyData[i].F_InWareName) {

                    $.modalMsg(bodyData[i].F_GoodsName + "，调出仓库不能与调入仓库相同", "error");
                    return false;
                }
                if (parseInt(bodyData[i].F_DbNum) - parseInt(bodyData[i].F_Num) > 0) {

                    $.modalMsg(bodyData[i].F_GoodsName + "：位于" + bodyData[i].F_OutWareName + bodyData[i].F_OutCargoPositionName + bodyData[i].F_SerialNum + "批次中的产品数量不足，请重新选择", "error");

                    return false;
                }
                if (bodyData[i].F_SerialNum == "请选择批次" || bodyData[i].F_SerialNum == "该仓库下暂无批次" || bodyData[i].F_SerialNum == "" || bodyData[i].F_SerialNum == undefined) {

                    $.modalMsg(bodyData[i].F_GoodsName + "，请输入批次", "error");
                    return false;
                }
            }

            for (var i = 0; i < bodyData.length; i++) {
                $.modalConfirm("注：您确定要保存单据吗？", function (r) {
                    if (r) {
                        var data = _form.formSerialize();
                        data.F_Id = keyValue;

                        data.dInfo = bodyData
                        $.submitForm({
                            url: router + "/SubmitFormMuti",
                            param: data,
                            success: function (result) {
                                if (result.state == 'success') {
                                    $.modalMsg("保存成功", "success");
                                    keyValue = result.data.F_Id
                                    $("#F_EnCode").val(result.data.F_EnCode)


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
        //产品出库
        outstock: function () {


            var _form = $("#form1");
            if (!_form.formValid()) {
                return false;
            }
            if (bodyData.length == 0) {
                $.modalMsg("请至少输入一条记录!", "error");
                return false;
            }

            var selectId = $("#gridList").jqGrid("getGridParam", "selrow");//选择行的ID
            if (selectId == null || selectId == undefined) {
                $.modalMsg("请选中一行", "error");
                return false;
            }


            var modalOpts = {
                id: "saveGoodsInStock",
                title: "产品出库",
                url: "/WmsManage/Allocation/InstockForm",
                width: "450px",
                height: "340px"
            }

            modalOpts.title = "产品出库"
            modalOpts.isClosed = true;
            modalOpts.callBack = function (iframeId, index) {
                var _form = $(top.frames[iframeId].document).find("#form1");
                var data = _form.formSerialize();

                data.selectId = selectId

                $.submitForm({
                    url: router + "/outStock",
                    param: data,
                    success: function (result) {

                        //$(top.frames[iframeId].document).find("#form1").isClosed();
                        if (result.state == 'success') {
                            $("#btn_noverify").hide();
                            Grid().reload();
                            $.modalMsg("出库成功", "success");
                        } else {
                            $.modalMsg(result.message, "error");
                        }
                    }
                })
            }
            $.modalOpen(modalOpts);
        },
        //产品入库
        instock: function () {

            //if (!document().bverify(keyvalue)) {
            //    return false;
            //}
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


            var _form = $("#form1");
            if (!_form.formValid()) {
                return false;
            }
            if (bodyData.length == 0) {
                $.modalMsg("请至少输入一条记录!", "error");
                return false;
            }

            var selectId = $("#gridList").jqGrid("getGridParam", "selrow");//选择行的ID
            if (selectId == null || selectId == undefined) {
                $.modalMsg("请选中一行", "error");
                return false;
            }


            var modalOpts = {
                id: "saveGoodsInStock",
                title: "产品入库",
                url: "/WmsManage/Allocation/InstockForm",
                width: "460px",
                height: "340px"
            }

            modalOpts.title = "产品入库"
            modalOpts.isClosed = true;
            modalOpts.callBack = function (iframeId, index) {
                var _form = $(top.frames[iframeId].document).find("#form1");
                var data = _form.formSerialize();

                data.selectId = selectId
                console.info(data)
                $.submitForm({
                    url: router + "/inStock",
                    param: data,
                    success: function (result) {
                        Grid().reload();
                        if (result.state == 'success') {
                            $("#btn_noverify").hide();
                            Grid().reload();
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
        noverify: function () {//反审核单据  
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
            $.modalConfirm("注：您确定要反审核单据吗？", function (r) {
                if (r) {
                    var data = _form.formSerialize();
                    data.orderId = keyValue
                    data.orderNo = $("#F_EnCode").val()

                    console.info(data)

                    $.ajax({
                        url: router + "/NoVerifyList",
                        data: data,
                        success: function (data) {
                            if (data == "反审核成功") {
                                $.modalMsg(data, "success");
                            } else {
                                $.modalMsg(data, "error");
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
                $("#gridList").jqGrid('setCell', ids[i], "F_AllAmount", parseInt(rowData.F_DbNum) * parseFloat(rowData.F_PurchasePrice));
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
            //重新加载表格
            Grid().getData().reload();
            //显示操作列

            $("#gridList").setGridParam().showCol("Operating");
        },
        printBarcode: function () {
            $.modalOpen({
                id: "Print",
                title: "条码打印",
                url: "/Print/Index?fileName=demo&sourceName=printbarcode&sourceData=" + escape($("#F_EnCode").val() + '|' + keyValue),
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
    height = (height - formHeight - 220) * 0.95;
    var ele = $("#gridList");
    return {
        getData: function () {
            if (keyValue) {
                $.ajax({
                    url: '/WmsManage/Allocation/GetFormJson1?keyValue=' + keyValue,
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
        init: function () {
            ele.dataGrid({
                treeGrid: false,
                datatype: "local",
                data: bodyData,
                height: height,
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
                    { label: '产品名称', name: 'F_GoodsName', width: 100, align: 'left' },
                    { label: '产品编码', name: 'F_EnCode', width: 80, align: 'left' },
                    { label: '规格型号', name: 'F_SpecifModel', width: 80, align: 'left' },
                    { label: '调拨数量', name: 'F_DbNum', width: 80, align: 'right', sortable: false, editable: true },
                    { label: '单位', name: 'F_Unit', width: 80, align: 'left' },
                    //{ label: '批次号', name: 'F_SerialNum', width: 100, align: 'left', sortable: false, editable: true, edittype: 'text' },
                    {
                        label: '采购价格', name: 'F_PurchasePrice', width: 100, align: 'right', editable: true,
                        formatter: 'currency', formatoptions: { thousandsSeparator: ",", decimalSeparator: ".", prefix: "￥" }

                    },
                    { label: '总金额', name: 'F_AllAmount', width: 100, align: 'left', },
                    { label: '调出仓库', name: 'F_OutWareId', hidden: true, sortable: false, editable: true, edittype: 'text', editoptions: {}, },
                    {
                        label: '调出仓库', name: 'F_OutWareName', width: 150, align: 'left', sortable: false, editable: true, edittype: 'select', editoptions: {
                            value: GetWar(),
                            dataEvents: [{//给当前控件追加事件处理  
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
                            }]
                        } //设置所属角色下拉框的内容
                    },
                    { label: '调出仓位', name: 'F_OutCargoPositionId', hidden: true, sortable: false, editable: true, edittype: 'text', editoptions: {}, },
                    {
                        label: '调出仓位', name: 'F_OutCargoPositionName', width: 150, align: 'left', sortable: false, editable: true, edittype: 'select', editoptions: {
                            value: GetCar(),
                            dataEvents: [{//给当前控件追加事件处理  
                                type: 'change',                 //下拉选择的时候  
                                fn: function (e) {              //触发方法  
                                    var CarGoId = this.value;   //获取选中的角色名称 
                                    GetOutCargo(CarGoId, this);      //调用获取角色下对应用户信息data的方法  
                                }
                            }]
                        } //设置所属角色下拉框的内容
                    },
                    {
                        label: '选择批次', name: 'F_SerialNum', index: 'F_CargoPositionName', width: 100, sortable: false, editable: true, edittype: 'select', editoptions: {
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
                    { label: '调入仓库', name: 'F_InWareId', hidden: true, sortable: false, editable: true, edittype: 'text', editoptions: {}, },
                    {
                        label: '调入仓库', name: 'F_InWareName', width: 150, align: 'left', sortable: false, editable: true, edittype: 'select', editoptions: {
                            value: GetWar(),
                            dataEvents: [{//给当前控件追加事件处理  
                                type: 'change',                 //下拉选择的时候  
                                fn: function (e) {              //触发方法  
                                    //判断调出调入是否一致
                                    getInWare(this);
                                    //获取当前下拉框的id名字（这是点击编辑按钮时才需要的，因为点击编辑按钮后，schoolName的下拉框会变成1_WareId,其中”1“是行号）  
                                    var itemName = this.id;
                                    var i = itemName.lastIndexOf("_");
                                    var str = itemName.substr(0, itemName.lastIndexOf("_", i - 1));
                                    var selectNum = itemName.match(/^\d+/);//（这是点击编辑按钮时才需要的）将id中的数字获取出来  
                                    var WareId = this.value; //获取选中的仓库名称 
                                    GetInCargoSel(str, WareId, this); //调用获取仓库下对应货位信息data的方法  
                                }
                            }]
                        } //设置所属角色下拉框的内容
                    },
                     { label: '调入仓位', name: 'F_InCargoPositionId', hidden: true, sortable: false, editable: true, edittype: 'text', editoptions: {}, },
                    {
                        label: '调入仓位', name: 'F_InCargoPositionName', width: 150, align: 'left', sortable: false, editable: true, edittype: 'select', editoptions: {
                            value: GetCar(),
                            dataEvents: [{//给当前控件追加事件处理  
                                type: 'change',                 //下拉选择的时候  
                                fn: function (e) {              //触发方法  
                                    var WareOut = this.value;
                                    GetInCargo(this);
                                }
                            }]
                        } //设置所属角色下拉框的内容
                    },
                    //{ label: "备注", name: "F_Description", width: 120, align: 'left' }
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
    var sum_Fy = $("#gridList").getCol('F_DbNum', false, 'sum');
    var sum_qntqFy = $("#gridList").getCol('F_AllAmount', false, 'sum');
    $("#gridList").footerData('set', { "F_EnCode": '合计：', F_InWareName: '调拨数量：' + sum_Fy, F_InCargoPositionName: '总金额：' + sum_qntqFy });

    $("#totalqty").html(sum_Fy)
    $("#totalmomey").html(sum_qntqFy)
}


//判断调出调入是否一致
function getInWare(_this) {
    var goodsId = _this.parentNode.parentNode.id;

    var outWare = $("select#" + goodsId + "_F_OutWareName option:selected").val()
    var InWare = $("select#" + goodsId + "_F_InWareName option:selected").val()

    if (outWare == InWare) {
        $.modalMsg("调出仓库不能与调入仓库相同！", "error");
        return false;
    }
}

//获取调出仓位
function GetOutCargo(CarGoid, _this) {
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
    var WareId = $("select#" + id + "_F_OutWareName option:selected").val()
    var CarGoid = $("select#" + id + "_F_OutCargoPositionName option:selected").val()
    var num = $("input#" + id + "_F_DbNum").val()

    $("#gridList").jqGrid('setCell', id, "F_OutWareId", $("select#" + id + "_F_OutWareName option:selected").val());
    $("#gridList").jqGrid('setCell', id, "F_OutCargoPositionId", $("select#" + id + "_F_OutCargoPositionName option:selected").val());


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



//获取调入仓位
function GetInCargo(_this) {
    var goodsId = _this.parentNode.parentNode.id;
    //赋值
    $("input#" + goodsId + "_F_InWareId").val($("select#" + goodsId + "_F_InWareName option:selected").val())
    $("input#" + goodsId + "_F_InCargoPositionId").val($("select#" + goodsId + "_F_InCargoPositionName option:selected").val())
}

function amount(_this) {
    var id = _this.parentNode.parentNode.id;

    var rowData = $("#gridList").jqGrid("getRowData", id);
    $("#gridList").jqGrid('setCell', id, "F_AllAmount", parseInt(rowData.F_DbNum) * parseFloat(rowData.F_PurchasePrice));
}

//开始编辑
function beginEdit(_this) {
    var id = _this.parentNode.nextElementSibling;

    $(_this).next().show();
    $(_this).hide();
    $("#gridList").jqGrid('editRow', id.innerText, true);

    return false
}
//结束编辑
function endEdit(_this) {
    var goodsId = _this.parentNode.parentNode.id;

    var goodsId = _this.parentNode.parentNode.id;
    //调出仓库
    var outware = $("select#" + goodsId + "_F_OutWareName").val();
    //调出仓位
    var outcargo = $("select#" + goodsId + "_F_OutCargoPositionName").val();
    //调入仓库
    var inware = $("select#" + goodsId + "_F_InWareName").val();
    //调入仓位
    var incargo = $("select#" + goodsId + "_F_InCargoPositionName").val();

    //调拨数量
    var dbnum = $("#" + goodsId + "_F_DbNum").val();
    //货位数量
    var rowData = $("#gridList").jqGrid("getRowData", goodsId);
    var cargonum = rowData.F_Num;

    if (outware == "" || outcargo == "" || inware == "" || incargo == "" || outware == "请选择仓库" || inware == "请选择仓库" || outcargo == "请选择仓库" || incargo == "请选择仓库" || outcargo == "请选择货位" || incargo == "请选择货位" || outcargo == "该仓库下暂无货位" || incargo == "该仓库下暂无货位") {
        $.modalMsg("仓库或仓位信息输入不正确", "error");
        return true
    }
    else if (outware == inware) {
        $.modalMsg("调出仓库不能与调入仓库相同", "error");
        return true
    }
    else if (cargonum == 0) {
        $.modalMsg("该仓库的仓位没有该产品！", "error");
        return true
    }
    else if (dbnum > cargonum) {
        $.modalMsg("调出数量超出库存数量！", "error");
        return true
    }
    else {
        $(_this).prev().show();
        $(_this).hide();

        var id = _this.parentNode.nextElementSibling;
        $("#gridList").jqGrid('saveRow', id.innerText);
        amount(_this)
        completeMethod();
        return false
    }

}
//获取仓库
function GetWar() {
    //动态生成select内容 
    var str = "请选择仓库" + ":" + "请选择仓库" + ";";
    $.ajax({
        //type: "post",
        async: false,
        url: "/WmsManage/PurchaseOutStock/GetWarSelectJson",
        success: function (data) {//通过后台获取到到数据源
            if (data != null) {//如果不为空，就循环遍历数据源
                var jsonobj = eval(data);
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

//获取选中仓库的仓位信息  调出
function GetCargoSel(selectNum, WareId, _this) {
    var str = ""; //用来存放option值  
    //将增加操作的弹出菜单中的WareId的下拉框内容清空（因为每次切换内容都需要变更）  
    $("select#F_OutWareName")
    $("select#F_OutCargoPositionName").empty();
    //将修改操作中的1_WareId（1是行号）的下拉框内容清空（因为每次切换内容都需要变更）  
    $("select#" + selectNum + "_F_OutCargoPositionName").empty();
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
    var username = $("select#_F_OutCargoPositionName");
    username.append(str);
    //获取下面下拉框selectNum_username对象 
    var username2 = $("select#" + selectNum + "_F_OutCargoPositionName");
    username2.append(str);//渲染option 
    GetOutCargo(id, _this);
}

//获取选中仓库的仓位信息 调入
function GetInCargoSel(selectNum, WareId, _this) {

    var str = ""; //用来存放option值  
    //将增加操作的弹出菜单中的WareId的下拉框内容清空（因为每次切换内容都需要变更）  
    $("select#F_InWareName")
    $("select#F_InCargoPositionName").empty();
    //将修改操作中的1_WareId（1是行号）的下拉框内容清空（因为每次切换内容都需要变更）  
    $("select#" + selectNum + "_F_InCargoPositionName").empty();
    if (WareId == '') {

    }
    else {
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
            }
        });
    }  //获取下面下拉框username对象 
    var username = $("select#_F_InCargoPositionName");
    username.append(str);
    //获取下面下拉框selectNum_username对象 
    var username2 = $("select#" + selectNum + "_F_InCargoPositionName");
    username2.append(str);//渲染option 
    GetInCargo(_this);
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