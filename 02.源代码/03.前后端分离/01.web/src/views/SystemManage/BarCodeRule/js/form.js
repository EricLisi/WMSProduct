var router = "BarCodeRule";
var datas = [];
(function($, app) {
	"use strict";
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');

	/**
	 * 页面事件对象
	 */
	var pageEvent = {
		/**
		 *  窗体初始化 
		 **/
		init: function() {
			$("#Id").hide();
			pageEvent.bindEvent();
			pageEvent.InitForm()
		},

		/**
		 * 绑定事件
		 */
		bindEvent: function() {
			// 优化滚动条
			$('.app-layout-wrap').appscroll();
			// 客户选择
			//			$("#CustomerId").appselect({
			//              url:'/api/Customer/GetSelectGrid',
			//              text: 'Text',
			//				value: 'Id',
			//				maxHeight: 180,
			//				allowSearch: true
			//         });
			//			// 仓库
			//			$("#WarehouseId").appselect({
			//				url: '/api/Warehouse/GetSelectGrid/'+app.APP_GLOBE_STORE.LOGIN_USER.Id,
			//				text: 'Text',
			//				value: 'Id',
			//				maxHeight: 180,
			//				allowSearch: true
			//			});
			//			//权属
			//			$('#OwnerId').appselect({
			//				url: '/api/Owner/GetSelectGrid/',
			//				text: 'Text',
			//				value: 'Id',
			//				maxHeight: 180,
			//				allowSearch: true
			//			});
			//			//入库类别
			$('#Type').appselect();
			//			//收发类别
			//			$('#SrTypeId').appselect({
			//				url: '/api/ReceiveType/GetSelectGrid/',
			//				text: 'Text',
			//				value: 'Id',
			//				maxHeight: 180,
			//				allowSearch: true
			//			});

			//选择物料信息
			//			$('#select').on('click', function() {
			////				console.log($("#Type").text())
			//				if($("#Type").text()=="")
			//				{
			//					app.MODAL_UTILS.error("请选择入库类别")
			//					return false;
			//				}
			//				layx.iframe('iconForm', '选择物料信息...', '../html/addForm.html', {
			//					shadable: true,
			//					statusBar: true, 
			//					width: 1050,
			//					height: 450,
			//					buttons: [{
			//							label: '<i class="fa fa-save" style="margin-right:5px"></i>确定',
			//							callback: function(id, button, event) {
			//								// 获取 iframe 页面 window对象
			//								var contentWindow = layx.getFrameContext(id);
			//								contentWindow.acceptClick();
			//								var win = layx.getFrameContext('iconForm', 'group2');
			//								var grid=win.document.querySelector(".pp").innerHTML;
			////								console.log(JSON.parse(grid))
			//								var data=JSON.parse(grid);
			//								if(data.length==0)
			//								{
			//									app.MODAL_UTILS.error("请选择一行数据")
			//									return false;
			//								}
			//								//将选中的数据赋值到下方列表中
			//								for(var i=0;i<data.length;i++)
			//								{
			//									var param = {
			//											"ProductId": data[i].Id,
			//											"ProductCode": data[i].EnCode,
			//											"ProductName": data[i].FullName,
			//											"InvSKU": data[i].InvSKU,
			//											"CustomerCode": data[i].CustomerCode,
			//											"Price": data[i].Price,
			//											"Quantity":1,
			//												};
			//									$("#productgird").appGridSet('addRow',param);
			//								}
			//								if($("#Type").val()==0){
			//									alert(55)
			////									
			////									$("#productgird").initEditCell($('#productgird'), headData, "BoxNo");
			//								}
			//								layx.destroy(id);
			//							},
			//							classes: ['btn-primary']
			//						},
			//						{
			//							label: '<i class="fa fa-close" style="margin-right:5px"></i>取消',
			//							callback: function(id, button, event) {
			//								layx.destroy(id);
			//							},
			//							classes: ['btn-danger']
			//						}
			//					]
			//				});
			//			});

			//选择全部商品，表格加载选中的商品信息
			$('#productgird').appgrid({
				headData: [
					//					{
					//						label: '产品Id',
					//						name: 'ProductId',
					//						width: 100,
					//						align: "center"
					//					},
					{
						label: '对应字段',
						name: 'EnCode',
						width: 100,
						align: "center",
						edit: {
							type: 'input',
						}
					},
					{
						label: '字段名称',
						name: 'FullName',
						width: 100,
						align: 'center',
						edit: {
							type: 'input',
						}
					},
					{
						label: '字段类型',
						name: 'Type',
						width: 100,
						align: 'center',
						edit: {
							type: 'select',
							init: function(data, $edit) { // 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象

							},
							change: function(row, num, item) { // 行数据和行号,下拉框选中数据

							},
							op: { // 下拉框设置参数 和 appselect一致
								data: [{
										'id': '1',
										'text': '文本'
									},
									{
										'id': '2',
										'text': '数字'
									},
									{
										'id': '3',
										'text': '时间'
									}
								]
							}
						}
					},
					{
						label: '长度',
						name: 'Length',
						width: 100,
						align: 'center',
						edit: {
							type: 'input',
						}
					},
					{
						label: '序号',
						name: 'Number',
						width: 100,
						align: 'center',
						edit: {
							type: 'input',
						}
					}
				],
				isEdit: true,
				height: 350,
				isMultiselect: true
			});

			// 保存数据
			//			$('#savaAndAdd').on('click', function() {
			//				acceptClick(0);
			//			});
			$('#save').on('click', function() {
				acceptClick();
			});
		},

		/*初始化表单数据*/
		InitForm: function() {
			$("#Date").val(app.BASE_UTILS.Date.get_yyyy_MM_dd());
			//			if(!!keyValue) {
			////								var data = {
			////									"orderData": {
			////										"EnCode": "11111",
			////										"Id": "27607392-c60c-4ee6-9557-ef59f9410bbb",
			////										"FullName": "22222",
			////										"Type": "符号分隔",
			////										"Separator": "|"
			////									},
			////									"orderProductData": [{
			////										"Id": "6540273d-4a68-4ee0-96bf-96cb5df909f9",
			////										"MainId": "27607392-c60c-4ee6-9557-ef59f9410bbb",
			////										"EnCode":"F_EnCode",
			////										"FullName": "111111",
			////										"Type": "文本",
			////										"Length": "5",
			////										"Number": "1"
			////									}]
			////								};
			//								$(".app-layout-wrap").appSetFormData(data.info)
			//								$('#productgird').appGridSet('refreshdata', data.dInfo);
			//
			//			}
			if(!!keyValue) {
				$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
					$('.app-layout-wrap').appSetFormData(data.info);
					$('#productgird').appGridSet('refreshdata', data.dInfo);
				});
			}
		},

	}

	// 保存数据
	var acceptClick = function() {
		if(!$('.app-layout-wrap').appValidform()) {
			return false;
		}
		var formData = $('.app-layout-wrap').appGetFormData(keyValue);
		var productData = [];
		var productDataTmp = $('.aa').appGridGet('rowdatas');
		//判断数据手否为空
		//		console.log(productDataTmp)
		for(var i = 0; i < productDataTmp.length; i++) {
			if(productDataTmp[i].FullName == "") {
				app.MODAL_UTILS.error("列表中名称不能为空！")
				return false;
			}
			if(productDataTmp[i].Length == "") {
				app.MODAL_UTILS.error("列表中长度不能为空！")
				return false;
			}
			if(productDataTmp[i].Number == "") {
				app.MODAL_UTILS.error("列表中序号不能为空！")
				return false;
			}
			if(productDataTmp[i].Type == "") {
				app.MODAL_UTILS.error("列表中类型不能为空！")
				return false;
			}
		}

		alert(JSON.stringify(productDataTmp))
				var postData = {
					info: formData,
					dInfo: productDataTmp
				};
//				alert(JSON.stringify(postData))
				var postUrl = '/api/' + router;
				var type = "POST";
				if(!!keyValue) {
					postUrl = postUrl + "/" + keyValue;
					type = "PUT"
				}
				$.appSaveForm(type, postUrl, postData, function(data) {
		
				});
//				learun.layerConfirm('注：您确认要保存此操作吗？', function (res, index) {
//				    if (res) {
//				        $.lrSaveForm(top.$.rootUrl + '/LR_CRMModule/CrmOrder/SaveForm?keyValue=' + keyValue, postData, function (res) {
//				            if (res.code == 200) {
//				                if (type == 0) {
//				                    window.location.href = top.$.rootUrl + '/LR_CRMModule/CrmOrder/Form';
//				                }
//				                else {
//				                    learun.frameTab.close('order_add');
//				                }
//				            }
//				        });
//				        top.layer.close(index); //再执行关闭  
//				    }
//				});
	};

	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)