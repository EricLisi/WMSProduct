var appbuttons;
var appcolumns;
var appmodules;

(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "Role",
			form: {
				title: "角色",
				width: 750,
				height: 450
			}
		},
		Event: { //初始化事件
			doBeforeInit: function () {
				$('#app_layout').appLayout();
			}
		},
//		Event: { //初始化事件
//			doBeforeInit: function() {
//				$('#app_layout').appLayout();
////				var CurrentId=localStorage.getItem('CurrentIds');							
////				app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Module/GetModuleById/'+CurrentId+'/'+app.APP_GLOBE_STORE.LOGIN_USER.Id, function(data) {
////					appModuleButtonList = data.ButtonList;
////					appModuleColumnList = data.ColumnList
//////					appModule = data.module;					
////				});
//			},
//			doAfterInit: function() {
//				// 角色功能授权
//				$('#app_authorize').on('click', function() {
//					var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
//					if(app.BASE_UTILS.checkrow(keyValue)) {
//						layx.iframe(app.CommonIndexParams.form.id, '功能授权', '../../Role/html/authorize.html?keyValue=' + keyValue, {
//							shadable: true,
//							statusBar: true,
//							height:550,
//							width: 750
//	
//						});
//					}
//				});
//			}
//		},
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
//				doBeforeEvent: function () {
//					return {
//						result: true,
//						data: {
//							addParams: "?ModuleId=" + moduleId
//						}
//					};
//				}
			}
		},

		grid: { //grid 
			options: {
				url: '/api/Role/GetByPagesAsync',
				//rowdatas: roledata,
				headData: [{
						label: '角色编号',
						name: 'encode',
						width: 100,
						align: "center"
					},
					{
						label: '角色名称',
						name: 'fullname',
						width: 200,
						align: "center"
					},
					{
						label: '创建时间',
						name: 'creatortime',
						width: 130,
						align: 'center',
						formatter: function(cellvalue) {
							if(cellvalue) {
								return app.BASE_UTILS.Date.get_yyyy_MM_dd(new Date(cellvalue));
							} else {
								return '';
							}
						}
					},
					{
						label: '创建人',
						name: 'creatoruserId',
						width: 130,
						align: 'center'
					},
					{
						label: "有效",
						name: "enabledmark",
						width: 50,
						align: "center",
						formatter: function(cellvalue) {
							return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
						}
					},
					{																								
						label: "角色描述",
						name: "description",
						index: "description",
						width: 300,
						align: "center"
					}
				],
			}
		}
	};
	$(function() {
//		alert(app.APP_GLOBE_STORE.LOGIN_USER.Id)		
		app.CommonIndexEvent.init(options);
	})
})(window.jQuery, top.app)