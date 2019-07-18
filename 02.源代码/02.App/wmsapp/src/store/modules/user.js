import { login } from '@/api/login'
import { Toast } from 'mint-ui';

const user = {
	state: {
		user: '',
		status: '',
		code: '',
		token: '',
		name: '',
		avatar: '',
		introduction: '',
		roles: [],
		setting: {
			articlePlatform: []
		},
		api:''
	},
	mutations: {
		SET_CODE: (state, code) => {
			state.code = code
		},
		SET_TOKEN: (state, token) => {
			state.token = token
			sessionStorage.token = token
			localStorage.token = token
		},
		DEL_TOKEN(state) {
			sessionStorage.removeItem('token')
		},
		SET_INTRODUCTION: (state, introduction) => {
			state.introduction = introduction
		},
		SET_SETTING: (state, setting) => {
			state.setting = setting
		},
		SET_STATUS: (state, status) => {
			state.status = status
		},
		SET_NAME: (state, name) => {
			state.name = name
		},
		SET_AVATAR: (state, avatar) => {
			state.avatar = avatar
		},
		SET_ROLES: (state, roles) => {
			state.roles = roles
		},
		SET_UserId: (state, userid) => {
			state.userid = userid
			localStorage.userid = userid
		},
		SET_UserAccount: (state, userAccount) => {
			state.userAccount = userAccount
		},
		SET_Api: (state, api) => {
			state.api = api
			localStorage.api = api
		}
	},

	actions: {
		// 用户名登录
		Login({
			commit
		}, userInfo) {
			const username = userInfo.username
			return new Promise((resolve, reject) => {
				login(username, userInfo.password).then(response => {
					const data = JSON.parse(response.data)
					if(data.status) {
						commit('SET_TOKEN', data.token)
						commit('SET_UserId', data.User.F_Id)
						commit('SET_UserAccount', data.User.F_Account)
						//commit('SET_UserId', data.Id)
						//setToken(response.data.token)
						resolve()
					} else {
						Toast(data.token)
					}
				}).catch(error => {
					reject(error)
				})
			})
		},
		// 登出
		LogOut({
			commit,
			state
		}) {
			return new Promise((resolve, reject) => {
				commit('SET_TOKEN', '')
				user.mutations.DEL_TOKEN()
			})
		},

	}
}

export default user