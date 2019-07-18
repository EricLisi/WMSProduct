<template>
	<div class="container">
		<div class="logo">
			<img src="../../assets/logo.jpg" alt="">
			<h3>WMS管理系统</h3>
			<h6 class="right">version 1.0.0</h6>
		</div>
		<div class="form">
			<mt-field placeholder="用户名"  v-focus v-model="user.account"></mt-field>
			<mt-field type="password" placeholder="密码" v-model="user.password" @keyup.enter.native="login()"></mt-field>

			<div class="loginbtn">
				<mt-button type="primary" size="large" @click.native="login()">登陆</mt-button>
				<a href="#" v-show="bConnection" @click="setConnection()">参数设置</a>
			</div>

			<div class="error">
				{{errorinfo}}
			</div>
		</div>
		<div class="footer">
			<p>上海金戈马软件有限公司</p>
			<p>&copy;2018</p>
		</div>
	</div>
</template>

<script>
	import { login } from '@/api/login'
	import request from '@/utils/request'
	import { Toast, MessageBox } from 'mint-ui';

	export default {
		data() {
			return {
				user: {
					account: "",
					password: ""
				},
				errorinfo: "",
				redirect: undefined,
				bConnection: false
			}
		},
		watch: {
			$route: {
				handler: function(route) {
					this.redirect = route.query && route.query.redirect
				},
				immediate: true
			},
			"user.account": {
				handler: function(newVal, oldVal) {
					if(newVal == "kgmadmin") {
						this.bConnection = true;
						localStorage.setItem('apiaddress', process.env.BASE_API)
					} else {
						this.bConnection = false;
					}
				}
			}
		},
		methods: {
			setConnection: () => {
				MessageBox.prompt('请输入服务器地址', {
					inputValue: localStorage.getItem('apiaddress')
				}).then(({
					value,
					action
				}) => {
					if(action == 'confirm') {
						localStorage.setItem('apiaddress', value)
//						this.$store.commit('SET_Api', value)
					}
				});
			},
			login: function(ev) {
				var _this = this;
				request.get("/api/User/Text")
					.then(res => {
						var datas = res.data
						if(datas == "ok") {
							_this.errorinfo = ""
							setTimeout(() => {
								try {
									if(!!!_this.user.account) {
										_this.errorinfo = "用户名不能为空"
										return false;
									}
									if(!!!_this.user.password) {
										_this.errorinfo = "密码不能为空"
										return false;
									}

									const data = {
										username: _this.user.account,
										password: _this.user.password
									}
									_this.$store.dispatch('Login', data).then((res) => {
										_this.$router.push({
											path: _this.redirect || '/Dashboard'
										})
									}).catch((res) => {
										console.log(res)
										Toast(res)
									})
								} catch(e) {
									_this.errorinfo = e;
								}
							}, 200);
						} else {
							MessageBox.prompt('请输入服务器地址', {
								inputValue: localStorage.getItem('apiaddress')
							}).then(({
								value,	
								action
							}) => {
								if(action == 'confirm') {
									localStorage.setItem('apiaddress', value)
									this.$store.commit('SET_Api', value)
								}
							});
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

<style scoped>
	.container {
		background: #ffffff;
		width: 100%;
		height: 100%;
		top: 0px;
		left: 0px;
		position: absolute;
	}
	
	.logo {
		text-align: center;
		background: #2f98fa;
		width: 100%;
		height: 35%;
		color: #ffffff;
		font-size: 28px;
	}
	
	.logo h3 {
		margin-top: 0px;
	}
	
	.logo img {
		margin-top: 16%;
	}
	
	.logo .right {
		float: right;
		margin-right: 15px;
		font-size: 10px;
	}
	
	.form {
		margin: auto 0;
		padding: 25px;
	}
	
	.form .error {
		margin-top: 10px;
		color: #ff0000;
		text-align: center;
		font-size: 14px;
		word-wrap: break-word;
		padding: 5px;
	}
	
	.form .loginbtn {
		margin-top: 50px;
		padding: 10px;
		text-align: center;
	}
	
	.form .loginbtn a {
		display: block;
		margin-top: 10px;
	}
	
	.footer {
		position: absolute;
		bottom: 50px;
		width: 100%;
		color: #b3acac;
		text-align: center;
		font-size: 14px;
	}
</style>