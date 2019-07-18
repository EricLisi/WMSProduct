<template>
	<div  class="mui-content">
		<mt-header title="WMS管理系统">
			<router-link to="/Personal" slot="left">
				<mt-button icon="back"></mt-button>
			</router-link>
		</mt-header>
		<mt-cell title="账号" v-model="info.Account"></mt-cell>
		<mt-cell title="姓名" v-model="info.RealName"></mt-cell>
		<mt-cell title="性别" v-model="info.Gender"></mt-cell>
		<mt-cell title="电话" v-model="info.Mobile"></mt-cell>
		<mt-cell title="公司" v-model="info.CompanyName"></mt-cell>
		<mt-cell title="部门" v-model="info.DepartmentName"></mt-cell>
		<mt-cell title="岗位" v-model="info.DutyName"></mt-cell>
		<mt-cell title="角色" v-model="info.RoleName"></mt-cell>
		<mt-cell title="仓库" v-model="info.WareHouse"></mt-cell>
		<!--<mt-cell title="修改资料" label="修改用户信息" to="/updateinfo" is-link class="upinfo"> </mt-cell>-->
	</div>
</template>

<script>
	import request from '@/utils/request'
	export default {
		components: {
			
		},
		data() {
			return {
				info: {
					Account: null,
					RealName:null,
					Gender: null,
					Mobile: null,
					CompanyName: null,
					DepartmentName: null,
					RoleName: null,
					WareHouse:null,
					DutyName:null,
				}
			}
		},
		created() {
			this.GetUserInfo()
		},
		methods: {
			GetUserInfo() {
				var _this = this;
				var id =localStorage.getItem('userid')
				//获取用户信息
				request.get("/api/User/GetUserById/" + id)
					.then(res => {
						var datas= res.data
						_this.info.Account=datas.F_Account
						_this.info.RealName=datas.F_RealName
						_this.info.Gender=datas.F_Gender?"男":"女"
						_this.info.Mobile=datas.F_MobilePhone
						_this.info.CompanyName=datas.F_OrganizeName
						_this.info.DepartmentName=datas.F_DepartmentName
						_this.info.WareHouse=datas.F_WarehouseName
						_this.info.DutyName=datas.F_DutyName
						_this.info.RoleName=datas.F_RoleName
						
						
//						if(res.data.Gender == "1") {
//							_this.info.Gender = "男"
//						} else {
//							_this.info.Gender = "女"
//						}
//						_this.info.RealName=res.data.RealName
//						_this.info.Mobile = res.data.Mobile
//						_this.info.CompanyId = res.data.CompanyId
//						_this.info.DepartmentId = res.data.DepartmentId
					}).catch(err => {
						console.log(err);
					});
			}
		}
	}
</script>

<style scoped>
	.upinfo {
		margin-top: 30px;
	}
</style>