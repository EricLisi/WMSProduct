var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var options = {
		params: { //参数
			router: "Inventory",
			form: {
				title: "商品",
				width: 800,
				height: 600
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
				url: '/api/Inventory/GatPagerListByWhere/'+ app.APP_GLOBE_STORE.LOGIN_USER.Id,			
//				rowdatas: [{
//									"Id": "6903ab9d-20cd-44c4-a380-09f229366e1f",
//									"EnCode": "001",
//									"FullName": "鼠标",
//									"InvSKU": "K201",
//									"BarCode": '541|110|112',
//									"Province":'上海市',
//									"ProvinceCode":'00001',
//									"CusCode":'001',
//									"Length":'13',
//									'Width':'15',
//									"Height":'12',
//									"Volumn": '13',
//									"fWeight": '17',
//									"gWeight": '0',
//									"Price":'2',
//									"Type":'1',
//									"Description": '1111111'
//								}, {
//									"Id": "abe9fcf1-1879-41b1-948d-05d514102934",
//									"EnCode": "002",
//									"FullName": "键盘",
//									"InvSKU": "K201",
//									"BarCode": '541|110|112',
//									"Province":'上海市',
//									"ProvinceCode":'00001',
//									"CusCode":'001',
//									"Length":'13',
//									'Width':'15',
//									"Height":'12',
//									"Volumn": '13',
//									"fWeight": '17',
//									"gWeight": '0',
//									"Price":'2',
//									"Type":'1',
//									"Description": '1111111'
//								}],
				headData: [
//				    {
//						label: "主键",
//						name: "F_Id"						
//					},
					{
						label: '物料编码',
						name: 'EnCode',
						width: 130,
						align: 'center'
					},
					{
						label: '物料名称',
						name: 'FullName',
						width: 130,
						align: 'center'
					},
					{
						label: '物料SKU',
						name: 'InvSKU',
						width: 130,
						align: 'center'
					},
					{
						label: '条形码',
						name: 'BarCode',
						width: 120,
						align: 'center'
					},
					{
						label: '客户编码',
						name: 'CusCode',
						width: 120,
						align: 'center'
					},
					{
						label: '长度',
						name: 'Length',
						width: 150,
						align: 'center'
					},
					{
						label: '宽度',
						name: 'Width',
						width: 150,
						align: 'center'
					},
					{
						label: '高度',
						name: 'Height',
						width: 150,
						align: 'center'
					},
					{
						label: '体积',
						name: 'Volumn',
						width: 150,
						align: 'center'
					},
					{
						label: '净重',
						name: 'fWeight',
						width: 150,
						align: 'center'
					},
					{
						label: '毛重',
						name: 'gWeight',
						width: 150,
						align: 'center'
					},
					{
						label: '价格',
						name: 'Price',
						width: 150,
						align: 'center'
					},
					{
						label: '物料分类',
						name: 'Type',
						width: 150,
						align: 'center'
					},
					{
						label: '备注',
						name: 'Description',
						width: 150,
						align: 'center'
					}
				]
			}
		}
	};
	$(function() {
		//alert(app.APP_GLOBE_STORE.LOGIN_USER.Id)		
		app.CommonIndexEvent.init(options);
	})
})(window.jQuery, top.app)