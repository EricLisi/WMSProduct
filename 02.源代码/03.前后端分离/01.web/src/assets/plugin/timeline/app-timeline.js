﻿/*
 * 版 本 Learun-ADMS V7.0.0 力软敏捷开发框架(http://www.learun.cn)
 * Copyright (c) 2013-2018 上海力 软信息技术有限公司
 * 创建人：力 软-前端开发组
 * 日 期：2017.03.22
 * 描 述：时间轴方法（降序）
 */
$.fn.apptimeline = function (nodelist) {

    // title   标题
    // people  审核人
    // content 内容
    // time    时间

    var $self = $(this);
    if ($self.length == 0) {
        return $self;
    }
    $self.addClass('app-timeline');
    var $wrap = $('<div class="app-timeline-allwrap"></div>');
    var $ul = $('<ul></ul>');

    // 开始节点
    var $begin = $('<li class="app-timeline-header"><div>当前</div></li>')
    $ul.append($begin);

    $.each(nodelist, function (_index, _item) {
        // 中间节点
        var $li = $('<li class="app-timeline-item" ><div class="app-timeline-wrap" ></div></li>');
        if (_index == 0) {
            $li.find('div').addClass('app-timeline-current');
        }
        var $itemwrap = $li.find('.app-timeline-wrap');
        var $itemcontent = $('<div class="app-timeline-content"><span class="arrow"></span></div>');
        $itemcontent.append('<div class="app-timeline-title">' + _item.title + '</div>');
        $itemcontent.append('<div class="app-timeline-body"><span>' + _item.people + '</span>' + _item.content + '</div>')
        $itemwrap.append('<span class="app-timeline-date">' + _item.time + '</span>');
        $itemwrap.append($itemcontent);
        $ul.append($li);
    });

    // 结束节点
    $ul.append('<li class="app-timeline-ender"><div>开始</div></li>');
    
    $wrap.html($ul);
    $self.html($wrap);

};