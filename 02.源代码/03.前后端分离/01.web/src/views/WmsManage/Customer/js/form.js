var router = "Customer";
var acceptClick;
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
			pageEvent.initForm()
		},
		//绑定事件和初始化控件
		bindEvent: function() {	
			//客户省份
			$("#province").appselect({
				url: '/api/Area/GetTreeJson/',
				maxHeight: 100,
				allowSearch: true 
//              text: 'FullName',
//				value: 'Id'
			});
			$("#city").appselect({
				url: '/api/Area/GetTreeJson/',
				type: 'tree',
				maxHeight: 100,
				allowSearch: true 
//              text: 'FullName',
//				value: 'Id'
			});
//          $("#province").appselect({
//              data:app.APP_GLOBE_STORE.DATA_STATUS['PROVINCE'],
//              text: 'FullName',
//				value: 'Id',
//          }).on("change", function (e) {
//              var prov = $("#Province").appselectGet('value'); 
//              alert(prov)
//             
//               //选择省后，市联动赋值
//               $("#city").appselect({
//                          url: '/api/Area/GetTreeJson/'+ app.APP_GLOBE_STORE.LOGIN_USER.Id+'?ParentId='+prov,
//                          text: 'FullName',
//				            value: 'Id'
//              });	
//              
//              app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Area/GetTreeJson/'+ app.APP_GLOBE_STORE.LOGIN_USER.Id+'?ParentId='+prov,function(datas) {										                      
//                      alert(JSON.stringify(datas))                        
//                      $("#City").appselect({
//                          data: datas,
//                          text: 'FullName',
//				            value: 'Id'
//                      });	
//                     
//			    })			
//          });

			$('#save').on('click', function() {
				acceptClick();
			});

           $('#productgird').appgrid({
				headData: [
					{
						label: '权属编码',
						name: 'encode',
						width: 150,
						align: "center",
						edit: {
							type: 'input',
						}
					},
					{
						label: '权属名称',
						name: 'fullname',
						width: 150,
						align: "center",
						edit: {
							type: 'input',
						}
					},
					{
						label: '描述',
						name: 'description',
						width: 280,
						align: 'center',
						edit: {
							type: 'input',
						}
					}	
				],
				isEdit: true,
				height: 550,
				isMultiselect: true,
				onAddRow: function(row, rows) {
					row.id = app.BASE_UTILS.newGuid();
					row.parentid = '';
				}
		});
		},
		/*初始化数据*/
		initForm: function() {
			if(!!keyValue) {
				alert('keyValue')
				$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
					console.log(data)
					$('#form1').appSetFormData(data);
					$('#productgird').appGridSet('refreshdata', data.owner);
					//$('.aa').appGridSet(data.owner);
				});
			}
		}
	};
	// 保存数据
	acceptClick = function() {
		if(!$('#form1').appValidform()) {
			return false;
		}
		var postData = $('#form1').appGetFormData(keyValue);
		if(!!!keyValue) {
				postData.id=app.BASE_UTILS.newGuid();
			}
		
		var owner=$('.aa').appGridGet('rowdatas');
		for(var i=0;i<owner.length;i++)
		{
			owner[i].parentid=postData.id;
		}
		postData.owner=owner;
		console.log(postData)
		var postUrl = '/api/' + router;
		var type = "POST";
		if(!!keyValue) {
			postUrl = postUrl + "/" + keyValue;
			type = "PUT"
		}
		layx.load('loadId', '数据正在保存中，请稍后');
			//alert(JSON.stringify(postData));
			app.HTTP_REQUEST_UTILS.httpAsync(type, postUrl, postData, function(data) {
				layx.destroy('loadId');
				if(data.status) {
					app.MODAL_UTILS.error(data.message)
					window.parent.location.reload()
					window.parent.layx.destroy('Customer');
					//$('#gridtable').appGridSet('reload',{});
				} else {
					
					app.MODAL_UTILS.success(data.message);
					window.parent.location.reload()
					window.parent.layx.destroy('Customer');
				}
			});
//		$.appSaveForm(type, postUrl, postData, function(data) {
//
//		});
	};

	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)





//var router = "Customer";
//var acceptClick;
//(function($, app) {
//	"use strict";
//	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
//	/**
//	 * 页面事件对象
//	 */
//	var pageEvent = {
//		/**
//		 *  窗体初始化 
//		 **/
//		init: function() {
//			pageEvent.bindEvent();
//			pageEvent.initForm()
//		},
//		//绑定事件和初始化控件
//		bindEvent: function() {			
//			$('#UserId').val(app.APP_GLOBE_STORE.LOGIN_USER.Id);
//			// 上级公司
//			//$('#ParentId').appCompanySelect();
//			//市
//        // $("#City").appselect();
//			//客户省份
//          $("#Province").appselect({
//              data:app.APP_GLOBE_STORE.DATA_STATUS['PROVINCE'],
//              text: 'FullName',
//				value: 'Id',
//          }).on("change", function (e) {
//              var prov = $("#Province").appselectGet('value'); 
//              alert(prov)
//             
//               //选择省后，市联动赋值
////               $("#City").appselect({
////                          url: '/api/Area/GetTreeJson/'+ app.APP_GLOBE_STORE.LOGIN_USER.Id+'?ParentId='+prov,
////                          text: 'FullName',
////				            value: 'Id'
////              });	
//              
//              app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Area/GetTreeJson/'+ app.APP_GLOBE_STORE.LOGIN_USER.Id+'?ParentId='+prov,function(datas) {										                      
//                      alert(JSON.stringify(datas))                        
//                      $("#City").appselect({
//                          data: datas,
//                          text: 'FullName',
//				            value: 'Id'
//                      });	
//                     
//			    })			
//          });
//         
//		},
//		/*初始化数据*/
//		initForm: function() {
//			if(!!keyValue) {
//				$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
//					$('#form1').appSetFormData(data);
//				});
//			}
//		},
//		
////		$('#productgird').appgrid({
////				headData: [{
////						label: '产品名称',
////						name: 'ProductName',
////						width: 260,
////						align: "center"
////					},
////					{
////						label: '产品编号',
////						name: 'ProductCode',
////						width: 100,
////						align: 'center'
////					},
////					{
////						label: 'sku',
////						name: 'InvSKU',
////						width: 100,
////						align: 'center'
////					},
////					{
////						label: '客户编号',
////						name: 'CusCode',
////						width: 100,
////						align: 'center'
////					},
////					{
////						label: '箱号',
////						name: 'BoxNo',
////						width: 100,
////						align: 'center',
////						edit: {
////							type: 'input',
////							init: function(data, $edit) { // 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象
////								if($("#Type").val()==0)
////								{
////									edit=false
////								}
////							},
////						}
////					},
////					{
////						label: '价格',
////						name: 'Price',
////						width: 100,
////						align: 'center',
////						edit: {
////							type: 'input'
////							}
////					},
////					//					{
////					//						label: '单位',
////					//						name: 'UnitId',
////					//						width: 100,
////					//						align: 'center',
////					//						edit: {
////					//							type: 'input'
////					//						}
////					//
////					//					},
////					{
////
////						label: '入库数量',
////						name: 'Quantity',
////						width: 80,
////						align: 'center',
////						statistics: true,
////						edit: {
////							type: 'input',
////							change: function(row, rownum) { // 行数据和行号
////								//								row.Amount = parseInt(parseFloat(row.Price || '0') * parseFloat(row.Qty || '0'));
////								//								row.TaxAmount = parseInt((parseFloat(row.Price || '0') * (1 + parseFloat(row.TaxRate || '0') / 100)) * parseFloat(row.Qty || '0'));
////								//								row.Tax = row.TaxAmount - row.Amount;
////								//								$('#productgird').appGridSet('updateRow', rownum);
////							},
////						}
////					},
////
////					{
////						label: '入库货位',
////						name: 'PositionId',
////						width: 120,
////						align: "center",
////						edit: {
////							type: 'select',
////							init: function(data, $edit) { // 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象
////
////							},
////							change: function(row, num, item) { // 行数据和行号,下拉框选中数据
////
////							},
////							op: { // 下拉框设置参数 和 appselect一致
////								data: [{
////										'id': '1',
////										'text': '货位一'
////									},
////									{
////										'id': '2',
////										'text': '货位二'
////									},
////									{
////										'id': '3',
////										'text': '货位三'
////									},
////									{
////										'id': '4',
////										'text': '货位四'
////									}
////								]
////							}
////						}
////					}
////				],
////				isEdit: true,
////				height: 400,
////				isMultiselect: true
////			});
////	};
//	
//	// 保存数据
//	acceptClick = function() {		
//		if(!$('#form1').appValidform()) {
//			return false;
//		}
//		var postData = $('#form1').appGetFormData(keyValue);
//		var postUrl = '/api/' + router;
//		var type = "POST";
//		if(!!keyValue) {
//			postUrl = postUrl + "/" + keyValue;
//			type = "PUT"
//		}
//		$.appSaveForm(type, postUrl, postData, function(data) {
//
//		});
//	};
//
//	$(function() {
//		pageEvent.init();
//	})
//})(window.jQuery, top.app)