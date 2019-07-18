var router = "/WmsManage/PackList",                            //当前页面路由 
    keyValue = $.request('keyValue'),//选中行Id
    IsAdmin = false;
SaveheadId = "";
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

            $("#F_SourceType").select2({
                minimumResultsForSearch: -1
            }).on("change", function (e) {
                var _this = this;
                if ($(_this).val() == 0) {
                    $("#F_SourceId").attr("disabled", "true");
                    $("#F_SourceId").css('background-color', 'lightgray');
                    $("#F_SourceId").val("");
                    $("#NF-deleteRow").show();
                }
                else {
                    $("#F_SourceId").removeAttr("disabled");
                    $("#F_SourceId").css('background-color', 'white');
                    $("#NF-deleteRow").hide();

                }
                form.grid.localData = [];
                form.grid.reload();
            });
            form.pageEvent.bindIsAdmin();
        }
    },
    Mst: {
        PositionSelectData: []//货位数据
    },
    pageEvent: {//页面事件
        init: function () {//初始化
            this.bindIsAdmin();
            this.bindAddRow();
            this.bindRemoveRow();
            this.bindSave();
            this.bindVerify();
            this.bindDeny();
            this.bindsetVisiable();
            this.bindLoadSelect();
            //this.bindFormData();

        },
        bindAddRow: function () {//添加行
            $("#NF-addRow").click(function () {
                if (!$("#form1").formValid()) {
                    return false;
                }
                //先结束编辑
                form.grid.endEditGrid();
                if ($("#F_SourceType").val() == 0) {//无来源弹出物料选择窗体
                    $.modalOpen({
                        id: "InStockAddRow",
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
                            var Mdate = new Date();
                            var year = Mdate.getFullYear() + 1;
                            var month = Mdate.getMonth() + 1;
                            var day = Mdate.getDay();
                            var hour = Mdate.getHours();
                            var minute = Mdate.getMinutes();
                            minute = minute < 10 ? ('0' + minute) : minute;
                            var second = Mdate.getSeconds();
                            second = minute < 10 ? ('0' + second) : second;
                            var Edate = new Date(year, month, day, hour, minute, second);
                            for (var i = 0; i < gridSelectData.length; i++) {
                                form.grid.addRow({
                                    F_Id: guid(),
                                    F_ProductId: gridSelectData[i].F_Id,
                                    F_ProductCode: gridSelectData[i].F_EnCode,
                                    F_ProductName: gridSelectData[i].F_FullName,
                                    F_ProductStandard: gridSelectData[i].F_Standard,
                                    F_ProdcuntBatchManagement: gridSelectData[i].F_BatchManagement,
                                    F_ExpiryDate: form.pageEvent.bindFormData(Edate),
                                    F_MadeDate: form.pageEvent.bindFormData(Mdate),
                                    F_Batch: "",
                                    F_Quantity: 1,
                                    F_PositionId: "",
                                })
                            }

                            form.grid.reload();
                            top.layer.close(index);
                        }
                    });
                } else if ($("#F_SourceType").val() == 1) {//来源入库通知,弹出通知单状态

                    $.modalOpen({
                        id: "OutStockAddRow",
                        title: "单据选择",
                        url: "/WmsManage/PackList/SelectItem",
                        width: "900px",
                        height: "600px",
                        callBack: function (iframeId, index) {
                            var grid = $(top.frames[iframeId].document).find("#gridList")
                            var selectId = grid.jqGrid("getGridParam", "selrow");//选择行的ID
                            if (selectId == null || selectId == undefined) {
                                $.modalMsg("请选择一行记录", "error");
                                return false;
                            }
                            var gridSelectData = grid.jqGridRowValue();


                            var itemNameSelect = $("#F_CustomerId").select2();
                            itemNameSelect.val(gridSelectData.F_CustomerId).trigger("change");
                            itemNameSelect.change();
                            var code = $("#F_SourceId").val();

                            if (code == gridSelectData.F_EnCode) {
                                $.modalMsg("已选择此单据", "error");
                                return false;

                            }


                            $.ajax({
                                url: router + "/GetOutGoods?keyValue=" + gridSelectData.F_Id,
                                success: function (data) {
                                    form.grid.localData = [];
                                    var result = JSON.parse(data);
                                    for (var i = 0; i < result.length; i++) {
                                        form.grid.addRow({
                                            F_Id: guid(),
                                            F_ProductId: result[i].F_ProductId,
                                            F_ProductCode: result[i].F_ProductCode,
                                            F_ProductName: result[i].F_ProductName,
                                            F_ProductStandard: result[i].F_ProductStandard,
                                            F_ProdcuntBatchManagement: result[i].F_BatchManagement,
                                            F_Batch: result[i].F_Batch,
                                            F_WarehouseId: result[i].F_WarehouseId,
                                            F_ExpiryDate: result[i].F_ExpiryDate,
                                            F_MadeDate: result[i].F_MadeDate,
                                            F_WarehouseName: result[i].F_WarehouseName,
                                            F_Quantity: result[i].F_Quantity,
                                            F_PositionId: result[i].F_PositionId,
                                            F_PositionName: result[i].F_PositionName,
                                        })
                                    }
                                    top.layer.close(index);
                                    form.grid.reload();
                                    $("#F_SourceId").val(gridSelectData.F_EnCode);

                                    form.pageEvent.bindLoadSelect();


                                }
                            });



                        }
                    });


                }
            });
        },
        bindIsAdmin: function () {
            $.ajax({
                url: router + "/IsAdmin",
                success: function (data) {
                    if (data) {
                        IsAdmin = true;
                        if (keyValue) {
                            $("#NF-verify").show();
                            $("#NF-deny").show();
                        }
                    } else {
                        IsAdmin = false;
                    }

                }
            })
        },//判断是否是管理员
        bindRemoveRow: function () {//移除行
            $("#NF-deleteRow").click(function () {
                form.grid.removeRow();
            });
            if (form.grid.localData.length == 0) {
                $("#F_SourceId").val("");
            }
        },
        bindSave: function () {//保存单据
            $("#NF-Save").click(function () {
                form.grid.endEditGrid();
                var _form = $("#form1");
                var data = _form.formSerialize();
                SaveheadId = guid();
                if (keyValue == "") {
                    data.F_Id = SaveheadId;

                }

                var rows = form.grid.localData;
                if (rows.length == 0) {
                    $.modalMsg("至少添加一行数据", "error");

                }
                for (var i = 0; i < rows.length; i++) {
                    if (rows[i].F_ExpiryDate < rows[i].F_MadeDate) {
                        $.modalMsg("失效日期要大于生产日期", "error");
                        return false;
                    }
                }

                $.ajax({
                    url: router + "/Submit",
                    data: {
                        headInfo: data,
                        dInfo: rows
                    },
                    type: 'post',
                    success: function (data) {
                        var result = JSON.parse(data);
                        if (!result.bSuccess) {
                            $.modalMsg(result.message, "error");
                        } else {

                            $("#F_EnCode").val(result.message);
                            if (IsAdmin) {
                                $("#NF-verify").show();
                                $("#NF-deny").show();
                            }
                            $.modalMsg("操作成功", "success");
                            keyValue = SaveheadId;

                        }
                    }
                });
            })
        },
        bindVerify: function () {//审核单据
            $("#NF-verify").click(function () {


                var _form = $("#form1");
                if (!_form.formValid()) {
                    return false;
                }
                if (form.grid.localData.length == 0) {
                    $.modalMsg("请至少输入一条记录!", "error");
                    return false;
                }
                if ($("#F_EnCode").val == "") {
                    $.modalMsg("请保存后再进行审核!", "error");
                    return false;
                }

                $.modalConfirm("注：您确定要审核单据吗？", function (r) {
                    if (r) {
                        $.ajax({
                            url: router + "/VerifyList?keyValue=" + keyValue,
                            success: function (data) {
                                var result = JSON.parse(data);
                                if (result.bSuccess) {
                                    $.modalMsg(result.message, "success");
                                } else {
                                    $.modalMsg(result.message, "error");
                                }
                            }
                        })

                    }
                })

            });
        },
        bindDeny: function () {//弃审单据
            $("#NF-deny").click(function () {
                var _form = $("#form1");
                if (!_form.formValid()) {
                    return false;
                }
                if (form.grid.localData.length == 0) {
                    $.modalMsg("请至少输入一条记录!", "error");
                    return false;
                }

                $.modalConfirm("注：您确定要弃核单据吗？", function (r) {
                    if (r) {


                        $.ajax({
                            url: router + "/OnVerifyList?keyValue=" + keyValue,
                            success: function (data) {
                                var result = JSON.parse(data);
                                if (result.bSuccess) {
                                    $.modalMsg(result.message, "success");
                                } else {
                                    $.modalMsg(result.message, "error");
                                }
                            }
                        })

                    }
                })
            });
        },
        bindsetVisiable: function () {
            if (keyValue) {//新建 
                if (!IsAdmin) {
                    $("#NF-verify").hide();
                    $("#NF-deny").hide();
                    if ($("#F_SourceType").val() == 1) {
                        $("#NF-deleteRow").hide();
                    }

                } else {
                    if ($("#F_SourceType").val() == 1) {
                        $("#NF-deleteRow").hide();
                    }
                    $("#NF-verify").show();
                    $("#NF-deny").show();
                }
            } else {
                $("#NF-verify").hide();
                $("#NF-deny").hide();
                $("#NF-deleteRow").hide();
            }
        },//显示隐藏按钮
        bindLoadSelect: function () {
            form.grid.ele.find('option:selected').select2({
                minimumResultsForSearch: -1
            })
        },//初始化加载所有select
        bindFormData: function (date) {
            var y = date.getFullYear();
            var m = date.getMonth() + 1;
            m = m < 10 ? ('0' + m) : m;
            var d = date.getDate();
            d = d < 10 ? ('0' + d) : d;
            var h = date.getHours();
            var minute = date.getMinutes();
            minute = minute < 10 ? ('0' + minute) : minute;
            var second = date.getSeconds();
            second = minute < 10 ? ('0' + second) : second;
            return y + '-' + m + '-' + d + ' ' + h + ':' + minute + ':' + second;

        },//日期的转换
        bindprintBarcode: function () {
            $.modalOpen({
                id: "Print",
                title: "捡货单打印",
                url: "/Print/Index?fileName=packListB&sourceName=printPackList&sourceData=" + keyValue,
                width: "800px",
                height: "550px",
                btn: null
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
            onSelectRow: function (Id) {
                if ($("#F_SourceType").val() == 0) {
                    form.grid.ele.jqGrid('editRow', Id, false);

                }
            },
            height: ($(window).height() - $('.topPanel').height() - 55) < 0 ? 200 : ($(window).height() - $('.topPanel').height() - 55),
            colModel: [
                { label: "主键", name: "F_Id", hidden: true, key: true },
                { label: '产品编码', name: 'F_ProductCode', width: 100, align: 'left' },
                { label: '产品名称', name: 'F_ProductName', width: 120, align: 'left' },
                { label: '规格型号', name: 'F_ProductStandard', width: 100, align: 'left' },
                {
                    label: '批次号', name: 'F_Batch', width: 100, align: 'left', sortable: false, editable: true,
                    //batchedit: true, batcheditopts: {//批设设置
                    //    title: "批次号",
                    //    inputmodel: "input",
                    //    inputFiled: "F_Batch",
                    //    callback: 'form.grid.batchEdit'
                    //}
                },
                {
                    label: '出库数量', name: 'F_Quantity', width: 100, align: 'left', editable: true, editrules: {
                        //校验只可以为数字
                        number: true
                    }//, batchedit: true, batcheditopts: {//批设设置
                    //    title: "入库数量",
                    //    inputmodel: "input",
                    //    inputFiled: "F_Quantity",
                    //    callback: 'form.grid.batchEdit'
                    //}
                },
                {
                    label: '出库仓库', name: 'F_WarehouseId', index: 'F_WarehouseId', editable: true, edittype: 'select', width: 150, editoptions: { value: GetWars() }, sortable: false,

                },
                {
                    label: '出库货位', name: 'F_PositionId', index: 'F_PositionName', editable: true, edittype: 'select', editoptions: { value: GePositions() }, width: 150, sortable: false,

                },
                {
                    label: '生产日期', name: 'F_MadeDate', width: 150, align: 'left', editable: true, editoptions: {
                        dataInit: function (el) {
                            $(el).click(function () {
                                WdatePicker();
                            })
                        }

                    }, formatter: function (cellvalue) {
                        if (cellvalue == "1900-01-01 00:00:00") {
                            return ''
                        }
                        return cellvalue;
                    }
                }, {
                    label: '失效日期', name: 'F_ExpiryDate', width: 150, align: 'left', editable: true, editoptions: {
                        dataInit: function (el) {
                            $(el).click(function () {
                                WdatePicker();
                            })
                        }

                    }, formatter: function (cellvalue) {
                        if (cellvalue == "1900-01-01 00:00:00") {
                            return ''
                        }
                        return cellvalue;
                    }
                },


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
        removeAll: function () {//删除所有行
            var _this = this;
            for (var i = 0; i < _this.localData.length; i++) {
                _this.localData.removeRow(this.localData[i]);
            }
            if (_this.localData.length == 0) {
                $("#F_SourceId").val("");
            }

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
            if (_this.localData.length == 0) {
                $("#F_SourceId").val("");
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
                        if ($("#F_SourceType").val() == 1) {
                            $("#" + $(_this.ele.getCell(gridRows[i].F_Id, 'F_Batch')).attr('id')).attr('disabled', true)
                            $("#" + $(_this.ele.getCell(gridRows[i].F_Id, 'F_Quantity')).attr('id')).attr('disabled', true)
                            $("#" + $(_this.ele.getCell(gridRows[i].F_Id, 'F_WarehouseId')).attr('id')).attr('disabled', true)
                            $("#" + $(_this.ele.getCell(gridRows[i].F_Id, 'F_PositionId')).attr('id')).attr('disabled', true)
                            $("#" + $(_this.ele.getCell(gridRows[i].F_Id, 'F_MadeDate')).attr('id')).attr('disabled', true)
                            $("#" + $(_this.ele.getCell(gridRows[i].F_Id, 'F_ExpiryDate')).attr('id')).attr('disabled', true)

                        } else {
                            if (_this.localData[j].F_ProdcuntBatchManagement == "false") {
                                $("#" + $(_this.ele.getCell(gridRows[i].F_Id, 'F_Batch')).attr('id')).attr('disabled', true)
                            }
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
                _this.ele.jqGrid('editRow', gridRowIds[i], false);

                //更改数据源,此处需要根据编辑项自己更改

                for (var j = 0; j < _this.localData.length; j++) {
                    if (_this.localData[j].F_Id == gridRowIds[i]) {
                        _this.localData[j].F_Batch = $("#" + gridRowIds[i] + "_F_Batch").val();
                        _this.localData[j].F_Quantity = $("#" + gridRowIds[i] + "_F_Quantity").val();
                        _this.localData[j].F_PositionId = $("#" + gridRowIds[i] + "_F_PositionId").val();
                        _this.localData[j].F_WarehouseId = $("#" + gridRowIds[i] + "_F_WarehouseId").val();
                        _this.localData[j].F_MadeDate = $("#" + gridRowIds[i] + "_F_MadeDate").val();
                        _this.localData[j].F_ExpiryDate = $("#" + gridRowIds[i] + "_F_ExpiryDate").val();
                        break;
                    }
                }
                _this.ele.jqGrid('saveRow', gridRowIds[i], false);

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
};

function GetWars() {
    //动态生成select内容 
    var str = "";
    $.ajax({
        async: false,
        url: router + "/GetWarSelectJson",
        success: function (data) {//通过后台获取到到数据源
            if (data != null) {//如果不为空，就循环遍历数据源
                var rows = eval(data);
                for (var i = 0; i < rows.length; i++) {
                    if (i != rows.length - 1) {
                        str += rows[i].F_Id + ":" + rows[i].F_FullName + ";";
                    } else {
                        str += rows[i].F_Id + ":" + rows[i].F_FullName;// 这里是option里面的 value:label ,我的是Id，text
                    }
                }
            } else {
                str = "0" + ':' + "暂无仓库可选择" + ';';

            }
        }
    });
    return str;
}
function GePositions() {
    //动态生成select内容 
    var str = "";
    $.ajax({
        async: false,
        url: router + "/GetPositonSelectJson",
        success: function (data) {//通过后台获取到到数据源
            if (data != null) {//如果不为空，就循环遍历数据源
                var rows = eval(data);
                for (var i = 0; i < rows.length; i++) {
                    if (i != rows.length - 1) {
                        str += rows[i].F_Id + ":" + rows[i].F_FullName + ";";
                    } else {
                        str += rows[i].F_Id + ":" + rows[i].F_FullName;// 这里是option里面的 value:label ,我的是Id，text
                    }
                }
            } else {
                str = "0" + ':' + "暂无货位可选择" + ';';
            }
        }
    });
    return str;
}
