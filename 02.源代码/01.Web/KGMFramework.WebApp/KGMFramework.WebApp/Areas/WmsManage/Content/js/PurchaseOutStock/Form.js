﻿var keyValue = $.request('keyValue');//选中行
var type = $.request('type')
var router = "/WmsManage/PurchaseOutStock";//当前页面路由
var bodyData = [];//表体数据
var Init = false;

formSetting = {
    initFormEvent: function initControl() { //画面初始化事件

        $("#F_Date").DefalutDate()
        $("#F_DueDate").DefalutDate()
        Grid().getData().init();
        Document().bindDepartment().setVisiable();
        $("#F_CustomerId").bindSelect({
            url: "/WmsManage/Customer/GetSelectJson",
        }).on("select2:select", function () {
            $.ajax({
                url: "/WmsManage/Customer/GetFormJson?keyValue=" + $("#F_CustomerId").val(),
                type: "get",
                dataType: "json",
                success: function (data) {
                    $("#F_Contacts").val(data.F_Contacts);
                    $("#F_TelePhone").val(data.F_TelePhone);
                    $("#F_Address").val(data.F_Address);
                }
            });
        });
        $("#F_WarehouseId").bindSelect({
            url: "/WmsManage/Warehouse/GetSelectJson"
        });
        var warId = localStorage.getItem('WarehouseId');
        var isAdmin = localStorage.getItem('IsAdmin');
        if (isAdmin =="false") {
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
        bindDepartment: function () {//绑定供应商
            return Document();
        },
        setVisiable: function () {//设置画面可见
            if (!keyValue) {//新建 
                $("#btn_Printbarcode").hide();
                $("#btn_verify").hide();
                $("#btn_noverify").hide();
                $("#btn_BeginBathEdit").hide()
            } else if (!!$.request('show')) {//查看
                $("#gridList").setGridParam().hideCol("Operating");
                $("#btn_verify").hide();
                $("#btn_noverify").hide();
                $("#btn_BeginBathEdit").hide();
                $("#btn_save").hide();
                $("#rowTools").hide();
            } else if (!!$.request('verify') && $.request('verify') == 1) {//审核
                $("#btn_Printbarcode").hide();
                $("#btn_noverify").hide();
                $("#gridList").setGridParam().hideCol("Operating");
                $("#btn_save").hide();
                $("#btn_BeginBathEdit").hide();
                $("#rowTools").hide();
            } else if (!!$.request('verify') && $.request('verify') == 2) {//反审核
                $("#btn_verify").hide();
                $("#btn_Printbarcode").hide();
                $("#gridList").setGridParam().hideCol("Operating");
                $("#btn_save").hide();
                $("#btn_BeginBathEdit").hide();
                $("#rowTools").hide();
            } else {
                $("#btn_Printbarcode").hide();
                $("#btn_noverify").hide();
                $("#btn_verify").hide();
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
                url: router + "/GetFormJson?keyValue=" + key,
                type: "get",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data) {
                        if (data.F_Status == "True") {//单据已经审核
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
        url: "/WmsManage/Goods/Index1",
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

                var body = top.$("#layui-layer" + index);
                var _form = body.find('#form')//取form表单
                var _grid = $(top.frames[iframeId].document).find("#gridList");
                var selectId = _grid.jqGrid("getGridParam", "selrow");//选择行的ID
                if (selectId == null || selectId == undefined) {
                    $.modalMsg("请选中一行", "error");
                    return false;
                }

                var data = _grid.jqGridRowValue();

                for (var i = 0; i < data.length; i++) {
                    data[i].F_GoodsName = data[i].F_FullName;
                    data[i].F_GoodsId = data[i].F_Id;
                    data[i].F_OutStockNum = 1;
                    var a = 0;
                    for (var j = 0; j < bodyData.length; j++) {
                        if (bodyData[j].F_Id == data[i].F_Id) {
                            a = 1;
                        }
                    }

                    if (a == 0) {
                        bodyData.push(data[i]);
                    }
                }
                if (data.length > 0) {
                    $("#btn_BeginBathEdit").show()
                }
                Grid().reload();

            },
            modalOpts.success = function (layero, index, layer) {
            var body = top.$("#layui-layer" + index);
            var btnDiv = body.find('.layui-layer-btn')//取form表单
            var html = ''
        },





        $.modalOpen(modalOpts);


        },
        edit: function () {
            if (!Document().bVerify(keyValue)) {
                return false;
            }

            var _grid = $("#gridList");
            var selectId = _grid.jqGrid("getGridParam", "selarrrow");//选择行的ID
            if (selectId == null || selectId == undefined) {
                $.modalMsg("请选中一行", "error");
                return false;
            }
            modalOpts.isClosed = true;
            modalOpts.title = "修改明细";
            modalOpts.url = "/WmsManage/PurchaseOutStock/Form1?keyValue=" + keyValue,
            modalOpts.callBack = function (iframeId, index) {
                var _form = $(top.frames[iframeId].document).find("#form1");
                if (!_form.formValid()) {
                    return false;
                }
                var data = _form.formSerialize()
                data.F_FullName = data.F_GoodsName;
                var selData = _grid.jqGridRowValue();
                //循环赋值
                for (var i = 0; i < selData.length; i++) {

                    for (var j = 0; j < bodyData.length; j++) {
                        if (selData[i].F_EnCode == bodyData[j].F_EnCode) {
                            //得到当前选中行，更新行信息
                            $.each(data, function (k, v) {
                                bodyData[j][k] = v;
                            })
                        }
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
                    body.find("#select2-F_AssetType-container").html(data[0]["F_AssetTypeName"]).attr('title', data[0]["F_AssetTypeName"])
                } else {
                    _form.formSerialize(data);//赋值
                    body.find("#select2-F_AssetType-container").html(data["F_AssetTypeName"]).attr('title', data["F_AssetTypeName"])
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


            if (bodyData.length == 0) {
                $("#btn_BeginBathEdit").hide()
                $("#btn_EndBathEdit").hide()

            }
            Grid().reload();
            var data = $("#gridList").jqGridRowValue();
            if (!data || data.length == 0) {
                $("#F_Department").removeAttr("disabled")
            }
        },
        save: function () {//保存单据  
            if (!Document().bVerify(keyValue)) {
                return false;
            }

            var _form = $("#form1");
            if (!_form.formValid()) {
                return false;
            }
            Tools().EndBathEdit();
            if (bodyData.length == 0) {
                $.modalMsg("请至少输入一条记录!", "error");
                return false;
            }
            var Value = $("#F_CustomerId").val();
            if (Value == "0") {
                $.modalMsg("请选择客户", "error");
                return false;
            }

            for (var i = 0; i < bodyData.length; i++) {
                if (bodyData[i].F_OutStockNum <= 0) {
                    $.modalMsg(bodyData[i].F_GoodsName + "，入库数量不可以小于零", "error");
                    return false;
                }
            }

            //for (var i = 0; i < bodyData.length; i++) {

            //    if (bodyData[i].F_WarehouseName == "请选择仓库" || bodyData[i].F_WarehouseName == "" || bodyData[i].F_WarehouseName == undefined) {

            //        $.modalMsg(bodyData[i].F_GoodsName + "请选择仓库", "error");
            //        return false;
            //    }
            //    if (bodyData[i].F_CargoPositionName == "请选择货位" || bodyData[i].F_CargoPositionName == " 该仓库下暂无货位" || bodyData[i].F_CargoPositionName == "" || bodyData[i].F_WarehouseName == undefined) {

            //        $.modalMsg(bodyData[i].F_GoodsName + "请选择货位", "error");
            //        return false;
            //    }

            //    if (bodyData[i].F_Batch == "请选择批次" || bodyData[i].F_Batch == " 该仓库下暂无批次" || bodyData[i].F_Batch == "" || bodyData[i].F_WarehouseName == undefined) {

            //        $.modalMsg(bodyData[i].F_GoodsName + "请选择批次", "error");
            //        return false;
            //    }
            //    if (parseInt(bodyData[i].F_OutStockNum) - parseInt(bodyData[i].F_Num) > 0) {

            //        $.modalMsg(bodyData[i].F_GoodsName + "位于" + bodyData[i].F_WarehouseName + bodyData[i].F_CargoPositionName + bodyData[i].F_Batch + "批次中的产品数量不足，请重新选择", "error");

            //        return false;
            //    }
            //
            $.modalConfirm("注：您确定要保存单据吗？", function (r) {
                if (r) {
                    var data = _form.formSerialize();
                    data.dInfo = bodyData;
                    data.F_CustomerName = $("#F_CustomerId").find("option:selected").text();
                    data.F_WarehouseName = $("#F_WarehouseId").find("option:selected").text();
                    $.submitForm({
                        url: router + "/SubmitFormMuti",
                        param: data,
                        success: function (result) {
                            console.info(result)
                            if (result.state == "success") {

                                $("#F_EnCode").val(result.data.F_EnCode);
                                $.modalMsg("保存成功", "success");
                            } else {
                                $.modalMsg("保存失败", "error");
                            }
                        }
                    })
                }
            })
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
                    data.orderUser = $("#F_Operator").val()
                    $.submitForm({
                        url: router + "/VerifyList1",
                        param: data,
                        success: function (result) {
                            if (result.state == 'success') {
                                $("#btn_createCode").show();
                                if (!keyValue) {
                                    keyValue = result.data
                                }
                                $.modalMsg("审核成功", "success");
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
        BeginBathEdit: function (_this) {
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
                $("#gridList").jqGrid('setCell', ids[i], "F_TotalAmount", parseInt(rowData.F_OutStockNum) * parseFloat(rowData.F_SellingPrice));

            }

            //显示操作列
            $("#gridList").setGridParam().showCol("Operating");


            var _that = this;
            _that.setBatchEditVisable(false);
            completeMethod();
        },
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

            var _that = this;
            _that.setBatchEditVisable(false)

            //显示操作列
            $("#gridList").setGridParam().showCol("Operating");
        },
        printBarcode: function () {
            $.modalOpen({
                id: "Print",
                title: "通知单打印",
                url: "/Print/Index?fileName=soutstock&sourceName=printOutstock&sourceData=" + keyValue,
                width: "800px",
                height: "550px",
                btn: null
            });
        }
    }
}
//单行编辑开始
function beginEdit(_this) {
    $(_this).next().show();
    $(_this).hide();
    var id = _this.parentNode.parentNode.id;
    $("#gridList").jqGrid('editRow', id, true);

    var _that = this;
    _that.setBatchEditVisable(true)
}
//单行编辑结束
function endEdit(_this) {
    $(_this).prev().show();
    $(_this).hide();
    var id = _this.parentNode.parentNode.id;
    $("#gridList").jqGrid('saveRow', id);
    var rowData = $("#gridList").jqGrid("getRowData", id);
    $("#gridList").jqGrid('setCell', id, "F_TotalAmount", parseInt(rowData.F_OutStockNum) * parseFloat(rowData.F_SellingPrice));
    completeMethod();

    var _that = this;
    _that.setBatchEditVisable(false)
}
//获取总金额和总数量
function completeMethod() {

    var sum_Fy = $("#gridList").getCol('F_OutStockNum', false, 'sum');
    var sum_qntqFy = $("#gridList").getCol('F_TotalAmount', false, 'sum');
    $("#gridList").footerData('set', {
        F_SpecifModel: '合计：',
        F_OutStockNum: '数量：' + sum_Fy,
        F_SellingPrice: "总金额：" + sum_qntqFy
    });
    $("#totalqty").html(sum_Fy)
    $("#totalmomey").html(sum_qntqFy);


    if (!Init) {
        const colprefix = 'jqgh_'
        //增加批设按钮
        var cols = Grid().getGridColumns();
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
            var setNum=  prompt("请输入" + name,100);
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
    if (setNum != "" && setNum != null) {
        value = setNum;
    }
    //获取所有行数
    var rowsCount = 2;
    var ids = $("#gridList").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var _this = $("#" + ids[i] + "_" + filed)
        if (!!_this && _this.length > 0) {
            _this.val(value)
        }
    }
    completeMethod();
}
/**
    *  列表对象
    */
var Grid = function () {
    var height = window.screen.availHeight;
    var formHeight = $("#filterTable").height()
    height = (height - formHeight - 391) * 0.95;
    var ele = $("#gridList");
    return {
        getData: function () {
            if (keyValue) {
                $.ajax({
                    url: '/WmsManage/PurchaseOutStock/GetFormJson1?keyValue=' + keyValue,
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
        getGridColumns: function () {

            var colums = [
             {
                 label: "操作", name: 'Operating', width: 70, formatter: function (cellvalue, options, rowObject) {
                     return "<span class='btn btn-primary edit'  onclick='return beginEdit(this)'><i class='fa fa-edit'></i></span>" +
                                "<span class='btn btn-danger finish' onclick='return endEdit(this)' style='display:none' ><i class='fa fa-check'></i></span>"
                 }
             },
            { label: "主键", name: "F_Id", key: true, hidden: true, },
            { label: '产品名称', name: 'F_GoodsName', width: 120, align: 'left' },
            { label: '产品编码', name: 'F_EnCode', width: 100, align: 'left' },
            { label: '规格型号', name: 'F_SpecifModel', width: 100, align: 'left' },
            { label: '出库数量', name: 'F_OutStockNum', width: 100, align: 'rigth', editable: true },
            { label: '单位', name: 'F_Unit', width: 60, align: 'left' },

       //     {
       //         label: '出库仓库', width: 100, name: 'F_WarehouseName', index: 'F_WarehouseName', sortable: false, editable: true, edittype: 'select', editoptions: {
       //             value: GetWar(this), //设置所属角色下拉框的内容
       //             dataEvents: [//给当前控件追加事件处理  
       //                 {
       //                     type: 'change',                 //下拉选择的时候  
       //                     fn: function (e) {              //触发方法  
       //                         //获取当前下拉框的id名字（这是点击编辑按钮时才需要的，因为点击编辑按钮后，schoolName的下拉框会变成1_WareId,其中”1“是行号）  
       //                         var itemName = this.id;
       //                         var i = itemName.lastIndexOf("_");
       //                         var str = itemName.substr(0, itemName.lastIndexOf("_", i - 1));
       //                         var selectNum = itemName.match(/^\d+/);//（这是点击编辑按钮时才需要的）将id中的数字获取出来  
       //                         var WareId = this.value; //获取选中的角色名称 
       //                         getCarName(str, WareId, this); //调用获取角色下对应用户信息data的方法  
       //                     }
       //                 }
       //             ]
       //         }
       //     }, //选择货位
       //{
       //    label: '出库货位', name: 'F_CargoPositionName', index: 'F_CargoPositionName', width: 100, sortable: false, editable: true, edittype: 'select', editoptions: {
       //        value: GetCar(),
       //        dataEvents: [{//给当前控件追加事件处理  
       //            type: 'change',                 //下拉选择的时候  
       //            fn: function (e) {              //触发方法                  
       //                getBatchName(this); //调用获取角色下对应用户信息data的方法  
       //            }
       //        }
       //        ]
       //    },

       //},
       //       {
       //           label: '选择批次', name: 'F_Batch', index: 'F_CargoPositionName', width: 150, sortable: false, editable: true, edittype: 'select', editoptions: {
       //               value: GetBatch(),
       //               dataEvents: [{//给当前控件追加事件处理  
       //                   type: 'change',                 //下拉选择的时候  
       //                   fn: function (e) {              //触发方法  
       //                       var Batch = this.value; //获取选中的角色名称 
       //                       GetNum(Batch, this); //调用获取角色下对应用户信息data的方法  
       //                   }
       //               }
       //               ]
       //           },

       //       },
       // { label: '货位数量', name: 'F_Num', index: 'F_Num', width: 100, sortable: false, editable: true, edittype: 'text', editoptions: { readonly: true }, },
         //{ label: '货位数量', name: 'F_Num', width: 100, align: 'left' },

         { label: '销售价格', name: 'F_SellingPrice', width: 100, align: 'left' },
        {
            label: '总金额', name: 'F_TotalAmount', width: 100, align: 'right',
            formatter: 'currency', formatoptions: { thousandsSeparator: ",", decimalSeparator: ".", prefix: "￥" }
        },
        { label: '保质期（天）', name: 'F_ShelfLife', width: 100, align: 'left' },
        { label: '产品Id', hidden: true, name: 'F_GoodsId', width: 100, align: 'left' },
         //{ label: '货位id', hidden: true, name: 'F_CargoPositionId', width: 100, align: 'left' },
         // { label: '仓库id', hidden: true, name: 'F_WarehouseId', width: 100, align: 'left' },
         //  { label: '货位Id', hidden: true, name: 'F_CargoPositionId', index: 'F_CargoPositionId', width: 50, sortable: false, editable: true, edittype: 'text', editoptions: {}, },
         //{ label: '仓库Id', hidden: true, name: 'F_WarehouseId', index: 'F_WarehouseId', width: 50, sortable: false, editable: true, edittype: 'text', editoptions: {}, },
            ]
            return colums;
        },
        init: function () {
            var _this = this;
            ele.dataGrid({
                treeGrid: false,
                datatype: "local",
                data: bodyData,
                height: height,
                multiselect: true,
                colModel: _this.getGridColumns(),
                footerrow: true,
                //获取总金额总数量
                gridComplete: completeMethod,
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
    function myvalue(elem, operation, value) {
        if (operation === 'get') {
            return $(elem).val();
        } else if (operation === 'set') {
            $(elem).val(value);
        }
    };
    /*获取数量*/
    function GetNum(Batch, _this) {
        var id = _this.parentNode.parentNode.id;
        var rowData = $("#gridList").jqGrid("getRowData", id);
        var GoosId = rowData.F_GoodsId;
        var WarId = $("select#" + id + "_F_WarehouseName option:selected").val();//选中的值
        var CarId = $("select#" + id + "_F_CargoPositionName option:selected").val();//选中的值


        $("#gridList").jqGrid('setCell', id, "F_WarehouseId", $("select#" + id + "_F_WarehouseName option:selected").val());
        $("#gridList").jqGrid('setCell', id, "F_CargoPositionId", $("select#" + id + "_F_CargoPositionName option:selected").val());


        $.ajax({
            async: false,
            data: {
                GoodsId: GoosId,
                WarId: WarId,
                CarId: CarId,
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
    /*获取仓库*/
    function GetWar() {

        //动态生成select内容 
        var id = "";
        var str = "";
        str = "0" + ':' + "请选择仓库" + ';';
        $.ajax({
            //type: "post",
            async: false,
            url: "/WmsManage/PurchaseOutStock/GetWarSelectJson",
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
    /*****获取仓位 **************/
    function getCarName(selectNum, WareId, _this) {

        var str = ""; //用来存放option值  
        //将增加操作的弹出菜单中的WareId的下拉框内容清空（因为每次切换内容都需要变更）  
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


        getBatchName(_this);
    }
    /*****获取批次 **************/
    function getBatchName(_this) {
        var Batch = "";
        var id = _this.parentNode.parentNode.id;
        var rowData = $("#gridList").jqGrid("getRowData", id);
        var GoosId = rowData.F_GoodsId;

        var CarId = $("select#" + id + "_F_CargoPositionName option:selected").val();//选中的值

        var str = ""; //用来存放option值  
        //将增加操作的弹出菜单中的WareId的下拉框内容清空（因为每次切换内容都需要变更）  
        $("select#_F_Batch").empty();
        $("select#" + id + "_F_Batch").empty();

        if (CarId == '') {
            str += "<option value='0'>" + "该货位下暂无该产品的批次" + "</option>";
        }
        else {
            $.ajax({
                url: "/WmsManage/PurchaseOutStock/GetBatch",
                async: false,
                cache: false,
                dataType: "json",
                data: { CarGoid: CarId, GoodsId: GoosId },//传入角色id，到后台获取json
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
        var username = $("select#_F_Batch");
        username.append(str);
        //获取下面下拉框selectNum_username对象 
        var username2 = $("select#" + id + "_F_Batch");
        username2.append(str);//渲染option 
        GetNum(Batch, _this);
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
    //获取总金额总数量

}

