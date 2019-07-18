var router = "/WmsManage/SrType",                            //当前页面路由  
      searchSetting = {                                           //查询设置
          setPostData: function () {
              return { keyword: $("#txt_keyword").val(), searchFiled: "F_FullName/F_EnCode" };
          },
      },
     gridSetting = {                                             //列表设置对象
         treegrid: false,//是否属性结构  
         searchActionUrl: router + '/GetGridJsonPagination',//查询API
         colModel: [
             { label: "主键", name: "F_Id", hidden: true, key: true },
             { label: '编号', name: 'F_EnCode', width: 100, align: 'left' },
             { label: '名称', name: 'F_FullName', width: 100, align: 'left' },
             { label: '备注', name: 'F_Description', width: 150, align: 'left' },
         ]//grid的显示列 
     },
    formSetting = {                                             //Form设置对象
        moduleName: "收发类别",//模块名 
        Width: "600px",//宽
        Height: "300px"//高
    };



InitPage(router, searchSetting, gridSetting, formSetting);