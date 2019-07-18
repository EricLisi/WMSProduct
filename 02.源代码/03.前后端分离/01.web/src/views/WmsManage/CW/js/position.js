
var acceptClick;
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
				url: '/api/Position/GatPagerListByWhere/' + app.APP_GLOBE_STORE.LOGIN_USER.Id,
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
						name: "Property",
						width: 80,
						align: "center",
						formatter: function(cellvalue) {
							if(cellvalue == 0) {
								return "正常品区域"
							} else if(cellvalue == 1) {
								return "待定品区域"
							} else if(cellvalue == 2) {
								return "坏品区域"
							}
						}
					},
					{
						label: "货位类型",
						name: "F_Type",
						width: 80,
						align: "center",
						formatter: function(cellvalue) {
							if(cellvalue == 0) {
								return "整货区域"
							} else if(cellvalue == 1) {
								return "散货区域"
							}
						}
					},
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
				isMultiselect: true,
				isTree: false,
				mainId: 'Id',
//				parentId: 'ParentId',
			}
		}
	};
    // 保存数据
    acceptClick = function(callBack) {
		var s = $("#gridtable").appGridGet('rowdata');		
		//alert(JSON.stringify(s))
		callBack(s);		
		return true;
	};
	$(function() {
		//alert(app.APP_GLOBE_STORE.LOGIN_USER.Id)		
		app.CommonIndexEvent.init(options);
	})
})(window.jQuery, top.app)