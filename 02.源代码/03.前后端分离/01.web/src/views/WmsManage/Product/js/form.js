var router = "Inventory";
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
              //客户
			 $("#CusCode").appselect({
                url:'/api/Customer/GetSelectGrid',
                text: 'Text',
				value: 'Id'
            })
			 //商品归类
			 $("#Type").appselect({
                url:'/api/InventoryClass/GetSelectGrid',
               text: 'Text',
				value: 'Id'
            })	
		},
		/*初始化数据*/
		initForm: function() {
			if(!!keyValue) {
				$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
					$('#form1').appSetFormData(data);
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
