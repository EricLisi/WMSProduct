var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "Customer",
			form: {
				id: "Customer",
				title: "菜单",
				width: 750,
				height: 550,
				type:'tab'
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
			doBeforeInit: function() {
				$('#app_layout').appLayout();
//				var CurrentId = localStorage.getItem('CurrentIds');
//				app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Module/GetModuleById/' + CurrentId + '/' + app.APP_GLOBE_STORE.LOGIN_USER.Id, function(data) {
//					appModuleButtonList = data.ButtonList;
//					appModuleColumnList = data.ColumnList
//					//					appModule = data.module;					
//				});
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
				url: '/api/Customer/GetCustomerByPages',
				headData: [
					{ label: '客户代码', name: 'encode', width: 100, align: "center"},
					{ label: '客户名称', name: 'fullname', width: 100,align: "center"},
					{ label: '联系人', name: 'person', width: 100, align: 'center'},
					{ label: '电话', name: 'phone', width: 100, align: 'center'},
					{ label: '手机', name: 'mobile', width: 100, align: 'center'},
					{ label: '邮箱', name: 'email', width: 100, align: 'center'},
// 					{ label: '传真', name: 'Fax', width: 100, align: 'center'},
//					{label: '微信', name: 'WeChat', width: 100, align: 'center'},
					{ label: '客户省份', name: 'province', width: 100, align: 'center',
						formatter: function(cellvalue, rowObject) {						
							var data = app.APP_GLOBE_STORE_UTILS.getKeyValue('PROVINCE', {
								key: "Id",
								value: cellvalue
							})
							return !!data ? data.FullName: cellvalue
						}
					},					
					{ label: '客户城市', name: 'city', width: 100, align: 'center',
						formatter: function(cellvalue, rowObject) {
							var data = app.APP_GLOBE_STORE_UTILS.getKeyValue('CITY', {
								key: "Id",
								value: cellvalue
							})
							return !!data ? data.FullName : cellvalue
						}
					},					
					{ label: '客户地址', name: 'address', width: 100, align: 'center'},
//					{ label: '免租期', name: 'NoRentTime', width: 100, align: 'center'},
//					{ label: '仓储费单价', name: 'UnitPrice', width: 100, align: 'center'},				
//					{ label: '客户权属', name: 'Ownership', width: 100, align: 'center'},
					{ label: "备注", name: "description", index: "Description", width: 300, align: "center"}
				],
			}
		}
	};
	$(function() {
		//alert(app.APP_GLOBE_STORE.LOGIN_USER.Id)		
		app.CommonIndexEvent.init(options);
	})
})(window.jQuery, top.app)