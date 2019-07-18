/**
 * 本地存储操作
 */
(function ($, app) {
    "use strict";

    /**
     * 存储操作
     */
    app.LOCAL_STORE_UTILS = {
        /**
         * 判断是否是在例外列表
         * @param {string} key 
         */
        existsExpect: function (key) {
            var expdata = app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.STORE_EXPECT_NODES;
            for (var i = 0; i < expdata.length; i++) {
                if (app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.STORE_PREFIX + expdata[i] == key) {
                    return true;
                }
            } 
            //如果是自动登录,则不清楚最后一次的用户
            if (app.LOCAL_STORE.AUTO_LOGIN == 'true' && key == app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.STORE_PREFIX + top.app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.LOGIN_USER) {
                return true;
            } 
            return false;
        },
        /**
         * 根据key获取数据
         * @param {string} key 存储节点
         * @returns {string} 返回string
         * 
         */
        get: function (key) {
            key = app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.STORE_PREFIX + key;
            var value = null;
            switch (app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.STORE_MEDIA) {
                case 0: //localstorage
                    value = localStorage.getItem(key);
                    break;
                case 1:
                    value = sessionStorage.getItem(key);
                    break;
                case 2:
                    break;
            }
            return value;
        },
        /**
         * 根据key获取数据
         * @param {string} key 存储节点
         * @returns {object} 返回对象 未能取到时,返回undefined
         */
        getObj: function (key) {
            var str = this.get(key);
            if (!!str) {
                return JSON.parse(str);
            } else {
                return undefined;
            }
        },
        /**
         * 根据key存储数据
         * @param {string} key 存储节点
         * @param {string} value 存储值 string类型 
         */
        set: function (key, value) {
            key = app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.STORE_PREFIX + key;
            switch (app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.STORE_MEDIA) {
                case 0: //localstorage
                    localStorage.setItem(key, value);
                    break;
                case 1:
                    sessionStorage.setItem(key, value);
                    break;
                case 2:
                    break;
            }
        },
        /**
         * 根据key存储数据
         * @param {string} key 存储节点
         * @param {object} value 存储值 object类型 
         */
        setObj: function (key, value) {
            this.set(key, JSON.stringify(value));
        },
        /**
         * 根据key移除节点
         * @param {string} key 
         */
        remove: function (key) {
            key = app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.STORE_PREFIX + key;
            switch (app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.STORE_MEDIA) {
                case 0: //localstorage
                    localStorage.removeItem(key);
                    break;
                case 1:
                    sessionStorage.removeItem(key);
                    break;
                case 2:
                    break;
            }
        },
        /**
         * 清除所有本地存储 
         */
        clear: function () {
            var data = undefined;
            switch (app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.STORE_MEDIA) {
                case 0: //localstorage
                    data = window.localStorage;
                    break;
                case 1:
                    data = window.sessionStorage;
                    break;
                case 2:
                    break;
            } 
            for (var i = 0; i < data.length; i++) {
                var key = data.key(i); 
                if (!app.LOCAL_STORE_UTILS.existsExpect(key)) {
                    data.removeItem(key);
                    i--;
                }
            }
        }
    }



    /**
     * 本地存储数据
     */
    app.LOCAL_STORE = {
        /**
         * 上一次登录的用户信息
         */
        LOGIN_USER: app.LOCAL_STORE_UTILS.get(top.app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.LOGIN_USER),      
        /**
         * 登录平台
         */
        LOGIN_PLATFORM: app.LOCAL_STORE_UTILS.getObj(top.app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.LOGIN_PLATFORM),
        /**
         * 登录TOKEN
         */
        LOGIN_TOKEN: app.LOCAL_STORE_UTILS.get(top.app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.TOKEN),
         /**
         * 登录USERID
         */
        LOGIN_USERID:app.LOCAL_STORE_UTILS.get(top.app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.USERID),
         /**
         * 登录WAREHOSEID
         */
        LOGIN_WAREHOSEID:app.LOCAL_STORE_UTILS.get(top.app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.WAREHOSEID),
        /**
         * 是否自动登录
         */
        AUTO_LOGIN: app.LOCAL_STORE_UTILS.get(top.app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.REMEMBER_ACCOUNT)
    }
})(window.jQuery, top.app)