<template>
	<MenuGrid @showBottomMenu="showBottomMenu" :menuitem="menuitem"></MenuGrid>
</template>

<script>
	import MenuGrid from '@/components/MenuGrid/index.vue';
	import request from '@/utils/request'
	export default {
		components: {
			MenuGrid,
		},
		data() {
			return {
				menuitem: [{
					icon: 'fa fa-cog fa-2x',
					title: "个人中心",
					src: '/Personal',
					parent: 'inStock',
				}, {
					icon: 'fa fa-power-off fa-2x',
					title: "注销",
					src: 'off',
					parent: 'inStock',
				}],
			}
		},
		methods: {
			goRouter: function(router, currentParentRouter) {
				localStorage.setItem('parent', '1')
				this.$router.push({
					path: router
				})
			},
			showBottomMenu: function(data) {
				this.$emit('showBottomMenu', data);
			},
			//用户列表
			GetModuleTree() {
				request.get("/api/Module/GetModuleTree")
					.then(result => {
						var _this=this;
						var res = JSON.parse(result.data)
						if(res.result) {
							for(var i = 0; i < res.message.length; i++) {
								_this.menuitem.unshift(res.message[i])
							}
						}
					}).catch(err => {
						console.log(err);
					});
			}
		},
		created() {
			this.GetModuleTree()
		},
		mounted: function() {

		}
	}
</script>
<style scoped>

</style>