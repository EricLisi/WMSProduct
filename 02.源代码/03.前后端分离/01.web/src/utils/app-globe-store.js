/**
 * 应用全局存储 存储一些基础类档案信息,可以本地读取,不从服务端获取
 * 每次登陆加载一次,适用于一些不经常变化的档案 例如 公司、部门、数据字典等
 */
(function ($, app) {
	"use strict";
	var $utils = {
		/**
		 * 初始化
		 * @param {function} callback 回调函数
		 */
		init: function (callback) {
			//初始化用户信息
			if (!this.initUser()) {
				return;
			}
			//初始化存储状态
			this.initStoreDataStatus();
		},
		/**
		 * 获取左侧树形菜单
		 */
		getTreeMenuData: function (data) {
			var modulesTree = {};

			//数据排序
			data.sort(
				function (a, b) {
					if (a.modulesortcode > b.modulesortcode) return 1;
					if (a.modulesortcode < b.modulesortcode) return -1;
					return 0;
				}
			)
			//alert(JSON.stringify(data))
			for (var i = 0; i < data.length; i++) {
				var _item = data[i];
				if (_item.moduleenabledmark) {
					modulesTree[_item.moduleparentid] = modulesTree[_item.moduleparentid] || [];
					modulesTree[_item.moduleparentid].push(_item);
				}
			}
			return modulesTree;
		},
		/**
		 * 初始化存储数据状态
		 */
		initStoreDataStatus: function () {
			var _this = this;
			//读取配置中需要缓存的数据
			var configData = app.APP_CONFIGRATION.GLOBE_STORE_CONFIG.STORE_DATA;
			//初始化存储列表状态
			$.each(configData, function (item, value) {
				app.HTTP_REQUEST_UTILS.httpGetAsync(value.ACTION_URL + app.LOCAL_STORE.LOGIN_USERID,
					function (data) {
						app.APP_GLOBE_STORE.DATA_STATUS[value.KEY] = data;
					}, () => {

					})
			})
		},
		/**
		 * 初始化用户
		 */
		initUser: function () {
			//读取当前用户
			app.APP_GLOBE_STORE.LOGIN_USER = app.LOCAL_STORE_UTILS.getObj(app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.LOGIN_USER)
			var _this = this;
			var bSuccess = false;
			//初始化菜单
			app.HTTP_REQUEST_UTILS.httpGet('/api/Role/' + app.APP_GLOBE_STORE.LOGIN_USER.roleid,
				function (data) { 
					//console.log(data)
					app.APP_GLOBE_STORE.LOGIN_USER_BUTTON = data.buttons;
					app.APP_GLOBE_STORE.LOGIN_USER_MODULE = data.modules;
					//console.log(data.modules)
					//初始化树形菜单						
					app.APP_GLOBE_STORE.LEFT_TREE_MENU = _this.getTreeMenuData(app.APP_GLOBE_STORE.LOGIN_USER_MODULE);
				}, () => {
					bSuccess = false;
					window.location.href = 'login.html' 
				})

			return bSuccess;
		}
	}


	/**
	 * 应用全局存储
	 */
	app.APP_GLOBE_STORE = {
		/**
		 * 登录用户
		 */
		LOGIN_USER: {},
		/**
		 * 用户权限模块信息
		 */
		LOGIN_USER_MODULE: [],
		/**
		 * 用户权限模块按钮信息
		 */
		LOGIN_USER_BUTTON: [],
		/**
		 * 左侧树形菜单
		 */
		LEFT_TREE_MENU: [],
		/**
		 * 公司、部门、数据字典
		 */
		DATA_STATUS: {}
	}

	/**
	 * 全局存储操作方式
	 */
	app.APP_GLOBE_STORE_UTILS = {
		/**
		 * 初始化
		 */
		init: function () {
			$utils.init();
		},
		/**
		 * 获取项目值
		 * @param {object} item 项目
		 * @param {string} key 键
		 */
		getItemValue(item, key) {
			if (typeof (item) == 'object') { //如果是对象,则根据key来返回 
				return item[key]
			} else { //非对象，无视key 返回缓存 
				return item;
			}
		},
		/**
		 * 获取数据
		 * @param {string} storeKey 存储节点
		 * @param {string} objectKey 对象key
		 */
		getData: function (storeKey, objectKey) {
			//获取全局缓存数据
			var data = app.APP_GLOBE_STORE.DATA_STATUS[storeKey];
			//没有全局节点，返回空
			if (!!!data) {
				return "";
			}
			//如果没有options 返回全部缓存对象
			if (!!!objectKey) {
				return data[objectKey];
			}
			return data;
		},
		/**
		 * 根据键值对获取全局数据
		 * @param {string} storeKey 获取存储节点
		 * @param {object} options 格式 {key,value}
		 */
		getKeyValue: function (storeKey, options) {
			var _this = this;
			var objectkey = !!options ? options.key : undefined;
			var data = this.getData(storeKey, objectkey)

			if (!!!data) {
				return "";
			}
			//判断当前获取到的缓存舒适否是数组 
			var datalength = data.length
			if (!!!datalength) { //当前不为数组 
				var item = this.getItemValue(data, objectKey)
				if (item != options.value) {
					return ""
				} else {
					return data;
				}
			}

			//当前对象是数组
			var activeItem = undefined;

			for (var i = 0; i < data.length; i++) {
				var item = data[i];
				if (_this.getItemValue(item, options.key) == options.value) {
					activeItem = item;
					break;
				}
			}

			return activeItem;
		},
		/**
		 * 根据键值对获取全局数据
		 * @param {string} storeKey 获取存储节点
		 * @param {object} options 格式 {key,callback(格式 function(o){return o.key = value})}
		 */
		getCondition: function (storeKey, options) {
			var objectkey = !!options ? options.key : undefined;
			var data = this.getData(storeKey, objectkey)

			if (data != null) {
				return data;
			}

			//判断当前获取到的缓存舒适否是数组 
			var datalength = data.length
			if (!!!datalength) { //当前不为数组 
				return options.callback(data)
			}

			//当前对象是数组
			var arr = []
			for (item in data) {
				if (options.callback(item)) {
					arr.push(item);
				}
			}
			return arr;
		}
	}
})(window.jQuery, top.app)