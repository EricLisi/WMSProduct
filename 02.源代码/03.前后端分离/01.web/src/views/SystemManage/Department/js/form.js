var router = "Company";
var acceptClick;
(function($, app) {
	"use strict";
	var companyId = app.URL_REQUEST_UTILS.get(window.location, 'CompanyId');
	var keyValue = app.URL_REQUEST_UTILS.get(window.location, 'keyValue');	
	// 页面事件对象     
	var pageEvent = {
		// 窗体初始化          
		init: function() {
			pageEvent.bindEvent();
			pageEvent.initForm()
		},
		//绑定事件和初始化控件
		bindEvent: function() {
			// 部门性质
			 $('#nature').appselect();
//			$('#Nature').appDataItemSelect({
//				code: 'DepartmentNature',
//				maxHeight: 230
//			});
			$('#parentid').appselect({
				url: '/api/Company/GetTreeJson',
				type: 'tree',
				maxHeight: 100,
				allowSearch: true
			});
			// 上级部门
			$('#companyid').appselect({
				url: '/api/Company/GetTreeJson',
				type: 'tree',
				maxHeight: 100,
				allowSearch: true 
			});
			$("#companyid").val(companyId);
//			$("#add").on('click',function(){
//				var data=$('#step-2').appGetFormData(keyValue)
//				console.log(data)
//				var param = {
//					"fullname": data.fullnamedep,
//					"encode": data.encodedep,
//					"shortname": data.shortnamedep,
//					"nature": data.naturedep,
//					"manager":data.managerdep,
//					"phone":data.phonedep,
//					"email":data.emaildep,
//					"fax": data.faxdep,
//					"description": data.descriptiondep
//				};
//			$("#dept_girdtable").appGridSet('addRow',param);
//			})
				$('#wizard').wizard().on('change', function(e, data) {
				var $finish = $("#btn_finish");
				var $next = $("#btn_next");
				if(data.direction == "next") {
					if(data.step == 1) {
				        $finish.removeAttr('disabled');
						if(!$('#step-1').appValidform()) {				
							return false;
						}
					}  else {
						$finish.removeAttr('disabled');
						$next.attr('disabled', 'disabled');
					}
				} else {
					$finish.attr('disabled', 'disabled');
					$next.removeAttr('disabled');
				}
			});
			// 保存数据按钮
			$("#btn_finish").on('click', pageEvent.save);
			
			$('#dept_girdtable').appgrid({
				headData: [{
						label: "部门名称",
						name: "fullname",
						width: 200,
						align: "center",
						edit: {
							type: 'input',
						}
					},
					{
						label: "部门编号",
						name: "encode",
						width: 100,
						align: "center",
						edit: {
							type: 'input',
						}
					},
					{
						label: "部门简称",
						name: "shortname",
						width: 100,
						align: "center",
						edit: {
							type: 'input',
						}
					},
					{
						label: "部门性质",
						name: "nature",
						width: 100,
						align: "center",	
						edit: {
							type: 'select',
							op: { // 下拉框设置参数 和 appselect一致
//								//url:'/api/Position/GetSelectGrid',
//								text: 'text',
//								value: 'id',
//								allowSearch: true
								data: [{
										'id': '0',
										'text': '综合性'
									},
									{
										'id': '1',
										'text': '协调性'
									},
									{
										'id': '2',
										'text': '咨询性'
									},
									{
										'id': '3',
										'text': '生产性'
									},
									{
										'id': '4',
										'text': '其他性'
									}
								]
							}
						},
						formatter: function(cellvalue) {
							if(cellvalue==0){								
								return "综合性"
							}
						    else if(cellvalue==1){
								return "协调性"
							}
						    else if(cellvalue==2){
								return "咨询性"
							}
						    else if(cellvalue==3){
								return "生产性"
							}
						    else if(cellvalue==4){
								return "其他性"
							}						  
						}
					},
					{
						label: "负责人",
						name: "manager",
						width: 100,
						align: "center",
						edit: {
							type: 'input',
						}
					},
					{
						label: "电话号",
						name: "phone",
						width: 100,
						align: "center",
						edit: {
							type: 'input',
						}
					},			
					{
						label: "邮箱",
						name: "email",
						width: 100,
						align: "center",
						edit: {
							type: 'input',
						}
					},
					{
						label: "传真",
						name: "fax",
						width: 100,
						align: "center",
						edit: {
							type: 'input',
						}
					},		
					{
						label: "备注",
						name: "description",
						width: 200,
						align: "center",
						edit: {
							type: 'input',
						}
					}
				],
				isEdit: true,
				height: 400,
				isMultiselect: true,
				onAddRow: function(row, rows) {
					row.id = app.BASE_UTILS.newGuid();
				}
			});
		},
		//初始化数据
		initForm: function() {
			if(!!keyValue) {
				$.appSetForm('/api/' + router + '/' + keyValue, function(data) {
					console.log(data)
					$('#step-1').appSetFormData(data);
					$('#dept_girdtable').appGridSet('refreshdata', data.departments);
				});
			}
		},
		/*保存数据*/
		save: function() {
			if(!$('#step-1').appValidform()) {
				return false;
			}
			var postData = $('#step-1').appGetFormData(keyValue); //得到提交数据源
			if(!!!keyValue) {
				postData.id = app.BASE_UTILS.newGuid()
			}
			var dept = $('#dept_girdtable').appGridGet('rowdatas');
			for(var i=0;i<dept.length;i++)
			{
			dept[i].companyid=postData.id;
			}
			postData.departments = dept;
						
			var postUrl = '/api/Company';
			var type = "POST";
			if(!!keyValue) {
				postUrl = postUrl + "/" + keyValue;
				type = "PUT"
			}
			//判断encode是否重复
		   var repeat=0;
		   for(var i=0;i<dept.length-1;i++)
		   {
		   	for(var j=i+1;j<dept.length;j++)
		   	{
             if(dept[j].encode==dept[i].encode)
             {
             	repeat=1;
             	alert('相同的encode编号，保存失败');
             }

		   	}

		   }
		   if(repeat==0){		   	
		   	layx.load('loadId', '数据正在保存中，请稍后');
			app.HTTP_REQUEST_UTILS.httpAsync(type, postUrl, postData, function(data) {
				layx.destroy('loadId');
				if(data.status) {
					app.MODAL_UTILS.error(data.message)
					window.parent.location.reload()
					window.parent.layx.destroy('Department');
					//$('#gridtable').appGridSet('reload',{});
				} else {

					app.MODAL_UTILS.success(data.message);
					window.parent.location.reload()
					window.parent.layx.destroy('Department');
				}
			});
		   }

		}
	}
	$(function() {
		pageEvent.init();
	})
})(window.jQuery, top.app)