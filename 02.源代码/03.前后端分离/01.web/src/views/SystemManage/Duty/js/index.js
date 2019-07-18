(function($, app) {
	"use strict";
	var companyId = '';
	//点击左侧树
	var nodeclick = function(item) {
		companyId = item.id;
		$('#titleinfo').text(item.text);

	}

	var options = {
		params: { //参数
			router: "Duty",
			form: {
				title: "岗位",
				width: 750,
				height: 450
			}
		},
		Event: { //初始化事件
			doBeforeInit: function() {
				$('#app_layout').appLayout();
			}
		},
		serach: { //搜索			
			SearchEvent: "",
			id: "gridtable",
			param: {
				parentId: companyId
				//departmentId: departmentId
			}
		},
		tree: { //启用左侧树形
			options: {
				id: "companyTree",
				data: app.APP_GLOBE_STORE.DATA_STATUS['COMPANY'],
				nodeClick: nodeclick
				//defaultValue: "53298b7a-404c-4337-aa7f-80b2a4ca6681"//设置默认值
			}
		},
		bindEvent: { //点击事件参数 
			add: {
				doBeforeEvent: function() {
					if(!!!companyId) {
						app.MODAL_UTILS.warning("请先选择公司!")
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
				rowdatas: [{
					"Id": "eea1d103-75d5-4cc7-b35e-de9feb8e0050",
					"ParentId": "cd108661-7169-4216-ae30-a94afd2c45ae",
					"Name": "采购部经理",
					"EnCode": "G100006",
					"CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
					"DepartmentId": "16ce047b-a4b1-46b9-b29f-52d25efffcab",
					"DeleteMark": 0,
					"Description": null,
					"CreateDate": "2017-05-09 17:01:21",
					"CreateUserId": "System",
					"CreateUserName": "超级管理员",
					"ModifyDate": "2017-05-10 10:42:15",
					"ModifyUserId": "System",
					"ModifyUserName": "超级管理员"
				}, {
					"Id": "d03ecdfa-c035-4b86-be91-c696e1cf33d4",
					"ParentId": "cd108661-7169-4216-ae30-a94afd2c45ae",
					"Name": "财务总监",
					"EnCode": "G100003",
					"CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
					"DepartmentId": "23ac3ac1-097f-4007-8bd2-20fea87fe377",
					"DeleteMark": 0,
					"Description": null,
					"CreateDate": "2017-05-09 15:02:26",
					"CreateUserId": "System",
					"CreateUserName": "超级管理员",
					"ModifyDate": "2017-05-10 10:44:15",
					"ModifyUserId": "System",
					"ModifyUserName": "超级管理员"
				}, {
					"Id": "e6e88d5b-bcf7-4f49-b355-df9cd4865d31",
					"ParentId": "6945ccf1-926c-4eb7-a9bd-39a4754dab76",
					"Name": "销售经理",
					"EnCode": "G100051",
					"CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
					"DepartmentId": "2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1",
					"DeleteMark": 0,
					"Description": null,
					"CreateDate": "2017-05-10 10:48:05",
					"CreateUserId": "System",
					"CreateUserName": "超级管理员",
					"ModifyDate": "2017-06-01 14:16:52",
					"ModifyUserId": "24a055d6-5924-44c5-be52-3715cdd68011",
					"ModifyUserName": "陈彬彬"
				}, {
					"Id": "6945ccf1-926c-4eb7-a9bd-39a4754dab76",
					"ParentId": "cd108661-7169-4216-ae30-a94afd2c45ae",
					"Name": "销售总监",
					"EnCode": "G100005",
					"CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
					"DepartmentId": "2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1",
					"DeleteMark": 0,
					"Description": null,
					"CreateDate": "2017-05-09 17:00:29",
					"CreateUserId": "System",
					"CreateUserName": "超级管理员",
					"ModifyDate": "2017-05-10 10:42:22",
					"ModifyUserId": "System",
					"ModifyUserName": "超级管理员"
				}, {
					"Id": "df3db03b-026e-4120-b606-2396c80daea8",
					"ParentId": "e6e88d5b-bcf7-4f49-b355-df9cd4865d31",
					"Name": "销售专员",
					"EnCode": "G100511",
					"CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
					"DepartmentId": "2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1",
					"DeleteMark": 0,
					"Description": null,
					"CreateDate": "2017-05-10 10:48:33",
					"CreateUserId": "System",
					"CreateUserName": "超级管理员",
					"ModifyDate": "2017-06-01 14:16:56",
					"ModifyUserId": "24a055d6-5924-44c5-be52-3715cdd68011",
					"ModifyUserName": "陈彬彬"
				}, {
					"Id": "e19cc97b-4ffd-4e26-988f-c5749f300d12",
					"ParentId": "0315e2d5-2072-4f36-bc61-683fe48c564f",
					"Name": "软件工程师",
					"EnCode": "G100411",
					"CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
					"DepartmentId": "8684502a-5dc2-487c-b589-48d2eb7734ca",
					"DeleteMark": 0,
					"Description": null,
					"CreateDate": "2017-05-10 10:46:52",
					"CreateUserId": "System",
					"CreateUserName": "超级管理员",
					"ModifyDate": "2017-05-10 10:47:11",
					"ModifyUserId": "System",
					"ModifyUserName": "超级管理员"
				}, {
					"Id": "0315e2d5-2072-4f36-bc61-683fe48c564f",
					"ParentId": "6f71e942-f82a-4aa9-b187-35ea129d69e5",
					"Name": "IT经理",
					"EnCode": "G100041",
					"CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
					"DepartmentId": "8684502a-5dc2-487c-b589-48d2eb7734ca",
					"DeleteMark": 0,
					"Description": null,
					"CreateDate": "2017-05-10 10:46:04",
					"CreateUserId": "System",
					"CreateUserName": "超级管理员",
					"ModifyDate": null,
					"ModifyUserId": null,
					"ModifyUserName": null
				}, {
					"Id": "6f71e942-f82a-4aa9-b187-35ea129d69e5",
					"ParentId": "cd108661-7169-4216-ae30-a94afd2c45ae",
					"Name": "IT部总监",
					"EnCode": "G100004",
					"CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
					"DepartmentId": "8684502a-5dc2-487c-b589-48d2eb7734ca",
					"DeleteMark": 0,
					"Description": null,
					"CreateDate": "2017-05-09 16:59:13",
					"CreateUserId": "System",
					"CreateUserName": "超级管理员",
					"ModifyDate": "2017-05-10 10:42:31",
					"ModifyUserId": "System",
					"ModifyUserName": "超级管理员"
				}, {
					"Id": "07f30896-213a-4272-ad2c-5fbeb56e1bc9",
					"ParentId": "0",
					"Name": "总经理",
					"EnCode": "G100001",
					"CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
					"DepartmentId": "de4d40f6-ea94-465f-bffd-9573ba9abeb6",
					"DeleteMark": 0,
					"Description": null,
					"CreateDate": "2017-05-09 14:12:35",
					"CreateUserId": "System",
					"CreateUserName": "超级管理员",
					"ModifyDate": "2017-06-09 10:26:40",
					"ModifyUserId": "System",
					"ModifyUserName": "超级管理员"
				}, {
					"Id": "cd108661-7169-4216-ae30-a94afd2c45ae",
					"ParentId": "07f30896-213a-4272-ad2c-5fbeb56e1bc9",
					"Name": "副总经理",
					"EnCode": "G100002",
					"CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
					"DepartmentId": "de4d40f6-ea94-465f-bffd-9573ba9abeb6",
					"DeleteMark": 0,
					"Description": null,
					"CreateDate": "2017-05-09 14:14:33",
					"CreateUserId": "System",
					"CreateUserName": "超级管理员",
					"ModifyDate": "2017-06-09 10:26:50",
					"ModifyUserId": "System",
					"ModifyUserName": "超级管理员"
				}],
				headData: [{
						label: "岗位名称",
						name: "Name",
						width: 300,
						align: "center"
					},
					{
						label: "岗位编号",
						name: "EnCode",
						width: 100,
						align: "center"
					},
					{
						label: "所属部门",
						name: "DepartmentId",
						width: 120,
						align: "center"
						/*formatterAsync: function (callback, value) {
						    learun.clientdata.getAsync('department', {
						        key: value,
						        companyId: companyId,
						        callback: function (item) {
						            callback(item.FullName);
						        }
						    });
						}*/
					},
					{
						label: "创建人",
						name: "CreateUserName",
						width: 100,
						align: "center"
					},
					{
						label: "创建时间",
						name: "CreateDate",
						width: 100,
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
						label: "备注",
						name: "Description",
						width: 200,
						align: "center"
					},
				],
				isTree: true,
                mainId: 'Id',
                parentId: 'ParentId',
			}
		}
	};
	$(function() {
		app.CommonIndexEvent.init(options);
	})
})(window.jQuery, top.app)

/*
 * 模块管理主页面
 */
//var router="SystemManage/Module";
// var moduleId;
//var refreshGirdData; // 更新数据
//(function ($, app) {
//  "use strict";
//  /**
//   * 页面事件
//   */
//  var pageEvent = {
//      /**
//       * 初始化事件
//       */
//      init: function () {  
//          $('#app_layout').appLayout();
//          pageEvent.initConfig();            
//          pageEvent.bindEvent();
//          pageEvent.inittree();
//          pageEvent.initgrid()            
//      },
//      /**
//       * 初始化配置
//       */
//      initConfig:function(){
//          //错误页面路径重设
//          app.APP_CONFIGRATION.ROUTER_CONFIG.ERROR_PAGE_URL = "../../../Error/index.html";
//      },
//      /**
//       * 绑定事件
//       */
//      bindEvent: function () {
//          // 查询
//          $('#btn_Search').on('click', function () {
//              var keyword = $('#txt_Keyword').val();
//              page.search({ parentId: moduleId, keyword: keyword });
//          });
//          // 刷新
//          $('#app_refresh').on('click', function () {
//              location.reload();
//              
//          });
//          // 新增
//          $('#app_add').on('click', function () { 
//          	
//          	layx.iframe('1','添加','../html/form.html?moduleId=' + moduleId);            	           	
//               /*app.layerForm({
//                  id: 'form',
//                  title: '添加功能',
//                  url: '../html/form.html?moduleId=' + moduleId,
//                  height: 430,
//                  width: 700,
//                  btn: null
//              });*/
// 
//          });
//          // 编辑
//          $('#app_edit').on('click', function () {            	
//          	var keyValue = $('#gridtable').appGridValue('F_Id');
//          	//alert(keyValue)           	
//          	 if (app.BASE_UTILS.checkrow(keyValue)) {
//          	 	 layx.iframe('1','编辑','../html/form.html?keyValue=' + keyValue);
//          	 }
//                                     	                
//             
//          });
//          
//          // 删除
//          $('#app_delete').on('click', function () {
//              var keyValue = $('#gridtable').appGridValue('F_Id');
//              if (app.BASE_UTILS.checkrow(keyValue)) {         
//	                app.MODAL_UTILS.confirm({
//			                msg: "是否确认删除该项！",
//			                callback: function () {			                   
//	                            request.delete({
//									url:router+ "/DeleteForm?keyValue=" + keyValue,					
//									success: function(data) {						
//										refreshGirdData();										
//									}
//								});
//			                }
//	                })
//              }
//              
//          });
//      },
//      /**
//       * 初始化树
//       */
//      inittree: function () {
//          $('#module_tree').apptree({
//              //url:'/app_SystemFunction/Function/GetFunctionTree',
//              data: [
//				    {
//					"id": "698f872c-407b-471b-a28b-eee69a4e64ba",
//					"text": "敏捷开发",
//					"title": null,
//					"value": "AgileDevelopment",
//					"icon": "fa fa-send-o",
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": true,
//					"isexpand": false,
//					"complete": true,
//					"ChildNodes": [{
//						"id": "1a86c83c-4bd2-44eb-ae47-7e8e0476e73b",
//						"text": "敏捷开发向导",
//						"title": null,
//						"value": "pcguide",
//						"icon": "fa fa-location-arrow",
//						"showcheck": false,
//						"checkstate": 0,
//						"hasChildren": false,
//						"isexpand": false,
//						"complete": true,
//						"ChildNodes": [],
//						"parentId": "698f872c-407b-471b-a28b-eee69a4e64ba"
//					}, {
//						"id": "1f98c46c-72f1-4abb-b750-af1620d33c79",
//						"text": "代码生成器",
//						"title": null,
//						"value": "CodeGenerator",
//						"icon": "fa fa-desktop",
//						"showcheck": false,
//						"checkstate": 0,
//						"hasChildren": false,
//						"isexpand": false,
//						"complete": true,
//						"ChildNodes": [],
//						"parentId": "698f872c-407b-471b-a28b-eee69a4e64ba"
//					}, {
//						"id": "dcad6b11-1c43-4170-a45d-59b48a27bd4e",
//						"text": "图标查看",
//						"title": null,
//						"value": "Icon",
//						"icon": "fa fa-search",
//						"showcheck": false,
//						"checkstate": 0,
//						"hasChildren": false,
//						"isexpand": false,
//						"complete": true,
//						"ChildNodes": [],
//						"parentId": "698f872c-407b-471b-a28b-eee69a4e64ba"
//					}, {
//						"id": "abf9cd56-49bc-475f-ab78-46f4843e3075",
//						"text": "移动图标",
//						"title": null,
//						"value": "AppIcon",
//						"icon": "fa fa-tablet",
//						"showcheck": false,
//						"checkstate": 0,
//						"hasChildren": false,
//						"isexpand": false,
//						"complete": true,
//						"ChildNodes": [],
//						"parentId": "698f872c-407b-471b-a28b-eee69a4e64ba"
//					}, {
//						"id": "5977b03a-3eee-4f99-aa9a-6d1c299a86dc",
//						"text": "表格组件",
//						"title": null,
//						"value": "griddemo",
//						"icon": "fa fa-th-list",
//						"showcheck": false,
//						"checkstate": 0,
//						"hasChildren": true,
//						"isexpand": false,
//						"complete": true,
//						"ChildNodes": [{
//							"id": "6196d60f-2f2d-4846-8263-df94d873e7f6",
//							"text": "普通表格",
//							"title": null,
//							"value": "commongrid",
//							"icon": "fa fa-table",
//							"showcheck": false,
//							"checkstate": 0,
//							"hasChildren": false,
//							"isexpand": false,
//							"complete": true,
//							"ChildNodes": [],
//							"parentId": "5977b03a-3eee-4f99-aa9a-6d1c299a86dc"
//						}],
//						"parentId": "698f872c-407b-471b-a28b-eee69a4e64ba"
//					}, {
//						"id": "9f70b427-9c46-4d70-8f5c-4e7e7c48571c",
//						"text": "插件演示",
//						"title": null,
//						"value": "JsDemo",
//						"icon": "fa fa-send-o",
//						"showcheck": false,
//						"checkstate": 0,
//						"hasChildren": false,
//						"isexpand": false,
//						"complete": true,
//						"ChildNodes": [],
//						"parentId": "698f872c-407b-471b-a28b-eee69a4e64ba"
//					}],
//					"parentId": "0"
//				}],
//              //url:'/api/LabelPrint/Material/GetMatClass',
//              nodeClick: pageEvent.treeNodeClick
//          });
//      },        
//       /**
//       * 树节点点击
//       * @param {object} item 节点
//       */
//      treeNodeClick: function (item) {        	
//      	alert(item.id)
//          moduleId = item.id;
//          $('#titleinfo').text(item.text);
//          pageEvent.search({ parentId: moduleId });
//      },
//       /**
//       * 初始化表格
//       */
//       initgrid: function () {
//       $("#gridtable").appgrid({        	   	 	
//	            url: '',                // 数据服务地址
//	            param: {},                    // 请求参数
//	            rowdatas: 
//	            [{
//				"F_Id": "698f872c-407b-471b-a28b-eee69a4e64ba",
//				"F_ParentId": "0",
//				"F_EnCode": "AgileDevelopment",
//				"F_FullName": "敏捷开发",
//				"F_Icon": "fa fa-send-o",
//				"F_UrlAddress": null,
//				"F_Target": "expand",
//				"F_IsMenu": 1,
//				"F_AllowExpand": 0,
//				"F_IsPublic": 0,
//				"F_AllowEdit": null,
//				"F_AllowDelete": null,
//				"F_SortCode": 0,
//				"F_DeleteMark": 0,
//				"F_EnabledMark": 1,
//				"F_Description": null,
//				"F_CreateDate": "2017-04-12 14:42:47",
//				"F_CreateUserId": "System",
//				"F_CreateUserName": "超级管理员",
//				"F_ModifyDate": "2018-02-02 11:16:50",
//				"F_ModifyUserId": "System",
//				"F_ModifyUserName": "超级管理员"
//			}, {
//				"F_Id": "1",
//				"F_ParentId": "0",
//				"F_EnCode": "SysManage",
//				"F_FullName": "系统管理",
//				"F_Icon": "fa fa-desktop",
//				"F_UrlAddress": "",
//				"F_Target": "expand",
//				"F_IsMenu": 1,
//				"F_AllowExpand": 0,
//				"F_IsPublic": 0,
//				"F_AllowEdit": null,
//				"F_AllowDelete": null,
//				"F_SortCode": 1,
//				"F_DeleteMark": 0,
//				"F_EnabledMark": 1,
//				"F_Description": "",
//				"F_CreateDate": null,
//				"F_CreateUserId": null,
//				"F_CreateUserName": null,
//				"F_ModifyDate": "2017-04-12 14:31:46",
//				"F_ModifyUserId": "System",
//				"F_ModifyUserName": "超级管理员"
//			}, {
//				"F_Id": "2",
//				"F_ParentId": "0",
//				"F_EnCode": "BaseManage",
//				"F_FullName": "单位组织",
//				"F_Icon": "fa fa-coffee",
//				"F_UrlAddress": "",
//				"F_Target": "expand",
//				"F_IsMenu": 1,
//				"F_AllowExpand": 0,
//				"F_IsPublic": 0,
//				"F_AllowEdit": null,
//				"F_AllowDelete": null,
//				"F_SortCode": 2,
//				"F_DeleteMark": 0,
//				"F_EnabledMark": 1,
//				"F_Description": "",
//				"F_CreateDate": null,
//				"F_CreateUserId": null,
//				"F_CreateUserName": null,
//				"F_ModifyDate": "2017-08-30 14:29:38",
//				"F_ModifyUserId": "System",
//				"F_ModifyUserName": "超级管理员"
//			}, {
//				"F_Id": "dc5701b6-989b-48ff-a333-b04d10ebba00",
//				"F_ParentId": "0",
//				"F_EnCode": "FormManager",
//				"F_FullName": "表单应用",
//				"F_Icon": "fa fa-table",
//				"F_UrlAddress": null,
//				"F_Target": "expand",
//				"F_IsMenu": 1,
//				"F_AllowExpand": 0,
//				"F_IsPublic": 0,
//				"F_AllowEdit": null,
//				"F_AllowDelete": null,
//				"F_SortCode": 3,
//				"F_DeleteMark": 0,
//				"F_EnabledMark": 1,
//				"F_Description": "快速开发功能",
//				"F_CreateDate": "2016-11-16 10:13:48",
//				"F_CreateUserId": "System",
//				"F_CreateUserName": "超级管理员",
//				"F_ModifyDate": "2018-02-02 10:51:47",
//				"F_ModifyUserId": "System",
//				"F_ModifyUserName": "超级管理员"
//			}, {
//				"F_Id": "5",
//				"F_ParentId": "0",
//				"F_EnCode": "FlowManage",
//				"F_FullName": "流程应用",
//				"F_Icon": "fa fa-share-alt",
//				"F_UrlAddress": null,
//				"F_Target": "expand",
//				"F_IsMenu": 1,
//				"F_AllowExpand": 0,
//				"F_IsPublic": 0,
//				"F_AllowEdit": null,
//				"F_AllowDelete": null,
//				"F_SortCode": 4,
//				"F_DeleteMark": 0,
//				"F_EnabledMark": 1,
//				"F_Description": null,
//				"F_CreateDate": null,
//				"F_CreateUserId": null,
//				"F_CreateUserName": null,
//				"F_ModifyDate": "2018-02-02 10:52:05",
//				"F_ModifyUserId": "System",
//				"F_ModifyUserName": "超级管理员"
//			}, {
//				"F_Id": "d0971af6-66a3-4875-a200-321e9afb9e0e",
//				"F_ParentId": "0",
//				"F_EnCode": "AppManager",
//				"F_FullName": "移动管理",
//				"F_Icon": "fa fa-android",
//				"F_UrlAddress": null,
//				"F_Target": "expand",
//				"F_IsMenu": 1,
//				"F_AllowExpand": 0,
//				"F_IsPublic": 0,
//				"F_AllowEdit": null,
//				"F_AllowDelete": null,
//				"F_SortCode": 5,
//				"F_DeleteMark": 0,
//				"F_EnabledMark": 1,
//				"F_Description": null,
//				"F_CreateDate": "2017-09-05 11:25:04",
//				"F_CreateUserId": "System",
//				"F_CreateUserName": "超级管理员",
//				"F_ModifyDate": "2018-03-16 10:14:25",
//				"F_ModifyUserId": "System",
//				"F_ModifyUserName": "超级管理员"
//			}, {
//				"F_Id": "6",
//				"F_ParentId": "0",
//				"F_EnCode": "ReportManage",
//				"F_FullName": "报表应用",
//				"F_Icon": "fa fa-area-chart",
//				"F_UrlAddress": null,
//				"F_Target": "expand",
//				"F_IsMenu": 1,
//				"F_AllowExpand": 0,
//				"F_IsPublic": 0,
//				"F_AllowEdit": null,
//				"F_AllowDelete": null,
//				"F_SortCode": 6,
//				"F_DeleteMark": 0,
//				"F_EnabledMark": 1,
//				"F_Description": null,
//				"F_CreateDate": null,
//				"F_CreateUserId": null,
//				"F_CreateUserName": null,
//				"F_ModifyDate": "2018-03-16 10:14:35",
//				"F_ModifyUserId": "System",
//				"F_ModifyUserName": "超级管理员"
//			}, {
//				"F_Id": "4",
//				"F_ParentId": "0",
//				"F_EnCode": "CommonInfo",
//				"F_FullName": "扩展应用",
//				"F_Icon": "fa fa-globe",
//				"F_UrlAddress": null,
//				"F_Target": "expand",
//				"F_IsMenu": 1,
//				"F_AllowExpand": 0,
//				"F_IsPublic": 0,
//				"F_AllowEdit": null,
//				"F_AllowDelete": null,
//				"F_SortCode": 7,
//				"F_DeleteMark": 0,
//				"F_EnabledMark": 1,
//				"F_Description": null,
//				"F_CreateDate": null,
//				"F_CreateUserId": null,
//				"F_CreateUserName": null,
//				"F_ModifyDate": "2018-05-08 15:40:12",
//				"F_ModifyUserId": "System",
//				"F_ModifyUserName": "超级管理员"
//			}],                 // 列表数据
//	        headData: [
//			{ label: "F_Id", name: "F_Id", width: 150, align: "center" },
//			{ label: "编号", name: "F_EnCode", width: 150, align: "center" },
//                  { label: "名称", name: "F_FullName", width: 150, align: "center" },
//                  { label: "地址", name: "F_UrlAddress", width: 350, align: "center" },
//                  { label: "目标", name: "F_Target", width: 60, align: "center" },
//                  {
//                      label: "菜单", name: "F_IsMenu", width: 50, align: "center",
//                      formatter: function (cellvalue, rowObject) {
//                          return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
//                      }
//                  },
//                  {
//                      label: "展开", name: "F_AllowExpand", width: 50, align: "center",
//                      formatter: function (cellvalue, rowObject) {
//                          return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
//                      }
//                  },
//                  //{
//                  //    label: "公共", name: "F_IsPublic", width: 50, align: "center",
//                  //    formatter: function (cellvalue, rowObject) {
//                  //        return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
//                  //    }
//                  //},
//                  {
//                      label: "有效", name: "F_EnabledMark", width: 50, align: "center",
//                      formatter: function (cellvalue, rowObject) {
//                          return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
//                      }
//                  },
//                  { label: "描述", name: "F_Description", width: 200, align: "center" }
//		],                                    // 列数据	
//	           
//      });
//       pageEvent.search({ parentId: moduleId });
//     },
//      search: function (param) {
//          $('#gridtable').appGridSet('reload', param);
//      }
//  } 
//  // 保存数据后回调刷新
//  refreshGirdData = function () {
//      pageEvent.search({ parentId: moduleId });
//      //$('#module_tree').apptreeSet('refresh');
//  }
//
//
//  $(function () {
//      pageEvent.init();
//  });
//
//})(window.jQuery, top.app);

///*
// * 模块管理主页面
// */
//var router="SystemManage/Duty";
//var selectedRow;
//var refreshGirdData;
//
//(function ($, app) {
//  "use strict";
//   var companyId = '';
//  var departmentId = '';
//  /**
//   * 页面事件
//   */
//  var pageEvent = {
//      /**
//       * 初始化事件
//       */
//      init: function () { 
//          $('#app_layout').appLayout();
//          pageEvent.initConfig();
//          pageEvent.inittree();
//          pageEvent.initgrid();
//          pageEvent.bindEvent()
//                      
//      },
//      /**
//       * 初始化配置
//       */
//      initConfig:function(){
//          //错误页面路径重设
//          app.APP_CONFIGRATION.ROUTER_CONFIG.ERROR_PAGE_URL = "../../../Error/index.html";
//      },
//      /**
//       * 绑定事件
//       */
//      bindEvent: function () {
//          // 查询
//          $('#btn_Search').on('click', function () {
//              var keyword = $('#txt_Keyword').val();
//              pageEvent.search({keyword: keyword });
//          });
//           // 部门选择
//          $('#department_select').appselect({
//              type: 'tree',
//              placeholder: '请选择部门',
//              // 展开最大高度
//              maxHeight: 300,
//              // 是否允许搜索
//              allowSearch: true,
//              select: function (item) {
//
//                  if (!item || item.value == '-1') {
//                      departmentId = '';
//                  }
//                  else {
//                      departmentId = item.value;
//                  }
//                  pageEvent.search();
//              }
//          });
//          // 刷新
//          $('#app_refresh').on('click', function () {
//              location.reload();
//              
//          });
//          // 新增
//          $('#app_add').on('click', function () {             	
//          	if (!companyId) {
//                  app.MODAL_UTILS.warning('请选择公司！');
//                  return false;
//              }
//              selectedRow = null;
//              //layx.iframe('1','添加','../html/form.html?companyId=' + companyId);
//              layx.iframe('1','添加','../html/form.html?companyId=' + companyId,{
//				    statusBar:true,				                          
//				    buttons:[
//				        {
//				            label:'保存',
//				            callback:function(id, button, event){
//				                // 获取 iframe 页面 window对象
//				                var contentWindow=layx.getFrameContext(id);				               
//				                contentWindow.acceptClick(refreshGirdData);
//				                layx.destroy(id);    
//				            },
//				            style:'border-color: #4898d5;background-color: #2e8ded;color: #fff;'
//				        },
//				        {
//				            label:'取消',
//				            callback:function(id, button, event){
//				                layx.destroy(id);
//				            }
//				        }
//				    ]
//				}); 
//          });
//          // 编辑
//          $('#app_edit').on('click', function () {            	
//          	var keyValue = $('#gridtable').appGridValue('F_Id');
//              selectedRow = $('#gridtable').appGridGet('rowdata');           	
//          	 if (app.BASE_UTILS.checkrow(keyValue)) {
//          	 	 //layx.iframe('1','编辑','../html/form.html?companyId=' + companyId);
//          	 	layx.iframe('1','编辑','../html/form.html?companyId=' + companyId,{
//					    statusBar:true,				                          
//					    buttons:[
//					        {
//					            label:'保存',
//					            callback:function(id, button, event){
//					                // 获取 iframe 页面 window对象
//					                var contentWindow=layx.getFrameContext(id);				               
//					                contentWindow.acceptClick(refreshGirdData);
//					                layx.destroy(id);    
//					            },
//					            style:'border-color: #4898d5;background-color: #2e8ded;color: #fff;'
//					        },
//					        {
//					            label:'取消',
//					            callback:function(id, button, event){
//					                layx.destroy(id);
//					            }
//					        }
//					    ]
//					}); 
//          	 }            	                                                                        	                               
//          });
//          
//          // 删除
//          $('#app_delete').on('click', function () {
//              var keyValue = $('#gridtable').appGridValue('F_Id');
//              if (app.BASE_UTILS.checkrow(keyValue)) {         
//	                app.MODAL_UTILS.confirm({
//			                msg: "是否确认删除该项！",
//			                callback: function () {				                	
//		                        if (res) {
//		                            app.deleteForm(top.$.rootUrl + '/LR_OrganizationModule/Post/DeleteForm', { keyValue: keyValue }, function () {
//		                                refreshGirdData();
//		                            });
//		                            /*request.delete({
//										url:router+ "/DeleteForm?keyValue=" + keyValue,					
//										success: function(data) {						
//											refreshGirdData();									
//										}
//									});*/
//		                        }                    	                            
//			                }
//	                })
//              }
//              
//          });
//           // 添加岗位成员
//          $('#app_memberadd').on('click', function () {
//              var keyValue = $('#gridtable').appGridValue('F_Id');
//              selectedRow = $('#gridtable').appGridGet('rowdata');
//              if (app.BASE_UTILS.checkrow(keyValue)) {
//              	layx.iframe('1','添加岗位成员','../html/SelectForm.html?objectId=' + keyValue + '&companyId=' + companyId + '&departmentId=' + selectedRow.F_DepartmentId + '&category=2');
//                  /*learun.layerForm({
//                      id: 'form',
//                      title: '添加岗位成员',
//                      url: top.$.rootUrl + '/LR_AuthorizeModule/UserRelation/SelectForm?objectId=' + keyValue + '&companyId=' + companyId + '&departmentId=' + selectedRow.F_DepartmentId + '&category=2',
//                      width: 800,
//                      height: 520,
//                      callBack: function (id) {
//                          return top[id].acceptClick();
//                      }
//                  });*/
//              }
//          });
//          // 产看成员
//          /*$('#app_memberlook').on('click', function () {
//              var keyValue = $('#gridtable').appGridValue('F_Id');
//              if (app.BASE_UTILS.checkrow(keyValue)) {
//              	//layx.iframe('1','查看岗位成员','../html/LookForm.html?objectId=' + keyValue)
//                  learun.layerForm({
//                      id: 'form',
//                      title: '查看岗位成员',
//                      url: top.$.rootUrl + '/LR_AuthorizeModule/UserRelation/LookForm?objectId=' + keyValue,
//                      width: 800,
//                      height: 520,
//                      btn: null
//                  });
//              }
//          });*/
//          
//      },
//       /**
//       * 初始化树
//       */
//      inittree: function () {
//          $('#companyTree').apptree({
//              //url: top.$.rootUrl + '/LR_OrganizationModule/Company/GetTree',
//              data:[{
//					"id": "207fa1a9-160c-4943-a89b-8fa4db0547ce",
//					"text": "力软信息技术有限公司",
//					"title": null,
//					"value": "207fa1a9-160c-4943-a89b-8fa4db0547ce",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": true,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [{
//						"id": "4dfdb713-9e7c-4c86-a4a4-188b774be7cb",
//						"text": "力软（北京）公司",
//						"title": null,
//						"value": "4dfdb713-9e7c-4c86-a4a4-188b774be7cb",
//						"icon": null,
//						"showcheck": false,
//						"checkstate": 0,
//						"hasChildren": false,
//						"isexpand": true,
//						"complete": true,
//						"ChildNodes": [],
//						"parentId": "207fa1a9-160c-4943-a89b-8fa4db0547ce"
//					}, {
//						"id": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
//						"text": "力软（上海）公司",
//						"title": null,
//						"value": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
//						"icon": null,
//						"showcheck": false,
//						"checkstate": 0,
//						"hasChildren": false,
//						"isexpand": true,
//						"complete": true,
//						"ChildNodes": [],
//						"parentId": "207fa1a9-160c-4943-a89b-8fa4db0547ce"
//					}, {
//						"id": "7a579db2-f4e3-489c-aed9-d39cf78a1cfe",
//						"text": "力软（苏州）公司",
//						"title": null,
//						"value": "7a579db2-f4e3-489c-aed9-d39cf78a1cfe",
//						"icon": null,
//						"showcheck": false,
//						"checkstate": 0,
//						"hasChildren": false,
//						"isexpand": true,
//						"complete": true,
//						"ChildNodes": [],
//						"parentId": "207fa1a9-160c-4943-a89b-8fa4db0547ce"
//					}, {
//						"id": "646617bb-37c1-473a-8384-19640ebec22c",
//						"text": "力软（重庆）公司",
//						"title": null,
//						"value": "646617bb-37c1-473a-8384-19640ebec22c",
//						"icon": null,
//						"showcheck": false,
//						"checkstate": 0,
//						"hasChildren": false,
//						"isexpand": true,
//						"complete": true,
//						"ChildNodes": [],
//						"parentId": "207fa1a9-160c-4943-a89b-8fa4db0547ce"
//					}],
//					"parentId": "0"
//				}],
//              param: { parentId: '0' },
//              nodeClick: pageEvent.treeNodeClick
//          });
//          $('#companyTree').apptreeSet('setValue', '53298b7a-404c-4337-aa7f-80b2a4ca6681');
//      },
//      treeNodeClick: function (item) {
//          companyId = item.id;
//          $('#titleinfo').text(item.text);
//
//          $('#department_select').appselectRefresh({
//              // 访问数据接口地址
//              //url: top.$.rootUrl + '/LR_OrganizationModule/Department/GetTree',
//              data:[{
//					"id": "23ac3ac1-097f-4007-8bd2-20fea87fe377",
//					"text": "财务部",
//					"title": null,
//					"value": "23ac3ac1-097f-4007-8bd2-20fea87fe377",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}, {
//					"id": "16ce047b-a4b1-46b9-b29f-52d25efffcab",
//					"text": "采购部",
//					"title": null,
//					"value": "16ce047b-a4b1-46b9-b29f-52d25efffcab",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}, {
//					"id": "606c458a-6356-4286-8ac6-e3cad4bdf621",
//					"text": "仓储部",
//					"title": null,
//					"value": "606c458a-6356-4286-8ac6-e3cad4bdf621",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}, {
//					"id": "a1057d3c-a232-489a-858f-a328e19e2a86",
//					"text": "工程部",
//					"title": null,
//					"value": "a1057d3c-a232-489a-858f-a328e19e2a86",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}, {
//					"id": "1e160d35-5b89-46b7-b7f6-3f1f97b3cc15",
//					"text": "媒体部",
//					"title": null,
//					"value": "1e160d35-5b89-46b7-b7f6-3f1f97b3cc15",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}, {
//					"id": "946ead87-d5c0-4f74-847d-403d328a4f4e",
//					"text": "培训部",
//					"title": null,
//					"value": "946ead87-d5c0-4f74-847d-403d328a4f4e",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}, {
//					"id": "5a56013d-2327-4027-9010-365c6f423373",
//					"text": "品质部",
//					"title": null,
//					"value": "5a56013d-2327-4027-9010-365c6f423373",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}, {
//					"id": "4a4e0754-5440-4eac-a161-c03fd03c2e2f",
//					"text": "人事部",
//					"title": null,
//					"value": "4a4e0754-5440-4eac-a161-c03fd03c2e2f",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}, {
//					"id": "94588899-4f1c-42ed-9983-0a1af348db22",
//					"text": "生产部",
//					"title": null,
//					"value": "94588899-4f1c-42ed-9983-0a1af348db22",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}, {
//					"id": "2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1",
//					"text": "市场部",
//					"title": null,
//					"value": "2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}, {
//					"id": "8684502a-5dc2-487c-b589-48d2eb7734ca",
//					"text": "信息技术部",
//					"title": null,
//					"value": "8684502a-5dc2-487c-b589-48d2eb7734ca",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}, {
//					"id": "8df11cbf-922a-4090-b31a-b60882803132",
//					"text": "行政部",
//					"title": null,
//					"value": "8df11cbf-922a-4090-b31a-b60882803132",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}, {
//					"id": "921a0e6c-bbb6-44c7-8b7f-26dd4224a364",
//					"text": "研发部",
//					"title": null,
//					"value": "921a0e6c-bbb6-44c7-8b7f-26dd4224a364",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}, {
//					"id": "bebcb255-5254-4250-88f4-06c5680c55f2",
//					"text": "业务部",
//					"title": null,
//					"value": "bebcb255-5254-4250-88f4-06c5680c55f2",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}, {
//					"id": "6b546b72-e40e-4913-a140-f76ac1aba638",
//					"text": "营销部",
//					"title": null,
//					"value": "6b546b72-e40e-4913-a140-f76ac1aba638",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}, {
//					"id": "de4d40f6-ea94-465f-bffd-9573ba9abeb6",
//					"text": "总裁办",
//					"title": null,
//					"value": "de4d40f6-ea94-465f-bffd-9573ba9abeb6",
//					"icon": null,
//					"showcheck": false,
//					"checkstate": 0,
//					"hasChildren": false,
//					"isexpand": true,
//					"complete": true,
//					"ChildNodes": [],
//					"parentId": "0"
//				}],
//              // 访问数据接口参数
//              param: { companyId: companyId, parentId: '0' },
//          });
//          departmentId = '';
//          pageEvent.search();
//      },
//      
//       /**
//       * 初始化表格
//       */
//      initgrid: function () {
//	         $("#gridtable").appgrid({        	   	 	
//		            url: '',                // 数据服务地址
//		            param: {},                    // 请求参数
//		            rowdatas: [{
//						"F_Id": "eea1d103-75d5-4cc7-b35e-de9feb8e0050",
//						"F_ParentId": "cd108661-7169-4216-ae30-a94afd2c45ae",
//						"F_Name": "采购部经理",
//						"F_EnCode": "G100006",
//						"F_CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
//						"F_DepartmentId": "16ce047b-a4b1-46b9-b29f-52d25efffcab",
//						"F_DeleteMark": 0,
//						"F_Description": null,
//						"F_CreateDate": "2017-05-09 17:01:21",
//						"F_CreateUserId": "System",
//						"F_CreateUserName": "超级管理员",
//						"F_ModifyDate": "2017-05-10 10:42:15",
//						"F_ModifyUserId": "System",
//						"F_ModifyUserName": "超级管理员"
//					}, {
//						"F_Id": "d03ecdfa-c035-4b86-be91-c696e1cf33d4",
//						"F_ParentId": "cd108661-7169-4216-ae30-a94afd2c45ae",
//						"F_Name": "财务总监",
//						"F_EnCode": "G100003",
//						"F_CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
//						"F_DepartmentId": "23ac3ac1-097f-4007-8bd2-20fea87fe377",
//						"F_DeleteMark": 0,
//						"F_Description": null,
//						"F_CreateDate": "2017-05-09 15:02:26",
//						"F_CreateUserId": "System",
//						"F_CreateUserName": "超级管理员",
//						"F_ModifyDate": "2017-05-10 10:44:15",
//						"F_ModifyUserId": "System",
//						"F_ModifyUserName": "超级管理员"
//					}, {
//						"F_Id": "e6e88d5b-bcf7-4f49-b355-df9cd4865d31",
//						"F_ParentId": "6945ccf1-926c-4eb7-a9bd-39a4754dab76",
//						"F_Name": "销售经理",
//						"F_EnCode": "G100051",
//						"F_CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
//						"F_DepartmentId": "2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1",
//						"F_DeleteMark": 0,
//						"F_Description": null,
//						"F_CreateDate": "2017-05-10 10:48:05",
//						"F_CreateUserId": "System",
//						"F_CreateUserName": "超级管理员",
//						"F_ModifyDate": "2017-06-01 14:16:52",
//						"F_ModifyUserId": "24a055d6-5924-44c5-be52-3715cdd68011",
//						"F_ModifyUserName": "陈彬彬"
//					}, {
//						"F_Id": "6945ccf1-926c-4eb7-a9bd-39a4754dab76",
//						"F_ParentId": "cd108661-7169-4216-ae30-a94afd2c45ae",
//						"F_Name": "销售总监",
//						"F_EnCode": "G100005",
//						"F_CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
//						"F_DepartmentId": "2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1",
//						"F_DeleteMark": 0,
//						"F_Description": null,
//						"F_CreateDate": "2017-05-09 17:00:29",
//						"F_CreateUserId": "System",
//						"F_CreateUserName": "超级管理员",
//						"F_ModifyDate": "2017-05-10 10:42:22",
//						"F_ModifyUserId": "System",
//						"F_ModifyUserName": "超级管理员"
//					}, {
//						"F_Id": "df3db03b-026e-4120-b606-2396c80daea8",
//						"F_ParentId": "e6e88d5b-bcf7-4f49-b355-df9cd4865d31",
//						"F_Name": "销售专员",
//						"F_EnCode": "G100511",
//						"F_CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
//						"F_DepartmentId": "2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1",
//						"F_DeleteMark": 0,
//						"F_Description": null,
//						"F_CreateDate": "2017-05-10 10:48:33",
//						"F_CreateUserId": "System",
//						"F_CreateUserName": "超级管理员",
//						"F_ModifyDate": "2017-06-01 14:16:56",
//						"F_ModifyUserId": "24a055d6-5924-44c5-be52-3715cdd68011",
//						"F_ModifyUserName": "陈彬彬"
//					}, {
//						"F_Id": "e19cc97b-4ffd-4e26-988f-c5749f300d12",
//						"F_ParentId": "0315e2d5-2072-4f36-bc61-683fe48c564f",
//						"F_Name": "软件工程师",
//						"F_EnCode": "G100411",
//						"F_CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
//						"F_DepartmentId": "8684502a-5dc2-487c-b589-48d2eb7734ca",
//						"F_DeleteMark": 0,
//						"F_Description": null,
//						"F_CreateDate": "2017-05-10 10:46:52",
//						"F_CreateUserId": "System",
//						"F_CreateUserName": "超级管理员",
//						"F_ModifyDate": "2017-05-10 10:47:11",
//						"F_ModifyUserId": "System",
//						"F_ModifyUserName": "超级管理员"
//					}, {
//						"F_Id": "0315e2d5-2072-4f36-bc61-683fe48c564f",
//						"F_ParentId": "6f71e942-f82a-4aa9-b187-35ea129d69e5",
//						"F_Name": "IT经理",
//						"F_EnCode": "G100041",
//						"F_CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
//						"F_DepartmentId": "8684502a-5dc2-487c-b589-48d2eb7734ca",
//						"F_DeleteMark": 0,
//						"F_Description": null,
//						"F_CreateDate": "2017-05-10 10:46:04",
//						"F_CreateUserId": "System",
//						"F_CreateUserName": "超级管理员",
//						"F_ModifyDate": null,
//						"F_ModifyUserId": null,
//						"F_ModifyUserName": null
//					}, {
//						"F_Id": "6f71e942-f82a-4aa9-b187-35ea129d69e5",
//						"F_ParentId": "cd108661-7169-4216-ae30-a94afd2c45ae",
//						"F_Name": "IT部总监",
//						"F_EnCode": "G100004",
//						"F_CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
//						"F_DepartmentId": "8684502a-5dc2-487c-b589-48d2eb7734ca",
//						"F_DeleteMark": 0,
//						"F_Description": null,
//						"F_CreateDate": "2017-05-09 16:59:13",
//						"F_CreateUserId": "System",
//						"F_CreateUserName": "超级管理员",
//						"F_ModifyDate": "2017-05-10 10:42:31",
//						"F_ModifyUserId": "System",
//						"F_ModifyUserName": "超级管理员"
//					}, {
//						"F_Id": "07f30896-213a-4272-ad2c-5fbeb56e1bc9",
//						"F_ParentId": "0",
//						"F_Name": "总经理",
//						"F_EnCode": "G100001",
//						"F_CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
//						"F_DepartmentId": "de4d40f6-ea94-465f-bffd-9573ba9abeb6",
//						"F_DeleteMark": 0,
//						"F_Description": null,
//						"F_CreateDate": "2017-05-09 14:12:35",
//						"F_CreateUserId": "System",
//						"F_CreateUserName": "超级管理员",
//						"F_ModifyDate": "2017-06-09 10:26:40",
//						"F_ModifyUserId": "System",
//						"F_ModifyUserName": "超级管理员"
//					}, {
//						"F_Id": "cd108661-7169-4216-ae30-a94afd2c45ae",
//						"F_ParentId": "07f30896-213a-4272-ad2c-5fbeb56e1bc9",
//						"F_Name": "副总经理",
//						"F_EnCode": "G100002",
//						"F_CompanyId": "53298b7a-404c-4337-aa7f-80b2a4ca6681",
//						"F_DepartmentId": "de4d40f6-ea94-465f-bffd-9573ba9abeb6",
//						"F_DeleteMark": 0,
//						"F_Description": null,
//						"F_CreateDate": "2017-05-09 14:14:33",
//						"F_CreateUserId": "System",
//						"F_CreateUserName": "超级管理员",
//						"F_ModifyDate": "2017-06-09 10:26:50",
//						"F_ModifyUserId": "System",
//						"F_ModifyUserName": "超级管理员"
//					}],                 // 列表数据
//			        headData: [
//					{ label: "岗位名称", name: "F_Name", width: 300, align: "center" },
//		                        { label: "岗位编号", name: "F_EnCode", width: 100, align: "center" },
//		                        {
//									label: '主键',
//									name: 'F_Id'
//								
//								},
//		                        {
//		                            label: "所属部门", name: "F_DepartmentId", width: 120, align: "center"
//		                            /*formatterAsync: function (callback, value) {
//		                                learun.clientdata.getAsync('department', {
//		                                    key: value,
//		                                    companyId: companyId,
//		                                    callback: function (item) {
//		                                        callback(item.F_FullName);
//		                                    }
//		                                });
//		                            }*/
//		                        },
//		                        { label: "备注", name: "F_Description", width: 200, align: "center" },
//		                        { label: "创建人", name: "F_CreateUserName", width: 100, align: "center" },
//		                        {
//		                            label: "创建时间", name: "F_CreateDate", width: 100, align: "center",
//		                            formatter: function (cellvalue) {
//		                                if(cellvalue) {
//										    return app.BASE_UTILS.Date.get_yyyy_MM_dd(new Date(cellvalue)); 
//									    }else{
//										    return '';
//						                }
//		                            }
//		                        }
//				    ],
//					isTree: true,
//			        mainId: 'F_Id',
//			        parentId: 'F_ParentId',
//				           
//	       });         
//     },
//      
//      search: function (param) {
//          param = param || {};
//          param.companyId = companyId;
//          param.departmentId = departmentId;
//
//          $('#gridtable').appGridSet('reload', param);
//      }
//  } 
//  // 保存数据后回调刷新
//   refreshGirdData = function () {
//      pageEvent.search();
//      
//  }
//
//
//  $(function () {
//      pageEvent.init();
//  });
//
//})(window.jQuery, top.app);