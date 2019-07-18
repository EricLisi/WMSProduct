var router = "Dictionary";
var keyValue = '';
var acceptClick;
(function($, app) {
	"use strict";
	var parentId = app.URL_REQUEST_UTILS.get(window.location, 'parentId');
	var itemCode = app.URL_REQUEST_UTILS.get(window.location, 'ItemId');
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	var selectedRow = top.selectedDataItemRow;
	/**
	 * 页面事件对象
	 */
	var pageEvent = {
		/**
		 *  窗体初始化 
		 **/
		init: function() {
			pageEvent.initForm()
			//$("#itemid").val(itemCode)
		},
		/*初始化数据*/
		initForm: function() {
			//$("#ItemId").val(itemCode)
			if(!!keyValue) {
				$.appSetForm('/api/' + router + '/' + localStorage.getItem('editItemId'), function(data) {
					console.log(data)
					for(var i=0;i<data.detail.length;i++)
					{ 
						if(data.detail[i].id==keyValue)
						{
							$('#form1').appSetFormData(data.detail[i]);
						}
					}
				});
			} else {
				$('#ParentId').val(parentId);
			}
		},
	};
	// 保存数据
	acceptClick = function(callBack) {
		if(!$('#form1').appValidform()) {
			return false;
		}
		var postData;
		var Detail = [];
		var postUrl = '/api/' + router;
		var type = "POST";
		var detail = $('#form1').appGetFormData(keyValue)
		$.appSetForm('/api/' + router + '/' + itemCode, function(data) {
			postData = data;
			Detail = data.detail;
			var point = {
				id: app.BASE_UTILS.newGuid(),
				itemid: itemCode,
				itemcode: detail.itemcode,
				itemname: detail.itemname,
				enablemark: detail.enablemark,
				description: detail.description,
				sortcode: detail.sortcode
			};
			postData.detail.push(detail);
			if(!!itemCode) {
				postUrl = postUrl + '/' + itemCode;
				type = "PUT"
			}
			layx.load('loadId', '数据正在保存中，请稍后');
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
		});
	};

	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)