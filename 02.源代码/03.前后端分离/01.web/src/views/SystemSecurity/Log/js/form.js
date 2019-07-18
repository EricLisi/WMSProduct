var router="SystemSecurity/Log";
var acceptClick;

(function ($, app) {
    "use strict";  
    
    var categoryId = app.URL_REQUEST_UTILS.get('categoryId');    
    /**
     * 页面事件对象
     */
    var pageEvent = {
        /**
         *  窗体初始化 
         **/
	        init: function () {         	     	
	        	  
	            $('#keepTime').appselect({maxHeight:75,placeholder:false}).appselectSet(7);
	                             
	        },
         
        
        },
        
    // 保存数据	    
	acceptClick = function (callBack) {
	        if (!$('#form').appValidform()) {
	            return false;
	        }
	        var postData = $('#form').appGetFormData(keyValue);
	        if (postData["F_ParentId"] == '' || postData["F_ParentId"] == '&nbsp;') {
	            postData["F_ParentId"] = '0';
	        }
	        else if (postData["F_ParentId"] == keyValue) {
	        	app.MODAL_UTILS.warning('上级不能是自己本身');
	            return false;
	        }
	        $.appSaveForm(top.$.rootUrl + '/LR_SystemModule/DataItem/SaveClassifyForm?keyValue=' + keyValue, postData, function (res) {
	            // 保存成功后才回调
	            if (!!callBack) {
	                callBack();
	            }
	        });
	       /*request.put({
				url: router+"/SaveForm?keyValue="+ keyValue,
				data: postData,
				success: function(data) {						
				    // 保存成功后才回调
		                    
				}
			});*/
    };


    $(function () {
        pageEvent.init();
    })
})(window.jQuery, top.app)
