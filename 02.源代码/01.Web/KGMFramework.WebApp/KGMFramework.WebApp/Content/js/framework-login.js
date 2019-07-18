$(function () {
    $("#login").val("登录").removeAttr("disabled");
    $("#clr").hide();
    $("#show").hide();
    $("#username").bind('input propertychange', function () {
        if ($(this).val() == "") {
            $("#clr").hide();
        }
        else {
            $("#clr").show();
        }
    })

    $("#clr").click(function () {
        $("#username").val("");
        $("#username").focus();
        $("#clr").hide();
    });

    $("#password").bind('input propertychange', function () {
        if ($(this).val() == "") {
            $("#show").hide();
        }
        else {
            $("#show").show();
        }
    })

    $("#show").click(function () {
        if ($("#password").attr('type') == "password") {
            $("#password").attr('type', "text");

            $(this).removeClass("glyphicon glyphicon-eye-close");
            $(this).addClass("glyphicon glyphicon-eye-open");

        } else {
            $("#password").attr('type', "password");
            $(this).removeClass("glyphicon glyphicon-eye-open");
            $(this).addClass("glyphicon glyphicon-eye-close");
        }

    });
})
//登录点击事件
$('#login').click(function () {
    login();
})
//登录的keydown事件
function loginDown(e) {
    var code = e.charCode || e.keyCode;
    if (code != 13) {
        return true;
    }
    login();
}
//登录
function login() {
    $("#loginInfo").html("");
    $("#login").val("登陆中，请稍后...").attr('disabled', "true");
    $.ajax({
        url: "/Account/LoginSystem",
        data: { username: $("#username").val(), password: $("#password").val() },
        type: "post",
        dataType: "json",
        success: function (data) {
            if (data.Success) {
                $("#login").val("登录成功，正在跳转...").attr('disabled', "true");
                window.setTimeout(function () {
                    window.location.href = "/Home/Index";
                }, 500);
            } else {
                $("#loginInfo").html("登录失败，原因:" + data.ErrorMessage);
                $("#login").val("登录").removeAttr("disabled");
            }
        }
    });
}


//调用外部api
//$("#loginInfo").html("");
//$("#login").val("登陆中，请稍后...").attr('disabled', "true");
//$.ajax({
//    url: "api/Auth/GetUserToken",  //"/Account/LoginSystem",
//    data: {
//        Account: $("#username").val(),
//        Password: $("#password").val(),
//        LoginSystem: 0
//    },//{ username: $("#username").val(), password: $("#password").val() },
//    type: "post",
//    dataType: "json",
//    success: function (data) {
//        if (data.result) {
//            $("#login").val("登录成功，正在跳转...").attr('disabled', "true");
//            window.setTimeout(function () {
//                window.location.href = "/Home/Index";
//            }, 500);
//        } else {
//            $("#loginInfo").html("登录失败，原因:" + data.message);
//            $("#login").val("登录").removeAttr("disabled");
//        }
//    },
//    error: function () {
//        alert(2)
//    }
//});
