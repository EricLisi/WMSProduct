var appModuleButtonList;
var appModuleColumnList;
var acceptClick;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "Consignee",
			form: {
				title: "收货人",
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
					//					appModule = data.module;					
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
				url: '/api/Consignee/GatPagerListByWhere/' + app.APP_GLOBE_STORE.LOGIN_USER.Id,				
				headData: [
//				    {
//						label: "主键",
//						name: "Id",	
//						width: 100,
//						align: 'center'
//					},
					{
						label: '收货人代码',
						name: 'EnCode',
						width: 100,
						align: 'center'
					},
					{
						label: '收货人简称',
						name: 'ShortName',
						width: 100,
						align: 'center'
					},
					{
						label: '收货人全称',
						name: 'FullName',
						width: 100,
						align: 'center'
					},
					{
						label: '联系人',
						name: 'Person',
						width: 100,
						align: 'center'
					},
					{
						label: '电话',
						name: 'Phone',
						width: 100,
						align: 'center'
					},
					
					{
						label: '收货人省份',
						name: 'ProvinceCode',
						width: 100,
						align: 'center',
						formatter: function(cellvalue, rowObject) {						
							var data = app.APP_GLOBE_STORE_UTILS.getKeyValue('PROVINCE', {
								key: "Id",
								value: cellvalue
							})
							return !!data ? data.FullName: cellvalue
						}
					},					
					{
						label: '收货人城市',
						name: 'CityCode',
						width: 100,
						align: 'center',
						formatter: function(cellvalue, rowObject) {
							var data = app.APP_GLOBE_STORE_UTILS.getKeyValue('CITY', {
								key: "Id",
								value: cellvalue
							})
							return !!data ? data.FullName : cellvalue
						}
					},					
//					{
//						label: '收货人城市id',
//						name: 'CityCode',
//						width: 100,
//						align: 'center',
//						hidden: true
//					},
//                  {
//						label: '收货人城市',
//						name: 'City',
//						width: 100,
//						align: 'center',
//						hidden: true
//					},
//					{
//						label: '收货人省份',
//						name: 'Province',
//						width: 100,
//						align: 'center'
//					},
//					{
//						label: '收货人省份id',
//						name: 'ProvinceCode',
//						width: 100,
//						align: 'center'
//					},
					
					
					
					{
						label: '收货人地址',
						name: 'Address',
						width: 100,
						align: 'center'
					},
					{
						label: '备注1',
						name: 'Description',
						width: 150,
						align: 'center'
					},
					{
						label: '备注2',
						name: 'Description1',
						width: 150,
						align: 'center'
					}
				],
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