/**
 * 页签操作
 */
(function ($, app) {
    "use strict";
    //初始化菜单和tab页的属性Id
    var iframeIdList = {};

    app.frameTab = {
        iframeId: '',
        /**
         * 初始化
         */
        init: function () { 
            app.frameTab.bind(); 
        },
        bind: function () { 
            $(".app-frame-tabs-wrap").appscroll(); 
        },
        setCurrentIframeId: function (iframeId) {
            app.iframeId = iframeId;
        },
        open: function (module, notAllowClosed) {
        	//alert(module.Id)
        	var moduleId=module.Id;
        	localStorage.setItem('CurrentIds',moduleId)
            var $tabsUl = $('#app_frame_tabs_ul');
            var $frameMain = $('#app_frame_main'); 
            if (iframeIdList[module.Id] == undefined || iframeIdList[module.Id] == null) {
                // 隐藏之前的tab和窗口
                if (app.frameTab.iframeId != '') {
                    //$tabsUl.find('#app_tab_').removeClass('active');
                    $tabsUl.find('.app-frame-tabItem').removeClass('active');
                    $frameMain.find('#app_frame_' + app.frameTab.iframeId).removeClass('active');
                    iframeIdList[app.frameTab.iframeId] = 0;
                }
                var parentId = app.frameTab.iframeId;
                app.frameTab.iframeId = module.Id; 
                iframeIdList[app.frameTab.iframeId] = 1;

                var urlAddress =app.APP_CONFIGRATION.ROUTER_CONFIG.PAGE_ROOT +module.UrlAddress

                // 打开一个功能模块tab_iframe页面
                var $tabItem = $('<li class="app-frame-tabItem active" id="app_tab_' + module.Id + '" parent-id="' + parentId + '"  ><span>' + module.FullName + '</span></li>');
                $tabItem.find('span').text(module.FullName);

                if (!notAllowClosed) { 
                    $tabItem.append('<span class="reomve" title="关闭窗口"></span>');
                }
                var $iframe = $('<iframe class="app-frame-iframe active" id="app_frame_' + module.Id + '" frameborder="0" src="' + urlAddress + '"></iframe>');
                $tabsUl.append($tabItem);
                $frameMain.append($iframe);

                var w = 0;
                var width = $tabsUl.children().each(function () {
                    w += $(this).outerWidth();
                });
                $tabsUl.css({
                    'width': w
                });
                $tabsUl.parent().css({
                    'width': w
                });


                $(".app-frame-tabs-wrap").appscrollSet('moveRight');

                //绑定一个点击事件
                $tabItem.on('click', function () {               	
                    var id = $(this).attr('id').replace('app_tab_', '');
                    app.frameTab.focus(id);
                });
                $tabItem.find('.reomve').on('click', function () {
                    var id = $(this).parent().attr('id').replace('app_tab_', '');
                    app.frameTab.close(id);
                    return false;
                });

                if (!!app.frameTab.opencallback) {
                    app.frameTab.opencallback();
                }
            } else {
                app.frameTab.focus(module.Id);
            }
        },
        focus: function (moduleId) {
            //if (iframeIdList[moduleId] == 0) {
            if (!iframeIdList[moduleId]) {
                // 定位焦点tab页
                $('#app_tab_' + app.frameTab.iframeId).removeClass('active');
                $('#app_frame_' + app.frameTab.iframeId).removeClass('active');
                iframeIdList[app.frameTab.iframeId] = 0;

                $('#app_tab_' + moduleId).addClass('active');
                $('#app_frame_' + moduleId).addClass('active');
                app.frameTab.iframeId = moduleId;
                iframeIdList[moduleId] = 1;

                if (!!app.frameTab.opencallback) {
                    app.frameTab.opencallback();
                }
            }
        },
        leaveFocus: function () {
            $('#app_tab_' + app.frameTab.iframeId).removeClass('active');
            $('#app_frame_' + app.frameTab.iframeId).removeClass('active');
            iframeIdList[app.frameTab.iframeId] = 0;
            app.frameTab.iframeId = '';
        },
        close: function (moduleId) {
            delete iframeIdList[moduleId];

            var $this = $('#app_tab_' + moduleId);
            var $prev = $this.prev(); // 获取它的上一个节点数据;
            if ($prev.length < 1) {
                $prev = $this.next();
            }
            $this.remove();
            $('#app_frame_' + moduleId).remove();
            if (moduleId == app.frameTab.iframeId && $prev.length > 0) {
                var prevId = $prev.attr('id').replace('app_tab_', '');

                $prev.addClass('active');
                $('#app_frame_' + prevId).addClass('active');
                app.frameTab.iframeId = prevId;
                iframeIdList[prevId] = 1;
            } else {
                if ($prev.length < 1) {
                    app.frameTab.iframeId = "";
                }
            }

            var $tabsUl = $('#app_frame_tabs_ul');
            var w = 0;
            var width = $tabsUl.children().each(function () {
                w += $(this).outerWidth();
            });
            $tabsUl.css({
                'width': w
            });
            $tabsUl.parent().css({
                'width': w
            });

            if (!!app.frameTab.closecallback) {
                app.frameTab.closecallback();
            }
        },
        // 获取当前窗口
        currentIframe: function () { 
            var ifameId = 'app_frame_' + app.frameTab.iframeId;
            if (top.frames[ifameId].contentWindow != undefined) {
                return top.frames[ifameId].contentWindow;
            } else {
                return top.frames[ifameId];
            }
        },
        parentIframe: function () {
                var ifameId = 'app_frame_' + top.$('#app_tab_' + app.frameTab.iframeId).attr('parent-id');
                if (top.frames[ifameId].contentWindow != undefined) {
                    return top.frames[ifameId].contentWindow;
                } else {
                    return top.frames[ifameId];
                }
            }


            ,
        opencallback: false,
        closecallback: false
    };

    app.frameTab.init();
})(window.jQuery, top.app);