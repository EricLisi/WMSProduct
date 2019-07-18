/**
 * HTTP请求对象
 */
(function ($, app) {
	"use strict";

	/**
	 * 本地方法
	 */
	var $utils = {
		/**
		 * 发送请求
		 * @param {object} options 请求参数
		 * @param {function} successCallback 成功回调
		 * @param {function} errorCallback 失败回调
		 * @param {boolean} showLoading 展示Loading
		 */
		request: function (options, successCallback, errorCallback, showLoading) {
			var headerValue = app.APP_CONFIGRATION.API_CONFIG.API_AUTHORIZE.AUTHORIZE_HEADER_VALUE_PREFIX + app.LOCAL_STORE.LOGIN_TOKEN;
			var _default = {
				timeout: app.APP_CONFIGRATION.API_CONFIG.API_REQUEST_TIMEOUT,
				dataType: app.APP_CONFIGRATION.API_CONFIG.API_REQUEST_DEFAULT_TYPE,
				cache: true,
				async: true,
				contentType: "application/json", //app.APP_CONFIGRATION.API_REQUEST_DEFAULT_CONTENT_TYPE, 
				headers: { //添加头
					"Authorization": headerValue
				},
				success: function (data) {
					//alert(JSON.stringify(data))
					if (!!successCallback) {
						successCallback(data)
					}
				},
				error: function (xhr) { 
					//跳转到错误页面
					if (!!errorCallback) {
						errorCallback();
					} else if (xhr.status == '401') {
						window.location.href = app.APP_CONFIGRATION.ROUTER_CONFIG.ERROR_PAGE_URL + '?errorcode=' + xhr.status;
					} else {
						app.MODAL_UTILS.error('操作失败!原因:' + xhr.status)
					}
				}
			}

			if (!!showLoading) {
				_default.beforeSend = function () {
					layx.load('loadId', '数据正在加载中，请稍后');
				}
			}
			options = $.extend(_default, options)
			options.url = app.APP_CONFIGRATION.API_CONFIG.BASE_API_URL + options.url;

			$.ajax(options);
		}
	}

	/**
	 * HTTP请求对象
	 */
	app.HTTP_REQUEST_UTILS = {
		/**
		 * 发送ajax请求
		 * @param {object} options 参数
		 * @param {function} callback 成功回调
		 * @param {function} errorCallback 失败回调
		 * @param {boolean} showLoading 展示Loading
		 */
		httpRequest: function (options, callback, errorCallback, showLoading) {
			$utils.request(options, callback, errorCallback, showLoading);
		},
		/**
		 * 发送ajax请求
		 * @param {string} type 请求类型
		 * @param {string} url 请求URL
		 * @param {object} param 参数
		 * @param {function} callback 回调函数
		 * @param {function} errorCallback 失败回调
		 */
		httpAsync: function (type, url, param, callback, errorCallback, showLoading) {
			var para = JSON.stringify(param);
			if (type == 'post' || type == 'POST') {
				param = para
			}
			if (type == 'put' || type == 'PUT') {
				param = para
			}

			var options = {
				type: type,
				url: url,
				data: param
			}
			$utils.request(options, callback, errorCallback, showLoading);
		},
		/**
		 * 发送ajax请求 同步
		 * @param {string} type 请求类型
		 * @param {string} url 请求URL
		 * @param {object} param 参数
		 * @param {function} callback 回调函数
		 * @param {function} errorCallback 失败回调
		 */
		httpSync: function (type, url, param, callback, errorCallback, showLoading) {
			var para = JSON.stringify(param);
			if (type == 'post' || type == 'POST') {
				param = para
			}
			if (type == 'put' || type == 'PUT') {
				param = para
			}

			var options = {
				type: type,
				url: url,
				data: param,
				async: false
			}
			$utils.request(options, callback, errorCallback, showLoading);
		},
		/**
		 * 发送GET请求
		 * @param {string} url 请求路径
		 * @param {function} callback 回调函数
		 * @param {function} errorCallback 失败回调
		 * @param {boolean} showLoading 展示Loading
		 */
		httpAsyncGet: function (url, callback, errorCallback, showLoading) {
			var options = {
				url: url,
				type: "GET"
			}
			$utils.request(options, callback, errorCallback, showLoading);
		},
		/**
		 * 发送GET请求
		 * @param {string} url 请求路径
		 * @param {function} callback 回调函数
		 * @param {function} errorCallback 失败回调
		 * @param {boolean} showLoading 展示Loading
		 */
		httpGet: function (url, callback, errorCallback, showLoading) {
			var options = {
				url: url,
				type: "GET",
				async: false
			}
			$utils.request(options, callback, errorCallback, showLoading);
		},
		/**
		 * 发送POST请求
		 * @param {string} url 请求路径
		 * @param {object} param 参数
		 * @param {function} callback 回调函数
		 * @param {function} errorCallback 失败回调
		 * @param {boolean} showLoading 展示Loading
		 */
		httpAsyncPost: function (url, param, callback, errorCallback, showLoading) {
			var options = {
				url: url,
				type: "POST",
				data: JSON.stringify(param)
			}
			$utils.request(options, callback, errorCallback, showLoading);
		},
		/**
		 * 发送PUT请求
		 * @param {string} key 主键
		 * @param {string} url 请求路径
		 * @param {object} param 参数
		 * @param {function} callback 回调函数
		 * @param {function} errorCallback 失败回调
		 * @param {boolean} showLoading 展示Loading
		 */
		httpAsyncPut: function (key, url, param, callback, errorCallback, showLoading) {
			var options = {
				url: url + '/' + escape(key),
				type: "PUT",
				data: JSON.stringify(param)
			}
			$utils.request(options, callback, errorCallback, showLoading);
		},
		/**
		 * 发送DELETE请求
		 * @param {string} key 主键
		 * @param {string} url 请求路径 
		 * @param {function} callback 回调函数
		 * @param {function} errorCallback 失败回调
		 * @param {boolean} showLoading 展示Loading
		 */
		httpAsyncDelete: function (key, url, callback, errorCallback, showLoading) {
			var options = {
				url: url + '/' + escape(key),
				type: "DELETE"
			}
			$utils.request(options, callback, errorCallback, showLoading);

		},
	}
})(window.jQuery, top.app)