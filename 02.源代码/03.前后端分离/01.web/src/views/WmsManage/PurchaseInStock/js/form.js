(function($, app) {
	"use strict";
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	// 保存数据
	var acceptClick = function() {
		if(!$('.app-layout-wrap').appValidform()) {
			return false;
		}
		var formData = $('.app-layout-wrap').appGetFormData(keyValue);
		var productData = [];
		var productDataTmp = $('#productgird').appGridGet('rowdatas');

		for(var i = 0, l = productDataTmp.length; i < l; i++) {
			if(!!productDataTmp[i]['ProductName']) {
				productData.push(productDataTmp[i]);
			}
		}
		//{
		//	"crmOrderJson": {
		//		"OrderCode ": "SO0811000002 ",
		//		"CreateUserName ": "徐晓悦 ",
		//		"OrderDate ": "2017 - 08 - 11 ",
		//		"CustomerId ": "27607392 - c60c - 4e e6 - 9557 - ef59f9410bbb ",
		//		"SellerId ": "1 fc0e985 - 1373 - 4 adc - b3a7 - f68b89093f1c ",
		//		"EnabledMark ": "false ",
		//		"appgrid_edit_productgird_Amount ": "33 ",
		//		"appgrid_edit_productgird_Taxprice ": "44 ",
		//		"appgrid_edit_productgird_date ": "2018 - 12 - 18 ",
		//		"appgrid_edit_productgird_date2 ": "2018 - 12 - 25 ",
		//		"appgrid_edit_productgird_Qty ": "200 ",
		//		"appgrid_edit_productgird_select ": "3 ",
		//		"appgrid_edit_productgird_Description ": "4444444444444 ",
		//		"Description ": " & nbsp;"
		//	},
		//	"crmOrderProductJson": [{
		//		"OrderEntryId ": "6540273 d - 4 a68 - 4e e0 - 96 bf - 96 cb5df909f9 ",
		//		"OrderId ": "3587 a099 - 980 d - 4342 - 864 f - a9f48e90e03b ",
		//		"ProductId ": null
		//	}, {
		//		"OrderEntryId ": "6540273 d - 4 a68 - 4e e0 - 96 bf - 96 cb5df909f9 ",
		//		"OrderId ": "3587 a099 - 980 d - 4342 - 864 f - a9f48e90e03b ",
		//		"ProductId ": null
		//	}]
		//}
		var postData = {
			crmOrderJson: formData,
			crmOrderProductJson: productData
		};
		alert(JSON.stringify(postData))
		var postUrl = '/api/' + router;
		var type = "POST";
		if(!!keyValue) {
			postUrl = postUrl + "/" + keyValue;
			type = "PUT"
		}
		$.appSaveForm(type, postUrl, postData, function(data) {

		});
		/*learun.layerConfirm('注：您确认要保存此操作吗？', function (res, index) {
		    if (res) {
		        $.lrSaveForm(top.$.rootUrl + '/LR_CRMModule/CrmOrder/SaveForm?keyValue=' + keyValue, postData, function (res) {
		            if (res.code == 200) {
		                if (type == 0) {
		                    window.location.href = top.$.rootUrl + '/LR_CRMModule/CrmOrder/Form';
		                }
		                else {
		                    learun.frameTab.close('order_add');
		                }
		            }
		        });
		        top.layer.close(index); //再执行关闭  
		    }
		});*/
	};

	/**
	 * 页面事件对象
	 */
	var pageEvent = {
		/**
		 *  窗体初始化 
		 **/
		init: function() {
			pageEvent.bindEvent();
			pageEvent.InitForm()
		},

		/**
		 * 绑定事件
		 */
		bindEvent: function() {
			// 优化滚动条
			$('.app-layout-wrap').appscroll();
			// 供应商选择
			$('#CustomerId').appselect({
				//url:'LR_CRMModule/Customer/GetList',
				data: [{
					"CustomerId": "6893bf56-e502-482f-9bd3-8c26532dc9a3",
					"EnCode": "KH-160523018",
					"FullName": "上海冠生园食品有限公司",
					"ShortName": "上海冠生园食品有限公司",
					"CustIndustryId": null,
					"CustTypeId": "企业客户",
					"CustLevelId": "C",
					"CustDegreeId": "往来客户",
					"Province": null,
					"City": null,
					"Contact": "刘芳",
					"Mobile": "15821722958",
					"Tel": null,
					"Fax": null,
					"QQ": null,
					"Email": null,
					"Wechat": null,
					"Hobby": null,
					"LegalPerson": null,
					"CompanyAddress": null,
					"CompanySite": null,
					"CompanyDesc": null,
					"TraceUserId": "e7e4dd8d-d207-4ea5-87f1-8c547115e767",
					"TraceUserName": "杨培培",
					"AlertDateTime": null,
					"AlertState": null,
					"SortCode": null,
					"DeleteMark": null,
					"EnabledMark": null,
					"Description": null,
					"CreateDate": "2016-05-23 11:19:04",
					"CreateUserId": "9dc4b4ac-5b35-48d7-8331-cbc8c24acb5f",
					"CreateUserName": "李阳华",
					"ModifyDate": "2018-03-30 10:30:40",
					"ModifyUserId": "31dc7e93-62ca-435e-b802-bcd3869a3719",
					"ModifyUserName": "佘"
				}, {
					"CustomerId": "27607392-c60c-4ee6-9557-ef59f9410bbb",
					"EnCode": "KH-160523013",
					"FullName": "上海唯捷城配",
					"ShortName": "上海唯捷城配",
					"CustIndustryId": null,
					"CustTypeId": "企业客户",
					"CustLevelId": "C",
					"CustDegreeId": "往来客户",
					"Province": null,
					"City": null,
					"Contact": "张林",
					"Mobile": "18755478756",
					"Tel": null,
					"Fax": null,
					"QQ": null,
					"Email": null,
					"Wechat": null,
					"Hobby": null,
					"LegalPerson": null,
					"CompanyAddress": null,
					"CompanySite": null,
					"CompanyDesc": null,
					"TraceUserId": "e47b497e-a905-432d-b8a9-7010586bc310",
					"TraceUserName": "徐玉静",
					"AlertDateTime": null,
					"AlertState": null,
					"SortCode": null,
					"DeleteMark": null,
					"EnabledMark": null,
					"Description": null,
					"CreateDate": "2016-05-23 11:18:18",
					"CreateUserId": "9dc4b4ac-5b35-48d7-8331-cbc8c24acb5f",
					"CreateUserName": "李阳华",
					"ModifyDate": "2016-06-01 10:19:37",
					"ModifyUserId": "31dc7e93-62ca-435e-b802-bcd3869a3719",
					"ModifyUserName": "佘"
				}],
				text: 'FullName',
				value: 'CustomerId',
				allowSearch: true,
				maxHeight: 400
			});
			// 仓库
			$('#SellerId').appselect({
				//url:'LR_OrganizationModule/User/GetList?departmentId=2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1',
				data: [{
					"UserId": "1fc0e985-1373-4adc-b3a7-f68b89093f1c",
					"EnCode": "10280",
					"Account": "10280",
					"Password": null,
					"Secretkey": null,
					"RealName": "仓库1",
					"NickName": null,
					"HeadIcon": null,
					"QuickQuery": "CCQ",
					"SimpleSpelling": "CCQ",
					"Gender": 1,
					"Birthday": "1982-06-13 00:00:00",
					"Mobile": "13911651315 ",
					"Telephone": "021-11652784",
					"Email": null,
					"OICQ": "021-11652784",
					"WeChat": null,
					"MSN": null,
					"CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
					"DepartmentId": "2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1",
					"SecurityLevel": null,
					"OpenId": null,
					"Question": null,
					"AnswerQuestion": null,
					"CheckOnLine": null,
					"AllowStartTime": null,
					"AllowEndTime": null,
					"LockStartDate": null,
					"LockEndDate": null,
					"SortCode": 10000280,
					"DeleteMark": 0,
					"EnabledMark": 1,
					"Description": null,
					"CreateDate": "2015-11-03 15:16:49",
					"CreateUserId": "System",
					"CreateUserName": "超级管理员",
					"ModifyDate": null,
					"ModifyUserId": null,
					"ModifyUserName": null,
					"LoginMsg": null,
					"LoginOk": false
				}, {
					"UserId": "c9480ffd-0af1-47f3-ac92-4ff5a99843f6",
					"EnCode": "10307",
					"Account": "10307",
					"Password": null,
					"Secretkey": null,
					"RealName": "仓库2",
					"NickName": null,
					"HeadIcon": null,
					"QuickQuery": "CX",
					"SimpleSpelling": "CX",
					"Gender": 1,
					"Birthday": "1980-06-10 00:00:00",
					"Mobile": "13626880670 ",
					"Telephone": "021-75776102",
					"Email": null,
					"OICQ": "021-75776102",
					"WeChat": null,
					"MSN": null,
					"CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
					"DepartmentId": "2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1",
					"SecurityLevel": null,
					"OpenId": null,
					"Question": null,
					"AnswerQuestion": null,
					"CheckOnLine": null,
					"AllowStartTime": null,
					"AllowEndTime": null,
					"LockStartDate": null,
					"LockEndDate": null,
					"SortCode": 10000307,
					"DeleteMark": 0,
					"EnabledMark": 1,
					"Description": null,
					"CreateDate": "2015-11-03 15:16:51",
					"CreateUserId": "System",
					"CreateUserName": "超级管理员",
					"ModifyDate": null,
					"ModifyUserId": null,
					"ModifyUserName": null,
					"LoginMsg": null,
					"LoginOk": false
				}],
				text: 'RealName',
				value: 'UserId',
				allowSearch: true,
				maxHeight: 400
			});

			// 产品信息
			$('#productgird').appgrid({
				headData: [{

						label: '商品名称',
						name: 'ProductName',
						width: 260,
						align: 'left',
						edit: {
							type: 'layer',
							init: function(data, $edit, rownum) { // 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象

							},
							change: function(row, rownum, selectdata) { // 行数据和行号,弹层选择行的数据，如果是自定义实现弹窗方式则该方法无效

								row.ProductName = selectdata.ItemName;
								row.ProductCode = selectdata.ItemValue;
								row.Qty = '1';
								row.Price = '0';
								row.Amount = '0';
								row.TaxRate = '0';
								row.Taxprice = '0';
								row.Tax = '0';
								row.TaxAmount = '0';

								$('#productgird').appGridSet('updateRow', rownum);
							},
							op: { // 如果未设置op属性可以在init中自定义实现弹窗方式
								width: 600,
								height: 400,
								colData: [{
										label: "商品编号",
										name: "ItemValue",
										width: 100,
										align: "left"
									},
									{
										label: "商品名称",
										name: "ItemName",
										width: 450,
										align: "left"
									}
								],
								//url:'LR_SystemModule/DataItem/GetDetailList',
								rowdatas: [{
									"ItemDetailId": "1b76ceae-c96e-4afd-a5d9-96834d82d96b",
									"ItemId": "7d610912-447d-4e64-8316-32e399455276",
									"ParentId": "0",
									"ItemCode": null,
									"ItemName": "企业豪华版11111",
									"ItemValue": "lr-2014-h",
									"QuickQuery": null,
									"SimpleSpelling": "qyhhb",
									"IsDefault": null,
									"SortCode": 1,
									"DeleteMark": 0,
									"EnabledMark": 1,
									"Description": null,
									"CreateDate": "2016-05-11 16:05:43",
									"CreateUserId": "bba93cbe-af5e-4a96-863f-454e739f8dc4",
									"CreateUserName": "李阳华",
									"ModifyDate": "2016-05-11 16:07:04",
									"ModifyUserId": "bba93cbe-af5e-4a96-863f-454e739f8dc4",
									"ModifyUserName": "李阳华"
								}, {
									"ItemDetailId": "0b1aa2ca-4e8b-483f-a294-155c0404d25f",
									"ItemId": "7d610912-447d-4e64-8316-32e399455276",
									"ParentId": "0",
									"ItemCode": null,
									"ItemName": "敏捷开发框架-个人开发版111111",
									"ItemValue": "lr-adms-01",
									"QuickQuery": null,
									"SimpleSpelling": "mjkfkj-grkfb",
									"IsDefault": null,
									"SortCode": 1,
									"DeleteMark": 0,
									"EnabledMark": 1,
									"Description": null,
									"CreateDate": "2016-03-11 17:08:41",
									"CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
									"CreateUserName": "佘赐雄",
									"ModifyDate": "2016-03-11 17:11:03",
									"ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
									"ModifyUserName": "佘赐雄"
								}, {
									"ItemDetailId": "68676c13-8a2e-4322-affe-67e1ac5c4f7c",
									"ItemId": "7d610912-447d-4e64-8316-32e399455276",
									"ParentId": "0",
									"ItemCode": null,
									"ItemName": "有线打印机1111111",
									"ItemValue": "lr-10010",
									"QuickQuery": null,
									"SimpleSpelling": "yxdyj",
									"IsDefault": null,
									"SortCode": 18,
									"DeleteMark": 0,
									"EnabledMark": 1,
									"Description": null,
									"CreateDate": "2016-03-18 14:37:08",
									"CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
									"CreateUserName": "佘赐雄",
									"ModifyDate": "2016-03-18 14:46:23",
									"ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
									"ModifyUserName": "佘赐雄"
								}],
								param: {
									itemCode: 'Client_ProductInfo'
								}
							}
						}
					},
					{
						label: '商品编号',
						name: 'ProductCode',
						width: 100,
						align: 'center',
						editType: 'label'
					},
					//					{
					//						label: '单位',
					//						name: 'UnitId',
					//						width: 100,
					//						align: 'center',
					//						edit: {
					//							type: 'input'
					//						}
					//
					//					},
					{
						label: '批次',
						name: 'Amount',
						width: 80,
						align: 'center',
						edit: {
							type: 'input'
						}
					},
					{
						label: '序列号',
						name: 'Taxprice',
						width: 80,
						align: 'center',
						edit: {
							type: 'input'
						}
					},
					{
						label: '生产日期',
						name: 'date',
						width: 120,
						align: 'left',
						edit: {
							type: 'datatime',
							dateformat: '0', // 0:yyyy-MM-dd;1:yyyy-MM-dd HH:mm,格式
							init: function(data, $edit) { // 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象

							},
							change: function(data, num) { // 行数据和行号

							}
						}
					},
					{
						label: '失效日期',
						name: 'date2',
						width: 120,
						align: 'left',
						edit: {
							type: 'datatime',
							dateformat: '0', // 0:yyyy-MM-dd;1:yyyy-MM-dd HH:mm,格式
							init: function(data, $edit) { // 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象

							},
							change: function(data, num) { // 行数据和行号

							}
						}
					},
					{

						label: '数量',
						name: 'Qty',
						width: 80,
						align: 'center',
						statistics: true,
						edit: {
							type: 'input',
							change: function(row, rownum) { // 行数据和行号
								row.Amount = parseInt(parseFloat(row.Price || '0') * parseFloat(row.Qty || '0'));
								row.TaxAmount = parseInt((parseFloat(row.Price || '0') * (1 + parseFloat(row.TaxRate || '0') / 100)) * parseFloat(row.Qty || '0'));
								row.Tax = row.TaxAmount - row.Amount;
								$('#productgird').appGridSet('updateRow', rownum);
							},
						}
					},
					{
						label: '货位',
						name: 'select',
						width: 120,
						align: 'left',
						edit: {
							type: 'select',
							init: function(data, $edit) { // 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象

							},
							change: function(row, num, item) { // 行数据和行号,下拉框选中数据

							},
							op: { // 下拉框设置参数 和 appselect一致
								data: [{
										'id': '1',
										'text': '选项一'
									},
									{
										'id': '2',
										'text': '选项二'
									},
									{
										'id': '3',
										'text': '选项三'
									},
									{
										'id': '4',
										'text': '选项四'
									}
								]
							}
						}
					},

					{
						label: "备注",
						name: "Description",
						width: 200,
						align: "left",
						edit: {
							type: 'input'
						}
					}
				],
				isEdit: true,
				height: 400,
				isMultiselect: true
			});

			// 保存数据
			//			$('#savaAndAdd').on('click', function() {
			//				acceptClick(0);
			//			});
			$('#save').on('click', function() {
				acceptClick();
			});

		},

		/*初始化表单数据*/
		InitForm: function() {
			$("#CreateUserName").val(app.APP_GLOBE_STORE.LOGIN_USER.FullName);				
			$("#OrderDate").val(app.BASE_UTILS. Date. get_yyyy_MM_dd());
			if(!!keyValue) {
				var data = {
					"orderData": {
						"OrderId": "3587a099-980d-4342-864f-a9f48e90e03b",
						"CustomerId": "27607392-c60c-4ee6-9557-ef59f9410bbb",
						"SellerId": "1fc0e985-1373-4adc-b3a7-f68b89093f1c",
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
					},
					"orderProductData": [{
						"OrderEntryId": "6540273d-4a68-4ee0-96bf-96cb5df909f9",
						"OrderId": "3587a099-980d-4342-864f-a9f48e90e03b",
						"ProductId": null,
						"ProductCode": "lr-2014-h",
						"ProductName": "企业豪华版",
						"UnitId": null,
						"Qty": 1.00,
						"Price": 100.00,
						"Amount": 100.00,
						"Taxprice": 100.00,
						"TaxRate": 0.00,
						"Tax": 0.00,
						"TaxAmount": 100.00,
						"SortCode": null,
						"DeleteMark": null,
						"EnabledMark": null,
						"Description": "33333333333",
						"date": "2017-01-01",
						"date2": "2018-01-01",
						"select": "1"
					}]
				};
				$(".app-layout-wrap").appSetFormData(data.orderData)
				$('#productgird').appGridSet('refreshdata', data.orderProductData);

			}

			//			if(!!keyValue) {
			//				$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
			//					$('.app-layout-wrap').appSetFormData(data.orderData);
			//					$('#productgird').appGridSet('refreshdata', data.orderProductData);
			//				});
			//			}
		},

	}
	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)