var router = "CW";
var datas = [];
(function($, app) {
	"use strict";
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	var show = app.URL_REQUEST_UTILS.get(window.location, 'show');
	// 保存数据
	var acceptClick = function() {
		if(!$('#form1').appValidform()) {
			return false;
		}
		var formData = $('#form1').appGetFormData(keyValue);
		var productData = [];
		var productDataTmp = $('#productgird').appGridGet('rowdatas');
		alert(JSON.stringify(productDataTmp))
		var postData = {
			crmOrderJson: formData,
			crmOrderProductJson: productDataTmp
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
			pageEvent.InitForm();
			//选择货位
			$('#selectIcon1').on('click', function() {
				layx.iframe('iconForm', '选择货位', '../html/position.html', {
					shadable: true,
					statusBar: true,
					width: 1050,
					height: 450,
					buttons: [{
							label: '<i class="fa fa-save" style="margin-right:5px"></i>确定',
							callback: function(id, button, event) {
								// 获取 iframe 页面 window对象
								var contentWindow = layx.getFrameContext(id);
								contentWindow.acceptClick(function(data) {
									//alert(JSON.stringify(data))
									if(data) {
										var str = '';
										$.each(data, function(i) {
											str += data[i].EnCode + ",";
										})
										var strs = str.slice(0, str.length - 1);
										$("#Position").val(strs);
									}

								})
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
		},

		/**
		 * 绑定事件
		 */
		bindEvent: function() {
			// 优化滚动条
			$('#form1').appscroll();
			
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
			//仓库
//			$("#WarehouseId").appselect({
//				url: '/api/Warehouse/GetSelectGrid/' + app.APP_GLOBE_STORE.LOGIN_USER.Id,
//				text: 'Text',
//				value: 'Id'
//			});
//			$("#WarehouseId").appselectSet(app.APP_GLOBE_STORE.LOGIN_USER.Warehoseid);
//			//客户
//			$("#CustomerId").appselect({
//				url: '/api/Customer/GetSelectGrid',
//				text: 'Text',
//				value: 'Id'
//			}).on("change", function(e) {
//				//alert($("#CustomerId").appselectGet('value'));
//				var cusid = $("#CustomerId").appselectGet('value');
//				app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Customer/' + cusid, function(data) {
//					$("#Property").val(data.Ownership)
//				});
//			});

			// 表格加载表体商品信息
			$('#productgird').appgrid({
				headData: [
//					{
//						label: "主键",
//						name: "Id",
//						width: 100,
//						align: 'center',
//					},					
					{
						label: '产品名称',
						name: 'ProductName',
						width: 260,
						align: "center"
					},
					{
						label: '产品编号',
						name: 'ProductCode',
						width: 100,
						align: 'center'
					},
					{
						label: 'sku',
						name: 'InvSKU',
						width: 100,
						align: 'center'
					},
					{
						label: '箱号',
						name: 'BoxNo',
						width: 100,
						align: 'left'
					},
					{
						label: '货位',
						name: 'PosCode',
						width: 150,
						align: 'left'
					},
					{
						label: '账面数量',
						name: 'Qty',
						width: 150,
						align: 'left'
					},
					{
						label: '实盘数量',
						name: 'DoneQty',
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
				isEdit: true,
				height: 650,
				isMultiselect: true
			});
			$('#save').on('click', function() {
				acceptClick();
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