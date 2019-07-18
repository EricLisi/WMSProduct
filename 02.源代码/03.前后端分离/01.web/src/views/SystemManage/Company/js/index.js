
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "Company",
			form: {
				id: "Company",
				title: "公司",
				width: 750,
				height: 700
			}
		},
		Event: { //初始化事件
			doBeforeInit: function() {
				$('#app_layout').appLayout();
//				var CurrentId=localStorage.getItem('CurrentIds');							
//				app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Module/GetModuleById/'+CurrentId+'/'+app.APP_GLOBE_STORE.LOGIN_USER.Id, function(data) {
//					appModuleButtonList = data.ButtonList;
//					appModuleColumnList = data.ColumnList
////					appModule = data.module;					
//				});
			}
		},
		search: { //搜索			
			setSearchParams: function () {
				return {
					userid: app.APP_GLOBE_STORE.LOGIN_USER.Id,
					fullname: $("#txtName").val()
				}
			}
		},
		tree: { //启用左侧树形
		},
		bindEvent: { //点击事件参数 
			add: {

			}
		},

		grid: { //grid 
			options: {
				url: '/api/Company/GetByPagesAsync',
			 param: {
					userid: app.APP_GLOBE_STORE.LOGIN_USER.id
				},
				//rowdatas: roledata,
				headData: [{
						label: "公司名称",
						name: "fullname",
						width: 260,
						align: "center"
					},
					{
						label: "公司编码",
						name: "encode",
						width: 150,
						align: "center"
					},
					{
						label: "公司简称",
						name: "shortname",
						width: 150,
						align: "center"
					},
					{
						label: "公司性质",
						name: "nature",
						width: 80,
						align: "center",
						formatter: function(cellvalue) {
						    if(cellvalue==0){								
								return "国家机关"
							}
						    else if(cellvalue==1){
								return "房地产"
							}
						    else if(cellvalue==2){
								return "建筑业"
							}
						    else if(cellvalue==3){
								return "社会服务业"
							}
						    else if(cellvalue==4){
								return "互联网"
							}
						    else if(cellvalue==5){
								return "制造业"
							}
						    else if(cellvalue==6){
								return "金融业"
							}
						    else if(cellvalue==7){
								return "其他业"
							}
						}
					},
					{
						label: "成立时间",
						name: "creatortime",
						width: 80,
						align: "center",
						formatter: function(value) {
							if(value) {
								return app.BASE_UTILS.Date.get_yyyy_MM_dd(new Date(value));
							} else {
								return '';
							}
						}
					},
					{
						label: "负责人",
						name: "manager",
						width: 80,
						align: "center"
					},
					{
						label: "传真",
						name: "fax",
						width: 200,
						align: "center"
					},
					{
						label: "备注",
						name: "description",
						width: 200,
						align: "center"
					}
				],
				isTree: false
			}
		}
	};
	$(function() {
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
//          	var keyValue = $('#gridtable').appGridValue('F_Id');
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
//              var keyValue = $('#gridtable').appGridValue('F_Id');
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
//              var keyValue = $('#gridtable').appGridValue('F_Id');
//              var loginInfo = learun.clientdata.get(['userinfo']);
//              if (app.BASE_UTILS.checkrow(keyValue)) {
//              	layx.iframe('1','添加角色成员','../html/form.html');
//                  /*learun.layerForm({
//                      id: 'form',
//                      title: '添加角色成员',
//                      url: top.$.rootUrl + '/LR_AuthorizeModule/UserRelation/SelectForm?objectId=' + keyValue + '&companyId=' + loginInfo.F_CompanyId + '&departmentId=' + loginInfo.F_DepartmentId + '&category=1',
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
//              var keyValue = $('#gridtable').appGridValue('F_Id');
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
//              var keyValue = $('#gridtable').appGridValue('F_Id');
//              selectedRow = $('#gridtable').appGridGet('rowdata');
//              if (app.BASE_UTILS.checkrow(keyValue)) {
//              	layx.iframe('1','功能授权','../html/form.html');
//                  /*learun.layerForm({
//                      id: 'authorizeForm',
//                      title: '功能授权 - ' + selectedRow.F_FullName,
//                      url: top.$.rootUrl + '/LR_AuthorizeModule/Authorize/Form?objectId=' + keyValue + '&objectType=1',
//                      width: 550,
//                      height: 690,
//                      btn: null
//                  });*/
//              }
//          });
//          // 数据授权
//          $('#app_dataauthorize').on('click', function () {
//              var keyValue = $('#gridtable').appGridValue('F_Id');
//              selectedRow = $('#gridtable').appGridGet('rowdata');
//              if (app.BASE_UTILS.checkrow(keyValue)) {
//              	layx.iframe('1','数据授权','../html/form.html');
//                  /*learun.layerForm({
//                      id: 'dataAuthorizeForm',
//                      title: '数据授权 - ' + selectedRow.F_FullName,
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
//              var keyValue = $('#gridtable').appGridValue('F_Id');
//              selectedRow = $('#gridtable').appGridGet('rowdata');
//              if (app.BASE_UTILS.checkrow(keyValue)) {
//              	layx.iframe('1','移动功能授权','../html/form.html');
//                  /*learun.layerForm({
//                      id: 'appAuthorizeForm',
//                      title: '移动功能授权 - ' + selectedRow.F_FullName,
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
//              var keyValue = $('#gridtable').appGridValue('F_Id');
//              selectedRow = $('#gridtable').appGridGet('rowdata');
//              if (app.BASE_UTILS.checkrow(keyValue)) {
//              	layx.iframe('1','设置Ip过滤','../html/form.html');
//                  /*learun.layerForm({
//                      id: 'filterIPIndex',
//                      title: 'TCP/IP 地址访问限制 - ' + selectedRow.F_FullName,
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
//              var keyValue = $('#gridtable').appGridValue('F_Id');
//              selectedRow = $('#gridtable').appGridGet('rowdata');
//              if (app.BASE_UTILS.checkrow(keyValue)) {
//              	layx.iframe('1','设置时间段过滤','../html/form.html');
//                  /*learun.layerForm({
//                      id: 'filterTimeForm',
//                      title: '时段访问过滤 - ' + selectedRow.F_FullName,
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
//	"F_Id": "7cdd37b0-3d69-4ed5-991d-55461a4fdb9c",
//	"F_Category": "1",
//	"F_EnCode": "100068",
//	"F_FullName": "数据维护",
//	"F_SortCode": 68,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:06",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "f1e4da91-c20a-42a5-acbd-72aa55e690c9",
//	"F_Category": "1",
//	"F_EnCode": "部门领导-1",
//	"F_FullName": "部门领导",
//	"F_SortCode": null,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2017-08-28 11:00:26",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "f3ff89c8-12c1-424d-8562-03467ff2797f",
//	"F_Category": "1",
//	"F_EnCode": "100111",
//	"F_FullName": "业务管理员",
//	"F_SortCode": 111,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "[系统内置]",
//	"F_CreateDate": "2015-11-04 16:11:09",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "b7a61699-947c-4100-a18d-ddf5eeb6c3dd",
//	"F_Category": "1",
//	"F_EnCode": "100001",
//	"F_FullName": "超级管理员",
//	"F_SortCode": 1,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "系统管理",
//	"F_CreateDate": "2015-11-04 16:10:48",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "b308dd3a-e89a-473c-9d97-a15392215427",
//	"F_Category": "1",
//	"F_EnCode": "100023",
//	"F_FullName": "安全员",
//	"F_SortCode": 23,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责安全管理",
//	"F_CreateDate": "2015-11-04 16:11:03",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "1d288fd0-1782-4f3d-bb38-61707ea0f316",
//	"F_Category": "1",
//	"F_EnCode": "100101",
//	"F_FullName": "维保巡检员",
//	"F_SortCode": 101,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:09",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "442b18ed-0f97-447c-aef5-48fea53e4bd6",
//	"F_Category": "1",
//	"F_EnCode": "100070",
//	"F_FullName": "丁班班长",
//	"F_SortCode": 70,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:06",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "d2c93bbb-d307-47f8-8c98-de24ad5d9415",
//	"F_Category": "1",
//	"F_EnCode": "100106",
//	"F_FullName": "公司出纳",
//	"F_SortCode": 106,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "[系统内置]",
//	"F_CreateDate": "2015-11-04 16:11:09",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "5432e6dc-401c-4e5a-9e6e-9e5e4a0d3a46",
//	"F_Category": "1",
//	"F_EnCode": "100003",
//	"F_FullName": "调度长",
//	"F_SortCode": 3,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责生产管理",
//	"F_CreateDate": "2015-11-04 16:11:01",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "9062bfc6-a870-4425-8521-ec180f1cbdec",
//	"F_Category": "1",
//	"F_EnCode": "100121",
//	"F_FullName": "公司财务人员",
//	"F_SortCode": 121,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:10",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "9d05cc07-b7aa-4d45-b2ad-4b74a7d12f62",
//	"F_Category": "1",
//	"F_EnCode": "100108",
//	"F_FullName": "助理",
//	"F_SortCode": 108,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "[系统内置]",
//	"F_CreateDate": "2015-11-04 16:11:09",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "f59e34c2-1317-4850-8a4a-1583c2d8f23f",
//	"F_Category": "1",
//	"F_EnCode": "100040",
//	"F_FullName": "燃气维保巡检员3",
//	"F_SortCode": 40,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:04",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "55d2f1cc-30b3-4c16-8111-f3ed5848fa25",
//	"F_Category": "1",
//	"F_EnCode": "100113",
//	"F_FullName": "审计员",
//	"F_SortCode": 113,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "[系统内置]",
//	"F_CreateDate": "2015-11-04 16:11:10",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "1e78847c-9694-49f3-b142-8d86943af83d",
//	"F_Category": "1",
//	"F_EnCode": "100012",
//	"F_FullName": "维保巡检员",
//	"F_SortCode": 12,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:02",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "94e915ea-7a10-4972-9ae7-78d9e47f0ade",
//	"F_Category": "1",
//	"F_EnCode": "100064",
//	"F_FullName": "丙班巡检员",
//	"F_SortCode": 64,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:06",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "f15e7f38-b68e-49b4-bc3f-2f53d6ac3fc6",
//	"F_Category": "1",
//	"F_EnCode": "100035",
//	"F_FullName": "测试岗位4",
//	"F_SortCode": 35,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "&nbsp;",
//	"F_CreateDate": "2015-11-04 16:11:03",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "046f9bf6-e00b-4307-b202-a5fe13bd259b",
//	"F_Category": "1",
//	"F_EnCode": "100067",
//	"F_FullName": "甲班班长",
//	"F_SortCode": 67,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:06",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "16488e80-8832-4ff5-8eec-01acac6fcc4f",
//	"F_Category": "1",
//	"F_EnCode": "100129",
//	"F_FullName": "工程部主管",
//	"F_SortCode": 129,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:11",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "d3bc5eea-8ba2-4599-8137-397a1bfe2faa",
//	"F_Category": "1",
//	"F_EnCode": "100077",
//	"F_FullName": "测试人员",
//	"F_SortCode": 77,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:07",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "d61e1853-cdee-4d49-a5e1-e230f1098e52",
//	"F_Category": "1",
//	"F_EnCode": "100055",
//	"F_FullName": "管理员",
//	"F_SortCode": 55,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:05",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "4e809c03-b4a5-4459-85a1-7e02c262a8bc",
//	"F_Category": "1",
//	"F_EnCode": "100117",
//	"F_FullName": "公司高层领导",
//	"F_SortCode": 117,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:10",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "869e3ebe-dd85-4db0-a4bf-34054da523c5",
//	"F_Category": "1",
//	"F_EnCode": "100114",
//	"F_FullName": "用户管理员",
//	"F_SortCode": 114,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "[系统内置]",
//	"F_CreateDate": "2015-11-04 16:11:10",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "90198392-357e-4a10-87c6-6e3767d3cd4e",
//	"F_Category": "1",
//	"F_EnCode": "100005",
//	"F_FullName": "库管",
//	"F_SortCode": 5,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责库房管理",
//	"F_CreateDate": "2015-11-04 16:11:01",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "3d761e7c-0e52-49cb-8405-4a9aa1e40bb4",
//	"F_Category": "1",
//	"F_EnCode": "100015",
//	"F_FullName": "测试查看帐号",
//	"F_SortCode": 15,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "测试查看帐号",
//	"F_CreateDate": "2015-11-04 16:11:02",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "a1431695-7f18-4aad-ae09-a087a783b1e0",
//	"F_Category": "1",
//	"F_EnCode": "100053",
//	"F_FullName": "丁班检修工",
//	"F_SortCode": 53,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:05",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "01d034c2-0141-448b-8ea4-13c337b5504e",
//	"F_Category": "1",
//	"F_EnCode": "100100",
//	"F_FullName": "燃保巡检员",
//	"F_SortCode": 100,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:09",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "c97c5fd2-8b02-4523-bff1-b3e92ac43c0b",
//	"F_Category": "1",
//	"F_EnCode": "100014",
//	"F_FullName": "环保巡检员",
//	"F_SortCode": 14,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:02",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "f5fd3e70-4616-4fe2-a5bc-1ee964d320a4",
//	"F_Category": "1",
//	"F_EnCode": "100060",
//	"F_FullName": "燃保巡检员",
//	"F_SortCode": 60,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:05",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "a6dbb68d-817a-4341-b199-b913f4d1091a",
//	"F_Category": "1",
//	"F_EnCode": "100124",
//	"F_FullName": "总经理",
//	"F_SortCode": 124,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:10",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "4e978770-0100-4c6e-b646-422d372ea23f",
//	"F_Category": "1",
//	"F_EnCode": "100009",
//	"F_FullName": "生产统计员",
//	"F_SortCode": 9,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责生产数据统计",
//	"F_CreateDate": "2015-11-04 16:11:01",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "adad429e-a6e8-4137-93a4-a9ad4d2671f4",
//	"F_Category": "1",
//	"F_EnCode": "100038",
//	"F_FullName": "测试岗位2",
//	"F_SortCode": 38,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "&nbsp;",
//	"F_CreateDate": "2015-11-04 16:11:04",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "210beb4d-e96c-4673-b617-45b79ee8dfde",
//	"F_Category": "1",
//	"F_EnCode": "100041",
//	"F_FullName": "燃气维保巡检员4",
//	"F_SortCode": 41,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:04",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "3959c15b-3e35-4db0-896b-436eba619906",
//	"F_Category": "1",
//	"F_EnCode": "100104",
//	"F_FullName": "公司领导",
//	"F_SortCode": 104,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "[系统内置]",
//	"F_CreateDate": "2015-11-04 16:11:09",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "5735a488-58da-423f-be81-9a846c822ece",
//	"F_Category": "1",
//	"F_EnCode": "test",
//	"F_FullName": "测试数据",
//	"F_SortCode": null,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "测试数据",
//	"F_CreateDate": "2017-04-28 09:49:16",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "21293c5e-60b0-4f31-a514-78313a8a6499",
//	"F_Category": "1",
//	"F_EnCode": "100105",
//	"F_FullName": "公司会计",
//	"F_SortCode": 105,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "[系统内置]",
//	"F_CreateDate": "2015-11-04 16:11:09",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "1a300077-2ffe-4001-97b9-e9c0bb8c43e3",
//	"F_Category": "1",
//	"F_EnCode": "100102",
//	"F_FullName": "检修班长",
//	"F_SortCode": 102,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:09",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "bf23dd88-2aed-4780-b260-430bee08bd2b",
//	"F_Category": "1",
//	"F_EnCode": "100057",
//	"F_FullName": "乙班班长",
//	"F_SortCode": 57,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:05",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "81d54a99-f6ac-44fd-8695-be5daf800eb2",
//	"F_Category": "1",
//	"F_EnCode": "100039",
//	"F_FullName": "燃气维保巡检员1",
//	"F_SortCode": 39,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:04",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "667deed2-f95c-4230-931b-b6658dbd53ab",
//	"F_Category": "1",
//	"F_EnCode": "100110",
//	"F_FullName": "系统管理员",
//	"F_SortCode": 110,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "[系统内置]",
//	"F_CreateDate": "2015-11-04 16:11:09",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "2ab5edea-4448-4ee3-92d5-8bd8bb86fafb",
//	"F_Category": "1",
//	"F_EnCode": "100118",
//	"F_FullName": "公司中层领导",
//	"F_SortCode": 118,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:10",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "43400843-6c97-436c-8dda-cc1298923814",
//	"F_Category": "1",
//	"F_EnCode": "100032",
//	"F_FullName": "现场管理员",
//	"F_SortCode": 32,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责现场管理",
//	"F_CreateDate": "2015-11-04 16:11:03",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "ec5f1e00-43aa-4573-9ec3-9d71068ce080",
//	"F_Category": "1",
//	"F_EnCode": "100091",
//	"F_FullName": "仓库管理员1",
//	"F_SortCode": 91,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责仓库管理",
//	"F_CreateDate": "2015-11-04 16:11:08",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "369bd2a7-069f-47ff-ab65-82a6bc9d4c78",
//	"F_Category": "1",
//	"F_EnCode": "100112",
//	"F_FullName": "安全管理员",
//	"F_SortCode": 112,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "[系统内置]",
//	"F_CreateDate": "2015-11-04 16:11:09",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "a5dee45d-8045-4bf3-9434-920f6a34f440",
//	"F_Category": "1",
//	"F_EnCode": "100096",
//	"F_FullName": "系统管理",
//	"F_SortCode": 96,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "&nbsp;",
//	"F_CreateDate": "2015-11-04 16:11:08",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "dbd5f525-c973-4ac9-b13a-0d166f9372e6",
//	"F_Category": "1",
//	"F_EnCode": "100037",
//	"F_FullName": "测试岗位1",
//	"F_SortCode": 37,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "&nbsp;",
//	"F_CreateDate": "2015-11-04 16:11:04",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "a5cc855d-de99-4b37-b7c3-4f960f25227d",
//	"F_Category": "1",
//	"F_EnCode": "100024",
//	"F_FullName": "巡检工1",
//	"F_SortCode": 24,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责现场设备巡检",
//	"F_CreateDate": "2015-11-04 16:11:03",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "9a06e2f8-eb3d-47b7-80f2-725ff7585ff5",
//	"F_Category": "1",
//	"F_EnCode": "100138",
//	"F_FullName": "宾客",
//	"F_SortCode": 138,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "宾客角色",
//	"F_CreateDate": "2015-11-04 16:11:12",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2017-08-23 18:18:45",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "b2a9d3c5-5ef9-460f-a396-1fe050785cac",
//	"F_Category": "1",
//	"F_EnCode": "100135",
//	"F_FullName": "仓库保管员",
//	"F_SortCode": 135,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:11",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "1999c024-25b2-4feb-a1fc-88fa3318133d",
//	"F_Category": "1",
//	"F_EnCode": "100065",
//	"F_FullName": "丙班检修工",
//	"F_SortCode": 65,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:06",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2017-04-20 11:36:56",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "ba44d84f-8df3-432a-9f3a-6b16365df440",
//	"F_Category": "1",
//	"F_EnCode": "100133",
//	"F_FullName": "工程实施人员",
//	"F_SortCode": 133,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:11",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "5d45079d-4d14-4fb3-894f-3653a4b6a243",
//	"F_Category": "1",
//	"F_EnCode": "100061",
//	"F_FullName": "测试",
//	"F_SortCode": 61,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "测试角色",
//	"F_CreateDate": "2015-11-04 16:11:05",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "00195dc6-f624-4c49-9ed3-9d3082be6308",
//	"F_Category": "1",
//	"F_EnCode": "100130",
//	"F_FullName": "业务部主管",
//	"F_SortCode": 130,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:11",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "be8f117b-7dc1-4dcb-8382-ef19df096131",
//	"F_Category": "1",
//	"F_EnCode": "100007",
//	"F_FullName": "物流人员",
//	"F_SortCode": 7,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责微粉外发",
//	"F_CreateDate": "2015-11-04 16:11:01",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "008caf61-fdda-43c7-af23-2eeebcacae85",
//	"F_Category": "1",
//	"F_EnCode": "100054",
//	"F_FullName": "生产统计员1",
//	"F_SortCode": 54,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责生产数据统计",
//	"F_CreateDate": "2015-11-04 16:11:05",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "57aba436-595d-4068-89af-dc8643eb7b5e",
//	"F_Category": "1",
//	"F_EnCode": "100092",
//	"F_FullName": "仓库管理员2",
//	"F_SortCode": 92,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责仓库管理",
//	"F_CreateDate": "2015-11-04 16:11:08",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "f819fe42-e836-4b98-a24d-8dd849031679",
//	"F_Category": "1",
//	"F_EnCode": "100062",
//	"F_FullName": "检修班长",
//	"F_SortCode": 62,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:06",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "9074cae0-a5ea-4114-b980-df5761c2afc7",
//	"F_Category": "1",
//	"F_EnCode": "100137",
//	"F_FullName": "检修人员",
//	"F_SortCode": 137,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2015-11-04 16:11:11",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2016-03-03 10:22:25",
//	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
//	"F_ModifyUserName": "佘赐雄"
//}, {
//	"F_Id": "943428cc-8db3-4f5c-8cde-4c05d42980f6",
//	"F_Category": "1",
//	"F_EnCode": "100076",
//	"F_FullName": "制造部部长",
//	"F_SortCode": 76,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责生产管理",
//	"F_CreateDate": "2015-11-04 16:11:07",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "3bbea8fc-4c68-4955-bd01-09b462c717d4",
//	"F_Category": "1",
//	"F_EnCode": "100128",
//	"F_FullName": "客户服务主管",
//	"F_SortCode": 128,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2015-11-04 16:11:11",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2017-01-22 11:04:38",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "7eb67636-7252-4dd1-a268-84d33a969f67",
//	"F_Category": "1",
//	"F_EnCode": "100119",
//	"F_FullName": "公司业务人员",
//	"F_SortCode": 119,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:10",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "cdad8fa5-d7bd-48c8-b44a-444cb87ae9e8",
//	"F_Category": "1",
//	"F_EnCode": "100034",
//	"F_FullName": "测试岗位3",
//	"F_SortCode": 34,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "&nbsp;",
//	"F_CreateDate": "2015-11-04 16:11:03",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "c13b766f-4459-40d3-a289-6eb036154917",
//	"F_Category": "1",
//	"F_EnCode": "99999",
//	"F_FullName": "力软内部测试角色",
//	"F_SortCode": null,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "力软测试",
//	"F_CreateDate": "2016-05-23 11:00:33",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "e17d3383-2ba9-46a7-87f5-c9b7de507051",
//	"F_Category": "1",
//	"F_EnCode": "100126",
//	"F_FullName": "开发部主管",
//	"F_SortCode": 126,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:11",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "88da93eb-1ba8-4a40-9d64-d7ce26bc0417",
//	"F_Category": "1",
//	"F_EnCode": "100136",
//	"F_FullName": "总经理助理",
//	"F_SortCode": 136,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2015-11-04 16:11:11",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2015-12-22 18:05:41",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "991e3103-7705-4637-822a-d3ffb804c5bb",
//	"F_Category": "1",
//	"F_EnCode": "100059",
//	"F_FullName": "丁班巡检员",
//	"F_SortCode": 59,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:05",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "565870b3-f834-4ac6-84bd-ed0cba744d15",
//	"F_Category": "1",
//	"F_EnCode": "100090",
//	"F_FullName": "生产统计员3",
//	"F_SortCode": 90,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责生产数据统计",
//	"F_CreateDate": "2015-11-04 16:11:08",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "990dbca5-e1e2-4a3e-99fa-4814c16f1a9a",
//	"F_Category": "1",
//	"F_EnCode": "100022",
//	"F_FullName": "部长",
//	"F_SortCode": 22,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责部门管理",
//	"F_CreateDate": "2015-11-04 16:11:02",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2017-08-11 09:44:20",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "309fc31c-4177-4c8a-b563-831d667115b7",
//	"F_Category": "1",
//	"F_EnCode": "100089",
//	"F_FullName": "生产统计员2",
//	"F_SortCode": 89,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责生产数据统计",
//	"F_CreateDate": "2015-11-04 16:11:08",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "bf501cf3-c908-4e38-a697-09ec394793f3",
//	"F_Category": "1",
//	"F_EnCode": "100033",
//	"F_FullName": "固定资产管理员",
//	"F_SortCode": 33,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责固定资产管理",
//	"F_CreateDate": "2015-11-04 16:11:03",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "203c1acf-8807-496d-8013-ef48c6971118",
//	"F_Category": "1",
//	"F_EnCode": "100006",
//	"F_FullName": "中控员",
//	"F_SortCode": 6,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责磨机操作",
//	"F_CreateDate": "2015-11-04 16:11:01",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "186bb4a4-9631-418e-a52c-5dae289489e5",
//	"F_Category": "1",
//	"F_EnCode": "100066",
//	"F_FullName": "乙班检修工",
//	"F_SortCode": 66,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:06",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "d927cb02-3d98-436f-b35d-f4530a3ba563",
//	"F_Category": "1",
//	"F_EnCode": "100011",
//	"F_FullName": "检修班长",
//	"F_SortCode": 11,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:02",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "08616575-07e8-4a36-99e4-40b0e58cc6c1",
//	"F_Category": "1",
//	"F_EnCode": "100002",
//	"F_FullName": "总调度长",
//	"F_SortCode": 2,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责生产管理",
//	"F_CreateDate": "2015-11-04 16:11:01",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "28b73595-a35e-4d39-8cab-55fbc5ae7ce9",
//	"F_Category": "1",
//	"F_EnCode": "100004",
//	"F_FullName": "设备管理员",
//	"F_SortCode": 4,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责设备管理",
//	"F_CreateDate": "2015-11-04 16:11:01",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "84c11691-684f-4d73-982b-d73113b9af6b",
//	"F_Category": "1",
//	"F_EnCode": "100131",
//	"F_FullName": "开发人员",
//	"F_SortCode": 131,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2015-11-04 16:11:11",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2015-11-04 16:13:51",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "d958a8ae-1b04-471a-bdde-6580e7e9c052",
//	"F_Category": "1",
//	"F_EnCode": "100021",
//	"F_FullName": "系统用户角色",
//	"F_SortCode": 21,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "&nbsp;",
//	"F_CreateDate": "2015-11-04 16:11:02",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "d1d152c5-557e-406f-88ab-c4d541e0dd08",
//	"F_Category": "1",
//	"F_EnCode": "100075",
//	"F_FullName": "新方专家",
//	"F_SortCode": 75,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "&nbsp;",
//	"F_CreateDate": "2015-11-04 16:11:07",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "ab9bb5b9-60c6-4c1a-bd57-ea32d23347e3",
//	"F_Category": "1",
//	"F_EnCode": "100116",
//	"F_FullName": "用户",
//	"F_SortCode": 116,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "[系统内置]",
//	"F_CreateDate": "2015-11-04 16:11:10",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "d617e4c0-f70b-4486-8f46-857bd007d3a0",
//	"F_Category": "1",
//	"F_EnCode": "100123",
//	"F_FullName": "人事主管",
//	"F_SortCode": 123,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:10",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "0a825fcd-103f-4b16-b965-90723ce96fa3",
//	"F_Category": "1",
//	"F_EnCode": "100056",
//	"F_FullName": "资料管理员",
//	"F_SortCode": 56,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责资料管理",
//	"F_CreateDate": "2015-11-04 16:11:05",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "051b1a3c-3646-4964-ae85-50750b3bf884",
//	"F_Category": "1",
//	"F_EnCode": "100134",
//	"F_FullName": "热线客服",
//	"F_SortCode": 134,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:11",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "756133f5-934e-487f-9d5c-2838791e69b1",
//	"F_Category": "1",
//	"F_EnCode": "100079",
//	"F_FullName": "燃气维保巡检员2",
//	"F_SortCode": 79,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:07",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "e9624138-1a09-4f5b-9506-77a2ed0e2070",
//	"F_Category": "1",
//	"F_EnCode": "100051",
//	"F_FullName": "巡检员",
//	"F_SortCode": 51,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责现场设备巡检",
//	"F_CreateDate": "2015-11-04 16:11:05",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "544753a6-8b5d-437e-9e08-1e96549d41a1",
//	"F_Category": "1",
//	"F_EnCode": "100115",
//	"F_FullName": "内部员工",
//	"F_SortCode": 115,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "[系统内置]",
//	"F_CreateDate": "2015-11-04 16:11:10",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "25808cfe-7e88-4ddb-81a0-d5137d30b41c",
//	"F_Category": "1",
//	"F_EnCode": "100063",
//	"F_FullName": "乙班巡检员",
//	"F_SortCode": 63,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:06",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "2810274c-5549-4283-9d86-2064e39c6e5a",
//	"F_Category": "1",
//	"F_EnCode": "100069",
//	"F_FullName": "丙班班长",
//	"F_SortCode": 69,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:06",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2017-06-01 14:24:38",
//	"F_ModifyUserId": "24a055d6-5924-44c5-be52-3715cdd68011",
//	"F_ModifyUserName": "陈彬彬"
//}, {
//	"F_Id": "f9ed83ea-9204-4b53-8f18-36120423fc1b",
//	"F_Category": "1",
//	"F_EnCode": "100120",
//	"F_FullName": "公司技术人员",
//	"F_SortCode": 120,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:10",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "036352aa-5809-493f-a047-1f7dd72c1036",
//	"F_Category": "1",
//	"F_EnCode": "100010",
//	"F_FullName": "数据维护管理员",
//	"F_SortCode": 10,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "",
//	"F_CreateDate": "2015-11-04 16:11:02",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "7321b2d4-4265-470e-b291-5bdf88c73078",
//	"F_Category": "1",
//	"F_EnCode": "100008",
//	"F_FullName": "检修人员",
//	"F_SortCode": 8,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "负责设备检修",
//	"F_CreateDate": "2015-11-04 16:11:01",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}],                 // 列表数据
//	        headData: [{
//				label: '主键',
//				name: 'F_Id'				
//			},
//			 { label: '角色编号', name: 'F_EnCode', width: 100, align: "center" },
//                  { label: '角色名称', name: 'F_FullName', width: 200, align: "center" },
//                  {
//                      label: '创建时间', name: 'F_CreateDate', width: 130, align: 'center'
//                  },
//                  {
//                      label: '创建人', name: 'F_CreateUserName', width: 130, align: 'center'
//                  },
//                  {
//                      label: "有效", name: "F_EnabledMark", width: 50, align: "center",
//                      formatter: function (cellvalue) {
//                          return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
//                      }
//                  },
//                  { label: "角色描述", name: "F_Description", index: "F_Description", width: 300, align: "center" }
//		],
//		isPage: true,
//      reloadSelected: true,
//      mainId: 'F_Id'
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