var router = "/SystemSecurity/FilterIP";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function initControl() {
        $("#F_Type").bindSelect();
    },
    doBeforeSubmit:function()
    {
        var StartIP = $("#F_StartIP").val();
        var EndIP = $("#F_EndIP").val();
        if (compareIP(StartIP, EndIP) == -1) {
            $.modalMsg("不在同一个网段内");
            return false;
        }
        if (compareIP(StartIP, EndIP) == 0) {
            $.modalMsg("结束IP不能大于开始IP");
            return false;
        }
        return true;
    }
}

//初始化窗体
InitForm(router, formSetting);


function compareIP(ipBegin, ipEnd) {
    var temp1 = ipBegin.split(".");
    var temp2 = ipEnd.split(".");
    if ((temp1[0] + temp1[1] + temp1[2]) == (temp2[0] + temp2[1] + temp2[2])) {
        if (temp2[3] >= temp1[3]) {
            return 1;
        } else {
            return 0;
        }
    } else {
        return -1;//不在同一个网段内
    }
} 