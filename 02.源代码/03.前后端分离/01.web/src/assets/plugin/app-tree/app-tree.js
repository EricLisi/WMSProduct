﻿/*
 * 描 述：appTree	
 */
(function ($, app) {
    "use strict";
    $.apptree = {
        getItem: function (path, dfop) {
            var ap = path.split(".");
            var t = dfop.data;
            for (var i = 0; i < ap.length; i++) {
                if (i == 0) {
                    t = t[ap[i]];
                }
                else {
                    t = t.ChildNodes[ap[i]];
                }
            }
            return t;
        },
        render: function ($self) {
            var dfop = $self[0]._apptree.dfop;
            // 渲染成树
            var $treeRoot = $('<ul class="app-tree-root" ></ul>');
            var _len = dfop.data.length;
            for (var i = 0; i < _len; i++) {
                var $node = $.apptree.renderNode(dfop.data[i], 0, i, dfop);
                $treeRoot.append($node);
            }
            $self.append($treeRoot);
            $self.appscroll();
            dfop = null;
        },
        renderNode: function (node, deep, path, dfop) {
            if (node.shide) {
                return "";
            }

            node._deep = deep;
            node._path = path;
            // 渲染成单个节点
            var nid = node.id.replace(/[^\w]/gi, "_");
            var title = node.title || node.text;
            var $node = $('<li class="app-tree-node"></li>');
            var $nodeDiv = $('<div id="' + dfop.id + '_' + nid + '" tpath="' + path + '" title="' + title + '"  dataId="' + dfop.id + '"  class="app-tree-node-el" ></div>');
            if (node.hasChildren) {
                var c = (node.isexpand || dfop.isAllExpand) ? 'app-tree-node-expanded' : 'app-tree-node-collapsed';
                $nodeDiv.addClass(c);
            }
            else {
                $nodeDiv.addClass('app-tree-node-leaf');
            }
            // span indent
            var $span = $('<span class="app-tree-node-indent"></span>');
            if (deep == 1) {
                $span.append('<img class="app-tree-icon" src="../../../../assets/images/tree/s.gif"/>');
            }
            else if (deep > 1) {
                $span.append('<img class="app-tree-icon" src="../../../../assets/images/tree/s.gif"/>');
                for (var j = 1; j < deep; j++) {
                    $span.append('<img class="app-tree-icon" src="../../../../assets/images/tree/s.gif"/>');
                }
            }
            $nodeDiv.append($span);
            // img
            var $img = $('<img class="app-tree-ec-icon" src="../../../../assets/images/tree/s.gif"/>');
            $nodeDiv.append($img);
            // checkbox
            if (node.showcheck) {
                if (node.checkstate == null || node.checkstate == undefined) {
                    node.checkstate = 0;
                }
                var $checkBox = $('<img  id="' + dfop.id + '_' + nid + '_cb" + class="app-tree-node-cb" src="' + dfop.cbiconpath + dfop.icons[node.checkstate] + '" />');
                $nodeDiv.append($checkBox);
            }
            // 显示的小图标
            if (node.icon != -1) {
                if (!!node.icon) {
                    $nodeDiv.append('<i class="' + node.icon + '"></i>&nbsp;');
                } else if (node.hasChildren) {
                    if (node.isexpand || dfop.isAllExpand) {
                        $nodeDiv.append('<i class="fa fa-folder-open" style="width:15px">&nbsp;</i>');
                    }
                    else {
                        $nodeDiv.append('<i class="fa fa-folder" style="width:15px">&nbsp;</i>');
                    }
                }
                else {
                    $nodeDiv.append('<i class="fa fa-file-o"></i>&nbsp;');
                }
            }
            // a
            var ahtml = '<a class="app-tree-node-anchor" href="javascript:void(0);">';
            ahtml += '<span data-value="' + node.id + '" class="app-tree-node-text" >' + node.text + '</span>';
            ahtml += '</a>';
            $nodeDiv.append(ahtml);
            // 节点事件绑定
            $nodeDiv.on('click', $.apptree.nodeClick);

            if (!node.complete) {
                $nodeDiv.append('<div class="app-tree-loading"><img class="app-tree-ec-icon" src="' + dfop.cbiconpath + 'loading.gif"/></div>');
            }

            $node.append($nodeDiv);
            if (node.hasChildren) {
                var $treeChildren = $('<ul  class="app-tree-node-ct" >');
                if (!node.isexpand && !dfop.isAllExpand) {
                    $treeChildren.css('display', 'none');
                }
                if (node.ChildNodes) {
                    var l = node.ChildNodes.length;
                    for (var k = 0; k < l; k++) {
                        node.ChildNodes[k].parent = node;
                        var $childNode = $.apptree.renderNode(node.ChildNodes[k], deep + 1, path + "." + k, dfop);
                        $treeChildren.append($childNode);
                    }
                    $node.append($treeChildren);
                }
            }
            node.render = true;
            dfop = null;
            return $node;
        },
        renderNodeAsync: function ($this, node, dfop) {
            var $treeChildren = $('<ul  class="app-tree-node-ct" >');
            if (!node.isexpand && !dfop.isAllExpand) {
                $treeChildren.css('display', 'none');
            }
            if (node.ChildNodes) {
                var l = node.ChildNodes.length;
                for (var k = 0; k < l; k++) {
                    node.ChildNodes[k].parent = node;
                    var $childNode = $.apptree.renderNode(node.ChildNodes[k], node._deep + 1, node._path + "." + k, dfop);
                    $treeChildren.append($childNode);
                }
                $this.parent().append($treeChildren);
            }
            return $treeChildren;
        },
        renderToo: function ($self) {
            var dfop = $self[0]._apptree.dfop;
            // 渲染成树
            var $treeRoot = $self.find('.app-tree-root');
            $treeRoot.html('');
            var _len = dfop.data.length;
            for (var i = 0; i < _len; i++) {
                var $node = $.apptree.renderNode(dfop.data[i], 0, i, dfop);
                $treeRoot.append($node);
            }
            dfop = null;
        },
        nodeClick: function (e) {
            var et = e.target || e.srcElement;
            var $this = $(this);
            var $parent = $('#' + $this.attr('dataId'));
            var dfop = $parent[0]._apptree.dfop;
            if (et.tagName == 'IMG') {
                var $et = $(et);
                var $ul = $this.next('.app-tree-node-ct');
                if ($et.hasClass("app-tree-ec-icon")) {
                    if ($this.hasClass('app-tree-node-expanded')) {
                        $ul.slideUp(200, function () {
                            $this.removeClass('app-tree-node-expanded');
                            $this.addClass('app-tree-node-collapsed');
                        });
                    }
                    else if ($this.hasClass('app-tree-node-collapsed')) {
                        // 展开
                        var path = $this.attr('tpath');
                        var node = $.apptree.getItem(path, dfop);
                        if (!node.complete) {
                            if (!node._loading) {
                                node._loading = true;// 表示正在加载数据
                                $this.find('.app-tree-loading').show();
                                app.HTTP_REQUEST_UTILS.httpAsync('GET', dfop.url, { parentId: node.id }, function (data) {
                                    if (!!data) {
                                        node.ChildNodes = data;
                                        $ul = $.apptree.renderNodeAsync($this, node, dfop);
                                        $ul.slideDown(200, function () {
                                            $this.removeClass('app-tree-node-collapsed');
                                            $this.addClass('app-tree-node-expanded');
                                        });
                                        node.complete = true;
                                        $this.find('.app-tree-loading').hide();
                                    }
                                    node._loading = false;
                                });
                            }
                        }
                        else {
                            $ul.slideDown(200, function () {
                                $this.removeClass('app-tree-node-collapsed');
                                $this.addClass('app-tree-node-expanded');
                            });
                        }                       
                    }

                }
                else if ($et.hasClass("app-tree-node-cb")) {
                    var path = $this.attr('tpath');
                    var node = $.apptree.getItem(path, dfop);
                   
                    if (node.checkstate == 1) {
                        node.checkstate = 0;
                    }
                    else {
                        node.checkstate = 1;
                    }
                    $et.attr('src', dfop.cbiconpath + dfop.icons[node.checkstate]);
                    $.apptree.checkChild($.apptree.check, node, node.checkstate, dfop);
                    $.apptree.checkParent($.apptree.check, node, node.checkstate, dfop);
                    if (!!dfop.nodeCheck) {
                        dfop.nodeCheck(node, $this);
                    }
                }
            }
            else {
                var path = $this.attr('tpath');
                var node = $.apptree.getItem(path, dfop);
                dfop.currentItem = node;
                $('#' + dfop.id).find('.app-tree-selected').removeClass('app-tree-selected');
                $this.addClass('app-tree-selected');
                if (!!dfop.nodeClick) {
                    dfop.nodeClick(node, $this);
                }
            }
            return false;
        },
        check: function (item, state, type, dfop) {
            var pstate = item.checkstate;
            if (type == 1) {
                item.checkstate = state;
            }
            else {// go to childnodes
                var cs = item.ChildNodes;
                var l = cs.length;
                var ch = true;
                for (var i = 0; i < l; i++) {
                    cs[i].checkstate = cs[i].checkstate || 0;
                    if ((state == 1 && cs[i].checkstate != 1) || state == 0 && cs[i].checkstate != 0) {
                        ch = false;
                        break;
                    }
                }
                if (ch) {
                    item.checkstate = state;
                }
                else {
                    item.checkstate = 2;
                }
            }
            //change show
            if (item.render && pstate != item.checkstate) {
                var nid = item.id.replace(/[^\w]/gi, "_");
                var et = $("#" + dfop.id + "_" + nid + "_cb");
                if (et.length == 1) {
                    et.attr("src", dfop.cbiconpath + dfop.icons[item.checkstate]);
                }
            }
        },
        checkParent: function (fn, node, state, dfop) {
            var p = node.parent;
            while (p) {
                var r = fn(p, state, 0, dfop);
                if (r === false) {
                    break;
                }
                p = p.parent;
            }
        },
        checkChild: function (fn, node, state, dfop) {
            if (fn(node, state, 1, dfop) != false) {
                if (node.ChildNodes != null && node.ChildNodes.length > 0) {
                    var cs = node.ChildNodes;
                    for (var i = 0, len = cs.length; i < len; i++) {
                        $.apptree.checkChild(fn, cs[i], state, dfop);
                    }
                }
            }
        },

        search: function (keyword, data) {
            var res = false;
            $.each(data, function (i, row) {
                var flag = false;
                
                if (!app.validator.isNotNull(keyword).code || row.text.indexOf(keyword) != -1) {
                    
                    flag = true;
                }
                if (row.hasChildren) {
                    if ($.apptree.search(keyword, row.ChildNodes)) {
                        flag = true;
                    }
                }
                if (flag) {
                    res = true;
                    row.isexpand = true;
                    row.shide = false;
                }
                else {
                    row.shide = true;
                }
            });
            return res;
        },
        findItem: function (data, id, value) {
            var _item = null;
            _fn(data, id, value);
            function _fn(_cdata, _id, _value) {
                for (var i = 0, l = _cdata.length; i < l; i++) {
                    if (_cdata[i][id] == value) {
                        _item = _cdata[i];
                        return true;
                    }
                    if (_cdata[i].hasChildren && _cdata[i].ChildNodes.length > 0) {
                        if (_fn(_cdata[i].ChildNodes, _id, _value)) {
                            return true;
                        }
                    }
                }
                return false;
            }
            return _item;
        },
        listTotree: function (data, parentId, id, text, value, check) {
            // 只适合小数据计算
            var resdata = [];
            var mapdata = {};
            for (var i = 0, l = data.length; i < l; i++) {
                var item = data[i];
                mapdata[item[parentId]] = mapdata[item[parentId]] || [];
                mapdata[item[parentId]].push(item);
            }
            _fn(resdata, '0');
            function _fn(_data, vparentId) {
                var pdata = mapdata[vparentId] || [];
                for (var j = 0, l = pdata.length; j < l; j++) {
                    var _item = pdata[j];
                    var _point = {
                        id: _item[id],
                        text: _item[text],
                        value: _item[value],
                        showcheck: check,
                        checkstate: false,
                        hasChildren: false,
                        isexpand: false,
                        complete: true,
                        ChildNodes: []
                    };
                    if (_fn(_point.ChildNodes, _item[id])) {
                        _point.hasChildren = true;
                        _point.isexpand = true;
                    }
                    _data.push(_point);
                }
                return _data.length > 0;
            }
            return resdata;
        },
        treeTotree: function (data, id, text, value, check, childId) {
            var resdata = [];
            _fn(resdata, data);
            function _fn(todata,fromdata) {
                for (var i = 0, l = fromdata.length; i < l; i++) {
                    var _item = fromdata[i];
                    var _point = {
                        id: _item[id],
                        text: _item[text],
                        value: _item[value],
                        showcheck: check,
                        checkstate: false,
                        hasChildren: false,
                        isexpand: true,
                        complete: true,
                        ChildNodes: []
                    };
                    if (_item[childId].length > 0) {
                        _point.hasChildren = true;
                        _fn(_point.ChildNodes, _item[childId]);
                    }
                    todata.push(_point);
                }
            }
            return resdata;
        },

        addNode: function ($self, node, Id, index) {// 下一版本完善
            var dfop = $self[0]._apptree.dfop;
            if (!!Id)// 在最顶层
            {
                dfop.data.splice(index, 0, node);
                var $node = $.apptree.renderNode(node, 0, index, dfop);
                if ($self.find('.app-tree-root>li').length == 0) {
                    $self.find('.app-tree-root>li').append($node);
                }
                else {
                    $self.find('.app-tree-root>li').eq(index).before($node);
                }

            }
            else {
                var $parentId = $self.find('#' + dfop.id + '_' + Id);
                var path = $parentId.attr('tpath');
                var $node = $.apptree.renderNode(node, 0, path + '.' + index, dfop);
                if ($parentId.next().children().length == 0) {
                    $parentId.next().children().append($node);
                }
                else {
                    $parentId.next().children().eq(index).before($node);
                }
            }
        },
        setValue: function ($self) {
            var dfop = $self[0]._apptree.dfop;
            if (dfop.data.length == 0) {
                setTimeout(function () {
                    $.apptree.setValue($self);
                }, 100);
            }
            else {
                $self.find('span[data-value="' + dfop._value + '"]').trigger('click');
            }
        }
    };

    $.fn.apptree = function (settings) {
        var dfop = {
            icons: ['checkbox_0.png', 'checkbox_1.png', 'checkbox_2.png'],
            method: "GET",
            url: false,
            param: null,
            /* [{
            id,
            text,
            value,
            showcheck,bool
            checkstate,int
            hasChildren,bool
            isexpand,bool
            complete,bool
            ChildNodes,[]
            }]*/
            data: [],
            isAllExpand: false,
            cbiconpath: '../../../../assets/images/tree/',
            // 点击事件（节点信息）,节点$对象
            nodeClick: false,
            // 选中事件（节点信息）,节点$对象
            nodeCheck: false
            
        };
        $.extend(dfop, settings);
        var $self = $(this);
        dfop.id = $self.attr("id");
        if (dfop.id == null || dfop.id == "") {
            dfop.id = "apptree" + new Date().getTime();
            $self.attr("id", dfop.id);
        }
        $self.html('');
        $self.addClass("app-tree");       
        $self[0]._apptree = { dfop: dfop };
        $self[0]._apptree.dfop.backupData = dfop.data;
        if (dfop.url) {
            app.HTTP_REQUEST_UTILS.httpAsync(dfop.method, dfop.url, dfop.param, function (data) {
                $self[0]._apptree.dfop.data = data || [];
                $self[0]._apptree.dfop.backupData = $self[0]._apptree.dfop.data;
                $.apptree.render($self);
            });
        }
        else {
            $.apptree.render($self);
        }
        // pre load the icons
        if (dfop.showcheck) {
            for (var i = 0; i < 3; i++) {
                var im = new Image();
                im.src = dfop.cbiconpath + dfop.icons[i];
            }
        }
        dfop = null;
        return $self;
    };

    $.fn.apptreeSet = function (name,op) {
        var $self = $(this);
        var dfop = $self[0]._apptree.dfop;
        var getCheck = function (items, buff, fn) {
            for (var i = 0, l = items.length; i < l; i++) {
                if ($self.find('#' + dfop.id + '_' + items[i].id.replace(/-/g, '_')).parent().css('display') != 'none') {
                    (items[i].showcheck == true && (items[i].checkstate == 1 || items[i].checkstate == 2)) && buff.push(fn(items[i]));
                    if (!items[i].showcheck || (items[i].showcheck == true && (items[i].checkstate == 1 || items[i].checkstate == 2))) {
                        if (items[i].ChildNodes != null && items[i].ChildNodes.length > 0) {
                            getCheck(items[i].ChildNodes, buff, fn);
                        }
                    }
                }
            }
        };
        var getCheck2 = function (items, buff, fn) {
            for (var i = 0, l = items.length; i < l; i++) {
                (items[i].showcheck == true && (items[i].checkstate == 1 || items[i].checkstate == 2) && !items[i].hasChildren) && buff.push(fn(items[i]));
                if (!items[i].showcheck || (items[i].showcheck == true && (items[i].checkstate == 1 || items[i].checkstate == 2))) {
                    if (items[i].ChildNodes != null && items[i].ChildNodes.length > 0) {
                        getCheck2(items[i].ChildNodes, buff, fn);
                    }
                }
            }
        };

        var setNoCheck = function (items, buff, fn) {
            for (var i = 0, l = items.length; i < l; i++) {
                if (items[i].showcheck) {
                    items[i].checkstate = 0;
                }
                if (items[i].ChildNodes != null && items[i].ChildNodes.length > 0) {
                    setNoCheck(items[i].ChildNodes);
                }
            }
        };


        switch (name) {
            case 'allNoCheck':
                $self.find('.app-tree-node-cb').attr('src', dfop.cbiconpath + 'checkbox_0.png');
                setNoCheck(dfop.data);
                break;
            case 'allCheck':
                $self.find('.app-tree-node-cb[src$="checkbox_0.png"]').trigger('click');
                break;
            case 'setCheck':
                var list = op;
                $.each(list, function (id, item) {
                    var $div = $self.find('#' + dfop.id + '_' + item.replace(/-/g, '_'));
                    if ($div.next().length == 0) {
                        $div.find('.app-tree-node-cb').trigger('click');
                    }
                });
                break;
            case 'setValue':
                dfop._value = op;
                $.apptree.setValue($self);
                break;
            case 'currentItem':
                return dfop.currentItem;
                break;
            case 'getCheckNodesEx':// 只获取最下面的选中元素
                var buff = [];
                getCheck2(dfop.data, buff, function (item) { return item; });
                return buff;
                break;
            case 'getCheckNodes':
                var buff = [];
                getCheck(dfop.data, buff, function (item) {return item; });
                return buff;
                break;
            case 'getCheckNodeIds':
                var buff = [];
                getCheck(dfop.data, buff, function (item) {return item.id; });
                return buff;
                break;
            case 'getCheckNodeIdsByPath':
                var buff = [];
                var pathlist
                getCheck(dfop.data, buff, function (item) { return item.id; });
                return buff;
                break;
            case 'search':
                $.apptree.search(op.keyword, dfop.data);
                if (app.validator.isNotNull(op.keyword).code) {
                    dfop._isSearch = true;
                }
                else if (dfop._isSearch) {
                    dfop._isSearch = false;
                }
                $.apptree.renderToo($self);
                break;
            case 'refresh':
                $.extend(dfop, op || {});
                if (!!dfop.url) {
                    app.HTTP_REQUEST_UTILS.httpAsync(dfop.method, dfop.url, dfop.param, function (data) {
                        $self[0]._apptree.dfop.data = data || [];
                        $self[0]._apptree.dfop.backupData = $self[0]._apptree.dfop.data;
                        $.apptree.renderToo($self);
                        dfop._isSearch = false;
                    });
                }
                else {
                    $self[0]._apptree.dfop.backupData = $self[0]._apptree.dfop.data;
                    $.apptree.renderToo($self);
                    dfop._isSearch = false;
                }
                break;
            case 'addNode':
                
                break;
            case 'updateNode':

                break;
        }
    }

})(jQuery, top.app);