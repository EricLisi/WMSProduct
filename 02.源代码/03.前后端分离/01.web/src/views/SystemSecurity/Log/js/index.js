/*
 * 模块管理主页面
 */
var router="SystemSecurity/Log";
(function ($, app) {
    "use strict";
     var categoryId = '1';
    var logbegin = '';
    var logend = '';

    var refreshGirdData = function () {
        pageEvent.search();
    }
    /**
     * 页面事件
     */
    var pageEvent = {
        /**
         * 初始化事件
         * 
         */
        init: function () { 
            $('#app_layout').appLayout();
            pageEvent.initConfig();
            pageEvent.initleft();
            pageEvent.initgrid();
            pageEvent.bindEvent()                      
        },
        /**
         * 初始化配置
         */
        initConfig:function(){
            //错误页面路径重设
            app.APP_CONFIGRATION.ROUTER_CONFIG.ERROR_PAGE_URL = "../../../Error/index.html";
        },
        /**
         * 绑定事件
         */
        bindEvent: function () {
             $('.datetime').each(function () {
                $(this).appdate({
                    dfdata: [
                        { name: '今天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00') }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                        { name: '近7天', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'd', -6) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                        { name: '近1个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -1) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                        { name: '近3个月', begin: function () { return learun.getDate('yyyy-MM-dd 00:00:00', 'm', -3) }, end: function () { return learun.getDate('yyyy-MM-dd 23:59:59') } },
                    ],
                    // 月
                    mShow: false,
                    premShow: false,
                    // 季度
                    jShow: false,
                    prejShow: false,
                    // 年
                    ysShow: false,
                    yxShow: false,
                    preyShow: false,
                    yShow: false,
                    // 默认
                    dfvalue: '1',
                    selectfn: function (begin, end) {
                        logbegin = begin;
                        logend = end;
                        pageEvent.search();
                    }
                });
            });
            // 查询
            $('#btn_Search').on('click', function () {
                var keyword = $('#txt_Keyword').val();
                page.search({ keyword: keyword });
            });
            // 刷新
            $('#app_refresh').on('click', function () {
                location.reload();
            });
            // 清空
            $('#app_removelog').on('click', function () {            	
            	layx.iframe('form','清空','../html/form.html?companyId=' + companyId,{
				    statusBar:true,				                          
				    buttons:[
				        {
				            label:'保存',
				            callback:function(id, button, event){
				                // 获取 iframe 页面 window对象
				                var contentWindow=layx.getFrameContext(id);				               
				                return contentWindow.acceptClick(refreshGirdData);				               
				                layx.destroy(id);    
				            },
				            style:'border-color: #4898d5;background-color: #2e8ded;color: #fff;'
				        },
				        {
				            label:'取消',
				            callback:function(id, button, event){
				                layx.destroy(id);
				            }
				        }
				    ]
				}); 
                /*learun.layerForm({
                    id: 'form',
                    title: '清空',
                    url: top.$.rootUrl + '/LR_SystemModule/Log/Form?categoryId=' + categoryId,
                    height: 200,
                    width: 400,
                    callBack: function (id) {
                        return top[id].acceptClick(refreshGirdData);
                    }
                });*/
            });
            // 导出
            $('#app_export').on('click', function () {            	
            	layx.iframe('ExcelExportForm','导出Excel数据','../Utility/ExcelExportForm?gridId'+gridtable+'&filename'+log,{
				    statusBar:true,				                          
				    buttons:[
				        {
				            label:'保存',
				            callback:function(id, button, event){
				                // 获取 iframe 页面 window对象
				                var contentWindow=layx.getFrameContext(id);				               
				                return contentWindow.acceptClick();				                  
				                layx.destroy(id);    
				            },
				            style:'border-color: #4898d5;background-color: #2e8ded;color: #fff;'
				        },
				        {
				            label:'取消',
				            callback:function(id, button, event){
				                layx.destroy(id);
				            }
				        }
				    ]
				}); 
                /*learun.layerForm({
                    id: "ExcelExportForm",
                    title: '导出Excel数据',
                    url: top.$.rootUrl + '/Utility/ExcelExportForm?gridId=gridtable&filename=log',
                    width: 500,
                    height: 380,
                    callBack: function (id) {
                        return top[id].acceptClick();
                    },
                    btn: ['导出Excel', '关闭']
                });*/
            });
                                  
        },
       
         initleft: function () {
            $('#app_left_list li').on('click', function () {
                var $this = $(this);
                var $parent = $this.parent();
                $parent.find('.active').removeClass('active');
                $this.addClass('active');

                categoryId = $this.attr('data-value');
                pageEvent.search();
            });
        },
        
         /**
         * 初始化表格
         */
         initgrid: function () {
         $("#gridtable").appgrid({        	   	 	
	            url: '',                // 数据服务地址
	            param: {},                    // 请求参数
	            rowdatas: [
	            {
				"F_Id": "6903ab9d-20cd-44c4-a380-09f229366e1f",
				"F_Account": "admin",
				"F_RealName": "系统管理员",
				"F_NickName": null,
				"F_HeadIcon": null,
				"F_Gender": false,
				"F_Birthday": null,
				"F_MobilePhone": "&nbsp;",
				"F_Email": "&nbsp;",
				"F_WeChat": "&nbsp;",
				"F_ManagerId": null,
				"F_SecurityLevel": 0,
				"F_Signature": null,
				"F_OrganizeId": "0001U910000000002QHK",
				"F_DepartmentId": "5B417E2B-4B96-4F37-8BAA-10E5A812D05E",
				"F_RoleId": "531F7D18-C49F-4F4F-A920-0074FCB52078",
				"F_DutyId": "7ad1b8b1-dd91-4908-aedc-d5e7114f127a",
				"F_IsAdministrator": true,
				"F_SortCode": 0,
				"F_DeleteMark": false,
				"F_EnabledMark": true,
				"F_Description": "&nbsp;",
				"F_CreatorTime": null,
				"F_CreatorUserId": null,
				"F_LastModifyTime": "2017-11-22 16:27:24",
				"F_LastModifyUserId": "kgmAdmin",
				"F_DeleteTime": null,
				"F_DeleteUserId": null,
				"F_UserPassword": "E2BB0ED30A7778E5",
				"F_Id1": "0001U910000000002QHK",
				"F_ParentId": "0001U910000000002QFO",
				"F_Layers": 0,
				"F_EnCode": "fk001",
				"F_FullName": "上海飞凯",
				"F_ShortName": null,
				"F_CategoryId": "Company",
				"F_ManagerId1": null,
				"F_TelePhone": null,
				"F_MobilePhone1": null,
				"F_WeChat1": null,
				"F_Fax": null,
				"F_Email1": null,
				"F_AreaId": null,
				"F_Address": null,
				"F_AllowEdit": false,
				"F_AllowDelete": false,
				"F_SortCode1": 0,
				"F_DeleteMark1": false,
				"F_EnabledMark1": false,
				"F_Description1": null,
				"F_CreatorTime1": null,
				"F_CreatorUserId1": null,
				"F_LastModifyTime1": null,
				"F_LastModifyUserId1": null,
				"F_DeleteTime1": null,
				"F_DeleteUserId1": null,
				"F_Id2": "7ad1b8b1-dd91-4908-aedc-d5e7114f127a",
				"F_EnCode1": "bb111",
				"F_FullName1": "aaa",
				"F_OrganizeId1": "0001U91000000004W81A",
				"F_AllowEdit1": false,
				"F_AllowDelete1": false,
				"F_SortCode2": 1,
				"F_DeleteMark2": false,
				"F_EnabledMark2": true,
				"F_Description2": "1111111",
				"F_CreatorTime2": "2018-08-28 14:14:15",
				"F_CreatorUserId2": "6903ab9d-20cd-44c4-a380-09f229366e1f",
				"F_LastModifyTime2": null,
				"F_LastModifyUserId2": null,
				"F_DeleteTime2": null,
				"F_DeleteUserId2": null,
				"F_FullName2": "上海飞凯",
				"F_FullName3": "aaa"
			}, {
				"F_Id": "abe9fcf1-1879-41b1-948d-05d514102934",
				"F_Account": "1",
				"F_RealName": "test",
				"F_NickName": null,
				"F_HeadIcon": null,
				"F_Gender": true,
				"F_Birthday": null,
				"F_MobilePhone": "&nbsp;",
				"F_Email": "&nbsp;",
				"F_WeChat": "&nbsp;",
				"F_ManagerId": null,
				"F_SecurityLevel": 0,
				"F_Signature": null,
				"F_OrganizeId": "0001U910000000000HTC",
				"F_DepartmentId": "0001U91000000004W836",
				"F_RoleId": "e2bfcd48-d551-4735-bb13-ba86ca72b511",
				"F_DutyId": "ce08ddee-431a-4e29-9ebb-63d8d45fde85",
				"F_IsAdministrator": false,
				"F_SortCode": 0,
				"F_DeleteMark": false,
				"F_EnabledMark": true,
				"F_Description": "&nbsp;",
				"F_CreatorTime": "2018-09-20 10:07:08",
				"F_CreatorUserId": "6903ab9d-20cd-44c4-a380-09f229366e1f",
				"F_LastModifyTime": null,
				"F_LastModifyUserId": null,
				"F_DeleteTime": null,
				"F_DeleteUserId": null,
				"F_UserPassword": "E2BB0ED30A7778E5",
				"F_Id1": null,
				"F_ParentId": null,
				"F_Layers": null,
				"F_EnCode": null,
				"F_FullName": null,
				"F_ShortName": null,
				"F_CategoryId": null,
				"F_ManagerId1": null,
				"F_TelePhone": null,
				"F_MobilePhone1": null,
				"F_WeChat1": null,
				"F_Fax": null,
				"F_Email1": null,
				"F_AreaId": null,
				"F_Address": null,
				"F_AllowEdit": null,
				"F_AllowDelete": null,
				"F_SortCode1": null,
				"F_DeleteMark1": null,
				"F_EnabledMark1": null,
				"F_Description1": null,
				"F_CreatorTime1": null,
				"F_CreatorUserId1": null,
				"F_LastModifyTime1": null,
				"F_LastModifyUserId1": null,
				"F_DeleteTime1": null,
				"F_DeleteUserId1": null,
				"F_Id2": "ce08ddee-431a-4e29-9ebb-63d8d45fde85",
				"F_EnCode1": "11",
				"F_FullName1": "1111",
				"F_OrganizeId1": "5b3ff62c-c0f3-4c7b-8b32-5e128ca22930",
				"F_AllowEdit1": false,
				"F_AllowDelete1": false,
				"F_SortCode2": 2,
				"F_DeleteMark2": false,
				"F_EnabledMark2": true,
				"F_Description2": "111",
				"F_CreatorTime2": "2018-08-28 14:16:35",
				"F_CreatorUserId2": "6903ab9d-20cd-44c4-a380-09f229366e1f",
				"F_LastModifyTime2": null,
				"F_LastModifyUserId2": null,
				"F_DeleteTime2": null,
				"F_DeleteUserId2": null,
				"F_FullName2": null,
				"F_FullName3": "1111"
            }],                 // 列表数据
	        headData: [{ label: 'F_Id', name: 'F_Id', width: 200, align: 'left' },
	                {
                        label: "操作时间", name: "F_OperateTime",width: 135, align: "left"
                        /*formatter: function (cellvalue) {
                            return learun.formatDate(cellvalue, 'yyyy-MM-dd hh:mm:ss');
                        }*/
                     },
                    { label: "操作用户", name: "F_OperateAccount",width: 140, align: "left" },
                    { label: "IP地址", name: "F_IPAddress", width: 100, align: "left" },
                    { label: "系统功能", name: "F_Module", width: 150, align: "left" },
                    { label: "操作类型", name: "F_OperateType", width: 70, align: "center" },
                    {
                        label: "执行结果", name: "F_ExecuteResult", width: 70, align: "center",
                        formatter: function (cellvalue) {
                            if (cellvalue == '1') {
                                return "<span class=\"label label-success\">成功</span>";
                            } else {
                                return "<span class=\"label label-danger\">失败</span>";
                            }
                        }
                    },
                    { label: "执行结果描述", name: "F_ExecuteResultJson", width: 300, align: "left" }
		],                                    // 列数据	
	            mainId: 'F_Id',
                isPage: true,
                sidx: 'F_OperateTime'
        });
       
       },
         search: function (param) {
            param = param || {};
            param.CategoryId = categoryId;
            param.StartTime = logbegin;
            param.EndTime = logend;

            $('#gridtable').appGridSet('reload', { queryJson: JSON.stringify(param) });
        }
    } 
    


    $(function () {
        pageEvent.init();
    });

})(window.jQuery, top.app);