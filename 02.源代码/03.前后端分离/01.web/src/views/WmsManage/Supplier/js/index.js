var companyId = '';
var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";

	//var departmentId = '';
	//点击左侧树
	var nodeclick = function(item) {
		companyId = item.id;
		$('#titleinfo').text(item.text);
		var param = {
			companyId: item.id
		};
		$("#" + app.CommonIndexParams.grid.id).appGridSet('reload', param);
	}

	var options = {
		params: { //参数
			router: "/Supplier",
			form: {
				title: "供应商",
				width: 800,
				height: 450
			}
		},
		Event: { //初始化事件
			doBeforeInit: function() {
				$('#app_layout').appLayout();
				var CurrentId = localStorage.getItem('CurrentIds');
				app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Module/GetModuleById/' + CurrentId + '/' + app.APP_GLOBE_STORE.LOGIN_USER.Id, function(data) {
					appModuleButtonList = data.ButtonList;
					appModuleColumnList = data.ColumnList
					//					appModule = data.module;					
				});
			}
		},
		search: { //搜索						

		},
		tree: { //启用左侧树形
			options: {
				id: "companyTree",
				//url:"/api/Company/GetTreeJson",
				data: [{
					"id": "6deda034-8f3f-4f32-9abf-75c7162c8e67",
					"text": "上海区域",
					"value": "Cod_ShangHai",
					"parentnodes": "0",
					"showcheck": false,
					"isexpand": true,
					"complete": true,
					"hasChildren": true,
					"ChildNodes": [{
						"id": "55a5ff12-92de-45cd-8e70-e01454aed6c2",
						"text": "一级供应商",
						"value": "Greygog",
						"parentnodes": "6deda034-8f3f-4f32-9abf-75c7162c8e67",
						"showcheck": false,
						"isexpand": true,
						"complete": true,
						"hasChildren": false,
						"ChildNodes": []
					}, {
						"id": "df42e329-2b77-4845-9429-4751b2d78496",
						"text": "二级供应商",
						"value": "Clo",
						"parentnodes": "6deda034-8f3f-4f32-9abf-75c7162c8e67",
						"showcheck": false,
						"isexpand": true,
						"complete": true,
						"hasChildren": false,
						"ChildNodes": []
					}]
				}, {
					"id": "e6ad3582-bc4a-4b81-b2b1-34a81ab84ddb",
					"text": "海南区域",
					"value": "HN",
					"parentnodes": "0",
					"showcheck": false,
					"isexpand": true,
					"complete": true,
					"hasChildren": true,
					"ChildNodes": [{
						"id": "457f949f-7022-45b2-ac4a-81c939826c46",
						"text": "一级",
						"value": "Frist",
						"parentnodes": "e6ad3582-bc4a-4b81-b2b1-34a81ab84ddb",
						"showcheck": false,
						"isexpand": true,
						"complete": true,
						"hasChildren": false,
						"ChildNodes": []
					}]
				}],
				nodeClick: nodeclick
				//defaultValue: "53298b7a-404c-4337-aa7f-80b2a4ca6681"//设置默认值
			}
		},
		bindEvent: { //点击事件参数 
			add: {
				doBeforeEvent: function() {
					if(!!!companyId) {
						app.MODAL_UTILS.warning("请先选择供应商分类!")
						return {
							result: false,
							data: null
						}
					}

					return {
						result: true,
						data: {
							addParams: "?CompanyId=" + companyId
						}
					};
				}
			}

		},

		grid: { //grid 
			options: {
				//url: '/api/User/GatPagerListByWhere/' + app.APP_GLOBE_STORE.LOGIN_USER.Id,
				rowdatas: [{
					"Contacts": "李XX",
					"SperCategoryId": "55a5ff12-92de-45cd-8e70-e01454aed6c2",
					"TelePhone": "176XXXXXXXX",
					"Address": "湖南省长沙市长沙县湖南工程职业技术学院",
					"WeChat": "176XXXXXXXX",
					"Fax": "4858",
					"MobilePhone": "176XXXXXXXX",
					"Id": "1e705da9-268c-462b-8fa5-32bc71925e7b",
					"ParentId": "",
					"EnCode": "Greygog",
					"FullName": "白萝卜集团",
					"SortCode": 0,
					"DeleteMark": false,
					"EnabledMark": false,
					"Description": "2",
					"CreatorTime": "1900-01-01 00:00:00",
					"CreatorUserId": "",
					"LastModifyTime": "2018-12-21 08:51:51",
					"LastModifyUserId": "admin",
					"DeleteTime": "1900-01-01 00:00:00",
					"DeleteUserId": "",
					"CurrentLoginUserId": null,
					"Data1": null,
					"Data2": null,
					"Data3": null
				}],
				headData: [{
						label: '供应商编码',
						name: 'EnCode',
						width: 100,
						align: "center"
					},
					{
						label: '供应商名称',
						name: 'FullName',
						width: 160,
						align: "center"
					},
					{
						label: '联系人',
						name: 'Contacts',
						width: 45,
						align: 'center'
					},
					{
						label: '电话',
						name: 'TelePhone',
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
						label: '微信',
						name: 'WeChat',
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
						label: "备注",
						name: "Description",
						index: "Description",
						width: 200,
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