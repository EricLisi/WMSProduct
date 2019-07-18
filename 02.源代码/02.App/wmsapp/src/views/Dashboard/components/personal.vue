<template>
	<div>
		<BackTop></BackTop>
		<div class="app-container">
			<div class="userIcon">
				<img src="../../../assets/user.png" alt="">
			</div>
			<mt-cell title="个人信息" label="查看个人信息" to="/UserInfo" is-link @click.native="goRouter('personal')"> </mt-cell>
			<mt-cell title="修改密码" label="修改用户密码" to="/ChangePwd" is-link @click.native="goRouter('personal')"> </mt-cell>
			<div class="exitMenu">
				<mt-button type="danger" size="large" @click.native="logout()">退出登陆</mt-button>
			</div>

		</div>
	</div>

</template>

<script>
	import {
		MessageBox
	} from 'mint-ui';
	import BackTop from '@/components/BackTop/index.vue';
	export default {
		components: {
			BackTop,
		},
		data() {
			return {

			}
		},
		methods: {
			//返回个人中心
			goRouter: function(currentParentRouter) {
				localStorage.setItem('parent', 'System')
			},
			logout: function() {
				var _this=this
				_this.$store.dispatch('LogOut').then(() => {
				})	
				MessageBox.confirm('是否确定退出登陆?').then(action => {
					_this.$router.push({
						path: '/Login'
					})
				});
			}
		}
	}
</script>

<style scoped>
	.userIcon {
		margin: 20px auto;
		text-align: center
	}
	
	.userIcon img {
		border: 4px solid #2f98fa;
		border-radius: 50%;
		margin-top: 10px;
		width: 120px;
		height: 120px;
	}
	
	.exitMenu {
		margin-top: 20px;
		padding: 10px;
	}
</style>