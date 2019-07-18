var router = "/SystemManage/TerminalGridColumn";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        $("#F_ParentId").bindSelect({
            url: "/SystemManage/TerminalGridColumn/GetTreeSelectJson",
        });
    }
}

//初始化窗体
InitForm(router, formSetting);

function SelectIcon() {
    $.modalOpen({
        id: "SelectIcon",
        title: '选取图标-双击图标选择',
        url: '/SystemManage/Module/Icon?ControlId=F_ModuleIcon',
        width: "1100px",
        height: "600px",
        btn: null
    })
}