var router = "/AssetManage/Received",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "F_EnCode/F_GroupCode" };
        }
    
    },

    //自己的初始化事件
formSetting = {
    initFormEvent: function initControl() {
        //渲染datagrid列表
        InitGrid();
        //初始化数据列表信息

    },
};
   
    //formSetting = {                                             //Form设置对象
    //    moduleName: "入库",//模块名 
    //    Width: "900px",//宽
    //    Height: "700px"//高
    //};


InitForm(router, searchSetting, formSetting);



