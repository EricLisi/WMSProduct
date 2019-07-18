var remoteUrl = 'http://192.168.168.79:9886/api/';//远程服务器地址

(function ($) {
    var _ajax = $.ajax;
    $.ajax = function (options) {
        if (options.url) {
            options.url = remoteUrl + options.url
        }
        var _options = options;
        //默认加上认证头
        if (!options.noheader) {
            _options = $.extend(options, {
                headers: {
                    'Bearer': localStorage.getItem('token')
                }
            });
        } 
        _ajax(options);
    };
})(jQuery);
