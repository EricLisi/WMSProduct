var router = "/WmsManage/Warehouse",                            //当前页面路由  
     pageEvents = {
         doBeforeInit: function () {//设置默认值、控件初始化

             $("#F_EnabledMark").select2({
                 minimumResultsForSearch: -1
             });

             $(".dropdown-menu").click(function (e) {
                 e.stopPropagation();
             })
             $('.toolbar').authorizeButton()
             return true;
         }
     },
    searchSetting = {                                           //查询设置
        setPostData: function () {
            var paramlist = {
                F_EnCode: $("#F_EnCode").val(),
                F_FullName: $("#F_FullName").val(),
                F_EnabledMark: $("#F_EnabledMark").val(),

            }

            return { filterStr: JSON.stringify(paramlist) };
        },
        doAfterSearch: function () {
            //关闭当前搜索框
            $("#btndropmenu").trigger('click')
        }
    },
     gridSetting = {                                             //列表设置对象
         treegrid: false,//是否属性结构  
         searchActionUrl: router + '/GetListGridJsonPagination',//查询API
         colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },

            { label: '编号', name: 'F_EnCode', width: 100, align: 'left' },
             { label: '名称', name: 'F_FullName', width: 100, align: 'left' },
             { label: '联系人', name: 'F_Contacts', width: 100, align: 'left' },
             { label: '邮箱', name: 'F_Email', width: 100, align: 'left' },
             { label: '微信', name: 'F_WeChat', width: 100, align: 'left' },
             { label: '传真', name: 'F_Fax', width: 100, align: 'left' },
             { label: '地址', name: 'F_Address', width: 150, align: 'left' },
             { label: '电话', name: 'F_TelePhone', width: 100, align: 'left' },
            //{
            //    label: '创建时间', name: 'F_CreatorTime', width: 150, align: 'left', formatter: function (cellvalue) {
            //        if (cellvalue == "1900-01-01 00:00:00") {
            //            return ''
            //        }
            //        return cellvalue;
            //    }
            //},
             {

                 label: '仓库状态', name: 'F_EnabledMark', width: 100, align: 'left', formatter: function (cellvalue) {

                     var rvalue = '<span class="label label-primary" style="font-size:14px">启用</span>'
                     switch (cellvalue) {
                         case true:
                             rvalue = '<span class="label label-success" style="font-size:14px">启用</span>'
                             break;
                         case false:
                             rvalue = '<span class="label label-danger" style="font-size:14px">禁用</span>'
                             break;
                     }
                     return rvalue;
                 }
             },
             {

                 label: '启用货位', name: 'F_PositionManagement', width: 100, align: 'left', formatter: function (cellvalue) {

                     var rvalue = '<span class="label label-primary" style="font-size:14px">启用</span>'
                     switch (cellvalue) {
                         case true:
                             rvalue = '<span class="label label-success" style="font-size:14px">启用</span>'
                             break;
                         case false:
                             rvalue = '<span class="label label-danger" style="font-size:14px">禁用</span>'
                             break;
                     }
                     return rvalue;
                 }
             },
            { label: '备注', name: 'F_Description', width: 150, align: 'left' },
         ]//grid的显示列 
     },
    formSetting = {                                             //Form设置对象
        //moduleName: "仓库",//模块名 
        //Width: top.$(window).width() + "px",//宽
        //Height: top.$(window).height() + "px",//高 
        moduleName: "仓库",//模块名 
        Width: "768px",//宽
        Height: "480px",//高
        doBeforeDelete: function () {//删除之前
            var selectId = $('#gridList').jqGrid('getGridParam', 'selrow');
            if (selectId == null) {
                $.modalMsg("请选中一行", "error");
                return false;
            }
            $.ajax({
                url: router + '/beDeletFrom',
                data: {
                    KeyValue: selectId

                },
                success: function (data) {
                    var result = JSON.parse(data);
                    if (!result.bSuccess) {
                        $.modalMsg(result.message, "error");
                        return false;
                    }
                }
            });
            return true;
        },

    };


InitPage(router, searchSetting, gridSetting, formSetting, pageEvents);

function btn_WarStatus() {
    var selectId = $('#gridList').jqGrid('getGridParam', 'selrow');//获取选中行
    if (selectId == null) {//判断是否选中
        $.modalMsg("请选中一行", "error");
        return false;
    }
    $.ajax({//更改状态
        url: router + '/UpEnMark',
        data: {
            Id: selectId,
            Type: 0//0是更改仓库，1是更改货位
        },
        success: function (data) {//返回信息
            var result = JSON.parse(data);
            if (!result.bSuccess) {
                $.modalMsg(result.message, "error");
                //$.modalMsg(result.message, "success");
            }

            jQuery("#gridList").trigger("reloadGrid");//重新加载
        }
    })
}
function btn_PoStatus() {
    var selectId = $('#gridList').jqGrid('getGridParam', 'selrow');
    if (selectId == null) {
        $.modalMsg("请选中一行", "error");
        return false;
    }
    $.ajax({
        url: router + '/UpEnMark',
        data: {
            Id: selectId,
            Type: 1//0是更改仓库，1是更改货位
        },
        success: function (data) { //返回状态
            var result = JSON.parse(data);
            if (!result.bSuccess) {
                $.modalMsg(result.message, "error");
                //$.modalMsg(result.message, "success");
            }
            jQuery("#gridList").trigger("reloadGrid");//重新加载

        }
    })
}