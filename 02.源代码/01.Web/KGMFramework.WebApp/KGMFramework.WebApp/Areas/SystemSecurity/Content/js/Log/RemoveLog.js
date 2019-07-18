function submitForm() {
    if (!$('#form1').formValid()) {
        return false;
    }
    $.submitForm({
        loading: "正在清除数据...",
        url: "/SystemSecurity/Log/SubmitRemoveLog",
        param: $("#form1").formSerialize(),
        success: function () {
            $.currentWindow().$("#gridList").trigger("reloadGrid");
        }
    })
}