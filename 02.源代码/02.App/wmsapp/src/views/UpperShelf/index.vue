<template>
	<div>
		<BackTop></BackTop>
		<section>
			<mt-cell title="仓库" @click.native="popUp('Warehouse')" value="选择仓库">
				{{datas.Warehouse}}
			</mt-cell>
			<mt-popup position="bottom" v-model="areaSwitch">
				<mt-picker :slots="areaPicker" @change="areaChange"></mt-picker>
			</mt-popup>
		</section>

		<mt-field class="from" label="货位" placeholder="货位" v-model="datas.CargoLocation"></mt-field>
		<mt-field class="from" label="条码" placeholder="条码" v-model="datas.Barcode" @keyup.enter.native="ScanBarCode()"></mt-field>
		<mt-field class="from" label="数量" placeholder="数量" v-model="datas.Maker"></mt-field>
		<hr/>
		<TableList></TableList>

		<div class="Turebtn">
			<mt-button type="primary" size="large" @click.native="Finish()">完成</mt-button>
		</div>
	</div>
</template>

<script>
	import BackTop from '@/components/BackTop/index.vue';
	import TableList from '@/components/TableList/index.vue';
	import request from '@/utils/request';
	
	export default {
		name: 'UpperShelf',
		components: {
			BackTop,
			TableList,
		},
		data() {
			return {
				datas: {
					Barcode: "",
					CargoLocation: "",
					Warehouse: "",
					Maker: "",
					Type: "",
					Date: "",
					Notes: "",
				},
				areaSwitch: false,
				areaPicker: [{
					flex: 1,
					values: [''],//id
					className: 'slot1',
					textAlign: 'center',
				}],
			}
		},
		created(){
			this.GetWareHouse();
		},
		methods: {
			popUp(type) {
				switch(type) {
					case 'Warehouse':
						this.areaSwitch = true
						break
				}
			},
			areaChange(picker, values) {
				this.datas.Warehouse = values[0]
			},
			GetWareHouse() {
				var _this = this;
				request.get("/api/User/")
					.then(res => {
						console.log(res)
						this.areaPicker.values=res.data;
					}).catch(err => {
						console.log(err);
					});
			},
		},
		mounted: function() {

		}
	}
</script>

<style>
	table {
		width: 95%;
		margin: 0px 8px;
		/*border: 1px solid #e8e8e8;*/
	}
	
	.mint-popup {
		width: 100%;
	}
	
	.Turebtn{
		padding: 15px;
	}
</style>