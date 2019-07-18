(function($, app) {
	"use strict";		
   var keyValue = '';
	var options = {
		params: { //参数
			router: "Dictionary",
			form:{ 
				title:"字典分类",
				width:550,
				height:450			
			}
		},
		Event: { //初始化事件
			doBeforeInit: function() {
				$('#app_layout').appLayout();
			}
		},
		search: {//搜索			
				
		},
		tree: { //启用左侧树形		
			
		},  
		bindEvent:{//点击事件参数 
			add: {
				
			}	            								
		},
		grid: { //grid 
			options: {
				url: '/api/Dictionary/GetDictionaryByPages',
				//rowdatas: itemstypedata,
				 headData:[
	                { label: '项目名', name: 'fullname', width: 200, align: "center" },
                    { label: '项目值', name: 'encode', width: 200, align: "center" },
                    //{ label: '简拼', name: 'SimpleSpelling', width: 150, align: "center" },
                    { label: '排序', name: 'sortcode',hidden:true, width: 80, align: 'center' },
                    {
                        label: "有效", name: "enabledmark", width: 50, align: "center",
                        formatter: function (cellvalue) {
                            return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
                        }
                    },
                    { label: "备注", name: "description", width: 200, align: "center" }
		        ], 
		        parentId: 'ParentId',
		        reloadSelected:true
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
//var router="SystemManage/ItemsType";
//var refreshGirdData; // 更新数据
//var selectedRow;
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
//              pageEvent.search({keyword: keyword });
//          });
//          // 刷新
//          $('#app_refresh').on('click', function () {
//              location.reload();
//              
//          });
//          // 新增
//          $('#app_add').on('click', function () {
//          	var f_ItemId = $('#gridtable').appGridValue('F_Id');
//              selectedRow = null;            	
//          	//layx.iframe('1','添加','../html/form.html?parentId=' + f_ItemId);            	           	
//              layx.iframe('1','添加','../html/form.html?parentId=' + f_ItemId,{
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
//          	selectedRow = $('#gridtable').appGridGet('rowdata');
//              var keyValue = $('#gridtable').appGridValue('F_Id');
//          	//alert(keyValue)           	
//          	 if (app.BASE_UTILS.checkrow(keyValue)) {
//          	 	 //layx.iframe('1','编辑','../html/form.html');
//          	 	layx.iframe('1','添加','../html/form.html',{
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
//                                     	                
//             
//          });
//          
//          // 删除
//          $('#app_delete').on('click', function () {
//              var keyValue = $('#gridtable').appgridValue('F_Id');
//              if (app.BASE_UTILS.checkrow(keyValue)) {         
//	                app.MODAL_UTILS.confirm({
//			                msg: "是否确认删除该项！",
//			                callback: function () {	
//			                	if (res) {
//			                        app.deleteForm(top.$.rootUrl + '/LR_SystemModule/DataItem/DeleteClassifyForm', { keyValue: keyValue }, function () {
//			                            refreshGirdData();
//			                        });
//			                        /*request.delete({
//										url:router+ "/DeleteForm?keyValue=" + keyValue,					
//										success: function(data) {						
//											refreshGirdData();									
//										}
//									});*/
//			                    }
//	                            
//			                }
//	                })
//              }                
//          });
//           
//      },
//     
//      
//       /**
//       * 初始化表格
//       */
//       initgrid: function () {
//       $("#gridtable").appgrid({        	   	 	
//	            url: '',                // 数据服务地址
//	            param: {},                    // 请求参数
//	            rowdatas:[{
//	"F_Id": "7BCDCAA4-2C65-444A-9D04-57F990585C92",
//	"F_ParentId": "0",
//	"F_ItemCode": "SysManage",
//	"F_ItemName": "系统管理",
//	"F_IsTree": null,
//	"F_IsNav": null,
//	"F_SortCode": 1,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2015-11-16 14:34:43",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "c5e19e10-e12a-4723-a553-3b3a93ad3f15",
//	"F_ParentId": "0",
//	"F_ItemCode": "FormManage",
//	"F_ItemName": "表单管理",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 2,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2017-06-29 10:47:01",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "84486467-5DFC-4538-BE86-0440DDDFEF81",
//	"F_ParentId": "0",
//	"F_ItemCode": "FlowManage",
//	"F_ItemName": "流程管理",
//	"F_IsTree": null,
//	"F_IsNav": null,
//	"F_SortCode": 3,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2015-11-16 14:34:43",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "3dd1b605-6813-45b5-bbe2-dd6ca87aeabd",
//	"F_ParentId": "0",
//	"F_ItemCode": "ClientManage",
//	"F_ItemName": "客户关系",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 4,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2016-03-11 16:53:36",
//	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
//	"F_CreateUserName": "佘赐雄",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "ea7b231f-fd49-421e-96f9-b350db85ea77",
//	"F_ParentId": "0",
//	"F_ItemCode": "CodeCreate",
//	"F_ItemName": "快速开发",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 4,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "代码快速生成器",
//	"F_CreateDate": "2016-12-02 18:13:57",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "54a5ac3f-1d3a-4351-b1ef-6f1997ad1432",
//	"F_ParentId": "0",
//	"F_ItemCode": "AppManager",
//	"F_ItemName": "移动管理",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 5,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-03-16 11:37:22",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2018-03-16 11:37:53",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ParentId": "0",
//	"F_ItemCode": "WFForm",
//	"F_ItemName": "流程自定义表单",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 6,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 15:51:18",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "7ade31ef-ce72-4b74-ac76-68ca7c3ea9db",
//	"F_ParentId": "0",
//	"F_ItemCode": "demo-1",
//	"F_ItemName": "演示字典",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 8,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2017-09-27 15:37:34",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "7d610912-447d-4e64-8316-32e399455276",
//	"F_ParentId": "3dd1b605-6813-45b5-bbe2-dd6ca87aeabd",
//	"F_ItemCode": "Client_ProductInfo",
//	"F_ItemName": "产品信息",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 1,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2016-03-11 16:54:22",
//	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
//	"F_CreateUserName": "佘赐雄",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "7abafdbc-7df7-4180-a778-8ee0a5ed206b",
//	"F_ParentId": "3dd1b605-6813-45b5-bbe2-dd6ca87aeabd",
//	"F_ItemCode": "Client_Trade",
//	"F_ItemName": "客户行业",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 2,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2016-03-11 16:54:44",
//	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
//	"F_CreateUserName": "佘赐雄",
//	"F_ModifyDate": "2016-03-14 10:27:16",
//	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
//	"F_ModifyUserName": "佘赐雄"
//}, {
//	"F_Id": "ea5a8f18-b524-419a-ab22-c72c5c171fe7",
//	"F_ParentId": "3dd1b605-6813-45b5-bbe2-dd6ca87aeabd",
//	"F_ItemCode": "Client_Sort",
//	"F_ItemName": "客户类别",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 3,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2016-03-11 16:54:59",
//	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
//	"F_CreateUserName": "佘赐雄",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "1131f08f-4119-4caf-aa84-db0e1b7f0f47",
//	"F_ParentId": "3dd1b605-6813-45b5-bbe2-dd6ca87aeabd",
//	"F_ItemCode": "Client_Level",
//	"F_ItemName": "客户级别",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 4,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2016-03-11 16:55:16",
//	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
//	"F_CreateUserName": "佘赐雄",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "8215df73-5adf-482a-96e4-7c49494f9674",
//	"F_ParentId": "3dd1b605-6813-45b5-bbe2-dd6ca87aeabd",
//	"F_ItemCode": "Client_Degree",
//	"F_ItemName": "客户程度",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 5,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2016-03-11 16:55:31",
//	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
//	"F_CreateUserName": "佘赐雄",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "69e891d8-62ae-4a44-95cf-e4d6a380835f",
//	"F_ParentId": "3dd1b605-6813-45b5-bbe2-dd6ca87aeabd",
//	"F_ItemCode": "Client_ChanceSource",
//	"F_ItemName": "商机来源",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 6,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2016-03-12 10:59:21",
//	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
//	"F_CreateUserName": "佘赐雄",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "86de0271-1975-4b99-a2d6-f0d492043537",
//	"F_ParentId": "3dd1b605-6813-45b5-bbe2-dd6ca87aeabd",
//	"F_ItemCode": "Client_ChancePhase",
//	"F_ItemName": "商机阶段",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 7,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2016-03-12 11:00:15",
//	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
//	"F_CreateUserName": "佘赐雄",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "a06b0ee3-a8e5-4ce2-badf-235a50445a57",
//	"F_ParentId": "3dd1b605-6813-45b5-bbe2-dd6ca87aeabd",
//	"F_ItemCode": "Client_ChanceSort",
//	"F_ItemName": "商机类别",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 8,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2016-03-12 12:21:38",
//	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
//	"F_CreateUserName": "佘赐雄",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "7e0cc2e5-5d24-43af-847e-4972f9e674d3",
//	"F_ParentId": "3dd1b605-6813-45b5-bbe2-dd6ca87aeabd",
//	"F_ItemCode": "Client_PaymentMode",
//	"F_ItemName": "收支方式",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 9,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2016-03-14 19:42:07",
//	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
//	"F_CreateUserName": "佘赐雄",
//	"F_ModifyDate": "2016-04-20 09:55:40",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "38162648-8927-4aba-8f6e-31005b0a37b4",
//	"F_ParentId": "3dd1b605-6813-45b5-bbe2-dd6ca87aeabd",
//	"F_ItemCode": "Client_PaymentAccount",
//	"F_ItemName": "收支账户",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 10,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2016-04-20 09:51:01",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2016-04-20 09:55:32",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "9eb4a902-9337-41cc-bbfe-a981552777da",
//	"F_ParentId": "3dd1b605-6813-45b5-bbe2-dd6ca87aeabd",
//	"F_ItemCode": "Client_ExpensesType",
//	"F_ItemName": "支出种类",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 11,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2016-04-20 11:48:37",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "49c6dedc-b676-4326-bd0b-2437d8959895",
//	"F_ParentId": "54a5ac3f-1d3a-4351-b1ef-6f1997ad1432",
//	"F_ItemCode": "function",
//	"F_ItemName": "功能分类",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 0,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-03-16 11:39:18",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "0c00ee6a-69ae-4aa8-bc5e-073277bb960b",
//	"F_ParentId": "7ade31ef-ce72-4b74-ac76-68ca7c3ea9db",
//	"F_ItemCode": "xueke",
//	"F_ItemName": "学科",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 1,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2017-09-27 15:38:04",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "FBF3CB04-1538-48B8-94EB-C4BDC6DB3AF5",
//	"F_ParentId": "7BCDCAA4-2C65-444A-9D04-57F990585C92",
//	"F_ItemCode": "DbVersion",
//	"F_ItemName": "数据库版本",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 3,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2015-11-16 14:34:43",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2017-07-17 14:24:28",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "f87d91a7-fe95-4117-9d03-c95a7f9288d0",
//	"F_ParentId": "7BCDCAA4-2C65-444A-9D04-57F990585C92",
//	"F_ItemCode": "DbFieldType",
//	"F_ItemName": "数据库字段类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 4,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-03-30 14:52:11",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "55fbf5d7-b3f4-4851-ae3a-fdb9ef22fb1b",
//	"F_ParentId": "7BCDCAA4-2C65-444A-9D04-57F990585C92",
//	"F_ItemCode": "NewsCategory",
//	"F_ItemName": "新闻类别",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 5,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2015-12-07 13:52:04",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2017-04-14 14:25:01",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "da65e343-548f-4e00-8b23-33f3acef7f55",
//	"F_ParentId": "7BCDCAA4-2C65-444A-9D04-57F990585C92",
//	"F_ItemCode": "NoticeCategory",
//	"F_ItemName": "公告类别",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 7,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2015-12-07 18:11:02",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2017-04-14 14:04:06",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "e65d50bb-80f7-4231-8824-86f3abec842d",
//	"F_ParentId": "7BCDCAA4-2C65-444A-9D04-57F990585C92",
//	"F_ItemCode": "ReportSort",
//	"F_ItemName": "报表分类",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 7,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2016-03-11 18:52:49",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2017-07-12 14:58:31",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "7b6933ce-1b9f-4266-aed0-5c85e7029db0",
//	"F_ParentId": "7BCDCAA4-2C65-444A-9D04-57F990585C92",
//	"F_ItemCode": "SaveFilePath",
//	"F_ItemName": "文件保存目录",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 8,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2016-10-10 23:26:47",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2016-10-10 23:27:06",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "633E7E8B-9C48-419F-B392-EC1637CC5352",
//	"F_ParentId": "7BCDCAA4-2C65-444A-9D04-57F990585C92",
//	"F_ItemCode": "CompanyNature",
//	"F_ItemName": "公司性质",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 11,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2015-11-16 14:34:43",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2016-03-18 11:10:03",
//	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
//	"F_ModifyUserName": "佘赐雄"
//}, {
//	"F_Id": "35CB1499-FC23-418D-B3D5-F8FAFCFD38B0",
//	"F_ParentId": "7BCDCAA4-2C65-444A-9D04-57F990585C92",
//	"F_ItemCode": "DepartmentNature",
//	"F_ItemName": "部门性质",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 12,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2015-11-16 14:34:43",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2016-03-18 11:10:09",
//	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
//	"F_ModifyUserName": "佘赐雄"
//}, {
//	"F_Id": "b6352df2-e415-4e65-b282-88c5a4c6f2f6",
//	"F_ParentId": "7BCDCAA4-2C65-444A-9D04-57F990585C92",
//	"F_ItemCode": "FieldType",
//	"F_ItemName": "数据字段类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 100,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": "用于接口维护",
//	"F_CreateDate": "2017-07-04 10:33:20",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "a37d6faa-a684-4969-8525-64f5048d7f18",
//	"F_ParentId": "7BCDCAA4-2C65-444A-9D04-57F990585C92",
//	"F_ItemCode": "usersex",
//	"F_ItemName": "人员性别",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 200,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2017-09-01 17:43:16",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2017-09-01 17:43:25",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "EA857B79-692E-48F8-99F9-3D540DD8EEB9",
//	"F_ParentId": "84486467-5DFC-4538-BE86-0440DDDFEF81",
//	"F_ItemCode": "AuditStatus",
//	"F_ItemName": "审核状态",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 1,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2015-11-16 14:34:43",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2018-06-28 16:56:38",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "98D28E4D-0D6D-45EF-9363-605CB0A6097F",
//	"F_ParentId": "84486467-5DFC-4538-BE86-0440DDDFEF81",
//	"F_ItemCode": "FlowSort",
//	"F_ItemName": "流程类别",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 4,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2015-11-16 14:34:43",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2015-11-27 10:34:34",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "a6526d90-15db-4ed7-be93-9dce75c93a68",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "DocumentType",
//	"F_ItemName": "公文文种",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 1,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 15:58:15",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "7edb77a1-81a9-4e9c-857c-d2fed3bdac51",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "SecretLevel",
//	"F_ItemName": "秘密等级",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 2,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 15:59:02",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "2099d806-27ed-4b38-a3c8-8e525ebc54e9",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "Degree",
//	"F_ItemName": "紧急程度",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 3,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 15:59:34",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "980d6424-904d-4e97-9ab6-f3dd27613ba2",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "YesOrNo",
//	"F_ItemName": "是否",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 4,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:00:01",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "fb367980-fb4f-4c7a-8d35-cbac70fa69eb",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "TicketType",
//	"F_ItemName": "车票类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 5,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:00:28",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "24d4fd4e-eed5-495b-bbd3-9d7c413753c8",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "DisposeMethod",
//	"F_ItemName": "处置方式",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 6,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:00:56",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "0c32779d-5c99-472a-81ac-3f121517e989",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "CachetType",
//	"F_ItemName": "公章类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 7,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:01:20",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "b43e4de3-885c-4ab9-a382-9e870b0d144b",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "OutType",
//	"F_ItemName": "外出类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 8,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:01:47",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "5ce842b6-d40e-4d3d-a60d-f939ef3915d0",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "LeaveType",
//	"F_ItemName": "请假类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 9,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:02:11",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "a71ac9ab-3c5c-4cad-a463-5f08d1880b8e",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "InvoProduct",
//	"F_ItemName": "涉及首要产品",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 10,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:02:51",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "cc8668f0-e46e-4313-abeb-3d043b002e79",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "TrainMethods",
//	"F_ItemName": "培训方式",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 11,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:03:15",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "6001c400-31e5-4a24-a96f-4f0f51317e71",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "ExtraWorkType",
//	"F_ItemName": "加班类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 12,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:03:39",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "15322f80-d492-4de9-a37a-6fb668948f5b",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "ProductType",
//	"F_ItemName": "产品类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 13,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:04:10",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "4fc39c06-a45c-4ef6-85e0-ca5bfb0b205f",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "HaveOrNot",
//	"F_ItemName": "有无",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 14,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:04:34",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "3ced75f2-0fee-443c-8725-6fbb6b591f57",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "AccessType",
//	"F_ItemName": "参观访问类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 15,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:05:01",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "9373f853-9e20-4472-9a89-fd0b6ae8a2ff",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "CustQuality",
//	"F_ItemName": "客户性质",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 16,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:05:29",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "1ad5a5c9-1ab5-4ee2-8b36-1779ad0c8051",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "QuatationType",
//	"F_ItemName": "报表类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 17,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:05:51",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "07d83cbf-206a-4dc9-9088-bf44fb644001",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "EndType",
//	"F_ItemName": "终止类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 18,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:06:18",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "2a87fc49-3669-41e6-9d44-26d019c85fb0",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "PayMethod",
//	"F_ItemName": "付款方式",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 19,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:06:40",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "9427788a-0d38-4385-bdbc-59544a7efc0c",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "CostCategory",
//	"F_ItemName": "费用类别",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 20,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:07:02",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "0eca4b92-cfc5-4b4f-ac45-d123e5bd1307",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "CostSubject",
//	"F_ItemName": "费用科目",
//	"F_IsTree": 1,
//	"F_IsNav": null,
//	"F_SortCode": 21,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:07:40",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2018-06-28 16:55:47",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}, {
//	"F_Id": "a415cc73-8747-443f-9335-fa84ec6ce9a2",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "CLibraryType",
//	"F_ItemName": "构件库类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 22,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:08:07",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "20a2213a-3b85-4277-a880-984a4a8b1b24",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "CLibraryModule",
//	"F_ItemName": "构件库所属模块",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 23,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:08:30",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "84c07cd4-694c-4265-b78a-815fc713005f",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "CLibraryVersion",
//	"F_ItemName": "构件库适用版本",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 24,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:08:55",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "baa3482c-b1b1-4b98-8d8d-1c785c012025",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "ReimburseWay",
//	"F_ItemName": "报销方式",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 25,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:09:19",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "038017a6-57e0-4a1e-987b-40e6a52fff43",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "Bank",
//	"F_ItemName": "公司银行",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 26,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:09:42",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "6c678e41-83db-4d79-b3b0-3de786ee2210",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "ReimburseType",
//	"F_ItemName": "报销类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 27,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:10:07",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "b52f2431-6d5f-483d-bacf-7e15f6d9ccee",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "TrafficType",
//	"F_ItemName": "交通方式",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 28,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:23:26",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "119481ef-9c5a-400d-a46b-f06c4b2c8641",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "ContractType",
//	"F_ItemName": "合同类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 29,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:23:52",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "2e90fb0c-28ab-4f6b-bf20-884aa7776b19",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "SaleType",
//	"F_ItemName": "销售类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 30,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:24:13",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "03e74863-da1c-4563-b120-3b3c70097123",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "CompanyType",
//	"F_ItemName": "企业类型",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 31,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:24:34",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "e0101e2c-1e69-44b6-8c8d-824d66b27a01",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "Products",
//	"F_ItemName": "相关产品",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 32,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:25:03",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "bcd84029-8cc6-4cd9-95fe-efecdc086413",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "BuyPatterns",
//	"F_ItemName": "购买方式",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 33,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:25:21",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "bd73478d-f2ff-4aab-9f59-5ff52cb6e5bb",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "ContractSignMode",
//	"F_ItemName": "合同签订方式",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 34,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:25:41",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "878baa4e-bd88-4fbf-a8c2-8e3914b271f7",
//	"F_ParentId": "98189a93-a2e1-4936-ade7-87ae1282a11a",
//	"F_ItemCode": "BusinessSource",
//	"F_ItemName": "商机的来源",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 35,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2018-06-28 16:26:00",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "d442b904-dcea-4421-95d8-8758251dc986",
//	"F_ParentId": "c5e19e10-e12a-4723-a553-3b3a93ad3f15",
//	"F_ItemCode": "FormSort",
//	"F_ItemName": "表单分类",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 1,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2017-06-29 10:47:33",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": null,
//	"F_ModifyUserId": null,
//	"F_ModifyUserName": null
//}, {
//	"F_Id": "9ee08b09-3ab2-446e-8840-6eeab6a33f89",
//	"F_ParentId": "ea7b231f-fd49-421e-96f9-b350db85ea77",
//	"F_ItemCode": "outputArea",
//	"F_ItemName": "输出区域",
//	"F_IsTree": 0,
//	"F_IsNav": null,
//	"F_SortCode": 1,
//	"F_DeleteMark": 0,
//	"F_EnabledMark": 1,
//	"F_Description": null,
//	"F_CreateDate": "2017-08-13 14:44:24",
//	"F_CreateUserId": "System",
//	"F_CreateUserName": "超级管理员",
//	"F_ModifyDate": "2018-06-28 16:38:42",
//	"F_ModifyUserId": "System",
//	"F_ModifyUserName": "超级管理员"
//}],                 // 列表数据
//	        headData: [
//	                { label: '名称', name: 'F_ItemName', width: 200, align: "center" },
//                  { label: '编号', name: 'F_ItemCode', width: 200, align: "center" },
//                  { label: 'F_Id', name: 'F_Id', width: 200, align: "center" },
//                  { label: '排序', name: 'F_SortCode', width: 50, align: 'center' },
//                  {
//                      label: "树型", name: "F_IsTree",width: 50, align: "center",
//                      formatter: function (cellvalue) {
//                          return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
//                      }
//                  },
//                  {
//                      label: "有效", name: "F_EnabledMark",width: 50, align: "center",
//                      formatter: function (cellvalue) {
//                          return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
//                      }
//                  },
//                  { label: "备注", name: "F_Description", width: 200, align: "center" }
//		],                                    // 列数据	
//	            isTree: true,
//              mainId: 'F_Id',
//              parentId: 'F_ParentId',
//              reloadSelected:true
//      });
//      pageEvent.search();
//     },
//      search: function (param) {
//          $('#gridtable').appGridSet('reload', param);
//      }
//  } 
//  // 保存数据后回调刷新
//     refreshGirdData = function () {
//      pageEvent.search();
//  }
//
//
//  $(function () {
//      pageEvent.init();
//  });
//
//})(window.jQuery, top.app);