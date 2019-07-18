var router = "/SystemManage/Role";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        $("#F_OrganizeId").bindSelect({
            url: "/SystemManage/Organize/GetTreeSelectJson",
        });
        $("#F_Type").bindSelect({
            url: "/SystemManage/ItemsData/GetSelectJsonByType",
            param: { type: "RoleType" }
        });
        $('#wizard').wizard().on('change', function (e, data) {
            var $finish = $("#btn_finish");
            var $next = $("#btn_next");
            if (data.direction == "next") {
                switch (data.step) {
                    case 1:
                        if (!$('#form1').formValid()) {
                            return false;
                        }
                        $finish.show();
                        $next.hide();
                        break;
                    default:
                        break;
                }
            } else {
                $finish.hide();
                $next.show();
            }
        });
        $("#permissionTree").treeview({
            height: 460,
            showcheck: true,
            url: "/SystemManage/Role/GetPermissionTree",
            param: { roleId: $.request("keyValue") }
        });
    }
}

//初始化窗体
InitForm(router, formSetting);

//关闭按钮
function btn_close() {
    $.modalClose();
}

//提交
function submitForm1() {
    var dataOptions = [];//自己添加的函数
    dataOptions.push({ parmKey: "info", parmValue: $formSetting.form.formSerialize() });
    dataOptions.push({ parmKey: "permissionIds", parmValue: String($("#permissionTree").getCheckedNodes()) })
    submitFormMuti(dataOptions)
}