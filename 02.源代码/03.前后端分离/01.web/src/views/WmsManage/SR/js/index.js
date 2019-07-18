var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "SR",
			form: {
				title: "退货单",
				type: "tab",
				width: 750,
				height: 450,
				doBeforeEdit: function(key) {
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
				//url: '/api/SR/GatPagerListByWhere'+ app.APP_GLOBE_STORE.LOGIN_USER.Id,
					rowdatas: [{					
					"Id": "1C9D2159-5E7D-48F7-BF8B-77925B2FB752",
					"Status": "1",
					"EnCode": "201901010001",
					"CustomerName": "123",
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
						label: "退货单号",
						name: "EnCode",
						width: 130,
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
						label: "发货单号",
						name: "Dpno",
						width: 130,
						align: "center"
					},
					{
						label: '物流公司',
						name: 'Backexpname',
						width: 150,
						align: 'center'
					},
					{
						label: '物流单号',
						name: 'Backexpno',
						width: 150,
						align: 'center'
					},
					{
						label: '仓库',
						name: 'WarehouseName',
						width: 150,
						align: "center"
					},

					{
						label: '制单人',
						name: 'CMaker',
						width: 100,
						align: "center"
					},
					{
						label: '单据日期',
						name: 'DDate',
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
						align: "center"
					},
					{
						label: '审核时间',
						name: 'VeriDate',
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
					{
						label: '反馈信息',
						name: 'Csrdefine5',
						width: 150,
						align: 'center'
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