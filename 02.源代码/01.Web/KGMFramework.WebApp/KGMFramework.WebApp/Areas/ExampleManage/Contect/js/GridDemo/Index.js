var router = "/SystemManage/User",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_Account/F_RealName/F_MobilePhone", list: null };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构  
        //multiselect: true,//多选
        searchActionUrl: router + '/GetGridJsonPagination',//查询API
        //bCellEdit: true,//直接单元格编辑
        colModel: [
            { label: '主键', name: 'F_Id', hidden: true, key: true },
            { label: '账户', name: 'F_Account', width: 80, align: 'left', editable: true },
            { label: '姓名', name: 'F_RealName', width: 80, align: 'left', editable: true },
            {
                label: '性别', name: 'F_Gender', width: 60, align: 'center', editable: true,
                edittype: "select", editoptions: { value: "true:男;false:女" },
                formatter: function (cellvalue, options, rowObject) {
                    if (cellvalue == true) {
                        return '男';
                    } else {
                        return '女';
                    }
                }
            },
            { label: '手机', name: 'F_MobilePhone', width: 80, align: 'left', editable: true },
            {
                label: '公司', name: 'F_OrganizeId', width: 150, align: 'left', editable: true,
                edittype: 'custom', editoptions: { custom_element: myelem, custom_value: myvalue },
                formatter: function (cellvalue, options, rowObject) {
                    return top.clients.organize[cellvalue] == null ? "" : top.clients.organize[cellvalue].fullname;
                }
            },
            {
                label: '部门', name: 'F_DepartmentId', width: 80, align: 'left', editable: true,
                formatter: function (cellvalue, options, rowObject) {
                    return top.clients.organize[cellvalue] == null ? "" : top.clients.organize[cellvalue].fullname;
                }
            },
            {
                label: '岗位', name: 'F_DutyId', width: 80, align: 'left', editable: true,
                formatter: function (cellvalue, options, rowObject) {
                    return top.clients.duty[cellvalue] == null ? "" : top.clients.duty[cellvalue].fullname;
                }
            },
            {
                label: '创建时间', name: 'F_CreatorTime', width: 80, align: 'left',
                formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
            },
            {
                label: "允许登录", name: "F_EnabledMark", width: 60, align: "center", editable: true,
                edittype: "checkbox", editoptions: { value: "1:0" },
                formatter: function (cellvalue, options, rowObject) {
                    if (cellvalue == 1) {
                        return '<span class=\"label label-success\">正常</span>';
                    } else if (cellvalue == 0) {
                        return '<span class=\"label label-default\">禁用</span>';
                    }
                }
            },
            { label: '备注', name: 'F_Description', width: 200, align: 'left', editable: true }
        ]//grid的显示列 
    }


//带按钮的文本框
function myelem(value, options) {
    var el = document.createElement("div");
    el.className = "input-group";
    var html = ' <input type="text" class="form-control" style="width:100px;float:left;margin-top:-30px;" readonly = true value=' + value + '"> ' +
                        '<button type="button" class="btn  btn-primary" style = "float:left;margin-top:-28px;" onclick="getCorp(this)"><i class="fa fa-search"></i></button> ' //+
    el.innerHTML = html;
    //alert(el.innerHTML)
    return el;
};

function myvalue(elem, operation, value) {
    //alert("myvalue: "+value);
    if (operation === 'get') {
        return $(elem).val();
    } else if (operation === 'set') {
        $(elem).val(value);
    }
};

InitPage(router, searchSetting, gridSetting);

function getCorp(obj) {
    $.modalOpen({
        id: "getCorp",
        title: '选择公司',
        url: '/SystemManage/Organize/Form?keyValue=',
        width: "450px",
        height: "260px",
        callBack: function (iframeId) {

        }
    });
}

var selectRowId = undefined;//选中行
function beginEdit() {
    var selectedRows = $("#gridList").jqGridRowValue();
    if (gridSetting.multiselect) {
        for (var i = 0; i < selectedRows.length; i++) {
            var selectedId = selectedRows[i].F_Id;
            if (selectedId) {
                $("#gridList").jqGrid('editRow', selectedId, true);
            }
        }
    }
    else {
        var selectedId = selectedRows.F_Id;
        if (selectedId) {
            $("#gridList").jqGrid('editRow', selectedId, true);
        }
    }
}

function endEdit() {
    var selectedRows = $("#gridList").jqGridRowValue();
    alert(JSON.stringify(selectedRows))
    if (gridSetting.multiselect) {
        for (var i = 0; i < selectedRows.length; i++) {
            var selectedId = selectedRows[i].F_Id;
            if (selectedId) {
                $("#gridList").jqGrid('saveRow', selectedId);
            }
        }
    }
    else {
        var selectedId = selectedRows.F_Id;
        if (selectedId) {
            $("#gridList").jqGrid('saveRow', selectedId);
        }
    }
}

function HightSearch(gridList) {
    $.modalOpen({
        id: "getCorp",
        title: '高级查询',
        url: '/Utility/GridSearch?gridId=' + gridList + '&router=' + router,
        width: "800px",
        height: "500px",
        btn: null
    });
}