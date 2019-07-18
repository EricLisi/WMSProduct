var router = "Role";
(function($, app) {
	"use strict";
	var parentId = "0";
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	var selectData;
	var checkModuleIds = [];
	/**
	 * 页面事件
	 */
	var pageEvent = {
		/**
		 * 初始化事件
		 */
		init: function() {
			pageEvent.bindEvent();
			//pageEvent.initGrid();
			pageEvent.initForm();
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
				        $finish.removeAttr('disabled');
						if(!$('#step-1').appValidform()) {				
							return false;
						}
					}  else {
						$finish.removeAttr('disabled');
						$next.attr('disabled', 'disabled');
					}
				} else {
					$finish.attr('disabled', 'disabled');
					$next.removeAttr('disabled');
				}
			});
			// 保存数据按钮
			$("#btn_finish").on('click', pageEvent.save);
		},
		/*初始化表格*/
		initGrid: function() {
			$('#module_girdtable').appgrid({
				headData: [{
						label: "名称",
						name: "modulefullname",
						width: 260,
						align: "left",
						edit: {
							type: 'input'
						}
					},
					{
						label: "编号",
						name: "moduleencode",
						width: 260,
						align: "left",
						edit: {
							type: 'input'
						}
					}
				],
				isTree: true,
				parentId: 'parentid', 
				mainId: 'id',
				isMultiselect: true,
				isEdit: true,
				onAddRow: function(row, rows) {
					row.Id = app.BASE_UTILS.newGuid();
				}
			});
			$('#btns_girdtable').appgrid({
				headData: [{
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
		},
		/*初始化数据*/
		initForm: function(options) {
			var _treeElemet = $("#module_girdtable");
			var _keyValue=!!!keyValue?"0":keyValue;
		     _treeElemet.apptree({
		 	  url: "/api/Module/GetModuleBtnTree?Id="+_keyValue
			 });
			if(!!keyValue) {
				$.appSetForm('/api/Role/' + keyValue, function(data) { //  
					$('#step-1').appSetFormData(data);
					$('#module_girdtable').appGridSet('refreshdata', data.modules);
					$('#btns_girdtable').appGridSet('refreshdata', data.buttons);
					$('#col_girdtable').appGridSet('refreshdata', data.columns);
				});

			}

		},
		/*保存数据*/
		save: function() {				
			if(!$('#step-1').appValidform()) {
				return false;
			}
			var postData = $('#step-1').appGetFormData(keyValue); //得到提交数据源
			if(!!!keyValue) {
				postData.id = app.BASE_UTILS.newGuid()
			}
			//获取所有选择节点的Id	
		    var items=$("#module_girdtable").apptreeSet('getCheckNodes')
		    var parent="";//一级节点
			var module=[];
			var button=[];
			var _module=[];
			var _button=[];
			for(var i=0;i<items.length;i++)
			{		
				if(items[i].parentId=="0")
				{
					parent=items[i].id;
					module.push(items[i]);
				}
				else
				{		
				  if(items[i].parentId==parent)
				  {
					module.push(items[i]);
				  }
				  else
				  {				  	
				  	button.push(items[i]);
				  }
				}			
			}

			$.each(module, function(_index, _item) {
					var point = {
						id: app.BASE_UTILS.newGuid(),
						roleid:keyValue,
						moduleid: _item.id
					};
					_module.push(point);
			});
			$.each(button, function(_index, _item) {
					var point = {
						id: app.BASE_UTILS.newGuid(),
						roleid:keyValue,
						mobulebuttonid: _item.id
					};
					_button.push(point);
			});
		
			postData.buttons = _button;
			postData.modules = _module;
			var postUrl = '/api/' + router;
			var type = "POST";
			if(!!keyValue) {
				postUrl = postUrl + "/" + keyValue;
				type = "PUT"
			}
			layx.load('loadId', '数据正在保存中，请稍后');
			app.HTTP_REQUEST_UTILS.httpAsync(type, postUrl, postData, function(data) {
				layx.destroy('loadId');
				if(data.status) {
					app.MODAL_UTILS.error(data.message)
					window.parent.location.reload()
					window.parent.layx.destroy('Role');
				} else {
					app.MODAL_UTILS.success(data.message);
					window.parent.location.reload()
					window.parent.layx.destroy('Role');
				}
			});
		}
	}
	$(function() {
		pageEvent.init();
	});

})(window.jQuery, top.app);