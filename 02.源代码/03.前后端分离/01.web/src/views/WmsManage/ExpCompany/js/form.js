var router = "ExpCompany";
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
			$('#UserId').val(app.APP_GLOBE_STORE.LOGIN_USER.Id);			
			//快递鸟账号
             $("#KDAccout").appselect({
             	url: '/api/ItemsDetail/GeExpSelectGrid',
             	text: 'Text',
				value: 'Id'
             });
             //仓库
             $('#WarehouseCode').appselect({
				url: '/api/Warehouse/GetSelectGrid/'+app.APP_GLOBE_STORE.LOGIN_USER.Id,
				text: 'Text',
				value: 'Id',
				maxHeight: 180,
				allowSearch: true
			});	
//			$("#WarehouseId").appselectSet(app.APP_GLOBE_STORE.LOGIN_USER.Warehoseid)
		},
		/*初始化数据*/
		initForm: function() {
			if(!!keyValue) {
				$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
					$('#form1').appSetFormData(data);
				});
			}
		},
	};
	// 保存数据
	acceptClick = function() {		
		if(!$('#form1').appValidform()) {
			return false;
		}
		var postData = $('#form1').appGetFormData(keyValue);
		var postUrl = '/api/' + router;
		var type = "POST";
		if(!!keyValue) {
			postUrl = postUrl + "/" + keyValue;
			type = "PUT"
		}
		$.appSaveForm(type, postUrl, postData, function(data) {

		});
	};

	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)