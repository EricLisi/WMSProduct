/*
 * 描 述：表单处理方法
 */
(function ($, app) {
	"use strict";

	/*获取和设置表单数据*/
	$.fn.appGetFormData = function (keyValue) { // 获取表单数据
		var resdata = {};
		$(this).find('input,select,textarea,.app-select,.app-formselect,.appUploader-wrap,.app-radio,.app-checkbox,.edui-default').each(function (r) {
			var id = $(this).attr('id');
			if (!!id) {
				var type = $(this).attr('type');
				switch (type) {
					case "radio":
						if ($("#" + id).is(":checked")) {
							var _name = $("#" + id).attr('name');
							resdata[_name] = $("#" + id).val();
						}
						break;
					case "checkbox":
						if ($("#" + id).is(":checked")) {
							resdata[id] = true;
						} else {
							resdata[id] = false;
						}
						break;
					case "appselect":
						resdata[id] = $(this).appselectGet();
						break;
					case "formselect":
						resdata[id] = $(this).appformselectGet();
						break;
					case "appGirdSelect":
						resdata[id] = $(this).appGirdSelectGet();
						break;
					case "app-Uploader":
						resdata[id] = $(this).appUploaderGet();
						break;
					case "app-radio":
						resdata[id] = $(this).find('input:checked').val();
						break;
					case "app-checkbox":
						var _idlist = [];
						$(this).find('input:checked').each(function () {
							_idlist.push($(this).val());
						});
						resdata[id] = String(_idlist);
						break;
					default:
						if ($("#" + id).hasClass('currentInfo')) {
							var value = $("#" + id)[0].appvalue;
							resdata[id] = $.trim(value);
						} else if ($(this).hasClass('edui-default')) {
							if ($(this)[0].ue) {
								resdata[id] = $(this)[0].ue.getContent(null, null, true);
							}
						} else {

							var value = $("#" + id).val();
							resdata[id] = $.trim(value);
						}

						break;
				}
				resdata[id] += '';
				if (resdata[id] == '') {
					resdata[id] = '&nbsp;';
				}
				if (resdata[id] == '&nbsp;' && !keyValue) {
					resdata[id] = '';
				}
			}
		});
		return resdata;
	};
	$.fn.appSetFormData = function (data) { // 设置表单数据
		var $this = $(this);
		for (var id in data) {
			var value = data[id];
			var $obj = $this.find('#' + id);
			if ($obj.length == 0 && value != null) {
				$obj = $this.find('[name="' + id + '"][value="' + value + '"]');
				if ($obj.length > 0) {
					if (!$obj.is(":checked")) {
						$obj.trigger('click');
					}
				}
			} else {
				var type = $obj.attr('type');
				if ($obj.hasClass("app-input-wdatepicker")) {
					type = "datepicker";
				}
				switch (type) {
					case "checkbox":
						var isck = 0;
						if ($obj.is(":checked")) {
							isck = 1;
						} else {
							isck = 0;
						}
						if (isck != value) {
							$obj.trigger('click');
						}
						break;
					case "appselect":
						$obj.appselectSet(value);
						break;
					case "formselect":
						$obj.appformselectSet(value);
						break;
					case "appGirdSelect":
						$obj.appGirdSelectSet(value);
						break;
					case "datepicker":
						$obj.val(app.BASE_UTILS.Date.get_yyyy_MM_dd(new Date(value)));
						break;
					case "app-Uploader":
						$obj.appUploaderSet(value);
						break;
					case "app-radio":
						if (!$obj.find('input[value="' + value + '"]').is(":checked")) {
							$obj.find('input[value="' + value + '"]').trigger('click');
						}
						break;
					default:
						if ($obj.hasClass('currentInfo')) {
							$obj[0].appvalue = value;
							if ($obj.hasClass('currentInfo-user')) {
								$obj.val('');
								app.clientdata.getAsync('user', {
									key: value,
									callback: function (item, op) {
										op.obj.val(item.name);
									},
									obj: $obj
								});
							} else if ($obj.hasClass('currentInfo-company')) {
								$obj.val('');
								app.clientdata.getAsync('company', {
									key: value,
									callback: function (_data, op) {
										op.obj.val(_data.name);
									},
									obj: $obj
								});
							} else if ($obj.hasClass('currentInfo-department')) {
								$obj.val('');
								app.clientdata.getAsync('department', {
									key: value,
									callback: function (_data, op) {
										op.obj.val(_data.name);
									},
									obj: $obj
								});
							} else {
								$obj.val(value);
							}

						} else if ($obj.hasClass('edui-default')) {
							var ue = $obj[0].ue;
							setUe(ue, value);
						} else {
							$obj.val(value);
						}

						break;
				}
			}
		}
	};

	function setUe(ue, value) {
		ue.ready(function () {
			ue.setContent(value);
		});
	}

	/*表单数据操作*/
	$.appSetForm = function (url, callback) {
		layx.load('loadId', '数据正在加载中，请稍后');
		app.HTTP_REQUEST_UTILS.httpAsyncGet(url, function (data) {
			layx.destroy('loadId');
			if (!!callback) {
				callback(data);
			}
		});
	};

	$.appSaveForm = function (type, url, param, callback) {
		layx.load('loadId', '数据正在保存中，请稍后');
		var result = false;
		app.HTTP_REQUEST_UTILS.httpSync(type, url, param, function (data) {
			layx.destroy('loadId');
			if (callback) {
				result = callback()
			} else { 
				if (data.status) {
					app.MODAL_UTILS.success(data.message); 
					result = true;
				} else {
					app.MODAL_UTILS.error(data.message)
				}
			}
		});

		return result
	};
	/*tab页切换*/
	$.fn.appFormTab = function () {
		var $this = $(this);
		$this.parent().css({
			'padding-top': '44px'
		});
		$this.appscroll();
		$this.on('DOMNodeInserted', function (e) {
			var $this = $(this);
			var w = 0;
			$this.find('li').each(function () {
				w += $(this).outerWidth();
			});
			$this.find('.app-scroll-box').css({
				'width': w
			});
		});

		$this.delegate('li', 'click', {
			$ul: $this
		}, function (e) {
			var $li = $(this);
			if (!$li.hasClass('active')) {
				var $parent = $li.parent();
				var $content = e.data.$ul.next();
				var id = $li.find('a').attr('data-value');
				$parent.find('li.active').removeClass('active');
				$li.addClass('active');
				$content.find('.tab-pane.active').removeClass('active');
				$content.find('#' + id).addClass('active');
			}
		});
	}
	$.fn.appFormTabEx = function (callback) {
		var $this = $(this);
		$this.delegate('li', 'click', {
			$ul: $this
		}, function (e) {
			var $li = $(this);
			if (!$li.hasClass('active')) {
				var $parent = $li.parent();
				var $content = e.data.$ul.next();

				var id = $li.find('a').attr('data-value');
				$parent.find('li.active').removeClass('active');
				$li.addClass('active');
				$content.find('.tab-pane.active').removeClass('active');
				$content.find('#' + id).addClass('active');

				if (!!callback) {
					callback(id);
				}
			}
		});
	}

	/*检测字段是否重复*/
	$.appExistField = function (keyValue, controlId, url, param) {
		var $control = $("#" + controlId);
		if (!$control.val()) {
			return false;
		}
		var data = {
			keyValue: keyValue
		};
		data[controlId] = $control.val();
		$.extend(data, param);
		app.HTTP_REQUEST_UTILS.httpAsync('GET', url, data, function (data) {
			if (data == false) {
				$.appValidformMessage($control, '已存在,请重新输入');
			}
		});
	};

	/*固定下拉框的一些封装：数据字典，组织机构，省市区级联*/
	// 数据字典下拉框
	$.fn.appDataItemSelect = function (op) {
		// op:code 码,parentId 父级id,maxHeight 200,allowSearch， childId 级联下级框id
		var dfop = {
			// 是否允许搜索
			allowSearch: false,
			// 访问数据接口地址
			url: '/api/Items/GetTreeJson',
			// 访问数据接口参数
			param: {
				itemCode: '',
				parentId: '0'
			},
			// 级联下级框
		}
		op = op || {};
		if (!op.code) {
			return $(this);
		}
		dfop.param.itemCode = op.code;
		dfop.param.parentId = op.parentId || '0';
		dfop.allowSearch = op.allowSearch;

		var list = [];

		if (!!op.childId) {
			var list2 = [];
			$('#' + op.childId).appselect({
				// 是否允许搜索
				allowSearch: dfop.allowSearch
			});
			dfop.select = function (item) {
				if (!item) {
					$('#' + op.childId).appselectRefresh({
						data: []
					});
				} else {
					list2 = [];
					app.clientdata.getAllAsync('dataItem', {
						code: dfop.param.itemCode,
						callback: function (dataes) {
							$.each(dataes, function (_index, _item) {
								if (_item.parentId == item.k) {
									list2.push({
										id: _item.text,
										text: _item.value,
										title: _item.text,
										k: _index
									});
								}
							});
							$('#' + op.childId).appselectRefresh({
								data: list2
							});
						}
					});
				}
			};
		}
		var $select = $(this).appselect(dfop);
		app.clientdata.getAllAsync('dataItem', {
			code: dfop.param.itemCode,
			callback: function (dataes) {
				$.each(dataes, function (_index, _item) {
					if (_item.parentId == dfop.param.parentId) {
						list.push({
							id: _item.value,
							text: _item.text,
							title: _item.text,
							k: _index
						});
					}
				});
				$select.appselectRefresh({
					data: list
				});
			}
		});
		return $select;
	};
	// 数据源下拉框
	$.fn.appDataSourceSelect = function (op) {
		op = op || {};
		var dfop = {
			// 是否允许搜索
			allowSearch: true,
			select: op.select,
		}
		if (!op.code) {
			return $(this);
		}
		var $select = $(this).appselect(dfop);

		app.clientdata.getAllAsync('sourceData', {
			code: op.code,
			callback: function (dataes) {
				$select.appselectRefresh({
					value: op.value,
					text: op.text,
					title: op.text,
					data: dataes
				});
			}
		});
		return $select;
	}

	// 公司信息下拉框
	$.fn.appCompanySelect = function (op) {
		// op:parentId 父级id,maxHeight 200,
		var dfop = {
			type: 'tree',
			// 是否允许搜索
			allowSearch: true,
			// 访问数据接口地址
			//url:'/api/Company/GetSelectGrid/'+app.APP_GLOBE_STORE.LOGIN_USER.Id,
			data: app.APP_GLOBE_STORE.DATA_STATUS['COMPANY'],
			// 访问数据接口参数
			param: {
				parentId: '0'
			},
		};
		op = op || {};
		dfop.param.parentId = op.parentId || '0';

		if (!!op.isLocal) {
			dfop.url = '';
		}
		var $select = $(this).appselect(dfop);
		if (!!op.isLocal) {
			app.clientdata.getAllAsync('company', {
				callback: function (dataes) {
					var mapdata = {};
					var resdata = [];
					$.each(dataes, function (_index, _item) {
						mapdata[_item.parentId] = mapdata[_item.parentId] || [];
						_item.id = _index;
						mapdata[_item.parentId].push(_item);
					});
					_fn(resdata, dfop.param.parentId);

					function _fn(_data, vparentId) {
						var pdata = mapdata[vparentId] || [];
						for (var j = 0, l = pdata.length; j < l; j++) {
							var _item = pdata[j];
							var _point = {
								id: _item.id,
								text: _item.name,
								value: _item.id,
								showcheck: false,
								checkstate: false,
								hasChildren: false,
								isexpand: false,
								complete: true,
								ChildNodes: []
							};
							if (_fn(_point.ChildNodes, _item.id)) {
								_point.hasChildren = true;
								_point.isexpand = true;
							}
							_data.push(_point);
						}
						return _data.length > 0;
					}
					$select.appselectRefresh({
						data: resdata
					});
				}
			});
		}

		return $select;

	};
	// 部门信息下拉框
	$.fn.appDepartmentSelect = function (op) {
		// op:parentId 父级id,maxHeight 200,

		var dfop = {
			type: 'tree',
			// 是否允许搜索
			allowSearch: true,
			// 访问数据接口地址
			//url:'/api/Department/GetSelectGrid/'+app.APP_GLOBE_STORE.LOGIN_USER.Id,					
			data: app.APP_GLOBE_STORE.DATA_STATUS['DEPARTMENT'],
			//			data: [{
			//				"id": "23ac3ac1-097f-4007-8bd2-20fea87fe377",
			//				"text": "财务部",
			//				"title": null,
			//				"value": "23ac3ac1-097f-4007-8bd2-20fea87fe377",
			//				"icon": null,
			//				"showcheck": false,
			//				"checkstate": 0,
			//				"hasChildren": false,
			//				"isexpand": true,
			//				"complete": true,
			//				"ChildNodes": [],
			//				"parentId": "0"
			//			}, {
			//				"id": "16ce047b-a4b1-46b9-b29f-52d25efffcab",
			//				"text": "采购部",
			//				"title": null,
			//				"value": "16ce047b-a4b1-46b9-b29f-52d25efffcab",
			//				"icon": null,
			//				"showcheck": false,
			//				"checkstate": 0,
			//				"hasChildren": false,
			//				"isexpand": true,
			//				"complete": true,
			//				"ChildNodes": [],
			//				"parentId": "0"
			//			}],
			// 访问数据接口参数
			param: {
				companyId: '',
				parentId: '0'
			},
		}
		op = op || {};
		dfop.param.companyId = op.companyId;
		dfop.param.parentId = op.parentId;

		return $(this).appselect(dfop);;
	};
	// 人员下拉框
	//	$.fn.appUserSelect = function(type) { //0单选1多选
	//		if(type == 0) {
	//			$(this).appformselect({
	//				layerUrl: top.$.rootUrl + '/LR_OrganizationModule/User/SelectOnlyForm',
	//				layerUrlW: 400,
	//				layerUrlH: 300,
	//				dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
	//			});
	//		} else {
	//			$(this).appformselect({
	//				layerUrl: top.$.rootUrl + '/LR_OrganizationModule/User/SelectForm',
	//				layerUrlW: 800,
	//				layerUrlH: 520,
	//				dataUrl: top.$.rootUrl + '/LR_OrganizationModule/User/GetListByUserIds'
	//			});
	//		}
	//	}

	// 省市区级联
	$.fn.appAreaSelect = function (op) {
		// op:parentId 父级id,maxHeight 200,
		var dfop = {
			// 字段
			value: "EnCode",
			text: "FullName",
			title: "FullName",
			// 是否允许搜索
			allowSearch: true,
			// 访问数据接口地址
			url: '/api/Area/Getlist',
			// 访问数据接口参数
			param: {
				parentId: ''
			},
		}
		op = op || {};
		if (!!op.parentId) {
			dfop.param.parentId = op.parentId;
		}
		var _obj = [],
			i = 0;
		var $this = $(this);
		$(this).find('div').each(function () {
			var $div = $('<div></div>');
			var $obj = $(this);
			dfop.placeholder = $obj.attr('placeholder');
			$div.addClass($obj.attr('class'));
			$obj.removeAttr('class');
			$obj.removeAttr('placeholder');
			$div.append($obj);
			$this.append($div);
			if (i == 0) {
				$obj.appselect(dfop);
			} else {
				dfop.url = "";
				dfop.parentId = "";
				$obj.appselect(dfop);
				_obj[i - 1].on('change', function () {
					var _value = $(this).appselectGet();
					if (_value == "") {
						$obj.appselectRefresh({
							url: '',
							param: {
								parentId: _value
							},
							data: []
						});
					} else {
						$obj.appselectRefresh({
							url: '/api/Area/Getlist',
							param: {
								parentId: _value
							},
						});
					}

				});
			}
			i++;
			_obj.push($obj);
		});
	};
	// 数据库选择
	$.fn.appDbSelect = function (op) {
		// op:maxHeight 200,
		var dfop = {
			type: 'tree',
			// 是否允许搜索
			allowSearch: true,
			// 访问数据接口地址
			url: top.$.rootUrl + '/LR_SystemModule/DatabaseLink/GetTreeList'
		}
		op = op || {};

		return $(this).appselect(dfop);
	};

	// 动态获取和设置radio，checkbox
	$.fn.appRadioCheckbox = function (op) {
		var dfop = {
			type: 'radio', // checkbox
			dataType: 'dataItem', // 默认是数据字典 dataSource（数据源）
			code: '',
			text: 'F_ItemName',
			value: 'F_ItemValue'
		};
		$.extend(dfop, op || {});
		var $this = $(this);
		$this.addClass(dfop.type);
		$this.addClass('app-' + dfop.type);
		$this.attr('type', 'app-' + dfop.type);
		var thisId = $this.attr('id');

		if (dfop.dataType == 'dataItem') {
			app.clientdata.getAllAsync('dataItem', {
				code: dfop.code,
				callback: function (dataes) {
					$.each(dataes, function (id, item) {
						var $point = $('<label><input name="' + thisId + '" value="' + item.value + '"' + ' type="' + dfop.type + '">' + item.text + '</label>');
						$this.append($point);
					});
					$this.find('input').eq(0).trigger('click');
				}
			});
		} else {
			app.clientdata.getAllAsync('sourceData', {
				code: dfop.code,
				callback: function (dataes) {
					$.each(dataes, function (id, item) {
						var $point = $('<label><input name="' + thisId + '" value="' + item[dfop.value] + '"' + '" type="' + dfop.type + '">' + item[dfop.text] + '</label>');
						$this.append($point);
					});
					$this.find('input').eq(0).trigger('click');
				}
			});
		}
	};
	// 多条件查询框
	$.fn.appMultipleQuery = function (search, height, width) {
		var $this = $(this);
		var contentHtml = $this.html();
		$this.addClass('app-query-wrap');

		var _html = '';
		_html += '<div class="app-query-btn"><i class="fa fa-search"></i>&nbsp;多条件查询</div>';
		_html += '<div class="app-query-content">';
		//_html += '<div class="app-query-formcontent">';
		_html += contentHtml;
		//_html += '</div>';
		_html += '<div class="app-query-arrow"><div class="app-query-inside"></div></div>';
		_html += '<div class="app-query-content-bottom">';
		_html += '<a id="app_btn_queryReset" class="btn btn-default">&nbsp;重&nbsp;&nbsp;置</a>';
		_html += '<a id="app_btn_querySearch" class="btn btn-primary">&nbsp;查&nbsp;&nbsp;询</a>';
		_html += '</div>';
		_html += '</div>';
		$this.html(_html);
		$this.find('.app-query-formcontent').show();

		$this.find('.app-query-content').css({
			'width': width || 400,
			'height': height || 300
		});

		$this.find('.app-query-btn').on('click', function () {
			var $content = $this.find('.app-query-content');
			if ($content.hasClass('active')) {
				$content.removeClass('active');
			} else {
				$content.addClass('active');
			}
		});

		$this.find('#app_btn_querySearch').on('click', function () {
			var $content = $this.find('.app-query-content');
			var query = $content.appGetFormData();
			$content.removeClass('active');
			search(query);
		});

		$this.find('#app_btn_queryReset').on('click', function () {
			var $content = $this.find('.app-query-content');
			var query = $content.appGetFormData();
			for (var id in query) {
				query[id] = "";
			}
			$content.appSetFormData(query);
		});

		$(document).click(function (e) {
			var et = e.target || e.srcElement;
			var $et = $(et);
			if (!$et.hasClass('app-query-wrap') && $et.parents('.app-query-wrap').length <= 0) {

				$('.app-query-content').removeClass('active');
			}
		});
	};

})(jQuery, top.app);