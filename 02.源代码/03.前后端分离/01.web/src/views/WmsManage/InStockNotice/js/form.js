var router = "InStockNotice";
var datas = [];
(function($, app) {
	"use strict";
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	
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
			// 客户选择
			$("#CustomerId").appselect({
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
			$("#Maker").val(app.APP_GLOBE_STORE.LOGIN_USER.FullName);

			//选择物料信息
			$('#select').on('click', function() {
//				console.log($("#Type").text())
				if($("#Type").text()=="")
				{
					app.MODAL_UTILS.error("请选择入库类别")
					return false;
				}
				layx.iframe('iconForm', '选择物料信息...', '../html/addForm.html', {
					shadable: true,
					statusBar: true, 
					width: 1050,
					height: 450,
					buttons: [{
							label: '<i class="fa fa-save" style="margin-right:5px"></i>确定',
							callback: function(id, button, event) {
								// 获取 iframe 页面 window对象
								var contentWindow = layx.getFrameContext(id);
								contentWindow.acceptClick();
								var win = layx.getFrameContext('iconForm', 'group2');
								var grid=win.document.querySelector(".pp").innerHTML;
//								console.log(JSON.parse(grid))
								var data=JSON.parse(grid);
								if(data.length==0)
								{
									app.MODAL_UTILS.warning("请选择一行数据")
									return false;
								}
								//将选中的数据赋值到下方列表中
								for(var i=0;i<data.length;i++)
								{
									var param = {
											"ProductId": data[i].Id,
											"ProductCode": data[i].EnCode,
											"ProductName": data[i].FullName,
											"InvSKU": data[i].InvSKU,
											"CustomerCode": data[i].CustomerCode,
											"Price": data[i].Price,
											"Quantity":1,
												};
									$("#productgird").appGridSet('addRow',param);
								}
								if($("#Type").val()==0){
//									$("#productgird").initEditCell($('#productgird'), headData, "BoxNo");
								}
								layx.destroy(id);
							},
							classes: ['btn-primary']
						},
						{
							label: '<i class="fa fa-close" style="margin-right:5px"></i>取消',
							callback: function(id, button, event) {
								layx.destroy(id);
							},
							classes: ['btn-danger']
						}
					]
				});
			});
			
			//选择全部商品，表格加载选中的商品信息
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
						align: 'center',
						edit: {
							type: 'input',
							init: function(data, $edit) { // 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象
//								if($("#Type").val()==0)
//								{
//									edit=false
//								}
							},
						}
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
						align: "center",
						edit: {
							type: 'select',
							init: function(data, $edit) { // 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象
							},
							change: function(row, num, item) { // 行数据和行号,下拉框选中数据

							},
							op: { // 下拉框设置参数 和 appselect一致
								url:'/api/Position/GetSelectGrid',
								text: 'Text',
								value: 'Id',
								allowSearch: true
//								data: [{
//										'id': '1',
//										'text': '货位一'
//									},
//									{
//										'id': '2',
//										'text': '货位二'
//									},
//									{
//										'id': '3',
//										'text': '货位三'
//									},
//									{
//										'id': '4',
//										'text': '货位四'
//									}
//								]
							}
						}
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
				app.MODAL_UTILS.confirm({
						msg: "您确认要保存此操作吗？",
						callback: function() {
							acceptClick();
						}
				});
				
			});
		},

		/*初始化表单数据*/
		InitForm: function() {
			$("#Maker").val(app.APP_GLOBE_STORE.LOGIN_USER.FullName);
			$("#Date").val(app.BASE_UTILS.Date.get_yyyy_MM_dd());
			if(!!keyValue) {
				//				var data = {
				//					"orderData": {
				//						"OrderId": "3587a099-980d-4342-864f-a9f48e90e03b",
				//						"CustomerId": "27607392-c60c-4ee6-9557-ef59f9410bbb",
				//						"SellerId": "1fc0e985-1373-4adc-b3a7-f68b89093f1c",
				//						"OrderDate": "2017-08-11 00:00:00",
				//						"OrderCode": "SO0811000002",
				//						"DiscountSum": 0.00,
				//						"Accounts": 100.00,
				//						"ReceivedAmount": 1000.00,
				//						"PaymentDate": "2017-08-11 00:00:00",
				//						"PaymentMode": "1",
				//						"PaymentState": 2,
				//						"SaleCost": 0.00,
				//						"AbstractInfo": null,
				//						"ContractCode": null,
				//						"ContractFile": "76c2bd72-9d9c-05c2-9bb9-cccdb30b4751",
				//						"SortCode": null,
				//						"DeleteMark": null,
				//						"EnabledMark": null,
				//						"Description": null,
				//						"CreateDate": "2018-04-03 16:34:26",
				//						"CreateUserId": null,
				//						"CreateUserName": "徐晓悦",
				//						"ModifyDate": null,
				//						"ModifyUserId": null,
				//						"ModifyUserName": null
				//					},
				//					"orderProductData": [{
				//						"OrderEntryId": "6540273d-4a68-4ee0-96bf-96cb5df909f9",
				//						"OrderId": "3587a099-980d-4342-864f-a9f48e90e03b",
				//						"ProductId": null,
				//						"ProductCode": "lr-2014-h",
				//						"ProductName": "企业豪华版",
				//						"UnitId": null,
				//						"Qty": 1.00,
				//						"Price": 100.00,
				//						"Amount": 100.00,
				//						"Taxprice": 100.00,
				//						"TaxRate": 0.00,
				//						"Tax": 0.00,
				//						"TaxAmount": 100.00,
				//						"SortCode": null,
				//						"DeleteMark": null,
				//						"EnabledMark": null,
				//						"Description": "33333333333",
				//						"date": "2017-01-01",
				//						"date2": "2018-01-01",
				//						"select": "1"
				//					}]
				//				};
				//				$(".app-layout-wrap").appSetFormData(data.orderData)
				//				$('#productgird').appGridSet('refreshdata', data.orderProductData);

			}

						if(!!keyValue) {
							$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
								$('#form1').appSetFormData(data.info);
								$('#productgird').appGridSet('refreshdata', data.dInfo);
							});
						}
		},

	}
	
	
	// 保存数据
	var acceptClick = function() {
		if(!$('.app-layout-wrap').appValidform()) {
			return false;
		}
		var formData = $('#form1').appGetFormData(keyValue);
		var productData = [];
		var productDataTmp = $('.aa').appGridGet('rowdatas');
//		alert(JSON.stringify(productDataTmp))
//		for(var i = 0, l = productDataTmp.length; i < l; i++) {
//			if(!!productDataTmp[i]['ProductName']) {
//				productData.push(productDataTmp[i]);
//			}
//		}
		var postData = {
			info: formData,
			dInfo: productDataTmp
		};
//		alert(JSON.stringify(postData))
		var postUrl = '/api/' + router;
		var type = "POST";
		if(!!keyValue) {
			postUrl = postUrl + "/" + keyValue;
			type = "PUT"
		}
		$.appSaveForm(type, postUrl, postData, function(data) {

		});
		
//		learun.layerConfirm('注：您确认要保存此操作吗？', function (res, index) {
//		    if (res) {
//		        $.lrSaveForm(top.$.rootUrl + '/LR_CRMModule/CrmOrder/SaveForm?keyValue=' + keyValue, postData, function (res) {
//		            if (res.code == 200) {
//		                if (type == 0) {
//		                    window.location.href = top.$.rootUrl + '/LR_CRMModule/CrmOrder/Form';
//		                }
//		                else {
//		                    learun.frameTab.close('order_add');
//		                }
//		            }
//		        });
//		        top.layer.close(index); //再执行关闭  
//		    }
//		});
	};
	
	
	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)