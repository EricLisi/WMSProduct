var router = "Area";
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
            // 上级          
			$('#parentid').appselect({
			    url: '/api/Area/GetTreeJson',			   
			    type: 'tree'
			});			
		},
		/*初始化数据*/
		initForm: function() {			
			if(!!keyValue) {				
				$.appSetForm('/api/' + router + '/'+keyValue, function(data) {
					$('#form1').appSetFormData(data);
				});
			}
		},
	};
	// 保存数据
	acceptClick = function(callBack) {
		if(!$('#form1').appValidform()) {
			return false;
		}
		var postData = $('#form1').appGetFormData(keyValue);
		 if (postData["parentid"] == '' || postData["parentid"] == '&nbsp;') {
            postData["parentid"] = '0';
        }
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
				window.parent.layx.destroy('Area');
				//$('#gridtable').appGridSet('reload',{});
			} else {
				app.MODAL_UTILS.success(data.message);
				window.parent.location.reload()
				window.parent.layx.destroy('Area');
			}
		});
	};

	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)