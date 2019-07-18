<template>
	<div>
		<ScanOrder :OrderType="OrderType" :RouterPath="RouterPath" :Title="title"></ScanOrder>
	</div>
</template>

<script>
	import ScanOrder from '@/components/ScanOrder/index.vue';
	
	export default {
		name: 'Inventory',
		components: {
			ScanOrder
		},
		data() {
			return {
				title:"仓库盘点",
				OrderType: "CW",
				RouterPath: "/CWScanStock",
			}
		},
		methods: {
			
		},
		mounted: function() {

		}
	}
</script>

<style>
    .mint-popup {
		width: 100%;
	}
	
	.Turebtn {
		padding: 15px;
	}
</style>