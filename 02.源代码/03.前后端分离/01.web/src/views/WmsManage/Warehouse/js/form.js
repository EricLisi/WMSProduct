var router = "Warehouse";
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
			$('#whtype').appselect({});
			$('#save').on('click', function() {
				acceptClick();
			});
			$('#gird').appgrid({
				headData: [
					{
						label: '货位编码',
						name: 'encode',
						width: 150,
						align: "center",
						edit: {
							type: 'input',
						}
					},
					{
						label: '货位名称',
						name: 'fullname',
						width: 150,
						align: "center",
						edit: {
							type: 'input',
						}
					},
					{
						label: "货位属性",
						name: "postype",
						width: 150,
						align: "center",
						edit: {
							type: 'select',
							op: { // 下拉框设置参数 和 appselect一致
//								//url:'/api/Position/GetSelectGrid',
//								text: 'text',
//								value: 'id',
//								allowSearch: true
								data: [{
										'id': '0',
										'text': '正常品'
									},
									{
										'id': '1',
										'text': '待处理'
									},
									{
										'id': '2',
										'text': '坏品区'
									}
								]
							}
						},
						formatter: function(cellvalue) {
							if(cellvalue == 0) {
								return "正常品"
							} else if(cellvalue == 1) {
								return "待处理"
							} else if(cellvalue == 2) {
								return "坏品区"
							}
						}
					},
					{
						label: '描述',
						name: 'description',
						width: 280,
						align: 'center',
						edit: {
							type: 'input',
						}
					}	
				],
				isEdit: true,
				height: 550,
				isMultiselect: true,
				onAddRow: function(row, rows) {
					row.id = app.BASE_UTILS.newGuid();
					row.parentid = '';
				}
		});
		},
		/*初始化数据*/
		initForm: function() {
			if(!!keyValue) {
				$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
					$('#form1').appSetFormData(data);
					$('#gird').appGridSet('refreshdata', data.position);
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
		if(!!!keyValue) {
				postData.id = app.BASE_UTILS.newGuid()
		}
		var position=$('.aa').appGridGet('rowdatas');
		for(var i=0;i<position.length;i++)
		{
			position[i].parentid=postData.id;
		}
		console.log(position)
		postData.position=position;
		var postUrl = '/api/' + router;
		var type = "POST";
		if(!!keyValue) {
			postUrl = postUrl + "/" + keyValue;
			type = "PUT"
		}
		console.log(postData)
		layx.load('loadId', '数据正在保存中，请稍后');
			//alert(JSON.stringify(postData));
			app.HTTP_REQUEST_UTILS.httpAsync(type, postUrl, postData, function(data) {
				layx.destroy('loadId');
				if(data.status) {
					app.MODAL_UTILS.error(data.message)
					window.parent.location.reload()
					window.parent.layx.destroy('Warehouse');
					//$('#gridtable').appGridSet('reload',{});
				} else {
					
					app.MODAL_UTILS.success(data.message);
					window.parent.location.reload()
					window.parent.layx.destroy('Warehouse');
				}
			});
		$.appSaveForm(type, postUrl, postData, function(data) {

		});
	};

	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)