/**
 * 基础帮助类库
 */
top.app = (function ($) {
    /**
     * 基础帮助信息
     */
    var app = {
        /**
         * 基本操作
         */
        BASE_UTILS: {
            /**
             * 创建一个GUID 
             **/
            newGuid: function () {
                var guid = "";
                for (var i = 1; i <= 32; i++) {
                    var n = Math.floor(Math.random() * 16.0).toString(16);
                    guid += n;
                    if ((i == 8) || (i == 12) || (i == 16) || (i == 20)) guid += "-";
                }
                return guid;
            },
            // 获取iframe窗口
	        iframe: function (Id, _frames) {
	            if (_frames[Id] != undefined) {
	                if (_frames[Id].contentWindow != undefined) {
	                    return _frames[Id].contentWindow;
	                }
	                else {
	                    return _frames[Id];
	                }
	            }
	            else {
	                return null;
	            }
	        },
             // 检测数据是否选中
	        checkrow: function (id) {
	            var isOK = true;
	            if (id == undefined || id == "" || id == 'null' || id == 'undefined') {
	                isOK = false;
	                /*top.learun.language.get('您没有选中任何数据项,请选中后再操作！', function (text) {
	                    learun.alert.warning(text);
	                });*/
	                app.MODAL_UTILS.warning('请至少选中一行');
	               
	            }
	            return isOK;
	        },
	          // 加载提示
//	        loading: function (isShow, _text) {//加载动画显示与否
//	            var $loading = top.$("#app_loading_bar");
//	            if (!!_text) {
//	               /* top.learun.language.get(_text, function (text) {
//	                    top.$("#lr_loading_bar_message").html(text);
//	                });*/
//	              // $("#app_loading_bar_message").html(text);
//	               
//	            } else {	            	 
//	               /* top.learun.language.get("正在拼了命为您加载…", function (text) {
//	                    top.$("#lr_loading_bar_message").html(text);
//	                });*/
//	                app.MODAL_UTILS.warning('正在拼了命为您加载…');
//	               // $("#app_loading_bar_message").html(text)
//	            }
//	            if (isShow) {
//	                $loading.show();
//	            } else {
//	                $loading.hide();
//	            }
//	        },
	        loading :function (bool, text) {
			    var $loadingpage = top.$("#loadingPage");
			    var $loadingtext = $loadingpage.find('.loading-content');
			    if (bool) {			    	
			        $loadingpage.show();
			    } else {
			        if ($loadingtext.attr('istableloading') == undefined) {
			            $loadingpage.hide();
			        }
			    }
			    if (!!text) {
			        $loadingtext.html(text);
			    } else {
			        $loadingtext.html("数据加载中，请稍后…");
			    }
			    $loadingtext.css("left", (top.$('body').width() - $loadingtext.width()) / 2 - 50);
			    $loadingtext.css("top", (top.$('body').height() - $loadingtext.height()) / 2);
			},
	        
            /**
             * 日期操作类
             */
            Date: {
                /**
                 *  获取当前日期 yyyy-MM-dd
                 * @param {Date} date 日期 为空则获取当前时间
                 */
                get_yyyy_MM_dd: function (date) {
                    if (!!!date) {
                        date = new Date();
                    } 
                    var seperator1 = "-";
                    var month = date.getMonth() + 1;
                    var strDate = date.getDate();
                    if (month >= 1 && month <= 9) {
                        month = "0" + month;
                    }
                    if (strDate >= 0 && strDate <= 9) {
                        strDate = "0" + strDate;
                    }
                    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate;
                    return currentdate;
                },
                /**
                 * 获取当前日期 yyyy-MM-dd 的数据
                 * @param {int} day 天数 负数往前推 正数往后推
                 * @param {Date} day date 日期 为空则获取当前时间
                 */
                
                get_yyyy_MM_dd_Area: function (day, date) {
                    if (!!!date) {
                        date = new Date();
                    }
                    var dateArr = [];
                    dateArr.push(app.BASE_UTILS.Date.get_yyyy_MM_dd(date))
                    //循环获取
                    for (var i = 0; i < Math.abs(day) - 1; i++) {
                        var ndate = new Date();
                        if (day > 0) {
                            ndate.setDate(ndate.getDate() + (i + 1));
                            dateArr.push(app.BASE_UTILS.Date.get_yyyy_MM_dd(ndate))
                        } else {
                            ndate.setDate(ndate.getDate() - (i + 1));
                            dateArr.unshift(app.BASE_UTILS.Date.get_yyyy_MM_dd(ndate))
                        }
                    }
                    return dateArr;
                },
                /**
                 *  获取当前日期 yyyyMMdd
                 * @param {Date} date 日期 为空则获取当前时间
                 */
                get_yyyyMMdd: function (date) {
                    if (!!!date) {
                        date = new Date();
                    }
                    var month = date.getMonth() + 1;
                    var strDate = date.getDate();
                    if (month >= 1 && month <= 9) {
                        month = "0" + month;
                    }
                    if (strDate >= 0 && strDate <= 9) {
                        strDate = "0" + strDate;
                    }
                    var currentdate = date.getFullYear() + month + strDate;
                    return currentdate;
                }
            },
            /**
             * 数据转换类
             */
            dataConvert: {
                /**
                 * 转化成十进制
                 * @param {string} num 
                 */
                toDecimal: function (num) {
                    if (num == null) {
                        num = "0";
                    }
                    num = num.toString().replace(/\$|\,/g, '');
                    if (isNaN(num))
                        num = "0";
                    var sign = (num == (num = Math.abs(num)));
                    num = Math.floor(num * 100 + 0.50000000001);
                    var cents = num % 100;
                    num = Math.floor(num / 100).toString();
                    if (cents < 10)
                        cents = "0" + cents;
                    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
                        num = num.substring(0, num.length - (4 * i + 3)) + '' +
                        num.substring(num.length - (4 * i + 3));
                    return (((sign) ? '' : '-') + num + '.' + cents);
                },
                /**
                 * 文件大小转换
                 * @param {int} size 
                 */
                countFileSize: function (size) {
                    if (size < 1024.00)
                        return app.BASE_UTILS.dataConvert.toDecimal(size) + " 字节";
                    else if (size >= 1024.00 && size < 1048576)
                        return app.BASE_UTILS.dataConvert.toDecimal(size / 1024.00) + " KB";
                    else if (size >= 1048576 && size < 1073741824)
                        return app.BASE_UTILS.dataConvert.toDecimal(size / 1024.00 / 1024.00) + " MB";
                    else if (size >= 1073741824)
                        return app.BASE_UTILS.dataConvert.toDecimal(size / 1024.00 / 1024.00 / 1024.00) + " GB";
                },
                /**
                 * 数字格式转换成千分位
                 * @param {decimal} num 
                 */
                commafy: function (num) {
                    if (num == null) {
                        num = "0";
                    }
                    if (isNaN(num)) {
                        return "0";
                    }
                    num = num + "";
                    if (/^.*\..*$/.test(num)) {
                        varpointIndex = num.lastIndexOf(".");
                        varintPart = num.substring(0, pointIndex);
                        varpointPart = num.substring(pointIndex + 1, num.length);
                        intPart = intPart + "";
                        var re = /(-?\d+)(\d{3})/
                        while (re.test(intPart)) {
                            intPart = intPart.replace(re, "$1,$2")
                        }
                        num = intPart + "." + pointPart;
                    } else {
                        num = num + "";
                        var re = /(-?\d+)(\d{3})/
                        while (re.test(num)) {
                            num = num.replace(re, "$1,$2")
                        }
                    }
                    return num;
                },
            },
            /**
             * 数据验证方法
             */
            dataValidator: {
                validReg: function (obj, reg, msg) {
                    var res = {
                        code: true,
                        msg: ''
                    };
                    if (!reg.test(obj)) {
                        res.code = false;
                        res.msg = msg;
                    }
                    return res;
                },
                validRegOrNull: function (obj, reg, msg) {
                    var res = {
                        code: true,
                        msg: ''
                    };
                    if (obj == null || obj == undefined || obj.length == 0) {
                        return res;
                    }
                    if (!reg.test(obj)) {
                        res.code = false;
                        res.msg = msg;
                    }
                    return res;
                },
                isNotNull: function (obj) { // 验证不为空
                    var res = {
                        code: true,
                        msg: ''
                    };
                    obj = $.trim(obj);
                    if (obj == null || obj == undefined || obj.length == 0) {
                        res.code = false;
                        res.msg = '不能为空';
                    }
                    return res;
                },
                isNum: function (obj) { // 验证数字
                    return app.BASE_UTILS.dataValidator.validReg(obj, /^[-+]?\d+$/, '必须为数字');
                },
                isNumOrNull: function (obj) { // 验证数字 或者空
                    return app.BASE_UTILS.dataValidator.validRegOrNull(obj, /^[-+]?\d+$/, '数字或空');
                },
                isEmail: function (obj) { //Email验证 email
                    return app.BASE_UTILS.dataValidator.validReg(obj, /^\w{3,}@\w+(\.\w+)+$/, '必须为E-mail格式');
                },
                isEmailOrNull: function (obj) { //Email验证 email   或者null,空
                    return app.BASE_UTILS.dataValidator.validRegOrNull(obj, /^\w{3,}@\w+(\.\w+)+$/, '必须为E-mail格式或空');
                },
                isEnglishStr: function (obj) { //验证只能输入英文字符串 echar
                    return app.BASE_UTILS.dataValidator.validReg(obj, /^[a-z,A-Z]+$/, '必须为英文字符串');
                },
                isEnglishStrOrNull: function (obj) { //验证只能输入英文字符串 echar 或者null,空
                    return app.BASE_UTILS.dataValidator.validRegOrNull(obj, /^[a-z,A-Z]+$/, '必须为英文字符串或空');
                },
                isTelephone: function (obj) { //验证是否电话号码 phone
                    return app.BASE_UTILS.dataValidator.validReg(obj, /^(\d{3,4}\-)?[1-9]\d{6,7}$/, '必须为电话格式');
                },
                isTelephoneOrNull: function (obj) { //验证是否电话号码 phone或者null,空
                    return app.BASE_UTILS.dataValidator.validRegOrNull(obj, /^(\d{3,4}\-)?[1-9]\d{6,7}$/, '必须为电话格式或空');
                },
                isMobile: function (obj) { //验证是否手机号 mobile
                    return app.BASE_UTILS.dataValidator.validReg(obj, /^(\+\d{2,3}\-)?\d{11}$/, '必须为手机格式');
                },
                isMobileOrnull: function (obj) { //验证是否手机号 mobile或者null,空
                    return app.BASE_UTILS.dataValidator.validRegOrNull(obj, /^(\+\d{2,3}\-)?\d{11}$/, '必须为手机格式或空');
                },
                isMobileOrPhone: function (obj) { //验证是否手机号或电话号码 mobile phone 
                    var res = {
                        code: true,
                        msg: ''
                    };
                    if (!app.BASE_UTILS.dataValidator.isTelephone(obj).code && !app.BASE_UTILS.dataValidator.isMobile(obj).code) {
                        res.code = false;
                        res.msg = '为电话格式或手机格式';
                    }
                    return res;
                },
                isMobileOrPhoneOrNull: function (obj) { //验证是否手机号或电话号码 mobile phone或者null,空
                    var res = {
                        code: true,
                        msg: ''
                    };
                    if (app.BASE_UTILS.dataValidator.isNotNull(obj).code && !app.BASE_UTILS.dataValidator.isTelephone(obj).code && !app.BASE_UTILS.dataValidator.isMobile(obj).code) {
                        res.code = false;
                        res.msg = '为电话格式或手机格式或空';
                    }
                    return res;
                },
                isUri: function (obj) { //验证网址 uri
                    return app.BASE_UTILS.dataValidator.validReg(obj, /^http:\/\/[a-zA-Z0-9]+\.[a-zA-Z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/, '必须为网址格式');
                },
                isUriOrNull: function (obj) { //验证网址 uri或者null,空
                    return app.BASE_UTILS.dataValidator.validRegOrNull(obj, /^http:\/\/[a-zA-Z0-9]+\.[a-zA-Z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/, '必须为网址格式或空');
                },
                isDate: function (obj) { //判断日期类型是否为YYYY-MM-DD格式的类型 date
                    return app.BASE_UTILS.dataValidator.validReg(obj, /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/, '必须为日期格式');
                },
                isDateOrNull: function (obj) { //判断日期类型是否为YYYY-MM-DD格式的类型 date或者null,空
                    return app.BASE_UTILS.dataValidator.validRegOrNull(obj, /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/, '必须为日期格式或空');
                },
                isDateTime: function (obj) { //判断日期类型是否为YYYY-MM-DD hh:mm:ss格式的类型 datetime
                    return app.BASE_UTILS.dataValidator.validReg(obj, /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/, '必须为日期时间格式');
                },
                isDateTimeOrNull: function (obj) { //判断日期类型是否为YYYY-MM-DD hh:mm:ss格式的类型 datetime或者null,空
                    return app.BASE_UTILS.dataValidator.validRegOrNull(obj, /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/, '必须为日期时间格式');
                },
                isTime: function (obj) { //判断日期类型是否为hh:mm:ss格式的类型 time
                    return app.BASE_UTILS.dataValidator.validReg(obj, /^((20|21|22|23|[0-1]\d)\:[0-5][0-9])(\:[0-5][0-9])?$/, '必须为时间格式');
                },
                isTimeOrNull: function (obj) { //判断日期类型是否为hh:mm:ss格式的类型 time或者null,空
                    return app.BASE_UTILS.dataValidator.validRegOrNull(obj, /^((20|21|22|23|[0-1]\d)\:[0-5][0-9])(\:[0-5][0-9])?$/, '必须为时间格式或空');
                },
                isChinese: function (obj) { //判断输入的字符是否为中文 cchar 
                    return app.BASE_UTILS.dataValidator.validReg(obj, /^[\u0391-\uFFE5]+$/, '必须为中文');
                },
                isChineseOrNull: function (obj) { //判断输入的字符是否为中文 cchar或者null,空
                    return app.BASE_UTILS.dataValidator.validRegOrNull(obj, /^[\u0391-\uFFE5]+$/, '必须为中文或空');
                },
                isZip: function (obj) { //判断输入的邮编(只能为六位)是否正确 zip
                    return app.BASE_UTILS.dataValidator.validReg(obj, /^\d{6}$/, '必须为邮编格式');
                },
                isZipOrNull: function (obj) { //判断输入的邮编(只能为六位)是否正确 zip或者null,空
                    return app.BASE_UTILS.dataValidator.validRegOrNull(obj, /^\d{6}$/, '必须为邮编格式或空');
                },
                isDouble: function (obj) { //判断输入的字符是否为双精度 double
                    return app.BASE_UTILS.dataValidator.validReg(obj, /^[-\+]?\d+(\.\d+)?$/, '必须为小数');
                },
                isDoubleOrNull: function (obj) { //判断输入的字符是否为双精度 double或者null,空
                    return app.BASE_UTILS.dataValidator.validRegOrNull(obj, /^[-\+]?\d+(\.\d+)?$/, '必须为小数或空');
                },
                isIDCard: function (obj) { //判断是否为身份证 idcard
                    return app.BASE_UTILS.dataValidator.validReg(obj, /^\d{15}(\d{2}[A-Za-z0-9;])?$/, '必须为身份证格式');
                },
                isIDCardOrNull: function (obj) { //判断是否为身份证 idcard或者null,空
                    return app.BASE_UTILS.dataValidator.validRegOrNull(obj, /^\d{15}(\d{2}[A-Za-z0-9;])?$/, '必须为身份证格式或空');
                },
                isIP: function (obj) { //判断是否为IP地址格式
                    var res = {
                        code: true,
                        msg: ''
                    };
                    var reg = /^(\d+)\.(\d+)\.(\d+)\.(\d+)$/g //匹配IP地址的正则表达式 
                    var flag = false;
                    if (reg.test(obj)) {
                        if (RegExp.$1 < 256 && RegExp.$2 < 256 && RegExp.$3 < 256 && RegExp.$4 < 256) {
                            flag = true
                        };
                    }
                    if (!flag) {
                        res.code = false;
                        res.msg = '必须为IP格式';
                    }
                    return res;
                },
                isIPOrNull: function (obj) { //判断是否为IP地址格式 或者null,空
                    var res = {
                        code: true,
                        msg: ''
                    };
                    if (app.BASE_UTILS.dataValidator.isNotNull(obj) && !app.BASE_UTILS.dataValidator.isIP(obj).code) {
                        res.code = false;
                        res.msg = '必须为IP格式或空';
                    }
                    return res;
                },

                isLenNum: function (obj, n) { //验证是否是n位数字字符串编号 nnum
                    var res = {
                        code: true,
                        msg: ''
                    };
                    var reg = /^[0-9]+$/;
                    obj = $.trim(obj);
                    if (obj.length > n || !reg.test(obj)) {
                        res.code = false;
                        res.msg = '必须为' + n + '位数字';
                    }
                    return res;
                },
                isLenNumOrNull: function (obj, n) { //验证是否是n位数字字符串编号 nnum或者null,空
                    var res = {
                        code: true,
                        msg: ''
                    };
                    if (app.BASE_UTILS.dataValidator.isNotNull(obj).code && !app.BASE_UTILS.dataValidator.isLenNum(obj)) {
                        res.code = false;
                        res.msg = '必须为' + n + '位数字或空';
                    }
                    return res;
                },
                isLenStr: function (obj, n) { //验证是否小于等于n位数的字符串 nchar
                    var res = {
                        code: true,
                        msg: ''
                    };
                    obj = $.trim(obj);
                    if (!app.BASE_UTILS.dataValidator.isNotNull(obj).code || obj.length > n) {
                        res.code = false;
                        res.msg = '必须小于等于' + n + '位字符';
                    }
                    return res;
                },
                isLenStrOrNull: function (obj, n) { //验证是否小于等于n位数的字符串 nchar或者null,空
                    var res = {
                        code: true,
                        msg: ''
                    };
                    obj = $.trim(obj);
                    if (app.BASE_UTILS.dataValidator.isNotNull(obj).code && obj.length > n) {
                        res.code = false;
                        res.msg = '必须小于等于' + n + '位字符或空';
                    }
                    return res;
                }
            }
        }, 
        /**
         * 获取Url字符串操作
         */
        URL_REQUEST_UTILS: {
            /**
             * 获取查询字符串数据
             * @param {string} key 参数名
             */
            get: function (location,key) { 
                var search = location.search.slice(1);
                var arr = search.split("&");
                for (var i = 0; i < arr.length; i++) {
                    var ar = arr[i].split("=");
                    if (ar[0] == key) {
                        if (unescape(ar[1]) == 'undefined') {
                            return "";
                        } else {
                            return unescape(ar[1]);
                        }
                    }
                }
                return "";
            },
            /**
             * 修改Url的查询字符串
             * @param {string} url 
             * @param {string} key 
             * @param {string} value 
             */
            set: function (url, key, value) {
                var newUrl = "";
                var reg = new RegExp("(^|)" + key + "=([^&]*)(|$)");
                var tmp = key + "=" + value;
                if (url.match(reg) != null) {
                    newUrl = url.replace(eval(reg), tmp);
                } else {
                    if (url.match("[\?]")) {
                        newUrl = url + "&" + tmp;
                    } else {
                        newUrl = url + "?" + tmp;
                    }
                }
                return newUrl;
            }
        },
        /**
         * 模态框处理
         */
        MODAL_UTILS: {
            msgotps: {
                width: 250,
                autodestroy: 2000,
                position: [50, 'tc'],
            },
            /**
             * 成功弹框
             * @param {string} msg 
             */
            success: function (msg) {
                var opts = $.extend(this.msgotps, {
                    bgColor: "green"
                })
                if (!msg) {
                    msg = "保存成功"
                }
                var m = "<div class='msgtext'><i class='icon fa fa-check'></i>" + msg + "<div>";
                layx.msg(m, opts);
            },
            /**
             * 失败弹框
             * @param {string} msg 
             */
            error: function (msg) {
                var opts = $.extend(this.msgotps, {
                    bgColor: "red"
                })
                if (!msg) {
                    msg = "保存失败"
                }
                var m = "<div class='msgtext'><i class='icon fa fa-times'></i>" + msg + "<div>"; 
                layx.msg(m, opts);
            },
            /**
             * 警告弹框
             * @param {string} msg 
             */
            warning: function (msg) {
                var opts = $.extend(this.msgotps, {
                    bgColor: "#ec9c08"
                })
                if (!msg) {
                    msg = "保存失败"
                }
                var m = "<div class='msgtext'><i class='icon fa fa-warning'></i>" + msg + "<div>";
                layx.msg(m, opts);
            },
            /**
             * 确认提示
             * @param {object} options 
             */
            confirm: function (options) {
                var _default = {
                    caption: "询问消息",
                    msg: "",
                    callback: undefined,
                    opts: {
                        dialogIcon: "help"
                    },
                }

                var opts = $.extend(_default, options)

                layx.confirm(opts.caption, opts.msg, function (id) {
                    if (opts.callback) {
                        opts.callback();
                    }
                    layx.destroy(id);
                }, opts.opts);

            },
            /**
             * 打开一个新窗体
             * @param {Object} options
             */
           /* open:function(options){
            	var _default = {
                    id:"1"
            	}
            	var opts = $.extend(_default, options)
            	
            	alert(opts.url)
            	
            	layx.iframe(opts.id,opts.title,opts.url,opts.options);
            }*/
           
	    },
	    			    
    }
   
	return app;
})(window.jQuery);





/**
 * jquery扩展方法
 */
// $.fn.extend({
//     /**
//      * 右键菜单处理
//      */
//     Contextmenu: function () {
//         var element = $(this);
//         var oMenu = $('.contextmenu');
//         $(document).click(function () {
//             oMenu.hide();
//         });
//         $(document).mousedown(function (e) {
//             if (3 == e.which) {
//                 oMenu.hide();
//             }
//         })
//         var aUl = oMenu.find("ul");
//         var aLi = oMenu.find("li");
//         var showTimer = hideTimer = null;
//         var i = 0;
//         var maxWidth = maxHeight = 0;
//         var aDoc = [document.documentElement.offsetWidth, document.documentElement.offsetHeight];
//         oMenu.hide();
//         for (i = 0; i < aLi.length; i++) {
//             //为含有子菜单的li加上箭头
//             aLi[i].getElementsByTagName("ul")[0] && (aLi[i].className = "sub");
//             //鼠标移入
//             aLi[i].onmouseover = function () {
//                 var oThis = this;
//                 var oUl = oThis.getElementsByTagName("ul");
//                 //鼠标移入样式
//                 oThis.className += " active";
//                 //显示子菜单
//                 if (oUl[0]) {
//                     clearTimeout(hideTimer);
//                     showTimer = setTimeout(function () {
//                         for (i = 0; i < oThis.parentNode.children.length; i++) {
//                             oThis.parentNode.children[i].getElementsByTagName("ul")[0] &&
//                                 (oThis.parentNode.children[i].getElementsByTagName("ul")[0].style.display = "none");
//                         }
//                         oUl[0].style.display = "block";
//                         oUl[0].style.top = oThis.offsetTop + "px";
//                         oUl[0].style.left = oThis.offsetWidth + "px";

//                         //最大显示范围					
//                         maxWidth = aDoc[0] - oUl[0].offsetWidth;
//                         maxHeight = aDoc[1] - oUl[0].offsetHeight;

//                         //防止溢出
//                         maxWidth < getOffset.left(oUl[0]) && (oUl[0].style.left = -oUl[0].clientWidth + "px");
//                         maxHeight < getOffset.top(oUl[0]) && (oUl[0].style.top = -oUl[0].clientHeight + oThis.offsetTop + oThis.clientHeight + "px")
//                     }, 300);
//                 }
//             };
//             //鼠标移出	
//             aLi[i].onmouseout = function () {
//                 var oThis = this;
//                 var oUl = oThis.getElementsByTagName("ul");
//                 //鼠标移出样式
//                 oThis.className = oThis.className.replace(/\s?active/, "");

//                 clearTimeout(showTimer);
//                 hideTimer = setTimeout(function () {
//                     for (i = 0; i < oThis.parentNode.children.length; i++) {
//                         oThis.parentNode.children[i].getElementsByTagName("ul")[0] &&
//                             (oThis.parentNode.children[i].getElementsByTagName("ul")[0].style.display = "none");
//                     }
//                 }, 300);
//             };
//         }
//         //自定义右键菜单
//         $(element).bind("contextmenu", function () {
//             var event = event || window.event;
//             oMenu.show();
//             oMenu.css('top', event.clientY + "px");
//             oMenu.css('left', event.clientX + "px");
//             //最大显示范围
//             maxWidth = aDoc[0] - oMenu.width();
//             maxHeight = aDoc[1] - oMenu.height();
//             //防止菜单溢出
//             if (oMenu.offset().top > maxHeight) {
//                 oMenu.css('top', maxHeight + "px");
//             }
//             if (oMenu.offset().left > maxWidth) {
//                 oMenu.css('left', maxWidth + "px");
//             }
//             return false;
//         }).bind("click", function () {
//             oMenu.hide();
//         });
//     }

// })


// $.fn.ComboBox = function (options) {
//     //options参数：description,height,width,allowSearch,url,param,data
//     var $select = $(this);
//     if (!$select.attr('id')) {
//         return false;
//     }
//     if (options) {
//         if ($select.find('.ui-select-text').length == 0) {
//             var $select_html = "";
//             $select_html += "<div class=\"ui-select-text\" style='color:#999;'>" + options.description + "</div>";
//             $select_html += "<div class=\"ui-select-option\">";
//             $select_html += "<div class=\"ui-select-option-content\" style=\"max-height: " + options.height + "\">" + $select.html() + "</div>";
//             if (options.allowSearch) {
//                 $select_html += "<div class=\"ui-select-option-search\"><input type=\"text\" class=\"form-control\" placeholder=\"搜索关键字\" /><span class=\"input-query\" title=\"Search\"><i class=\"fa fa-search\"></i></span></div>";
//             }
//             $select_html += "</div>";
//             $select.html('');
//             $select.append($select_html);
//         }
//     }
//     var $option_html = $($("<p>").append($select.find('.ui-select-option').clone()).html());
//     $option_html.attr('id', $select.attr('id') + '-option');
//     $select.find('.ui-select-option').remove();
//     if ($option_html.length > 0) {
//         $('body').find('#' + $select.attr('id') + '-option').remove();
//     }
//     $('body').prepend($option_html);
//     var $option = $("#" + $select.attr('id') + "-option");
//     if (options.url != undefined) {
//         $option.find('.ui-select-option-content').html('');
//         $.ajax({
//             url: options.url,
//             data: options.param,
//             type: "GET",
//             dataType: "json",
//             async: false,
//             success: function (data) {
//                 options.data = data;
//                 var json = data;
//                 loadComboBoxView(json);
//             },
//             error: function (XMLHttpRequest, textStatus, errorThrown) {
//                 dialogMsg(errorThrown, -1);
//             }
//         });
//     } else if (options.data != undefined) {
//         var json = options.data;
//         loadComboBoxView(json);
//     } else {
//         $option.find('li').css('padding', "0 5px");
//         $option.find('li').click(function (e) {
//             var data_text = $(this).text();
//             var data_value = $(this).attr('data-value');
//             $select.attr("data-value", data_value).attr("data-text", data_text);
//             $select.find('.ui-select-text').html(data_text).css('color', '#000');
//             $option.slideUp(150);
//             $select.trigger("change");
//             e.stopPropagation();
//         }).hover(function (e) {
//             if (!$(this).hasClass('liactive')) {
//                 $(this).toggleClass('on');
//             }
//             e.stopPropagation();
//         });
//     }

//     function loadComboBoxView(json, searchValue, m) {
//         if (json.length > 0) {
//             var $_html = $('<ul></ul>');
//             if (options.description) {
//                 $_html.append('<li data-value="">' + options.description + '</li>');
//             }
//             $.each(json, function (i) {
//                 var row = json[i];
//                 var title = row[options.title];
//                 if (title == undefined) {
//                     title = "";
//                 }
//                 if (searchValue != undefined) {
//                     if (row[m.text].indexOf(searchValue) != -1) {
//                         $_html.append('<li data-value="' + row[options.id] + '" title="' + title + '">' + row[options.text] + '</li>');
//                     }
//                 } else {
//                     $_html.append('<li data-value="' + row[options.id] + '" title="' + title + '">' + row[options.text] + '</li>');
//                 }
//             });
//             $option.find('.ui-select-option-content').html($_html);
//             $option.find('li').css('padding', "0 5px");
//             $option.find('li').click(function (e) {
//                 var data_text = $(this).text();
//                 var data_value = $(this).attr('data-value');
//                 $select.attr("data-value", data_value).attr("data-text", data_text);
//                 $select.find('.ui-select-text').html(data_text).css('color', '#000');
//                 $option.slideUp(150);
//                 $select.trigger("change");
//                 e.stopPropagation();
//             }).hover(function (e) {
//                 if (!$(this).hasClass('liactive')) {
//                     $(this).toggleClass('on');
//                 }
//                 e.stopPropagation();
//             });
//         }
//     }
//     //操作搜索事件
//     if (options.allowSearch) {
//         $option.find('.ui-select-option-search').find('input').bind("keypress", function (e) {
//             if (event.keyCode == "13") {
//                 var value = $(this).val();
//                 loadComboBoxView($(this)[0].options.data, value, $(this)[0].options);
//             }
//         }).focus(function () {
//             $(this).select();
//         })[0]["options"] = options;
//     }

//     $select.unbind('click');
//     $select.bind("click", function (e) {
//         if ($select.attr('readonly') == 'readonly' || $select.attr('disabled') == 'disabled') {
//             return false;
//         }
//         $(this).addClass('ui-select-focus');
//         if ($option.is(":hidden")) {
//             $select.find('.ui-select-option').hide();
//             $('.ui-select-option').hide();
//             var left = $select.offset().left;
//             var top = $select.offset().top + 29;
//             var width = $select.width();
//             if (options.width) {
//                 width = options.width;
//             }
//             if (($option.height() + top) < $(window).height()) {
//                 $option.slideDown(150).css({
//                     top: top,
//                     left: left,
//                     width: width
//                 });
//             } else {
//                 var _top = (top - $option.height() - 32)
//                 $option.show().css({
//                     top: _top,
//                     left: left,
//                     width: width
//                 });
//                 $option.attr('data-show', true);
//             }
//             $option.css('border-top', '1px solid #ccc');
//             $option.find('li').removeClass('liactive');
//             $option.find('[data-value=' + $select.attr('data-value') + ']').addClass('liactive');
//             $option.find('.ui-select-option-search').find('input').select();
//         } else {
//             if ($option.attr('data-show')) {
//                 $option.hide();
//             } else {
//                 $option.slideUp(150);
//             }
//         }
//         e.stopPropagation();
//     });
//     $(document).click(function (e) {
//         var e = e ? e : window.event;
//         var tar = e.srcElement || e.target;
//         if (!$(tar).hasClass('form-control')) {
//             if ($option.attr('data-show')) {
//                 $option.hide();
//             } else {
//                 $option.slideUp(150);
//             }
//             $select.removeClass('ui-select-focus');
//             e.stopPropagation();
//         }
//     });
//     return $select;
// }
// $.fn.ComboBoxSetValue = function (value) {
//     if ($.isNullOrEmpty(value)) {
//         return;
//     }
//     var $select = $(this);
//     var $option = $("#" + $select.attr('id') + "-option");
//     $select.attr('data-value', value);
//     var data_text = $option.find('ul').find('[data-value=' + value + ']').html();
//     if (data_text) {
//         $select.attr('data-text', data_text);
//         $select.find('.ui-select-text').html(data_text).css('color', '#000');
//         $option.find('ul').find('[data-value=' + value + ']').addClass('liactive')
//     }
//     return $select;
// }
// $.fn.ComboBoxTree = function (options) {
//     //options参数：description,height,allowSearch,appendTo,click,url,param,method,icon
//     var $select = $(this);
//     if (!$select.attr('id')) {
//         return false;
//     }
//     if ($select.find('.ui-select-text').length == 0) {
//         var $select_html = "";
//         $select_html += "<div class=\"ui-select-text\"  style='color:#999;'>" + options.description + "</div>";
//         $select_html += "<div class=\"ui-select-option\">";
//         $select_html += "<div class=\"ui-select-option-content\" style=\"max-height: " + options.height + "\"></div>";
//         if (options.allowSearch) {
//             $select_html += "<div class=\"ui-select-option-search\"><input type=\"text\" class=\"form-control\" placeholder=\"搜索关键字\" /><span class=\"input-query\" title=\"Search\"><i class=\"fa fa-search\" title=\"按回车查询\"></i></span></div>";
//         }
//         $select_html += "</div>";
//         $select.append($select_html);
//     }


//     var $option_html = $($("<p>").append($select.find('.ui-select-option').clone()).html());
//     $option_html.attr('id', $select.attr('id') + '-option');
//     $select.find('.ui-select-option').remove();
//     if (options.appendTo) {
//         $(options.appendTo).prepend($option_html);
//     } else {
//         $('body').prepend($option_html);
//     }
//     var $option = $("#" + $select.attr('id') + "-option");
//     var $option_content = $("#" + $select.attr('id') + "-option").find('.ui-select-option-content');
//     loadtreeview(options.url);

//     function loadtreeview(url) {
//         $option_content.treeview({
//             onnodeclick: function (item) {
//                 $select.attr("data-value", item.id).attr("data-text", item.text);
//                 $select.find('.ui-select-text').html(item.text).css('color', '#000');
//                 $select.trigger("change");
//                 if (options.click) {
//                     options.click(item);
//                 }
//             },
//             height: options.height,
//             url: url,
//             param: options.param,
//             method: options.method,
//             description: options.description
//         });
//     }
//     if (options.allowSearch) {
//         $option.find('.ui-select-option-search').find('input').attr('data-url', options.url);
//         $option.find('.ui-select-option-search').find('input').bind("keypress", function (e) {
//             if (event.keyCode == "13") {
//                 var value = $(this).val();
//                 var url = changeUrlParam($option.find('.ui-select-option-search').find('input').attr('data-url'), "keyword", escape(value));
//                 loadtreeview(url);
//             }
//         }).focus(function () {
//             $(this).select();
//         });
//     }
//     if (options.icon) {
//         $option.find('i').remove();
//         $option.find('img').remove();
//     }
//     $select.find('.ui-select-text').unbind('click');
//     $select.find('.ui-select-text').bind("click", function (e) {
//         if ($select.attr('readonly') == 'readonly' || $select.attr('disabled') == 'disabled') {
//             return false;
//         }
//         $(this).parent().addClass('ui-select-focus');
//         if ($option.is(":hidden")) {
//             $select.find('.ui-select-option').hide();
//             $('.ui-select-option').hide();
//             var left = $select.offset().left;
//             var top = $select.offset().top + 29;
//             var width = $select.width();
//             if (options.width) {
//                 width = options.width;
//             }
//             if (($option.height() + top) < $(window).height()) {
//                 $option.slideDown(150).css({
//                     top: top,
//                     left: left,
//                     width: width
//                 });
//             } else {
//                 var _top = (top - $option.height() - 32);
//                 $option.show().css({
//                     top: _top,
//                     left: left,
//                     width: width
//                 });
//                 $option.attr('data-show', true);
//             }
//             $option.css('border-top', '1px solid #ccc');
//             if (options.appendTo) {
//                 $option.css("position", "inherit")
//             }
//             $option.find('.ui-select-option-search').find('input').select();
//         } else {
//             if ($option.attr('data-show')) {
//                 $option.hide();
//             } else {
//                 $option.slideUp(150);
//             }
//         }
//         e.stopPropagation();
//     });
//     $select.find('li div').click(function (e) {
//         var e = e ? e : window.event;
//         var tar = e.srcElement || e.target;
//         if (!$(tar).hasClass('bbit-tree-ec-icon')) {
//             $option.slideUp(150);
//             e.stopPropagation();
//         }
//     });
//     $(document).click(function (e) {
//         var e = e ? e : window.event;
//         var tar = e.srcElement || e.target;
//         if (!$(tar).hasClass('bbit-tree-ec-icon') && !$(tar).hasClass('form-control')) {
//             if ($option.attr('data-show')) {
//                 $option.hide();
//             } else {
//                 $option.slideUp(150);
//             }
//             $select.removeClass('ui-select-focus');
//             e.stopPropagation();
//         }
//     });
//     return $select;
// }
// $.fn.ComboBoxTreeSetValue = function (value) {
//     if (value == "") {
//         return;
//     }
//     var $select = $(this);
//     var $option = $("#" + $select.attr('id') + "-option");
//     $select.attr('data-value', value);
//     var data_text = $option.find('ul').find('[data-value=' + value + ']').html();
//     if (data_text) {
//         $select.attr('data-text', data_text);
//         $select.find('.ui-select-text').html(data_text).css('color', '#000');
//         $option.find('ul').find('[data-value=' + value + ']').parent().parent().addClass('bbit-tree-selected');
//     }
//     return $select;
// }
// $.fn.GetWebControls = function (keyValue) {
//     var reVal = "";
//     $(this).find('input,select,textarea,.ui-select').each(function (r) {
//         var id = $(this).attr('id');
//         var type = $(this).attr('type');
//         switch (type) {
//             case "checkbox":
//                 if ($("#" + id).is(":checked")) {
//                     reVal += '"' + id + '"' + ':' + '"1",'
//                 } else {
//                     reVal += '"' + id + '"' + ':' + '"0",'
//                 }
//                 break;
//             case "select":
//                 var value = $("#" + id).attr('data-value');
//                 if (value == "") {
//                     value = "&nbsp;";
//                 }
//                 reVal += '"' + id + '"' + ':' + '"' + $.trim(value) + '",'
//                 break;
//             case "selectTree":
//                 var value = $("#" + id).attr('data-value');
//                 if (value == "") {
//                     value = "&nbsp;";
//                 }
//                 reVal += '"' + id + '"' + ':' + '"' + $.trim(value) + '",'
//                 break;
//             default:
//                 var value = $("#" + id).val();
//                 if (value == "") {
//                     value = "&nbsp;";
//                 }
//                 reVal += '"' + id + '"' + ':' + '"' + $.trim(value) + '",'
//                 break;
//         }
//     });
//     reVal = reVal.substr(0, reVal.length - 1);
//     if (!keyValue) {
//         reVal = reVal.replace(/&nbsp;/g, '');
//     }
//     reVal = reVal.replace(/\\/g, '\\\\');
//     reVal = reVal.replace(/\n/g, '\\n');
//     var postdata = jQuery.parseJSON('{' + reVal + '}');
//     //阻止伪造请求
//     //if ($('[name=__RequestVerificationToken]').length > 0) {
//     //    postdata["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
//     //}
//     return postdata;
// };
// $.fn.SetWebControls = function (data) {
//     var $id = $(this)
//     for (var key in data) {
//         var id = $id.find('#' + key);
//         if (id.attr('id')) {
//             var type = id.attr('type');
//             if (id.hasClass("input-datepicker")) {
//                 type = "datepicker";
//             }
//             var value = $.trim(data[key]).replace(/&nbsp;/g, '');
//             switch (type) {
//                 case "checkbox":
//                     if (value == 1) {
//                         id.attr("checked", 'checked');
//                     } else {
//                         id.removeAttr("checked");
//                     }
//                     break;
//                 case "select":
//                     id.ComboBoxSetValue(value);
//                     break;
//                 case "selectTree":
//                     id.ComboBoxTreeSetValue(value);
//                     break;
//                 case "datepicker":
//                     id.val(formatDate(value, 'yyyy-MM-dd'));
//                     break;
//                 default:
//                     id.val(value);
//                     break;
//             }
//         }
//     }
// }

// $.fn.panginationEx = function (options) {
//     var $pager = $(this);
//     if (!$pager.attr('id')) {
//         return false;
//     }
//     var defaults = {
//         firstBtnText: '首页',
//         lastBtnText: '尾页',
//         prevBtnText: '上一页',
//         nextBtnText: '下一页',
//         showInfo: true,
//         showJump: true,
//         jumpBtnText: '跳转',
//         showPageSizes: true,
//         infoFormat: '{start} ~ {end}条，共{total}条',
//         sortname: '',
//         url: "",
//         success: null,
//         beforeSend: null,
//         complete: null
//     };
//     var options = $.extend(defaults, options);
//     var params = $.extend({
//         sidx: options.sortname,
//         sord: "asc"
//     }, options.params);
//     options.remote = {
//         url: options.url, //请求地址
//         params: params, //自定义请求参数
//         beforeSend: function (XMLHttpRequest) {
//             if (options.beforeSend != null) {
//                 options.beforeSend(XMLHttpRequest);
//             }
//         },
//         success: function (result, pageIndex) {
//             //回调函数
//             //result 为 请求返回的数据，呈现数据
//             if (options.success != null) {
//                 options.success(result.rows, pageIndex);
//             }
//         },
//         complete: function (XMLHttpRequest, textStatu) {
//             if (options.complete != null) {
//                 options.complete(XMLHttpRequest, textStatu);
//             }
//             //...
//         },
//         pageIndexName: 'page', //请求参数，当前页数，索引从0开始
//         pageSizeName: 'rows', //请求参数，每页数量
//         totalName: 'records' //指定返回数据的总数据量的字段名
//     }
//     $pager.page(options);
// }
// $.fn.LeftListShowOfemail = function (options) {
//     var $list = $(this);
//     if (!$list.attr('id')) {
//         return false;
//     }
//     $list.append('<ul  style="padding-top: 10px;"></ul>');
//     var defaults = {
//         id: "id",
//         name: "text",
//         img: "fa fa-file-o",

//     };
//     var options = $.extend(defaults, options);
//     $list.height(options.height);
//     $.ajax({
//         url: options.url,
//         data: options.param,
//         type: "GET",
//         dataType: "json",
//         async: false,
//         success: function (data) {
//             $.each(data, function (i, item) {
//                 var $_li = $('<li class="" data-value="' + item[options.id] + '"  data-text="' + item[options.name] + '" ><i class="' + options.img + '" style="vertical-align: middle; margin-top: -2px; margin-right: 8px; font-size: 14px; color: #666666; opacity: 0.9;"></i>' + item[options.name] + '</li>');
//                 if (i == 0) {
//                     $_li.addClass("active");
//                 }
//                 $list.find('ul').append($_li);
//             });
//             $list.find('li').click(function () {
//                 var key = $(this).attr('data-value');
//                 var value = $(this).attr('data-text');
//                 $list.find('li').removeClass('active');
//                 $(this).addClass('active');
//                 options.onnodeclick({
//                     id: key,
//                     name: value
//                 });
//             });
//         },
//         error: function (XMLHttpRequest, textStatus, errorThrown) {
//             dialogMsg(errorThrown, -1);
//         }
//     });
// }
// $.fn.authorizeButton = function () {
//     var $element = $(this);
//     $element.find('a.btn').attr('authorize', 'no')
//     $element.find('ul.dropdown-menu').find('li').attr('authorize', 'no')
//     var moduleId = tabiframeId().substr(6);
//     var data = top.authorizeButtonData[moduleId];
//     if (data != undefined) {
//         $.each(data, function (i) {
//             $element.find("#" + data[i].EnCode).attr('authorize', 'yes');
//         });
//     }
//     $element.find('[authorize=no]').remove();
// }
// $.fn.authorizeColModel = function () {
//     var $element = $(this);
//     var columnModel = $element.jqGrid('getGridParam', 'colModel');
//     $.each(columnModel, function (i) {
//         if (columnModel[i].name != "rn") {
//             $element.hideCol(columnModel[i].name);
//         }
//     });
//     var moduleId = tabiframeId().substr(6);
//     var data = top.authorizeColumnData[moduleId];
//     if (data != undefined) {
//         $.each(data, function (i) {
//             $element.showCol(data[i].EnCode);
//         });
//     }
// }


// $.fn.jqGridEx = function (options) {
//     var $jqGrid = $(this);
//     var _selectedRowIndex;
//     if (!$jqGrid.attr('id')) {
//         return false;
//     }
//     var defaults = {
//         url: "",
//         datatype: "json",
//         height: $(window).height() - 139.5,
//         autowidth: true,
//         colModel: [],
//         viewrecords: true,
//         rowNum: 30,
//         rowList: [30, 50, 100],
//         pager: "#gridPager",
//         sortname: 'CreateDate desc',
//         rownumbers: true,
//         shrinkToFit: false,
//         gridview: true,
//         onSelectRow: function () {
//             _selectedRowIndex = $("#" + this.id).getGridParam('selrow');
//         },
//         gridComplete: function () {
//             $("#" + this.id).setSelection(_selectedRowIndex, false);
//         }
//     };
//     var options = $.extend(defaults, options);
//     $jqGrid.jqGrid(options);
// }
// $.fn.jqGridRowValue = function (code) {
//     var $jgrid = $(this);
//     var json = [];
//     var selectedRowIds = $jgrid.jqGrid("getGridParam", "selarrrow");
//     if (selectedRowIds != undefined && selectedRowIds != "") {
//         var len = selectedRowIds.length;
//         for (var i = 0; i < len; i++) {
//             var rowData = $jgrid.jqGrid('getRowData', selectedRowIds[i]);
//             json.push(rowData[code]);
//         }
//     } else {
//         var rowData = $jgrid.jqGrid('getRowData', $jgrid.jqGrid('getGridParam', 'selrow'));
//         json.push(rowData[code]);
//     }
//     return String(json);
// }
// $.fn.jqGridRow = function () {
//     var $jgrid = $(this);
//     var json = [];
//     var selectedRowIds = $jgrid.jqGrid("getGridParam", "selarrrow");
//     if (selectedRowIds != "") {
//         var len = selectedRowIds.length;
//         for (var i = 0; i < len; i++) {
//             var rowData = $jgrid.jqGrid('getRowData', selectedRowIds[i]);
//             json.push(rowData);
//         }
//     } else {
//         var rowData = $jgrid.jqGrid('getRowData', $jgrid.jqGrid('getGridParam', 'selrow'));
//         json.push(rowData);
//     }
//     return json;
// }