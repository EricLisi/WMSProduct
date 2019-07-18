/*
 * 滚动条
 */
(function ($, app) {
    "use strict";

    /**
     * 页面事件
     */
    var pageEvent = {
        /**
         * 初始化事件
         */
        init: function () { 
            pageEvent.getWeekChart();
        }, 
        /**
         * 获取一周流量表
         */
        getWeekChart: function () {
            //获取当前日期
            var dateArea = app.BASE_UTILS.Date.get_yyyy_MM_dd_Area(-7);
            var data = [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 125.2]
            $('#weekChart').highcharts({
                chart: {
                    type: 'spline'
                },
                title: {
                    text: '',
                    x: -20 //center
                },
                xAxis: {
                    categories: dateArea
                },
                yAxis: {
                    title: {
                        text: ''
                    }
                },
                tooltip: {
                    crosshairs: true,
                    shared: true
                },
                plotOptions: {
                    spline: {
                        marker: {
                            radius: 4,
                            lineColor: '#666666',
                            lineWidth: 1
                        }
                    }
                },
                series: [{
                    name: '登录数',
                    marker: {
                        symbol: 'square'
                    },
                    data: data

                }]
            });
        }
    } 


    $(function () {
        pageEvent.init();

    });

})(window.jQuery, top.app);