var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "DP",
			form: {
				title: "发货单",
				type: "tab",
				width: 750,
				height: 450,
				doBeforeEdit: function (key) {                   
                     return true;
                }
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
				
				
				
					$('#app_Pack').on('click', function() {//生成拣货单
				layx.iframe('CheckType', '请选择类型', '../../DP/html/SrType.html', {
					shadable: true,
					statusBar: true,
					width: 400,
					height: 200,
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
				url: '/api/DP/GatPagerListByWhere/'+ app.APP_GLOBE_STORE.LOGIN_USER.Id,				
				headData: [{
						label: '状态',
						name: 'Status',
						width: 100,
						align: "center",
						formatter: function(cellvalue) {
							if(cellvalue == 1) {
								return '<span class=\"label label-success\" style=\"cursor: pointer;\">已审核</span>';
							} else if(cellvalue == 0) {
								return '<span class=\"label label-default\" style=\"cursor: pointer;\">待审核</span>';
							} else if(cellvalue == 2) {
								return '<span class=\"label label-danger\" style=\"cursor: pointer;\">已关闭</span>';
							}
						}
					},
					{
						label: '发运方式',
						name: 'sendType',
						width: 100,
						align: "center",
						formatter: function(cellvalue) {
							if(cellvalue == 1) {
								return '<span class=\"label label-danger\" style=\"cursor: pointer;\">货运</span>';
							} else if(cellvalue == 0) {
								return '<span class=\"label label-success\" style=\"cursor: pointer;\">快递</span>';
							}
						}
					},
					{
						label: "单据号",
						name: "OrderNo",
						width: 130,
						align: "center"
					}, {
						label: "拣货单号",
						name: "Define6",
						width: 130,
						align: "center"
					},
					{
						label: "客户代码",
						name: "CustomerId",
						width: 130,
						align: "center"
					},
					{
						label: "客户名称",
						name: "CustomerName",
						width: 130,
						align: "center"
					},
					{
						label: "仓库代码",
						name: "WarehouseId",
						width: 130,
						align: "center"
					},
					{
						label: '仓库名称',
						name: 'WarehouseName',
						width: 150,
						align: "center"
					},
					{
						label: '件数',
						name: 'Qty',
						width: 100,
						align: 'center'
					},
					{
						label: '快递公司',
						name: 'expCompany',
						width: 200,
						align: 'left'
					},
					{
						label: '快递单号',
						name: 'expNo',
						width: 120,
						align: 'center'
					},
					{
						label: '收件人',
						name: 'sendPerson',
						width: 120,
						align: 'center'
					},
					{
						label: '发货地址',
						name: 'sendAddress',
						width: 200,
						align: 'center'
					},
					{
						label: '制单人',
						name: 'Maker',
						width: 100,
						align: "center"
					},
					{
						label: '单据日期',
						name: 'Date',
						width: 100,
						align: 'center',
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
					}
				],
			}
		}
	};
	$(function() {
		app.CommonIndexEvent.init(options);
	})
})(window.jQuery, top.app)