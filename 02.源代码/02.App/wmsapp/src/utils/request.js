/**
 * ajax请求封装
 */
import axios from 'axios'
import store from '@/store'
//import { getToken } from '@/utils/auth'

// 创建请求对象实例
const service = axios.create({
	baseURL: localStorage.getItem('apiaddress'), // api 的 base_url 
	timeout: 5000 // 超时设置
})

// 请求的配置
service.interceptors.request.use(
	config => {
		if(localStorage.getItem('apiaddress')){
			config.baseURL = localStorage.getItem('apiaddress');
		}
		
		// Do something before request is sent
		//       if (store.getters.token) {
		//         // 让每个请求携带token-- ['X-Token']为自定义key 请根据实际情况自行修改
		//         config.headers['X-Token'] = getToken()
		//       }
		if(store.getters.token) {
			// 让每个请求携带token-- ['X-Token']为自定义key 请根据实际情况自行修改
			//config.headers['X-Token'] = getToken()
			config.headers['Authorization'] = "Bearer "+store.getters.token
		}
		return config
	},
	error => {
		console.log(error) // for debug 
	}
)



// response interceptor
service.interceptors.response.use(
	response => response,
	error => {
		console.log('err' + error) // for debug  
		return false
	}
)

export default service