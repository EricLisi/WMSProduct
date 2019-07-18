/**
 * 登陆api
 */
import request from '@/utils/request'
import md5 from 'js-md5';

/**
 * 登陆系统
 * @param {string} username 用户名
 * @param {string} password 密码
 */
export function login(username, password) {
	//加密密码
	var md5pwd = !!password ? md5(password) : ""
	const data = {
		Account: username,
		Password: password
	}
	return request({
		url: '/api/User/GetCurrentUser',
		method: 'post',
		data
	})
}
