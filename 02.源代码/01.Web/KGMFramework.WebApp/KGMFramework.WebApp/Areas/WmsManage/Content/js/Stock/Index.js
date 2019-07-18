var keyValue = $.request('keyValue');//选中行

var router = "/WmsManage/Stock",                            //当前页面路由 
    searchSetting = {                                           //查询设置
        setPostData: function () {
            return { keyword: $("#txt_keyword").val(), searchFiled: "GOODSNAME/WHNAME" };
        }
    },
    gridSetting = {                                             //列表设置对象
        treegrid: false,//是否属性结构 
        pager: "#gridPager",//分页控件
        viewrecords: true,//显示记录  
        searchActionUrl: router + '/GetGridJsonPagination?sortFiled= F_BATCH ',//查询API
        colModel: [
            { label: "主键", name: "F_ID", hidden: true, key: true },
            { label: '仓库编码', name: 'WHCODE', width: 100, align: 'left' },
            { label: '仓库名称', name: 'WHNAME', width: 100, align: 'left' },
            { label: '仓位编码', name: 'POSCODE', width: 100, align: 'left' },
            { label: '仓位名称', name: 'POSNAME', width: 100, align: 'left' },
            { label: '产品名称', name: 'GOODSID', width: 100, align: 'left', hidden: true },
            { label: '产品编码', name: 'GOODSCODE', width: 100, align: 'left' },
            { label: '产品名称', name: 'GOODSNAME', width: 100, align: 'left' },
            { label: '批号', name: 'F_BATCH', width: 100, align: 'left' },
            { label: '库存数量', name: 'F_NUMBER', width: 100, align: 'right' },
            { label: '单位', name: 'F_UNIT', width: 100, align: 'left' },
            
            { label: '规格型号', name: 'F_SPECIFMODEL', width: 100, align: 'left' },
            {
                label: '采购价格', name: 'F_SellingPrice', width: 120, align: 'right',
                formatter: 'currency', formatoptions: { thousandsSeparator: ",", decimalSeparator: ".", prefix: "￥" }
            },

            { label: '备注', name: 'F_Description', width: 300, align: 'left' }
        ]//grid的显示列 
    },
    formSetting = {//Form设置对象
        moduleName: "库存",//模块名 
        Width: "650px",//宽
        Height: "500px"//高
    };


InitPage(router, searchSetting, gridSetting, formSetting);
function btn_transfer() {
    var modalOpts = {
        id: "saveAssetDetail",
        title: "物品转移",
        url: "/WmsManage/Stock/Form?keyValue=" + keyValue,
        width: "600px",
        height: "500px"
    } 

    modalOpts.title = "物品转移"
    //模型绑定
    modalOpts.success = function (layero, index, layer) {
        var body = layer.getChildFrame('body', index);//建立父子联系 
        var _form = body.find("#form1");
        var data = $("#gridList").jqGridRowValue();//取当前选中的数据 
        console.info(data);
        if (data.length) {
            _form.formSerialize(data[0]);//赋值 
            body.find("#select2-F_AssetType-container").html(data[0]["F_AssetTypeName"]).attr('title', data[0]["F_AssetTypeName"])
        } else {
            _form.formSerialize(data);//赋值
            body.find("#select2-F_AssetType-container").html(data["F_AssetTypeName"]).attr('title', data["F_AssetTypeName"])
        }

      
    },
      modalOpts.callBack = function (iframeId, index) {
          var _form = $(top.frames[iframeId].document).find("#form1");
          var data = _form.formSerialize();
          $.ajax({
              url: router + '/transferSaves',
              data: data,
              success: function (data) {
                  if (data=="转移成功") {
                      $.modalMsg(data, "success");
                      modalOpts.clos
                  } else {
                      $.modalMsg(data, "error");
                      modalOpts.clos
                  }
              }
          })
          //$.modalOpen(modalOpts);
          //Grid().reload();
          data.F_Id = guid();
          bodyData.push(data);

          Grid().reload();
      }
    $.modalOpen(modalOpts);
}

function ExportExcel1(options) {
    options.searchId = $searchId;
    options.parmlist = [{ Key: "type", Value: "type" }, { Key: "cDepCode", Value: "cDepCode" }]
    console.log(options);
    FileOper.ExportExcel(options)
}