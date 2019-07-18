var router = "/SystemManage/VouchTypeSetting",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_FullName/F_EnCode" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: true,//是否属性结构 
        ExpandColumn: "F_EnCode",//按照编码分类
        searchActionUrl: router + '/GetTreeGridJson',//查询API
        colModel: [
            { label: "主键", name: "F_Id", hidden: true, key: true },
            { label: '名称', name: 'F_FullName', width: 200, align: 'left' },
            { label: '编码', name: 'F_EnCode', width: 100, align: 'left' },
            { label: '出入库类型', name: 'F_InoutType', width: 100, align: 'center',
            formatter: function (cellvalue, options, rowObject) {
                //if (cellvalue ==2)
                //{
                //     return '';
                //}
                if(cellvalue==0){
                    return '出库';
                }
                else
                {
                    return '入库';
                }
               }
            },
            { label: '来源表', name: 'F_SourceTable', width: 100, align: 'left' },
            { label: '业务类型前缀', name: 'F_Prefix', width: 100, align: 'left' },
            {
                label: '来源类型', name: 'F_Source', width: 100, align: 'left',
                formatter: function (cellvalue) {
                    return top.clients.dataItems["1015"][cellvalue] == undefined ? "" : top.clients.dataItems["1015"][cellvalue]
                }
            }
        ]//grid的显示列 
    },
    formSetting = {                                             //Form设置对象
        moduleName: "业务类型",//模块名 
        Width: "700px",//宽
        Height: "460px",//高 ，
        addBtn: null,//隐藏按钮
        editBtn: null
    };

InitPage(router, searchSetting, gridSetting, formSetting);
