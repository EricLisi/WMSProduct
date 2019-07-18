<template>
	<div>
		<BackTop></BackTop>
		<mt-field label="单据号" placeholder="请扫描单据号" v-model="outstock.DocuNum"></mt-field>
		<mt-field label="物料条码" placeholder="请扫描物料条码" v-model="outstock.MatterCode"></mt-field>
		<mt-field label="物料名称" placeholder="请输入物料名称" v-model="outstock.Matter"></mt-field>
		<mt-field label="出库数量" placeholder="请输入出库数量" type="number" v-model="outstock.Num"></mt-field>
		<div class="btnstyle">
			<mt-button type="primary" size="large" @click="OutStock()">确认出库</mt-button>
		</div>
	</div>
</template>

<script>
	import BackTop from '@/components/BackTop/index.vue';

	export default {
		name: 'SingleOut',
		components: {
			BackTop
		},
		data() {
			return {
				outstock: {
					DocuNum: "",
					MatterCode: "",
					Matter: "",
					Num: "",
				}
			}
		},
		methods: {
			OutStock: function() {
				var _this = this;
				request.post("/api/outstock", _this.outstock)
					.then(res => {
						if(res.status == 200) {　
							Toast('出库成功！');
						}
					}).catch(err => {
						console.log(err);
					});
			}
		},
		mounted: function() {

		}
	}
</script>

<style>

</style>