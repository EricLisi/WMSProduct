var router = "Duty";
var acceptClick;
var keyValue = '';

(function($, app) {
	"use strict";
	var companyId = app.URL_REQUEST_UTILS.get(window.location, 'companyId');	
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
		/*绑定事件和初始化控件*/
		bindEvent: function() {
			$('#ParentId').appformselect({
				placeholder: '请选择上级岗位',
				layerUrl: './SelectForm.html',
				layerUrlH: 500,
				dataUrl: top.$.rootUrl + '/LR_OrganizationModule/Post/GetEntityName'
			});
			// 所属部门
			$('#DepartmentId').appDepartmentSelect({
				companyId: companyId,
				maxHeight: 100
			});

		},
		/*初始化数据*/
		initForm: function() {			
			if(!!keyValue) {
				$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
					$('#form1').appSetFormData(data);

				});
			} else {
				$('#F_CompanyId').val(companyId);
			}
		},

	};
	// 保存数据	   
	acceptClick = function(callBack) {
		if(!$('#form1').appValidform()) {
			return false;
		}
		var postData = $('#form1').appGetFormData(keyValue);
		if(postData["F_ParentId"] == undefined || postData["F_ParentId"] == '' || postData["F_ParentId"] == '&nbsp;') {
			postData["F_ParentId"] = '0';
		}
		var postUrl = '/api/' + router;
		var type = "POST";
		if(!!keyValue) {
			postUrl = postUrl + "/" + keyValue;
			type = "PUT"
		}
		$.appSaveForm(type, postUrl, postData, function(res) {
			// 保存成功后才回调
			if(!!callBack) {
				callBack();
			}
		});
	};

	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)