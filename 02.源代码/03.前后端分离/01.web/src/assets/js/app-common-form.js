/*
 * 模块管理主页面
 */
(function($, app) {
	"use strict";
	app.CommonFormParams = {
		router: "",
	}

	/**
	 * 页面事件
	 */
	app.CommonFormEvent = {
		/**
		 * 页面初始化
		 * @param {Object} options 选项
		 */
		init: function(formSetting) {
			app.CommonFormEvent.initParams(formSetting);
			if(!!formSetting.Event.doBeforeAdd) {
				formSetting.Event.doBeforeAdd();
			}
			if(!!formSetting.Event.doBeforeEdit) {
				formSetting.Event.doBeforeEdit();
			}
			 if(!!formSetting.bindEvent) {			 			
				formSetting.bindEvent.bindEvent();
			}			
			
			if(!!formSetting.initForm) {				
				formSetting.initForm.initForm();
			}
			if(!!formSetting.acceptClick) {
				formSetting.acceptClick.acceptClick();
			}			
		},
		/**
		 * 初始化参数
		 */
		initParams: function(formSetting) {
			app.CommonFormParams.router = formSetting.params.router;
		},				
		
	}
					
})(window.jQuery, top.app);