var router = "DP";
var datas = [];
(function($, app) {
	"use strict";
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');

	// 保存数据
	var acceptClick = function() {
		if(!$('#form1').appValidform()) {
			return false;
		}
		var formData = $('#form1').appGetFormData(keyValue);
		var productDataTmp = $('#productgird').appGridGet('rowdatas');
//		alert(JSON.stringify(productDataTmp))
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
			//选择收货人
			$('#selectIcon1').on('click', function() {
				layx.iframe('iconForm', '选择收货人', '../../Consignee/html/index.html', {
					shadable: true,
					statusBar: true,
					width: 1050,
					height: 450,
					buttons: [{
							label: '<i class="fa fa-save" style="margin-right:5px"></i>保存',
							callback: function(id, button, event) {
								// 获取 iframe 页面 window对象
								var contentWindow = layx.getFrameContext(id);
								contentWindow.acceptClick(function(data) {
									if($("#sendPerson").val() == data.EnCode) {
										app.MODAL_UTILS.error("已经选择过此收件人")
										return false
									} else {
										alert(data.City)
										$("#sendPerson").val(data.Person);
										$("#phone").val(data.Phone);
										$("#sendAddress").val(data.Address);
										$("#Province").appselectSet(data.Province);
										$("#City").appselectSet(data.City)
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
			//仓库
			$("#WarehouseId").appselect({
				url: '/api/Warehouse/GetSelectGrid/' + app.APP_GLOBE_STORE.LOGIN_USER.Id,
				text: 'Text',
				value: 'Id'
			});
			$("#WarehouseId").appselectSet(app.APP_GLOBE_STORE.LOGIN_USER.Warehoseid)
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
			})
			//发运方式
			$("#sendType").appselect().on("change", function(e) {
				var sendType = $("#sendType").appselectGet('value');
				if(sendType == "1") //货运
				{
					$("#expCompany").attr('disabled', 'disabled');
					$("#expCompany").appselectSet('');
					$('#expCompany').prev().html("快递公司")
					$('#expCompany').removeAttr('isvalid', 'yes');
					$('#expCompany').removeAttr('checkexpession', 'NotNull');

					$('#Province').prev().html("省")
					$('#Province').removeAttr('isvalid', 'yes');
					$('#Province').removeAttr('checkexpession', 'NotNull');

					$('#City').prev().html("市")
					$('#City').removeAttr('isvalid', 'yes');
					$('#City').removeAttr('checkexpession', 'NotNull');

				} else //快递
				{
					$("#expCompany").removeAttr('disabled', 'disabled');
					$('#expCompany').prev().html("快递公司<font face='宋体'>*</font>")
					$('#expCompany').attr('isvalid', 'yes');
					$('#expCompany').attr('checkexpession', 'NotNull');

					$('#Province').prev().html("省<font face='宋体'>*</font>")
					$('#Province').attr('isvalid', 'yes');
					$('#Province').attr('checkexpession', 'NotNull');

					$('#City').prev().html("市<font face='宋体'>*</font>")
					$('#City').attr('isvalid', 'yes');
					$('#City').attr('checkexpession', 'NotNull');
				}
			});;
			//快递公司
			$("#expCompany").appselect({
				url: '/api/ExpCompany/GetSelectGrid',
				text: 'Text',
				value: 'Id'
			});
			//客户省份
			$("#Province").appselect({
				data: app.APP_GLOBE_STORE.DATA_STATUS['PROVINCE'],
				text: 'FullName',
				value: 'Id',
			}).on("change", function(e) {
				var prov = $("#Province").appselectGet('value');
				//alert(prov)

				//选择省后，市联动赋值
				//               $("#City").appselect({
				//                          url: '/api/Area/GetTreeJson/'+ app.APP_GLOBE_STORE.LOGIN_USER.Id+'?ParentId='+prov,
				//                          text: 'FullName',
				//				            value: 'Id'
				//              });	

				app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Area/GetTreeJson/' + app.APP_GLOBE_STORE.LOGIN_USER.Id + '?ParentId=' + prov, function(datas) {
					//alert(JSON.stringify(datas))
					$("#City").appselect({
						data: datas,
						text: 'FullName',
						value: 'Id'
					});

				})
			});

			// 表格加载表体商品信息
			$('#productgird').appgrid({
				headData: [{
						label: 'sku',
						name: 'BarCode',
						width: 260,
						align: "center"

					},
					{
						label: '商品名称',
						name: 'ProductName',
						width: 260,
						align: "center",
						edit: {
							type: 'layer',
							init: function(data, $edit, rownum) { // 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象

							},
							change: function(row, rownum, selectdata) { // 行数据和行号,弹层选择行的数据，如果是自定义实现弹窗方式则该方法无效
								row.BarCode = selectdata.Barcode;
								row.ProductName = selectdata.ProductName;
 								row.qty = 1;
 								row.boxNo=selectdata.BoxNo;
 								row.doneqty =selectdata.Qty;
 								row.outqty =row.doneqty-row.qty;
							    row.RowId=selectdata.Id;
							    row.ProductId=selectdata.ProductId;
								$('#productgird').appGridSet('updateRow', rownum);

								//alert(JSON.stringify(row))
								//alert(rownum)							
								//alert(JSON.stringify(selectdata))
//								for(var i=0;i<selectdata.length;i++){
//								        alert(parseInt(rownum)+parseInt(i))
//								        row.FullName = selectdata[i].FullName;
//							            row.SKU = selectdata[i].SKU;																
//								        $('#productgird').appGridSet('updateRow', parseInt(rownum)+parseInt(i));
//								}
							},
							op: { // 如果未设置op属性可以在init中自定义实现弹窗方式
								width: 601,
								height: 400,
								colData: [{
										label: '商品条码',
										name: 'Barcode',
										width: 100,
										align: "center"
									},
									{
										label: '商品名称',
										name: 'ProductName',
										width: 100,
										align: "center"
									},
									{
										label: '数量',
										name: 'Qty',
										width: 100,
										align: 'center'
									},
										{
										label: '备注',
										name: 'Description',
										width: 100,
										align: 'center'
									}
								 
								],
								url: '/api/Stock/GatPagerListByWhere/' + app.APP_GLOBE_STORE.LOGIN_USER.Id,
							}
						}
					},
					{
						label: '箱号',
						name: 'BoxNo',
						width: 100,
						align: 'center',
						edit: {
							type: 'input'
						}
					},
					{

						label: '数量',
						name: 'qty',
						width: 80,
						align: 'center',
						statistics: true,
						edit: {
							type: 'input'
						}
					},
					{
						label: '实际数量',
						name: 'doneqty',
						width: 120,
						align: "center",
						statistics: true
					},
					{
						label: "差异数量",
						name: "outqty",
						width: 200,
						align: "center"
					}			
				],
				isEdit: true,
				height: 400,
				isMultiselect: true
			});
			$('#save').on('click', function() {
				acceptClick();
			});

		},

		/*初始化表单数据*/
		InitForm: function() {
			$('#Maker').val(app.APP_GLOBE_STORE.LOGIN_USER.FullName);
			$("#Date").val(app.BASE_UTILS.Date.get_yyyy_MM_dd());
			if(!!keyValue) {
				$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
					$('#form1').appSetFormData(data.info);
					$('#productgird').appGridSet('refreshdata', data.dInfo);
				});
			}
		},

	}
	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)