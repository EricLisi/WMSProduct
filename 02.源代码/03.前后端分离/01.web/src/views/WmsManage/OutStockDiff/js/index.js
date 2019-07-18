var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "OutStockDiff",
			form: {
				title: "发货差异处理",
				width: 800,
				height: 450,
				type: 'tab'
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
				//url: '/api/OutStockDiff/GatPagerListByWhere/' + app.APP_GLOBE_STORE.LOGIN_USER.Id,
				rowdatas: [{					
					"CustomerId": "",
					"WarehouseId": "",					
					"OwnershipId": "",
					"Maker": "",
					"Date": "1900-01-01 00:00:00",
					"Verifier": "",
					"Veridate": "1900-01-01 00:00:00",
					"Status": 0,
					"Id": "1",
					"ParentId": null,
					"EnCode": "233445",
					"FullName": null,					
					"Ordertype":1,					
					"CreatorTime": "1900-01-01 00:00:00"							
				}],
				headData: [					
					{
						label: "单据类型",
						name: "Ordertype",
						index: "Ordertype",
						width: 100,
						align: "center",
						formatter: function(cellvalue) {
							if(cellvalue == 0) {
								return '<span class=\"label label-success\" style=\"cursor: pointer;\">摘果式</span>';
							} else {
								return '<span class=\"label label-danger\" style=\"cursor: pointer;\">播种式</span>';
							}
						}
					},
					{
						label: '单据号',
						name: 'EnCode',
						width: 100,
						align: "center"
					},
					{
						label: "客户",
						name: "CustomerName",
						width: 130,
						align: "center"
					},
					{
						label: "权属",
						name: "Property",
						width: 130,
						align: "center"
					},
					{
						label: '仓库',
						name: 'WarehouseName',
						width: 150,
						align: "center"
					},
					{
						label: '发货单号',
						name: 'Dpno',
						width: 150,
						align: "center"
					},
					{
						label: '制单人',
						name: 'CMaker',
						width: 100,
						align: 'center'
					},
					{
						label: '单据日期',
						name: 'Date',
						width: 100,
						align: 'center',
						formatter: function(cellvalue) {
							if(cellvalue) {
								return app.BASE_UTILS.Date.get_yyyy_MM_dd(new Date(cellvalue));
							} else {
								return '';
							}
						}
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