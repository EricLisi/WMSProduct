/**
 * 系统配置文件
 */
(function($, app) {
	"use strict";
	/**
	 * 系统配置
	 */
	app.APP_CONFIGRATION = {
		/**
		 * API配置
		 */
		API_CONFIG: {
			/**
			 * 基本权限认证URL 需要预先配置
			 */
			BASE_API_URL: "http://localhost:5000",
			/**
			 * 验证数据配置
			 */
			API_AUTHORIZE: {
				/**
				 * 验证头VALUE前缀
				 */
				AUTHORIZE_HEADER_VALUE_PREFIX: "bearer "
			},
			/**
			 * 超时时间
			 */
			API_REQUEST_TIMEOUT: 5000,
			/**
			 * 默认类型
			 */
			API_REQUEST_DEFAULT_TYPE: 'JSON',
			/**
			 * 默认Content-type
			 */
			API_REQUEST_DEFAULT_CONTENT_TYPE: 'application/json',
			/**
			 * 心跳事件 分钟
			 */
			HEART_TIMEOUT:20
		},
		/**
		 * 本地存储配置
		 */
		LOCAL_STORE_CONFIG: {
			/**
			 * 存储媒体 0 localstroage 1 sessionstorage 2 cookie
			 */
			STORE_MEDIA: 0,
			/**
			 * 存储前缀
			 */
			STORE_PREFIX: "KGM_",
			/**
			 * 存储清除例外节点
			 */
			STORE_EXPECT_NODES: [
				"REMEMBER_LOGIN"
			],
			/**
			 * 记录登录用户选项
			 */
			REMEMBER_ACCOUNT: "REMEMBER_LOGIN",
			/**
			 * 登录平台存储节点
			 */
			LOGIN_PLATFORM: "LOGIN_PLATFORM",
			/**
			 * 登录用户节点
			 */
			LOGIN_USER: "LOGIN_USER",
			/**
			 * 登录用户下仓库节点
			 */
			WAREHOSEID:"WAREHOSEID",
			/**
			 * 登录用户Id
			 */
			USERID:"USERID",
			/**
			 * 登录TOKEN节点
			 */
			TOKEN: "TOKEN"
		},
		
		/**
		 * 全局存储配置
		 */
		GLOBE_STORE_CONFIG: {
			/**
			 * 缓存数据列表,将需要缓存的数据信息已枚举的方式先列入到配置中
			 */
			STORE_DATA: [
				// {
				// 	REMOTE: false, //是否其他路径加载 true 则 下方ACTIONURL需要写全路径 如 http://www.xxx.com/api/test 
				// 	KEY: "COMPANY", //索引KEY 读取数据的时候 根据此项来获取 
				// 	ACTION_URL: "/api/Company/GetTreeJson/", //请求的API路径
				// 	ACTION_TYPE: "GET", //数据请求方式
				// 	ACTION_DATA: {} //数据请求参数 支持枚举参数 @USERID 用户ID @PLATFORMID 登录平台ID @COMPNAYID 公司ID @DEPARTMENTID 部门ID
				// },
				// {
				// 	REMOTE: false,
				// 	KEY: "DEPARTMENT",
				// 	ACTION_URL: "/api/Department/GetTreeJson/",
				// 	ACTION_TYPE: "GET",
				// 	ACTION_DATA: {}
				// },
				// {
				// 	REMOTE: false,
				// 	KEY: "PROVINCE",
				// 	ACTION_URL: "/api/Area/GetProvinceTreeJson/",
				// 	ACTION_TYPE: "GET",
				// 	ACTION_DATA: {}
				// } ,
				// {
				// 	REMOTE: false,
				// 	KEY: "CITY",
				// 	ACTION_URL: "/api/Area/GetCityTreeJson/",
				// 	ACTION_TYPE: "GET",
				// 	ACTION_DATA: {}
				// } 
//				,{
//					REMOTE: false,
//					KEY: "ITEMDATA",
//					ACTION_URL: "/api/ItemData/GetSelectGrid",
//					ACTION_TYPE: "GET",
//					ACTION_DATA: {}
//				}
			]
		},
		/**
		 * 路由节点配置
		 */
		ROUTER_CONFIG: {
			/**
			 * 页面基础路径
			 */
			PAGE_ROOT: "./src/views/",
			/**
			 * 错误页URL
			 */
			ERROR_PAGE_URL: '/src/views/Error/index.html'
		}
	}
})(window.jQuery, top.app)