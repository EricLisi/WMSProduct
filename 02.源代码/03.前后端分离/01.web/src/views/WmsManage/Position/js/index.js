var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "Position",
			form: {
				title: "货位",
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
					//appModule = data.module;					
				});
			},
//			doAfterInit: function() {
//				//批量添加货位
//				$('#app-addsPosition').on('click', function() {
//					layx.iframe('1', '批量添加货位', '../html/form1.html', {
//						statusBar: true,
//						buttons: [{
//								label: '保存',
//								callback: function(id, button, event) {
//									// 获取 iframe 页面 window对象
//									var contentWindow = layx.getFrameContext(id);
//									contentWindow.acceptClick1(refreshGirdData);
//									layx.destroy(id);
//								},
//								style: 'border-color: #4898d5;background-color: #2e8ded;color: #fff;'
//							},
//							{
//								label: '取消',
//								callback: function(id, button, event) {
//									layx.destroy(id);
//								}
//							}
//						]
//					});
//				});
//				// 启用货位
//				$('#app_ableCaroGoMark').on('click', function() {
//					var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
//					if(app.BASE_UTILS.checkrow(keyValue)) {
//						app.MODAL_UTILS.confirm({
//							msg: "是否确认要【启用】货位！",
//							callback: function() {
//								var param = {
//									status: true
//								};
//								layx.load('loadId', '数据正在启用中，请稍后');
//								app.HTTP_REQUEST_UTILS.httpAsyncPut(keyValue, '/api' + app.CommonIndexParams.router + '/UpByState', param, function(data) {
//									layx.destroy('loadId');
//									if(data.status) {
//										app.MODAL_UTILS.success(data.message);
//										refreshGirdData();
//									} else {
//										app.MODAL_UTILS.error(data.message)
//									}
//								});
//							}
//						})
//					}
//				});
//				// 禁用货位
//				$('#app_unableCaroGoMark').on('click', function() {
//					var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
//					if(app.BASE_UTILS.checkrow(keyValue)) {
//						app.MODAL_UTILS.confirm({
//							msg: "是否确认要【禁用】货位！",
//							callback: function() {
//								var param = {
//									status: false
//								};
//								layx.load('loadId', '数据正在禁用中，请稍后');
//								app.HTTP_REQUEST_UTILS.httpAsyncPut(keyValue, '/api' + app.CommonIndexParams.router + '/UpByState', param, function(data) {
//									layx.destroy('loadId');
//									if(data.status) {
//										app.MODAL_UTILS.success(data.message);
//										refreshGirdData();
//									} else {
//										app.MODAL_UTILS.error(data.message)
//									}
//								});
//							}
//						})
//					}
//				});
//			}
//		
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
				url: '/api/Position/GatPagerListByWhere/' + app.APP_GLOBE_STORE.LOGIN_USER.Id,
//			rowdatas: [{
//									"Id": "6903ab9d-20cd-44c4-a380-09f229366e1f",
//									"EnCode": "001",
//									"FullName": "MM",
//									"WhCode":'001',
//									"PosType":'1',
//									'Description': '2222222222'
//								}, {
//									"Id": "abe9fcf1-1879-41b1-948d-05d514102934",
//									"EnCode": "002",
//									"FullName": "QQ",
//									"WhCode":'002',
//									"PosType":'0',
//									'Description': '55555555'
//								}],
				headData: [					
//					{
//						label: '主键',
//						name: 'Id',
//						width: 100,
//						align: "center"
//					},
					
					{
						label: '货位名称',
						name: 'FullName',
						width: 100,
						align: "center"
					},
					{
						label: '货位编码',
						name: 'EnCode',
						width: 100,
						align: "center"
					},
					{
						label: '所属仓库',
						name: 'WarehouseName',
						width: 100,
						align: 'center'
					},
					{
						label: "货位属性",
						name: "PosType",
						width: 80,
						align: "center",
						formatter: function(cellvalue) {
							if(cellvalue == 0) {
								return "正常品"
							} else if(cellvalue == 1) {
								return "待处理"
							} else if(cellvalue == 2) {
								return "坏品区"
							}
						}
					},
//					{
//						label: "货位类型",
//						name: "PosType",
//						width: 80,
//						align: "center",
//						formatter: function(cellvalue) {
//							if(cellvalue == 0) {
//								return "整货区域"
//							} else if(cellvalue == 1) {
//								return "散货区域"
//							}
//						}
//					},
//					{
//						label: "货位状态",
//						name: "PositionManagement",
//						width: 120,
//						align: "center",
//						formatter: function(cellvalue) {
//							return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
//						}
//					},
					{
						label: "备注",
						name: "Description",
						index: "Description",
						width: 300,
						align: "center"
					}
				],
				isTree: false,
				mainId: 'Id',
//				parentId: 'ParentId',
			}
		}
	};
	
	$(function() {
		//alert(app.APP_GLOBE_STORE.LOGIN_USER.Id)		
		app.CommonIndexEvent.init(options);
	})
})(window.jQuery, top.app)