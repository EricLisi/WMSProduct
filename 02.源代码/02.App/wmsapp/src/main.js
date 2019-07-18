// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import store from './store'
import MintUI from "mint-ui"
import "mint-ui/lib/style.css"
import "./lib/mui/css/mui.min.css"
import mui from "./lib/mui/js/mui.min.js"
import "font-awesome/css/font-awesome.min.css"
import "./assets/css/app.css"

import request from '@/utils/request'

Vue.prototype.mui = mui
Vue.use(MintUI)

Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
	el: '#app',
	router,
	store,
	components: {
		App
	},
	template: '<App/>'
})

Vue.directive('focus', {
	// 当被绑定的元素插入到 DOM 中时……
	// 指令的定义
	inserted: function(el) {
		// 聚焦元素
		el.querySelector('input').focus()
	}
})