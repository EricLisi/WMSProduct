var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "StockCycleReport",
			form: {
				title: "库存周期报表",
				type: "tab",
				width: 750,
				height: 450,
				doBeforeEdit: function (key) {                   
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
				//url: '/api/StockCycleReport/GatPagerListByWhere/'+ app.APP_GLOBE_STORE.LOGIN_USER.Id,				
				rowdatas: [{
					"OrganizationId": "",
					"WarehouseId": "1",
					"SupplierId": "",
					"SrTypeId": "",
					"OwnershipId": "",
					"Maker": "",
					"Date": "2019-01-03 10:34:07",
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
					"SupplierCode": "",
					"SupplierName": "",
					"SupplierClassId": "",
					"SupplierContacts": "",
					"SupplierTelePhone": "",
					"SupplierMobilePhone": "",
					"SupplierEmail": "",
					"SupplierWeChat": "",
					"SupplierFax": "",
					"SupplierAddress": "",
					"SupplierDefine1": "",
					"SupplierDefine2": "",
					"SupplierDefine3": "",
					"SupplierDefine4": "",
					"SupplierDefine5": "",
					"SupplierDefine6": "",
					"SupplierDefine7": "",
					"SupplierDefine8": "",
					"SupplierDefine9": "",
					"SupplierDefine10": "",
					"SupplierDescription": "",
					"WarehouseCode": "001",
					"WarehouseName": "上海仓",
					"WarehouseContacts": "老李",
					"WarehouseTelePhone": "132XXXXXX",
					"WarehouseMobilePhone": "",
					"WarehouseEmail": "21123328481@qq.com",
					"WarehouseWeChat": "152XXXXXXX",
					"WarehouseFax": "021-11111",
					"WarehouseAddress": "上海市闵行区中春路",
					"WarehouseDefine1": "",
					"WarehouseDefine2": "",
					"WarehouseDefine3": "",
					"WarehouseDefine4": "",
					"WarehouseDefine5": "",
					"WarehouseDefine6": "",
					"WarehouseDefine7": "",
					"WarehouseDefine8": "",
					"WarehouseDefine9": "",
					"WarehouseDefine10": "",
					"WarehouseDescription": "",
					"SrTypeCode": "",
					"SrTypeName": "",
					"Id": "1C9D2159-5E7D-48F7-BF8B-77925B2FB752",
					"ParentId": null,
					"EnCode": "201901010001",
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
				}, {
					"OrganizationId": "",
					"WarehouseId": "1",
					"SupplierId": "",
					"SrTypeId": "",
					"OwnershipId": "",
					"Maker": "",
					"Date": "2019-01-03 10:34:07",
					"Verifier": "",
					"Veridate": "1900-01-01 00:00:00",
					"Status": 1,
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
					"SupplierCode": "",
					"SupplierName": "",
					"SupplierClassId": "",
					"SupplierContacts": "",
					"SupplierTelePhone": "",
					"SupplierMobilePhone": "",
					"SupplierEmail": "",
					"SupplierWeChat": "",
					"SupplierFax": "",
					"SupplierAddress": "",
					"SupplierDefine1": "",
					"SupplierDefine2": "",
					"SupplierDefine3": "",
					"SupplierDefine4": "",
					"SupplierDefine5": "",
					"SupplierDefine6": "",
					"SupplierDefine7": "",
					"SupplierDefine8": "",
					"SupplierDefine9": "",
					"SupplierDefine10": "",
					"SupplierDescription": "",
					"WarehouseCode": "001",
					"WarehouseName": "上海仓",
					"WarehouseContacts": "老李",
					"WarehouseTelePhone": "132XXXXXX",
					"WarehouseMobilePhone": "",
					"WarehouseEmail": "21123328481@qq.com",
					"WarehouseWeChat": "152XXXXXXX",
					"WarehouseFax": "021-11111",
					"WarehouseAddress": "上海市闵行区中春路",
					"WarehouseDefine1": "",
					"WarehouseDefine2": "",
					"WarehouseDefine3": "",
					"WarehouseDefine4": "",
					"WarehouseDefine5": "",
					"WarehouseDefine6": "",
					"WarehouseDefine7": "",
					"WarehouseDefine8": "",
					"WarehouseDefine9": "",
					"WarehouseDefine10": "",
					"WarehouseDescription": "",
					"SrTypeCode": "",
					"SrTypeName": "",
					"Id": "5E976598-37F3-48A3-A9B4-5F961BF88349",
					"ParentId": null,
					"EnCode": "201901010002",
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
				headData: [					 
					{
						label: "客户代码",
						name: "CustomerId",
						width: 130,
						align: "center"
					},
					{
						label: "货号",
						name: "Maker",
						width: 130,
						align: "center"
					},
					{
						label: "商品名称",
						name: "ProductName",
						width: 130,
						align: "center"
					},
					{
						label: "商品编码",
						name: "ProductBarcode",
						width: 130,
						align: "center"
					},
					{
						label: '自定义1',
						name: 'Define1',
						width: 150,
						align: "center"
					},
					{
						label: '自定义2',
						name: 'Define2',
						width: 100,
						align: 'center'
					},
					{
						label: '自定义3',
						name: 'Define3',
						width: 200,
						align: 'left'
					},
					{
						label: '数量',
						name: 'Qty',
						width: 120,
						align: 'center'
					},
					{
						label: '入库日期',
						name: 'IDate',
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
						label: '入库单号',
						name: 'Inno',
						width: 120,
						align: 'center'
					},
					{
						label: '出库日期',
						name: 'ODate',
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
						label: '出库单号',
						name: 'Outno',
						width: 200,
						align: 'center'
					},
					{
						label: '在仓天数',
						name: 'Stoday',
						width: 100,
						align: "center"
					},					
					{
						label: '<30天',
						name: 'Less30',
						width: 100,
						align: "center"
					},				
					{
						label: '30天<进库日期<60天',
						name: 'Betwen3060',
						width: 100,
						align: "center"
					},
					{
						label: "60天<进库日期<90天",
						name: "Betwen6090",
						width: 100,
						align: "center"
					},
					{
						label: ">90天",
						name: "More90",
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