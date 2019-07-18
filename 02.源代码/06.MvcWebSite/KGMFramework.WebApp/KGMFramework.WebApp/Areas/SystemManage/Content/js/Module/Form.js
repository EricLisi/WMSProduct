var router = "/SystemManage/Module";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        $("#F_Target").select2({
            minimumResultsForSearch: -1
        });
        $("#F_ParentId").bindSelect({
            url: "/SystemManage/Module/GetTreeSelectJson",
        });
    }
}

//初始化窗体
InitForm(router, formSetting);



//选取图标
function SelectIcon() {
    $.modalOpen({
        id: "SelectIcon",
        title: '选取图标-双击图标选择',
        url: '/SystemManage/Module/Icon?ControlId=F_Icon',
        width: "1100px",
        height: "600px",
        btn: null
    })
}