<template>
	<div class="content">
		<div class="menubox">
			<div :class="menuclass" v-for="(item,index) in showItems" class="menu">
				<div class="roulink" @click="goRouter(item.src,item.parent)">
					<div class="icss"><i :class="item.icon"></i></div>
					{{item.title}}
				</div>
			</div>
		</div>
	</div>

</template>
<script>
	import { Swipe, SwipeItem } from 'mint-ui';
	import {
		MessageBox
	} from 'mint-ui';

	export default {
		components: {
			'mt-swipe': Swipe,
			'mt-swipe-item': SwipeItem,
		},
		data() {
			return {
				menuclass: "menu-two",
				showItems: []
			}
		},
		props: {
			menuitem: {
				type: Array,
				default() {
					return []
				}
			},
			itemCount: {
				type: Number,
				default() {
					return 12
				}
			}
		},
		methods: {
			goRouter: function(router, currentParentRouter) {
				var _this = this;
				if(router == "#") {
					_this.$emit('showBottomMenu', false); //select事件触发后，自动触发showCityName事 
					_this.showItems = [];
					_this.showItems = _this.menuitem;

					_this.showItems.splice(0, 0, {
						icon: 'fa fa-mail-reply fa-2x',
						title: "返回",
						src: '#!',
						parent: _this.menuitem[0].parent,
					})
				} else if(router == "#!") {
					_this.$emit('showBottomMenu', true); //select事件触发后，自动触发showCityName事  
					_this.showItems.shift()
					_this.setItems();
				} else if(router == "off") {
					_this.logout();
				} else {
					_this.$router.push({
						path: router
					})
					switch(currentParentRouter) {
						case 'inStock':
							localStorage.setItem('parent', '1')
							break;
						case 'outStock':
							localStorage.setItem('parent', '2')
							break;
						case 'stock':
							localStorage.setItem('parent', '3')
							break;
						default:
							localStorage.setItem('parent', '1')
							break;
					}
				}
			},
			setItems: function() {
				var _this = this;
				_this.showItems = [];
				if(_this.menuitem.length > _this.itemCount) {
					//只加载前11个 剩余的放在更多按钮中
					for(var i = 0; i < _this.itemCount - 1; i++) {
						_this.showItems.push(_this.menuitem[i])
					}
					_this.showItems.push({
						icon: 'fa fa-ellipsis-h fa-2x',
						title: "更多",
						src: '#',
						parent: _this.menuitem[0].parent,
					})
				} else {
					_this.showItems = _this.menuitem;
				}
			},
			logout: function() {
				var _this=this;
				_this.$store.dispatch('LogOut').then(() => {
				})	
				MessageBox.confirm('是否确定退出登陆?').then(action => {
					_this.$router.push({
						path: '/Login'
					})
				});
			}
		},
		mounted: function() {
			var _this = this;
			_this.setItems();
			switch(_this.menuitem.length) {
				case 1:
					_this.menuclass = "menu-one";
					break;
				case 2:
					_this.menuclass = "menu-two";
					break;
				default:
					_this.menuclass = "menu-three";
					break;
			}
		}
	}
</script>
<style>
	i {
		color: #87CEFA;
	}
	
	.icss {
		padding-top: 13px;
		height: 35px;
	}
	
	.mint-swipe {
		height: 218px;
	}
	
	.menubox {
		width: 99%;
		margin: 3px;
	}
	
	.menu {
		text-align: center;
		border: 1px solid #F5F5F5;
		background: whitesmoke;
		color: #000000;
		margin: 2px;
		height: 95px;
		line-height: 55px;
		float: left;
	}
	
	.menu:hover {
		background: whitesmoke;
		color: black;
	}
	
	.menu-one {
		width: 94%;
	}
	
	.menu-two {
		width: 48.5%;
	}
	
	.menu-three {
		width: 32.2%;
	}
</style>