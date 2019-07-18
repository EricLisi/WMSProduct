var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "Warehouse",
			form: {
				title: "仓库",
				width: 800,
				height: 450,
				type:'tab'
			}
		},
		Event: { //初始化事件
			doBeforeInit: function() {
				$('#app_layout').appLayout();
			},
			doAfterInit: function() {
				// 启用仓库
//				$('#app-ableWarStatus').on('click', function() {
//					var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
//					alert($('.appgrid-selected i').eq(0).attr("class"))
//					if(app.BASE_UTILS.checkrow(keyValue)) {
//						app.MODAL_UTILS.confirm({
//							msg: "是否确认要【启用】仓库！",
//							callback: function() {
//								var param = {
//									EnabledMark: true
//								};
//								layx.load('loadId', '数据正在启用中，请稍后');
//								app.HTTP_REQUEST_UTILS.httpAsyncPut(keyValue, '/api' + app.CommonIndexParams.router + '/UpByState', param, function(data) {
//									layx.destroy('loadId');
//									if(data.status) {
//										app.MODAL_UTILS.success(data.message);
//										refreshGirdData();
//									} else {
//										app.MODAL_UTILS.error(data.message)
//									}
//								});
//							}
//						})
//					}
//				});
//				// 禁用仓库
//				$('#app-unableWarStatus').on('click', function() {
//					var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
//					alert($('.appgrid-selected span').eq(0).html())
//					if(app.BASE_UTILS.checkrow(keyValue)) {
//						app.MODAL_UTILS.confirm({
//							msg: "是否确认要【禁用】仓库！",
//							callback: function() {
//								var param = {
//									EnabledMark: false
//								};
//								layx.load('loadId', '数据正在禁用中，请稍后');
//								app.HTTP_REQUEST_UTILS.httpAsyncPut(keyValue, '/api' + app.CommonIndexParams.router + '/UpByState', param, function(data) {
//									layx.destroy('loadId');
//									if(data.status) {
//										app.MODAL_UTILS.success(data.message);
//										refreshGirdData();
//									} else {
//										app.MODAL_UTILS.error(data.message)
//									}
//								});
//							}
//						})
//					}
//				});
//				// 启用货位
//				$('#app_ablePoStatus').on('click', function() {
//					var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
//					if(app.BASE_UTILS.checkrow(keyValue)) {
//						app.MODAL_UTILS.confirm({
//							msg: "是否确认要【启用】货位！",
//							callback: function() {
//								var param = {
//									EnabledMark: true
//								};
//								layx.load('loadId', '数据正在启用中，请稍后');
//								app.HTTP_REQUEST_UTILS.httpAsyncPut(keyValue, '/api' + app.CommonIndexParams.router + '/UpByState', param, function(data) {
//									layx.destroy('loadId');
//									if(data.status) {
//										app.MODAL_UTILS.success(data.message);
//										refreshGirdData();
//									} else {
//										app.MODAL_UTILS.error(data.message)
//									}
//								});
//							}
//						})
//					}
//				});
//				// 禁用货位
//				$('#app_ablePoStatus').on('click', function() {
//					var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
//					if(app.BASE_UTILS.checkrow(keyValue)) {
//						app.MODAL_UTILS.confirm({
//							msg: "是否确认要【禁用】货位！",
//							callback: function() {
//								var param = {
//									EnabledMark: false
//								};
//								layx.load('loadId', '数据正在禁用中，请稍后');
//								app.HTTP_REQUEST_UTILS.httpAsyncPut(keyValue, '/api' + app.CommonIndexParams.router + '/UpByState', param, function(data) {
//									layx.destroy('loadId');
//									if(data.status) {
//										app.MODAL_UTILS.success(data.message);
//										refreshGirdData();
//									} else {
//										app.MODAL_UTILS.error(data.message)
//									}
//								});
//							}
//						})
//					}
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
				
			}
		},

		grid: { //grid 
			options: {
				url: '/api/Warehouse/GetWarehouseByPages',	
				headData: [
//                  {
//						label: '仓库编号',
//						name: 'Id',
//						width: 100,
//						align: "center"
//					},
					{
						label: '仓库编码',
						name: 'encode',
						width: 100,
						align: "center"
					},
					{
						label: '仓库名称',
						name: 'fullname',
						width: 100,
						align: "center"
					},
					{
						label: '联系人',
						name: 'whperson',
						width: 100,
						align: 'center'
					},
					{
						label: '邮箱',
						name: 'whemail',
						width: 100,
						align: 'center'
					},
						
					{
						label: '手机',
						name: 'whphone',
						width: 100,
						align: 'center'
					},
					{
						label: '地址',
						name: 'whaddress',
						width: 100,
						align: 'center'
					},

//					{
//						label: "仓库状态",
//						name: "enabledmark",
//						width: 120,
//						align: "center",
//						formatter: function(cellvalue) {
//							return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
//						}
//					},
//					{
//						label: "货位状态",
//						name: "PositionManagement",
//						width: 120,
//						align: "center",
//						formatter: function(cellvalue) {
//							return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
//						}
//					},
					{
						label: "备注",
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
		//alert(app.APP_GLOBE_STORE.LOGIN_USER.Id)		
		app.CommonIndexEvent.init(options);
	})
})(window.jQuery, top.app)