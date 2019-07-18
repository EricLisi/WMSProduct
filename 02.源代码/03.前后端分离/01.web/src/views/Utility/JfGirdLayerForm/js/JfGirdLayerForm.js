var acceptClick;
var op = top.appGirdLayerEdit;
(function($, app) {
	"use strict";
	var selectItem;
	var griddata = null;
	/**
	 * 页面事件对象
	 */
	var pageEvent = {
		/**
		 *  窗体初始化 
		 **/
		init: function() {
			pageEvent.bindEvent();
			pageEvent.initgrid()
		},
		/**
		 * 绑定事件
		 */
		bindEvent: function() {
			$('#btn_Search').on('click', function() {
				if(griddata != null) {
					var data = [];
					var keyword = $('#txt_Keyword').val();
					if(!!keyword) {
						for(var i = 0, l = griddata.length; i < l; i++) {
							var item = griddata[i];
							for(var j = 0, jl = op.edit.op.colData.length; j < jl; j++) {
								if(item[op.edit.op.colData[j].name] && item[op.edit.op.colData[j].name].indexOf(keyword) != -1) {
									data.push(item);
									break;
								}
							}
						}
						$('#gridtable').appGridSet('refreshdata', data);
					} else {
						$('#gridtable').appGridSet('refreshdata', griddata);
					}

				}
			});
		},
		/**
		 * 初始化表格
		 */
		initgrid: function() {
			$("#gridtable").appgrid({
				headData: op.edit.op.colData,
				url: op.edit.op.url,				
				isMultiselect: true,
				isPage: true,				
				param: op.edit.op.param,
				onRenderComplete: function(data) {
					griddata = data;
					//alert(JSON.stringify(griddata))
				},
				dblclick: function(row) {
					top.appGirdLayerEditCallBack(row);
					layx.destroyAll();
				},
				onSelectRow: function(row) {
					selectItem = row;				
					//alert(JSON.stringify(selectItem))
				}
			})
			$('#gridtable').appGridSet('reload');
		}
	};
	// 保存数据
	acceptClick = function(callBack) {
		callBack(selectItem);		
		return true;
		
//		var s = $("#gridtable").appGridGet('rowdata');


//		alert(JSON.stringify(s))
//		callBack(s);		
//		return true;
	};

	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)