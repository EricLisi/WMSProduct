<template>
	<div>
		<MenuGrid  :menuitem="menuitem"></MenuGrid>
	</div>
</template>

<script>
	import MenuGrid from '@/components/MenuGrid/index.vue';
	export default {
		components: {
			MenuGrid
		},
		data() {
			return {
				menuitem: [{
					icon:'fa fa-file-powerpoint-o fa-2x',
					title: "按单出库",
					src: '/SingleOut',
					parent:'outStock',
				}, {
					icon:'fa fa-server fa-2x',
					title: "其他出库",
					src: '/OtherOut',
					parent:'outStock',
				}]
			}
		},
		methods: {
			goRouter: function(router, currentParentRouter) {
				localStorage.setItem('parent', '2')
				this.$router.push({
					path: router
				})
			}
		}
	}
</script>

<style scoped>
	.menu {
		border: 1px solid #B3ACAC;
		border-radius: 10px;
		background: #2F98FA;
		color: #FFFFFF;
		text-align: center;
		padding: 10px 0;
		margin: 10px 10px;
		height: 60px;
		line-height: 60px;
		float: left;
	}
	
	.menu-one {
		width: 94%;
	}
	
	.menu-two {
		width: 42%;
	}
	
	.menu-three {
		width: 26%;
	}
	
	.roulink {
		color: #FFFFFF;
		text-decoration: none;
	}
</style>