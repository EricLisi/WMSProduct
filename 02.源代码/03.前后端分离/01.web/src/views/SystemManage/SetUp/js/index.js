var appModuleButtonList;
var appModuleColumnList;

(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "SetUp",
			form: {
				title: "业务类型设置",
				width: 750,
				height: 450
			}
		},
		Event: { //初始化事件
			doBeforeInit: function() {
				$('#app_layout').appLayout();
				var CurrentId=localStorage.getItem('CurrentIds');							
				app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Module/GetModuleById/'+CurrentId+'/'+app.APP_GLOBE_STORE.LOGIN_USER.Id, function(data) {
					appModuleButtonList = data.ButtonList;
					appModuleColumnList = data.ColumnList
//					appModule = data.module;					
				});
			},
			doAfterInit: function() {
				// 角色功能授权
//				$('#app_authorize').on('click', function() {
//					var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
//					if(app.BASE_UTILS.checkrow(keyValue)) {
//						layx.iframe(app.CommonIndexParams.form.id, '功能授权', '../../Role/html/authorize.html?keyValue=' + keyValue, {
//							shadable: true,
//							statusBar: true,
//							height: 550,
//							width: 690
//	
//						});
//					}
//				});
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
				url: '/api/SetUp/GatPagerListByWhere/'+app.APP_GLOBE_STORE.LOGIN_USER.Id,
//			rowdatas: [{
//					"PreFix": "PU",
//					"NumberLength": "4",
//					"IsBatch": false,
//					"HavePL": true,
//					"Define1": "",
//					"Define2": "",
//					"Define3": "",
//					"Id": "1C9D2159-5E7D-48F7-BF8B-77925B2FB752",
//					"EnCode": "001",
//					"FullName": "入库通知",
//					"SortCode": 0,
//					"DeleteMark": false,
//					"EnabledMark": false,
//					"Description": "",
//					"CreatorTime": "1900-01-01 00:00:00",
//					"CreatorUserId": "",
//					"LastModifyTime": "1900-01-01 00:00:00",
//					"LastModifyUserId": "",
//					"DeleteTime": "1900-01-01 00:00:00",
//					"DeleteUserId": ""
//				}, {
//					"PreFix": "SR",
//					"NumberLength": "4",
//					"IsBatch": false,
//					"HavePL": true,
//					"Define1": "",
//					"Define2": "",
//					"Define3": "",
//					"Id": "88888",
//					"EnCode": "002",
//					"FullName": "退货",
//					"SortCode": 0,
//					"DeleteMark": false,
//					"EnabledMark": false,
//					"Description": "",
//					"CreatorTime": "1900-01-01 00:00:00",
//					"CreatorUserId": "",
//					"LastModifyTime": "1900-01-01 00:00:00",
//					"LastModifyUserId": "",
//					"DeleteTime": "1900-01-01 00:00:00",
//					"DeleteUserId": ""
//				}],
				headData: [{
						label: '业务类型编码',
						name: 'EnCode',
						width: 100,
						align: "center"
					},
					{
						label: '业务类型名称',
						name: 'FullName',
						width: 200,
						align: "center"
					},
					{
						label: '单据前缀',
						name: 'PreFix',
						width: 80,
						align: 'center',
					},
					{
						label: '流水号长度',
						name: 'NumberLength',
						width: 100,
						align: 'center'
					},
					{
						label: "是否分批",
						name: "IsBatch",
						width: 100,
						align: "center",
						formatter: function(cellvalue) {
							return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
						}
					},
					{
						label: "是否有拣货单",
						name: "HavePL",
						width: 100,
						align: "center",
						formatter: function(cellvalue) {
							return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
						}
					},
					{																								
						label: "描述",
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
		//alert(app.APP_GLOBE_STORE.LOGIN_USER.Id)		
		app.CommonIndexEvent.init(options);
	})
})(window.jQuery, top.app)

///*
// * 模块管理主页面
// */
//var router="SystemManage/Role";
//var selectedRow;
//var refreshGirdData;
//
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
//          // 刷新
//          $('#app_refresh').on('click', function () {
//              location.reload();
//              
//          });
//          // 新增
//          $('#app_add').on('click', function () {             	            	
//              selectedRow = null;
//              //layx.iframe('1','添加','../html/form.html');
//              layx.iframe('1','添加','../html/form.html',{
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
//               
//          });
//          // 编辑
//          $('#app_edit').on('click', function () {            	
//          	var keyValue = $('#gridtable').appGridValue('Id');
//              selectedRow = $('#gridtable').appGridGet('rowdata');           	
//          	 if (app.BASE_UTILS.checkrow(keyValue)) {
//          	 	 //layx.iframe('1','编辑','../html/form.html');
//          	 	layx.iframe('1','编辑','../html/form.html',{
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
//              var keyValue = $('#gridtable').appGridValue('Id');
//              if (app.BASE_UTILS.checkrow(keyValue)) {         
//	                app.MODAL_UTILS.confirm({
//			                msg: "是否确认删除该项！",
//			                callback: function () {
//			                	 if (res) {
//			                	 	app.deleteForm(router + '/DeleteForm', { keyValue: keyValue}, function () {
//		                                refreshGirdData();
//		                            });
//		                            /*request.delete({
//										url:router+ "/DeleteForm?keyValue=" + keyValue,					
//										success: function(data) {						
//											refreshGirdData();									
//										}
//									});*/
//			                	 }
//			                	 	                            
//			                }
//	                })
//              }
//              
//          });
//           // 添加角色成员
//          $('#app_memberadd').on('click', function () {
//              var keyValue = $('#gridtable').appGridValue('Id');
//              var loginInfo = learun.clientdata.get(['userinfo']);
//              if (app.BASE_UTILS.checkrow(keyValue)) {
//              	layx.iframe('1','添加角色成员','../html/form.html');
//                  /*learun.layerForm({
//                      id: 'form',
//                      title: '添加角色成员',
//                      url: top.$.rootUrl + '/LR_AuthorizeModule/UserRelation/SelectForm?objectId=' + keyValue + '&companyId=' + loginInfo.CompanyId + '&departmentId=' + loginInfo.DepartmentId + '&category=1',
//                      width: 800,
//                      height: 520,
//                      callBack: function (id) {
//                          return top[id].acceptClick();
//                      }
//                  });*/
//              }
//          });
//          // 查看成员
//          $('#app_memberlook').on('click', function () {
//              var keyValue = $('#gridtable').appGridValue('Id');
//              if (app.BASE_UTILS.checkrow(keyValue)) {
//              	layx.iframe('1','查看角色成员','../html/form.html');
//                  /*learun.layerForm({
//                      id: 'form',
//                      title: '查看角色成员',
//                      url: top.$.rootUrl + '/LR_AuthorizeModule/UserRelation/LookForm?objectId=' + keyValue,
//                      width: 800,
//                      height: 520,
//                      btn: null
//                  });*/
//              }
//          });
//          // 功能授权
//          $('#app_authorize').on('click', function () {
//              var keyValue = $('#gridtable').appGridValue('Id');
//              selectedRow = $('#gridtable').appGridGet('rowdata');
//              if (app.BASE_UTILS.checkrow(keyValue)) {
//              	layx.iframe('1','功能授权','../html/form.html');
//                  /*learun.layerForm({
//                      id: 'authorizeForm',
//                      title: '功能授权 - ' + selectedRow.FullName,
//                      url: top.$.rootUrl + '/LR_AuthorizeModule/Authorize/Form?objectId=' + keyValue + '&objectType=1',
//                      width: 550,
//                      height: 690,
//                      btn: null
//                  });*/
//              }
//          });
//          // 数据授权
//          $('#app_dataauthorize').on('click', function () {
//              var keyValue = $('#gridtable').appGridValue('Id');
//              selectedRow = $('#gridtable').appGridGet('rowdata');
//              if (app.BASE_UTILS.checkrow(keyValue)) {
//              	layx.iframe('1','数据授权','../html/form.html');
//                  /*learun.layerForm({
//                      id: 'dataAuthorizeForm',
//                      title: '数据授权 - ' + selectedRow.FullName,
//                      url: top.$.rootUrl + '/LR_AuthorizeModule/DataAuthorize/Index?objectId=' + keyValue + '&objectType=1',
//                      width: 1100,
//                      height: 700,
//                      maxmin: true,
//                      btn: null
//                  });*/
//              }
//          });
//          // 移动功能授权
//          $('#app_appauthorize').on('click', function () {
//              var keyValue = $('#gridtable').appGridValue('Id');
//              selectedRow = $('#gridtable').appGridGet('rowdata');
//              if (app.BASE_UTILS.checkrow(keyValue)) {
//              	layx.iframe('1','移动功能授权','../html/form.html');
//                  /*learun.layerForm({
//                      id: 'appAuthorizeForm',
//                      title: '移动功能授权 - ' + selectedRow.FullName,
//                      url: top.$.rootUrl + '/LR_AuthorizeModule/Authorize/AppForm?objectId=' + keyValue + '&objectType=1',
//                      width: 550,
//                      height: 690,
//                      callBack: function (id) {
//                          return top[id].acceptClick();
//                      }
//                  });*/
//              }
//          });
//          // 设置Ip过滤
//          $('#app_ipfilter').on('click', function () {
//              var keyValue = $('#gridtable').appGridValue('Id');
//              selectedRow = $('#gridtable').appGridGet('rowdata');
//              if (app.BASE_UTILS.checkrow(keyValue)) {
//              	layx.iframe('1','设置Ip过滤','../html/form.html');
//                  /*learun.layerForm({
//                      id: 'filterIPIndex',
//                      title: 'TCP/IP 地址访问限制 - ' + selectedRow.FullName,
//                      url: top.$.rootUrl + '/LR_AuthorizeModule/FilterIP/Index?objectId=' + keyValue + '&objectType=Role',
//                      width: 600,
//                      height: 400,
//                      btn: null,
//                      callBack: function (id) { }
//                  });*/
//              }
//          });
//          // 设置时间段过滤
//          $('#app_timefilter').on('click', function () {
//              var keyValue = $('#gridtable').appGridValue('Id');
//              selectedRow = $('#gridtable').appGridGet('rowdata');
//              if (app.BASE_UTILS.checkrow(keyValue)) {
//              	layx.iframe('1','设置时间段过滤','../html/form.html');
//                  /*learun.layerForm({
//                      id: 'filterTimeForm',
//                      title: '时段访问过滤 - ' + selectedRow.FullName,
//                      url: top.$.rootUrl + '/LR_AuthorizeModule/FilterTime/Form?objectId=' + keyValue + '&objectType=Role',
//                      width: 610,
//                      height: 470,
//                      callBack: function (id) {
//                          return top[id].acceptClick();
//                      }
//                  });*/
//              }
//          });
//          
//      },        
//      
//       /**
//       * 初始化表格
//       */
//       initgrid: function () {
//       $("#gridtable").appgrid({        	   	 	
//	            url: '',                // 数据服务地址
//	            param: {},                    // 请求参数
//	            rowdatas: [{
//	"Id": "7cdd37b0-3d69-4ed5-991d-55461a4fdb9c",
//	"Category": "1",
//	"EnCode": "100068",
//	"FullName": "数据维护",
//	"SortCode": 68,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:06",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "f1e4da91-c20a-42a5-acbd-72aa55e690c9",
//	"Category": "1",
//	"EnCode": "部门领导-1",
//	"FullName": "部门领导",
//	"SortCode": null,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": null,
//	"CreateDate": "2017-08-28 11:00:26",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "f3ff89c8-12c1-424d-8562-03467ff2797f",
//	"Category": "1",
//	"EnCode": "100111",
//	"FullName": "业务管理员",
//	"SortCode": 111,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "[系统内置]",
//	"CreateDate": "2015-11-04 16:11:09",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "b7a61699-947c-4100-a18d-ddf5eeb6c3dd",
//	"Category": "1",
//	"EnCode": "100001",
//	"FullName": "超级管理员",
//	"SortCode": 1,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "系统管理",
//	"CreateDate": "2015-11-04 16:10:48",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "b308dd3a-e89a-473c-9d97-a15392215427",
//	"Category": "1",
//	"EnCode": "100023",
//	"FullName": "安全员",
//	"SortCode": 23,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责安全管理",
//	"CreateDate": "2015-11-04 16:11:03",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "1d288fd0-1782-4f3d-bb38-61707ea0f316",
//	"Category": "1",
//	"EnCode": "100101",
//	"FullName": "维保巡检员",
//	"SortCode": 101,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:09",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "442b18ed-0f97-447c-aef5-48fea53e4bd6",
//	"Category": "1",
//	"EnCode": "100070",
//	"FullName": "丁班班长",
//	"SortCode": 70,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:06",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "d2c93bbb-d307-47f8-8c98-de24ad5d9415",
//	"Category": "1",
//	"EnCode": "100106",
//	"FullName": "公司出纳",
//	"SortCode": 106,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "[系统内置]",
//	"CreateDate": "2015-11-04 16:11:09",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "5432e6dc-401c-4e5a-9e6e-9e5e4a0d3a46",
//	"Category": "1",
//	"EnCode": "100003",
//	"FullName": "调度长",
//	"SortCode": 3,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责生产管理",
//	"CreateDate": "2015-11-04 16:11:01",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "9062bfc6-a870-4425-8521-ec180f1cbdec",
//	"Category": "1",
//	"EnCode": "100121",
//	"FullName": "公司财务人员",
//	"SortCode": 121,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:10",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "9d05cc07-b7aa-4d45-b2ad-4b74a7d12f62",
//	"Category": "1",
//	"EnCode": "100108",
//	"FullName": "助理",
//	"SortCode": 108,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "[系统内置]",
//	"CreateDate": "2015-11-04 16:11:09",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "f59e34c2-1317-4850-8a4a-1583c2d8f23f",
//	"Category": "1",
//	"EnCode": "100040",
//	"FullName": "燃气维保巡检员3",
//	"SortCode": 40,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:04",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "55d2f1cc-30b3-4c16-8111-f3ed5848fa25",
//	"Category": "1",
//	"EnCode": "100113",
//	"FullName": "审计员",
//	"SortCode": 113,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "[系统内置]",
//	"CreateDate": "2015-11-04 16:11:10",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "1e78847c-9694-49f3-b142-8d86943af83d",
//	"Category": "1",
//	"EnCode": "100012",
//	"FullName": "维保巡检员",
//	"SortCode": 12,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:02",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "94e915ea-7a10-4972-9ae7-78d9e47f0ade",
//	"Category": "1",
//	"EnCode": "100064",
//	"FullName": "丙班巡检员",
//	"SortCode": 64,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:06",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "f15e7f38-b68e-49b4-bc3f-2f53d6ac3fc6",
//	"Category": "1",
//	"EnCode": "100035",
//	"FullName": "测试岗位4",
//	"SortCode": 35,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "&nbsp;",
//	"CreateDate": "2015-11-04 16:11:03",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "046f9bf6-e00b-4307-b202-a5fe13bd259b",
//	"Category": "1",
//	"EnCode": "100067",
//	"FullName": "甲班班长",
//	"SortCode": 67,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:06",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "16488e80-8832-4ff5-8eec-01acac6fcc4f",
//	"Category": "1",
//	"EnCode": "100129",
//	"FullName": "工程部主管",
//	"SortCode": 129,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:11",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "d3bc5eea-8ba2-4599-8137-397a1bfe2faa",
//	"Category": "1",
//	"EnCode": "100077",
//	"FullName": "测试人员",
//	"SortCode": 77,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:07",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "d61e1853-cdee-4d49-a5e1-e230f1098e52",
//	"Category": "1",
//	"EnCode": "100055",
//	"FullName": "管理员",
//	"SortCode": 55,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:05",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "4e809c03-b4a5-4459-85a1-7e02c262a8bc",
//	"Category": "1",
//	"EnCode": "100117",
//	"FullName": "公司高层领导",
//	"SortCode": 117,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:10",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "869e3ebe-dd85-4db0-a4bf-34054da523c5",
//	"Category": "1",
//	"EnCode": "100114",
//	"FullName": "用户管理员",
//	"SortCode": 114,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "[系统内置]",
//	"CreateDate": "2015-11-04 16:11:10",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "90198392-357e-4a10-87c6-6e3767d3cd4e",
//	"Category": "1",
//	"EnCode": "100005",
//	"FullName": "库管",
//	"SortCode": 5,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责库房管理",
//	"CreateDate": "2015-11-04 16:11:01",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "3d761e7c-0e52-49cb-8405-4a9aa1e40bb4",
//	"Category": "1",
//	"EnCode": "100015",
//	"FullName": "测试查看帐号",
//	"SortCode": 15,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "测试查看帐号",
//	"CreateDate": "2015-11-04 16:11:02",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "a1431695-7f18-4aad-ae09-a087a783b1e0",
//	"Category": "1",
//	"EnCode": "100053",
//	"FullName": "丁班检修工",
//	"SortCode": 53,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:05",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "01d034c2-0141-448b-8ea4-13c337b5504e",
//	"Category": "1",
//	"EnCode": "100100",
//	"FullName": "燃保巡检员",
//	"SortCode": 100,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:09",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "c97c5fd2-8b02-4523-bff1-b3e92ac43c0b",
//	"Category": "1",
//	"EnCode": "100014",
//	"FullName": "环保巡检员",
//	"SortCode": 14,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:02",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "f5fd3e70-4616-4fe2-a5bc-1ee964d320a4",
//	"Category": "1",
//	"EnCode": "100060",
//	"FullName": "燃保巡检员",
//	"SortCode": 60,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:05",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "a6dbb68d-817a-4341-b199-b913f4d1091a",
//	"Category": "1",
//	"EnCode": "100124",
//	"FullName": "总经理",
//	"SortCode": 124,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:10",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "4e978770-0100-4c6e-b646-422d372ea23f",
//	"Category": "1",
//	"EnCode": "100009",
//	"FullName": "生产统计员",
//	"SortCode": 9,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责生产数据统计",
//	"CreateDate": "2015-11-04 16:11:01",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "adad429e-a6e8-4137-93a4-a9ad4d2671f4",
//	"Category": "1",
//	"EnCode": "100038",
//	"FullName": "测试岗位2",
//	"SortCode": 38,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "&nbsp;",
//	"CreateDate": "2015-11-04 16:11:04",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "210beb4d-e96c-4673-b617-45b79ee8dfde",
//	"Category": "1",
//	"EnCode": "100041",
//	"FullName": "燃气维保巡检员4",
//	"SortCode": 41,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:04",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "3959c15b-3e35-4db0-896b-436eba619906",
//	"Category": "1",
//	"EnCode": "100104",
//	"FullName": "公司领导",
//	"SortCode": 104,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "[系统内置]",
//	"CreateDate": "2015-11-04 16:11:09",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "5735a488-58da-423f-be81-9a846c822ece",
//	"Category": "1",
//	"EnCode": "test",
//	"FullName": "测试数据",
//	"SortCode": null,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "测试数据",
//	"CreateDate": "2017-04-28 09:49:16",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "21293c5e-60b0-4f31-a514-78313a8a6499",
//	"Category": "1",
//	"EnCode": "100105",
//	"FullName": "公司会计",
//	"SortCode": 105,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "[系统内置]",
//	"CreateDate": "2015-11-04 16:11:09",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "1a300077-2ffe-4001-97b9-e9c0bb8c43e3",
//	"Category": "1",
//	"EnCode": "100102",
//	"FullName": "检修班长",
//	"SortCode": 102,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:09",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "bf23dd88-2aed-4780-b260-430bee08bd2b",
//	"Category": "1",
//	"EnCode": "100057",
//	"FullName": "乙班班长",
//	"SortCode": 57,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:05",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "81d54a99-f6ac-44fd-8695-be5daf800eb2",
//	"Category": "1",
//	"EnCode": "100039",
//	"FullName": "燃气维保巡检员1",
//	"SortCode": 39,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:04",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "667deed2-f95c-4230-931b-b6658dbd53ab",
//	"Category": "1",
//	"EnCode": "100110",
//	"FullName": "系统管理员",
//	"SortCode": 110,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "[系统内置]",
//	"CreateDate": "2015-11-04 16:11:09",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "2ab5edea-4448-4ee3-92d5-8bd8bb86fafb",
//	"Category": "1",
//	"EnCode": "100118",
//	"FullName": "公司中层领导",
//	"SortCode": 118,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:10",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "43400843-6c97-436c-8dda-cc1298923814",
//	"Category": "1",
//	"EnCode": "100032",
//	"FullName": "现场管理员",
//	"SortCode": 32,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责现场管理",
//	"CreateDate": "2015-11-04 16:11:03",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "ec5f1e00-43aa-4573-9ec3-9d71068ce080",
//	"Category": "1",
//	"EnCode": "100091",
//	"FullName": "仓库管理员1",
//	"SortCode": 91,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责仓库管理",
//	"CreateDate": "2015-11-04 16:11:08",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "369bd2a7-069f-47ff-ab65-82a6bc9d4c78",
//	"Category": "1",
//	"EnCode": "100112",
//	"FullName": "安全管理员",
//	"SortCode": 112,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "[系统内置]",
//	"CreateDate": "2015-11-04 16:11:09",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "a5dee45d-8045-4bf3-9434-920f6a34f440",
//	"Category": "1",
//	"EnCode": "100096",
//	"FullName": "系统管理",
//	"SortCode": 96,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "&nbsp;",
//	"CreateDate": "2015-11-04 16:11:08",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "dbd5f525-c973-4ac9-b13a-0d166f9372e6",
//	"Category": "1",
//	"EnCode": "100037",
//	"FullName": "测试岗位1",
//	"SortCode": 37,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "&nbsp;",
//	"CreateDate": "2015-11-04 16:11:04",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "a5cc855d-de99-4b37-b7c3-4f960f25227d",
//	"Category": "1",
//	"EnCode": "100024",
//	"FullName": "巡检工1",
//	"SortCode": 24,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责现场设备巡检",
//	"CreateDate": "2015-11-04 16:11:03",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "9a06e2f8-eb3d-47b7-80f2-725ff7585ff5",
//	"Category": "1",
//	"EnCode": "100138",
//	"FullName": "宾客",
//	"SortCode": 138,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "宾客角色",
//	"CreateDate": "2015-11-04 16:11:12",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": "2017-08-23 18:18:45",
//	"ModifyUserId": "System",
//	"ModifyUserName": "超级管理员"
//}, {
//	"Id": "b2a9d3c5-5ef9-460f-a396-1fe050785cac",
//	"Category": "1",
//	"EnCode": "100135",
//	"FullName": "仓库保管员",
//	"SortCode": 135,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:11",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "1999c024-25b2-4feb-a1fc-88fa3318133d",
//	"Category": "1",
//	"EnCode": "100065",
//	"FullName": "丙班检修工",
//	"SortCode": 65,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:06",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": "2017-04-20 11:36:56",
//	"ModifyUserId": "System",
//	"ModifyUserName": "超级管理员"
//}, {
//	"Id": "ba44d84f-8df3-432a-9f3a-6b16365df440",
//	"Category": "1",
//	"EnCode": "100133",
//	"FullName": "工程实施人员",
//	"SortCode": 133,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:11",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "5d45079d-4d14-4fb3-894f-3653a4b6a243",
//	"Category": "1",
//	"EnCode": "100061",
//	"FullName": "测试",
//	"SortCode": 61,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "测试角色",
//	"CreateDate": "2015-11-04 16:11:05",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "00195dc6-f624-4c49-9ed3-9d3082be6308",
//	"Category": "1",
//	"EnCode": "100130",
//	"FullName": "业务部主管",
//	"SortCode": 130,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:11",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "be8f117b-7dc1-4dcb-8382-ef19df096131",
//	"Category": "1",
//	"EnCode": "100007",
//	"FullName": "物流人员",
//	"SortCode": 7,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责微粉外发",
//	"CreateDate": "2015-11-04 16:11:01",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "008caf61-fdda-43c7-af23-2eeebcacae85",
//	"Category": "1",
//	"EnCode": "100054",
//	"FullName": "生产统计员1",
//	"SortCode": 54,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责生产数据统计",
//	"CreateDate": "2015-11-04 16:11:05",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "57aba436-595d-4068-89af-dc8643eb7b5e",
//	"Category": "1",
//	"EnCode": "100092",
//	"FullName": "仓库管理员2",
//	"SortCode": 92,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责仓库管理",
//	"CreateDate": "2015-11-04 16:11:08",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "f819fe42-e836-4b98-a24d-8dd849031679",
//	"Category": "1",
//	"EnCode": "100062",
//	"FullName": "检修班长",
//	"SortCode": 62,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:06",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "9074cae0-a5ea-4114-b980-df5761c2afc7",
//	"Category": "1",
//	"EnCode": "100137",
//	"FullName": "检修人员",
//	"SortCode": 137,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": null,
//	"CreateDate": "2015-11-04 16:11:11",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": "2016-03-03 10:22:25",
//	"ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
//	"ModifyUserName": "佘赐雄"
//}, {
//	"Id": "943428cc-8db3-4f5c-8cde-4c05d42980f6",
//	"Category": "1",
//	"EnCode": "100076",
//	"FullName": "制造部部长",
//	"SortCode": 76,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责生产管理",
//	"CreateDate": "2015-11-04 16:11:07",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "3bbea8fc-4c68-4955-bd01-09b462c717d4",
//	"Category": "1",
//	"EnCode": "100128",
//	"FullName": "客户服务主管",
//	"SortCode": 128,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": null,
//	"CreateDate": "2015-11-04 16:11:11",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": "2017-01-22 11:04:38",
//	"ModifyUserId": "System",
//	"ModifyUserName": "超级管理员"
//}, {
//	"Id": "7eb67636-7252-4dd1-a268-84d33a969f67",
//	"Category": "1",
//	"EnCode": "100119",
//	"FullName": "公司业务人员",
//	"SortCode": 119,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:10",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "cdad8fa5-d7bd-48c8-b44a-444cb87ae9e8",
//	"Category": "1",
//	"EnCode": "100034",
//	"FullName": "测试岗位3",
//	"SortCode": 34,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "&nbsp;",
//	"CreateDate": "2015-11-04 16:11:03",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "c13b766f-4459-40d3-a289-6eb036154917",
//	"Category": "1",
//	"EnCode": "99999",
//	"FullName": "力软内部测试角色",
//	"SortCode": null,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "力软测试",
//	"CreateDate": "2016-05-23 11:00:33",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "e17d3383-2ba9-46a7-87f5-c9b7de507051",
//	"Category": "1",
//	"EnCode": "100126",
//	"FullName": "开发部主管",
//	"SortCode": 126,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:11",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "88da93eb-1ba8-4a40-9d64-d7ce26bc0417",
//	"Category": "1",
//	"EnCode": "100136",
//	"FullName": "总经理助理",
//	"SortCode": 136,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": null,
//	"CreateDate": "2015-11-04 16:11:11",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": "2015-12-22 18:05:41",
//	"ModifyUserId": "System",
//	"ModifyUserName": "超级管理员"
//}, {
//	"Id": "991e3103-7705-4637-822a-d3ffb804c5bb",
//	"Category": "1",
//	"EnCode": "100059",
//	"FullName": "丁班巡检员",
//	"SortCode": 59,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:05",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "565870b3-f834-4ac6-84bd-ed0cba744d15",
//	"Category": "1",
//	"EnCode": "100090",
//	"FullName": "生产统计员3",
//	"SortCode": 90,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责生产数据统计",
//	"CreateDate": "2015-11-04 16:11:08",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "990dbca5-e1e2-4a3e-99fa-4814c16f1a9a",
//	"Category": "1",
//	"EnCode": "100022",
//	"FullName": "部长",
//	"SortCode": 22,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责部门管理",
//	"CreateDate": "2015-11-04 16:11:02",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": "2017-08-11 09:44:20",
//	"ModifyUserId": "System",
//	"ModifyUserName": "超级管理员"
//}, {
//	"Id": "309fc31c-4177-4c8a-b563-831d667115b7",
//	"Category": "1",
//	"EnCode": "100089",
//	"FullName": "生产统计员2",
//	"SortCode": 89,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责生产数据统计",
//	"CreateDate": "2015-11-04 16:11:08",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "bf501cf3-c908-4e38-a697-09ec394793f3",
//	"Category": "1",
//	"EnCode": "100033",
//	"FullName": "固定资产管理员",
//	"SortCode": 33,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责固定资产管理",
//	"CreateDate": "2015-11-04 16:11:03",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "203c1acf-8807-496d-8013-ef48c6971118",
//	"Category": "1",
//	"EnCode": "100006",
//	"FullName": "中控员",
//	"SortCode": 6,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责磨机操作",
//	"CreateDate": "2015-11-04 16:11:01",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "186bb4a4-9631-418e-a52c-5dae289489e5",
//	"Category": "1",
//	"EnCode": "100066",
//	"FullName": "乙班检修工",
//	"SortCode": 66,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:06",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "d927cb02-3d98-436f-b35d-f4530a3ba563",
//	"Category": "1",
//	"EnCode": "100011",
//	"FullName": "检修班长",
//	"SortCode": 11,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:02",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "08616575-07e8-4a36-99e4-40b0e58cc6c1",
//	"Category": "1",
//	"EnCode": "100002",
//	"FullName": "总调度长",
//	"SortCode": 2,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责生产管理",
//	"CreateDate": "2015-11-04 16:11:01",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "28b73595-a35e-4d39-8cab-55fbc5ae7ce9",
//	"Category": "1",
//	"EnCode": "100004",
//	"FullName": "设备管理员",
//	"SortCode": 4,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责设备管理",
//	"CreateDate": "2015-11-04 16:11:01",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "84c11691-684f-4d73-982b-d73113b9af6b",
//	"Category": "1",
//	"EnCode": "100131",
//	"FullName": "开发人员",
//	"SortCode": 131,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": null,
//	"CreateDate": "2015-11-04 16:11:11",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": "2015-11-04 16:13:51",
//	"ModifyUserId": "System",
//	"ModifyUserName": "超级管理员"
//}, {
//	"Id": "d958a8ae-1b04-471a-bdde-6580e7e9c052",
//	"Category": "1",
//	"EnCode": "100021",
//	"FullName": "系统用户角色",
//	"SortCode": 21,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "&nbsp;",
//	"CreateDate": "2015-11-04 16:11:02",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "d1d152c5-557e-406f-88ab-c4d541e0dd08",
//	"Category": "1",
//	"EnCode": "100075",
//	"FullName": "新方专家",
//	"SortCode": 75,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "&nbsp;",
//	"CreateDate": "2015-11-04 16:11:07",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "ab9bb5b9-60c6-4c1a-bd57-ea32d23347e3",
//	"Category": "1",
//	"EnCode": "100116",
//	"FullName": "用户",
//	"SortCode": 116,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "[系统内置]",
//	"CreateDate": "2015-11-04 16:11:10",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "d617e4c0-f70b-4486-8f46-857bd007d3a0",
//	"Category": "1",
//	"EnCode": "100123",
//	"FullName": "人事主管",
//	"SortCode": 123,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:10",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "0a825fcd-103f-4b16-b965-90723ce96fa3",
//	"Category": "1",
//	"EnCode": "100056",
//	"FullName": "资料管理员",
//	"SortCode": 56,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责资料管理",
//	"CreateDate": "2015-11-04 16:11:05",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "051b1a3c-3646-4964-ae85-50750b3bf884",
//	"Category": "1",
//	"EnCode": "100134",
//	"FullName": "热线客服",
//	"SortCode": 134,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:11",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "756133f5-934e-487f-9d5c-2838791e69b1",
//	"Category": "1",
//	"EnCode": "100079",
//	"FullName": "燃气维保巡检员2",
//	"SortCode": 79,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:07",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "e9624138-1a09-4f5b-9506-77a2ed0e2070",
//	"Category": "1",
//	"EnCode": "100051",
//	"FullName": "巡检员",
//	"SortCode": 51,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责现场设备巡检",
//	"CreateDate": "2015-11-04 16:11:05",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "544753a6-8b5d-437e-9e08-1e96549d41a1",
//	"Category": "1",
//	"EnCode": "100115",
//	"FullName": "内部员工",
//	"SortCode": 115,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "[系统内置]",
//	"CreateDate": "2015-11-04 16:11:10",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "25808cfe-7e88-4ddb-81a0-d5137d30b41c",
//	"Category": "1",
//	"EnCode": "100063",
//	"FullName": "乙班巡检员",
//	"SortCode": 63,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:06",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "2810274c-5549-4283-9d86-2064e39c6e5a",
//	"Category": "1",
//	"EnCode": "100069",
//	"FullName": "丙班班长",
//	"SortCode": 69,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:06",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": "2017-06-01 14:24:38",
//	"ModifyUserId": "24a055d6-5924-44c5-be52-3715cdd68011",
//	"ModifyUserName": "陈彬彬"
//}, {
//	"Id": "f9ed83ea-9204-4b53-8f18-36120423fc1b",
//	"Category": "1",
//	"EnCode": "100120",
//	"FullName": "公司技术人员",
//	"SortCode": 120,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:10",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "036352aa-5809-493f-a047-1f7dd72c1036",
//	"Category": "1",
//	"EnCode": "100010",
//	"FullName": "数据维护管理员",
//	"SortCode": 10,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "",
//	"CreateDate": "2015-11-04 16:11:02",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}, {
//	"Id": "7321b2d4-4265-470e-b291-5bdf88c73078",
//	"Category": "1",
//	"EnCode": "100008",
//	"FullName": "检修人员",
//	"SortCode": 8,
//	"DeleteMark": 0,
//	"EnabledMark": 1,
//	"Description": "负责设备检修",
//	"CreateDate": "2015-11-04 16:11:01",
//	"CreateUserId": "System",
//	"CreateUserName": "超级管理员",
//	"ModifyDate": null,
//	"ModifyUserId": null,
//	"ModifyUserName": null
//}],                 // 列表数据
//	        headData: [{
//				label: '主键',
//				name: 'Id'				
//			},
//			 { label: '角色编号', name: 'EnCode', width: 100, align: "center" },
//                  { label: '角色名称', name: 'FullName', width: 200, align: "center" },
//                  {
//                      label: '创建时间', name: 'CreateDate', width: 130, align: 'center'
//                  },
//                  {
//                      label: '创建人', name: 'CreateUserName', width: 130, align: 'center'
//                  },
//                  {
//                      label: "有效", name: "EnabledMark", width: 50, align: "center",
//                      formatter: function (cellvalue) {
//                          return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
//                      }
//                  },
//                  { label: "角色描述", name: "Description", index: "Description", width: 300, align: "center" }
//		],
//		isPage: true,
//      reloadSelected: true,
//      mainId: 'Id'
//	           
//     });  
//      pageEvent.search();
//     },
//      
//      search: function (param) {
//           param = param || {};
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