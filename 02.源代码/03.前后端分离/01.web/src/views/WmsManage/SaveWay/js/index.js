var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "SaveWay",
			form: {
				title: "结算方式",
				width: 400,
				height: 300
			}
		},
		Event: { //初始化事件
			doBeforeInit: function() {
				$('#app_layout').appLayout();
				var CurrentId = localStorage.getItem('CurrentIds');
				app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Module/GetModuleById/' + CurrentId + '/' + app.APP_GLOBE_STORE.LOGIN_USER.Id, function(data) {
					appModuleButtonList = data.ButtonList;
					appModuleColumnList = data.ColumnList
					//appModule = data.module;					
				});
			},
//			doAfterInit: function() {
//				// 启用仓库
//				$('#app-ableWarStatus').on('click', function() {
//					var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
////					alert($('.appgrid-selected i').eq(0).attr("class"))
////					if(app.BASE_UTILS.checkrow(keyValue)) {
////						app.MODAL_UTILS.confirm({
////							msg: "是否确认要【启用】仓库！",
////							callback: function() {
////								var param = {
////									EnabledMark: true
////								};
////								layx.load('loadId', '数据正在启用中，请稍后');
////								app.HTTP_REQUEST_UTILS.httpAsyncPut(keyValue, '/api' + app.CommonIndexParams.router + '/UpByState', param, function(data) {
////									layx.destroy('loadId');
////									if(data.status) {
////										app.MODAL_UTILS.success(data.message);
////										refreshGirdData();
////									} else {
////										app.MODAL_UTILS.error(data.message)
////									}
////								});
////							}
////						})
////					}
//				});
//				// 禁用仓库
//				$('#app-unableWarStatus').on('click', function() {
//					var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
//					alert($('.appgrid-selected span').eq(0).html())
////					if(app.BASE_UTILS.checkrow(keyValue)) {
////						app.MODAL_UTILS.confirm({
////							msg: "是否确认要【禁用】仓库！",
////							callback: function() {
////								var param = {
////									EnabledMark: false
////								};
////								layx.load('loadId', '数据正在禁用中，请稍后');
////								app.HTTP_REQUEST_UTILS.httpAsyncPut(keyValue, '/api' + app.CommonIndexParams.router + '/UpByState', param, function(data) {
////									layx.destroy('loadId');
////									if(data.status) {
////										app.MODAL_UTILS.success(data.message);
////										refreshGirdData();
////									} else {
////										app.MODAL_UTILS.error(data.message)
////									}
////								});
////							}
////						})
////					}
//				});
//				// 启用货位
//				$('#app_ablePoStatus').on('click', function() {
//					var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
////					if(app.BASE_UTILS.checkrow(keyValue)) {
////						app.MODAL_UTILS.confirm({
////							msg: "是否确认要【启用】货位！",
////							callback: function() {
////								var param = {
////									EnabledMark: true
////								};
////								layx.load('loadId', '数据正在启用中，请稍后');
////								app.HTTP_REQUEST_UTILS.httpAsyncPut(keyValue, '/api' + app.CommonIndexParams.router + '/UpByState', param, function(data) {
////									layx.destroy('loadId');
////									if(data.status) {
////										app.MODAL_UTILS.success(data.message);
////										refreshGirdData();
////									} else {
////										app.MODAL_UTILS.error(data.message)
////									}
////								});
////							}
////						})
////					}
//				});
//				// 禁用货位
//				$('#app_ablePoStatus').on('click', function() {
//					var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
////					if(app.BASE_UTILS.checkrow(keyValue)) {
////						app.MODAL_UTILS.confirm({
////							msg: "是否确认要【禁用】货位！",
////							callback: function() {
////								var param = {
////									EnabledMark: false
////								};
////								layx.load('loadId', '数据正在禁用中，请稍后');
////								app.HTTP_REQUEST_UTILS.httpAsyncPut(keyValue, '/api' + app.CommonIndexParams.router + '/UpByState', param, function(data) {
////									layx.destroy('loadId');
////									if(data.status) {
////										app.MODAL_UTILS.success(data.message);
////										refreshGirdData();
////									} else {
////										app.MODAL_UTILS.error(data.message)
////									}
////								});
////							}
////						})
////					}
//				});
//			}
		},
		search: { //搜索	
		},
		tree: { //启用左侧树形			
		},
		bindEvent: { //点击事件参数 
			add: {

			}
		},

		grid: { //grid 
			options: {
				url: '/api/SaveWay/GatPagerListByWhere/'+app.APP_GLOBE_STORE.LOGIN_USER.Id,				
//			rowdatas: [{
//									"Id": "6903ab9d-20cd-44c4-a380-09f229366e1f",
//									"EnCode": "001",
//									"FullName": "MM",
//									'Description': '2222222222'
//								}, {
//									"Id": "abe9fcf1-1879-41b1-948d-05d514102934",
//									"EnCode": "002",
//									"FullName": "QQ",
//									'Description': '55555555'
//								}],
				headData: [
//                  {
//						label: '仓库编号',
//						name: 'Id',
//						width: 100,
//						align: "center"
//					},
					{
						label: '结算方式编码',
						name: 'EnCode',
						width: 100,
						align: "center"
					},
					{
						label: '结算方式名称',
						name: 'FullName',
						width: 100,
						align: "center"
					},
					{
						label: "备注",
						name: "Description",
						index: "Description",
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