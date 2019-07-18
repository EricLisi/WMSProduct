var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "Pack",
			form: {
				title: "产品拣货单",
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
				//url: '/api/'+router+'/GatPagerListByWhere/'+ app.APP_GLOBE_STORE.LOGIN_USER.Id,				
				rowdatas: [{
					"Veridate": "",
					"Verifier": "",
					"Id": "1C9D2159-5E7D-48F7-BF8B-77925B2FB752",
					"PackTypey":'0',
					"OrderNo":'CK20190409001',
					"CustomerId": '001',
					"OwnerId":'001',
					"WarehouseId":'001',
					"ParentOrderNo":'CKTZ201904110001',
					"Maker": "admin",
					"Date": "1900-01-01 00:00:00",
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
					"Data3": null,
					"Status":'0'
				}, {
					"Veridate": "",
					"Verifier": "",
					"Id": "5555555",
					"PackTypey":'1',
					"OrderNo":'CK20190409002',
					"CustomerId": '001',
					"OwnerId":'001',
					"WarehouseId":'001',
					"ParentOrderNo":'CKTZ201904110001',
					"Maker": "admin",
					"Date": "1900-01-01 00:00:00",
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
					"Data3": null,
					"Status":'1'
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
						label: "单据类型",
						name: "PackTypey",
						index: "PackTypey",
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
						name: 'OrderNo',
						width: 130,
						align: "center"
					},
					{
						label: "客户",
						name: "CustomerId",
						width: 130,
						align: "center"
					},
					{
						label: "权属",
						name: "OwnerId",
						width: 130,
						align: "center"
					},
					{
						label: '仓库',
						name: 'WarehouseId',
						width: 150,
						align: "center"
					},
					{
						label: '发货单号',
						name: 'ParentOrderNo',
						width: 250,
						align: 'left'
					},
					{
						label: '制单人',
						name: 'Maker',
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