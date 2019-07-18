<template>
	<div>
		<BackTop></BackTop>
		<mt-field label="单据号" placeholder="请扫描单据号" v-model="instock.DocuNum"></mt-field>
		<mt-field label="物料条码" placeholder="请扫描物料条码" v-model="instock.MatterCode"></mt-field>
		<mt-field label="物料名称" placeholder="请输入物料名称" v-model="instock.Matter"></mt-field>
		<mt-field label="入库数量" placeholder="请输入入库数量" type="number" v-model="instock.Num"></mt-field>
		<div class="btnstyle">
			<mt-button type="primary" size="large">确认入库</mt-button>
		</div>
	</div>
</template>

<script>
	import BackTop from '@/components/BackTop/index.vue';

	export default {
		name: 'OtherEntry',
		components: {
			BackTop
		},
		data() {
			return {
				instock:{
					DocuNum:"",
					MatterCode:"",
					Matter:"",
					Num:"",
				}
			}
		},
		methods: {

		},
		mounted: function() {

		}
	}
</script>

<style scoped>
.btnstyle{
	margin-top: 20px;
    padding: 10px;
}
</style>