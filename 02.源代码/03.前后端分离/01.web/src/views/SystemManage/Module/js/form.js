var router = "Module";
(function($, app) {
	//alert(JSON.stringify(app))
	"use strict";
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	var moduleId = app.URL_REQUEST_UTILS.get(window.location, 'ModuleId');
	/**
	 * 页面事件对象
	 */
	var pageEvent = {
		/**
		 *  窗体初始化 
		 **/
		init: function() {
			$(".layx-statu-bar").css('display','none')
			pageEvent.bindEvent();
			pageEvent.initGrid();
			pageEvent.initForm()
		},
		/*绑定事件和初始化控件*/
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
			// 上级
			$('#parentid').appselect({
				url: '/api/Module/GetModuleTree',
				type: 'tree',
				maxHeight: 180,
				allowSearch: true
			});
			// 选择图标
			$('#selectIcon').on('click', function() {
				layx.iframe('iconForm', '选择图标', '../../../Utility/icon.html', {
					shadable: true,
					statusBar: true,
					width: 1050,
					height: 450,
					buttons: [{
							label: '<i class="fa fa-save" style="margin-right:5px"></i>保存',
							callback: function(id, button, event) {
								var win = layx.getFrameContext('iconForm', 'group2');
								$("#Icon").val(win.document.querySelector("p").innerHTML);
								layx.destroy(id);
							},
							classes: ['btn-primary']
						},
						{
							label: '<i class="fa fa-close" style="margin-right:5px"></i>取消',
							callback: function(id, button, event) {
								layx.destroy(id);
							},
							classes: ['btn-danger']
						}
					]
				});
			});

			// 保存数据按钮
			$("#btn_finish").on('click', pageEvent.save);
		},

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
			$('#view_girdtable').appgrid({
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
			$('#form_girdtable').appgrid({
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
			if(!!keyValue) {
				$.appSetForm('/api/Module/' + keyValue, function(data) { //  
					$('#step-1').appSetFormData(data);
		
					$('#btns_girdtable').appGridSet('refreshdata', data.buttons);
					$('#view_girdtable').appGridSet('refreshdata', data.columns);
					$('#form_girdtable').appGridSet('refreshdata', data.forms);
				});

			} else if(!!moduleId) {
				$('#ParentId').appselectSet(moduleId);
			}
		},

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
			var _cols = $('#view_girdtable').appGridGet('rowdatas');
		    var _fields = $('#form_girdtable').appGridGet('rowdatas');
	        var btns = [];
	        var cols = [];
	        var fields=[];
	        					$.each(_fields, function(_index, _item) {
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
		  //判断有没有相同的code
		   var repeat=0;
		   for(var i=0;i<btns.length-1;i++)
		   {
		   	for(var j=i+1;j<btns.length;j++)
		   	{
		  	 
             if(btns[j].EnCode==btns[i].EnCode)
             {
             	repeat=1;
             	alert('相同的encode编号，保存失败');
             }

		   	}

		   }
if(repeat!=1){	
            postData.buttons = btns ;
			postData.columns = cols;
			postData.forms  =fields;
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
					window.parent.layx.destroy('Module');
					//$('#gridtable').appGridSet('reload',{});
				} else {
					
					app.MODAL_UTILS.success(data.message);
					window.parent.location.reload()
					window.parent.layx.destroy('Module');
				}
			});            	
             
}
		}

	}

	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)