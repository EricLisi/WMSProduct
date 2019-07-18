/*
 * 主页面
 */
var loaddfimg;
(function ($, app) {
	"use strict";
	/**
	 * 页面事件
	 */
	var page = {
		init: function () {
			try {
				page.platformInit();
				page.GlobeInit();
				page.userInit();
				page.fullScreenInit();
				page.leftmenu.init();
				// page.Heart();
				// $(window).load(function () {
				// 	window.setTimeout(function () {
				// 		$('#app-loading').fadeOut();
				// 	}, 300);
				// });
			} catch (ex) {
				window.location.href = 'login.html'
			} finally {
				window.setTimeout(function () {
					$('#app-loading').fadeOut();
				}, 300);
			}
		},
		/*
		 * 心跳机制
		 */
		Heart: function () {
			window.setInterval(function () {
				var param = {
					"Id": app.APP_GLOBE_STORE.LOGIN_USER.Id,
					"Account": app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.LOGIN_USER
				};
				app.HTTP_REQUEST_UTILS.httpAsyncPost('/api/Login/RepeatAuthToken', param,
					function (data) {
						if (data.Status) {
							//将TOKEN记录到临时存储
							app.LOCAL_STORE_UTILS.set(app.APP_CONFIGRATION.LOCAL_STORE_CONFIG.TOKEN, data.Message);
							window.location.href = "index.html"
						}
					}, )

			}, app.APP_CONFIGRATION.API_CONFIG.HEART_TIMEOUT * 1000 * 60)
		},
		/**
		 * 初始化GlobeStore
		 */
		GlobeInit: function () {
			app.APP_GLOBE_STORE_UTILS.init();
		},
		/**
		 * 平台设置初始化
		 */
		platformInit: function () {
			if (!!!app.LOCAL_STORE.LOGIN_PLATFORM) {
				window.location.href = 'login.html'
				return false;
			}
			$("#loginsystem").text(app.LOCAL_STORE.LOGIN_PLATFORM.PLATFORM_NAME);
		
			
			if (app.LOCAL_STORE.LOGIN_PLATFORM.PLATFORM_HOMEPAGE_URL) {
				// 打开首页模板
				app.frameTab.open({
					Id: '0',
					Icon: 'fa fa-desktop',
					FullName: '欢迎首页',
					UrlAddress: "Dashboard/html/" + app.LOCAL_STORE.LOGIN_PLATFORM.PLATFORM_HOMEPAGE_URL
				}, true);
			}
		},
		/**
		 * 登录头像和个人设置
		 */
		userInit: function (platform) {
			$("#currentUser").text(app.APP_GLOBE_STORE.LOGIN_USER.FullName)
			$('#app_loginout_btn').on('click', page.loginout);
			$('#app_userinfo_btn').on('click', page.openUserCenter);
		},
		loginout: function () { // 安全退出        	
			app.MODAL_UTILS.confirm({
				msg: "是否确定退出系统?",
				callback: function () {
					//清空登录缓存
					app.LOCAL_STORE_UTILS.clear();
					//跳转到登录页面
					window.location.href = "login.html"
				}
			})
		},
		/**
		 * 用户中心事件
		 */
		openUserCenter: function () {
			// 打开个人中心
			//			app.frameTab.open({
			//				Id: '1',
			//				Icon: 'fa fa-user',
			//				FullName: '修改密码',
			//				UrlAddress: '/UserCenter/Index'
			//			});	
			//修改密码
			layx.iframe('1', '修改密码', 'src/views/SystemManage/User/html/RevisePassword.html', {
				shadable: true,
				statusBar: true,
				height: 100,
				width: 350,
				buttons: [{
						label: '<i class="fa fa-save" style="margin-right:5px"></i>保存',
						callback: function (id, button, event) {
							var win = layx.getFrameContext('1');
							win.acceptClick();
							layx.destroy(id);
						},
						classes: ['btn-primary']
					},
					{
						label: '<i class="fa fa-close" style="margin-right:5px"></i>取消',
						callback: function (id, button, event) {
							layx.destroy(id);
						},
						classes: ['btn-danger']

					}
				]
			});
		},
		/**
		 * 全屏按钮
		 */
		fullScreenInit: function () {
			$('#btnfullscreen').on('click', function () {
				if (!$(this).attr('fullscreen')) {
					$(this).attr('fullscreen', 'true');
					page.requestFullScreen();
				} else {
					$(this).removeAttr('fullscreen');
					page.exitFullscreen();
				}
			});
		},
		/**
		 * 进入全屏
		 */
		requestFullScreen: function () {
			var de = document.documentElement;
			if (de.requestFullscreen) {
				de.requestFullscreen();
			} else if (de.mozRequestFullScreen) {
				de.mozRequestFullScreen();
			} else if (de.webkitRequestFullScreen) {
				de.webkitRequestFullScreen();
			}
		},
		/**
		 * 退出全屏
		 */
		exitFullscreen: function () {
			var de = document;
			if (de.exitFullscreen) {
				de.exitFullscreen();
			} else if (de.mozCancelFullScreen) {
				de.mozCancelFullScreen();
			} else if (de.webkitCancelFullScreen) {
				de.webkitCancelFullScreen();
			}
		},
		/**
		 * 左侧菜单对象
		 */
		leftmenu: {
		
			/**
			 * 默认父节点id为0
			 */
			parentId: '0',
			/**
			 * 菜单数据
			 */
			menuData: undefined,
			/**
			 * 菜单初始化
			 */
			init: function () {
				page.leftmenu.menuData = app.APP_GLOBE_STORE.LOGIN_USER_MODULE; 
				page.leftmenu.load();
				page.leftmenu.bind();
			},
			/**
			 * 根据id获取菜单的信息  
			 * @param {string} id 当前id
			 */
			getMenuData: function (id) {
				var data = page.leftmenu.menuData;
				//alert(JSON.stringify(data))              
				var module = undefined;
				for (var i = 0; i < data.length; i++) {
					if (data[i].moduleid == id) {
						//alert(data[i].UrlAddress)
						module = {
							Id: data[i].moduleid,
							Icon: data[i].moduleicon,
							FullName: data[i].modulefullname,
							UrlAddress: data[i].moduleurladdress,
							Target: data[i].moduletarget
						}
						break;
					}
				}
				return module;
			},
			/**
			 * 获取第一层菜单的html
			 * @param {object} options {id:"",icon:"",name:""}
			 */
			getFirstLevelMenuHTML: function (options) {
				//获取模块
				return '<a id="' + options.id + '" href="javascript:void(0);"  class="app-menu-item">' +
					'<i class="' + options.icon + ' app-menu-item-icon"></i>' +
					'<span class="app-menu-item-text">' + options.name + '</span>' +
					'<span class="app-menu-item-arrow"></span></a>';
			},
			/**
			 * 获取第二层菜单的html
			 * @param {object} options {id:"",icon:"",name:""}
			 */
			getSecondLevelMenuHTML: function (options) {
				//获取模块
				return '<a id="' + options.id + '" href="javascript:void(0);" class="app-menu-item">' +
					'<i class="' + options.icon + ' app-menu-item-icon"></i>' +
					'<span class="app-menu-item-text">' + options.name + '</span>' +
					'</a>';
			},
			/**
			 * 获取第三层菜单的html
			 * @param {object} options {id:"",icon:"",name:""}
			 */
			getThirdLevelMenuHTML: function (options) {
				//获取模块
				return '<a id="' + options.id + '" href="javascript:void(0);" class="app-menu-item">' +
					'<i class="' + options.icon + ' app-menu-item-icon"></i>' +
					'<span class="app-menu-item-text">' + options.name + '</span>' +
					'</a>';
			},
			/**
			 * 加载菜单
			 */
			load: function () {
				var modulesTree = app.APP_GLOBE_STORE.LEFT_TREE_MENU;
				//alert(JSON.stringify(modulesTree))
				// 第一级菜单
				var parentId = page.leftmenu.parentId;
				var modules = modulesTree[parentId] || [];
				var $firstmenus = $('<ul class="app-first-menu-list"></ul>');
				for (var i = 0, l = modules.length; i < l; i++) {
					var item = modules[i];
					if (item.moduleismenu) {
						var $firstMenuItem = $('<li></li>');
						if (!!item.moduledescription) {
							$firstMenuItem.attr('title', item.moduledescription);
						}
						var menuItemHtml = page.leftmenu.getFirstLevelMenuHTML({
							id: item.moduleid,
							name: item.modulefullname,
							icon: item.moduleicon
						})
						$firstMenuItem.append(menuItemHtml); 
						// 第二级菜单
						var secondModules = modulesTree[item.moduleid] || []; 
						var $secondMenus = $('<ul class="app-second-menu-list"></ul>');
						var secondMenuHad = false;
						for (var j = 0, sl = secondModules.length; j < sl; j++) {
							var secondItem = secondModules[j];
							//alert(secondItem.IsMenu)
							if (secondItem.moduleismenu) {
								secondMenuHad = true;
								var $secondMenuItem = $('<li></li>');
								if (!!secondItem.moduledescription) {
									$secondMenuItem.attr('title', secondItem.moduledescription);
								}
								var secondItemHtml = page.leftmenu.getSecondLevelMenuHTML({
									id: secondItem.moduleid,
									name: secondItem.modulefullname,
									icon: secondItem.moduleicon
								});

								$secondMenuItem.append(secondItemHtml);
								// 第三级菜单
								var threeModules = modulesTree[secondItem.moduleid] || [];
								var $threeMenus = $('<ul class="app-three-menu-list"></ul>');
								var threeMenuHad = false;
								for (var m = 0, tl = threeModules.length; m < tl; m++) {
									var threeItem = threeModules[m];
									if (threeItem.moduleismenu) {
										threeMenuHad = true;
										var $threeMenuItem = $('<li></li>');
										$threeMenuItem.attr('title', threeItem.FullName);
										var threeItemHtml = page.leftmenu.getThirdLevelMenuHTML({
											id: threeItem.moduleid,
											name: threeItem.modulefullname,
											icon: threeItem.moduleicon
										});
										$threeMenuItem.append(threeItemHtml);
										$threeMenus.append($threeMenuItem);
									}
								}
								if (threeMenuHad) {
									$secondMenuItem.addClass('app-meun-had');
									$secondMenuItem.append($threeMenus);
								}
								$secondMenus.append($secondMenuItem);
							}
						}
						if (secondMenuHad) {
							$firstMenuItem.append($secondMenus);
						}
						$firstmenus.append($firstMenuItem);
					}
				}
				$('#app_frame_menu').html($firstmenus);
			},
			bind: function () {
				$("#app_frame_menu").appscroll();
				$("#app_frame_menu .app-first-menu-list > li").hover(function (e) { // 一级菜单选中的时候判断二级菜单的位置
					var $secondMenu = $(this).find('.app-second-menu-list');
					var length = $secondMenu.find('li').length;
					if (length > 0) {
						$secondMenu.css('top', '0px');
						var secondMenuTop = $(this).offset().top + $secondMenu.height() + 23;
						var bodyHeight = $(window).height();
						if (secondMenuTop > bodyHeight) {
							$secondMenu.css('top', '-' + (secondMenuTop - bodyHeight) + 'px');
						}
					}
				}, function (e) {
					$('#app_frame_menu').width(80);
				});

				$("#app_frame_menu .app-second-menu-list > li.app-meun-had").hover(function (e) { // 二级菜单选中的时候判断三级菜单的位置
					var $ul = $(this).find('.app-three-menu-list');
					$ul.css('top', '-9px');
					var ulTop = $(this).offset().top + $ul.height() + 23;
					var bodyHeight = $(window).height();
					if (ulTop > bodyHeight) {
						$ul.css('top', '-' + (ulTop - bodyHeight) + 'px');
					}
				});

				// 添加点击事件
				$('#app_frame_menu .app-menu-item').on('click', function () { 
					var $obj = $(this);
					var id = $obj.attr('id');
					var currentModule = page.leftmenu.getMenuData(id);
					//alert(JSON.stringify(currentModule))
					if (!currentModule || !app.BASE_UTILS.dataValidator.isNotNull(currentModule.UrlAddress).code) {
						return false;
					}
					switch (currentModule.Target) {
						case 'iframe': // 窗口
							app.frameTab.open(currentModule, false);
							break;
					}
				});
			}
		}
	};

	$(function () {
		//调用初始化页面方法
		page.init();
	});
})(window.jQuery, top.app);