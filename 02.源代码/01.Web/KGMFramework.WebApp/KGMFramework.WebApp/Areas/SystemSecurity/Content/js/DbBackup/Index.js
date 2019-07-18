var router = "/SystemSecurity/DbBackup",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_DbName/F_FileName" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构
        searchActionUrl: router + '/GetGridJsonPagination',//查询API
        colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: '数据库名', name: 'F_DbName', width: 100, align: 'left' },
            { label: '备份名称', name: 'F_FileName', width: 200, align: 'left' },
            { label: '大小', name: 'F_FileSize', width: 100, align: 'left' },
            {
                label: '备份模式', name: 'F_BackupType', width: 100, align: 'left',
                formatter: function (cellvalue) {
                    if (cellvalue == "1") {
                        return "完整备份";
                    } else if (cellvalue == "2") {
                        return "差异备份";
                    }
                }
            },
            {
                label: '备份时间', name: 'F_CreatorTime', width: 100, align: 'left',
                formatter: "date", formatoptions: { srcformat: 'Y-m-d H:i', newformat: 'Y-m-d H:i' }
            },
            { label: '备份人员', name: 'F_CreatorUserId', width: 100, align: 'left' },
            { label: '备份说明', name: 'F_Description', width: 300, align: 'left' }
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "备份",//模块名 
        Width: "450px",//宽
        Height: "360px"//高
    };


InitPage(router, searchSetting, gridSetting, formSetting);

function btn_download() {
    var keyValue = $("#gridList").jqGridRowValue().F_Id;
    $.download("/SystemSecurity/DbBackup/DownloadBackup", "keyValue=" + keyValue, 'post');
}