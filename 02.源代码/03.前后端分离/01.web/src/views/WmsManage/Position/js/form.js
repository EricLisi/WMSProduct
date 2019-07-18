var router = "Position";
var acceptClick;
var acceptClick1;
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
			//所属仓库
			$('#WhCode').appselect({
				url: '/api/Warehouse/GetSelectGrid/'+app.APP_GLOBE_STORE.LOGIN_USER.Id,
				text: 'Text',
				value: 'Id',
				maxHeight: 180,
				allowSearch: true
			});
			//货位类型
			$('#PosType').appselect();
			
		},
		/*初始化数据*/
		initForm: function() {
			if(!!keyValue) {
//				alert(keyValue);
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
	// 批量保存数据
	acceptClick1 = function() {			
		if(!$('#form2').appValidform()) {
			return false;
		}
		var postData = $('#form2').appGetFormData(keyValue);
		//alert(JSON.stringify(postData))		
        if (postData.BenginNum < 0 || postData.EndNum > 99) {//限制序号在1-99之间           	
            app.MODAL_UTILS.error("序号在1-99之间")
            return false;
        }
		$.appSaveForm('POST', '/api/' + router+'/SubmitForm1', postData, function(data) {

		});
	};

	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)