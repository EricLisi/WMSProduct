function guid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

var FileOper = {
    ExportExcel: function (options) {//列表导出Excel
        var _default = {
            id: "ExcelIExportDialog",
            title: "导出",
            gridId: "gridList",
            width: "800px",
            height: "480px",
            router: "",
            searchId: "",
            parmlist: ""
        }
        options = $.extend(_default, options);

        var data = {
            gridId: options.gridId,
            router: options.router,
            searchId: options.searchId,
            parmlist: options.parmlist
        }

        var id = guid()

        sessionStorage.setItem(id, JSON.stringify(data))


        $.modalOpen({
            id: options.Id,
            title: options.title,
            url: "/Utility/ExcelExportForm?id=" + id,
            width: options.width,
            height: options.height,
            callBack: function (iframeId) {
                top.frames[iframeId].AcceptClick();
            }, btn: ['导出Excel', '关闭']
        });
    },
    Uploadify: function (options) {//上传文件
        var _default = {
            id: "upload",
            title: "上传文件",
            folderId: "",
            width: "600px",
            height: "440px",
            router: "",
            fileType: ""
        }
        options = $.extend(_default, options);
        $.modalOpen({
            id: options.id,
            title: options.title,
            url: '/Utility/UploadifyForm?router=' + options.router,
            width: options.width,
            height: options.height,
            btn: null
        });
    },
    Uploadify1: function (options) {//上传文件
        var _default = {
            id: "upload1",
            title: "上传文件",
            folderId: "",
            width: "600px",
            height: "440px",
            router: "",
            fileType: ""
        }
        options = $.extend(_default, options);
        $.modalOpen({
            id: options.id,
            title: options.title,
            url: '/Utility/UploadifyForm1?router=' + options.router,
            width: options.width,
            height: options.height,
            btn: null
        });
    }
}

//获取列信息
function GetGridColumns(options) {
    var _default = {
        page: "/PrintManage/Document",//页面Url
        gridId: "gridList",//表格Id

    }
    options = $.extend(_default, options);
    var colModel = [];
    var dataurl = undefined;
    $.ajax({
        url: options.page + "/GetGridColumns",
        data: options,
        dataType: "json",
        async: false,
        success: function (data) {
            //dataurl = data[0].F_DataUrl
            $.each(data, function (i, n) {
                //动态拼接对象
                var obj = {};
                obj.label = n.F_Label
                obj.name = n.F_Name;
                obj.hidden = n.F_Hidden ? true : undefined;
                obj.key = n.F_Key ? true : undefined;
                obj.align = n.F_Align ? n.F_Align : undefined;
                obj.width = n.F_Width ? n.F_Width : undefined;
                obj.editable = n.F_Editable ? true : undefined;
                if (n.F_Formatter) {
                    obj.formatter = n.F_Formatter;
                }
                colModel.push(obj);
            });
        }
    });
    var str = JSON.stringify(colModel);
    colModel = eval(str.replace('"function', 'function').replace(';}"}', ';}}').replace('}"}', '}}'));
    //return dataurl;
    return colModel;
}



//带按钮的文本框空间
function getCellEditButtonTextCtrl(value, options) {
    var el = document.createElement("div");
    el.className = "input-group";
    var html = ' <input type="text" class="form-control" style="width:100px;float:left;margin-top:-30px;" readonly = true value=' + value + '"> ' +
                        '<button type="button" class="btn  btn-primary" style = "float:left;margin-top:-28px;" onclick="getCorp(this)"><i class="fa fa-search"></i></button> ' //+
    el.innerHTML = html;
    return el;
};

//获取buttontext的值
function getCellEditButtonValue(elem, operation, value) {
    if (operation === 'get') {
        return $(elem).val();
    } else if (operation === 'set') {
        $(elem).val(value);
    }
};


$(function () {
    document.body.className = localStorage.getItem('config-skin');
    $("[data-toggle='tooltip']").tooltip();
})
$.reload = function () {
    location.reload();
    return false;
}
$.loading = function (bool, text) {
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
}
$.request = function (name) {
    var search = location.search.slice(1);
    var arr = search.split("&");
    for (var i = 0; i < arr.length; i++) {
        var ar = arr[i].split("=");
        if (ar[0] == name) {
            if (unescape(ar[1]) == 'undefined') {
                return "";
            } else {
                return unescape(ar[1]);
            }
        }
    }
    return "";
}
$.currentWindow = function () {
    var iframeId = top.$(".NFine_iframe:visible").attr("id");
    return top.frames[iframeId];
}
$.browser = function () {
    var userAgent = navigator.userAgent;
    var isOpera = userAgent.indexOf("Opera") > -1;
    if (isOpera) {
        return "Opera"
    };
    if (userAgent.indexOf("Firefox") > -1) {
        return "FF";
    }
    if (userAgent.indexOf("Chrome") > -1) {
        if (window.navigator.webkitPersistentStorage.toString().indexOf('DeprecatedStorageQuota') > -1) {
            return "Chrome";
        } else {
            return "360";
        }
    }
    if (userAgent.indexOf("Safari") > -1) {
        return "Safari";
    }
    if (userAgent.indexOf("compatible") > -1 && userAgent.indexOf("MSIE") > -1 && !isOpera) {
        return "IE";
    };
}
$.download = function (url, data, method) {
    if (url && data) {
        data = typeof data == 'string' ? data : jQuery.param(data);
        var inputs = '';
        $.each(data.split('&'), function () {
            var pair = this.split('=');
            inputs += '<input type="hidden" name="' + pair[0] + '" value="' + pair[1] + '" />';
        });
        $('<form action="' + url + '" method="' + (method || 'post') + '">' + inputs + '</form>').appendTo('body').submit().remove();
    };
};
$.modalOpen = function (options) {
    var defaults = {
        id: null,
        title: '系统窗口',
        width: "100px",
        height: "100px",
        url: '',
        shade: 0.3,
        btn: ['确认', '关闭'],
        btnclass: ['btn btn-primary', 'btn btn-danger'],
        callBack: null,
        endCallBack: null,
        isClosed: false//是否要执行完callback后关闭
    };
    var options = $.extend(defaults, options);
    //var _width = top.$(window).width() > parseInt(options.width.replace('px', '')) ? options.width : top.$(window).width() + 'px';
    //var _height = top.$(window).height() > parseInt(options.height.replace('px', '')) ? options.height : top.$(window).height() + 'px';
    var _this = top.layer
    _this.open({
        id: options.id,
        type: 2,
        shade: options.shade,
        title: options.title,
        fix: false,
        area: [options.width, options.height],
        content: options.url,
        btn: options.btn,
        btnclass: options.btnclass,
        success: function (layero, index) {
            if (options.success) {
                options.success(layero, index, _this);
            }
        },
        yes: function (index) {
            options.callBack(options.id, index)
            if (options.isClosed) {
                top.layer.close(index);
            }
        }, cancel: function () {
            return true;
        }, end: function () {
            if (options.endCallBack) {
                options.endCallBack();
            }
        }
    });
}

/**
* 高级查询
* @parm {Object} options: id:girdId,router:路由
*
*/
$.AdvenSearch = function (options) {
    var _default = {
        id: "gridList",
        title: "条件查询",
        width: "800px",
        height: "500px",
        searchId: "",
        btn: null
    }
    options = $.extend(_default, options);

    $.modalOpen({
        id: options.id,
        title: options.title,
        url: '/Utility/GridSearch?gridId=' + options.id + '&router=' + options.router + "&searchId=" + options.searchId,
        width: options.width,
        height: options.height,
        btn: options.btn
    });
}



$.modalConfirm = function (content, callBack) {
    top.layer.confirm(content, {
        icon: "fa-exclamation-circle",
        title: "系统提示",
        btn: ['确认', '取消'],
        btnclass: ['btn btn-primary', 'btn btn-danger'],
    }, function (index) {
        callBack(true, index);
    }, function () {
        callBack(false)
    });
}
$.modalAlert = function (content, type) {
    var icon = "";
    if (type == 'success') {
        icon = "fa-check-circle";
    }
    if (type == 'error') {
        icon = "fa-times-circle";
    }
    if (type == 'warning') {
        icon = "fa-exclamation-circle";
    }
    top.layer.alert(content, {
        icon: icon,
        title: "系统提示",
        btn: ['确认'],
        btnclass: ['btn btn-primary'],
    });
}
$.modalMsg = function (content, type) {
    if (type != undefined) {
        var icon = "";
        if (type == 'success') {
            icon = "fa-check-circle";
        }
        if (type == 'error') {
            icon = "fa-times-circle";
        }
        if (type == 'warning') {
            icon = "fa-exclamation-circle";
        }
        top.layer.msg(content, { icon: icon, time: 4000, shift: 5 });
        top.$(".layui-layer-msg").find('i.' + icon).parents('.layui-layer-msg').addClass('layui-layer-msg-' + type);
    } else {
        top.layer.msg(content);
    }
}
$.modalClose = function () {
    var index = top.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
    var $IsdialogClose = top.$("#layui-layer" + index).find('.layui-layer-btn').find("#IsdialogClose");
    var IsClose = $IsdialogClose.is(":checked");
    if ($IsdialogClose.length == 0) {
        IsClose = true;
    }
    if (IsClose) {
        top.layer.close(index);
    } else {
        location.reload();
    }
}
//新增
$.modalClose2 = function (name) {
    var index = top.layer.getFrameIndex(name); //先得到当前iframe层的索引
    var $IsdialogClose = top.$("#layui-layer" + index).find('.layui-layer-btn').find("#IsdialogClose");
    var IsClose = $IsdialogClose.is(":checked");
    if ($IsdialogClose.length == 0) {
        IsClose = true;
    }
    if (IsClose) {
        top.layer.close(index);
    } else {
        location.reload();
    }
}
$.submitForm = function (options) {
    var defaults = {
        url: "",
        param: [],
        loading: "正在提交数据...",
        success: null,
        close: true
    };
    var options = $.extend(defaults, options);
    $.loading(true, options.loading);
    window.setTimeout(function () {
        if ($('[name=__RequestVerificationToken]').length > 0) {
            options.param["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
        }
        $.ajax({
            url: options.url,
            data: options.param,
            type: "post",
            dataType: "json",
            success: function (data) {
                if (data.state == "success") {
                    options.success(data);
                    $.modalMsg(data.message, data.state);
                    if (options.close == true) {
                        $.modalClose();
                    }
                } else {
                    $.modalAlert(data.message, data.state);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.loading(false);
                $.modalMsg(errorThrown, "error");
            },
            beforeSend: function () {
                $.loading(true, options.loading);
            },
            complete: function () {
                $.loading(false);
            }
        });
    }, 500);
}
$.deleteForm = function (options) {
    var defaults = {
        prompt: "注：您确定要删除该项数据吗？",
        url: "",
        param: [],
        loading: "正在删除数据...",
        success: null,
        close: true
    };
    var options = $.extend(defaults, options);
    if ($('[name=__RequestVerificationToken]').length > 0) {
            options.param["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
    }
    $.modalConfirm(options.prompt, function (r) {
        if (r) {
            $.loading(true, options.loading);
            window.setTimeout(function () {
                $.ajax({
                    url: options.url,
                    data: options.param,
                    type: "post",
                    dataType: "json",
                    success: function (data) {
                        if (data.state == "success") {
                            options.success(data);
                            $.modalMsg(data.message, data.state);
                        } else {
                            $.modalAlert(data.message, data.state);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        $.loading(false);
                        $.modalMsg(errorThrown, "error");
                    },
                    beforeSend: function () {
                        $.loading(true, options.loading);
                    },
                    complete: function () {
                        $.loading(false);
                    }
                });
            }, 500);
        }
    });

}
$.jsonWhere = function (data, action) {
    if (action == null) return;
    var reval = new Array();
    $(data).each(function (i, v) {
        if (action(v)) {
            reval.push(v);
        }
    })
    return reval;
}
$.fn.jqGridRowValue = function () {
    var $grid = $(this);
    var selectedRowIds = $grid.jqGrid("getGridParam", "selarrrow");
    if (selectedRowIds != "") {
        var json = [];
        var len = selectedRowIds.length;
        for (var i = 0; i < len ; i++) {
            var rowData = $grid.jqGrid('getRowData', selectedRowIds[i]);
            json.push(rowData);
        }
        return json;
    } else {
        return $grid.jqGrid('getRowData', $grid.jqGrid('getGridParam', 'selrow'));
    }
}
$.fn.formValid = function () {
    return $(this).valid({
        errorPlacement: function (error, element) {
            element.parents('.formValue').addClass('has-error');
            element.parents('.has-error').find('i.error').remove();
            element.parents('.has-error').append('<i class="form-control-feedback fa fa-exclamation-circle error" data-placement="left" data-toggle="tooltip" title="' + error + '"></i>');
            $("[data-toggle='tooltip']").tooltip();
            if (element.parents('.input-group').hasClass('input-group')) {
                element.parents('.has-error').find('i.error').css('right', '33px')
            }
        },
        success: function (element) {
            element.parents('.has-error').find('i.error').remove();
            element.parent().removeClass('has-error');
        }
    });
}
$.fn.formSerialize = function (formdate) {
    var element = $(this);
    if (!!formdate) {
        for (var key in formdate) {
            var $id = element.find('#' + key);
            var value = $.trim(formdate[key]).replace(/&nbsp;/g, '');
            var type = $id.attr('type');
            if ($id.hasClass("select2-hidden-accessible")) {
                type = "select";
            }
            switch (type) {
                case "checkbox":
                    if (value == "true") {
                        $id.attr("checked", 'checked');
                    } else {
                        $id.removeAttr("checked");
                    }
                    break;
                case "select":
                    if (value.indexOf(value, ',') == -1) {
                        $id.val(value).trigger("change");
                    }
                    else {
                        $id.val(value.split(',')).trigger("change");
                    }
                    break;
                default:
                    $id.val(value);

                    break;
            }
        };
        return false;
    }
    var postdata = {};
    element.find('input,select,textarea').each(function (r) {
        var $this = $(this);
        var id = "";
        if ($this.attr('name')) {
            id = $this.attr('name');
        }
        else {
            id = $this.attr('id');
        }
     
        var type = $this.attr('type');
        var tagname = $this.prop("tagName")

        switch (tagname) {
            case "SELECT":
                var value = $this.val();// == "" ? "&nbsp;" : $this.val();
                if (!value) {
                    postdata[id] = ""
                }
                else if (typeof (value) == "string") {
                    if (!$.request("keyValue")) {
                        value = value.replace(/&nbsp;/g, '');
                    }
                    postdata[id] = value;
                } else {
                    value = value.join(',');
                    if (!$.request("keyValue")) {
                        value = value.replace(/&nbsp;/g, '');
                    }
                    postdata[id] = value;
                }
                break;
            default:
                switch (type) {
                    case "checkbox":
                        postdata[id] = $this.is(":checked");
                        break;
                    default:
                        var value = $this.val() == "" ? "&nbsp;" : $this.val();
                        if (!$.request("keyValue")) {
                            value = value.replace(/&nbsp;/g, '');
                        }
                        postdata[id] = value;
                        break;
                }
                break;
        }

    });
    if ($('[name=__RequestVerificationToken]').length > 0) {
        postdata["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
    }
    return postdata;
};
$.fn.bindSelect = function (options) {
    var defaults = {
        id: "id",
        text: "text",
        search: false,
        url: "",
        param: [],
        change: null
    };
    var options = $.extend(defaults, options);
    var $element = $(this);
    if (options.url != "") {
        $.ajax({
            url: options.url,
            data: options.param,
            dataType: "json",
            async: false,
            success: function (data) {
                $.each(data, function (i) {
                    $element.append($("<option></option>").val(data[i][options.id]).html(data[i][options.text]));
                });
                $element.select2({
                    minimumResultsForSearch: options.search == true ? 0 : -1
                });
                $element.on("change", function (e) {
                    if (options.change != null) {
                        options.change(data[$(this).find("option:selected").index()]);
                    }
                    $("#select2-" + $element.attr('id') + "-container").html($(this).find("option:selected").text().replace(/　　/g, ''));
                });
            }
        });
    } else {
        $element.select2({
            minimumResultsForSearch: -1
        });
    }

    return $element;
}
$.fn.authorizeButton = function () {
    if (top.$(".NFine_iframe:visible").attr("id")) {
        var moduleId = top.$(".NFine_iframe:visible").attr("id").substr(6);
        var dataJson = top.clients.authorizeButton[moduleId];
        var $element = $(this);
        $element.find('a[authorize=yes]').attr('authorize', 'no');
        if (dataJson != undefined) {
            $.each(dataJson, function (i) {
                $element.find("#" + dataJson[i].F_EnCode).attr('authorize', 'yes');
            });
        }
        $element.find("[authorize=no]").parents('li').prev('.split').remove();
        $element.find("[authorize=no]").parents('li').remove();
        $element.find('[authorize=no]').remove();
    }

}
$.fn.dataGrid = function (options) {
    var defaults = {
        datatype: "json",
        autowidth: true,
        rownumbers: true,
        shrinkToFit: false,
        gridview: true,
    };
    var options = $.extend(defaults, options);
    var $element = $(this);
    var $selectRowId = undefined;
    options["onSelectRow"] = function (rowid) {
        if (options["bCellEdit"]) {
            if (rowid && rowid !== $selectRowId) {
                $element.jqGrid('restoreRow', $selectRowId);
                $element.jqGrid('editRow', rowid, true);
                $selectRowId = rowid;
            }
        }
        else {
            if ($(this).jqGrid("getGridParam", "selrow") != null) {
                var length = $(this).jqGrid("getGridParam", "selrow").length;
                var $operate = $(".operate");
                if (length > 0) {
                    $operate.animate({ "left": 0 }, 200);
                } else {
                    $operate.animate({ "left": '-100.1%' }, 200);
                }
                $operate.find('.close').click(function () {
                    $operate.animate({ "left": '-100.1%' }, 200);
                })
            }
        }
    };

    $element.jqGrid(options);

    //if (options.pager) {
    //    $element.jqGrid(options).navGrid(options.pager, {}, true, true, true, true, true).navButtonAdd(options.pager, {
    //        caption: "Del", 
    //        buttonicon: "ui-icon-del", 
    //        onClickButton: function () { 
    //            alert("Deleting Row");

    //        },

    //        position: "last"

    //    });;
    //}
    //else {
    //    $element.jqGrid(options);
    //}

};


$.fn.DefalutDate = function () {//默认值设置 默认为时间格式
    var _this = $(this);
    var myDate = new Date();
    var month = myDate.getMonth() + 1;
    var day = myDate.getDate();
    var value = myDate.getFullYear() + "-" + (month < 10 ? '0' + month : month) + "-" + (day < 10 ? '0' + day : day);

    _this.val(value)

    return _this;
}

//千分位
function toThousands(num) {
    var str_n = num.toString();
    var result = "";
    while (str_n.length > 3) {
        result = "," + str_n.slice(-3) + result;
        str_n = str_n.slice(0, str_n.length - 3)
    }
    if (str_n) {
        return str_n + result
    }
}



/**
 * 根据类型获取单据类型
 */
function getOrderType(type) {
    var orderType = "";
    switch (type) {
        case "zcly":
            orderType = "资产领用";
            break;
        case "zcjy":
            orderType = "资产借用";
            break;
        case "zcgh":
            orderType = "资产归还";
            break;
        case "zcwx":
            orderType = "资产维修";
            break;
        case "zccl":
            orderType = "资产处理";
            break;
        case "zcdr":
            orderType = "资产调入";
            break;
        case "zcdc":
            orderType = "资产调出";
            break;
        case "zcbg":
            orderType = "资产变更";
            break;
        case "zcpd":
            orderType = "资产盘点";
            break;
    }

    return orderType
}