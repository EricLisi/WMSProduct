var router = "/SystemSecurity/Log",                            //当前页面路由 
    pageEvents = {
        doAfterInit: function () {
            $("#time_horizon a.btn-default").click(function () {
                $("#time_horizon a.btn-default").removeClass("active");
                $(this).addClass("active");
                $('#btn_search').trigger("click");
            });
            return true;
        }//共通初始化之后执行
    },
    searchSetting = {                                           //查询设置
        searchEvent: function () {//自定义查询事件 
            $gridList.jqGrid('setGridParam', {
                postData: { keyword: $("#txt_keyword").val(), timeType: $("#time_horizon a.active").attr('data-value') },
            }).trigger('reloadGrid');
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构
        pager: "#gridPager",
        sortname: 'F_Date desc',
        viewrecords: true,
        searchActionUrl: router + '/GetGridJsonInfo',//查询API
        colModel: [
            { label: '主键', name: 'F_Id', hidden: true },
            {
                label: '日期', name: 'F_Date', width: 120, align: 'left',
                formatter: "date", formatoptions: { srcformat: 'Y-m-d H:i:s', newformat: 'Y-m-d H:i:s' }
            },
            { label: '账户', name: 'F_Account', width: 80, align: 'left' },
            { label: '姓名', name: 'F_NickName', width: 80, align: 'left' },
            { label: '操作菜单', name: 'F_ModuleName', width: 100, align: 'left' },
            {
                label: '操作类型', name: 'F_Type', width: 80, align: 'left',
                formatter: function (cellvalue) {
                    return top.clients.dataItems["DbLogType"][cellvalue] == undefined ? "" : top.clients.dataItems["DbLogType"][cellvalue]
                }
            },
            {
                label: 'IP地址', name: 'F_IPAddress', width: 230, align: 'left',
                formatter: function (cellvalue, options, rowObject) {
                    return cellvalue + ";" + rowObject.F_IPAddressName;
                }
            },
            { label: '日志内容', name: 'F_Description', width: 300, align: 'left' }
        ]//grid的显示列 
    }


InitPage(router, searchSetting, gridSetting, null, pageEvents);

function btn_removelog() {
    $.modalOpen({
        id: "removelog",
        title: "清空日志",
        url: "/SystemSecurity/Log/RemoveLog",
        width: "400px",
        height: "180px",
        callBack: function (iframeId) {
            top.frames[iframeId].submitForm();
        }
    });
}