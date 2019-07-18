var router = "SetUp";
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
			$('.app-layout-wrap').appscroll();
			// 客户选择
			$('#FullName').appselect({
				url: '/api/Module/GetTreeJson/'+app.APP_GLOBE_STORE.LOGIN_USER.Id,
				type: 'tree',
				maxHeight: 180,
				allowSearch: true
			});
			pageEvent.initForm()
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