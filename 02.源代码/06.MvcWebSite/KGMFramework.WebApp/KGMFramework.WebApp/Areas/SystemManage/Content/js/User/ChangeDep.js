var router = "/SystemManage/User",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            var kword = $("#txt_keyword").val();
            var org = $("#F_OrganizeS").val()
            var word = "";
            var filed = "";
            if (kword != "" && org != "") {
                word += kword + "|" + org
                filed = "F_RealName|F_OrganizeId/F_DepartmentId"
            } else if (kword != "") {
                word = kword
                filed = "F_RealName"
            } else if (org != "") {
                word = org
                filed = "F_OrganizeId/F_DepartmentId"
            }

            return { keyword: word, searchFiled: filed };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构  
        searchActionUrl: router + '/GetGridJsonPagination',//查询API
        pager: "#gridPager",//分页控件 
        multiselect: true,//复选框
        viewrecords: true,//显示记录  
        height: "290",
        colModel: [
            { label: '主键', name: 'F_Id', hidden: true, key: true },
             { label: '账户', name: 'F_Account', width: 120, align: 'left', hidden: true },
            { label: '姓名', name: 'F_RealName', width: 120, align: 'left' },
            { label: '公司', name: 'F_CompanyName', width: 250, align: 'left' },
            { label: '部门', name: 'F_DepartmentName', width: 250, align: 'left' }
        ]//grid的显示列 
    },
    event = {
        doAfterInit: function () {
            $("#F_OrganizeId").bindSelect({
                url: "/SystemManage/Organize/GetTreeSelectJson"
            });
            $("#F_OrganizeS").bindSelect({
                url: "/SystemManage/Organize/GetTreeSelectJson"
            });
        }
    };


InitPage(router, searchSetting, gridSetting, undefined, event);


//关闭按钮
function btn_close() {
    $.modalClose();
}

//提交
function submitForm1() {
    if ($("#F_OrganizeId").val() == "") {
        $.modalMsg("公司/部门不允许为空", "error");
        return false;
    }
    var grid = $("#gridList");
    var selectId = grid.jqGrid("getGridParam", "selrow");//选择行的ID 
    if (selectId == null || selectId == undefined) {
        $.modalMsg("请选中一行", "error");
        return false;
    }

    var rows = grid.jqGridRowValue()
    var codes = [];
    for (var i = 0; i < rows.length; i++) {
        codes.push(rows[i].F_Account);
    }


    $.modalConfirm("注：您确定要将选中的用户变更部门吗？", function (r) {
        if (r) {
            $.submitForm({
                url: "/SystemManage/User/ChangeDepartment",
                param: { list: codes, deptId: $("#F_OrganizeId").val() },
                success: function (result) {
                    if (result.state == 'success') {
                        $.modalMsg("操作成功", "success");
                        $.currentWindow().$("#gridList").trigger("reloadGrid");
                    } else {
                        $.modalAlert(result.message, "error");
                    }
                }
            })
        }
    });
}