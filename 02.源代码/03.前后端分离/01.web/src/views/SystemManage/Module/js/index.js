var appModuleButtonList;
var appModuleColumnList;

(function ($, app) {
	"use strict";
	var moduleId = '';
	//点击左侧树
	var nodeclick = function (item) {
		moduleId = item.id;
		$('#titleinfo').text(item.text);
		var param = {
			moduleid: item.id
		};
		$("#" + app.CommonIndexParams.grid.id).appGridSet('reload', param);
	}
	/**
	 * 初始化参数
	 */
	var options = {
		params: { //参数
			router: "Module",
			form: {
				id: "Module",
				title: "菜单",
				width: 750,
				height: 550
//				buttons: [{
//						label: '<i class="fa fa-save" style="margin-right:5px"></i>保存',
//						callback: function (id, button, event) {
//							// 获取 iframe 页面 window对象
//							var contentWindow = layx.getFrameContext(id);
//							contentWindow.acceptClick(refreshGirdData);
//							layx.destroy(id);
//						},
//						classes: ['a1']
//					},
//					{
//						label: '<i class="fa fa-close" style="margin-right:5px"></i>取消',
//						callback: function (id, button, event) {
//							layx.destroy(id);
//						},
//						classes: ['a1']
//					}
//				]
			}
		},
		Event: { //初始化事件
			doBeforeInit: function () {
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
			options: {
				id: "module_tree", 
				//data: moduletreedata,
				url: '/api/Module/GetModuleTree',
				nodeClick: nodeclick//,
				//defaultValue: "5" //设置默认值
			}
		},
		bindEvent: { //点击事件参数 
			add: {
				doBeforeEvent: function () {
					return {
						result: true,
						data: {
							addParams: "?ModuleId=" + moduleId
						}
					};
				}
			}

		},

		grid: { //grid 
			options: {
				url: '/api/Module/GetModuleByPages',
				param: {
					userid: app.APP_GLOBE_STORE.LOGIN_USER.id
				},
				//rowdatas: moduledata,
				headData: [{
						label: "编号",
						name: "encode",
						width: 150,
						align: "center"
					},
					{
						label: "名称",
						name: "fullname",
						width: 150,
						align: "center"
					},
					{
						label: "地址",
						name: "urladdress",
						width: 350,
						align: "center"
					},
					{
						label: "目标",
						name: "target",
						width: 60,
						align: "center"
					},
					{
						label: "菜单",
						name: "ismenu",
						width: 50,
						align: "center",
						formatter: function (cellvalue, rowObject) {
							return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
						}
					},
					{
						label: "展开",
						name: "isexpand",
						width: 50,
						align: "center",
						formatter: function (cellvalue, rowObject) {
							return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
						}
					},
					{
						label: "有效",
						name: "enabledmark",
						width: 50,
						align: "center",
						formatter: function (cellvalue, rowObject) {
							return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
						}
					},
					{
						label: "描述",
						name: "description",
						width: 200,
						align: "center"
					}
				]
			}
		}
	};
	$(function () { 
		//调用初始化页面方法
		app.CommonIndexEvent.init(options);
	})
})(window.jQuery, top.app)