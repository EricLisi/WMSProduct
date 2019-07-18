/*
 * 描 述：弹层选择控件
 */
(function ($, app) {
    "use strict";

    $.appformselect = {
        init: function ($self) {
            var dfop = $self[0]._appformselect.dfop;
            $self.addClass('app-formselect');
            $self.attr('type', 'formselect');
            var $input = $('<span>' + dfop.placeholder + '</span><i class="fa ' + dfop.icon + '"></i><div class="clear-btn" >清空</div>');
            $self.on('click', $.appformselect.click);
            $self.html($input);
        },
        click: function (e) {        	
            var $self = $(this);
            var dfop = $self[0]._appformselect.dfop;
            var et = e.target || e.srcElement;
            var $et = $(et);
            if ($et.hasClass('clear-btn')) {
                dfop._itemValue = { value: "", text: dfop.placeholder };
                $self.removeClass('selected');
                $self.find('span').text(dfop._itemValue.text);
                if (!!dfop.select) {
                    dfop.select(dfop._itemValue);
                }
            }
            else {
                var value = dfop._itemValue ? dfop._itemValue.value : "";
                var _url = dfop.layerUrl;

                if (_url.indexOf('?') != -1) {
                    _url += '&dfopid=' + dfop.id;
                }
                else {
                    _url += '?dfopid=' + dfop.id;
                }
                _url += '&selectValue=' + value;
                _url += '&selectText=' + encodeURI(encodeURI($self.find('span').text()));
                /*app.layerForm({
                    id: dfop.id,
                    title: dfop.placeholder,
                    url: _url,
                    width: dfop.layerUrlW,
                    height: dfop.layerUrlH,
                    maxmin: true,
                    callBack: function (id) {                    	
                        return top[id].acceptClick($.appformselect.callback);
                    }
                });*/                              
                layx.iframe(dfop.id,dfop.placeholder, _url,{
					statusBar:true,
					shadable: true,                                	
                    height: dfop.layerUrlH || 400,
                    width: dfop.layerUrlW || 600,
					buttons:[
					    {					       
					        label: '<i class="fa fa-save" style="margin-right:5px"></i>确认',
					        callback:function(id, button, event){
					                // 获取 iframe 页面 window对象
					                var contentWindow=layx.getFrameContext(id);				               
					                return contentWindow.acceptClick($.appformselect.callback);
					                //return top[id].acceptClick($.appformselect.callback);
					                layx.destroy(id);    
					        },
					         classes: ['btn-primary']
					    },
					    {					       
					        label: '<i class="fa fa-close" style="margin-right:5px"></i>关闭',
					        callback:function(id, button, event){
					                layx.destroy(id);
					                
					        },
					        classes: ['btn-danger']
					    }
					]
			    }); 
            }
        },
        callback: function (item, id, obj) {
            var $self = $('#' + id);
            var dfop = $self[0]._appformselect.dfop;
            top['app_selectform_' + id] = { _obj: obj };
            dfop._itemValue = dfop._itemValue || {};
            if (dfop._itemValue.value != item.value) {
                if (!!dfop.select) {
                    dfop.select(item);
                }
                $self.trigger('change');
            }

            if (item.value == "") {
                item.text = dfop.placeholder;
            }
            else {
                $self.addClass('selected');
            }
            $self.find('span').text(item.text);
            dfop._itemValue = item;
            
        }
    };
    $.fn.appformselect = function (op) {
        var dfop = {
            placeholder: "请选择",
            icon: 'fa-plus',

            layerUrl: false, // 弹层地址
            layerParam: false,
            layerUrlW: 600,
            layerUrlH: 400,
            dataUrl: null,  // 获取数据地址

            select: false,  // 选择事件

        };

        $.extend(dfop, op || {});
        var $self = $(this);
        dfop.id = $self.attr('id');
        if (!dfop.id) {
            return false;
        }
        if (!!$self[0]._appformselect) {
            return $self;
        }

        $self[0]._appformselect = { dfop: dfop };

        $.appformselect.init($self);
        return $self;
    };
    $.fn.appformselectRefresh = function (op) {
        var $self = $(this);
        var dfop = $self[0]._appformselect.dfop;
        $.extend(dfop, op || {});
        dfop._itemValue = null;
        $self.find('span').text(dfop.placeholder);
    };
    $.fn.appformselectGet = function () {
        var $self = $(this);
        var dfop = $self[0]._appformselect.dfop;
        return dfop._itemValue ? dfop._itemValue.value : "";
    };
    $.fn.appformselectSet = function (value) {
        var $self = $(this);
        var dfop = $self[0]._appformselect.dfop;
        if (value == '') {
            dfop._itemValue = { value: '', text: '' };
            $self.removeClass('selected');
            $self.find('span').text(dfop.placeholder);
            return false;
        }
        dfop._itemValue = { value: value };
        app.HTTP_REQUEST_UTILS.httpAsync('GET', dfop.dataUrl, { keyValue: value }, function (data) {
            if (!!data && data !="") {
                dfop._itemValue.text = data;
                $self.addClass('selected');
                $self.find('span').text(data);
            }
        });
    };

    // 弹层列表选择
    $.appGirdSelect = {
        init: function ($self) {
            var dfop = $self[0]._appGirdSelect.dfop;
            $self.addClass('app-formselect');
            $self.attr('type', 'appGirdSelect');
            var $input = $('<span>' + dfop.placeholder + '</span><i class="fa ' + dfop.icon + '"></i><div class="clear-btn" >清空</div>');
            $self.on('click', $.appGirdSelect.click);
            $self.html($input);

            // 异步加载数据
            app.HTTP_REQUEST_UTILS.httpAsync('GET', dfop.url, dfop.param, function (data) {
                dfop._loaded = true;
                dfop._data = data || [];
            });

            top.appGirdSelect = top.appGirdSelect || {};
            top.appGirdSelect[dfop.id] = dfop;
        },
        click: function (e) {
            var $self = $(this);
            var dfop = $self[0]._appGirdSelect.dfop;
            var et = e.target || e.srcElement;
            var $et = $(et);
            if ($et.hasClass('clear-btn')) {
                dfop._itemValue = { value: "", text: dfop.placeholder };
                $self.removeClass('selected');
                $self.find('span').text(dfop._itemValue.text);
                if (!!dfop.select) {
                    dfop.select(dfop._itemValue);
                }
            }
            else {
                var value = dfop._itemValue ? dfop._itemValue.value : "";
                /*app.layerForm({
                    id: dfop.id,
                    title: dfop.placeholder,
                    url: top.$.rootUrl + '/Utility/GirdSelectIndex?dfopid=' + dfop.id,
                    width: dfop.width,
                    height: dfop.height,
                    maxmin: true,
                    callBack: function (id) {
                        return top[id].acceptClick($.appGirdSelect.callback);
                    }
                });*/
                layx.iframe(dfop.id,dfop.placeholder,'../../../Utility/GirdSelectIndex?dfopid=' + dfop.id,{
                	    shadable: true,
					    statusBar:true,
					    width: dfop.width|| 600,
                        height: dfop.height|| 400,
					    buttons:[
					        {
					            label: '<i class="fa fa-save" style="margin-right:5px"></i>保存',
					            callback:function(id, button, event){
					                // 获取 iframe 页面 window对象
					                var contentWindow=layx.getF
					                rameContext(id);
					                contentWindow.acceptClick($.appGirdSelect.callback);
					                layx.destroy(id);    
					            },
					            classes: ['btn-primary']
					        },
					        {
					            label:'取消',label: '<i class="fa fa-close" style="margin-right:5px"></i>取消',
					            callback:function(id, button, event){
					                layx.destroy(id);
					            },
					            classes: ['btn-danger']
					        }
					    ]
			    }); 
            }
        },
        callback: function (item, id) {
            var $self = $('#' + id);
            var dfop = $self[0]._appGirdSelect.dfop;
            dfop._itemValue = dfop._itemValue || {};
            if (dfop._itemValue[dfop.value] != item[dfop.value]) {
                if (!!dfop.select) {
                    dfop.select(item);
                }
                $self.trigger('change');
            }

            if (!item) {
                item.text = dfop.placeholder;
            }
            else {
                $self.addClass('selected');
            }
            $self.find('span').text(item[dfop.text]);
            dfop._itemValue = item;
        }
    }

    $.fn.appGirdSelect = function (op) {
        var dfop = {
            placeholder: "请选择",
            icon: 'fa-plus',
            url: '',
            selectWord: '',
            headData: [],
            value: '',
            text: '',
            width: 600,
            height: 400,
            select: false,     // 选择事件
            param: {},
            _loaded: false
        };

        $.extend(dfop, op || {});
        var $self = $(this);
        dfop.id = $self.attr('id');
        if (!dfop.id) {
            return false;
        }
        if (!!$self[0]._appGirdSelect) {
            return $self;
        }
        $self[0]._appGirdSelect = { dfop: dfop };

        $.appGirdSelect.init($self);
        return $self;
    }
    $.fn.appGirdSelectGet = function () {
        var $this = $(this);
        var dfop = $this[0]._appGirdSelect.dfop;
        dfop._itemValue = dfop._itemValue || {};
        var res = dfop._itemValue[dfop.value] || "";
        return res;
    }
    $.fn.appGirdSelectSet = function (value) {
        var $this = $(this);
        var dfop = $this[0]._appGirdSelect.dfop;
        function set(_value) {
            if (dfop._loaded) {
                $.each(dfop._data, function (id, item) {
                    if (item[dfop.value] == _value) {
                        if (!!dfop.select) {
                            dfop.select(item);
                        }
                        $this.trigger('change');

                        $this.addClass('selected');
                        $this.find('span').text(item[dfop.text]);
                        dfop._itemValue = item;
                        return false;
                    }
                });
            }
            else {
                setTimeout(function () {
                    set(_value);
                }, 100);
            }
        }
        set(value);
    }



})(window.jQuery, top.app);