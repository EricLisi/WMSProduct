<template>
	<div>
		<ScanOrder :OrderType="OrderType" :RouterPath="RouterPath" :Title="title"></ScanOrder>
	</div>
</template>

<script>
	import ScanOrder from '@/components/ScanOrder/index.vue';
	import request from '@/utils/request';
	
	export default {
		name: 'SingleEntry',
		components: {
			ScanOrder,
			request
		},
		data() {
			return {
				OrderNo: "",
				title:"入库扫描",
				OrderType:"PI",
				RouterPath:"/ScanInStock"
			}
		},
		methods: {
			
		},
		mounted: function() {

		},
	}
</script>

<style scoped>
	.Turebtn {
		padding: 10px;
		position:fixed;
		width: 100%;
		bottom: 3px;
	}
</style>