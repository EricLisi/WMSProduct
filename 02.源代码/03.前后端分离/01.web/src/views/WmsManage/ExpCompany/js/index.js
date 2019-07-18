var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "ExpCompany",
			form: {
				title: "快递公司",
				width: 800,
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
				url: '/api/ExpCompany/GatPagerListByWhere/' + app.APP_GLOBE_STORE.LOGIN_USER.Id,
//			rowdatas: [{
//									"Id": "6903ab9d-20cd-44c4-a380-09f229366e1f",
//									"EnCode": "001",
//									"FullName": "MM",
//									"KDAccout":'123000',
//									"KDPwd":'1',
//									"KDMonthAccout":'1',
//									"ApiKey":'1',
//									"KDNId":'1',
//									'WarehouseCode': '001',
//									"Contacts":'张三',
//									"Phone":'130XXXXXXXX',
//									"MobilePhone":'500-1444',
//									"WeChat":'111111',
//									"Fax":'4521111',
//									"Address":'XXXXXXX',
//									'Description': '2222222222'
//								}, {
//									"Id": "abe9fcf1-1879-41b1-948d-05d514102934",
//									"EnCode": "002",
//									"FullName": "DD",
//									"KDAccout":'123000',
//									"KDPwd":'1',
//									"KDMonthAccout":'1',
//									"ApiKey":'1',
//									"KDNId":'1',
//									'WarehouseCode': '001',
//									"Contacts":'李四',
//									"Phone":'130XXXXXXXX',
//									"MobilePhone":'500-1444',
//									"WeChat":'111111',
//									"Fax":'4521111',
//									"Address":'XXXXXXX',
//									'Description': '55555555'
//								}],
				headData: [
//				    {
//						label: "主键",
//						name: "Id",
//						width: 100,
//						align: 'center'
//					},
					{
						label: '编码',
						name: 'EnCode',
						width: 100,
						align: 'center'
					},
					{
						label: '名称',
						name: 'FullName',
						width: 100,
						align: 'center'
					},
					{
						label: '快递鸟账号',
						name: 'KDAccoutName',	
						width: 100,
						align: 'center'
					},
//					{
//						label: '快递鸟账号id',
//						name: 'KDAccout',
//						width: 100,
//						align: 'center'
//					},
					{
						label: '快递鸟密码',
						name: 'KDPwd',
						width: 100,
						align: 'center'
					},
					{
						label: '快递鸟秘钥',
						name: 'ApiKey',
						width: 100,
						align: 'center'
					},
					{
						label: '快递鸟ID',
						name: 'KDNId',
						width: 100,
						align: 'center',
						hidden: true
					},
					{
						label: '月结账号',
						name: 'KDMonthAccout',
						width: 100,
						align: 'center'
					},
					{
						label: '仓库名称',
						name: 'WarehouseName',
						width: 100,
						align: 'center'
					},
//					{
//						label: '仓库编码',
//						name: 'WarehouseId',
//						width: 100,
//						align: 'center'
//					},					
					{
						label: '联系人',
						name: 'Contacts',
						width: 150,
						align: 'center'
					},
					{
						label: '电话',
						name: 'Phone',
						width: 100,
						align: 'center'
					},
					{
						label: '手机',
						name: 'MobilePhone',
						width: 100,
						align: 'center'
					},
					{
						label: '微信',
						name: 'WeChat',
						width: 100,
						align: 'center'
					},
					{
						label: '传真',
						name: 'Fax',
						width: 100,
						align: 'center'
					},
					{
						label: '地址',
						name: 'Address',
						width: 100,
						align: 'center'
					},
					{
						label: '备注',
						name: 'Description',
						width: 150,
						align: 'center'
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