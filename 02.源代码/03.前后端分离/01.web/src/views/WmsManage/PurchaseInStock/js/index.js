(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "PurchaseInStock",
			form: {
				title: "入库单",
				width: 750,
				height: 450
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
				//url: '/api/PurchaseInStock/GatPagerListByWhere',
				rowdatas: [{
					"Id": "3587a099-980d-4342-864f-a9f48e90e03b",
					"CustomerId": "27607392-c60c-4ee6-9557-ef59f9410bbb",
					"SellerId": "7702ad2a-c3e9-411e-acef-0cc61bab0507",
					"OrderDate": "2017-08-11 00:00:00",
					"OrderCode": "SO0811000002",
					"DiscountSum": 0.00,
					"Accounts": 100.00,
					"ReceivedAmount": 1000.00,
					"PaymentDate": "2017-08-11 00:00:00",
					"PaymentMode": "1",
					"PaymentState": 2,
					"SaleCost": 0.00,
					"AbstractInfo": null,
					"ContractCode": null,
					"ContractFile": "76c2bd72-9d9c-05c2-9bb9-cccdb30b4751",
					"SortCode": null,
					"DeleteMark": null,
					"EnabledMark": null,
					"Description": null,
					"CreateDate": "2018-04-03 16:34:26",
					"CreateUserId": null,
					"CreateUserName": "徐晓悦",
					"ModifyDate": null,
					"ModifyUserId": null,
					"ModifyUserName": null
				}, {
					"Id": "0394fa78-047b-4662-af90-0ebd4ba2dcf2",
					"CustomerId": "6893bf56-e502-482f-9bd3-8c26532dc9a3",
					"SellerId": "1fc0e985-1373-4adc-b3a7-f68b89093f1c",
					"OrderDate": "2017-09-28 00:00:00",
					"OrderCode": "SO0928000001",
					"DiscountSum": null,
					"Accounts": 0.00,
					"ReceivedAmount": 56.00,
					"PaymentDate": "2017-09-28 00:00:00",
					"PaymentMode": null,
					"PaymentState": 2,
					"SaleCost": 56.00,
					"AbstractInfo": null,
					"ContractCode": null,
					"ContractFile": "fd8248bb-35a2-76f3-9ed0-e522496ecd45",
					"SortCode": null,
					"DeleteMark": null,
					"EnabledMark": null,
					"Description": "55555555",
					"CreateDate": "2018-04-03 16:33:12",
					"CreateUserId": "System",
					"CreateUserName": null,
					"ModifyDate": null,
					"ModifyUserId": null,
					"ModifyUserName": "555555555"
				}],
				headData: [{
						label: "主键",
						name: "Id",
						width: 100,
						align: "left"

					},
					{
						label: "单据编号",
						name: "OrderCode",
						width: 130,
						align: "left"
					},
					{
						label: "供应商",
						name: "CustomerId",
						width: 130,
						align: "left"
					},					
					{
						label: "单据日期",
						name: "OrderDate",
						width: 100,
						align: "left",
						formatter: function(cellvalue) {
							if(cellvalue) {
								return app.BASE_UTILS.Date.get_yyyy_MM_dd(new Date(cellvalue));
							} else {
								return '';
							}
						}
					},									
					{
						label: "单据状态",
						name: "PaymentState",
						width: 80,
						align: "center",
						formatter: function(cellvalue) {
							if(cellvalue == 2) {
								return "<span style='color:green'>待审核</span>";
							} else if(cellvalue == 3) {
								return "<span style='color:blue'>已审核</span>";
							} else {
								return "<span style='color:red'>已出库</span>";
							}
						}
					},
					{
						label: "制单人员",
						name: "CreateUserName",
						width: 80,
						align: "left"
					},
					{
						label: "备注",
						name: "Description",
						width: 200,
						align: "left"
					}
				], 
			}
		}
	};
	$(function() {		
		app.CommonIndexEvent.init(options);
	})
})(window.jQuery, top.app)