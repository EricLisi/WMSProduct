var refreshGirdData;
var router='PurchaseInStock';
/*
 * 模块管理主页面
 */
(function ($, app) {
    "use strict";
    /**
     * 页面事件
     */               
    var pageEvent = {
        /**
         * 初始化事件
         */
        init: function () {
        	$('#app_layout').appLayout();
            pageEvent.initConfig();          
            pageEvent.initgrid();
            pageEvent.bindEvent()                                     
        },
        /**
         * 初始化配置
         */
        initConfig:function(){        	           
            //错误页面路径重设
            app.APP_CONFIGRATION.ROUTER_CONFIG.ERROR_PAGE_URL = "../../../Error/index.html";
        },
        
             
        /**
         * 绑定事件
         */
        bindEvent: function () {
        	// 时间搜索框
            $('#datesearch').appdate({
                /*dfdata: [                
                    { name: '今天', begin: function () { return app.getDate('yyyy-MM-dd 00:00:00') }, end: function () { return app.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近7天', begin: function () { return app.getDate('yyyy-MM-dd 00:00:00', 'd', -6) }, end: function () { return app.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近1个月', begin: function () { return app.getDate('yyyy-MM-dd 00:00:00', 'm', -1) }, end: function () { return app.getDate('yyyy-MM-dd 23:59:59') } },
                    { name: '近3个月', begin: function () { return app.getDate('yyyy-MM-dd 00:00:00', 'm', -3) }, end: function () { return app.getDate('yyyy-MM-dd 23:59:59') } }
                ],
                // 月
                mShow: false,
                premShow: false,
                // 季度
                jShow: false,
                prejShow: false,
                // 年
                ysShow: false,
                yxShow: false,
                preyShow: false,
                
                yShow: false,
                // 默认
                dfvalue: '1',
                selectfn: function (begin, end) {
                }*/
            });
           /* $('#multiple_condition_query').appMultipleQuery(function (queryJson) {
                // 调用后台查询
                // queryJson 查询条件
                console.log(queryJson);
                pageEven.search({ queryJson: JSON.stringify(queryJson)});

            },220);*/

            // 客户选择
            $('#customerId').appselect({
            	data:[{
					"F_CustomerId": "6893bf56-e502-482f-9bd3-8c26532dc9a3",
					"F_EnCode": "KH-160523018",
					"F_FullName": "上海冠生园食品有限公司",
					"F_ShortName": "上海冠生园食品有限公司",
					"F_CustIndustryId": null,
					"F_CustTypeId": "企业客户",
					"F_CustLevelId": "C",
					"F_CustDegreeId": "往来客户",
					"F_Province": null,
					"F_City": null,
					"F_Contact": "刘芳",
					"F_Mobile": "15821722958",
					"F_Tel": null,
					"F_Fax": null,
					"F_QQ": null,
					"F_Email": null,
					"F_Wechat": null,
					"F_Hobby": null,
					"F_LegalPerson": null,
					"F_CompanyAddress": null,
					"F_CompanySite": null,
					"F_CompanyDesc": null,
					"F_TraceUserId": "e7e4dd8d-d207-4ea5-87f1-8c547115e767",
					"F_TraceUserName": "杨培培",
					"F_AlertDateTime": null,
					"F_AlertState": null,
					"F_SortCode": null,
					"F_DeleteMark": null,
					"F_EnabledMark": null,
					"F_Description": null,
					"F_CreateDate": "2016-05-23 11:19:04",
					"F_CreateUserId": "9dc4b4ac-5b35-48d7-8331-cbc8c24acb5f",
					"F_CreateUserName": "李阳华",
					"F_ModifyDate": "2018-03-30 10:30:40",
					"F_ModifyUserId": "31dc7e93-62ca-435e-b802-bcd3869a3719",
					"F_ModifyUserName": "佘"
				}, {
					"F_CustomerId": "27607392-c60c-4ee6-9557-ef59f9410bbb",
					"F_EnCode": "KH-160523013",
					"F_FullName": "上海唯捷城配",
					"F_ShortName": "上海唯捷城配",
					"F_CustIndustryId": null,
					"F_CustTypeId": "企业客户",
					"F_CustLevelId": "C",
					"F_CustDegreeId": "往来客户",
					"F_Province": null,
					"F_City": null,
					"F_Contact": "张林",
					"F_Mobile": "18755478756",
					"F_Tel": null,
					"F_Fax": null,
					"F_QQ": null,
					"F_Email": null,
					"F_Wechat": null,
					"F_Hobby": null,
					"F_LegalPerson": null,
					"F_CompanyAddress": null,
					"F_CompanySite": null,
					"F_CompanyDesc": null,
					"F_TraceUserId": "e47b497e-a905-432d-b8a9-7010586bc310",
					"F_TraceUserName": "徐玉静",
					"F_AlertDateTime": null,
					"F_AlertState": null,
					"F_SortCode": null,
					"F_DeleteMark": null,
					"F_EnabledMark": null,
					"F_Description": null,
					"F_CreateDate": "2016-05-23 11:18:18",
					"F_CreateUserId": "9dc4b4ac-5b35-48d7-8331-cbc8c24acb5f",
					"F_CreateUserName": "李阳华",
					"F_ModifyDate": "2016-06-01 10:19:37",
					"F_ModifyUserId": "31dc7e93-62ca-435e-b802-bcd3869a3719",
					"F_ModifyUserName": "佘"
				}],
                //url: top.$.rootUrl + '/LR_CRMModule/Customer/GetList',
                text: 'F_FullName',
                value: 'F_CustomerId',
                allowSearch: true,
                maxHeight: 400
            });
            // 销售人员
            $('#sellerId').appselect({
            	data:[{
					"F_UserId": "1fc0e985-1373-4adc-b3a7-f68b89093f1c",
					"F_EnCode": "10280",
					"F_Account": "10280",
					"F_Password": null,
					"F_Secretkey": null,
					"F_RealName": "陈春琴",
					"F_NickName": null,
					"F_HeadIcon": null,
					"F_QuickQuery": "CCQ",
					"F_SimpleSpelling": "CCQ",
					"F_Gender": 1,
					"F_Birthday": "1982-06-13 00:00:00",
					"F_Mobile": "13911651315 ",
					"F_Telephone": "021-11652784",
					"F_Email": null,
					"F_OICQ": "021-11652784",
					"F_WeChat": null,
					"F_MSN": null,
					"F_CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
					"F_DepartmentId": "2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1",
					"F_SecurityLevel": null,
					"F_OpenId": null,
					"F_Question": null,
					"F_AnswerQuestion": null,
					"F_CheckOnLine": null,
					"F_AllowStartTime": null,
					"F_AllowEndTime": null,
					"F_LockStartDate": null,
					"F_LockEndDate": null,
					"F_SortCode": 10000280,
					"F_DeleteMark": 0,
					"F_EnabledMark": 1,
					"F_Description": null,
					"F_CreateDate": "2015-11-03 15:16:49",
					"F_CreateUserId": "System",
					"F_CreateUserName": "超级管理员",
					"F_ModifyDate": null,
					"F_ModifyUserId": null,
					"F_ModifyUserName": null,
					"LoginMsg": null,
					"LoginOk": false
				}, {
					"F_UserId": "c9480ffd-0af1-47f3-ac92-4ff5a99843f6",
					"F_EnCode": "10307",
					"F_Account": "10307",
					"F_Password": null,
					"F_Secretkey": null,
					"F_RealName": "陈新",
					"F_NickName": null,
					"F_HeadIcon": null,
					"F_QuickQuery": "CX",
					"F_SimpleSpelling": "CX",
					"F_Gender": 1,
					"F_Birthday": "1980-06-10 00:00:00",
					"F_Mobile": "13626880670 ",
					"F_Telephone": "021-75776102",
					"F_Email": null,
					"F_OICQ": "021-75776102",
					"F_WeChat": null,
					"F_MSN": null,
					"F_CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
					"F_DepartmentId": "2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1",
					"F_SecurityLevel": null,
					"F_OpenId": null,
					"F_Question": null,
					"F_AnswerQuestion": null,
					"F_CheckOnLine": null,
					"F_AllowStartTime": null,
					"F_AllowEndTime": null,
					"F_LockStartDate": null,
					"F_LockEndDate": null,
					"F_SortCode": 10000307,
					"F_DeleteMark": 0,
					"F_EnabledMark": 1,
					"F_Description": null,
					"F_CreateDate": "2015-11-03 15:16:51",
					"F_CreateUserId": "System",
					"F_CreateUserName": "超级管理员",
					"F_ModifyDate": null,
					"F_ModifyUserId": null,
					"F_ModifyUserName": null,
					"LoginMsg": null,
					"LoginOk": false
				}],
                //url: top.$.rootUrl + '/LR_OrganizationModule/User/GetList?departmentId=2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1',
                text: 'F_RealName',
                value: 'F_UserId',
                allowSearch: true,
                maxHeight: 400
            });
            // 收款方式
          /*  $('#paymentState').appDataItemSelect({ code: 'Client_PaymentMode' });*/


            

 
            // 查询
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                pageEvent.search({ keyword: keyword });
            });
            // 刷新
            $('#app_refresh').on('click', function () {
                location.reload();
            });
            // 新增
            $('#app_add').on('click', function () {
            	alert(11111)            	
                app.frameTab.open({ 
                	F_Id: 'order_add', 
                	F_Icon: 'fa fa-file-text-o',
                	F_FullName: '新增订单', 
                	F_UrlAddress: 'SystemManage/CrmOrder/html/form.html' 
                });
                
            });
            // 编辑
            $('#app_edit').on('click', function () {
                var keyValue = $('#gridtable').appGridValue('F_Id');
                alert(keyValue)
                if (app.BASE_UTILS.checkrow(keyValue)) {
                	alert(222)
                    app.frameTab.open({
                    	F_ModuleId: 'order_add',
                    	F_Icon: 'fa fa-file-text-o',
                    	F_FullName: '编辑订单',
                    	F_UrlAddress: 'SystemManage/CrmOrder/html/form.html?keyValue=' + keyValue 
                    });
                }
            });
            // 删除
            $('#app_delete').on('click', function () {
                var keyValue = $('#gridtable').appGridValue('F_Id');
                if (app.BASE_UTILS.checkrow(keyValue)) {
                    app.MODAL_UTILS.confirm({
                        msg: "是否确认删除该项！",
		                callback: function () {
		                    
                            alert(2222)
                            request.delete({
								url: "/api/SystemManage/CrmOrder/DeleteForm?keyValue=" + keyValue,					
								success: function(data) {						
									refreshGirdData();									
								}
								
							});
		                }
                    });
                }
            });                             	           
        },
         
         /**
         * 初始化表格
         */
         initgrid: function () {
         $("#gridtable").appgrid({
	            url: '',                // 数据服务地址
	            param: {},                    // 请求参数
	            rowdatas:[{
	"F_Id": "3587a099-980d-4342-864f-a9f48e90e03b",
	"F_CustomerId": "27607392-c60c-4ee6-9557-ef59f9410bbb",
	"F_SellerId": "7702ad2a-c3e9-411e-acef-0cc61bab0507",
	"F_OrderDate": "2017-08-11 00:00:00",
	"F_OrderCode": "SO0811000002",
	"F_DiscountSum": 0.00,
	"F_Accounts": 100.00,
	"F_ReceivedAmount": 1000.00,
	"F_PaymentDate": "2017-08-11 00:00:00",
	"F_PaymentMode": "1",
	"F_PaymentState": 2,
	"F_SaleCost": 0.00,
	"F_AbstractInfo": null,
	"F_ContractCode": null,
	"F_ContractFile": "76c2bd72-9d9c-05c2-9bb9-cccdb30b4751",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": null,
	"F_CreateDate": "2018-04-03 16:34:26",
	"F_CreateUserId": null,
	"F_CreateUserName": "徐晓悦",
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_Id": "0394fa78-047b-4662-af90-0ebd4ba2dcf2",
	"F_CustomerId": "6893bf56-e502-482f-9bd3-8c26532dc9a3",
	"F_SellerId": "1fc0e985-1373-4adc-b3a7-f68b89093f1c",
	"F_OrderDate": "2017-09-28 00:00:00",
	"F_OrderCode": "SO0928000001",
	"F_DiscountSum": null,
	"F_Accounts": 0.00,
	"F_ReceivedAmount": 56.00,
	"F_PaymentDate": "2017-09-28 00:00:00",
	"F_PaymentMode": null,
	"F_PaymentState": 2,
	"F_SaleCost": 56.00,
	"F_AbstractInfo": null,
	"F_ContractCode": null,
	"F_ContractFile": "fd8248bb-35a2-76f3-9ed0-e522496ecd45",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": "55555555",
	"F_CreateDate": "2018-04-03 16:33:12",
	"F_CreateUserId": "System",
	"F_CreateUserName": null,
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": "555555555"
}, {
	"F_Id": "93e22189-e778-4f57-b4d2-3848ee828511",
	"F_CustomerId": "705a2756-2fc8-4074-b113-4040f2d3995f",
	"F_SellerId": "90e94e25-824b-40a0-8b6d-7ae07a68a4e3",
	"F_OrderDate": "2017-07-13 00:00:00",
	"F_OrderCode": "SO0713000001",
	"F_DiscountSum": 0.00,
	"F_Accounts": 9000.00,
	"F_ReceivedAmount": null,
	"F_PaymentDate": "2017-07-06 00:00:00",
	"F_PaymentMode": "3",
	"F_PaymentState": null,
	"F_SaleCost": 0.00,
	"F_AbstractInfo": "",
	"F_ContractCode": "",
	"F_ContractFile": "fcc223d2-116f-6e6a-e2aa-8d1e9a8798e5",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": "",
	"F_CreateDate": "2017-07-13 16:18:58",
	"F_CreateUserId": null,
	"F_CreateUserName": "超级管理员",
	"F_ModifyDate": "2017-08-11 17:28:56",
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_Id": "4396d6ad-ce4c-8cd3-5e78-a6718e3e61b7",
	"F_CustomerId": "27607392-c60c-4ee6-9557-ef59f9410bbb",
	"F_SellerId": "a0270e2b-1fb2-42c0-8d45-66f0deddea64",
	"F_OrderDate": "2017-09-29 00:00:00",
	"F_OrderCode": "SO0929000003",
	"F_DiscountSum": null,
	"F_Accounts": 0.00,
	"F_ReceivedAmount": 1.00,
	"F_PaymentDate": "2017-09-29 00:00:00",
	"F_PaymentMode": null,
	"F_PaymentState": 2,
	"F_SaleCost": 1.00,
	"F_AbstractInfo": "1",
	"F_ContractCode": "1",
	"F_ContractFile": "c7cf0162-2133-873c-a6ca-708c35b587ce",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": "1",
	"F_CreateDate": "2018-04-03 16:34:44",
	"F_CreateUserId": "System",
	"F_CreateUserName": null,
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": "1"
}, {
	"F_Id": "fbbbfaf5-b559-fbea-df0d-ebbb0915955b",
	"F_CustomerId": "705a2756-2fc8-4074-b113-4040f2d3995f",
	"F_SellerId": "c9480ffd-0af1-47f3-ac92-4ff5a99843f6",
	"F_OrderDate": "2017-09-29 00:00:00",
	"F_OrderCode": "SO0929000004",
	"F_DiscountSum": null,
	"F_Accounts": 0.00,
	"F_ReceivedAmount": 1.00,
	"F_PaymentDate": "2017-09-29 00:00:00",
	"F_PaymentMode": null,
	"F_PaymentState": 2,
	"F_SaleCost": 1.00,
	"F_AbstractInfo": "1",
	"F_ContractCode": "1",
	"F_ContractFile": "e5f345ae-2152-9fea-6723-96782110a345",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": "1",
	"F_CreateDate": "2018-04-03 16:34:04",
	"F_CreateUserId": "System",
	"F_CreateUserName": null,
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": "1"
}, {
	"F_Id": "d604a075-cef3-b8e6-658a-12baf06e3ea6",
	"F_CustomerId": "27607392-c60c-4ee6-9557-ef59f9410bbb",
	"F_SellerId": "689431b9-a995-43b2-9966-09645bca53f4",
	"F_OrderDate": "2018-03-23 00:00:00",
	"F_OrderCode": "SO0323000001",
	"F_DiscountSum": null,
	"F_Accounts": 0.00,
	"F_ReceivedAmount": 10000000.00,
	"F_PaymentDate": "2018-03-23 00:00:00",
	"F_PaymentMode": null,
	"F_PaymentState": 2,
	"F_SaleCost": 1000.00,
	"F_AbstractInfo": null,
	"F_ContractCode": null,
	"F_ContractFile": "7a3ff3f2-28df-ba8b-7f19-3cdd6c2dcd82",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": "测试",
	"F_CreateDate": "2018-04-03 16:33:51",
	"F_CreateUserId": "System",
	"F_CreateUserName": null,
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_Id": "a8313bef-40d8-2f8a-a85f-b4b88f1b9fab",
	"F_CustomerId": "768db9d6-a310-41e4-b7b0-b3c520161c57",
	"F_SellerId": "3100a77a-0a24-4087-99f6-7306fef067b1",
	"F_OrderDate": "2018-04-03 00:00:00",
	"F_OrderCode": "SO0403000008",
	"F_DiscountSum": null,
	"F_Accounts": 0.00,
	"F_ReceivedAmount": 11111.00,
	"F_PaymentDate": "2018-04-03 00:00:00",
	"F_PaymentMode": null,
	"F_PaymentState": 2,
	"F_SaleCost": 1000.00,
	"F_AbstractInfo": null,
	"F_ContractCode": null,
	"F_ContractFile": "f2a79a9a-44f9-f60f-376f-3c3eb49e3b2f",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": "3fc486cb-c49b-1f56-87f1-8fed7176d1b7",
	"F_CreateDate": "2018-04-03 16:44:43",
	"F_CreateUserId": "System",
	"F_CreateUserName": null,
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_Id": "253e5cba-cee6-1b83-9f23-1e2381e96a85",
	"F_CustomerId": "6893bf56-e502-482f-9bd3-8c26532dc9a3",
	"F_SellerId": "8f2accbb-f389-4ce7-9972-92a437d12d87",
	"F_OrderDate": "2018-05-21 00:00:00",
	"F_OrderCode": "SO0521000001",
	"F_DiscountSum": null,
	"F_Accounts": 0.00,
	"F_ReceivedAmount": 500.00,
	"F_PaymentDate": "2018-05-21 00:00:00",
	"F_PaymentMode": null,
	"F_PaymentState": 2,
	"F_SaleCost": 500.00,
	"F_AbstractInfo": null,
	"F_ContractCode": null,
	"F_ContractFile": "51545679-514f-f072-b85d-d44503fa4cd6",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": "b5fbb356-5799-8f93-97ca-d61f9906bea5",
	"F_CreateDate": "2018-05-21 15:37:13",
	"F_CreateUserId": "221f644c-0f23-4e86-b639-bedac5d95664",
	"F_CreateUserName": null,
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_Id": "b5fbb356-5799-8f93-97ca-d61f9906bea5",
	"F_CustomerId": "768db9d6-a310-41e4-b7b0-b3c520161c57",
	"F_SellerId": "8f2accbb-f389-4ce7-9972-92a437d12d87",
	"F_OrderDate": "2018-05-21 00:00:00",
	"F_OrderCode": "SO0521000004",
	"F_DiscountSum": null,
	"F_Accounts": 0.00,
	"F_ReceivedAmount": 100.00,
	"F_PaymentDate": "2018-05-21 00:00:00",
	"F_PaymentMode": null,
	"F_PaymentState": 2,
	"F_SaleCost": 100.00,
	"F_AbstractInfo": null,
	"F_ContractCode": null,
	"F_ContractFile": "11641c54-906c-3a10-73e3-20beefa556fe",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": null,
	"F_CreateDate": "2018-05-21 16:46:00",
	"F_CreateUserId": "8f2accbb-f389-4ce7-9972-92a437d12d87",
	"F_CreateUserName": null,
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_Id": "f1a411b9-4156-487a-eecc-52da5638d818",
	"F_CustomerId": "6893bf56-e502-482f-9bd3-8c26532dc9a3",
	"F_SellerId": "6e73abf5-0960-42d1-8ba1-63236d40e303",
	"F_OrderDate": "2018-05-21 00:00:00",
	"F_OrderCode": "SO0521000005",
	"F_DiscountSum": null,
	"F_Accounts": 0.00,
	"F_ReceivedAmount": 1000.00,
	"F_PaymentDate": "2018-05-21 00:00:00",
	"F_PaymentMode": null,
	"F_PaymentState": 2,
	"F_SaleCost": 100.00,
	"F_AbstractInfo": null,
	"F_ContractCode": null,
	"F_ContractFile": "4b8e012b-6d12-7aa3-4e97-28ce6af6e444",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": "576a7263-c65b-d1d2-43dc-462ef94b7682",
	"F_CreateDate": "2018-05-21 16:51:13",
	"F_CreateUserId": "8f2accbb-f389-4ce7-9972-92a437d12d87",
	"F_CreateUserName": null,
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_Id": "406451e4-d602-02da-153f-4f6c84a91ed0",
	"F_CustomerId": "27607392-c60c-4ee6-9557-ef59f9410bbb",
	"F_SellerId": "8f2accbb-f389-4ce7-9972-92a437d12d87",
	"F_OrderDate": "2018-05-21 00:00:00",
	"F_OrderCode": "SO0521000009",
	"F_DiscountSum": 1.00,
	"F_Accounts": 2.00,
	"F_ReceivedAmount": 100.00,
	"F_PaymentDate": "2018-05-21 00:00:00",
	"F_PaymentMode": "1",
	"F_PaymentState": 2,
	"F_SaleCost": 100.00,
	"F_AbstractInfo": "",
	"F_ContractCode": "",
	"F_ContractFile": "438e53b5-3c30-26c4-b744-e3939145a7b8",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": "",
	"F_CreateDate": "2018-05-21 17:11:26",
	"F_CreateUserId": "8f2accbb-f389-4ce7-9972-92a437d12d87",
	"F_CreateUserName": "测试人员",
	"F_ModifyDate": "2018-07-20 15:36:32",
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_Id": "20a1eb02-1c3e-4355-980c-c21862352f6d",
	"F_CustomerId": "768db9d6-a310-41e4-b7b0-b3c520161c57",
	"F_SellerId": "7702ad2a-c3e9-411e-acef-0cc61bab0507",
	"F_OrderDate": "2017-07-13 00:00:00",
	"F_OrderCode": "SO0713000002",
	"F_DiscountSum": 0.00,
	"F_Accounts": 0.00,
	"F_ReceivedAmount": null,
	"F_PaymentDate": "2017-07-11 00:00:00",
	"F_PaymentMode": "2",
	"F_PaymentState": null,
	"F_SaleCost": 0.00,
	"F_AbstractInfo": null,
	"F_ContractCode": null,
	"F_ContractFile": "585eb761-d8d8-bb9b-674e-31e42802193b",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": null,
	"F_CreateDate": "2017-07-13 16:21:28",
	"F_CreateUserId": null,
	"F_CreateUserName": "超级管理员",
	"F_ModifyDate": "2017-09-25 16:28:38",
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_Id": "7535ed05-f717-4821-9e60-9792fe20e07f",
	"F_CustomerId": "768db9d6-a310-41e4-b7b0-b3c520161c57",
	"F_SellerId": "7702ad2a-c3e9-411e-acef-0cc61bab0507",
	"F_OrderDate": "2017-08-11 00:00:00",
	"F_OrderCode": "SO0811000003",
	"F_DiscountSum": 100900.00,
	"F_Accounts": 100900.00,
	"F_ReceivedAmount": null,
	"F_PaymentDate": "2017-08-11 00:00:00",
	"F_PaymentMode": "1",
	"F_PaymentState": null,
	"F_SaleCost": 0.00,
	"F_AbstractInfo": "",
	"F_ContractCode": "",
	"F_ContractFile": "51227ab1-77a6-bc89-a5d1-7c3bd6a94c25",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": "",
	"F_CreateDate": "2017-08-11 17:45:45",
	"F_CreateUserId": null,
	"F_CreateUserName": "徐晓悦",
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_Id": "576a7263-c65b-d1d2-43dc-462ef94b7682",
	"F_CustomerId": "6893bf56-e502-482f-9bd3-8c26532dc9a3",
	"F_SellerId": "8f2accbb-f389-4ce7-9972-92a437d12d87",
	"F_OrderDate": "2018-05-21 00:00:00",
	"F_OrderCode": "SO0521000006",
	"F_DiscountSum": null,
	"F_Accounts": 0.00,
	"F_ReceivedAmount": 100.00,
	"F_PaymentDate": "2018-05-21 00:00:00",
	"F_PaymentMode": null,
	"F_PaymentState": 2,
	"F_SaleCost": 1000.00,
	"F_AbstractInfo": null,
	"F_ContractCode": null,
	"F_ContractFile": "c85fbb4e-5ab8-7a8b-efeb-599498084745",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": null,
	"F_CreateDate": "2018-05-21 16:52:32",
	"F_CreateUserId": "8f2accbb-f389-4ce7-9972-92a437d12d87",
	"F_CreateUserName": null,
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_Id": "5b283e8e-d6c9-450f-a3c9-cbed2216c047",
	"F_CustomerId": "768db9d6-a310-41e4-b7b0-b3c520161c57",
	"F_SellerId": "689431b9-a995-43b2-9966-09645bca53f4",
	"F_OrderDate": "2017-07-13 00:00:00",
	"F_OrderCode": "SO0713000003",
	"F_DiscountSum": 0.00,
	"F_Accounts": 0.00,
	"F_ReceivedAmount": 111.00,
	"F_PaymentDate": "2017-07-26 00:00:00",
	"F_PaymentMode": "2",
	"F_PaymentState": 2,
	"F_SaleCost": 0.00,
	"F_AbstractInfo": null,
	"F_ContractCode": null,
	"F_ContractFile": "1044a54f-6f7c-3710-ef63-42df57c87d8e",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": null,
	"F_CreateDate": "2018-04-03 16:35:04",
	"F_CreateUserId": null,
	"F_CreateUserName": "超级管理员",
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_Id": "9155cf78-da74-6159-1f2c-0ebe7d112714",
	"F_CustomerId": "768db9d6-a310-41e4-b7b0-b3c520161c57",
	"F_SellerId": "ec8edbf2-b4b6-47f1-916b-f1d5c3acec0d",
	"F_OrderDate": "2017-09-25 00:00:00",
	"F_OrderCode": "SO0925000001",
	"F_DiscountSum": null,
	"F_Accounts": 0.00,
	"F_ReceivedAmount": 123123.00,
	"F_PaymentDate": "2017-09-25 00:00:00",
	"F_PaymentMode": null,
	"F_PaymentState": 2,
	"F_SaleCost": 100.00,
	"F_AbstractInfo": null,
	"F_ContractCode": null,
	"F_ContractFile": "e10f4e69-f4a7-a5d5-b3f3-37024570cb89",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": "测试cbb",
	"F_CreateDate": "2017-09-25 16:14:10",
	"F_CreateUserId": "System",
	"F_CreateUserName": null,
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_Id": "9e4bee31-ec5c-16ba-4a8d-e7ae9ee50037",
	"F_CustomerId": "768db9d6-a310-41e4-b7b0-b3c520161c57",
	"F_SellerId": "d31d1cd4-9bdf-4c2c-9620-617941b8e4e8",
	"F_OrderDate": "2017-09-28 00:00:00",
	"F_OrderCode": "SO0925000001",
	"F_DiscountSum": null,
	"F_Accounts": 0.00,
	"F_ReceivedAmount": 1231.00,
	"F_PaymentDate": "2017-09-25 00:00:00",
	"F_PaymentMode": null,
	"F_PaymentState": 2,
	"F_SaleCost": 100.00,
	"F_AbstractInfo": null,
	"F_ContractCode": null,
	"F_ContractFile": "c4f3eb5e-14c7-99ce-7a8b-f01b36a897a7",
	"F_SortCode": null,
	"F_DeleteMark": null,
	"F_EnabledMark": null,
	"F_Description": "测试cbb1",
	"F_CreateDate": "2018-04-03 16:35:26",
	"F_CreateUserId": "System",
	"F_CreateUserName": null,
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}],
				         // 列表数据
	         headData: [
	                {
                        label: "Id", name: "F_Id", width: 100, align: "left"
                       
                    },
	                {
                        label: "单据日期", name: "F_OrderDate", width: 100, align: "left",                       
                        formatter: function(cellvalue) {
						    if(cellvalue) {
							    return app.BASE_UTILS.Date.get_yyyy_MM_dd(new Date(cellvalue)); 
						    }else{
							    return '';
						    }
				        }
                    },

                    { label: "单据编号", name: "F_OrderCode", width: 130, align: "left" },
                    {
                        label: "客户名称", name: "F_CustomerId", width: 250, align: "left"
                        /*formatterAsync: function (callback, value, row) {
                            app.clientdata.getAsync('custmerData', {
                                url: '/LR_CRMModule/Customer/GetList',
                                key: value,
                                keyId: 'F_CustomerId',
                                callback: function (item) {
                                    callback(item.F_FullName);
                                }
                            });
                        }*/
                    },
                    {
                        label: "销售人员", name: "F_SellerId", width: 80, align: "left"
                       /* formatterAsync: function (callback, value, row) {
                            app.clientdata.getAsync('user', {
                                key: value,
                                callback: function (item) {
                                    callback(item.name);
                                }
                            });
                        }*/
                    },

                    { label: "优惠金额", name: "F_DiscountSum", width: 80, align: "left" },
                    { label: "收款金额", name: "F_Accounts", width: 80, align: "left" },
                    {
                        label: "收款方式", name: "F_PaymentMode", width: 80, align: "center"
                        /*formatterAsync: function (callback, value, row) {
                            app.clientdata.getAsync('dataItem', {
                                key: value,
                                code: 'Client_PaymentMode',
                                callback: function (_data) {
                                    callback(_data.text);
                                }
                            });
                        }*/
                    },
                    {
                    label: "收款状态", name: "F_PaymentState", width: 80, align: "center",
                    formatter: function (cellvalue) {
                        if (cellvalue == 2) {
                                return "<span style='color:green'>部分收款</span>";
                            } else if (cellvalue == 3) {
                                return "<span style='color:blue'>全部收款</span>";
                            } else {
                                return "<span style='color:red'>未收款</span>";
                            }
                        }
                    },
                    { label: "制单人员", name: "F_CreateUserName", width: 80, align: "left" },
                    { label: "备注", name: "F_Description", width: 200, align: "left" }
                ],                // 列数据	
	            mainId: 'F_Id',
                reloadSelected: true,
                isPage: true
	          
           
        });
      
         pageEvent.search();
          
       },
        
        search: function (param) {
            param = param || {};
            $('#gridtable').appGridSet('reload', param);
        }
       
    };


     // 保存数据后回调刷新
      refreshGirdData = function () {
        pageEvent.search();
    };
    
    $(function () {
        pageEvent.init();
    });

})(window.jQuery, top.app);