var refreshGirdData;
var acceptClick;
(function($, app) {
	"use strict";

	/**
	 * 页面事件
	 */
	var pageEvent = {
		/**
		 * 初始化事件
		 */
		init: function() {
			pageEvent.initgrid();
			pageEvent.bindEvent();

		},

		/**
		 * 绑定事件
		 */
		bindEvent: function() {
			// 查询
			$('#btn_Search').on('click', function() {
				var keyword = $('#txt_Keyword').val();
				pageEvent.search({
					keyword: keyword
				});
			});

		},

		/**
		 * 初始化表格
		 */
		initgrid: function() {
			$("#gridtable").appgrid({
				url: '', // 数据服务地址
				param: {}, // 请求参数
				rowdatas: [{
					"EnCode": "1111111",
					"CustomerName": "FF"
					
				}, {
					"EnCode": "2222",
					"CustomerName": "水电费"
					
				}], // 列表数据
				headData: [{

						label: '单据号',
						name: 'EnCode',
						width: 260,
						align: "center"

					},
					//					{
					//						label: '客户编码',
					//						name: 'CustomerId',
					//						width: 80,
					//						align: 'center'
					//					},
					{
						label: '客户',
						name: 'CustomerName',
						width: 100,
						align: 'center'
					},
					{
						label: '仓库',
						name: 'WarehouseName',
						width: 100,
						align: 'center'

					},
					{
						label: '制单人',
						name: 'Maker',
						width: 80,
						align: 'center'
					},
					{
						label: '单据时间',
						name: 'Date',
						width: 120,
						align: "center"
					},
					{
						label: '状态',
						name: 'EnabledMark',
						width: 120,
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

						label: '审核人',
						name: 'Verify',
						width: 80,
						align: 'center'
					},

					{
						label: '审核时间',
						name: 'VeriDate',
						width: 120,
						align: "center"
					},

					{
						label: "备注",
						name: "Description",
						width: 200,
						align: "center"
					}
				],
				isPage: true,
				reloadSelected: true,
				mainId: 'Id'

			});
			pageEvent.search();
		},

		search: function(param) {
			param = param || {};
			$('#gridtable').appGridSet('reload', param);
		}
	}
	// 保存数据后回调刷新
	refreshGirdData = function() {
		pageEvent.search();

	};
	// 保存数据
	acceptClick = function(callBack) {
		var ss = $("#gridtable").appGridValue("EnCode");
		$(".pp").html(ss)
	};

	$(function() {
		pageEvent.init();
	});

})(window.jQuery, top.app);