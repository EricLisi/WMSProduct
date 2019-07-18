var router = "/SystemManage/ItemsData",                            //当前页面路由 
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
            return { keyword: $("#txt_keyword").val() + "|" + $("#itemTree").getCurrentNode().id, searchFiled: "F_ItemName|F_ItemId" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构  
        searchActionUrl: router + '/GetGridJsonEmptyIfNull',//查询API
        colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: '名称', name: 'F_ItemName', width: 150, align: 'left' },
            { label: '编号', name: 'F_ItemCode', width: 150, align: 'left' },
            { label: '排序', name: 'F_SortCode', width: 80, align: 'center' },
            {
                label: "默认", name: "F_IsDefault", width: 60, align: "center",
                formatter: function (cellvalue) {
                    return cellvalue == true ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
                }
            },
            {
                label: '创建时间', name: 'F_CreatorTime', width: 80, align: 'left',
                formatter: "date", formatoptions: { srcformat: 'Y-m-d', newformat: 'Y-m-d' }
            },
            {
                label: "有效", name: "F_EnabledMark", width: 60, align: "center",
                formatter: function (cellvalue) {
                    return cellvalue == true ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
                }
            },
            { label: "备注", name: "F_Description", index: "F_Description", width: 200, align: "left", sortable: false }
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "字典",//模块名 
        Width: "450px",//宽
        Height: "430px",//高
        doBeforeAdd: function () {
            if ($("#itemTree").getCurrentNode() == null || $("#itemTree").getCurrentNode() == undefined) {
                alert("请先选择字典分类");
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
        }
    };


InitPage(router, searchSetting, gridSetting, formSetting);

function treeView() {
    $("#itemTree").treeview({
        url: "/SystemManage/ItemsType/GetTreeJson",
        onnodeclick: function (item) {
            $("#txt_keyword").val('');
            $('#btn_search').trigger("click");
        }
    });
}

function btn_itemstype() {
    $.modalOpen({
        id: "ItemsType",
        title: "字典分类",
        url: "/SystemManage/ItemsType/Index",
        width: "800px",
        height: "550px",
        btn: null,
    });
}