var appModuleButtonList;
var appModuleColumnList;
(function($, app) {
	"use strict";
	var classify_itemCode;
	//点击左侧树
	var nodeclick = function(item) {
		classify_itemCode = item.id;
		$('#titleinfo').text(item.text + '(' + classify_itemCode + ')');
		var param = {
			ItemId: item.id
		};
		$("#" + app.CommonIndexParams.grid.id).appGridSet('reload', param);
	}

	var options = {
		params: { //参数
			router: "Dictionary",
			form: {
				id: classify_itemCode,
				title: "数据字典",
				width: 750,
				height: 450
			}
		},
		Event: { //初始化事件
			doBeforeInit: function() {
				$('#app_layout').appLayout();
			},
			doAfterInit: function() {
				//字典分类
				$('#app_category').on('click', function() {
					//layx.iframe('1','分类管理','../../ItemsType/html/index.html');
					layx.iframe("Dictionary", '分类管理', '../../ItemsType/html/index.html', {
						shadable: true,
						height: 600,
						width: 850
						//skin: 'river'				
					});
				});
				$("#app_deletedetail").on('click', function() {
					var postData;
					var Detail = [];
					var postUrl = '/api/Dictionary/'+classify_itemCode;
					var type = "PUT";
					app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Dictionary/' + classify_itemCode, function(data) {
						postData = data;
						Detail = data.detail;
						var key = $('#gridtable').appGridValue(app.CommonIndexParams.grid.keyFiled)
						for(var i = 0; i < postData.detail.length; i++) {
							if(Detail[i].id == key) {
								console.log(Detail[i])
								postData.detail.splice(i, 1);
							}
						}
						console.log(postData.detail)
						console.log(postData)
						layx.load('loadId', '数据正在删除中，请稍后');
						app.HTTP_REQUEST_UTILS.httpAsync(type, postUrl, postData, function(data) {
							layx.destroy('loadId');
							if(data.status) {
								app.MODAL_UTILS.error(data.message)
								window.parent.location.reload()
								window.parent.layx.destroy('Dictionary');
								//$('#gridtable').appGridSet('reload',{});
							} else {

								app.MODAL_UTILS.success(data.message);
								window.parent.location.reload()
								window.parent.layx.destroy('Dictionary');
							}
						});
					});
				});
			}
		},
		search: { //搜索		
			setSearchParams: function() {
				return {
					userid: app.APP_GLOBE_STORE.LOGIN_USER.Id,
					encode: $("#txtCode").val(),
					fullname: $("#txtName").val()
				}
			}
		},
		tree: { //启用左侧树形
			options: {
				id: "app_left_tree",
				//data: moduletreedata,
				url: '/api/Dictionary/GetDictionaryTree',
				nodeClick: nodeclick //,
				//defaultValue: "5" //设置默认值
			}
		},
		bindEvent: { //点击事件参数 
			add: {
				doBeforeEvent: function() {
					if(!!!classify_itemCode) {
						app.MODAL_UTILS.warning("请先选择字典分类!")
						return {
							result: false,
							data: null
						}
					}
					//console.log(classify_itemCode)
					return {
						result: true,
						data: {
							addParams: "?ItemId=" + classify_itemCode
						}
					};
				}
			},
			edit: {
				doBeforeEvent: function() {
					localStorage.setItem('editItemId',classify_itemCode)
					return {
						result: true
					};
					
				}
			}
		},

		grid: { //grid 
			options: {
				//				url: '/api/Dictionary/GetDictionaryItemByPages',
				url: '/api/Dictionary/GetDictionaryItemByPages',
				//rowdatas: itemsdata,
				headData: [{
						label: '项目名',
						name: 'itemname',
						width: 200,
						align: "center"
					},
					{
						label: '项目值',
						name: 'itemcode',
						width: 200,
						align: "center"
					},
//					{
//						label: '简拼',
//						name: 'SimpleSpelling', 
//						width: 150,
//						align: "center"
//					},
//					{
//						label: '排序',
//						name: 'sortcode',
//						width: 80,
//						align: 'center'
//					},
					{
						label: "有效", 
						name: "enabledmark",
						width: 50,
						align: "center",
						formatter: function(cellvalue) {
							return cellvalue == 1 ? "<i class=\"fa fa-toggle-on\"></i>" : "<i class=\"fa fa-toggle-off\"></i>";
						}
					},
					{
						label: "备注",
						name: "description",
						width: 200,
						align: "center"
					}
				],
				parentId: 'ParentId',
			}
		}
	};

	$(function() {
		app.CommonIndexEvent.init(options);
	})
})(window.jQuery, top.app)