var keyValue = $.request('keyValue');//选中行
var type = $.request('type');
var cDepCode = $.request('cDepCode');
var router = "/WmsManage/StockMake";//当前页面路由
var bodyData = [];//表体数据
var searchId = $.request('searchId');

formSetting = {
    initFormEvent: function initControl() { //画面初始化事件 
        $("#F_Date").DefalutDate()
        $("#F_DueDate").DefalutDate()
        Grid().getData().init();
        Document().bindDepartment().setVisiable();
        Mask();
        Statistic();
      //  初始化供应商
        $("#F_WarehouseId").bindSelect({
            url: "/WmsManage/Warehouse/GetSelectJson",
        }).on("select2:select", function () {
            $("#F_CargoPositionId").empty();
            $("#F_CargoPositionId").bindSelect({
                url: "/CargoPosition/GetSelectJson?keyword=" + $("#F_WarehouseId").val() + '&searchFiled=F_WarehouseId',
            });
        })
        $("#F_CargoPositionId").bindSelect({
            url: "/CargoPosition/GetSelectJson?keyword=" + $("#F_WarehouseId").val() + '&searchFiled=F_WarehouseId',
        });
        var warId = localStorage.getItem('WarehouseId');
        var isAdmin = localStorage.getItem('IsAdmin');
        if (isAdmin == "false") {
            $("#F_WarehouseId").val([warId]).trigger("change");
            $("#F_WarehouseId").attr("disabled", "disabled");
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
                $("#btn_verify").hide();
                $("#btn_noverify").hide();
                $("#btn_BeginBathEdit").hide()
            } else if (!!$.request('show')) {//查看
                $("#btn_BeginBathEdit").hide()
                $("#gridList").setGridParam().hideCol("Operating");
                $("#btn_verify").hide();
                $("#btn_save").hide();
                $("#btnImport").hide();
                $("#btn_noverify").hide();
                $("#rowTools").hide();
            } else if (!!$.request('verify') || $.request('verify')==1) {//审核
                $("#btnImport").hide();
                $("#gridList").setGridParam().hideCol("Operating");
                $("#btn_BeginBathEdit").hide();
                $("#btn_save").hide();
                $("#btn_noverify").hide();
                $("#rowTools").hide();
            } else if (!!$.request('verify') || $.request('verify') == 2) {//反审核
                $("#btnImport").hide();
                $("#gridList").setGridParam().hideCol("Operating");
                $("#btn_BeginBathEdit").hide();
                $("#btn_save").hide();
                $("#btn_verify").hide();
                $("#rowTools").hide();
            } else {
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
        add: function () {//添加行 
            if (!Document().bVerify(keyValue)) {
                return false;
            }

            $.modalConfirm("注：您确定要生成盘点单？", function (r, index) {
                if (r) {
                    $.ajax({
                        url: "/WmsManage/StockMake/Generate",
                        type: "post",
                        dataType: "json",
                        data: {
                            cDepCode: $("#F_WarehouseId").val(),
                            range: $("#F_CargoPositionId").val()
                        },
                        async: false,
                        success: function (data) {
                            var rows = $("#gridList").jqGrid("getRowData");
                            for (var i = 0; i < rows.length; i++) {
                                for (var j = 0; j < bodyData.length; j++) {
                                    if (bodyData[j].F_Id == rows[i].F_Id) {
                                        bodyData.splice(j, 1);
                                    }
                                }
                            }

                            for (var i = 0; i < data.data.length; i++) {
                               data.data[i].F_RealNumber = 0;
                                bodyData.push(data.data[i]);
                            }
                            if (data.data.length > 0) {
                                $("#btn_BeginBathEdit").show()
                            }
                            Grid().reload();
                            Statistic();
                            
                            top.layer.close(index);

                        
                        }
                    });
                }
            })
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
            //for (var i = 0; i < bodyData.length; i++) {
            //    if (bodyData[i].F_RealNumber=="") {
            //        $.modalMsg("盘点数量不能为空!", "error");
            //        return false;
            //    }
            //}

            $.modalConfirm("注：您确定要保存单据吗？", function (r) {
                if (r) {
                    var data = _form.formSerialize();
                    data.F_Id = keyValue;
                    data.F_WarehouseName = $("#F_WarehouseId").find("option:selected").text();
                    data.F_CargoPositionName = $("#F_CargoPositionId").find("option:selected").text();
                    data.dInfo = bodyData;

                    $.submitForm({
                        url: router + "/SubmitFormMuti",
                        param: data,
                        success: function (result) {
                            console.info(result);
                            if (result.state == 'success') {
                                keyValue = result.data.F_Id
                                $("#F_EnCode").val(result.data.F_EnCode)
                            } else {
                                $.modalMsg(result.message, "error");
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
            var info;
            $.ajax({
                url: router + "/GetFormJson?keyValue=" + keyValue,
                type: "get",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data) {
                        if (data.F_Status > 0) {
                            $.modalMsg("当前单据已审核", "error");
                            info = "false";
                        }

                    }
                }
            });
            if (info == "false") {
                return false;
            }
            $.modalConfirm("注：您确定要审核单据吗？", function (r) {
                if (r) {
                    var data = _form.formSerialize();
                    data.orderId = keyValue;
                    data.info = bodyData;
                    data.orderUserId = $("#F_Operator").val()
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
            }
            //显示操作列
            $("#gridList").setGridParam().showCol("Operating");
            //判断盘点数和实盘数的大小更改样式
            var ids = $("#gridList").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                var row = $("#gridList").jqGrid('getRowData', ids[i]);
                if (parseInt(row.F_Number) > parseInt(row.F_RealNumber)) {
                    $("tr#" + ids[i]).removeClass("Min").removeClass("Max").addClass("Min");
                } else if (parseInt(row.F_Number) < parseInt(row.F_RealNumber)) {
                    $("tr#" + ids[i]).removeClass("Min").removeClass("Max").addClass("Max");
                } else {
                    $("tr#" + ids[i]).removeClass("Min").removeClass("Max")
                }

            }
            Statistic();
        },
        CancelEdit: function (_this) {
            //显示批量操作，隐藏取消编辑，隐藏批量保存
            $(_this).prev().prev().show();
            $(_this).hide();
            $(_this).prev().hide();
            //退出编辑状态
            var ids = $("#gridList").jqGrid('getDataIDs');
            for (var i = 0; i < ids.length; i++) {
                //$("#gridList").restoreRow("'" + ids[i] + "'");
                $('#gridList').jqGrid('restoreRow', ids[i]);
            } 
     
            //显示操作列
            $("#gridList").setGridParam().showCol("Operating");
        },

    }
}
//单行编辑
function beginEdit(_this) {
    //隐藏批量操作，显示取消编辑，显示批量保存
    $(_this).next().show();
    $(_this).next().next().show();
    $(_this).hide();
    var id = _this.parentNode.parentNode.id;
    $("#gridList").jqGrid('editRow', id, true);

}
//单行保存
function endEdit(_this) {
    //显示批量操作，隐藏取消编辑，隐藏批量保存
    $(_this).prev().show();
    $(_this).hide();
    $(_this).next().hide();
    var id = _this.parentNode.parentNode.id;
    $("#gridList").jqGrid('saveRow', id);
    var row = $("#gridList").jqGrid('getRowData', id);

    if (parseInt(row.F_Number) > parseInt(row.F_RealNumber)) {
        $("tr#" + id).removeClass("Min").removeClass("Max").addClass("Min");
    } else if (parseInt(row.F_Number) < parseInt(row.F_RealNumber)) {
        $("tr#" + id).removeClass("Min").removeClass("Max").addClass("Max");
    } else {
        $("tr#" + id).removeClass("Min").removeClass("Max")
    }

    Statistic();
}
//统计
function Statistic() {

    var ids = jQuery("#gridList").jqGrid("getDataIDs");//得到jqgrid当前行数 
    var Zsum = 0; var Csum = 0; var Psum = 0;
    for (var i = 0; i < ids.length; i++) {
        var row = $("#gridList").jqGrid('getRowData', ids[i]);
        Zsum += row.F_Number * row.F_SellingPrice;
        Psum += row.F_RealNumber * row.F_SellingPrice;
    };
    var Zcount = $("#gridList").getCol('F_Number', false, 'sum');
    var Pcount = $("#gridList").getCol('F_RealNumber', false, 'sum');
    var Ccount = Math.abs(Zcount - Pcount);
    Csum = Math.abs(Zsum - Psum);
    $("#gridList").footerData('set', {
        F_Batch: '账面合计数量：',
        F_GoodsName: Zcount,
        F_Number: "账面合计金额：",
        F_RealNumber: Zsum,
        F_SellingPrice: '实盘合计数量：',
        F_Unit:'实盘合计数量：'+ Pcount,
        F_WarehouseName: "实盘合计金额：",
        F_CargoPositionName: Psum
    });


}
//文件打印
function printBarcode() {
    console.info(bodyData);
    $.ajax({
        url: '/WmsManage/StockMake/AddPrintData',
        type: "post",
        data: {
            MaskList: bodyData
        },
        success: function () {

        }
    })

    var grid = $("#gridList");
    var rows = bodyData;

    var codes = "";
    for (var i = 0; i < rows.length; i++) {
        codes += rows[i].F_EnCode + ","
    }
    codes = codes.substring(0, codes.length - 1)
    console.info(codes);
    $.modalOpen({
        id: "Print",
        title: "条码打印",
        url: "/Print/Index?fileName=demo&sourceName=PrintMask&sourceData=" + escape(codes),
        width: "700px",
        height: "500px",
        btn: null
    });
}
//文件导出
function ExportExcel1(options) {


    options.parmlist = [{ Key: "type", Value: type }, { Key: "cDepCode", Value: cDepCode }];
    FileOper.ExportExcel(options)
}

function Mask() {

    var ids = $("#gridList").jqGrid('getDataIDs');
    for (var i = 0; i < ids.length; i++) {
        var row = $("#gridList").jqGrid('getRowData', ids[i]);
        if (parseInt(row.F_Number) > parseInt(row.F_RealNumber)) {
            $("tr#" + ids[i]).removeClass("Min").removeClass("Max").addClass("Min");
        } else if (parseInt(row.F_Number) < parseInt(row.F_RealNumber)) {
            $("tr#" + ids[i]).removeClass("Min").removeClass("Max").addClass("Max");
        } else {
            $("tr#" + ids[i]).removeClass("Min").removeClass("Max")
        }

    }
}
/**
    *  列表对象
    */
var Grid = function () {
    var height = window.screen.availHeight;
    var formHeight = $("#filterTable").height()
    height = (height - formHeight - 370) * 0.97;

    var ele = $("#gridList");
    return {
        getData: function () {
            if (keyValue) {
                $.ajax({
                    url: '/WmsManage/StockMake/GetFormJson1?keyValue=' + keyValue,
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
                   { label: '主键', name: 'F_Id', hidden: true, key: true },
                    //{
                    //    label: "操作", name: 'Operating', width: 70, formatter: function (cellvalue, options, rowObject) {
                    //        return "<span class='btn btn-primary edit'  onclick='return beginEdit(this)'><i class='fa fa-edit'></i></span>" +
                    //                   "<span class='btn btn-danger finish' onclick='return endEdit(this)' style='display:none' ><i class='fa fa-check'></i></span>"
                    //    }
                    //},
                    { label: '产品编码', name: 'F_GoodsId', width: 160, align: 'left', hidden: true },
                     //{ label: '产品批次', name: 'F_Batch', width: 200, align: 'left' },
                { label: '批次', name: 'F_Batch', width: 100, align: 'left' },
                { label: '产品编码', name: 'F_GoodsCode', width: 100, align: 'left' },
                    { label: '产品名称', name: 'F_GoodsName', width: 100, align: 'left' },

                      { label: '账面数量', name: 'F_Number', width: 100, align: 'left' },

                     {
                         label: '实盘数量', name: 'F_RealNumber', index: 'F_RealNumber', width: 100,
                         //sortable: false, editable: true, edittype: 'text', editrules: {
                         //    custom: true, custom_func: function (value, colname) {
                         //        var re = /^[0-9]+.?[0-9]*$/; //判断字符串是否为数字 //判断正整数 /^[1-9]+[0-9]*]*$/ 
                         //        if (!re.test(value)) {

                         //            return [];
                         //        } else {
                         //            return ["数量必须为正整数"];
                         //        }

                         //    },
                         //},

                     },
            {
                label: '销售价格', name: 'F_SellingPrice', width: 100, align: 'right',
                formatter: 'currency', formatoptions: { thousandsSeparator: ",", decimalSeparator: ".", prefix: "￥" },hidden:true
            },
                      { label: '单位', name: 'F_Unit', width: 130, align: 'left' },
                  { label: "仓库编号", name: "F_WarehouseId", width: 100, align: 'left', hidden: true },
                    { label: '货位编号', name: 'F_CargoPositionId', width: 100, align: 'left', hidden: true },
                    { label: "所属仓库", name: "F_WarehouseName", width: 100, align: 'left' },
                    { label: '所属货位', name: 'F_CargoPositionName', width: 100, align: 'left' },
                    // { label: "生产日期", name: "F_ProDate", width: 100, align: 'left' },
                    //{ label: '失效日期', name: 'F_ExpiratDate', width: 100, align: 'left' },
                    //{ label: '单位', name: 'F_Unit', width: 100, align: 'left' },
                    //{ label: '规格型号', name: 'F_SpecifModel', width: 100, align: 'left' },
                    { label: "自定义项1", name: "F_Cdefine1", width: 100, align: 'left', hidden: true },
                    { label: "自定义项2", name: "F_Cdefine2", width: 100, align: 'left', hidden: true },
                    { label: "自定义项3", name: "F_Cdefine3", width: 100, align: 'left', hidden: true },
                    { label: "自定义项4", name: "F_Cdefine4", width: 100, align: 'left', hidden: true },
                    { label: "自定义项5", name: "F_Cdefine5", width: 100, align: 'left', hidden: true },
                    { label: "自定义项6", name: "F_Cdefine6", width: 100, align: 'left', hidden: true },
                    { label: "自定义项7", name: "F_Cdefine7", width: 100, align: 'left', hidden: true },
                    { label: "自定义项8", name: "F_Cdefine8", width: 100, align: 'left', hidden: true },
                    { label: "自定义项9", name: "F_Cdefine9", width: 100, align: 'left', hidden: true },
                    { label: "自定义项10", name: "F_Cdefine10", width: 100, align: 'left', hidden: true },
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
                multiselect: false,
                footerrow: true,
                //获取总金额总数量
                gridComplete: Statistic(),
                colModel: _this.getGridColumns(),
                afterEditCell: function (rowid, cellname, value, iRow, iCol) {
                    alert(333);
                    $("#" + iRow + "_" + cellname).blur(function (e) {//绑定可编辑单元格的失去焦点事件
                        //  $("#gridList").jqGrid("saveCell", iRow, iCol);
                        $("#gridList").jqGrid('setGridParam', { cellEdit: false });
                    });
                },



            });

            return Grid();
        },
        reload: function () {
            ele.jqGrid('setGridParam', {
                data: bodyData
            }).trigger('reloadGrid');
            return Grid();
        },
    }
    function myvalue(elem, operation, value) {
        if (operation === 'get') {
            return $(elem).val();
        } else if (operation === 'set') {
            $(elem).val(value);
        }
    };

}

