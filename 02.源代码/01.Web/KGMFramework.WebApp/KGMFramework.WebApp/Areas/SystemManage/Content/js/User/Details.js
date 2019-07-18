var keyValue = $.request("keyValue");
$(function () {
    initControl();
    $.ajax({
        url: "/SystemManage/User/GetFormJson",
        data: { keyValue: keyValue },
        dataType: "json",
        async: false,
        success: function (data) {
            $("#form1").formSerialize(data);
            $("#form1").find('.form-control,select,input').attr('readonly', 'readonly');
            $("#form1").find('div.ckbox label').attr('for', '');
            $("#F_UserPassword").val("******");
        }
    });
});
function initControl() {
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