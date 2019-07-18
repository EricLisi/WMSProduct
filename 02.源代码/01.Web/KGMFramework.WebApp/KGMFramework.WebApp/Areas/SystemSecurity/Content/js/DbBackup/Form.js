var router = "/SystemSecurity/DbBackup";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function initControl() {
        $("#F_DbName").bindSelect()
        $("#F_BackupType").bindSelect()
    }
}

//初始化窗体
InitForm(router, formSetting);

 