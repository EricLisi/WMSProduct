/// <reference path="Form.js" />
var router = "/SystemManage/VouchTypeSetting";    //当前页面路由

//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        $("#F_InoutType").select2({
            minimumResultsForSearch: -1
        });
        $("#F_ParentId").bindSelect({
            url: "/SystemManage/VouchTypeSetting/GetTreeSelectJson",
        });
        //初始化来源类型下拉框
        $("#F_Source").bindSelect({
            url: "/SystemManage/ItemsData/GetSelectJsonByType",
            param: { type: "1015" }
        });
        //初始化默认值
        $("#F_Type").bindSelect({
            url: "/SystemManage/ItemsData/GetSelectJsonByType",
            param: { type: "RoleType" }
        })
    }
    // doBeforeSubmit:   //提交按钮前业务判断事件
    //function () {
    //如果不是父节点判断，判断上级与出入库类型是否一致；如果为父节点不用判断
    //var parent = $("#F_ParentId option:selected").val();//获取上级选中值
    //var type = $("#F_InoutType option:selected").val(); 
    //var b = true;
    //async: false;
    //if (parent != "父节点") {
    //    if (parent != type) {
    //        $.modalMsg("出入库类型必须一致", "error");
    //        b = false;
    //    }
    //    return true;
    //}
    //获取出入库类型选中值
    //return false;
    //var type = $("#F_InoutType option:selected").val()
    //if (F_InoutType != type) {
    //    $.modalMsg("出入库类型必须一致", "error");
    //    return false;
    //}
    //return true;
    //获取选中父节点的出入库类型
    //}

}
//初始化窗体
InitForm(router, formSetting);

//关闭按钮
function btn_close() {
    $.modalClose();
}

//完成提交数据
function submitForm1() {    
    //获取选中父节点
    var parent = $("#F_ParentId option:selected").text();
    if (parent == "父节点") {
        noCheckSubmit();
    }
    else {
        checkSubmit(parent);
    }
}
///不做校验（即选择上级为父节点）
function noCheckSubmit() {
    //如果一致，执行提交表单
    var dataOptions = [];//定义数据变量
    //给变量赋值
    //var dInfoValue = [{ F_EnCode: $("#F_Type").val(), F_FullName: $("#F_Type option:selected").text() }];
    ////alert(JSON.stringify(dInfoValue))
    //dataOptions.push({ parmKey: "dInfo", parmValue: dInfoValue })//传入的变量、值
    dataOptions.push({ parmKey: "info", parmValue: $formSetting.form.formSerialize() });
    dataOptions.push({ parmKey: "dInfo", parmValue: JSON.stringify(ruleDetailEntityList) })
    submitFormMuti(dataOptions)//调用提交数据的方法
}
///上级不为父节点时要判断选择的出入库类型与上级的是否一致
function checkSubmit(parent) {
    $.ajax({
        url: "/SystemManage/VouchTypeSetting/GetTypeByParent?F_FullName=" + parent,//获取父节点的出入库类型
        async: false,
        type: "post",
        dataType: "json",
        success: function (data) {
            if (data == null || data[0] == null) {
                $.modalMsg("未能获取到信息！", "error");
                return false;
            }
            var type = $("#F_InoutType option:selected").val();
            var F_InoutType = data[0].F_InoutType;
            if (F_InoutType != type) {
                $.modalMsg("出入库类型必须一致", "error");
                return false;
            }
            noCheckSubmit();
        }
    })
}

