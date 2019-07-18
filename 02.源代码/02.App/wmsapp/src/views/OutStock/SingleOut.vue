<template>
	<div>
		<ScanOrder :OrderType="OrderType" :RouterPath="RouterPath" :Title="title"></ScanOrder>
	</div>
</template>

<script>
	import ScanOrder from '@/components/ScanOrder/index.vue';
	import request from '@/utils/request';
	
	export default {
		name: 'SingleOut',
		components: {
			ScanOrder,
			request
		},
		data() {
			return {
				OrderNo: "",
				title:"出库扫描",
				OrderType:"SO",
				RouterPath:"/ScanOutStock"
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