var router = "/SystemManage/User",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_Account/F_RealName/F_MobilePhone" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构  
        searchActionUrl: router + '/GetGridJsonPagination',//查询API
        pager: "#gridPager",//分页控件
        viewrecords: true,//显示记录  
        colModel: [
            { label: '主键', name: 'F_Id', hidden: true, key: true },
            { label: '账户', name: 'F_Account', width: 80, align: 'left' },
            { label: '姓名', name: 'F_RealName', width: 80, align: 'left' },
            {
                label: '性别', name: 'F_Gender', width: 80, align: 'center',
                formatter: function (cellvalue, options, rowObject) {
                    if (cellvalue == true) {
                        return '男';
                    } else {
                        return '女';
                    }
                }
            },
            { label: '手机', name: 'F_MobilePhone', width: 120, align: 'left' },
            { label: '公司', name: 'F_CompanyName', width: 200, align: 'left' },
            { label: '部门', name: 'F_DepartmentName', width: 150, align: 'left' },
            {
                label: '岗位', name: 'F_DutyId', width: 100, align: 'left',
                formatter: function (cellvalue, options, rowObject) {
                    return top.clients.duty[cellvalue] == null ? "" : top.clients.duty[cellvalue].fullname;
                }
            },
            {
                label: '创建时间', name: 'F_CreatorTime', width: 100, align: 'left',
                formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
            },
            {
                label: "允许登录", name: "F_EnabledMark", width: 60, align: "center",
                formatter: function (cellvalue, options, rowObject) {
                    if (cellvalue == 1) {
                        return '<span class=\"label label-success\">正常</span>';
                    } else if (cellvalue == 0) {
                        return '<span class=\"label label-default\">禁用</span>';
                    }
                }
            },
            { label: '备注', name: 'F_Description', width: 200, align: 'left' }
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "用户",//模块名 
        Width: "768px",//宽
        Height: "510px"//高
    };


InitPage(router, searchSetting, gridSetting, formSetting);

function btn_revisepassword() {
    var keyValue = $("#gridList").jqGridRowValue().F_Id;
    var Account = $("#gridList").jqGridRowValue().F_Account;
    var RealName = $("#gridList").jqGridRowValue().F_RealName;
    $.modalOpen({
        id: "RevisePassword",
        title: '重置密码',
        url: '/SystemManage/User/RevisePassword?keyValue=' + keyValue + "&account=" + escape(Account) + '&realName=' + escape(RealName),
        width: "450px",
        height: "260px",
        callBack: function (iframeId) {
            top.frames[iframeId].submitForm();
        }
    });
}
function btn_disabled() {
    var keyValue = $("#gridList").jqGridRowValue().F_Id;
    $.modalConfirm("注：您确定要【禁用】该项账户吗？", function (r) {
        if (r) {
            $.submitForm({
                url: "/SystemManage/User/DisabledAccount",
                param: { keyValue: keyValue },
                success: function () {
                    $.currentWindow().$("#gridList").trigger("reloadGrid");
                }
            })
        }
    });
}
function btn_enabled() {
    var keyValue = $("#gridList").jqGridRowValue().F_Id;
    $.modalConfirm("注：您确定要【启用/禁止】该项账户吗？", function (r) {
        if (r) {
            $.submitForm({
                url: "/SystemManage/User/EnabledAccount",
                param: { keyValue: keyValue },
                success: function (data) { 
                    $.currentWindow().$("#gridList").trigger("reloadGrid");
                }
            })
        }
    });
}



function btn_changeDep() {
    $.modalOpen({
        id: "changeDep",
        title: '部门批量变更',
        url: '/SystemManage/User/ChangeDep',
        width: "800px",
        height: "500px",
        btn: null
    });
}