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
	
	const prov = {
		'上海': ['越秀仓', '荔湾仓'],
		'杭州': ['罗湖仓', '宝安仓'],
		'苏州': ['越秀仓2', '荔湾仓2'],
		'江苏': ['罗湖仓2', '宝安仓2']
	}
	export default {
		name: 'UpperShelf',
		components: {
			BackTop,
			TableList
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
					values: ['上海', '杭州', '苏州', '江苏'],
					className: 'slot1',
					textAlign: 'center'
				}, {
					divider: true,
					content: '-',
					className: 'slot2'
				}, {
					flex: 1,
					values: ['越秀仓', '荔湾仓'],
					className: 'slot3',
					textAlign: 'center'
				}],
			}
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
				// 绑定第三个插槽的值
				picker.setSlotValues(1, prov[values[0]])
				this.datas.Warehouse = values[0]
				this.datas.CargoLocation=values[1]
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