var router = "/WmsManage/Product",                            //当前页面路由  
    searchSetting = {                                           //查询设置
        setPostData: function () {
            var paramlist = {
                F_EnCode: $("#F_EnCode").val(),
                F_FullName: $("#F_FullName").val(),
            }

            return { filterStr: JSON.stringify(paramlist) };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构  
        multiselect: true,
        searchActionUrl: router + '/GetListGridJsonPagination',//查询API
        colModel: [
           { label: "主键", name: "F_Id", hidden: true, key: true },
           { label: '产品编码', name: 'F_EnCode', width: 100, align: 'left' },
           { label: '产品名称', name: 'F_FullName', width: 100, align: 'left' },
           { label: '简码', name: 'F_ShortCode', width: 100, align: 'left' },
           { label: '简称', name: 'F_ShortName', width: 100, align: 'left' },
           { label: '规格', name: 'F_Standard', width: 100, align: 'left' },
           { label: '品牌', name: 'F_Brand', width: 100, align: 'left' },
           { label: '颜色', name: 'F_Color', width: 100, align: 'left' },
           { label: '长（m）', name: 'F_Length', width: 100, align: 'left' },
           { label: '高（m）', name: 'F_Height', width: 100, align: 'left' },
           { label: '宽（m）', name: 'F_Width', width: 100, align: 'left' },
           { label: '净重（kg）', name: 'F_NetWeight', width: 100, align: 'left' },
           { label: '毛重（kg）', name: 'F_Weight', width: 100, align: 'left' }, 
           { label: '单位', name: 'F_Unit', width: 150, align: 'left' },
           { label: '是否批次管理', name: 'F_BatchManagement', width: 150, align: 'left', hidden: true },
           { label: '是否序列号管理', name: 'F_SnManagement', width: 150, align: 'left', hidden: true },
           { label: '是否效期管理', name: 'F_EffectiveManagement', width: 150, align: 'left', hidden: true },
           {
               label: '创建时间', name: 'F_CreatorTime', width: 150, align: 'left', formatter: function (cellvalue) {
                   if (cellvalue == "1900-01-01 00:00:00") {
                       return ''
                   }
                   return cellvalue;
               }
           }
        ]//grid的显示列 
    };


InitPage(router, searchSetting, gridSetting);