var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "PU",
			form: {
				title: "到货单",
				type: "tab",
				width: 750,
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
			doAfterInit: function() {
				//快速上架
				
				$('#app_Ground').click(function() {
					var id = $('#gridtable').appGridValue('Id');
					alert(id)
					var rowData = $('#gridtable').appGridGet('rowdata'); //获得选中行行的所有数据
					if(id == null || id == "") {
						app.MODAL_UTILS.error("请选择一条信息")
						return false;
					}

					//					if(rowdata.status < 2) {
					//						app.MODAL_UTILS.error("单据尚未审核,不允许快速上架");
					//						return false;
					//					} else if(rowdata.status == 4) {
					//						app.MODAL_UTILS.error("单据已经上架,不允许快速上架");
					//						return false;
					//					} else if(rowdata.status == 5) {
					//						app.MODAL_UTILS.error("单据已经完成,不允许快速上架");
					//						return false;
					//					}
					layx.iframe('AddFKInnfo', '快速上架', '../html/FormFK.html?rowData=' + escape(JSON.stringify(rowData)), {
						shadable: true,
						statusBar: true,
						height: 400,
						width: 601,
						buttons: [{
							label: '<i class="fa fa-save" style="margin-right:5px"></i>保存',
							callback: function(id, button, event) {
								// 获取 iframe 页面 window对象
								var contentWindow = layx.getFrameContext(id);
								contentWindow.acceptClick(function(data) {
									if(!!!data.PositionCode) {
										app.MODAL_UTILS.error("请输入货位", "error");
										return;
									}									
									app.HTTP_REQUEST_UTILS.httpAsyncPost('/api/PU/Fastshelf', data,
										function(data) {
											if(data.status) {
												app.MODAL_UTILS.success(data.message)
											} else {
												app.MODAL_UTILS.error(data.message)
											}
										});
								})
								layx.destroy(id);
							},
							classes: ['btn-primary']
						}, {
							label: '<i class="fa fa-close" style="margin-right:5px"></i>取消',
							callback: function(id, button, event) {
								layx.destroy(id);
							},
							classes: ['btn-danger']
						}]
					});

				})
				//确认到货
				$('#app_ArriveGoods').click(function(){
					
		  	var id = $('#gridtable').appGridValue('Id');
		  	alert(id);
		  	alert(app.APP_GLOBE_STORE.LOGIN_USER.FullName);
				if(app.BASE_UTILS.checkrow(id)) {
					app.MODAL_UTILS.confirm({
						msg: "是否确认到货！",
						callback: function() {
							layx.load('loadId', '数据正在加载中，请稍后');
							app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/PU/QuickPU/'+id+'/' +app.APP_GLOBE_STORE.LOGIN_USER.FullName, function(data) {
								layx.destroy('loadId');
								if(data.status) {
									app.MODAL_UTILS.success(data.message);
									refreshGirdData();
								} else {
									app.MODAL_UTILS.error(data.message)
								}
							});
						}
					})

				}
				})
				
				
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
				//url: '/api/'+router+'/GatPagerListByWhere/'+ app.APP_GLOBE_STORE.LOGIN_USER.Id,
				url: '/api/PU/GatPagerListByWhere/' + app.APP_GLOBE_STORE.LOGIN_USER.Id,
				headData: [{
						label: '状态',
						name: 'Status',
						width: 100,
						align: "center",
						formatter: function(cellvalue) {
							if(cellvalue == 2) {
								return '<span class=\"label label-success\" style=\"cursor: pointer;\">已审核</span>';
							} else if(cellvalue == 0) {
								return '<span class=\"label label-default\" style=\"cursor: pointer;\">待审核</span>';
							} else if(cellvalue==4) {
								return '<span class=\"label label-danger\" style=\"cursor: pointer;\">已到货</span>';
							}else if(cellvalue == 5) {
								return '<span class=\"label label-danger\" style=\"cursor: pointer;\">已上架</span>';
							}
						}
					},
					{
						label: '业务类型',
						name: 'Ordertype',
						width: 100,
						align: "center",
						formatter: function(cellvalue) {
							if(cellvalue == 1) {
								return '<span class=\"label label-success\" style=\"cursor: pointer;\">散货</span>';
							} else if(cellvalue == 0) {
								return '<span class=\"label label-danger\" style=\"cursor: pointer;\">整箱</span>';
							}
						}
					},
					{
						label: "单据号",
						name: "OrderNo",
						width: 130,
						align: "center"
					},
					{
						label: "客户",
						name: "CustomerName",
						width: 130,
						align: "center"
					},
					{
						label: "权属",
						name: "Property",
						width: 130,
						align: "center"
					},
					{
						label: '仓库',
						name: 'WarehouseName',
						width: 150,
						align: "center"
					},
					{
						label: '制单人',
						name: 'CMaker',
						width: 100,
						align: "center"
					},
					{
						label: "单据时间",
						name: "Date",
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
						label: '审核人',
						name: 'Verify',
						width: 100,
						align: "center"
					},
					{
						label: '审核时间',
						name: 'VeriDate',
						width: 150,
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
						label: '外部单号',
						name: 'Define1',
						width: 100,
						align: "center"
					},
					{
						label: "备注",
						name: "Description",
						width: 100,
						align: "center"
					},
					{
						label: "完成时间",
						name: "Insertime",
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
				],
			}
		}
	};
	$(function() {
		app.CommonIndexEvent.init(options);
	})
})(window.jQuery, top.app)