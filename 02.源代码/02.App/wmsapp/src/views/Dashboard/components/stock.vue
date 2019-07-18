<template>
	<div>
		<MenuGrid :menuitem="menuitem"></MenuGrid>
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
					title: "货位调整",
					src: '/CargoAdjust',
					parent:'stock',
				}, {
					icon:'fa fa-server fa-2x',
					title: "仓库盘点",
					src: '/Inventory',
					parent:'stock',
				}]
			}
		},
		methods: {

		}
	}
</script>

<style scoped>

</style>