var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "PackList",
			form: {
				title: "出库拣货",
				width: 800,
				height: 450
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
				//url: '/api/Warehouse/GatPagerListByWhere',
				rowdatas: [{
					"OrganizationId": "",
					"CustomerId": "",
					"WarehouseId": "",
					"SrTypeId": "",
					"OwnershipId": "",
					"PackPolicy": 0,
					"Maker": "",
					"Date": "1900-01-01 00:00:00",
					"Verifier": "",
					"Veridate": "1900-01-01 00:00:00",
					"Status": 0,
					"SourceId": "",
					"SourceType": "",
					"SourceNo": "",
					"Define1": "",
					"Define2": "",
					"Define3": "",
					"Define4": "",
					"Define5": "",
					"Define6": "",
					"Define7": "",
					"Define8": "",
					"Define9": "",
					"Define10": "",
					"Id": "1",
					"ParentId": null,
					"EnCode": "2",
					"FullName": null,
					"SortCode": 0,
					"DeleteMark": false,
					"EnabledMark": false,
					"Description": "",
					"CreatorTime": "1900-01-01 00:00:00",
					"CreatorUserId": "",
					"LastModifyTime": "1900-01-01 00:00:00",
					"LastModifyUserId": "",
					"DeleteTime": "1900-01-01 00:00:00",
					"DeleteUserId": "",
					"CurrentLoginUserId": null,
					"Data1": null,
					"Data2": null,
					"Data3": null
				}],
				headData: [{
						label: "状态",
						name: "Status",
						index: "Status",
						width: 100,
						align: "center",
						formatter: function(cellvalue) {
							if(cellvalue == 1) {
								return '<span class=\"label label-success\" style=\"cursor: pointer;\">已审核</span>';
							} else if(cellvalue == 0) {
								return '<span class=\"label label-default\" style=\"cursor: pointer;\">待审核</span>';
							} else if(cellvalue == 2) {
								return '<span class=\"label label-danger\" style=\"cursor: pointer;\">已关闭</span>';
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
						label: '客户',
						name: 'SrTypeId',
						width: 100,
						align: 'center'
					},
//					{
//						label: '仓库',
//						name: 'WarehouseName',
//						width: 100,
//						align: "center"
//					},
//
//					{
//						label: '收发类别',
//						name: 'SrTypeId',
//						width: 100,
//						align: 'center'
//					},
					{
						label: '制单人',
						name: 'CMaker',
						width: 100,
						align: 'center'
					},
					{
						label: '单据时间',
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
					},
					{
						label: '审核人',
						name: 'Verify',
						width: 100,
						align: 'center'
					},
					{
						label: '审核时间',
						name: 'VeriDate',
						width: 100,
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