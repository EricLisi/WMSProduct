<template>
	<div>
		<mt-header title="WMS管理系统">
			<router-link to="/SingleOut" slot="left">
				<mt-button icon="back"></mt-button>
			</router-link>
		</mt-header>
		<ScanBarcode></ScanBarcode>
	</div>
</template>

<script>
	import ScanBarcode from '@/components/ScanBarcode/index.vue';
	
	export default {
		components: {
			ScanBarcode
		},
		data() {
			return {
				
			}
		},
		methods: {
			
		}
	}
</script>

<style>
</style>