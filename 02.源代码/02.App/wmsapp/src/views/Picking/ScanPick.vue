<template>
	<div>
		<mt-header title="WMS管理系统">
			<router-link to="/Picking" slot="left">
				<mt-button icon="back"></mt-button>
			</router-link>
		</mt-header>
		<mt-field class="from" label="条码" placeholder="条码" v-model="instock.Barcode" @keyup.enter.native="ScanBarCode()"></mt-field>
		<!--<mt-field class="from" label="货位" placeholder="货位" v-model="instock.Supplier"></mt-field>-->
		<mt-field class="from" label="数量" placeholder="数量" v-model="instock.Maker"></mt-field>
		<hr/>
		<TableList></TableList>
		<div class="Turebtn">
			<mt-button type="primary" size="large" @click.native="Finish()">完成</mt-button>
		</div>
	</div>
</template>

<script>
	import TableList from '@/components/TableList/index.vue';
	
	export default {
		components: {
			TableList,
		},
		data() {
			return {
				instock: {
					Barcode: "",
					CargoLocation: "",
					Supplier: "",
					Maker: "",
					Type: "",
					Date: "",
					Notes: "",
				},
				areaSwitch: false,
				areaPicker: [{
					flex: 1,
					values: ['谢谢仓', '高考仓'],
					className: 'slot1',
					textAlign: 'center'
				}],
			}
		},																									
		methods: {
			Finish() {
				this.$router.push({
					path: '/SingleEntry'
				})
			},
			popUp(type) {
					switch(type) {
						case 'CargoLocation':
							this.areaSwitch = true
							break
					}
				},
				areaChange(picker, values) {
					this.$data.instock.CargoLocation = values[0]
				},
			ScanBarCode() {
				alert(this.instock.Barcode)
			}
		}
	}
</script>

<style>
	table {
		width: 95%;
		margin: 8px;
		/*border: 1px solid #e8e8e8;*/
	}
	.mint-popup {
		width: 100%;
	}
	
	.Turebtn {
		padding: 10px;
	}
</style>