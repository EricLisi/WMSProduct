var router = "/SystemManage/GridColumn";    //当前页面路由
var init = true;
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        $("#F_ParentId").bindSelect({
            url: "/SystemManage/GridColumn/GetTreeSelectJson",
            change: function () {
                if (!init) {
                    var parent = $("#F_ParentId").find("option:selected").text();
                    if (parent != "父节点") {
                        switchs(false);
                        $("#F_Page").val($("#F_ParentId").find("option:selected").text());
                    } else {
                        switchs(true);
                        $("#F_Page").val("");
                    }
                }
                init = false;
            }
        });
        $("#F_Align").bindSelect({});
    }
}

//初始化窗体
InitForm(router, formSetting);


function switchs(state) {
    $('#F_Label').attr('disabled', state);
    $('#F_Name').attr('disabled', state);
    $('#F_Width').attr('disabled', state);
    $('#F_Align').attr('disabled', state);
    $('#F_SortCode').attr('disabled', state);
    $('#F_Hidden').attr('disabled', state);
    $('#F_Key').attr('disabled', state);
    $('#F_Editable').attr('disabled', state);
    $('#F_Formatter').attr('disabled', state);
    $('#F_Formatoptions').attr('disabled', state);
}