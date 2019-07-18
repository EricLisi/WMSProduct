var router = "/WmsManage/InStockNotice",                            //当前页面路由 
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

/**
   窗体对象
*/
var form = {
    Data: {
        InitGridPosition: function (F_WarehouseId, change) {
            //清除grid下所有的select选项
            var gridPositions = form.grid.ele.find("select[name='F_PositionId']");
            if (change) {
                gridPositions.empty();
            }
            if (!!$("#F_WarehouseId").val()) {
                //查找对应的货位
                $.ajax({
                    url: "/WmsManage/Position/GetSelectJson?keyword=" + $("#F_WarehouseId").val() + "&searchFiled=F_WarehouseId",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        var appendHTML = "";
                        for (var i = 0; i < data.length; i++) {
                            appendHTML += "<option value='" + data[i].id + "'>" + data[i].text + "</option>"
                        }
                        if (change) {
                            gridPositions.append(appendHTML)
                        } else {
                            console.log("select count=" + gridPositions.length)
                            for (var i = 0; i < gridPositions.length; i++) {
                                console.log($(gridPositions[i]).find('option').length)
                                if ($(gridPositions[i]).find('option').length != 0) {
                                    continue;
                                }
                                $(gridPositions[i]).append(appendHTML)
                            }
                        }
                    }
                });
            }

        }
    },
    page: {//页面对象
        init: function () {
            $("#F_Date").DefalutDate();
            $("#F_SupplierId").bindSelect({
                url: "/WmsManage/Supplier/GetSelectJson"
            })

            $("#F_WarehouseId").bindSelect({
                url: "/WmsManage/Warehouse/GetSelectJson",
                change: function (data) {
                    form.Data.InitGridPosition($("F_Warehouse").val(), true)
                }
            });
            $("#F_SourceType").select2({
                minimumResultsForSearch: -1
            }).on("change", function (e) {
                var _this = this;
                if ($(_this).val() == 0) {
                    $("#F_SourceId").select2({
                        minimumResultsForSearch: -1
                    }).attr('disabled', 'disabled');
                }
                else {
                    $("#F_SourceId").select2({
                        minimumResultsForSearch: -1
                    }).removeAttr("disabled");
                }
            });
            $("#F_SourceId").select2({
                minimumResultsForSearch: -1
            });
        }
    },
    pageEvent: {//页面事件
        init: function () {//初始化
            this.bindAddRow();
            this.bindRemoveRow();
            this.bindSave();
            this.bindVerify();
            this.bindDeny();
            this.bindprintBarcode();
        },
        bindAddRow: function () {//添加行
            $("#NF-addRow").click(function () {
                if (!$("#form1").formValid()) {
                    return false;
                }
                //先结束编辑
                form.grid.endEditGrid();

                var dialogOpts = {
                    id: "InStockAddRow",
                    title: "商品选择",
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
                                F_PositionName: ""
                            })
                        }

                        form.grid.reload();
                        form.Data.InitGridPosition($("F_Warehouse").val(), false)
                        top.layer.close(index);
                    }
                }

                if ($("#F_SourceType").val() == 0) {//无来源弹出物料选择窗体
                    dialogOpts.url = "/WmsManage/Product/SelectItem"
                } else if ($("#F_SourceType").val() == 1) {//来源入库通知,弹出通知单状态
                    dialogOpts.url = "/WmsManage/InStockNotice/SelectItem"
                }

                $.modalOpen(dialogOpts);
            });
        },
        bindRemoveRow: function () {//移除行
            $("#NF-deleteRow").click(function () {
                form.grid.removeRow();
            });
        },
        bindSave: function () {//保存单据
            $("#NF-Save").click(function () {

            });
        },
        bindVerify: function () {//审核单据
            $("#NF-verify").click(function () {

            });
        },
        bindDeny: function () {//弃审单据
            $("#NF-deny").click(function () {

            });
        },


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
                        label: '批次号', name: 'F_Batch', width: 100, align: 'left', sortable: false, editable: true,
                        batchedit: true, batcheditopts: {//批设设置
                            title: "批次号",
                            inputmodel: "input",
                            inputFiled: "F_Batch",
                            callback: 'form.grid.batchEdit'
                        }
                    },
                    {
                        label: '入库数量', name: 'F_Quantity', width: 100, align: 'left', sortable: false, editable: true, editrules: {
                            //校验只可以为数字
                            number: true
                        }, batchedit: true, batcheditopts: {//批设设置
                            title: "入库数量",
                            inputmodel: "input",
                            inputFiled: "F_Quantity",
                            callback: 'form.grid.batchEdit'
                        }
                    },
                    {
                        label: '入库货位', name: 'F_PositionId', index: 'F_PositionId', width: 200, sortable: false,
                        editable: true, edittype: 'select',
                        //editoptions: {
                        //    value: ":"
                        //}
                    },
                    { label: '规格型号', name: 'F_ProductStandard', width: 100, align: 'left' },
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
        removeAll: function () {//删除全部
            var _this = this;
            _this.localData.removeAll();
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
                        _this.localData.slice(j, 1)
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
                url: "/Utility/GridBatchSet?inputmodel=" + $(that).attr('inputmodel') + "&title=" + escape($(that).attr('inputtitle')),
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