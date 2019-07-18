var router = "/SystemManage/User";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        $("#F_Gender").bindSelect()
        $("#F_IsAdministrator").bindSelect()
        $("#F_EnabledMark").bindSelect()
        $("#F_OrganizeId").bindSelect({
            url: "/SystemManage/Organize/GetTreeSelectJson"
        });
        $("#F_DepartmentId").bindSelect({
            url: "/SystemManage/Organize/GetTreeSelectJson",
        });
        $("#F_RoleId").bindSelect({
            url: "/SystemManage/Role/GetGridJson",
            id: "F_Id",
            text: "F_FullName"
        });
        $("#F_DutyId").bindSelect({
            url: "/SystemManage/Duty/GetGridJson",
            id: "F_Id",
            text: "F_FullName"
        });
    }
}

//初始化窗体
InitForm(router, formSetting);

function ChangePwd() {
    var keyValue = $.request("keyValue");
    var Account = $("#F_Account").val();
    var RealName = $("#F_RealName").val();
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
 