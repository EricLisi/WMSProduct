import Vue from 'vue'
import Router from 'vue-router'
Vue.use(Router)

export default new Router({
	routes: [{
	      path: '/',
	      redirect:'/login',
	    },{
			path: '/Login',
			name: 'Login',
			component: () =>
				import('@/views/Login/index')
		},
		{
			path: '/Personal', //个人中心
			name: 'Personal',
			component: () =>
				import('@/views/Dashboard/components/personal')
		},
		{
			path: '/UserInfo',
			name: 'UserInfo', //用户信息
			component: () =>
				import('@/views/User/info')
		},
		{
			path: '/ChangePwd',
			name: 'ChangePwd', //修改密码
			component: () =>
				import('@/views/User/password')
		},
		{
			path: '/Dashboard',
			name: 'Dashboard',
			component: () =>
				import('@/views/Dashboard/index')
		}, {
			path: '/OtherEntry',
			name: 'OtherEntry', //按单入库
			component: () =>
				import('@/views/InStock/OtherEntry')
		}, {
			path: '/ScanInStock',
			name: 'ScanInStock', //扫描单子
			component: () =>
				import('@/views/InStock/ScanInStock')
		}, {
			path: '/SingleOut',
			name: 'SingleOut', //按单出库
			component: () =>
				import('@/views/OutStock/SingleOut')
		}, {
			path: '/SingleEntry',
			name: 'SingleEntry', //按单入库
			component: () =>
				import('@/views/InStock/SingleEntry')
		},  {
			path: '/ScanOutStock',
			name: 'ScanOutStock', //其他出库
			component: () =>
				import('@/views/OutStock/ScanOutStock')
		}, {
			path: '/CargoAdjust',
			name: 'CargoAdjust', //货位调整
			component: () =>
				import('@/views/Stock/CargoAdjust')
		}, {
			path: '/Inventory',
			name: 'Inventory', //仓库盘点
			component: () =>
				import('@/views/Stock/Inventory')
		}, {
			path: '/CWScanStock',
			name: 'CWScanStock', //仓库盘点
			component: () =>
				import('@/views/Stock/CWScanStock')
		}, {
			path: '/updateinfo',
			name: 'updateinfo', //修改用户信息
			component: () =>
				import('@/views/User/updateinfo')
		}, {
			path: '/Picking',
			name: 'Picking', //按单拣货
			component: () =>
				import('@/views/Picking/index')
		}, {
			path: '/ScanPick',
			name: 'ScanPick', //扫描拣货
			component: () =>
				import('@/views/Picking/ScanPick')
		}, {
			path: '/UpperShelf',
			name: 'UpperShelf', //自由上架
			component: () =>
				import('@/views/UpperShelf/index')
		}, {
			path: '/SelectWhPos',
			name: 'SelectWhPos', //选择目标货位 仓库
			component: () =>
				import('@/views/Stock/SelectWhPos')
		}
	]
})
