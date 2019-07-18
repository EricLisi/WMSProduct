<template>
	<div>
		<BackTop></BackTop>
		<section>
			<mt-cell title="单据号" @click.native="popUp('DocuNum')" value="选择单据号">
				{{instock.DocuNum}}
			</mt-cell>
			<mt-popup position="bottom" v-model="areaSwitch">
				<mt-picker :slots="areaPicker" @change="areaChange"></mt-picker>
			</mt-popup>
		</section>
		<mt-field class="from" label="供应商" placeholder="供应商" v-model="instock.Customer" disabled></mt-field>
		<mt-field class="from" label="制单人" placeholder="制单人" v-model="instock.Maker" disabled> </mt-field>
		<section>
			<mt-cell title="出入类别" @click.native="popUp('Type')" value="选择出入类别">
				{{instock.Type}}
			</mt-cell>
			<mt-popup position="bottom" v-model="typeSwitch">
				<mt-picker :slots="typePicker" @change="typeChange"></mt-picker>
			</mt-popup>
		</section>
		<!--<mt-field class="from" label="出入类别" placeholder="出入类别" v-model="instock.Type"></mt-field>-->
		<section>
			<mt-cell title="日期" @click.native="open('picker1')" value="选择日期">{{instock.Date}}</mt-cell>
			<mt-datetime-picker ref="picker1" v-model="dataVal" type="date" year-format="{value} 年" month-format="{value} 月" :startDate="startDate" date-format="{value} 日" @confirm="handleChange">
			</mt-datetime-picker>
		</section>
		<mt-field class="from" label="备注" placeholder="备注" v-model="instock.Notes"></mt-field>

		<div class="Turebtn">
			<mt-button type="primary" size="large" @click.native="Sure()">确定</mt-button>
		</div>
		<!--<mt-navbar>
			<mt-tab-item id="1" @click.native.prevent="active = 'tab-container1'">待入库</mt-tab-item>
			<mt-tab-item id="2" @click.native.prevent="active = 'tab-container2'">已入库</mt-tab-item>
		</mt-navbar>
		<mt-tab-container class="page-tabbar-tab-container" v-model="active" swipeable>
			<mt-tab-container-item id="tab-container1">

				<table border="1" cellspacing="0" cellpadding="0"> 
					<tr>
						<td>商品编码</td>
						<td>数量</td>
						<td>单位</td>
					</tr>
					<tr>
						<td>香蕉</td>
						<td>12</td>
						<td>kg</td>
					</tr>
				</table>
				
				<div class="r">
					<mt-button type="primary" size="large" class="btnin">确认入库</mt-button>
				</div>
			</mt-tab-container-item>
			<mt-tab-container-item id="tab-container2">
				<table border="1" cellspacing="0" cellpadding="0"> 
					<tr>
						<td>商品编码</td>
						<td>数量</td>
						<td>单位</td>
					</tr>
					<tr>
						<td>橘子</td>
						<td>2</td>
						<td>箱</td>
					</tr>
				</table>
			</mt-tab-container-item>
		</mt-tab-container>-->

	</div>
</template>

<script>
	import BackTop from '@/components/BackTop/index.vue';
	import { Navbar, TabItem } from 'mint-ui';
	import request from '@/utils/request';
	
	export default {
		name: 'SingleEntry',
		components: {
			BackTop,
			Navbar,
			TabItem
		},
		data() {
			return {
				instock: {
					DocuNum: "",
					Warehouse: "",
					Customer: "",
					Maker: "",
					Type: "",
					Date: "请选择日期",
					Notes: "",
				},
				areaSwitch: false,
				areaPicker: [{
					flex: 1,
					// 只填写直观显示的第一个插槽的‘省’数组，实际上是由addrChange方法和‘省’数组带动
					values: ['请选择', 'Out201812280001-客户', 'Out201812280002-人肉人'],
					className: 'slot1',
					textAlign: 'center'
				}],
				typeSwitch: false,
				typePicker: [{
					flex: 1,
					values: ['请选择出入类别', '出库', '入库'],
					className: 'slot1',
					textAlign: 'center'
				}],
				dataVal: new Date(),
				startDate: new Date('2019-01-01'),
			}
		},
		created() {
			this.GetMaker();
		},
		methods: {
			InStock: function() {
				var _this = this;
				request.post("/api/Instock", _this.instock)
					.then(res => {
						if(res.status == 200) {　
							Toast('入库成功！');
						}
					}).catch(err => {
						console.log(err);
					});
			},
			open(picker) {
				this.$refs[picker].open();
			},
			handleChange(value) {
				this.instock.Date = this.formatDate(value)
			},
			formatDate(date) {
				const y = date.getFullYear()
				let m = date.getMonth() + 1
				m = m < 10 ? '0' + m : m
				let d = date.getDate()
				d = d < 10 ? ('0' + d) : d
				return y + '-' + m + '-' + d
			},
			GetMaker() {
				var _this = this;
				var id = _this.$store.state.user.userid
				request.get("/api/User/" + id)
					.then(res => {

						_this.instock.Maker = res.data.Account

					}).catch(err => {
						console.log(err);
					});
			},
			popUp(type) {
				switch(type) {
					case 'DocuNum':
						this.areaSwitch = true
						break;
					case 'Type':
						this.typeSwitch = true
						break
				}
			},
			areaChange(picker, values) {
				var arr = values[0].split("-");
				this.$data.instock.DocuNum = arr[0]
				this.$data.instock.Warehouse = arr[1]
				this.$data.instock.Supplier = arr[2]
			},
			typeChange(picker, values) {
				this.$data.instock.Type = values[0]
			},
			Sure() {
				this.$router.push({
					path: '/ScanPick'
				})
			}
		},
		mounted: function() {

		},
	}
</script>

<style scoped>
	.r {
		width: 40%;
		position: fixed;
		bottom: 0;
		right: 0;
	}
	
	.btnin {
		border-radius: 0px;
	}
	
	table {
		width: 95%;
		margin: 0px 8px;
		/*border: 1px solid #e8e8e8;*/
	}
	
	.mint-popup {
		width: 100%;
	}
	
	.Turebtn {
		padding: 15px;
	}
</style>