var router = "InStock";
var datas=[];
(function($, app) {
	"use strict";
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	//来源类型为无来源时。来源单据不可编辑
//	$("#SourceType").change(function() {
//		var SourceType = $("#SourceType").val();
//		//alert(SourceType)
//		if(SourceType == "0") {
//			$('#SourceId').attr('disabled', 'disabled');
//			//$('#SourceId').text("==请选择==")
//		} else {
//			$('#SourceId').removeAttr('disabled', 'disabled')
//		}
//	})
	//来源类型为无来源时,来源单据不可编辑
//	$("#SourceType").change(function() {
//		var SourceType = $("#SourceType").val();
//		if(SourceType == "0") {
//			$('#SourceId').attr('disabled', 'disabled');
//			$('#SourceId').val("");
//			$('#productgird').css('display', 'block');
//			$('#productgird1').css('display', 'none');
//			//先将表格置空
//			$("#productgird").appGridSet('refreshdatas', datas);
//		} else if(SourceType == "1") {
//			$('#SourceId').removeAttr('disabled', 'disabled');
//			$('#productgird').css('display', 'none');
//			$('#productgird1').css('display', 'block');
//			$(".valia").html('来源单据<font face="宋体">*</font>');
//			$('#SourceId').attr('isvalid', 'yes');
//			$('#SourceId').attr('checkexpession', 'NotNull');
//			var SourceId = $('#SourceId').val();
//			if(!SourceId) {				        
//				//先将表格置空
//				$("#productgird1").appGridSet('refreshdatas',datas);
//			}
//		}
//
//	})
	// 保存数据
	var acceptClick = function() {
		if(!$('.app-layout-wrap').appValidform()) {
			return false;
		}
		var formData = $('.app-layout-wrap').appGetFormData(keyValue);
		var productData = [];
		var productDataTmp = $('.aa').appGridGet('rowdatas');
		alert(JSON.stringify(productDataTmp))
		for(var i = 0, l = productDataTmp.length; i < l; i++) {
			if(!!productDataTmp[i]['ProductName']) {
				productData.push(productDataTmp[i]);
			}
		}
		//{
		//	"crmOrderJson": {
		//		"OrderCode ": "SO0811000002 ",
		//		"CreateUserName ": "徐晓悦 ",
		//		"OrderDate ": "2017 - 08 - 11 ",
		//		"CustomerId ": "27607392 - c60c - 4e e6 - 9557 - ef59f9410bbb ",
		//		"SellerId ": "1 fc0e985 - 1373 - 4 adc - b3a7 - f68b89093f1c ",
		//		"EnabledMark ": "false ",
		//		"appgrid_edit_productgird_Amount ": "33 ",
		//		"appgrid_edit_productgird_Taxprice ": "44 ",
		//		"appgrid_edit_productgird_date ": "2018 - 12 - 18 ",
		//		"appgrid_edit_productgird_date2 ": "2018 - 12 - 25 ",
		//		"appgrid_edit_productgird_Qty ": "200 ",
		//		"appgrid_edit_productgird_select ": "3 ",
		//		"appgrid_edit_productgird_Description ": "4444444444444 ",
		//		"Description ": " & nbsp;"
		//	},
		//	"crmOrderProductJson": [{
		//		"OrderEntryId ": "6540273 d - 4 a68 - 4e e0 - 96 bf - 96 cb5df909f9 ",
		//		"OrderId ": "3587 a099 - 980 d - 4342 - 864 f - a9f48e90e03b ",
		//		"ProductId ": null
		//	}, {
		//		"OrderEntryId ": "6540273 d - 4 a68 - 4e e0 - 96 bf - 96 cb5df909f9 ",
		//		"OrderId ": "3587 a099 - 980 d - 4342 - 864 f - a9f48e90e03b ",
		//		"ProductId ": null
		//	}]
		//}
		var postData = {
			crmOrderJson: formData,
			crmOrderProductJson: productData
		};
		alert(JSON.stringify(postData))
		var postUrl = '/api/' + router;
		var type = "POST";
		if(!!keyValue) {
			postUrl = postUrl + "/" + keyValue;
			type = "PUT"
		}
		$.appSaveForm(type, postUrl, postData, function(data) {

		});
		/*learun.layerConfirm('注：您确认要保存此操作吗？', function (res, index) {
		    if (res) {
		        $.lrSaveForm(top.$.rootUrl + '/LR_CRMModule/CrmOrder/SaveForm?keyValue=' + keyValue, postData, function (res) {
		            if (res.code == 200) {
		                if (type == 0) {
		                    window.location.href = top.$.rootUrl + '/LR_CRMModule/CrmOrder/Form';
		                }
		                else {
		                    learun.frameTab.close('order_add');
		                }
		            }
		        });
		        top.layer.close(index); //再执行关闭  
		    }
		});*/
	};

	/**
	 * 页面事件对象
	 */
	var pageEvent = {
		/**
		 *  窗体初始化 
		 **/
		init: function() {
			pageEvent.bindEvent();
			pageEvent.InitForm()
		},

		/**
		 * 绑定事件
		 */
		bindEvent: function() {
			// 优化滚动条
			$('.app-layout-wrap').appscroll();
			$("#CustomId").appselect({
                url:'/api/Customer/GetSelectGrid',
                text: 'Text',
				value: 'Id',
				maxHeight: 180,
				allowSearch: true
           });
			// 仓库
			$("#WarehouseId").appselect({
				url: '/api/Warehouse/GetSelectGrid/'+app.APP_GLOBE_STORE.LOGIN_USER.Id,
				text: 'Text',
				value: 'Id',
				maxHeight: 180,
				allowSearch: true
			});
			//权属
			$('#OwnerId').appselect({
				url: '/api/Owner/GetSelectGrid/',
				text: 'Text',
				value: 'Id',
				maxHeight: 180,
				allowSearch: true
			});
			//入库类别
			$('#Type').appselect();
			//收发类别
			$('#SrTypeId').appselect({
				url: '/api/ReceiveType/GetSelectGrid/',
				text: 'Text',
				value: 'Id',
				maxHeight: 180,
				allowSearch: true
			});
//			$("#Maker").val(app.APP_GLOBE_STORE.LOGIN_USER.FullName);
			//来源类型
			$('#SourceType').appselect();
			//无来源时，选择全部商品，表格加载选中的商品信息
			$('#productgird').appgrid({
				headData: [
					{
						label: '产品Id',
						name: 'ProductId',
						width: 100,
						align: "center"
					},
					{
						label: '产品名称',
						name: 'ProductName',
						width: 150,
						align: "center"
					},
					{
						label: '产品批次',
						name: 'Batch',
						width: 100,
						align: 'center',
						edit: {
							type: 'input',
						}
					},
//					{
//						label: 'sku',
//						name: 'InvSKU',
//						width: 100,
//						align: 'center'
//					},
//					{
//						label: '客户编号',
//						name: 'CustomerCode',
//						width: 100,
//						align: 'center'
//					},
					{
						label: '箱号',
						name: 'BoxNo',
						width: 100,
						align: 'center'
					},
					{
						label: '价格',
						name: 'Price',
						width: 100,
						align: 'center',
						edit: {
							type: 'input'
							}
					},
					{

						label: '数量',
						name: 'Quantity',
						width: 80,
						align: 'center',
						statistics: true
					},
					{

						label: '入库数量',
						name: 'InQty',
						width: 80,
						align: 'center',
						statistics: true,
						edit: {
							type: 'input',
							change: function(row, rownum) { // 行数据和行号
								//								row.Amount = parseInt(parseFloat(row.Price || '0') * parseFloat(row.Qty || '0'));
								//								row.TaxAmount = parseInt((parseFloat(row.Price || '0') * (1 + parseFloat(row.TaxRate || '0') / 100)) * parseFloat(row.Qty || '0'));
								//								row.Tax = row.TaxAmount - row.Amount;
								//								$('#productgird').appGridSet('updateRow', rownum);
							},
						}
					},

					{
						label: '入库货位',
						name: 'PositionId',
						width: 120,
						align: "center"
					}
				],
				isEdit: true,
				height: 550,
				isMultiselect: true
		});

			// 保存数据
			//			$('#savaAndAdd').on('click', function() {
			//				acceptClick(0);
			//			});
			$('#save').on('click', function() {
				acceptClick();
			});

		},

		/*初始化表单数据*/
		InitForm: function() {
			$("#CMaker").val(app.APP_GLOBE_STORE.LOGIN_USER.FullName);
			$("#Date").val(app.BASE_UTILS.Date.get_yyyy_MM_dd());
						if(!!keyValue) {
							$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
								console.log(data.info)
								$("#form1").appSetFormData(data.info)
								for(var i=0;i<data.dInfo.length;i++){
									data.dInfo[i].InQty=1;
								}
								$('#productgird').appGridSet('refreshdata', data.dInfo);
							});
						}
		},

	}
	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)