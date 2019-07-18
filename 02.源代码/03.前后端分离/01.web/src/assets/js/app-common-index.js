/*
 * 模块管理主页面
 */
(function ($, app) {
	"use strict";
	var selectedRow;
	var refreshGirdData;
	/**
	 * 本页面全局变量
	 */
	app.CommonIndexParams = {
		router: "",
		search: {
			id: "btn_Search",
			keywordValueId: "txt_Keyword", 
			setSearchParams: function (params) { 
				return {
					keyword: $('#' + this.keywordValueId).val()
				}
			}
		},
		grid: {
			id: "gridtable",
			keyFiled: "id",
			options: {
				isPage: true,
				reloadSelected: true,
				mainId: 'id'
			}
		},
		form: {
			id: app.BASE_UTILS.newGuid(),
			title: "",
			type: "layx",
			addActionUrl: "../html/form.html",
			editActionUrl: "../html/form.html?keyValue=",
			detailsActionUrl: "../html/form.html?show=1&keyValue=",
			buttons: [{
					label: '<i class="fa fa-save" style="margin-right:5px"></i>保存',
					callback: function (id, button, event) {
						// 获取 iframe 页面 window对象
						var contentWindow = layx.getFrameContext(id);
						if (!contentWindow.acceptClick()) {
							return false;
						}
						location.reload();
						layx.destroy(id);
					},
					classes: ['btn-primary']
				},
				{
					label: '<i class="fa fa-close" style="margin-right:5px"></i>取消',
					callback: function (id, button, event) {
						layx.destroy(id);
					},
					classes: ['btn-danger']
				}
			],

		}
	}

	/**
	 * 页面事件
	 */
	app.CommonIndexEvent = {
		/**
		 * 页面初始化
		 * @param {Object} options 选项
		 */
		init: function (options, formSetting) {
			app.CommonIndexEvent.initParams(options);
			if (!!options.Event.doBeforeInit) {
				options.Event.doBeforeInit();
			}
			app.CommonIndexEvent.initConfig();
			if (!!options.tree.options) {
				app.CommonIndexEvent.inittree(options.tree.options);
			} 
			if (!!options.grid) {
				app.CommonIndexEvent.initgrid(app.CommonIndexParams.grid);
			}
			if (!!options.search) {
				app.CommonIndexEvent.initsearch() 
			}
			if (!!options.bindEvent) {
				app.CommonIndexEvent.bindEvent(options.bindEvent)
			}
			if (!!options.Event.doAfterInit) {
				options.Event.doAfterInit();
			}

		},
		/**
		 * 初始化参数
		 */
		initParams: function (options) {
			app.CommonIndexParams.router = options.params.router;
			$.extend(true, app.CommonIndexParams.form, options.params.form);
			$.extend(true, app.CommonIndexParams.grid, options.grid);
			$.extend(true, app.CommonIndexParams.search, options.search);
		},
		/**
		 * 初始化配置
		 */
		initConfig: function () {
			//错误页面路径重设
			app.APP_CONFIGRATION.ROUTER_CONFIG.ERROR_PAGE_URL = "../../../Error/index.html";
		},
		/**
		 * 绑定事件
		 */
		bindEvent: function (options) {
			// 刷新
			$('#app_refresh').on('click', function () {
				location.reload();

			});
			// 新增
			$('#app_add').on('click', function () {
				if (!!options.add && !!options.add.customerize) {
					options.add.customerize();
				} else {
					if (!!options.add.doBeforeEvent) {
						var r = options.add.doBeforeEvent(options)
						if (!r.result) {
							return false;
						}
					}
					selectedRow = null;
					if (app.CommonIndexParams.form.type == "layx") {
						layx.iframe(app.CommonIndexParams.form.id, app.CommonIndexParams.form.titleCustomerize ? app.CommonIndexParams.form.title : '添加' + app.CommonIndexParams.form.title,
							app.CommonIndexParams.form.addActionUrl + (!!r && !!r.data && !!r.data.addParams ? r.data.addParams : ""), {
								shadable: true,
								statusBar: true,
								height: app.CommonIndexParams.form.height,
								width: app.CommonIndexParams.form.width,
								//							skin: 'river',
								buttons: app.CommonIndexParams.form.buttons

							});
					} else if (app.CommonIndexParams.form.type == "tab") {
						app.frameTab.open({
							Id: app.CommonIndexParams.form.id,
							Icon: 'fa fa-file-text-o',
							FullName: app.CommonIndexParams.form.titleCustomerize ? app.CommonIndexParams.form.title : '添加' + app.CommonIndexParams.form.title,
							UrlAddress: 'WmsManage/' + app.CommonIndexParams.router + '/html/form.html'

						});
					}

				}
			});
			// 编辑
			$('#app_edit').on('click', function () { 
				if (app.CommonIndexParams.form.doBeforeEdit != null && app.CommonIndexParams.form.doBeforeEdit != undefined) {
					if (!app.CommonIndexParams.form.doBeforeEdit(keyValue)) {
						return false;
					}
				} 
				if (!!options.edit && !!options.edit.customerize) {
					options.edit.customerize();
				} else {
					var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
 
					selectedRow = $('#' + app.CommonIndexParams.grid.id).appGridGet('rowdata');

					if (!!options.edit && !!options.edit.doBeforeEvent) {
						var r = options.edit.doBeforeEvent(options)
						if (!r.result) {
							return false;
						}
					}

					if (app.BASE_UTILS.checkrow(keyValue)) {
						if (app.CommonIndexParams.form.type == "layx") {
							layx.iframe(app.CommonIndexParams.form.id, app.CommonIndexParams.form.titleCustomerize ? app.CommonIndexParams.form.title : '编辑' + app.CommonIndexParams.form.title,
								app.CommonIndexParams.form.editActionUrl + keyValue + (!!r && !!r.data && !!r.data.editParams ? r.data.editParams : ""), {
									shadable: true,
									statusBar: true,
									height: app.CommonIndexParams.form.height,
									width: app.CommonIndexParams.form.width,
									buttons: app.CommonIndexParams.form.buttons
								});
						} else if (app.CommonIndexParams.form.type == "tab") {
							app.frameTab.open({
								Id: app.CommonIndexParams.form.id,
								Icon: 'fa fa-file-text-o',
								FullName: app.CommonIndexParams.form.titleCustomerize ? app.CommonIndexParams.form.title : '编辑' + app.CommonIndexParams.form.title,
								UrlAddress: 'WmsManage/' + app.CommonIndexParams.router + '/html/form.html?keyValue=' + keyValue
							});
						}

					}
				}
			});
			// 查看
			$('#app_details').on('click', function () {
				if (app.CommonIndexParams.form.doBeforeDetails != null && app.CommonIndexParams.form.doBeforeDetails != undefined) {
					if (!app.CommonIndexParams.form.doBeforeDetails(keyValue)) {
						return false;
					}
				}
				if (!!options.details && !!options.details.customerize) {
					options.details.customerize();
				} else {
					var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
					//alert(keyValue)
					selectedRow = $('#' + app.CommonIndexParams.grid.id).appGridGet('rowdata');
					if (!!options.details && !!options.details.doBeforeEvent) {
						var r = options.details.doBeforeEvent(options)
						if (!r.result) {
							return false;
						}
					}

					if (app.BASE_UTILS.checkrow(keyValue)) {
						if (app.CommonIndexParams.form.type == "layx") {
							layx.iframe(app.CommonIndexParams.form.id, app.CommonIndexParams.form.titleCustomerize ? app.CommonIndexParams.form.title : '编辑' + app.CommonIndexParams.form.title,
								app.CommonIndexParams.form.detailsActionUrl + keyValue + (!!r && !!r.data && !!r.data.detailsParams ? r.data.detailsParams : ""), {
									shadable: true,
									statusBar: true,
									height: app.CommonIndexParams.form.height,
									width: app.CommonIndexParams.form.width,
									buttons: app.CommonIndexParams.form.buttons
								});
						} else if (app.CommonIndexParams.form.type == "tab") {
							app.frameTab.open({
								Id: app.CommonIndexParams.form.id,
								Icon: 'fa fa-file-text-o',
								FullName: app.CommonIndexParams.form.titleCustomerize ? app.CommonIndexParams.form.title : '查看' + app.CommonIndexParams.form.title,
								UrlAddress: 'WmsManage/' + app.CommonIndexParams.router + '/html/form.html?keyValue=' + keyValue + '&show=1'
							});
						}

					}
				}
			});
			// 删除
			$('#app_delete').on('click', function () {
				var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
				if (app.BASE_UTILS.checkrow(keyValue)) {
					app.MODAL_UTILS.confirm({
						msg: "是否确认删除该项！",
						callback: function () {
							layx.load('loadId', '数据正在删除中，请稍后');
							app.HTTP_REQUEST_UTILS.httpAsyncDelete(keyValue, '/api/' + app.CommonIndexParams.router, function (data) {
								layx.destroy('loadId');
								//console.log(data)
								if (data) {
									app.MODAL_UTILS.error(data.message)
									refreshGirdData();
								} else {
									app.MODAL_UTILS.success("删除成功！");
									refreshGirdData();
								}
							});
						}
					})

				}
			});
			//审核
			$('#app_verify').on('click', function () {
				var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
				selectedRow = $('#' + app.CommonIndexParams.grid.id).appGridGet('rowdata');
				if (selectedRow.Status > 0) {
					app.MODAL_UTILS.warning("该单据状态不允许审核!")
					return false;
				}
				if (app.BASE_UTILS.checkrow(keyValue)) {
					app.MODAL_UTILS.confirm({
						msg: "是否确认审核该项！",
						callback: function () {
							layx.load('loadId', '数据正在审核中，请稍后');
							app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/' + app.CommonIndexParams.router + '/VerifyList/' + keyValue + '?User=' + app.APP_GLOBE_STORE.LOGIN_USER.FullName + '&orderType=0', function (data) {
								layx.destroy('loadId');
								if (data.status) {
									app.MODAL_UTILS.success(data.message);
									refreshGirdData();
								} else {
									app.MODAL_UTILS.error(data.message)
								}
							});
						}
					})

				}
			});
			//弃审
			$('#app_deny').on('click', function () {
				var keyValue = $('#' + app.CommonIndexParams.grid.id).appGridValue(app.CommonIndexParams.grid.keyFiled);
				//				alert(keyValue)
				selectedRow = $('#' + app.CommonIndexParams.grid.id).appGridGet('rowdata');
				if (selectedRow.Status > 1) {
					app.MODAL_UTILS.warning("该单据状态不允许弃审!")
					return false;
				}
				if (app.BASE_UTILS.checkrow(keyValue)) {
					app.MODAL_UTILS.confirm({
						msg: "是否确认弃审该项！",
						callback: function () {
							layx.load('loadId', '数据正在弃审中，请稍后');
							app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/' + app.CommonIndexParams.router + '/VerifyList/' + keyValue + '?User=' + app.APP_GLOBE_STORE.LOGIN_USER.FullName + '&orderType=1', function (data) {
								layx.destroy('loadId');
								if (data.status) {
									app.MODAL_UTILS.success(data.message);
									refreshGirdData();
								} else {
									app.MODAL_UTILS.error(data.message)
								}
							});
						}
					})

				}
			});
			// 用户数据导出
			$('#app_export').on('click', function () {
				location.href = app.CommonIndexParams.router + "/ExportUserList";
			});
		},
		//初始化树
		inittree: function (options) {
			var _treeElemet = $("#" + options.id);
			_treeElemet.apptree({
				url: options.url,
				data: options.data,
				param: {
					parentId: options.parentId || '0'
				},
				nodeClick: options.nodeClick
			})
			if (!!options.defaultValue) {
				_treeElemet.apptreeSet('setValue', options.defaultValue);	
			}
		},
		/**
		 * 初始化表格
		 */
		initgrid: function (options) {
			$("#" + app.CommonIndexParams.grid.id).appgrid(options.options);
		},
		/*搜索事件*/
		initsearch: function () {
			$("#" + app.CommonIndexParams.grid.id).appGridSet('reload', '');
			//得到Search对象 
			$("#" + app.CommonIndexParams.search.id).click(function () {
				if (!!app.CommonIndexParams.search.SearchEvent) {
					app.CommonIndexParams.search.serachEvent()
				}else {
					//刷新grid
					var options = app.CommonIndexParams.search.setSearchParams(); 
					$("#" + app.CommonIndexParams.grid.id).appGridSet('reload', options);
				}
			})
		}
	}

	// 保存数据后回调刷新
	refreshGirdData = function () {
		app.CommonIndexEvent.initsearch();
	}

})(window.jQuery, top.app);