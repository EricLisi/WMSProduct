var router = "Consignee";
var acceptClick;
(function($, app) {
	"use strict";
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');
	/**
	 * 页面事件对象
	 */
	var pageEvent = {
		/**
		 *  窗体初始化 
		 **/
		init: function() {
			pageEvent.bindEvent();
			pageEvent.initForm()
		},
		//绑定事件和初始化控件
		bindEvent: function() {			
			$('#UserId').val(app.APP_GLOBE_STORE.LOGIN_USER.Id);			
			//市
          // $("#CityCode").appselect();
			//客户省份
            $("#ProvinceCode").appselect({
                data:app.APP_GLOBE_STORE.DATA_STATUS['PROVINCE'],
                text: 'FullName',
				value: 'Id',
            }).on("change", function (e) {
                var prov = $("#ProvinceCode").appselectGet('value'); 
                alert(prov)
               
                //选择省后，市联动赋值
//               $("#CityCode").appselect({
//                          url: '/api/Area/GetTreeJson/'+ app.APP_GLOBE_STORE.LOGIN_USER.Id+'?ParentId='+prov,
//                          text: 'FullName',
//				            value: 'Id'
//              });	
                
                app.HTTP_REQUEST_UTILS.httpAsyncGet('/api/Area/GetTreeJson/'+ app.APP_GLOBE_STORE.LOGIN_USER.Id+'?ParentId='+prov,function(datas) {										                      
                        alert(JSON.stringify(datas))                        
                        $("#CityCode").appselect({
                            data: datas,
                            text: 'FullName',
				            value: 'Id'
                        });	
                       
			    })			
            });
           
		},
		/*初始化数据*/
		initForm: function() {
			if(!!keyValue) {
				$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
					$('#form1').appSetFormData(data);
				});
			}
		},
	};
	// 保存数据
	acceptClick = function() {		
		if(!$('#form1').appValidform()) {
			return false;
		}
		var postData = $('#form1').appGetFormData(keyValue);
		var postUrl = '/api/' + router;
		var type = "POST";
		if(!!keyValue) {
			postUrl = postUrl + "/" + keyValue;
			type = "PUT"
		}
		$.appSaveForm(type, postUrl, postData, function(data) {

		});
	};

	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)