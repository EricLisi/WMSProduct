var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "OutStockNotice",
			form: {
				title: "出库通知单",
				type: "tab",
				width: 750,
				height: 450,
				doBeforeEdit: function (key) {
                     alert(11111111)
                     return true;
                }
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
				url: '/api/OutStockNotice/GatPagerListByWhere/'+app.APP_GLOBE_STORE.LOGIN_USER.Id,
//				rowdatas: [{
//					"Veridate": "",
//					"Verifier": "",
//					"Id": "1C9D2159-5E7D-48F7-BF8B-77925B2FB752",
//					"OrderNo":'RKTZ20190409001',
//					"CustomerId": '001',
//					"WarehouseId":'001',
//					"ExpCompany":'顺丰快递',
//					"ExpNo":'SF201904110001',
//					"ReceivePerson":'张三',
//					"ReceivePersonTel":'511-201400',
//					"ReceiveAddress":'XXXXXXX',
//					"SrTypeId":'出库通知',
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
//					"OrderNo":'RKTZ20190409002',
//					"ReceivePerson":'李四',
//					"ReceivePersonTel":'511-201400',
//					"ReceiveAddress":'XXXXXXX',
//					"CustomerId": '002',
//					"WarehouseId":'002',
//					"ExpCompany":'中通快递',
//					"ExpNo":'SF201904110002',
//					"SrTypeId":'出库通知',
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
								return '<span class=\"label label-danger\" style=\"cursor: pointer;\">已关闭</span>';
							}
						}
					},
					{
						label: '发运方式',
						name: 'SendType',
						width: 100,
						align: "center",
						formatter: function(cellvalue) {
							if(cellvalue == 1) {
								return '<span class=\"label label-danger\" style=\"cursor: pointer;\">货运</span>';
							} else if(cellvalue == 0) {
								return '<span class=\"label label-success\" style=\"cursor: pointer;\">快递</span>';
							}
						}
					},
					{
						label: "单据号",
						name: "OrderNo",
						width: 130,
						align: "center"
					}, 
//					{
//						label: "拣货单号",
//						name: "Define6",
//						width: 130,
//						align: "center"
//					},
					{
						label: "客户代码",
						name: "CustomerId",
						width: 130,
						align: "center"
					},
					{
						label: "仓库代码",
						name: "WarehouseId",
						width: 130,
						align: "center"
					},
					{
						label: '收发类别',
						name: 'SrTypeId',
						width: 150,
						align: "center"
					},
//					{
//						label: '件数',
//						name: 'Single',
//						width: 100,
//						align: 'center'
//					},
					{
						label: '快递公司',
						name: 'ExpCompanyId',
						width: 200,
						align: 'left'
					},
					{
						label: '快递单号',
						name: 'ExpNo',
						width: 120,
						align: 'center'
					},
					{
						label: '收件人',
						name: 'ReceivePerson',
						width: 120,
						align: 'center'
					},
					{
						label: '收件人联系方式',
						name: 'ReceivePersonTel',
						width: 120,
						align: 'center'
					},
					{
						label: '收货地址',
						name: 'ReceiveAddress',
						width: 200,
						align: 'center'
					},
					{
						label: '制单人',
						name: 'Maker',
						width: 100,
						align: "center"
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
						align: "center",
						formatter: function(cellvalue) {
							if(cellvalue) {
								return app.BASE_UTILS.Date.get_yyyy_MM_dd(new Date(cellvalue));
							} else {
								return '';
							}
						}
					},
//					{
//						label: '外部单号',
//						name: 'Define1',
//						width: 100,
//						align: "center"
//					},
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