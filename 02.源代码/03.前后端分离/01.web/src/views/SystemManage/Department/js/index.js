
(function($, app) {
	"use strict";
	var companyId = '';
//	//点击左侧树
//	var nodeclick = function(item) {
//		companyId = item.id;
//		$('#titleinfo').text(item.text);
//		var param={
//	        userid: app.APP_GLOBE_STORE.LOGIN_USER.Id,
//			companyId:item.id
//		};
//		$("#" + app.CommonIndexParams.grid.id).appGridSet('reload',param);
//	}

	var options = {
		params: { //参数
			router: "Company",
			form: {
				id: "Company",
				title: "公司",
				width: 900,
				height: 550
			}
		},
		Event: { //初始化事件
			doBeforeInit: function() {
				$('#app_layout').appLayout();
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
//			options: {
//				id: "companyTree",
//				//data: moduletreedata,
//			    url: '/api/Company/GetTreeJson',
//				nodeClick: nodeclick//,
//				//defaultValue: "5" //设置默认值
//				
////				id: "companyTree",
////				//url:"/api/Company/GetTreeJson",
////				//data: userdata,
////				data:app.APP_GLOBE_STORE.DATA_STATUS['COMPANY'],
////				nodeClick: nodeclick
////				//defaultValue: "53298b7a-404c-4337-aa7f-80b2a4ca6681"//设置默认值
//			}
		},
		bindEvent: { //点击事件参数 
			add: {
//				doBeforeEvent: function() {
//					if(!!!companyId) {
//						app.MODAL_UTILS.warning("请先选择公司!")
//						return {
//							result: false,
//							data: null
//						}
//					}
//					return {
//						result: true,
//						data: {
//							addParams: "?CompanyId=" + companyId
//						}
//					};
//				}
			}

		},

		grid: { //grid 
			options: {
				url: '/api/Company/GetByPagesAsync',
			 param: {
					userid: app.APP_GLOBE_STORE.LOGIN_USER.id
				},
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
				]
                
			}
		}
	};
	$(function() {
		app.CommonIndexEvent.init(options);
	})
})(window.jQuery, top.app)