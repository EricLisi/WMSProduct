var router = "PU";
var datas = [];
(function($, app) {
	"use strict";
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	//根据入库类别，加载表格
	$("#OrderType").change(function() {
		var OrderType = $("#OrderType").appselectGet('value');
		if(OrderType == "0") { //入库类别为散货时,productgird显示			
			$('#productgird').css('display', 'block');
			$('#productgird').addClass('aa')
			$('#productgird1').css('display', 'none');
			$('#productgird1').removeClass('aa');
			
			//先将表格置空
			$("#productgird").appGridSet('refreshdatas', datas);
		} else if(OrderType == "1") { //入库类别为整箱时,productgird1显示				
			$('#productgird').css('display', 'none');
			$('#productgird').removeClass('aa');
			$('#productgird1').addClass('aa');
			$('#productgird1').css('display', 'block');
			//先将表格置空
			$("#productgird1").appGridSet('refreshdatas', datas);
		}
	})
	// 保存数据
	var acceptClick = function() {
		if(!$('#form1').appValidform()) {
			return false;
		}
		var formData = $('#form1').appGetFormData(keyValue);
		var productData = [];
		var productDataTmp = $('.aa').appGridGet('rowdatas');
		var postData = {
			info: formData,
			dInfo: productDataTmp
		};
		//alert(JSON.stringify(postData))
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
			//复制行
			$('.fa-file-audio-o').click(function(){	
				var product = $('.aa').appGridGet('rowdatas');
				//alert(JSON.stringify(product))
				var productDataTmp = $('.aa').appGridGet('rowdata');	
				//alert(JSON.stringify(productDataTmp))
				var c = productDataTmp.concat(product);
				//alert(JSON.stringify(c))
				$('.aa').appGridSet('refreshdata',c)
			})
		},

		/**
		 * 绑定事件
		 */
		bindEvent: function() {		
			$('span').removeClass('hides')
//			var $fuzhi = $('<span><i class="fa fa-file-audio-o"></i></span>');              
//			$('.appgrid-toolbar').append($fuzhi);			
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
			//入库类别
			$("#OrderType").appselect();
			// 入库类别为整箱时，表格加载表体商品信息
			$('#productgird1').appgrid({
				headData: [{
						label: 'sku',
						name: 'ProductSku',
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
								row.ProductSku = selectdata.SKU;
								row.ProductName = selectdata.FullName;
								row.ProductId=selectdata.Id;
								row.Qty = '1';
								row.Doneqty = '0';
								row.CYqty = '1';
								$('#productgird1').appGridSet('updateRow', rownum);

//								alert(JSON.stringify(row))
//								alert(rownum)							
//								alert(JSON.stringify(selectdata))
//								for(var i=0;i<selectdata.length;i++){
//								    alert(parseInt(rownum)+parseInt(i))
//								    row.FullName = selectdata[i].FullName;
//					                row.SKU = selectdata[i].SKU;																
//								    $('#productgird1').appGridSet('updateRow', parseInt(rownum)+parseInt(i));
//								}
							},
							op: { // 如果未设置op属性可以在init中自定义实现弹窗方式
								width: 601,
								height: 400,
								colData: [{
										label: '商品归类',
										name: 'TypeName',
										width: 100,
										align: "center"
									},
									{
										label: 'sku',
										name: 'SKU',
										width: 100,
										align: "center"
									},
									{
										label: '商品名称',
										name: 'FullName',
										width: 100,
										align: 'center'
									},
									{
										label: '商品编码',
										name: 'Barcode',
										width: 100,
										align: 'center'
									},
									{
										label: "备注",
										name: "Description",
										width: 300,
										align: "center"
									}
								],
								url: '/api/Product/GatPagerListByWhere/' + app.APP_GLOBE_STORE.LOGIN_USER.Id,
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
						name: 'Qty',
						width: 80,
						align: 'center',
						statistics: true,
						edit: {
							type: 'input'
						}
					},
					{
						label: '实际数量',
						name: 'Doneqty',
						width: 120,
						align: "center",
						statistics: true
					},
					{
						label: "差异数量",
						name: "CYqty",
						width: 200,
						align: "center"
					}
				],
				isEdit: true,
				height: 400,
				isMultiselect: true
			});

			//入库类别为散货时，表格加载选中的商品信息
			$('#productgird').appgrid({
				headData: [{
						label: 'sku',
						name: 'ProductSku',
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
                                row.ProductSku = selectdata.SKU;
								row.ProductName = selectdata.FullName;
								row.ProductId=selectdata.Id;
								row.Qty = '1';
								row.Doneqty = '0';
								row.CYqty = '1';
								$('#productgird').appGridSet('updateRow', rownum);
								
							},
							op: { // 如果未设置op属性可以在init中自定义实现弹窗方式
								width: 601,
								height: 400,
								colData: [{
										label: '商品归类',
										name: 'TypeName',
										width: 100,
										align: "center"
									},
									{
										label: 'sku',
										name: 'Sku',
										width: 100,
										align: "center"
									},
									{
										label: '商品名称',
										name: 'FullName',
										width: 100,
										align: 'center'
									},
									{
										label: '商品编码',
										name: 'Barcode',
										width: 100,
										align: 'center'
									},
									{
										label: "备注",
										name: "Description",
										width: 300,
										align: "center"
									}
								],
								url: '/api/Product/GatPagerListByWhere/' + app.APP_GLOBE_STORE.LOGIN_USER.Id,
							}
						}
					},
					{
						label: '箱号',
						name: 'BoxNo',
						width: 100,
						align: 'center'
					},
					{

						label: '数量',
						name: 'Qty',
						width: 80,
						align: 'center',
						statistics: true,
						edit: {
							type: 'input'
						}
					},

					{
						label: '实际数量',
						name: 'Doneqty',
						width: 120,
						align: "center",
						statistics: true
					},

					{
						label: "差异数量",
						name: "CYqty",
						width: 200,
						align: "center"
					}
				],
				isEdit: true,
				height: 400,
				isMultiselect: true
			});
			// 保存数据			
			$('#save').on('click', function() {
				acceptClick();
			});

		},

		/*初始化表单数据*/
		InitForm: function() {
			$("#Date").val(app.BASE_UTILS.Date.get_yyyy_MM_dd());
			if(!!keyValue) {
				$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
					$('#form1').appSetFormData(data.info);
					$('.aa').appGridSet('refreshdata', data.dInfo);
				});
			}
		},

	}
	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)