var router = "User";
var acceptClick;
(function($, app) {
	// 保存数据	   
	acceptClick = function() {
		if(!$('#form1').appValidform()) {
			return false;
		}
		var newpwd=$.md5($("#UserPassword").val());
		var param = {
			//"Account":app.APP_GLOBE_STORE.LOGIN_USER.FullName,						
			"Id": localStorage.getItem('KGM_USERID'),
			"pwd": newpwd
		};
		app.HTTP_REQUEST_UTILS.httpAsyncPut(newpwd,'/api/User/UpdatePwd/'+localStorage.getItem('KGM_USERID'), param, function(data) {
			if(!data.status) {
				app.MODAL_UTILS.success(data.message);				
			} else {
				app.MODAL_UTILS.error(data.message)
			}
		});
	};

})(window.jQuery, top.app)