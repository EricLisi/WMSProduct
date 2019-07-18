<template>
	<div>
		<BackTop></BackTop>
		<h2>货位调整</h2>
		<div class="select" @click="popupVisible = true">
			<mt-cell title="选择仓库" is-link>
				<span>{{currentTags?currentTags.text: '请选择仓库'}}</span>
			</mt-cell>
		</div>
		<mt-popup v-model="popupVisible" position="bottom" class="mint-popup">
			<mt-picker :slots="dataList" @change="onDateChange" :visible-item-count="5" :show-toolbar="true" ref="picker1" value-key="text"></mt-picker>
			<!--<mt-button @click="handleConfirm" class="sure">确认</mt-button>-->
		</mt-popup>
		<mt-field class="from" label="货位" v-focus placeholder="请扫描货位" v-model="datas.PosCode" @keyup.enter.native="ScanPoscode()"></mt-field>
		<mt-field class="from" label="数量" placeholder="请输入数量" v-model="datas.QTY"></mt-field>
		<mt-field class="from" label="条码" placeholder="请扫描条码" v-model="datas.BarCode" @keyup.enter.native="ScanBarCode()"></mt-field>
		<hr/>
		<ScanInfoList :InfoList="ScanList" :classNames="nameClass" ></ScanInfoList>

		<div class="button mui-content" v-show="hidshow">
			<div class="boxButton mui-row">
				<div class="checks mui-col-sm-6">
					<mt-checklist align="left" v-model="checkvalue" :options="options">
					</mt-checklist>
				</div>
				<div class="Turebtn mui-col-sm-3">
					<mt-button type="primary" size="large" @click.native="FinishScanList()" class="trues"><i class="fa fa-check"></i>确定</mt-button>
				</div>
				<div class="Turebtncancel mui-col-sm-3">
					<mt-button type="primary" size="large" @click.native="Cancel()" class="cancel"><i class="fa fa-close"></i>取消</mt-button>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
	import { Picker, Toast } from 'mint-ui';
	import BackTop from '@/components/BackTop/index.vue';
	import ScanInfoList from '@/components/ScanInfoList/index.vue';
	import request from '@/utils/request';

	export default {
		name: 'CargoAdjust',
		components: {
			BackTop,
			ScanInfoList
		},
		data() {
			return {
				popupVisible: false,
				dateSlots: [ // 当slots这样定义时，因为tagList是通过api异步请求的，无法正常渲染，出现下图空白
					/* {
					  flex: 1,
					  values: this.$store.state.tagList,
					  className: 'slot1',
					  textAlign: 'center'
						} */
				],
				currentTags: {},
				datas: {
					PosCode: "",
					QTY: 1,
					BarCode: "",
					Warehouse: ""
				},
				tagList: [],
				ScanList: [],
				orderType: "MP",
				orderNo: "",
				checkvalue: [],
				options: [{
					label: '刪除',
					value: '刪除',
					disabled: false
				}, ],
				isfocus: false,
				hidshow:true,
				clientHeight: document.documentElement.clientHeight,
				nameClass:"JaLength"
			}
		},
		created() {
			this.GetScanList()
			this.GetWareHouse()
		},
		methods: {
			GetWareHouse() {
				var _this = this;
				request.get("/api/Search/GetWarSelectList")
					.then(res => {
						if(res.status == 200) {
							_this.tagList = JSON.parse(res.data.message);
						}
					}).catch(err => {
						console.log(err);
					});
			},
			ScanPoscode() {
				this.isfocus = true
			},
			ScanBarCode() {
				var _this = this;
				var BarCode = _this.datas.BarCode
				var PosCode = _this.datas.PosCode
				if(BarCode == "" || PosCode == "") {
					Toast("请扫描完整信息！");
					return false;
				}
				var DeleteMarks;
				if(_this.checkvalue == "") {
					DeleteMarks = false
				} else {
					DeleteMarks = true
				}

				var data = {
					OrderNo: "",
					OrderType: _this.orderType,
					Warehouse: _this.datas.Warehouse,
					Position: _this.datas.PosCode,
					DesPosition: "",
					DesWarehouse: "",
					Barcode: _this.datas.BarCode,
					OperUser: _this.$store.state.user.userAccount,
					Qty: _this.datas.QTY,
					DeleteMark: DeleteMarks
				}
				request.post("/api/app/SaveTempScan", data)
					.then(res => {
						this.GetScanList()
						var resdata = res.data
						if(resdata.result) {　
							//var datas = JSON.parse(resdata.message)
							_this.datas.BarCode = ""
							_this.DeleteMarks = false
							_this.checkvalue = []
						} else {
							Toast(resdata.message);
							_this.datas.BarCode = ""
							_this.DeleteMarks = false
							_this.checkvalue = []
						}
					}).catch(err => {
						console.log(err);
					});
			},
			GetScanList() {
				request.get("/api/app/GetTempScanList/" + this.orderType + "?orderNo=")
					.then(res => {
						var resdata = res.data
						if(resdata.result) {　
							var datas = JSON.parse(resdata.message)
							this.ScanList = datas
						} else {
							Toast(resdata.message);
						}
					}).catch(err => {
						console.log(err);
					});
			},
			onDateChange(picker, values) {
				setTimeout(() => {
					this.datas.Warehouse = this.$refs.picker1.getValues()[0].id
					this.currentTags = this.$refs.picker1.getValues()[0]
				}, 1000)
				//this.popupVisible = false
			},
			Cancel() {
				this.$router.push({
					path: "/Dashboard",
				})
			},
			FinishScanList() {
				var _this = this
				if(_this.ScanList == []) {
					Toast("至少输入一条数据");
					return false;
				} else {
					_this.$router.push({
						path: "/SelectWhPos",
					})
				}
			}
			//handleConfirm () {
			//	this.datas.Warehouse=this.$refs.picker.getValues()[0].id
			//  this.currentTags = this.$refs.picker.getValues()[0]
			//  this.popupVisible = false
			//}
		},
		computed: {
			dataList() {
				let dateSlots = [{
					flex: 1,
					values: this.tagList,
					className: 'slot1',
					textAlign: 'center'
				}];
				return dateSlots
			}
		},
		mounted: function() {
			window.onresize = () => {       
				if(this.clientHeight > document.documentElement.clientHeight) {                
					this.hidshow = false          
				} else {                
					this.hidshow = true   
				}        
			}
		},
		directives: {
			// 注册一个局部的自定义指令 v-focus
			focus: {
				// 指令的定义
				inserted: function(el) {
					// 聚焦元素
					el.querySelector('input').focus()
				}
			},
		},
	}
</script>

<style scoped>
	h2 {
		margin-left: 10px;
		border-top: 1px solid #000000;
		border-bottom: 1px solid #000000;
		text-align: center;
		padding: 10px;
		width: 95%;
	}
	
	.mint-popup {
		width: 100%;
	}
	
	.boxButton {
		width: 100%;
		position: fixed;
		bottom: 0px;
		right: 0px;
		padding-bottom: 0px;
	}
	
	.Turebtn {
		width: 33%;
		padding: 0px 5px;
	}
	
	.checks {
		width: 33%;
	}
	
	.Turebtncancel {
		width: 33%;
		padding: 0px 5px;
	}
</style>