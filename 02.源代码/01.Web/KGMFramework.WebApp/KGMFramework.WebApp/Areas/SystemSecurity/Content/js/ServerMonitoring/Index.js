﻿$(function () {
    loadGaugeIIS();
    loadGaugeCPU();
    loadGaugeRAM();
    loadChart();
})
function loadGaugeIIS() {
    var myChart = echarts.init(document.getElementById('maina'));
    option = {
        series: [
            {
                name: '业务指标',
                type: 'gauge',
                splitNumber: 10,       // 分割段数，默认为5
                axisLine: {            // 坐标轴线
                    lineStyle: {       // 属性lineStyle控制线条样式
                        color: [[0.2, '#228b22'], [0.8, '#48b'], [1, '#ff4500']],
                        width: 10
                    }
                },
                axisTick: {            // 坐标轴小标记
                    splitNumber: 10,   // 每份split细分多少段
                    length: 12,        // 属性length控制线长
                    lineStyle: {       // 属性lineStyle控制线条样式
                        color: 'auto'
                    }
                },
                axisLabel: {           // 坐标轴文本标签，详见axis.axisLabel
                    textStyle: {       // 其余属性默认使用全局文本样式，详见TEXTSTYLE
                        color: 'auto'
                    }
                },
                splitLine: {           // 分隔线
                    show: true,        // 默认显示，属性show控制显示与否
                    length: 30,         // 属性length控制线长
                    lineStyle: {       // 属性lineStyle（详见lineStyle）控制线条样式
                        color: 'auto'
                    }
                },

                detail: {
                    formatter: '{value}%',
                    textStyle: {       // 其余属性默认使用全局文本样式，详见TEXTSTYLE
                        color: 'auto',
                        fontWeight: 'bolder',
                        fontSize: 20
                    }
                },
                data: [{ value: 50 }]
            }
        ]
    };
    myChart.setOption(option);
}
function loadGaugeCPU() {
    var myChartCUP = echarts.init(document.getElementById('mainb'), infographicTheme());
    optionCUP = {
        series: [
            {
                name: '业务指标',
                type: 'gauge',
                splitNumber: 10,       // 分割段数，默认为5
                axisLine: {            // 坐标轴线
                    lineStyle: {       // 属性lineStyle控制线条样式
                        color: [[0.2, '#228b22'], [0.8, '#48b'], [1, '#ff4500']],
                        width: 10
                    }
                },
                axisTick: {            // 坐标轴小标记
                    splitNumber: 10,   // 每份split细分多少段
                    length: 12,        // 属性length控制线长
                    lineStyle: {       // 属性lineStyle控制线条样式
                        color: 'auto'
                    }
                },
                axisLabel: {           // 坐标轴文本标签，详见axis.axisLabel
                    textStyle: {       // 其余属性默认使用全局文本样式，详见TEXTSTYLE
                        color: 'auto'
                    }
                },
                splitLine: {           // 分隔线
                    show: true,        // 默认显示，属性show控制显示与否
                    length: 30,         // 属性length控制线长
                    lineStyle: {       // 属性lineStyle（详见lineStyle）控制线条样式
                        color: 'auto'
                    }
                },

                detail: {
                    formatter: '{value}%',
                    textStyle: {       // 其余属性默认使用全局文本样式，详见TEXTSTYLE
                        color: 'auto',
                        fontWeight: 'bolder',
                        fontSize: 20
                    }
                },
                data: [{ value: 50 }]
            }
        ]
    };
    myChartCUP.setOption(optionCUP);
    clearInterval(timeTicket);
    var timeTicket = setInterval(function () {
        optionCUP.series[0].data[0].value = (Math.random() * 100).toFixed(2) - 0;
        myChartCUP.setOption(optionCUP, true);
    }, 2000)
}
function loadGaugeRAM() {
    var myChart = echarts.init(document.getElementById('mainc'));
    option = {
        series: [
            {
                name: '业务指标',
                type: 'gauge',
                splitNumber: 10,       // 分割段数，默认为5
                axisLine: {            // 坐标轴线
                    lineStyle: {       // 属性lineStyle控制线条样式
                        color: [[0.2, '#228b22'], [0.8, '#48b'], [1, '#ff4500']],
                        width: 10
                    }
                },
                axisTick: {            // 坐标轴小标记
                    splitNumber: 10,   // 每份split细分多少段
                    length: 12,        // 属性length控制线长
                    lineStyle: {       // 属性lineStyle控制线条样式
                        color: 'auto'
                    }
                },
                axisLabel: {           // 坐标轴文本标签，详见axis.axisLabel
                    textStyle: {       // 其余属性默认使用全局文本样式，详见TEXTSTYLE
                        color: 'auto'
                    }
                },
                splitLine: {           // 分隔线
                    show: true,        // 默认显示，属性show控制显示与否
                    length: 30,         // 属性length控制线长
                    lineStyle: {       // 属性lineStyle（详见lineStyle）控制线条样式
                        color: 'auto'
                    }
                },

                detail: {
                    formatter: '{value}%',
                    textStyle: {       // 其余属性默认使用全局文本样式，详见TEXTSTYLE
                        color: 'auto',
                        fontWeight: 'bolder',
                        fontSize: 20
                    }
                },
                data: [{ value: 50 }]
            }
        ]
    };
    myChart.setOption(option);
}
function loadChart() {
    var myChart = echarts.init(document.getElementById('maind'));
    option = {
        tooltip: {
            trigger: 'axis'
        },
        legend: {
            data: ['IIS使用率', 'CPU使用率', 'ARM使用率']
        },

        xAxis: {
            type: 'category',
            boundaryGap: false,
            data: ['周一', '周二', '周三', '周四', '周五', '周六', '周日']
        },
        yAxis: {
            type: 'value'
        },
        series: [
            {
                name: 'IIS使用率', type: 'line',
                data: [1720, 8132, 2101, 3134, 490, 5230, 6210]
            },
            {
                name: 'CPU使用率', type: 'line',
                data: [2620, 4182, 5191, 4234, 2290, 1330, 9310]
            },
            {
                name: 'ARM使用率', type: 'line',
                data: [2320, 1822, 7791, 23344, 22790, 5530, 5110]
            }
        ]
    };

    myChart.setOption(option);
}