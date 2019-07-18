<template>
	<div>
		<mt-header title="WMS管理系统"></mt-header>
		<!--<div v-show="selected != 'System'">
			<img src="../../../static/images/banner1.jpg" height="200" width="100%" />
		</div>-->
		<div>
			<img src="../../../static/images/banner1.jpg" height="200" width="100%" />
		</div>
		<div id="news">
			<i class="fa fa-volume-up" style="color: #f7968d;font-size: 22px;padding-left: 5px;"></i><marquee id="mar" direction=left >{{newsInfo}}</marquee>
		</div>
		<div class="content">
			<instock @showBottomMenu="showBottomMenu"></instock>
			<!--<mt-tab-container class="page-tabbar-container" v-model="selected">
				<mt-tab-container-item id="1">
					<instock @showBottomMenu="showBottomMenu"></instock>
				</mt-tab-container-item>
				<mt-tab-container-item id="2">
					<outstock></outstock>
				</mt-tab-container-item>
				<mt-tab-container-item id="3">
					<stock></stock>
				</mt-tab-container-item>
				<mt-tab-container-item id="System">
					<personal></personal>
				</mt-tab-container-item>
			</mt-tab-container>
			<mt-tabbar v-model="selected" v-show="show">
				<mt-tab-item id="1">
					<i class="fa fa-sign-in fa-2x"></i>
					<div>入库管理</div>
				</mt-tab-item>
				<mt-tab-item id="2">
					<i class="fa fa-sign-out fa-2x"></i>
					<div>出库管理</div>
				</mt-tab-item>
				<mt-tab-item id="3">
					<i class="fa fa-home fa-2x"></i>
					<div>库内管理</div>
				</mt-tab-item>
				<mt-tab-item id="System">
					<i class="fa fa-gear fa-2x"></i>
					<div>个人中心</div>
				</mt-tab-item>
			</mt-tabbar>-->
		</div>
	</div>
</template>

<script>
	import personal from './components/personal'
	import instock from './components/instock'
	import outstock from './components/outstock'
	import stock from './components/stock'
	import request from '@/utils/request'
	//import { Swipe, SwipeItem } from 'mint-ui';
	
	export default {
		name: 'Dashboard',
		components: {
			instock,
			outstock,
			stock,
			personal
		},
		data() {
			return {
				selected: "1",
				newsInfo:"测试测试测试测试测试测试",
				show: true
			}
		},
		created() {
			//this.GetModuleTree()
		},
		methods: {
			showBottomMenu: function(data) {
				this.show = data
			},
			//用户列表
			GetModuleTree(){ 
				request.get("/api/Module/GetModuleTree")
					.then(res => {	
						if(res.status) {
							alert(res.message)
						}
					}).catch(err => {
						console.log(err);
					});
			}
		},
		mounted: function() {
			var _this = this;
			if(!!localStorage.getItem('parent')) {
				_this.selected = localStorage.getItem('parent');
			}
		}
	}
</script>

<style scoped>
	i {
		color: #2f98fa
	}
	
	#news{
		padding: 1px;
		background-color: #f1f3f2;
	}
	#mar{
		color: #ee6558;
		float:right;
		width: 92%;
		line-height: 20px;
	}
</style>