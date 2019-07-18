var router = "User";
(function($, app) {
	"use strict";
	var parentId = "0";
	var objectId = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	var selectData;
	var checkModuleIds = [];

	function setTreeData1() {
		if(!!selectData) {
			$('#step-1').apptreeSet('setCheck', selectData.moduleList);
		} else {
			setTimeout(setTreeData1, 100);
		}
	}

	function setTreeData2() {
		if(!!selectData) {
			$('#step-2').apptreeSet('setCheck', selectData.buttonList);
		} else {
			setTimeout(setTreeData2, 100);
		}
	}

	/**
	 * 页面事件
	 */
	var pageEvent = {
		/**
		 * 初始化事件
		 */
		init: function() {
			pageEvent.bindEvent();
			pageEvent.initData()
		},

		/**
		 * 绑定事件
		 */
		bindEvent: function() {
			app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/User/GetAll', function(data) {
				setTimeout(function() {
					$('#step-1').apptree({
						data: JSON.parse(data.moduleList)
					});
					if(!!objectId) {
						setTreeData1();
					}
				}, 10);
				setTimeout(function() {
					$('#step-2').apptree({
						data: JSON.parse(data.buttonList)
					});
					if(!!objectId) {
						setTreeData2();
					}
				}, 50);

			});
			// 加载导向
			$('#wizard').wizard().on('change', function(e, data) {
				var $finish = $("#btn_finish");
				var $next = $("#btn_next");
				if(data.direction == "next") {
					if(data.step == 1) {
						checkModuleIds = $('#step-1').apptreeSet('getCheckNodeIds');
						$('#step-2 .app-tree-root [id$="_learun_moduleId"]').parent().hide();
						$.each(checkModuleIds, function(id, item) {
							$('#step-2_' + item.replace(/-/g, '_') + '_learun_moduleId').parent().show();

						});
						$next.attr('disabled', 'disabled');
						$finish.removeAttr('disabled');
					}
				} else {
					$finish.attr('disabled', 'disabled');
					$next.removeAttr('disabled');
				}
			});
			// 保存数据按钮
			$("#btn_finish").on('click', pageEvent.save);
		},
		/*初始化数据*/
		initData: function() {
			if(!!objectId) {
				$.appSetForm('/api/User/GetUserPerById/' + objectId, function(data) {
					selectData = data;
				});				
			}
		},
		/*保存数据*/
		save: function() {
			var buttonList = [],
				columnList = [],
				formList = [];
			var checkButtonIds = $('#step-2').apptreeSet('getCheckNodeIds');
			$.each(checkButtonIds, function(id, item) {
				if(item.indexOf('_learun_moduleId') == -1) {
					buttonList.push(item);
				}
			});
			var postData = {
				strModuleId: String(checkModuleIds),
				strModuleButtonId: String(buttonList)
			};
			//alert(JSON.stringify(postData))
			$.appSaveForm('PUT', '/api/User/InsUpUserPre/' + objectId, postData, function(data) {

			});
		}
	}

	$(function() {
		pageEvent.init();
	});

})(window.jQuery, top.app);