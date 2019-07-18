var router = "OutStockDiff";
var datas = [];
(function($, app) {
	"use strict";
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	var show = app.URL_REQUEST_UTILS.get(window.location, 'show');

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
			$('#form1').appscroll();
			//仓库
			$("#WarehouseId").appselect({
				url: '/api/Warehouse/GetSelectGrid/' + app.APP_GLOBE_STORE.LOGIN_USER.Id,
				text: 'Text',
				value: 'Id'
			});
			$("#WarehouseId").appselectSet(app.APP_GLOBE_STORE.LOGIN_USER.Warehoseid);
			//客户
			$("#CustomerId").appselect({
				url: '/api/Customer/GetSelectGrid',
				text: 'Text',
				value: 'Id'
			}).on("change", function(e) {
				//alert($("#CustomerId").appselectGet('value'));
				var cusid = $("#CustomerId").appselectGet('value');
				app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Customer/' + cusid, function(data) {
					$("#Property").val(data.Ownership)
				});
			});
			//确认差异 差异下架
			$('#app_Shelf').on('click', function() {
				var param = {
					"Id": keyValue,
					"type": 0
				};
				app.MODAL_UTILS.confirm({
					msg: "是否确认差异信息,单据差异下架？",
					callback: function() {
						layx.load('loadId', '请稍后');
						app.HTTP_REQUEST_UTILS.httpAsyncPost('/api/OutStockDiff/DoneDiffenece', param, function(data) {
							layx.destroy('loadId');
							if(data.status) {
								app.MODAL_UTILS.success(data.message);
							} else {
								app.MODAL_UTILS.error(data.message)
							}
							
						});
					}
				})
			});
			//继续发货
			$('#app_Arrival').on('click', function() {
				var datas = {
					"Id": keyValue,
					"type": 1
				};
				app.MODAL_UTILS.confirm({
					msg: "是否不确认差异信息,继续下架？",
					callback: function() {
						layx.load('loadId', '请稍后');
						app.HTTP_REQUEST_UTILS.httpAsyncPost('/api/OutStockDiff/DoneDiffenece', datas, function(data) {
							layx.destroy('loadId');
							if(data.status) {
								app.MODAL_UTILS.success(data.message);
							} else {
								app.MODAL_UTILS.error(data.message)
							}
							
						});
					}
				})
			});
			//重新发货扫描
			$('#app_Redo').on('click', function() {
				var para = {
					"Id": keyValue,
					"type": 2
				};
				app.MODAL_UTILS.confirm({
					msg: "是否不确认差异信息,重新下架？",
					callback: function() {
						layx.load('loadId', '请稍后');
						app.HTTP_REQUEST_UTILS.httpAsyncPost('/api/OutStockDiff/DoneDiffenece', para, function(data) {
							layx.destroy('loadId');
							if(data.status) {
								app.MODAL_UTILS.success(data.message);
							} else {
								app.MODAL_UTILS.error(data.message)
							}							
						});
					}
				})
			});
			// 表格加载表体商品信息
			$('#girdTable').appgrid({
				rowdatas: [{
					"CustomerId": "",
					"WarehouseId": "",
					"OwnershipId": "",
					"Maker": "",
					"Date": "1900-01-01 00:00:00",
					"Verifier": "",
					"Veridate": "1900-01-01 00:00:00",
					"Status": 0,
					"Id": "1",
					"ParentId": null,
					"EnCode": "233445",
					"FullName": null,
					"Ordertype": 1,
					"CreatorTime": "1900-01-01 00:00:00"
				}],
				headData: [{
						label: "主键",
						name: "Id",
						width: 100,
						align: 'center',
					},
					{
						label: "状态",
						name: "Status",
						index: "Status",
						width: 100,
						align: "center",
						formatter: function(cellvalue) {
							if(cellvalue == 1) {
								return '<span class=\"label label-success\" style=\"cursor: pointer;\">无差异</span>';
							} else if(cellvalue == 0) {
								return '<span class=\"label label-danger\" style=\"cursor: pointer;\">有差异</span>';
							}
						}
					},
					{
						label: '发货单号',
						name: 'mainID',
						width: 150,
						align: 'left'
					},
					{
						label: 'SKU',
						name: 'sku',
						width: 150,
						align: 'left'
					},
					{
						label: '品名',
						name: 'cInvName',
						width: 150,
						align: 'left'
					},
					{
						label: '货位',
						name: 'cPosCode',
						width: 150,
						align: 'left'
					},
					{
						label: '单据数量',
						name: 'qty',
						width: 150,
						align: 'left'
					},
					{
						label: '下架数量',
						name: 'Doneqty',
						width: 150,
						align: 'left'
					},
					{
						label: '差异数量',
						name: 'Cyqty',
						width: 150,
						align: 'left'
					}
				],
				isEdit: false,
				height: 400,
				isMultiselect: false
			});

		},

		/*初始化表单数据*/
		InitForm: function() {
			if(!!keyValue) {

				//				$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
				//					$('#form1').appSetFormData(data.orderData);
				//					$('#productgird').appGridSet('refreshdata', data.orderProductData);
				//					   if ($("#orderType").appselectGet('value') == 1) {//如果是播种 发货单号隐藏                           
				//                          //$("#productgird").setGridParam().hideCol("Dpno");
				//                      }
				//				});

			}
			if(show == "1") {
				$('input,div,.fa-plus,.fa-minus,.top-btn-tool').attr('disabled', 'disabled');
				$('.fa-plus,.fa-minus,.top-btn-tool').hide()
			}
		},

	}
	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)