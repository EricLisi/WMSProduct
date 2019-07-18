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
				url: '/api/Inventory/GatPagerListByWhere/'+ app.APP_GLOBE_STORE.LOGIN_USER.Id,	
				param: {}, // 请求参数
//				rowdatas: [{
//					"Id":'123456',
//					"EnCode": "1111111",
//					"FullName": "FF",
//					"InvSKU":'111',
//					"CusCode":'001',
//					"Price":'10'
//				}, {
//					"Id":'789454',
//					"EnCode": "222222",
//					"FullName": "CC",
//					"InvSKU":'222',
//					"CusCode":'002',
//					"Price":'30'
//				}], // 列表数据
				headData: [
				{
						label: '物料编码',
						name: 'EnCode',
						width: 120,
						align: "center"

				},				
					{
						label: '物料名称',
						name: 'FullName',
						width: 150,
						align: 'center'
					},
					{
						label: 'sku',
						name: 'InvSKU',
						width: 100,
						align: 'center'

					},
					{
						label: '客户编码',
						name: 'CustomerCode',
						width: 100,
						align: 'center'
					},
					{
						label: '单价',
						name: 'Price',
						width: 80,
						align: 'center'
					}
				],
				isPage: true,
				reloadSelected: true,
				mainId: 'Id',
				isMultiselect: true

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
		var ss = $("#gridtable").appGridGet("rowdata");
//		alert(JSON.stringify(ss))
		$(".pp").html(JSON.stringify(ss))
	};

	$(function() {
		pageEvent.init();
	});

})(window.jQuery, top.app);