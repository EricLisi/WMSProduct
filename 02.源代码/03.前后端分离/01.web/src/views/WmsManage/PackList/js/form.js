var router = "PackList";
var datas=[];
(function($, app) {
	"use strict";
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	//来源类型为无来源时,来源单据不可编辑
	$("#SourceType").change(function() {
		var SourceType = $("#SourceType").val();
		if(SourceType == "0") {
			$('#SourceId').attr('disabled', 'disabled');
			$('#SourceId').val("");
			$('#productgird').css('display', 'block');
			$('#productgird1').css('display', 'none');
			//先将表格置空
			$("#productgird").appGridSet('refreshdatas', datas);
		} else if(SourceType == "1") {
			$('#SourceId').removeAttr('disabled', 'disabled');
			$('#productgird').css('display', 'none');
			$('#productgird1').css('display', 'block');
			$(".valia").html('来源单据<font face="宋体">*</font>');
			$('#SourceId').attr('isvalid', 'yes');
			$('#SourceId').attr('checkexpession', 'NotNull');
			var SourceId = $('#SourceId').val();
			if(!SourceId) {
				// 获取当前列表数据
                //var rowdatas = $('#productgird1').appGridGet('rowdatas');
                //获取选中行
                //var rowdatas = $('#productgird1').getCheckRow();              
				//先将表格置空
				$("#productgird1").appGridSet('refreshdatas',datas);
			}
		}

	})
	// 保存数据
	var acceptClick = function() {
		if(!$('.app-layout-wrap').appValidform()) {
			return false;
		}
		var formData = $('.app-layout-wrap').appGetFormData(keyValue);
		var productData = [];
		var productDataTmp = $('.aa').appGridGet('rowdatas');
		alert(JSON.stringify(productDataTmp))
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
			$('#SupplierId').appselect({
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
			//			$('#WarehouseId').appselect({
			//				//url:'LR_OrganizationModule/User/GetList?departmentId=2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1',
			//				data: [{
			//					"UserId": "1fc0e985-1373-4adc-b3a7-f68b89093f1c",
			//					"EnCode": "10280",
			//					"Account": "10280",
			//					"Password": null,
			//					"Secretkey": null,
			//					"RealName": "仓库1",
			//					"NickName": null,
			//					"HeadIcon": null,
			//					"QuickQuery": "CCQ",
			//					"SimpleSpelling": "CCQ",
			//					"Gender": 1,
			//					"Birthday": "1982-06-13 00:00:00",
			//					"Mobile": "13911651315 ",
			//					"Telephone": "021-11652784",
			//					"Email": null,
			//					"OICQ": "021-11652784",
			//					"WeChat": null,
			//					"MSN": null,
			//					"CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
			//					"DepartmentId": "2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1",
			//					"SecurityLevel": null,
			//					"OpenId": null,
			//					"Question": null,
			//					"AnswerQuestion": null,
			//					"CheckOnLine": null,
			//					"AllowStartTime": null,
			//					"AllowEndTime": null,
			//					"LockStartDate": null,
			//					"LockEndDate": null,
			//					"SortCode": 10000280,
			//					"DeleteMark": 0,
			//					"EnabledMark": 1,
			//					"Description": null,
			//					"CreateDate": "2015-11-03 15:16:49",
			//					"CreateUserId": "System",
			//					"CreateUserName": "超级管理员",
			//					"ModifyDate": null,
			//					"ModifyUserId": null,
			//					"ModifyUserName": null,
			//					"LoginMsg": null,
			//					"LoginOk": false
			//				}, {
			//					"UserId": "c9480ffd-0af1-47f3-ac92-4ff5a99843f6",
			//					"EnCode": "10307",
			//					"Account": "10307",
			//					"Password": null,
			//					"Secretkey": null,
			//					"RealName": "仓库2",
			//					"NickName": null,
			//					"HeadIcon": null,
			//					"QuickQuery": "CX",
			//					"SimpleSpelling": "CX",
			//					"Gender": 1,
			//					"Birthday": "1980-06-10 00:00:00",
			//					"Mobile": "13626880670 ",
			//					"Telephone": "021-75776102",
			//					"Email": null,
			//					"OICQ": "021-75776102",
			//					"WeChat": null,
			//					"MSN": null,
			//					"CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
			//					"DepartmentId": "2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1",
			//					"SecurityLevel": null,
			//					"OpenId": null,
			//					"Question": null,
			//					"AnswerQuestion": null,
			//					"CheckOnLine": null,
			//					"AllowStartTime": null,
			//					"AllowEndTime": null,
			//					"LockStartDate": null,
			//					"LockEndDate": null,
			//					"SortCode": 10000307,
			//					"DeleteMark": 0,
			//					"EnabledMark": 1,
			//					"Description": null,
			//					"CreateDate": "2015-11-03 15:16:51",
			//					"CreateUserId": "System",
			//					"CreateUserName": "超级管理员",
			//					"ModifyDate": null,
			//					"ModifyUserId": null,
			//					"ModifyUserName": null,
			//					"LoginMsg": null,
			//					"LoginOk": false
			//				}],
			//				text: 'RealName',
			//				value: 'UserId',
			//				allowSearch: true,
			//				maxHeight: 400
			//			});
			//来源类型
			$('#SourceType').appselect();
			//选择来源单据
			$('#selectIcon1').on('click', function() {
				layx.iframe('iconForm', '选择来源单据', '../html/addForm.html', {
					shadable: true,
					statusBar: true,
					width: 1050,
					height: 450,
					buttons: [{
							label: '<i class="fa fa-save" style="margin-right:5px"></i>保存',
							callback: function(id, button, event) {
								// 获取 iframe 页面 window对象
								var contentWindow = layx.getFrameContext(id);
								contentWindow.acceptClick();
								var win = layx.getFrameContext('iconForm', 'group2');
								//alert(win.document.querySelector(".pp").innerHTML);
								if($("#SourceId").val()==win.document.querySelector(".pp").innerHTML){									
									app.MODAL_UTILS.error("已经选择过此单据")
									return false
								}
								$("#SourceId").val(win.document.querySelector(".pp").innerHTML);
								var SourceId = $('#SourceId').val();
								var SourceType = $("#SourceType").val();
								if(!!SourceId && SourceType == "1") {
									//app.HTTP_REQUEST_UTILS.httpAsyncGet('../laiyuandanju/'+SourceId, function(data) {});
									datas = [{
										"Id": "11",
										"ProductCode": "cb5df909f9 ",
										"ProductName": "商品1",
										"ProductStandard": '10g',
										'Batch': '001'
									}, {
										"Id": "22",
										"ProductCode": "cb5df909f8",
										"ProductName": "商品2",
										"ProductStandard": '20g',
										'Batch': '002'
									}];
									$("#productgird1").appGridSet('refreshdata', datas);
								} else {
									alert("请选择来源单据")
								}
								layx.destroy(id);
							},
							classes: ['btn-primary']
						},
						{
							label: '<i class="fa fa-close" style="margin-right:5px"></i>取消',
							callback: function(id, button, event) {
								layx.destroy(id);
							},
							classes: ['btn-danger']
						}
					]
				});
			});

			// 来源为出库通知单时，选择单据表头信息，表格加载表体商品信息
			$('#productgird1').appgrid({
				//url: '',   
				//rowdatas: datas,
				headData: [{
						label: '产品名称',
						name: 'ProductName',
						width: 260,
						align: "center"

					},
					{
						label: '商品编号',
						name: 'ProductCode',
						width: 100,
						align: 'center'
					},
					{
						label: '规格型号',
						name: 'ProductStandard',
						width: 100,
						align: 'center'

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
						name: 'Batch',
						width: 80,
						align: 'center'

					},
					{
						label: '序列号',
						name: 'Taxprice',
						width: 80,
						align: 'center'
					},
					{
						label: '生产日期',
						name: 'date',
						width: 120,
						align: "center"
					},
					{
						label: '失效日期',
						name: 'date2',
						width: 120,
						align: "center"
					},
					{

						label: '入库数量',
						name: 'Quantity',
						width: 80,
						align: 'center'
					},

					{
						label: '入库货位',
						name: 'PositionId',
						width: 120,
						align: "center"
					},

					{
						label: "备注",
						name: "Description",
						width: 200,
						align: "center"
					}
				],
				isEdit: false,
				height: 400,
				isMultiselect: false
			});
			//无来源时，选择全部商品，表格加载选中的商品信息
			$('#productgird').appgrid({
				headData: [{

						label: '产品名称',
						name: 'ProductName',
						width: 260,
						align: "center",
						edit: {
							type: 'layer',
							init: function(data, $edit, rownum) { // 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象

							},
							change: function(row, rownum, selectdata) { // 行数据和行号,弹层选择行的数据，如果是自定义实现弹窗方式则该方法无效
								row.ProductName = selectdata.FullName;
								row.ProductCode = selectdata.EnCode;
								row.ProductStandard = selectdata.Standard;
								row.ProdcuntBatchManagement = selectdata.ProdcuntBatchManagement;
								row.Quantity = '1';
								if(selectdata.ProdcuntBatchManagement == "false") {
									alert(333333333333)
									alert(JSON.stringify(row))
								}

								$('#productgird').appGridSet('updateRow', rownum);
							},
							op: { // 如果未设置op属性可以在init中自定义实现弹窗方式
								width: 601,
								height: 400,
								colData: [{
										label: '产品编码',
										name: 'EnCode',
										width: 100,
										align: "center"
									},
									{
										label: '产品名称',
										name: 'FullName',
										width: 100,
										align: "center"
									},
									{
										label: '代码',
										name: 'ShortCode',
										width: 100,
										align: 'center'
									},
									{
										label: '别名',
										name: 'ShortName',
										width: 100,
										align: 'center'
									},
									{
										label: '规格',
										name: 'Standard',
										width: 100,
										align: 'center'
									},
									{
										label: '品牌',
										name: 'Brand',
										width: 100,
										align: 'center'
									},
									{
										label: '单位',
										name: 'Unit',
										width: 100,
										align: 'center'
									},
									{
										label: '包装规格',
										name: 'Package',
										width: 100,
										align: "center"
									},
									{
										label: '颜色',
										name: 'Color',
										width: 100,
										align: 'center'
									},
									{
										label: '长（m）',
										name: 'Length',
										width: 100,
										align: 'center'
									},
									{
										label: '高（m）',
										name: 'Height',
										width: 100,
										align: 'center'
									},
									{
										label: '宽（m）',
										name: 'Width',
										width: 100,
										align: 'center'
									},

									{
										label: '净重（kg）',
										name: 'NetWeight',
										width: 100,
										align: 'center'
									},
									{
										label: '毛重（kg）',
										name: 'Weight',
										width: 100,
										align: 'center'
									},
									{
										label: '采购价格',
										name: 'PurchasePrice',
										width: 100,
										align: 'center'
									},
									{
										label: '销售价格',
										name: 'SalesPrice',
										width: 100,
										align: 'center'
									},
									{
										label: 'pici11111',
										name: 'ProdcuntBatchManagement',
										width: 100,
										align: 'center'
									},

									{
										label: "创建时间",
										name: "CreatorTime",
										width: 300,
										align: "center"
									}
								],
								//url:'LR_SystemModule/DataItem/GetDetailList',
								rowdatas: [{
									"EnCode": "DG",
									"FullName": "FF",
									"ShortCode": "FSF",
									"ShortName": "GH",
									"ProductClassId": "",
									"OwnershipId": "",
									"Standard": "DFG",
									"Brand": "DFG",
									"Color": "DF",
									"Length": 54.000000,
									"Height": 5.000000,
									"Width": 6.000000,
									"NetWeight": 3.000000,
									"Weight": 6.000000,
									"PurchasePrice": 12.000000,
									"SalesPrice": 10.000000,
									"Unit": "个",
									"BatchManagement": false,
									"SnManagement": false,
									"EffectiveManagement": false,
									"EffectiveDays": 0,
									"EffectiveUnit": 0,
									"Package": 0,
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
									"Description": "&nbsp;",
									"SortCode": 0,
									"DeleteMark": false,
									"EnabledMark": true,
									"CreatorTime": "1900-01-01 00:00:00",
									"CreatorUserId": "",
									"LastModifyTime": "1900-01-01 00:00:00",
									"LastModifyUserId": "",
									"DeleteTime": "1900-01-01 00:00:00",
									"DeleteUserId": "",
									"Id": "29c6364e-fdce-4623-bf89-4b7f0ea947a1",
									"ParentId": null,
									"CurrentLoginUserId": null,
									"ProdcuntBatchManagement": "false",
									"Data1": null,
									"Data2": null,
									"Data3": null
								}, {
									"EnCode": "eeee",
									"FullName": "水电费",
									"ShortCode": "dfs",
									"ShortName": "ewr",
									"ProductClassId": "",
									"OwnershipId": "",
									"Standard": "水电费",
									"Brand": "23",
									"Color": "23",
									"Length": 23.000000,
									"Height": 23.000000,
									"Width": 23.000000,
									"NetWeight": 4.000000,
									"Weight": 34.000000,
									"PurchasePrice": 34.000000,
									"SalesPrice": 23.000000,
									"Unit": "个",
									"BatchManagement": true,
									"SnManagement": true,
									"EffectiveManagement": true,
									"EffectiveDays": 4,
									"EffectiveUnit": 0,
									"Package": 0,
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
									"Description": "",
									"SortCode": 0,
									"DeleteMark": false,
									"EnabledMark": true,
									"CreatorTime": "1900-01-01 00:00:00",
									"CreatorUserId": "",
									"LastModifyTime": "1900-01-01 00:00:00",
									"LastModifyUserId": "",
									"DeleteTime": "1900-01-01 00:00:00",
									"DeleteUserId": "",
									"Id": "4c950519-c8e1-422d-bc9e-e3a6a9963349",
									"ParentId": null,
									"CurrentLoginUserId": null,
									"ProdcuntBatchManagement": "true",
									"Data1": null,
									"Data2": null,
									"Data3": null
								}],
								//								param: {
								//									itemCode: 'Client_ProductInfo'
								//								}
							}
						}
					},
					{
						label: '商品编号',
						name: 'ProductCode',
						width: 100,
						align: 'center'
						//						editType: 'label'
					},
					{
						label: '规格型号',
						name: 'ProductStandard',
						width: 100,
						align: 'center'
						//						editType: 'label'
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
						label: '批次号',
						name: 'Batch',
						width: 80,
						align: 'center',
						edit: {
							type: 'input',
							init: function(data, $edit) {}
						}
					},
					{
						label: '批次号1111',
						name: 'ProdcuntBatchManagement',
						width: 80,
						align: 'center',
						edit: {
							type: 'input'

						}
					},					
					{

						label: '出库数量',
						name: 'Quantity',
						width: 80,
						align: 'center',
						statistics: true,
						edit: {
							type: 'input',
							change: function(row, rownum) { // 行数据和行号								
							},
						}
					},
					{
						label: '出库仓库',
						name: 'WarehouseId',
						width: 150,
						align: 'center',
						edit: {
							type: 'select',
							op: {
                                value: 'id',
                                text: 'text',
                                title: 'text',
                                url:'/api/Warehouse/GetSelectGrid'
                                //param: { itemCode: 'DbFieldType' },
                            },
                            change: function (row, num, selectdata) {// 行数据和行号
//                              if (!!selectdata) {
//                                  row.f_datatypename = selectdata.F_ItemName;
//                                  row.f_datatype = selectdata.F_ItemValue;
//                                  if (selectdata.F_ItemValue == 'varchar') {
//                                      row.f_length = 50;
//                                  }
//                                  else {
//                                      row.f_length = 0;
//                                  }
//                              }
//                              else {
//                                  row.f_length = 0;
//                                  row.f_datatype = '';
//                                  row.f_datatypename = '';
//                              }
//
//                              $('#gridtable').jfGridSet('updateRow', num);
                            }
							
							
//							op: { // 下拉框设置参数 和 appselect一致
//								data: [{
//										'id': '1',
//										'text': '仓库一'
//									},
//									{
//										'id': '2',
//										'text': '仓库二'
//									},
//									{
//										'id': '3',
//										'text': '仓库三'
//									},
//									{
//										'id': '4',
//										'text': '仓库四'
//									}
//								]
//							}
						}

					},
					{
						label: '出库货位',
						name: 'PositionId',
						width: 120,
						align: "center",
						edit: {
							type: 'select',
							init: function(data, $edit) { // 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象

							},
							change: function(row, num, item) { // 行数据和行号,下拉框选中数据

							},
							op: { // 下拉框设置参数 和 appselect一致
								data: [{
										'id': '1',
										'text': '货位一'
									},
									{
										'id': '2',
										'text': '货位二'
									},
									{
										'id': '3',
										'text': '货位三'
									},
									{
										'id': '4',
										'text': '货位四'
									}
								]
							}
						}
					},

					{
						label: '生产日期',
						name: 'MadeDate',
						width: 120,
						align: "center",
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
						name: '失效日期',
						width: 120,
						align: "center",
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
						label: "备注",
						name: "Description",
						width: 200,
						align: "center",
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
			$('#save').on('click', function() {
				acceptClick();
			});

		},

		/*初始化表单数据*/
		InitForm: function() {
			$("#CMaker").val(app.APP_GLOBE_STORE.LOGIN_USER.FullName);
			$("#Date").val(app.BASE_UTILS.Date.get_yyyy_MM_dd());
			if(!!keyValue) {
				//				var data = {
				//					"orderData": {
				//						"OrderId": "3587a099-980d-4342-864f-a9f48e90e03b",
				//						"CustomerId": "27607392-c60c-4ee6-9557-ef59f9410bbb",
				//						"SellerId": "1fc0e985-1373-4adc-b3a7-f68b89093f1c",
				//						"OrderDate": "2017-08-11 00:00:00",
				//						"OrderCode": "SO0811000002",
				//						"DiscountSum": 0.00,
				//						"Accounts": 100.00,
				//						"ReceivedAmount": 1000.00,
				//						"PaymentDate": "2017-08-11 00:00:00",
				//						"PaymentMode": "1",
				//						"PaymentState": 2,
				//						"SaleCost": 0.00,
				//						"AbstractInfo": null,
				//						"ContractCode": null,
				//						"ContractFile": "76c2bd72-9d9c-05c2-9bb9-cccdb30b4751",
				//						"SortCode": null,
				//						"DeleteMark": null,
				//						"EnabledMark": null,
				//						"Description": null,
				//						"CreateDate": "2018-04-03 16:34:26",
				//						"CreateUserId": null,
				//						"CreateUserName": "徐晓悦",
				//						"ModifyDate": null,
				//						"ModifyUserId": null,
				//						"ModifyUserName": null
				//					},
				//					"orderProductData": [{
				//						"OrderEntryId": "6540273d-4a68-4ee0-96bf-96cb5df909f9",
				//						"OrderId": "3587a099-980d-4342-864f-a9f48e90e03b",
				//						"ProductId": null,
				//						"ProductCode": "lr-2014-h",
				//						"ProductName": "企业豪华版",
				//						"UnitId": null,
				//						"Qty": 1.00,
				//						"Price": 100.00,
				//						"Amount": 100.00,
				//						"Taxprice": 100.00,
				//						"TaxRate": 0.00,
				//						"Tax": 0.00,
				//						"TaxAmount": 100.00,
				//						"SortCode": null,
				//						"DeleteMark": null,
				//						"EnabledMark": null,
				//						"Description": "33333333333",
				//						"date": "2017-01-01",
				//						"date2": "2018-01-01",
				//						"select": "1"
				//					}]
				//				};
				//				$(".app-layout-wrap").appSetFormData(data.orderData)
				//				$('#productgird').appGridSet('refreshdata', data.orderProductData);

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