var keyValue = $.request('keyValue');
var router = "/SystemManage/Rule";    //当前页面路由,'
var ruleDetailEntityList = [];//表体对象的集合

//自己的初始化事件
formSetting = {
    initFormEvent: function initControl() {
        $("#F_Type").bindSelect({
        }),
        //给表体集合赋值
        getRuleEntityList(keyValue);
        //渲染grid
        InitGrid();
    },

}

//获取已经存在的子表集合
function getRuleEntityList(keyValue) {
    if (keyValue) {
        //ajax读取
        $.ajax({
            url: '/SystemManage/RuleDeatil/GetFormJson1?keyValue=' + keyValue,
            dataType: "json",
            async: false,
            success: function (data) {
                ruleDetailEntityList = data;
            }
        });
    }
    else {
        ruleDetailEntityList = [];
    }
}
//渲染datagrid
function InitGrid() {
    $("#gridData").dataGrid({
        treeGrid: false,
        datatype: "local",//读取JSON数据
        data: ruleDetailEntityList,
        height: 200,
        editable: true,
        colModel: [
             { label: "主键", name: "F_Id", hidden: true, key: true },
               {
                   label: '编码', name: 'F_EnCode', width: 80, align: 'center'
               },
             {
                 label: '名称', name: 'F_FullName', width: 100, align: 'center'
             },

             {
                 label: '类型', name: 'F_Type', width: 100, align: 'center',
                 formatter: function (cellvalue, options, rowObject) {
                     if (cellvalue == 0) {
                         return '文本';
                     }
                     else if (cellvalue == 1) {
                         return '数字';
                     }
                     else {
                         return '时间';
                     }
                 }
             },
             { label: '对应U8表', name: 'F_Table', width: 100, align: 'center' },
             {
                 label: '实际值', name: 'F_ValueFiled', width: 100, align: 'center', hidden: true
             },
              {
                  label: '显示值', name: 'F_DisplayFiled', width: 100, align: 'center', hidden: true
              },

             {
                 label: '长度', name: 'F_Length', width: 100, align: 'center',

             },

             { label: '备注', name: 'F_Description', width: 100, align: 'center' },
              {
                  label: '排序号', name: 'F_SortCode', width: 80, align: 'center',
              },

              {
                  label: '解析标识', name: 'F_AnalyzeMark', width: 100, align: 'center', hidden: true
              },

              {
                  label: '过滤条件', name: 'F_Condition', width: 100, align: 'center', hidden: true
              },
              {
                  label: '自动生成规则', name: 'F_GenerateMark', width: 100, align: 'center', hidden: true
              },
              {
                  label: '生成规则', name: 'F_GenerateRule', width: 100, align: 'center', hidden: true
              },
              {
                  label: '生成格式', name: 'F_GenerateFormatter', width: 100, align: 'center', hidden: true
              },
             {
                 label: '名称', name: 'F_GenerateFormatter', width: 100, align: 'center', hidden: true
             },
            {
                label: '生成长度', name: 'F_GenerateLength', width: 100, align: 'center', hidden: true
            },
            {
                label: '外键', name: 'F_ParentId', width: 100, align: 'center', hidden: true
            },


        ],
        sortname: "F_SortCode",
    });
}


//关闭窗口
function btn_close() {
    $.modalClose();
}



//初始化窗体
InitForm(router, formSetting);




//提交
function submitMuti() {
    var dataOptions = [];//自己添加的函数
    dataOptions.push({ parmKey: "info", parmValue: $formSetting.form.formSerialize() });
    dataOptions.push({ parmKey: "dInfo", parmValue: JSON.stringify(ruleDetailEntityList) })
    submitFormMuti(dataOptions)
}

//分隔符选项
var isSelect = true;
function Sel_Change() {
    var keyValue = $.request('keyValue');
    if (!isSelect) {
        $.modalConfirm("注：会清空数据，是否要选择？", function (r) {
            if (r) {
                $.ajax({
                    url: "/SystemManage/RuleDeatil/DeleteForm2?keyValue=" + keyValue,
                    type: "get",
                    dataType: "json",
                    success: function (data) {
                        if (data) {
                            $.modalMsg("清空完毕！", "success");
                            $.currentWindow().$("#gridData").trigger("reloadGrid");
                        }
                    }
                });
            }
        });
    }
    isSelect = false;
}


//删除子表规则
function btn_delDetail() {
    var selectedRows = $("#gridData").jqGrid("getGridParam", "selrow");
    if (selectedRows == null || selectedRows == undefined) {
        $.modalMsg("请至少选中一行", "error");
        return false;
    }
    else {
        $.ajax({
            url: "/SystemManage/RuleDeatil/DeleteFrom1",
            data: { keyValue: selectedRows },
            type: "get",
            dataType: "json",
            success: function (data) {
                if (data) {
                    $.modalMsg("删除成功！", "success");
                    $.currentWindow().$("#gridData").trigger("reloadGrid");
                }
            }
        })
    }
}


//新增编辑子规则事件
function btn_SaveRuleDetail(bEdit) {
    //验证表头输入合法性 
    if (!$formSetting.form.formValid()) {
        return false;
    }
    var selectedId, selectedRows;//声明两变量接收选中的iD和行数据；
    if (bEdit) {
        selectedId = $("#gridData").jqGrid("getGridParam", "selrow");//选择行的ID
        selectedRows = $("#gridData").jqGrid("getRowData", selectedId);//选择行的数据 
        if (selectedId == null || selectedId == undefined) {
            $.modalMsg("请至少选中一行", "error");
            return false;
        }
        //修改
        $.modalOpen({
            id: "editRuleDetail",
            title: "修改子规则",
            url: "/SystemManage/RuleDeatil/Form?keyValue=" + selectedId,
            width: "850px",
            height: "600px",
            callBack: function (iframeId) {
                // 获取弹出窗里录入的信息
                var detailForm = $(top.frames[iframeId].document).find("#form1");//弹出窗内的表单
                var ruleDetailEntity = detailForm.formSerialize();//表单序列化对象
                //判断规则名称是否已经存在
                //获取gridData中的所有行数据
                var obj = $("#gridData").jqGrid("getRowData");//获取所有行的数据
                for (var i = 0; i < obj.length; i++) {
                    if (selectedId == obj[i].F_Id) {
                        ruleDetailEntityList.splice(i, 1);
                    }
                    if (ruleDetailEntity.F_FullName == obj[i].F_FullName) {
                        $.modalMsg("重复数据,请重新输入", "error");
                        return;
                    }
                }
                // 将录入的信息 添加到表格内
                // 先将对象添加到列表集合内
                ruleDetailEntityList.push(ruleDetailEntity);
                // 将列表结合绑定的到表格内
                $("#gridData").trigger("reloadGrid");
            }
        });

    }
    //新增
    $.modalOpen({
        id: "editRuleDetail",
        title: "子规则",
        url: "/SystemManage/RuleDeatil/Form?keyValue=" + selectedId,
        width: "850px",
        height: "600px",
        callBack: function (iframeId) {
            // 获取弹出窗里录入的信息
            var detailForm = $(top.frames[iframeId].document).find("#form1");//弹出窗内的表单
            var ruleDetailEntity = detailForm.formSerialize();//表单序列化对象
            alert(JSON.stringify(ruleDetailEntity));
            //判断规则名称是否已经存在
            //获取gridData中的所有行数据
            var obj = $("#gridData").jqGrid("getRowData");//获取所有行的数据
            for (var i = 0; i < obj.length; i++) {
                if (ruleDetailEntity.F_FullName == obj[i].F_FullName) {
                    $.modalMsg("重复数据,请重新输入", "error");
                    return;
                }
            }
            // 将录入的信息 添加到表格内
            // 先将对象添加到列表集合内
            ruleDetailEntityList.push(ruleDetailEntity);
            // 将列表结合绑定的到表格内
            $("#gridData").trigger("reloadGrid");
        }
    });
}



