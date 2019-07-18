
(function ($, app) {
	//top._learunSelectIcon="";
    "use strict";  
    /**
     * 页面事件对象
     */
    var pageEvent = {
        /**
         *  窗体初始化 
         **/
        init: function () {        	
            pageEvent.bindEvents()          
        },              
        /**
         * 绑定事件
         */
        bindEvents: function () {
        	var controlId = app.URL_REQUEST_UTILS.get(window.location,'ControlId');
        	//双击图标选中        	
             $('#icons').on('dblclick', function (e) {             
                var et = e.target || e.srcElement;
                if ($(et).children().hasClass('fa')) {                
                    var icon = $(et).find('i').attr('class');
                    alert(icon)               
                    top.Form.$('#' + controlId).val(icon);
                    //top._learunSelectIcon = icon;
                   // top.app.layerClose(window.name);
                }
            });
            $('#icons').appscroll();        
        },                       
    }

    $(function () {
        pageEvent.init();
    })
})(window.jQuery, top.app)
