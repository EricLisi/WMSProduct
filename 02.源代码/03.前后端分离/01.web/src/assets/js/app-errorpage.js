(function ($, app) {
    /**
     * 错误常量集合
     */
    const errorlist = [{
            code: "400",
            desc: "（错误请求） 服务器不理解请求的语法"
        },
        {
            code: "401",
            desc: "（未授权） 请求要求身份验证。 对于需要登录的网页，服务器可能返回此响应。"
        }, {
            code: "403",
            desc: "（禁止） 服务器拒绝请求"
        }, {
            code: "404",
            desc: "（未找到） 服务器找不到请求的网页"
        }, {
            code: "405",
            desc: "（方法禁用） 禁用请求中指定的方法"
        }, {
            code: "406",
            desc: "（不接受） 无法使用请求的内容特性响应请求的网页"
        }, {
            code: "407",
            desc: "（需要代理授权） 此状态代码与 401（未授权）类似，但指定请求者应当授权使用代理"
        }, {
            code: "408",
            desc: "（请求超时） 服务器等候请求时发生超时"
        }, {
            code: "409",
            desc: "（冲突） 服务器在完成请求时发生冲突。服务器必须在响应中包含有关冲突的信息"
        }, {
            code: "410",
            desc: "（已删除） 如果请求的资源已永久删除，服务器就会返回此响应"
        }, {
            code: "411",
            desc: "（需要有效长度） 服务器不接受不含有效内容长度标头字段的请求"
        }, {
            code: "412",
            desc: "（未满足前提条件） 服务器未满足请求者在请求中设置的其中一个前提条件"
        }, {
            code: "413",
            desc: "（请求实体过大） 服务器无法处理请求，因为请求实体过大，超出服务器的处理能力"
        }, {
            code: "414",
            desc: "请求的 URI（通常为网址）过长，服务器无法处理"
        }, {
            code: "415",
            desc: "（不支持的媒体类型） 请求的格式不受请求页面的支持"
        }, {
            code: "416",
            desc: "（请求范围不符合要求） 如果页面无法提供请求的范围，则服务器会返回此状态代码"
        }, {
            code: "417",
            desc: "（未满足期望值） 服务器未满足期望请求标头字段的要求"
        }, {
            code: "500",
            desc: "（服务器内部错误） 服务器遇到错误，无法完成请求"
        }, {
            code: "501",
            desc: "（尚未实施） 服务器不具备完成请求的功能。例如，服务器无法识别请求方法时可能会返回此代码"
        }, {
            code: "502",
            desc: "（错误网关） 服务器作为网关或代理，从上游服务器收到无效响应"
        }, {
            code: "503",
            desc: "（服务不可用） 服务器目前无法使用（由于超载或停机维护）。通常，这只是暂时状态"
        }, {
            code: "504",
            desc: "（网关超时） 服务器作为网关或代理，但是没有及时从上游服务器收到请求"
        }, {
            code: "505",
            desc: "（HTTP 版本不受支持） 服务器不支持请求中所用的 HTTP 协议版本"
        }
    ]

    /**
     * 页面事件
     */
    var pageEvent = {
        /**
         * 页面初始化
         */
        init: function () {
            var errcode = app.URL_REQUEST_UTILS.get(window.location, 'errorcode')
            errorinfo = pageEvent.getErrorInfo(errcode);
            $("#errorcode").text(errorinfo.code)
            $("#errordesc").text(errorinfo.desc)
            
            $("#back").click(function (e) { 
                if(errcode == "401"){
                    parent.location.href = "../../../login.html"
                }else{
                    history.go(-1);
                }
                
            });
        },
        /**
         * 查找错误信息
         * @param {string} code 
         */
        getErrorInfo: function (code) {
            if (!!!code) {
                return {
                    code: "400",
                    desc: "(错误请求) 服务器不理解请求的语法"
                }
            }

            for (var i = 0; i < errorlist.length; i++) {
                if (errorlist[i].code == code) {
                    return errorlist[i];
                }
            }

            return {
                code: "400",
                desc: "(错误请求) 服务器不理解请求的语法"
            }
        }
    }


    $(function () {
        pageEvent.init();
    })


})(window.jQuery, top.app);