var router = "Dictionary";
//var selectedRow = top.layer_ClassifyIndex.selectedRow;
var acceptClick;

(function($, app) {
	"use strict";
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	//var parentId = app.URL_REQUEST_UTILS.get('parentId');
	/**
	 * 页面事件对象
	 */
	var pageEvent = {
		/**
		 *  窗体初始化 
		 **/
		init: function() {
			//alert(85)
			pageEvent.bindEvent();
			pageEvent.initForm()

		},
		/*绑定事件和初始化控件*/
		bindEvent: function() {
			// 上级
			$("#parentid").appselect({
				url: '/api/Dictionary/GetDictionaryTree',
				type: 'tree',
				maxHeight: 100,
				allowSearch: true
			});
		},

		/*初始化数据*/
		initForm: function() {
			/*if (!!selectedRow) {
                keyValue = selectedRow.F_ItemId || '';
                $('#form').appSetFormData(selectedRow);
            }*/
			if(!!keyValue) {
				$.appSetForm('/api/Dictionary'+ '/' + keyValue, function(data) {
					//console.log(data)
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
//		console.log(postData)
//		if(postData.ParentId=="" || postData.ParentId == "0" ){
//			postData["ParentId"] = '0';
//		} else if(postData["ParentId"] == keyValue) {
//			app.MODAL_UTILS.warning('上级不能是自己本身');
//			return false;
//		}
		var postUrl = '/api/Dictionary';
		var type = "POST";
		if(!!keyValue) {
			postUrl = postUrl + "/" + keyValue;
			type = "PUT"
		}
		//alert(postUrl)
		layx.load('loadId', '数据正在保存中，请稍后');
			//alert(JSON.stringify(postData));
			app.HTTP_REQUEST_UTILS.httpAsync(type, postUrl, postData, function(data) {
				layx.destroy('loadId');
				if(data.status) {
					app.MODAL_UTILS.error(data.message)
					window.parent.location.reload()
					window.parent.layx.destroy('Dictionary');
					//$('#gridtable').appGridSet('reload',{});
				} else {
					
					app.MODAL_UTILS.success(data.message);
					window.parent.location.reload()
					window.parent.layx.destroy('Dictionary');
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