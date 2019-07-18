var appBarCodeRuleDetailList;

(function($, app) {
	"use strict";
	var mainId = '';
	/**
	 * 初始化参数
	 */
	var options = {
		params: { //参数
			router: "BarCodeRule",
			form: {
				id: "BarCodeRule",
				title: "条码规则",
				width: 750,
				height: 450,
				type: "tab",
				buttons: [{
						label: '<i class="fa fa-save" style="margin-right:5px"></i>保存',
						callback: function (id, button, event) {
							// 获取 iframe 页面 window对象
							var contentWindow = layx.getFrameContext(id);
							contentWindow.acceptClick(refreshGirdData);
							layx.destroy(id);
						},
						classes: ['a1']
					},
					{
						label: '<i class="fa fa-close" style="margin-right:5px"></i>取消',
						callback: function (id, button, event) {
							layx.destroy(id);
						},
						classes: ['a1']
					}
				]
			}
		},
//		params: { //参数
//			router: "BarCodeRule",
//			form: {
//				title: "条码规则",
//				width: 950,
//				height: 700,
////				type: "tab",
//			}
//		},
		Event: { //初始化事件
			doBeforeInit: function() {
				$('#app_layout').appLayout();
			}
		},
		search: { //搜索			
			setSearchParams: function () {
				return {
					userid: app.APP_GLOBE_STORE.LOGIN_USER.Id,
					encode: $("#txtCode").val(),
					fullname: $("#txtName").val()
				}
			}
		},
		tree: { //启用左侧树形			
		},
		bindEvent: { //点击事件参数 
			add: {

			}
		},

		grid: { //grid 
			options: {
				url: '/api/BarCodeRule/GetBarCodeRuleByPages',
				param: {
					userid: app.APP_GLOBE_STORE.LOGIN_USER.id
				},
				headData: [
//				{
//						label: '状态',
//						name: 'Status',
//						width: 100,
//						align: "center",
//						formatter: function(cellvalue) {
//							if(cellvalue == 1) {
//								return '<span class=\"label label-success\" style=\"cursor: pointer;\">已审核</span>';
//							} else if(cellvalue == 0) {
//								return '<span class=\"label label-default\" style=\"cursor: pointer;\">待审核</span>';
//							} else if(cellvalue == 2) {
//								return '<span class=\"label label-danger\" style=\"cursor: pointer;\">已关闭</span>';
//							}
//						}
//					},
					{
						label: "规则编码",
						name: "EnCode",
						width: 130,
						align: "center"
					},
					{
						label: "规则名称",
						name: "FullName",
						width: 130,
						align: "center"
					},
					{
						label: '规则类型',
						name: 'Type',
						width: 150,
						align: "center"
					},
					{
						label: '分隔符',
						name: 'Separator',
						width: 100,
						align: "center"
					},
					{
						label: "备注",
						name: "Description",
						width: 100,
						align: "center"
					}
				],
			}
		}
	};
	$(function() {
		app.CommonIndexEvent.init(options);
	})
})(window.jQuery, top.app)