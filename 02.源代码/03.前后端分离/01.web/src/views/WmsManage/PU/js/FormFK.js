var router = "PU";
var acceptClick;
(function($, app) {
	"use strict";
	//var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	var rowData = app.URL_REQUEST_UTILS.get(window.location, 'rowData');
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
		},

		/*初始化表单数据*/
		InitForm: function() {
			var rowDatas = JSON.parse(rowData);
			$("#OrderNo").val(rowDatas.OrderNo)
			$("#WarehouseId").appselectSet(rowDatas.WarehouseId)
			$("#CustomerId").appselectSet(rowDatas.CustomerId)
			$("#Property").val(rowDatas.Property)
		},

	};
	// 保存数据
	acceptClick = function(callBack) {
		var rowDatas = JSON.parse(rowData);
		var param = {
			"User":app.APP_GLOBE_STORE.LOGIN_USER.FullName,
			"orderNo": rowDatas.Id,
			"PositionCode": $("#Position").val()
		};
		//alert(JSON.stringify(s))
		callBack(param);
		return true;
	};
	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)