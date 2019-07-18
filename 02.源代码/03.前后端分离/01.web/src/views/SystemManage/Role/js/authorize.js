var router = "Role";
(function($, app) {
	"use strict";
	var parentId = "0";
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	var selectData;
	var checkModuleIds = [];
//	function setTreeData1() {
//		if(!!selectData) {
//			$('#step-1').apptreeSet('setCheck', selectData.modules);
//		} else {
//			setTimeout(setTreeData1, 100);
//		}
//	}
//
//	function setTreeData2() {
//		if(!!selectData) {
//			$('#step-2').apptreeSet('setCheck', selectData.buttons);
//		} else {
//			setTimeout(setTreeData2, 100);
//		}
//	}
//
//	function setTreeData3() {
//		if(!!selectData) {
//			$('#step-3').apptreeSet('setCheck', selectData.columns);
//		} else {
//			setTimeout(setTreeData3, 100);
//		}
//	}

//	function setTreeData4() {
//		if(!!selectData) {
//			$('#step-4').apptreeSet('setCheck', selectData.forms);
//		} else {
//			setTimeout(setTreeData4, 100);
//		}
//	}

	/**
	 * 页面事件
	 */
	var pageEvent = {
		/**
		 * 初始化事件
		 */
		init: function() {
			alert('init')
			pageEvent.bindEvent();
			alert(1)
			pageEvent.initGrid();
			alert(2)
			pageEvent.initForm();
			alert(3)
		},
		/**
		 * 绑定事件
		 */
		bindEvent: function() {
			// 加载导向
			$('#wizard').wizard().on('change', function(e, data) {
				var $finish = $("#btn_finish");
				var $next = $("#btn_next");
				if(data.direction == "next") {
					if(data.step == 1) {
						if(!$('#step-1').appValidform()) {
							return false;
						}
					} else if(data.step == 3) {
						$finish.removeAttr('disabled');
						$next.attr('disabled', 'disabled');
					} else {
						$finish.attr('disabled', 'disabled');
					}
				} else {
					$finish.attr('disabled', 'disabled');
					$next.removeAttr('disabled');
				}
			});
			// 目标
			$('#target').appselect().on('change', function() {
				// 目标改变
				var value = $(this).appselectGet();
				var $next = $("#btn_next");
				var $finish = $("#btn_finish");
				if(value == 'expand') {
					$next.attr('disabled', 'disabled');
					$finish.removeAttr('disabled');
				} else {
					$next.removeAttr('disabled');
					$finish.attr('disabled', 'disabled');
				}
			});
			// 保存数据按钮
			$("#btn_finish").on('click', pageEvent.save);
		},
//		bindEvent: function() {			
//			//app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Module/'+app.APP_GLOBE_STORE.LOGIN_USER.Id, function(data) {	
//			app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Role/'+objectId, function(data) {	
//				console.log(data)
//				setTimeout(function() {
//					$('#step-1').apptree({
//						data: data.modules
//					});
//					if(!!objectId) {
//						setTreeData1();
//					}
//				}, 10);
//				setTimeout(function() {
//					$('#step-2').apptree({
//						data: JSON.parse(data.buttons)
//					});
//					if(!!objectId) {
//						setTreeData2();
//					}
//				}, 50);
//				setTimeout(function() {
//					$('#step-3').apptree({
//						data: JSON.parse(data.columns)
//					});
//					if(!!objectId) {
//						setTreeData3();
//					}
//				}, 90);
////				setTimeout(function() {
////					$('#step-4').apptree({
////						data: JSON.parse(data.formList)
////					});
////					if(!!objectId) {
////						setTreeData4();
////					}
////				}, 200);
//			
//			});
//			// 加载导向
//			$('#wizard').wizard().on('change', function(e, data) {
//				var $finish = $("#btn_finish");
//				var $next = $("#btn_next");
//				if(data.direction == "next") {
//					if(data.step == 1) {
//						checkModuleIds = $('#step-1').apptreeSet('getCheckNodeIds');
//						$('#step-2 .app-tree-root [id$="_learun_moduleId"]').parent().hide();
//						$('#step-3 .app-tree-root [id$="_learun_moduleId"]').parent().hide();
////						$('#step-4 .app-tree-root [id$="_learun_moduleId"]').parent().hide();
//						$.each(checkModuleIds, function(id, item) {
//							$('#step-2_' + item.replace(/-/g, '_') + '_learun_moduleId').parent().show();
//							$('#step-3_' + item.replace(/-/g, '_') + '_learun_moduleId').parent().show();
////							$('#step-4_' + item.replace(/-/g, '_') + '_learun_moduleId').parent().show();
//						});
//					} else if(data.step == 2) {
//						$finish.removeAttr('disabled');
//						$next.attr('disabled', 'disabled');
//					}
////					else {
////						$finish.attr('disabled', 'disabled');
////					}
//				} else {
//					$finish.attr('disabled', 'disabled');
//					$next.removeAttr('disabled');
//				}
//			});
//			// 保存数据按钮
//			$("#btn_finish").on('click', pageEvent.save);
//		},
		/*初始化表格*/
		initGrid: function() {
			$('#btns_girdtable').appgrid({
				headData: [

					{
						label: "名称",
						name: "fullname",
						width: 200,
						align: "left",
						edit: {
							type: 'input'
						}
					},
					{
						label: "编号",
						name: "encode",
						width: 160,
						align: "left",
						edit: {
							type: 'input'
						}
					},
					{
						label: "上级按钮",
						name: "parentid",
						width: 160,
						align: "left",
						formatter: function(value, row, op, $cell) {
							if(value == '0' || value == '') {
								row.parentid = '';
								return '';
							}
							var res = '';
							$.each(op.rowdatas, function(_index, _item) {
								if(value == _item.id) {
									res = _item.fullname;
									return false;
								}
							});
							return res;
						},
						edit: {
							type: 'select',
							init: function(row, $self) { // 选中单元格后执行
								// 获取当前列表数据
								var rowdatas = $('#btns_girdtable').appGridGet('rowdatas');
								var res = [];
								$.each(rowdatas, function(_index, _item) {
									if(row.id != _item.id) {
										res.push(_item);
									}
								});

								$self.appselectRefresh({
									data: res
								});
							},
							op: {
								value: 'id',
								text: 'fullname',
								title: 'fullname'
							},
							change: function(rowData, rowIndex, item) {
								setTimeout(function() {
									$('#btns_girdtable').appGridSet('refreshdata');
								}, 300);
							}
						}
					},
					{
						label: "",
						name: "btn1",
						width: 52,
						align: "center",
						formatter: function(value, row, op, $cell) {
							$cell.on('click', function() {
								var rowindex = parseInt($cell.attr('rowindex'));
								var res = $('#btns_girdtable').appGridSet('moveUp', rowindex);
								return false;
							});
							return '<span class=\"label label-info\" style=\"cursor: pointer;\">上移</span>';
						}
					},
					{
						label: "",
						name: "btn2",
						width: 52,
						align: "center",
						formatter: function(value, row, op, $cell) {
							$cell.on('click', function() {
								var rowindex = parseInt($cell.attr('rowindex'));
								var res = $('#btns_girdtable').appGridSet('moveDown', rowindex);
								return false;
							});
							return '<span class=\"label label-success\" style=\"cursor: pointer;\">下移</span>';
						}
					},
				],
				isTree: true,
				mainId: 'id',
				parentId: 'parentid',
				isMultiselect: true,
				isEdit: true,
				onAddRow: function(row, rows) {
					row.id = app.BASE_UTILS.newGuid();
					row.parentid = '';
				}
			});
			$('#col_girdtable').appgrid({
				headData: [{
						label: "名称",
						name: "fullname",
						width: 260,
						align: "left",
						edit: {
							type: 'input'
						}
					},
					{
						label: "编号",
						name: "encode",
						width: 260,
						align: "left",
						edit: {
							type: 'input'
						}
					},
					{
						label: "",
						name: "btn1",
						width: 52,
						align: "center",
						formatter: function(value, row, op, $cell) {
							$cell.on('click', function() {
								var rowindex = parseInt($cell.attr('rowindex'));
								var res = $('#view_girdtable').appGridSet('moveUp', rowindex);
								return false;
							});
							return '<span class=\"label label-info\" style=\"cursor: pointer;\">上移</span>';
						}
					},
					{
						label: "",
						name: "btn2",
						width: 52,
						align: "center",
						formatter: function(value, row, op, $cell) {
							$cell.on('click', function() {
								var rowindex = parseInt($cell.attr('rowindex'));
								var res = $('#view_girdtable').appGridSet('moveDown', rowindex);
								return false;
							});
							return '<span class=\"label label-success\" style=\"cursor: pointer;\">下移</span>';
						}
					}
				],			
				mainId: 'id',
				isMultiselect: true,
				isEdit: true,
				onAddRow: function(row, rows) {
					row.id = app.BASE_UTILS.newGuid();
					row.parentid = '0';
				}
			});
			$('#module_girdtable').appgrid({
				headData: [{
						label: "名称",
						name: "fullname",
						width: 260,
						align: "left",
						edit: {
							type: 'input'
						}
					},
					{
						label: "编号",
						name: "encode",
						width: 260,
						align: "left",
						edit: {
							type: 'input'
						}
					},
					{
						label: "",
						name: "btn1",
						width: 52,
						align: "center",
						formatter: function(value, row, op, $cell) {
							$cell.on('click', function() {
								var rowindex = parseInt($cell.attr('rowindex'));
								var res = $('#form_girdtable').appGridSet('moveUp', rowindex);
								return false;
							});
							return '<span class=\"label label-info\" style=\"cursor: pointer;\">上移</span>';
						}
					},
					{
						label: "",
						name: "btn2",
						width: 52,
						align: "center",
						formatter: function(value, row, op, $cell) {
							$cell.on('click', function() {
								var rowindex = parseInt($cell.attr('rowindex'));
								var res = $('#form_girdtable').appGridSet('moveDown', rowindex);
								return false;
							});
							return '<span class=\"label label-success\" style=\"cursor: pointer;\">下移</span>';
						}
					}
				],
				mainId: 'Id',
				isMultiselect: true,
				isEdit: true,
				onAddRow: function(row, rows) {
					row.Id = app.BASE_UTILS.newGuid();
				}
			});
		},
		/*初始化数据*/
		initForm: function() {
			alert(keyValue)
			if(!!keyValue) {
				$.appSetForm('/api/Role/' + keyValue, function(data) { //  
					$('#step-1').appSetFormData(data);
					$('#module_girdtable').appGridSet('refreshdata', data.modules);
					$('#btns_girdtable').appGridSet('refreshdata', data.buttons);
					$('#col_girdtable').appGridSet('refreshdata', data.columns);
				});

			} else if(!!moduleId) {
				$('#ParentId').appselectSet(moduleId);
			}
		},
		/*初始化数据*/
//		initData: function() {
//			if(!!objectId) {
//              $.appSetForm('/api/Role/GetPerById/' + objectId, function(data) {
//					selectData = data;
//				});		
//			}
//		},
		/*保存数据*/
		save: function() {
			if(!$('#step-1').appValidform()) {
				return false;
			}
			var postData = $('#step-1').appGetFormData(keyValue);//得到提交数据源
			if(!!!keyValue){
				postData.id = app.BASE_UTILS.newGuid()
			}
			///btn 按钮/col 列
			var _btns = $('#btns_girdtable').appGridGet('rowdatas'); 
			var _cols = $('#col_girdtable').appGridGet('rowdatas');
		    var _module = $('#module_girdtable').appGridGet('rowdatas');
	        var btns = [];
	        var cols = [];
	        var module=[];
	        					$.each(_module, function(_index, _item) {
								if(_item.encode && _item.fullname) {
									var point = {
										Id: _item.id,
										EnCode: _item.encode,
										FullName: _item.fullname,
										SortCode: _index
									};
									fields.push(point);
								}
							});
	       $.each(_cols, function(_index, _item) {
				if(_item.encode && _item.fullname) {
					var point = {
					Id: _item.id,
					ParentId: '0',
					EnCode: _item.encode,
					FullName: _item.fullname,
					SortCode: _index
				 };
					cols.push(point);
				}
			   });
			$.each(_btns, function(_index, _item) {
			if(_item.encode && _item.fullname) {			
			var point = {
										Id: _item.id,
										ParentId: _item.parentid || '0',
										EnCode: _item.encode,
										FullName: _item.fullname,
										SortCode: _index
					   };
									btns.push(point);
								}
							});
			postData.buttons = btns ;
			postData.columns = cols;
			postData.modules = module;
			var postUrl = '/api/' + router;
			var type = "POST";
			if(!!keyValue) {
				postUrl = postUrl + "/" + keyValue;
				type = "PUT"
			}
			layx.load('loadId', '数据正在保存中，请稍后');
			alert(JSON.stringify(postData));
			app.HTTP_REQUEST_UTILS.httpAsync(type, postUrl, postData, function(data) {
				layx.destroy('loadId');
				if(data.status) {
					app.MODAL_UTILS.error(data.message)
					window.parent.location.reload()
					window.parent.layx.destroy('Module');
					//$('#gridtable').appGridSet('reload',{});
				} else {
					
					app.MODAL_UTILS.success(data.message);
					window.parent.location.reload()
					window.parent.layx.destroy('Module');
				}
			});
		}
//		save: function() {
//			var buttonList = [],
//				columnList = [];
////				formList = [];
//			var checkButtonIds = $('#step-2').apptreeSet('getCheckNodeIds');
//			var checkColumnIds = $('#step-3').apptreeSet('getCheckNodeIds');
////			var checkFormIds = $('#step-4').apptreeSet('getCheckNodeIds');
//
//			$.each(checkButtonIds, function(id, item) {
//				if(item.indexOf('_learun_moduleId') == -1) {
//					buttonList.push(item);
//				}
//			});
//			$.each(checkColumnIds, function(id, item) {
//				if(item.indexOf('_learun_moduleId') == -1) {
//					columnList.push(item);
//				}
//			});
////			$.each(checkFormIds, function(id, item) {
////				if(item.indexOf('_learun_moduleId') == -1) {
////					formList.push(item);
////				}
////			});
//
//			var postData = {
//				strModuleId: String(checkModuleIds),
//				strModuleButtonId: String(buttonList),
//				strModuleColumnId: String(columnList)
////				strModuleFormId: String(formList)
//			};
//			//alert(JSON.stringify(postData))
//			$.appSaveForm('PUT', '/api/Role/InsUpPre/' + objectId, postData, function(data) {
//			    
//			});
//		}
	}

	$(function() {
		alert(8)
		pageEvent.init();
	});

})(window.jQuery, top.app);