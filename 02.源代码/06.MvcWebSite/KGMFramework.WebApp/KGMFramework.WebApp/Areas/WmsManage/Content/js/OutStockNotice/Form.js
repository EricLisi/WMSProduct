var router = "/WmsManage/OutStockNotice",                            //当前页面路由 
    keyValue = $.request('keyValue'),//选中行Id
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        form.page.init();
        form.grid.init();
        form.pageEvent.init();
    }
}

//初始化窗体
InitForm(router, formSetting);

function jump() {
    this.location.href = "https://www.baidu.com/";
}

/**
   窗体对象
*/
var form = {
    page: {//页面对象
        init: function () {
            $("#F_Date").DefalutDate();
            $("#F_CustomerId").bindSelect({
                url: "/WmsManage/Customer/GetSelectJson"
            })

        }
    },
    Mst: {
        PositionSelectData: []//货位数据
    },
    pageEvent: {//页面事件
        init: function () {//初始化
            this.bindAddRow();
            this.bindRemoveRow();
            this.bindSave();
            this.bindVerify();
            this.bindDeny();
            if (!keyValue) {//新建
                $("#NF-verify").hide();
                $("#NF-deny").hide();
            } else if (!!$.request('show')) {//查看
                $("#NF-addRow").hide();
                $("#NF-deleteRow").hide();
                $("#NF-Save").hide();
            }
        },
        bindAddRow: function () {//添加行
            $("#NF-addRow").click(function () {
                if (!$("#form1").formValid()) {
                    return false;
                }
                //先结束编辑
                form.grid.endEditGrid();
                $.modalOpen({
                    id: "OutStockAddRow",
                    title: "商品选择",
                    url: "/WmsManage/Product/SelectItem",
                    width: "900px",
                    height: "600px",
                    callBack: function (iframeId, index) {
                        var grid = $(top.frames[iframeId].document).find("#gridList")
                        var selectId = grid.jqGrid("getGridParam", "selrow");//选择行的ID
                        if (selectId == null || selectId == undefined) {
                            $.modalMsg("请至少选择一行记录", "error");
                            return false;
                        }
                        var gridSelectData = grid.jqGridRowValue();
                        for (var i = 0; i < gridSelectData.length; i++) {
                            form.grid.addRow({
                                F_Id: guid(),
                                F_ProductId: gridSelectData[i].F_Id,
                                F_ProductCode: gridSelectData[i].F_EnCode,
                                F_ProductName: gridSelectData[i].F_FullName,
                                F_ProductStandard: gridSelectData[i].F_Standard,
                                F_ProdcuntBatchManagement: gridSelectData[i].F_BatchManagement,
                                F_Batch: "",
                                F_Quantity: 1,
                                F_PositionId: "",
                                F_PositionName: "",
                                F_DoneQty: 0
                            })
                        }

                        form.grid.reload();
                        top.layer.close(index);
                    }
                });

            });
        },
        bindRemoveRow: function () {//移除行
            $("#NF-deleteRow").click(function () {
                form.grid.removeRow();
            });
        },
        bindSave: function () {//保存单据
            $("#NF-Save").click(function () {
                form.grid.reload();
                if (form.grid.localData.length == 0) {
                    $.modalMsg("请至少输入一条记录!", "error");
                    return false;
                }
                $.modalConfirm("注：您确定要保存单据吗？", function (r) {
                    if (r) {
                        var _form = $("#form1");
                        var data = _form.formSerialize();
                        data.Binfo = form.grid.localData;
                        data.F_Id = keyValue;
                        data.F_SrTypeId = "f582a493-23ff-44bb-9c3e-37687d1cf28f";
                        console.info(data);
                        $.submitForm({
                            url: router + "/SubmitForm1",
                            param: data,
                            success: function (result) {
                                if (result.state == 'success') {
                                    $.modalMsg("保存成功", "success");
                                    //$("#btn_Printbarcode").show();
                                } else {
                                    $.modalMsg(result.message, "error");
                                }
                            }
                        })
                    }
                })
            })
        },
        bindVerify: function () {//审核单据
            $("#NF-verify").click(function () {
                $.modalConfirm("注：您确定要审核单据吗？", function (r) {
                    if (r) {
                        $.ajax({
                            url: "/WmsManage/OutStockNotice/Verify?keyValue=" + keyValue,
                            type: "get",
                            dataType: "json",
                            async: false,
                            success: function (result) {
                                if (result.state == 'success') {
                                    $.modalMsg(result.message, "success");
                                } else {
                                    $.modalMsg(result.message, "error");
                                }
                            }
                        });

                    }
                })
            });
        },
        bindDeny: function () {//弃审单据
            $("#NF-deny").click(function () {
                $.modalConfirm("注：您确定要弃审单据吗？", function (r) {
                    if (r) {
                        $.ajax({
                            url: "/WmsManage/OutStockNotice/DenyVerify?keyValue=" + keyValue,
                            type: "get",
                            dataType: "json",
                            async: false,
                            success: function (result) {
                                if (result.state == 'success') {
                                    $.modalMsg(result.message, "success");
                                } else {
                                    $.modalMsg(result.message, "error");
                                }
                            }
                        });

                    }
                })
            });
        }


    },
    grid: {//grid对象 
        ele: $("#gridList"),//对象
        localData: [],//本地数据
        options: {//参数
            treegrid: false,//是否属性结构  
            datatype: "local",
            data: this.localData,
            multiselect: true,
            height: ($(window).height() - $('.topPanel').height() - 55) < 0 ? 200 : ($(window).height() - $('.topPanel').height() - 55),
            colModel: [
                    { label: "主键", name: "F_Id", hidden: true, key: true },
                    { label: '产品编码', name: 'F_ProductCode', width: 100, align: 'left' },
                    { label: '产品名称', name: 'F_ProductName', width: 120, align: 'left' },
                    { label: '规格型号', name: 'F_ProductStandard', width: 100, align: 'left' },
                    {
                        label: '批次号', name: 'F_Batch', width: 100, align: 'left', editable: true,
                        batchedit: true, batcheditopts: {//批设设置
                            title: "批次号",
                            inputmodel: "input",
                            inputFiled: "F_Batch",
                            callback: 'form.grid.batchEdit'
                        }
                    },
                    {
                        label: '数量', name: 'F_Quantity', width: 100, align: 'left', editable: true, editrules: {
                            //校验只可以为数字
                            number: true
                        }, batchedit: true, batcheditopts: {//批设设置
                            title: "数量",
                            inputmodel: "input",
                            inputFiled: "F_Quantity",
                            callback: 'form.grid.batchEdit'
                        }
                    },
                    {
                        label: '出库仓库', name: 'F_WarehouseId', index: 'F_WarehouseId', width: 150, sortable: false,
                        //editable: true, edittype: 'select',
                        //editoptions: {
                        //    value: form.Mst.PositionSelectData
                        //}
                    },
                    {
                        label: '出库货位', name: 'F_PositionId', index: 'F_PositionId', width: 150, sortable: false,
                        //editable: true, edittype: 'select',
                        //editoptions: {
                        //    value: form.Mst.PositionSelectData
                        //}
                    },
                    { label: '已出库数量', name: 'F_DoneQty', width: 100, align: 'left' }
            ]//grid的显示列

        },
        init: function () {//初始化
            var _this = this;
            _this.ele.dataGrid(this.options);
            if (keyValue) {
                //ajax请求得到数据后初始化
                $.ajax({
                    url: router + "/GetListGridJson?keyValue=" + keyValue,
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        _this.localData = data;
                        _this.reload();
                    }
                });
            } else {
                _this.reload();
            }
        },
        reload: function () {//刷新数据
            var _this = this;
            //结束编辑  
            _this.endEditGrid();
            _this.ele.jqGrid("clearGridData");
            _this.ele.jqGrid('setGridParam', {
                data: _this.localData
            }).trigger('reloadGrid');
            //开始编辑
            _this.beginEditGrid();
        },
        reloadNoChange: function () {//刷新数据
            var _this = this;
            _this.ele.jqGrid("clearGridData");
            _this.ele.jqGrid('setGridParam', {
                data: _this.localData
            }).trigger('reloadGrid');
        },
        addRow: function (newRow) {//添加行
            var _this = this;
            _this.localData.push(newRow);
        },
        removeRow: function () {//移除行
            var _this = this;
            selectId = _this.ele.jqGrid("getGridParam", "selrow");//选择行的ID

            if (selectId == null || selectId == undefined) {
                $.modalMsg("请选中一行", "error");
                return false;
            }

            var gridRowIds = _this.ele.jqGridRowValue();//得到所有行Id 
            for (var i = 0; i < gridRowIds.length; i++) {
                for (var j = 0; j < _this.localData.length; j++) {
                    if (gridRowIds[i].F_Id == _this.localData[j].F_Id) {
                        _this.localData.splice(j, 1)
                        break;
                    }
                }
            }
            _this.reload();
        },
        beginEditGrid: function () {//开始表格编辑
            var _this = this;
            var gridRows = _this.ele.jqGrid('getRowData')
            for (var i = gridRows.length - 1; i >= 0; i--) {
                _this.ele.jqGrid('editRow', gridRows[i].F_Id, false);
                //得到选中行下所有的input
                for (var j = 0; j < _this.localData.length; j++) {
                    if (_this.localData[j].F_Id == gridRows[i].F_Id) {
                        if (_this.localData[j].F_ProdcuntBatchManagement != "true") {
                            $("#" + $(_this.ele.getCell(gridRows[i].F_Id, 'F_Batch')).attr('id')).attr('readonly', true)
                        }
                        break;
                    }
                }
            }
        },
        endEditGrid: function () {//开始表格编辑
            var _this = this;
            var gridRowIds = _this.ele.jqGrid('getDataIDs');//得到所有行Id
            for (var i = 0; i < gridRowIds.length; i++) {
                _this.ele.jqGrid('saveRow', gridRowIds[i], false);
                var currentRowData = _this.ele.jqGrid('getRowData', gridRowIds[i])
                //更改数据源,此处需要根据编辑项自己更改

                for (var j = 0; j < _this.localData.length; j++) {
                    if (_this.localData[j].F_Id == gridRowIds[i]) {
                        _this.localData[j].F_Batch = currentRowData.F_Batch;
                        _this.localData[j].F_Quantity = currentRowData.F_Quantity;
                        _this.localData[j].F_PositionId = currentRowData.F_PositionId;
                        break;
                    }
                }
            }
        },
        batchEdit: function (that) {//批设
            var _this = this
            $.modalOpen({
                title: "批设" + $(that).attr('inputtitle'),
                width: "300px",
                height: "110px",
                url: "/Utility/GridBatchSet?inputmodel=" + $(that).attr('inputmodel'),
                callBack: function (iframeId, index) {
                    var inputdata = $(top.frames[iframeId].document).find("#" + $(that).attr('inputmodel') + "data").val();
                    switch ($(that).attr('inputFiled')) {
                        case "F_Batch":
                            for (var i = 0; i < _this.localData.length; i++) {
                                if (_this.localData[i].F_ProdcuntBatchManagement == "true") {
                                    _this.localData[i].F_Batch = inputdata;
                                }
                            }
                            break;
                        default:
                            for (var i = 0; i < _this.localData.length; i++) {
                                _this.localData[i][$(that).attr('inputFiled')] = inputdata;
                            }
                            break;
                    }
                    _this.reloadNoChange();
                    top.layer.close(index);
                }
            });
        }
    }
}