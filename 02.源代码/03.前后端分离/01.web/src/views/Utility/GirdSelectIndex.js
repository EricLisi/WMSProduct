var acceptClick;
(function ($, app) {
    "use strict";         
    var dfopid = app.URL_REQUEST_UTILS.get('dfopid');
    var selectItem;
    function loadData(_dfop) {
        if (_dfop._loaded) {
            $('#gridtable').appGridSet('refreshdata', _dfop._data);
        }
        else {
            setTimeout(function () {
                loadData(_dfop);
            }, 100);
        }
    }
    /**
     * 页面事件对象
     */
    var pageEvent = {
        /**
         *  窗体初始化 
         **/
        init: function () {         	 
        	pageEvent.bindEvent();
        	pageEvent.initgrid()
        },
        /**
         * 绑定事件
         */
        bindEvent: function () {                        
	        var dfop = top.appGirdSelect[dfopid];
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                if (dfop._loaded) {
                    if (!!keyword) {
                        var _data = [];
                        $.each(dfop._data, function (id, item) {
                            if (item[dfop.selectWord].indexOf(keyword) != -1) {
                                _data.push(item);
                            }
                        });
                        $('#gridtable').appGridSet('refreshdata', _data);
                    }
                    else {
                        $('#gridtable').appGridSet('refreshdata', dfop._data);
                    }
                }
            });         
        },
         /**
         * 初始化表格
         */
        initgrid: function () {
	        $("#gridtable").appgrid({ 
	            headData: dfop.headData,
                mainId: 'F_Id',
                onSelectRow: function (row) {
                    selectItem = row;
                }
	        })
	         loadData(dfop);
	    }
    };
     // 保存数据
    acceptClick = function (callBack) {
        callBack(selectItem, dfopid);
        return true;
    };

    $(function () {
        pageEvent.init();
    })
})(window.jQuery, top.app)
