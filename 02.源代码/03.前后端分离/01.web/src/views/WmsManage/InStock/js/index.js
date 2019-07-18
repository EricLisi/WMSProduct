(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "InStock",
			form: {
				title: "入库单",
				width: 750,
				height: 450,
				type: "tab",
			}
		},
		Event: { //初始化事件
			doBeforeInit: function() {
				$('#app_layout').appLayout();
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
				url: '/api/InStock/GatPagerListByWhere/'+app.APP_GLOBE_STORE.LOGIN_USER.Id,
//				rowdatas: [{
//					"Veridate": "",
//					"Verifier": "",
//					"Id": "1C9D2159-5E7D-48F7-BF8B-77925B2FB752",
//					"ParentOrderNo":'RKTZ20190409001',
//					"OrderNo":'RK20190409001',
//					"CustomId": '001',
//					"WarehouseId":'001',
//					"SrTypeId":'入库单',
//					"OwnerId":'001',
//					"Maker": "admin",
//					"Date": "1900-01-01 00:00:00",
//					"SortCode": 0,
//					"DeleteMark": false,
//					"EnabledMark": false,
//					"Description": "",
//					"CreatorTime": "1900-01-01 00:00:00",
//					"CreatorUserId": "",
//					"LastModifyTime": "1900-01-01 00:00:00",
//					"LastModifyUserId": "",
//					"DeleteTime": "1900-01-01 00:00:00",
//					"DeleteUserId": "",
//					"CurrentLoginUserId": null,
//					"Data1": null,
//					"Data2": null,
//					"Data3": null,
//					"Status":'0'
//				}, {
//					"Veridate": "",
//					"Verifier": "",
//					"Id": "55555",
//					"ParentOrderNo":'RKTZ20190409002',
//					"OrderNo":'RK20190409002',
//					"CustomId": '002',
//					"WarehouseId":'002',
//					"SrTypeId":'入库单',
//					"OwnerId":'002',
//					"Maker": "admin",
//					"Date": "1900-01-01 00:00:00",
//					"SortCode": 0,
//					"DeleteMark": false,
//					"EnabledMark": false,
//					"Description": "",
//					"CreatorTime": "1900-01-01 00:00:00",
//					"CreatorUserId": "",
//					"LastModifyTime": "1900-01-01 00:00:00",
//					"LastModifyUserId": "",
//					"DeleteTime": "1900-01-01 00:00:00",
//					"DeleteUserId": "",
//					"CurrentLoginUserId": null,
//					"Data1": null,
//					"Data2": null,
//					"Data3": null,
//					"Status":'0'
//				}],
				headData: [{
						label: '状态',
						name: 'Status',
						width: 100,
						align: "center",
						formatter: function(cellvalue) {
							if(cellvalue == 1) {
								return '<span class=\"label label-success\" style=\"cursor: pointer;\">已审核</span>';
							} else if(cellvalue == 0) {
								return '<span class=\"label label-default\" style=\"cursor: pointer;\">待审核</span>';
							} else if(cellvalue == 2) {
								return '<span class=\"label label-danger\" style=\"cursor: pointer;\">待上架</span>';
							}
						}
					},
					{
						label: "单据号",
						name: "OrderNo",
						width: 130,
						align: "center"
					},
					{
						label: "来源单号",
						name: "ParentOrderNo",
						width: 130,
						align: "center"
					},
					{
						label: "客户",
						name: "CustomId",
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
						label: '收发类别',
						name: 'SrTypeId',
						width: 150,
						align: "center"
					},
					{
						label: '权属',
						name: 'OwnerId',
						width: 150,
						align: "center"
					},
					{
						label: '制单人',
						name: 'Maker',
						width: 100,
						align: "center"
					},
					{
						label: "单据时间",
						name: "Date",
						width: 100,
						align: "center",
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
						name: 'Verifier',
						width: 100,
						align: "center"
					},
					{
						label: '审核时间',
						name: 'Veridate',
						width: 150,
						align: "center"
					},
					{
						label: "备注",
						name: "Description",
						width: 100,
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