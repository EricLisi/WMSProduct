var router = "User";
var acceptClick;
(function($, app) {
	"use strict";
	//var companyId = app.URL_REQUEST_UTILS.get(window.location, 'companyId');
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	// 页面事件对象     
	var pageEvent = {
		// 窗体初始化          
		init: function() {
			pageEvent.bindEvent();
			pageEvent.initForm()
		},
		//绑定事件和初始化控件
		bindEvent: function() {
			// 部门
			$("#departmentid").appselect()
			//公司部门
			$("#companyid").appselect({
				type: 'tree',
				url: '/api/Company/GetTreeJson',
				text: 'fullname',
				value: 'id',
				maxHeight: 60,
				allowSearch: true
			}).on("change", function(e) {
				var com = $("#companyid").appselectGet('value');
				app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Company/' + com, function(datas) { 
					$("#departmentid").appselect({ 
						data: datas.departments,
						text: 'fullname',
						value: 'id',
						maxHeight: 60,
						allowSearch: true,
						refresh:true
					});
				})
			});

			// 性别
			$('#gender').appselect();
			$('#roleid').appselect({
				url: '/api/Role/GetSelectJson',
				text: 'text',
				value: 'id',
				maxHeight: 60,
				allowSearch: true
			});
		},
		//初始化数据
		initForm: function() {
			if(!!keyValue) {
				$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
					$('#form1').appSetFormData(data);
					$("#companyid").val(data.companyid)
					$('#password').attr('readonly', 'readonly');
					$('#account').attr('readonly', 'readonly');
					$('#password').attr('unselectable', 'on');
					$('#account').attr('unselectable', 'on');
				});
			}
		}
	}
	// 保存数据	   
	acceptClick = function(callBack) {
		if(!$('#form1').appValidform()) {
			return false;
		}
		var postData = $('#form1').appGetFormData(keyValue);
		alert(JSON.stringify(postData));
		var postUrl = '/api/' + router;
		var type = "POST";

		if(!!keyValue) {
			postUrl = postUrl + "/" + keyValue;
			type = "PUT"
		}
		if(!keyValue) {
			postData.password = $.md5(postData.password);
		}
		layx.load('loadId', '数据正在保存中，请稍后');
		//alert(JSON.stringify(postData));
		app.HTTP_REQUEST_UTILS.httpAsync(type, postUrl, postData, function(data) {
			layx.destroy('loadId');
			if(data.status) {
				app.MODAL_UTILS.error(data.message)
				window.parent.location.reload()
				window.parent.layx.destroy('User');
				//$('#gridtable').appGridSet('reload',{});
			} else {

				app.MODAL_UTILS.success(data.message);
				window.parent.location.reload()
				window.parent.layx.destroy('User');
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