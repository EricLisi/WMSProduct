var router = "/WmsManage/Suppliers",                            //当前页面路由 
    $pageEvents = {
        doBeforeInit: function () {
            $('#layout').css("height", $(window).height() + "px")
            $('#layout').layout();
            treeView();
            return true;
        }
    },
     searchSetting = {                                           //查询设置
         setPostData: function () {
             return { keyword: $("#txt_keyword").val() + "|" + $("#itemTree").getCurrentNode().id, searchFiled: "F_FullName|F_SperCategoryId" };
         }
     },
    gridSetting = {                                             //列表设置对象
        treegrid:false,//是否属性结构 
        ExpandColumn: "F_EnCode",
        searchActionUrl: '/WmsManage/Suppliers/GetGridJsonEmptyIfNull',//查询API
        multiselect: true,//复选框
        colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: '供应商名称', name: 'F_FullName', width: 150, align: 'left' },
            { label: '供应商编码', name: 'F_EnCode', width: 100, align: 'left' },
            { label: '联系人', name: 'F_Contacts', width: 100, align: 'left' },
            { label: '电话', name: 'F_TelePhone', width: 100, align: 'left' },
             { label: '传真', name: 'F_Fax', width: 250, align: 'left' },
            { label: '微信', name: 'F_WeChat', width: 100, align: 'left' },
            { label: '地址', name: 'F_Address', width: 250, align: 'left' },
            { label: '备注', name: 'F_Description', width: 200, align: 'left' },
 
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "供应商",//模块名 
        Width: "750px",//宽
        Height: "430px",//高
        doBeforeAdd: function () {
            if ($("#itemTree").getCurrentNode() == null || $("#itemTree").getCurrentNode() == undefined) {
                alert("请先选择供应商分类");
                return false;
            }
            var itemId = $("#itemTree").getCurrentNode().id;
            var itemName = $("#itemTree").getCurrentNode().text;
            if (!itemId) {
                return false;
            }
            $formSetting.formPrefix = itemName + "》";
            $formSetting.addParms = "?itemId=" + itemId;
            return true;
        },
        doBeforeEdit: function () {
            var itemId = $("#itemTree").getCurrentNode().id;
            var itemName = $("#itemTree").getCurrentNode().text;
            if (!itemId) {
                return false;
            }

            $formSetting.formPrefix = itemName + "》";
            $formSetting.editParms = "&itemId=" + itemId;
            return true;
        },
    };


InitPage(router, searchSetting, gridSetting, formSetting);

function btn_itemstype() {
    $.modalOpen({
        id: "ItemsType",
        title: "供应商分类",
        url: "/WmsManage/SperCategory/Index",
        width: "800px",
        height: "550px",
        btn: null,
    });
}

function treeView() {
    $("#itemTree").treeview({
        url: "/WmsManage/SperCategory/GetTreeJson",
        onnodeclick: function (item) {
            $("#txt_keyword").val('');
            $('#btn_search').trigger("click");
        }
    });
}

/*
    导出Excel
*/
function ExportExcel1(options) {
    console.info(options);
    options.searchId = $searchId;
    options.parmlist = [{ Key: "type", Value: "type" }, { Key: "cDepCode", Value: "cDepCode" }]
    console.log(options);
    FileOper.ExportExcel(options)
}