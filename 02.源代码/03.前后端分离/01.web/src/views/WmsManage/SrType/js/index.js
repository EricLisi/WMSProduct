var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "SrType",
			form: {
				title: "收发类别",
				width: 800,
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
					"EnCode": "SO",
					"FullName": "销售出库",
					"OrganizationId": "8b52fb58-d4b0-4ca7-b347-5a289fd1515f",
					"SrFlag": 0,
					"Description": "",
					"SortCode": 0,
					"DeleteMark": false,
					"EnabledMark": false,
					"CreatorTime": "1900-01-01 00:00:00",
					"CreatorUserId": "",
					"LastModifyTime": "1900-01-01 00:00:00",
					"LastModifyUserId": "",
					"DeleteTime": "1900-01-01 00:00:00",
					"DeleteUserId": "",
					"Id": "227a1331-1210-4045-acb2-1cc6e36786c8",
					"ParentId": null,
					"CurrentLoginUserId": null,
					"Data1": null,
					"Data2": null,
					"Data3": null
				}, {
					"EnCode": "PI",
					"FullName": "采购入库",
					"OrganizationId": "5846e083-841c-4037-bf19-61e15acb034d",
					"SrFlag": 0,
					"Description": "",
					"SortCode": 0,
					"DeleteMark": false,
					"EnabledMark": false,
					"CreatorTime": "1900-01-01 00:00:00",
					"CreatorUserId": "",
					"LastModifyTime": "1900-01-01 00:00:00",
					"LastModifyUserId": "",
					"DeleteTime": "1900-01-01 00:00:00",
					"DeleteUserId": "",
					"Id": "f582a493-23ff-44bb-9c3e-37687d1cf28f",
					"ParentId": null,
					"CurrentLoginUserId": null,
					"Data1": null,
					"Data2": null,
					"Data3": null
				}],
				headData: [					                  
					{
						label: '收发类别编码',
						name: 'EnCode',
						width: 100,
						align: "center"
					},
					{
						label: '收发类别名称',
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