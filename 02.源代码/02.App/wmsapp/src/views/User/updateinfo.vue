<template>
	<div>
		<mt-header title="WMS管理系统">
			<router-link to="/UserInfo" slot="left">
				<mt-button icon="back"></mt-button>
			</router-link>
		</mt-header>
		<mt-field label="用户名" placeholder="请输入用户名" v-model="users.username"></mt-field>
		<mt-field label="真实姓名" placeholder="请输入真实姓名" v-model="users.username"></mt-field>
		<mt-field label="性别" placeholder="请输入性别" v-model="users.usersex"></mt-field>
		<mt-field label="电话" placeholder="请输入电话" v-model="users.userphone"></mt-field>
		<mt-field label="权限" placeholder="请输入权限" v-model="users.userauth"></mt-field>
		<mt-field label="公司" placeholder="请输入公司" v-model="users.usercompany"></mt-field>
		<mt-field label="部门" placeholder="请输入部门" v-model="users.userdepm"></mt-field>
		<div class="btnstyle">
			<mt-button type="primary" size="large" @click="UpdateInfo()">确认修改</mt-button>
		</div>
	</div>
</template>

<script>
	export default {
		components: {
		},
		data() {
			return {
				users:{
					username:"",
					usersex:"",
					userphone:"",
					userauth:"",
					usercompany:"",
					userdepm:"",
				}
			}
		},
		created() {
			this.getInfo()
		},
		methods: {
			//获取当前用户信息
			getInfo:function(){
				request.post("/api/GetInfo", _this.users)
					.then(res => {
						if(res.status == 200) {　
							users.username=res.data.F_UserName;
							users.usersex=res.data.F_UserSex;
							users.userphone=res.data.F_UserPhone;
							users.userauth=res.data.F_UserAuth;
							users.usercompany=res.data.F_Usercompany;
							users.userdepm=res.data.F_depm;
						}
					}).catch(err => {
						console.log(err);
					});
			},
			//修改用户信息
			UpdateInfo:function(){
				request.post("/api/UpdateInfo", _this.users)
					.then(res => {
						if(res.status == 200) {　
							Toast('修改成功！');
						}
					}).catch(err => {
						console.log(err);
					});
			}
		}
	}
</script>

<style scoped>
.btnstyle{
	margin-top: 20px;
    padding: 10px;
}
</style>