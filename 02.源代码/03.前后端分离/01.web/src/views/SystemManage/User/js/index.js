var companyId = '';
var appModuleButtonList;
var appModuleColumnList;

(function($, app) {
	"use strict";

	//var departmentId = '';
	//点击左侧树
//	var nodeclick = function(item) {
//		companyId = item.id;
//		$('#titleinfo').text(item.text);
//		var param = {
//			companyId: item.id
//		};
//		$("#" + app.CommonIndexParams.grid.id).appGridSet('reload', param);
//	}

	var options = {
		params: { //参数
			router: "/User",
			form: {
				title: "用戶",
				width: 750,
				height: 500
			}
		},
		Event: { //初始化事件
			doBeforeInit: function() {
				$('#app_layout').appLayout();
			},
			doAfterInit: function() {
				// 启用用户
				$('#app_enabled').on('click', function() {
					var keyValue = $('#gridtable').appGridValue('id');
					if(!!!keyValue)
					{
						app.MODAL_UTILS.error("请选择一行数据！")
						return;
					}
					if(app.BASE_UTILS.checkrow(keyValue)) {
						app.MODAL_UTILS.confirm({
							msg: "是否确认要【启用】账号！",
							callback: function() {
								var param = {
									enablemark: true
								};
								layx.load('loadId', '数据正在启用中，请稍后');
								app.HTTP_REQUEST_UTILS.httpAsyncPut(keyValue, '/api/User/UpByState', param, function(data) {
									layx.destroy('loadId');
									if(data.status) {
										app.MODAL_UTILS.success(data.message);
										refreshGirdData();
									} else {
										app.MODAL_UTILS.error(data.message)
									}
								});
							}
						})
					}
				});
				 //禁用用户
				$('#app_disabled').on('click', function() {
					if(!!!keyValue)
					{
						app.MODAL_UTILS.error("请选择一行数据！")
						return;
					}
					if(app.BASE_UTILS.checkrow(keyValue)) {
						app.MODAL_UTILS.confirm({
							msg: "是否确认要【禁用】账号！",
							callback: function() {
								var param = {
									enablemark: false
								};
								layx.load('loadId', '数据正在禁用中，请稍后');
								app.HTTP_REQUEST_UTILS.httpAsyncPut(keyValue, '/api/User/UpByState', param, function(data) {
									layx.destroy('loadId');
									if(data.status) {
										app.MODAL_UTILS.success(data.message);
										refreshGirdData();
									} else {
										app.MODAL_UTILS.error(data.message)
									}
								});
	
							}
						})
					}
				});
				 //重置账号
				$('#app_resetpassword').on('click', function() {
					if(!!!keyValue)
					{
						app.MODAL_UTILS.error("请选择一行数据！")
						return;
					}
					if(app.BASE_UTILS.checkrow(keyValue)) {
						app.MODAL_UTILS.confirm({
							msg: "是否确认要【重置密码】！",
							callback: function() {
								layx.load('loadId', '密码正在重置中，请稍后');
								app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/User/ResetPassword/' + keyValue, function() {
									layx.destroy('loadId');
									if(data.status) {
										app.MODAL_UTILS.success(data.message);
									} else {
										app.MODAL_UTILS.error(data.message)
									}
								});
	
							}
						})
					}
				});
				// 用户机构功能授权
//				$('#app_authorize1').on('click', function() {
//					var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
//					if(app.BASE_UTILS.checkrow(keyValue)) {
//						layx.iframe(app.CommonIndexParams.form.id, '功能授权', '../../User/html/authorize.html?keyValue=' + keyValue, {
//							shadable: true,
//							statusBar: true,
//							height: 550,
//							width: 690
//	
//						});
//					}
//				});
			}
		},
		search: { //搜索						
			setSearchParams: function () {
				return {
					userid: app.APP_GLOBE_STORE.LOGIN_USER.Id,
					realname: $("#txtName").val()
				}
			}
		},
		tree: { //启用左侧树形
//			options: {
//				id: "companyTree",
//				url: '/api/Company/GetTreeJson',
//				nodeClick: nodeclick
//			}
		},
		bindEvent: { //点击事件参数 
			add: {
//				doBeforeEvent: function() {
//					if(!!!companyId) {
//						app.MODAL_UTILS.warning("请先选择公司!")
//						return {
//							result: false,
//							data: null
//						}
//					}
//					return {
//						result: true,
//						data: {
//							addParams: "?companyId=" + companyId
//						}
//					};
//				}
			}

		},

		grid: { //grid 
			options: {
				url: '/api/User/GetByPages',
					param: {
					userid: app.APP_GLOBE_STORE.LOGIN_USER.id
				},
				//rowdatas: usergriddata,
				headData: [{
						label: '账户',
						name: 'account',
						width: 100,
						align: "center"
					},
					{
						label: '姓名',
						name: 'realname',
						width: 160,
						align: "center"
					},
					{
						label: '性别',
						name: 'gender',
						width: 45,
						align: 'center',
						formatter: function(cellvalue) {
							return cellvalue == 0 ? "女" : "男";
						}
					},
					{
						label: '手机',
						name: 'mobile',
						width: 100,
						align: 'center'
					},
					//					{
					//						label: '公司',
					//						name: 'CompanyId',
					//						width: 100,
					//						align: "center",
					//					    formatter: function (cellvalue, rowObject) { 
					//					    	//alert(JSON.stringify(app.APP_GLOBE_STORE.DATA_STATUS['COMPANY']))
					//							var data = app.APP_GLOBE_STORE_UTILS.getKeyValue('COMPANY',{
					//								key:"id",
					//								value:cellvalue
					//							})
					//							 
					//							return !!data?data.text:cellvalue
					//						}
					//					},
					{
						label: '仓库名称',
						name: 'warehouseid',
						width: 100,
						align: 'center'
					},
//					{
//						label: '仓库编码',
//						name: 'WarehouseId',
//						width: 100,
//						align: 'center'
//					},				
					{
						label: '部门名称',
						name: 'departmentid',
						width: 100,
						align: "center",
						formatter: function(cellvalue, rowObject) {							
							var data = app.APP_GLOBE_STORE_UTILS.getKeyValue('DEPARTMENT', {
								key: "id",
								value: cellvalue
							})
							return !!data ? data.text : cellvalue
						}
					},
					{
						label: "状态",
						name: "enabledmark",
						index: "enabledark",
						width: 50,
						align: "center",
						formatter: function(cellvalue) {
							if(cellvalue == 1) {
								return '<span class=\"label label-success\" style=\"cursor: pointer;\">正常</span>';
							} else if(cellvalue == 0) {
								return '<span class=\"label label-default\" style=\"cursor: pointer;\">禁用</span>';
							}
						}
					},
					{
						label: "备注",
						name: "description",
						index: "description",
						width: 200,
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