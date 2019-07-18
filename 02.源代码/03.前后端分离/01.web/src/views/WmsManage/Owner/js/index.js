var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "Owner",
			form: {
				title: "权属",
				width: 400,
				height: 350
			}
		},
		Event: { //初始化事件
			doBeforeInit: function() {
				$('#app_layout').appLayout();
				var CurrentId = localStorage.getItem('CurrentIds');
				app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Module/GetModuleById/' + CurrentId + '/' + app.APP_GLOBE_STORE.LOGIN_USER.Id, function(data) {
					appModuleButtonList = data.ButtonList;
					appModuleColumnList = data.ColumnList
					//					appModule = data.module;					
				});
			}
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
				url: '/api/Owner/GatPagerListByWhere/' + app.APP_GLOBE_STORE.LOGIN_USER.Id,
//				rowdatas: [{
//									"Id": "6903ab9d-20cd-44c4-a380-09f229366e1f",
//									"EnCode": "001",
//									"FullName": "权属1",
//									'Description': '2222222222'
//								}, {
//									"Id": "abe9fcf1-1879-41b1-948d-05d514102934",
//									"EnCode": "002",
//									"FullName": "权属2",
//									'Description': '55555555'
//								}],
				headData: [{
						label: '权属编码',
						name: 'EnCode',
						width: 100,
						align: "center"
					},
					{
						label: '权属名称',
						name: 'FullName',
						width: 100,
						align: "center"
					},
					{
						label: '客户编码',
						name: 'CustomerCode',
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