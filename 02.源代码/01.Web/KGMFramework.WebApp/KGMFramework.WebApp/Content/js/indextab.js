(function ($) {

    $.nfinetab = {
        fillTab: function (str, add) {
            var ww = $("#ss").width();  //$('#header-navbar').width() - $('#make-small-nav').width() - $('.navbar-brand').width() - $('#header-nav').width() - 120;
            var tabcount = parseInt(parseInt(ww) / 120);//当前可以放多少个tabs
            var current = $("#ss ul li").length;
            if (add) { 
                if (current + 1 > tabcount) {
                    $("#ss").css("overflow-x", "scroll")
                    $("#menuul").css("width", (current + 1) * 120 + 40 + "px")
                } 

                $('.menuTabs .page-tabs-content').prepend(str);
                $.nfinetab.scrollToTab($('.menuTab.active')); 
            }
            else {
                if (current - 1 <= tabcount) {
                    $("#ss").css("overflow-x", "hidden")
                    $("#menuul").css("width", ww + "px")
                }  
            }
        },

        fillTab2: function (str, add) {
            var ww = window.top.$("#ss").width();  //$('#header-navbar').width() - $('#make-small-nav').width() - $('.navbar-brand').width() - $('#header-nav').width() - 120;
            var tabcount = parseInt(parseInt(ww) / 120);//当前可以放多少个tabs
            var current = window.top.$("#ss ul li").length;

            if (add) { 
                if (current + 1 > tabcount) {
                    window.top.$("#ss").css("overflow-x", "scroll")
                    window.top.$("#menuul").css("width", (current + 1) * 120 + 40 + "px")
                }

                window.top.$('.menuTabs .page-tabs-content').prepend(str);
                $.nfinetab.scrollToTab2(window.top.$('.menuTab.active'));
            }
            else {
                if (current - 1 <= tabcount) {
                    window.top.$("#ss").css("overflow-x", "hidden")
                    window.top.$("#menuul").css("width", ww + "px")
                } 
            }
        },

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
        //刷新
        refreshTab: function () {
            var currentId = $('.page-tabs-content').find('.active').attr('data-id');
            var target = $('.NFine_iframe[data-id="' + currentId + '"]');
            var url = target.attr('src');
            $.loading(true);
            target.attr('src', url).load(function () {
                $.loading(false);
            });
        },
        //选中
        activeTab: function () {
            var currentId = $(this).data('id');
            if (!$(this).hasClass('active')) {
                $('.mainContent .NFine_iframe').each(function () {
                    if ($(this).data('id') == currentId) {
                        $(this).show().siblings('.NFine_iframe').hide();
                        return false;
                    }
                });
                var s = $(".menuTab");
                for (var i = 0; i < s.length; i++) {
                    $(s[i]).removeClass('active');
                }
                $(this).addClass('active');//.siblings('.menuTab').removeClass('active'); 
                $.nfinetab.scrollToTab(this);
            }
        },
        //关闭其他
        closeOtherTabs: function () {

            //$('.page-tabs-content').children("[data-id]").find('.fa-remove').parents('a').not(".active").each(function () {          
            //    $('.NFine_iframe[data-id="' + $(this).data('id') + '"]').remove();        
            //   $(this).remove();
            //});
            //$('.page-tabs-content').css("margin-left", "0");

            $('.page-tabs-content').children().children("[data-id]").find('.fa-remove').parents('a').not(".active").each(function () {
                $('.NFine_iframe[data-id="' + $(this).data('id') + '"]').remove();
                $(this).parent().remove();

            });
            $('.page-tabs-content').css("margin-left", "0");
        },

        //关闭当前
        closeTab: function () {
            var closeTabId = $(this).parents('.menuTab').data('id');
            var currentWidth = $(this).parents('.menuTab').width();

            //把active前移一个
            var currentli = $(this).parents('.menuTab').parents('li');
            var preNodeli = currentli.next();//后一个Node节点 
            if ($(this).parents('.menuTab').hasClass('active')) {
                //iframe也要移走
                var activeId = preNodeli.children('.menuTab:eq(0)').data('id');
                $('.mainContent .NFine_iframe').each(function () {
                    if ($(this).data('id') == activeId) {
                        $(this).show().siblings('.NFine_iframe').hide();
                    }
                });
            }
            //li移除
            preNodeli.children('.menuTab').addClass('active');
            currentli.remove()
            $.nfinetab.scrollToTab($('.menuTab.active'));
            $.nfinetab.fillTab("", false)

            return false;
        },
        //添加nav li 
        addTab: function () {
            $("#header-nav>ul>li.open").removeClass("open");
            var dataId = $(this).attr('data-id');
            if (dataId != "") {
                top.$.cookie('nfine_currentmoduleid', dataId, { path: "/" });
            }
            var dataUrl = $(this).attr('href');
            var menuName = $.trim($(this).text());
            var flag = true;
            if (dataUrl == undefined || $.trim(dataUrl).length == 0) {
                return false;
            }
            $('.menuTab').each(function () {
                if ($(this).data('id') == dataUrl) {
                    if (!$(this).hasClass('active')) {
                        var s = $(".menuTab");
                        for (var i = 0; i < s.length; i++) {
                            $(s[i]).removeClass('active');
                        }
                        $(this).addClass('active');
                        //$(this).addClass('active').siblings('.menuTab').removeClass('active');
                        $.nfinetab.scrollToTab(this);
                        $('.mainContent .NFine_iframe').each(function () {
                            if ($(this).data('id') == dataUrl) {
                                $(this).show().siblings('.NFine_iframe').hide();
                                return false;
                            }
                        });
                    }
                    flag = false;
                    return false;
                }
            });
            if (flag) {
                var str = '<li class="blockli"><a href="javascript:;" class="active menuTab" data-id="' + dataUrl + '">' + '<i class="fa fa-remove"></i>' + menuName + '</a></li>';
                $('.menuTab').removeClass('active');
                var str1 = '<iframe class="NFine_iframe" id="iframe' + dataId + '" name="iframe' + dataId + '"  width="100%" height="100%" src="' + dataUrl + '" frameborder="0" data-id="' + dataUrl + '" seamless></iframe>';
                $('.mainContent').find('iframe.NFine_iframe').hide();
                $('.mainContent').prepend(str1);
                $.loading(true);
                $('.mainContent iframe:visible').load(function () {
                    $.loading(false);
                });
                //如果nav的宽度小于分辨率宽度，加入nav
                // alert($('#clearfix').width())

                $.nfinetab.fillTab(str, true)


            }
            return false;
        },
        addTab2: function (dataUrl, menuName, dataId) {

            var nbar = $("#header-nav>ul>li.open")
            if (nbar.length > 0) {
                nbar.removeClass("open");
            }

            //var dataId =window.$(this).attr('data-id');//存ID
            //if (dataId != "") {
            //    top.$.cookie('nfine_currentmoduleid', dataId, { path: "/" });
            //}
            //var dataUrl = $(this).attr('href');
            //var menuName = $.trim($(this).text());
            var flag = true;
            if (dataUrl == undefined || $.trim(dataUrl).length == 0) {
                return false;
            }

            window.top.$('.menuTab').each(function () {
                if ($(this).data('id') == dataUrl) {
                    if (!$(this).hasClass('active')) {
                        var s = window.top.$(".menuTab");
                        //alert(s.length)
                        for (var i = 0; i < s.length; i++) {
                            $(s[i]).removeClass('active');
                        }
                        $(this).addClass('active');
                        //$(this).parent().siblings().children().removeClass('active');                     
                        $.nfinetab.scrollToTab2(this);
                                           
                        window.top.$('.mainContent .NFine_iframe').each(function () {
                            if ($(this).data('id') == dataUrl) {                             
                                $(this).show().siblings('.NFine_iframe').hide();
                                return false;
                            }
                        });
                    }
                    flag = false;
                    return false;
                }
            });

            if (flag) {
                var str = '<li class="blockli"><a href="javascript:;" class="active menuTab" data-id="' + dataUrl + '">' + '<i class="fa fa-remove"></i>' + menuName + '</a></li>';
                if (window.top.$('.menuTab').length > 0) {
                    window.top.$('.menuTab').removeClass('active');
                }

                var str1 = '<iframe class="NFine_iframe" id="iframe' + dataId + '" name="iframe' + dataId + '"  width="100%" height="100%" src="' + dataUrl + '" frameborder="0" data-id="' + dataUrl + '" seamless></iframe>';
                window.top.$('.mainContent').find('iframe.NFine_iframe').hide();
                window.top.$('.mainContent').append(str1);


                window.top.$.loading(true);
                window.top.$('.mainContent iframe:visible').load(function () {
                    window.top.$.loading(false);
                });
                //如果nav的宽度小于分辨率宽度，加入nav
                // alert($('#clearfix').width())

                $.nfinetab.fillTab2(str, true)

            }

            return false;
        },
        scrollTabRight: function () {
            var marginLeftVal = Math.abs(parseInt($('.page-tabs-content').css('margin-left')));
            var tabOuterWidth = $.nfinetab.calSumWidth($(".content-tabs").children().not(".menuTabs"));
            var visibleWidth = $(".content-tabs").outerWidth(true) - tabOuterWidth;
            var scrollVal = 0;
            if ($(".page-tabs-content").width() < visibleWidth) {
                return false;
            } else {
                var tabElement = $(".menuTab:first");
                var offsetVal = 0;
                while ((offsetVal + $(tabElement).outerWidth(true)) <= marginLeftVal) {
                    offsetVal += $(tabElement).outerWidth(true);
                    tabElement = $(tabElement).next();
                }
                offsetVal = 0;
                while ((offsetVal + $(tabElement).outerWidth(true)) < (visibleWidth) && tabElement.length > 0) {
                    offsetVal += $(tabElement).outerWidth(true);
                    tabElement = $(tabElement).next();
                }
                scrollVal = $.nfinetab.calSumWidth($(tabElement).prevAll());
                if (scrollVal > 0) {
                    $('.page-tabs-content').animate({
                        marginLeft: 0 - scrollVal + 'px'
                    }, "fast");
                }
            }
        },
        scrollTabLeft: function () {
            var marginLeftVal = Math.abs(parseInt($('.page-tabs-content').css('margin-left')));
            var tabOuterWidth = $.nfinetab.calSumWidth($(".content-tabs").children().not(".menuTabs"));
            var visibleWidth = $(".content-tabs").outerWidth(true) - tabOuterWidth;
            var scrollVal = 0;
            if ($(".page-tabs-content").width() < visibleWidth) {
                return false;
            } else {
                var tabElement = $(".menuTab:first");
                var offsetVal = 0;
                while ((offsetVal + $(tabElement).outerWidth(true)) <= marginLeftVal) {
                    offsetVal += $(tabElement).outerWidth(true);
                    tabElement = $(tabElement).next();
                }
                offsetVal = 0;
                if ($.nfinetab.calSumWidth($(tabElement).prevAll()) > visibleWidth) {
                    while ((offsetVal + $(tabElement).outerWidth(true)) < (visibleWidth) && tabElement.length > 0) {
                        offsetVal += $(tabElement).outerWidth(true);
                        tabElement = $(tabElement).prev();
                    }
                    scrollVal = $.nfinetab.calSumWidth($(tabElement).prevAll());
                }
            }
            $('.page-tabs-content').animate({
                marginLeft: 0 - scrollVal + 'px'
            }, "fast");
        },
        scrollToTab: function (element) {
            var marginLeftVal = $.nfinetab.calSumWidth($(element).prevAll()), marginRightVal = $.nfinetab.calSumWidth($(element).nextAll());
            var tabOuterWidth = $.nfinetab.calSumWidth($(".content-tabs").children().not(".menuTabs"));
            var visibleWidth = $(".content-tabs").outerWidth(true) - tabOuterWidth;
            var scrollVal = 0;

            if (!$(".page-tabs-content").outerWidth() || $(".page-tabs-content").outerWidth() < visibleWidth) {
                scrollVal = 0;
            } else if (marginRightVal <= (visibleWidth - $(element).outerWidth(true) - $(element).next().outerWidth(true))) {
                if ((visibleWidth - $(element).next().outerWidth(true)) > marginRightVal) {
                    scrollVal = marginLeftVal;
                    var tabElement = element;
                    while ((scrollVal - $(tabElement).outerWidth()) > ($(".page-tabs-content").outerWidth() - visibleWidth)) {
                        scrollVal -= $(tabElement).prev().outerWidth();
                        tabElement = $(tabElement).prev();
                    }
                }
            } else if (marginLeftVal > (visibleWidth - $(element).outerWidth(true) - $(element).prev().outerWidth(true))) {
                scrollVal = marginLeftVal - $(element).prev().outerWidth(true);
            }
            $('.page-tabs-content').animate({
                marginLeft: 0 - scrollVal + 'px'
            }, "fast");
        },

        scrollToTab2: function (element) {    
            var marginLeftVal = $.nfinetab.calSumWidth($(element).prevAll()), marginRightVal = $.nfinetab.calSumWidth($(element).nextAll());  
            var tabOuterWidth = $.nfinetab.calSumWidth(window.top.$(".content-tabs").children().not(".menuTabs"));
            var visibleWidth = $(".content-tabs").outerWidth(true) - tabOuterWidth;        
            var scrollVal = 0;           
            if (!window.top.$(".page-tabs-content").outerWidth() || window.top.$(".page-tabs-content").outerWidth() < visibleWidth) {              
                scrollVal = 0;
            } else if (marginRightVal <= (visibleWidth - $(element).outerWidth(true) - $(element).next().outerWidth(true))) {          
                if ((visibleWidth - $(element).next().outerWidth(true)) > marginRightVal) {
                    scrollVal = marginLeftVal;
                    var tabElement = element;
                    while ((scrollVal - $(tabElement).outerWidth()) > (window.top.$(".page-tabs-content").outerWidth() - visibleWidth)) {
                        scrollVal -= $(tabElement).prev().outerWidth();
                        tabElement = $(tabElement).prev();
                    }
                }
            } else if (marginLeftVal > (visibleWidth - $(element).outerWidth(true) - $(element).prev().outerWidth(true))) {
               
                scrollVal = marginLeftVal - $(element).prev().outerWidth(true);
           
            }
            window.top.$('.page-tabs-content').animate({
                marginLeft: 0 - scrollVal + 'px'
            }, "fast");
        },

        calSumWidth: function (element) {
            var width = 0;
            $(element).each(function () {
                width += $(this).outerWidth(true);
            });
            return width;
        },


        init: function () {
            $('.menuItem').on('click', $.nfinetab.addTab);
            $('.menuTabs').on('click', '.menuTab i', $.nfinetab.closeTab);
            $('.menuTabs').on('click', '.menuTab', $.nfinetab.activeTab);
            $('.tabLeft').on('click', $.nfinetab.scrollTabLeft);
            $('.tabRight').on('click', $.nfinetab.scrollTabRight);


            $('.tabReload').on('click', $.nfinetab.refreshTab);
            $('.tabCloseCurrent').on('click', function () {
                $('.page-tabs-content').find('.active i').trigger("click");

            });

            //全部关闭
            $('.tabCloseAll').on('click', function () {

                $('#drop-add').children().each(function (i, n) {
                    $(n).remove();
                });//drop-add下的li

                $('.page-tabs-content').children().children("[data-id]").find('.fa-remove').parents('a').each(function () {
                    $('.NFine_iframe[data-id="' + $(this).data('id') + '"]').remove();
                    $(this).parent().remove();
                });
                $('.page-tabs-content').children().children("[data-id]:first").each(function () {
                    $('.NFine_iframe[data-id="' + $(this).data('id') + '"]').show();
                    $(this).addClass("active");
                });
                $('#moreLi').css("display", "none");
                $('.page-tabs-content').css("margin-left", "0");
            });


            $('.tabCloseOther').on('click', $.nfinetab.closeOtherTabs);
            $('.fullscreen').on('click', function () {
                if (!$(this).attr('fullscreen')) {
                    $(this).attr('fullscreen', 'true');
                    requestFullScreen();
                } else {
                    $(this).removeAttr('fullscreen')
                    exitFullscreen();
                }
            });
        }
    };
    $(function () {
        $.nfinetab.init();
    });
})(jQuery);