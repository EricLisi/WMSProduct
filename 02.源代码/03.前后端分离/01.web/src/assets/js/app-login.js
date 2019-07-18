(function ($, app) {
	"use strict";
	var AUTOLOGIN_NODE = 'AUTOLOGIN'
	/**
	 * 页面事件对象
	 */
	var pageEvent = {
		/**
		 *  窗体初始化 
		 **/
		init: function () {
			if (!pageEvent.BrowserValidate()) {
				return false;
			}
			pageEvent.clearcache();
			pageEvent.autologin();
			pageEvent.validateInit();

			$("#btnLogin").click(function () {
				pageEvent.login();
			})

			$("#copy").text(new Date().getFullYear())

			// $("#account").blur(function () {
			// 	pageEvent.InitPlatFormSelect();
			// });
		},
		/**
		 * 根据获取的数据,绑定平台
		 * @param {object} data 平台数据
		 */
		getPlatformHTML: function (data) {
			var html = '<option value="">=请选择登录平台=</option>';
			for (var i = 0; i < data.length; i++) {
				html += '<option value="' + data[i].F_Id + '" data-url="' + data[i].F_HomePageUrl + '">' + data[i].F_FullName + '</option>'
			}
			return html;
		},
		/**
		 *  初始化下拉菜单
		 */
		InitPlatFormSelect: function () {
			var postData = $("#account").val();
			app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Login/GetPlat?username=' + postData, function (data) {
				//var data = platformDemoData;
				//清除Options				
				$("#loginPlatform").html("");
				$("#loginPlatform").append(pageEvent.getPlatformHTML(data));
			})

		},
		/**
		 * 清空缓存 
		 */
		clearcache: function () {
			app.LOCAL_STORE_UTILS.clear();
		},
		/**
		 * 自动登录设置
		 */
		autologin: function () {
			var autologin = app.LOCAL_STORE_UTILS.getObj(AUTOLOGIN_NODE)
			if (autologin) {
				$("#autoLogin").attr("checked", 'true');
				$("#account").val(autologin.account)
				pageEvent.InitPlatFormSelect();
			}
		},
		/**
		 * 验证控件初始化
		 */
		validateInit: function () {
			$('#validate').slideToUnlock({
				height: 36,
				text: '拖动滑块验证',
				succText: '验证成功',
				successFunc: function () {
					$("#btnLogin").removeAttr('disabled');
				}
			});
		},
		/**
		 * 浏览器校验 IE6不支持
		 */
		BrowserValidate: function () {
			var isIE6 = !!window.ActiveXObject && !window.XMLHttpRequest;
			if (isIE6) {
				window.location.href = "/ErrorPage/Browser"
				return false;
			}
			return true;
		},
		/**
		 * 系统登录 
		 */
		login: function () {
			$("#btnLogin").html("登陆中,请稍后...")
			//记录下登录的平台 
			app.LOCAL_STORE_UTILS.setObj(app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.LOGIN_PLATFORM, {
				PLATFORM_CODE: $("#loginPlatform").val(),
				PLATFORM_NAME: $("#loginPlatform option:selected").text(),
				PLATFORM_HOMEPAGE_URL: $("#loginPlatform option:selected").attr('data-url')
			})
			var param = {
				"Account": $("#account").val(),
				"PassWord": $.md5($("#password").val())
			};

			app.HTTP_REQUEST_UTILS.httpAsyncPost('/api/Login/LoginSystem', param,
				function (data) { 
					if (data.status) {
						//登录成功,记录下是否记录登录用户
						var remember = $("#autoLogin:checked").val() == "on" ? true : false;
						app.LOCAL_STORE_UTILS.set(app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.REMEMBER_ACCOUNT, remember) 
						//登录成功,在本地存储记录下登录用户
						app.LOCAL_STORE_UTILS.set(app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.LOGIN_USER, JSON.stringify(data.user)) 
						//将TOKEN记录到临时存储
						app.LOCAL_STORE_UTILS.set(app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.TOKEN, data.message) 
						//将当前用户Id记录到临时存储
						app.LOCAL_STORE_UTILS.set(app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.USERID, data.user.id)
						//将当前用户绑定的仓库Id记录到临时存储
						//app.LOCAL_STORE_UTILS.set(app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.WAREHOSEID, data.WarehouseId)
						setTimeout(() => {
							$("#btnLogin").html("登录系统")
						}, 1000);
						window.location.href = "index.html";
					} else {
						app.MODAL_UTILS.error(data.message)
						$("#btnLogin").html("登录系统")
					}

				},
				function () { 
					$("#btnLogin").html("登录系统")
				})

		}
	}

	$(function () {
		pageEvent.init();
	})
})(window.jQuery, top.app)