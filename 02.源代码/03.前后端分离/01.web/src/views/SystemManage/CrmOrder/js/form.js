(function ($, app) {
    "use strict";   
    var keyValue = app.URL_REQUEST_UTILS.get('keyValue'); 
    alert(keyValue )
    // 保存数据
    var acceptClick = function (type) {// 0保存并新增 1保存
        if (!$('.app-layout-wrap').appValidform()) {
            return false;
        }
        var formData = $('.app-layout-wrap').appGetFormData(keyValue);
        var productData = [];
        var productDataTmp = $('#productgird').appGridGet('rowdatas');

        for (var i = 0, l = productDataTmp.length; i < l; i++) {
            if (!!productDataTmp[i]['F_ProductName']) {
                productData.push(productDataTmp[i]);
            }
        }

        var postData = {
            crmOrderJson: JSON.stringify(formData),
            crmOrderProductJson: JSON.stringify(productData)
        };

        /*learun.layerConfirm('注：您确认要保存此操作吗？', function (res, index) {
            if (res) {
                $.lrSaveForm(top.$.rootUrl + '/LR_CRMModule/CrmOrder/SaveForm?keyValue=' + keyValue, postData, function (res) {
                    if (res.code == 200) {
                        if (type == 0) {
                            window.location.href = top.$.rootUrl + '/LR_CRMModule/CrmOrder/Form';
                        }
                        else {
                            learun.frameTab.close('order_add');
                        }
                    }
                });
                top.layer.close(index); //再执行关闭  
            }
        });*/
        app.MODAL_UTILS.confirm({
            msg: "您确认要保存此操作吗？",
		        callback: function () {		                   
                    request.put({
						url: "/LR_CRMModule/CrmOrder/SaveForm?keyValue=" + keyValue,
						data:postData,
						success: function(data) {
							if (type == 0) {
		                        window.location.href = 'SystemManage/CrmOrder/html/form.html';		
		                    }
		                    else {
		                        app.frameTab.close('order_add');
		                    }						   				
						}
				    });
		        }
        });
    };

   
     /**
     * 页面事件对象
     */  
    var pageEvent = {
        /**
         *  窗体初始化 
         **/
        init: function () {         	     
            pageEvent.bindEvent();         
            pageEvent.InitForm()                 
        },
       
        /**
         * 绑定事件
         */
        bindEvent: function () {
        	// 优化滚动条
            $('.app-layout-wrap').appscroll();
            // 客户选择
            $('#F_CustomerId').appselect({
                url:'LR_CRMModule/Customer/GetList',
                text: 'F_FullName',
                value: 'F_CustomerId',
                allowSearch: true,
                maxHeight:400
            });
            // 销售人员
            $('#F_SellerId').appselect({
                url:'LR_OrganizationModule/User/GetList?departmentId=2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1',
                text: 'F_RealName',
                value: 'F_UserId',
                allowSearch: true,
                maxHeight: 400
            });
            // 收款方式
            $('#F_PaymentMode').appDataItemSelect({ code: 'Client_PaymentMode' });

            // 合同附件
            $('#F_ContractFile').appUploader();    
             // 订单产品信息
            $('#productgird').appgrid({
                headData: [
                    {
                        label: "商品信息", name: "a1", width: 80, align: "center", frozen: true,
                        children: [
                            {
                                label: '商品名称', name: 'F_ProductName', width: 260, align: 'left',
                                edit: {
                                    type: 'layer',
                                    init: function (data, $edit, rownum) {// 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象

                                    },
                                    change: function (row, rownum, selectdata) {// 行数据和行号,弹层选择行的数据，如果是自定义实现弹窗方式则该方法无效

                                        row.F_ProductName = selectdata.F_ItemName;
                                        row.F_ProductCode = selectdata.F_ItemValue;
                                        row.F_Qty = '1';
                                        row.F_Price = '0';
                                        row.F_Amount = '0';
                                        row.F_TaxRate = '0';
                                        row.F_Taxprice = '0';
                                        row.F_Tax = '0';
                                        row.F_TaxAmount = '0';

                                        $('#productgird').appGridSet('updateRow', rownum);
                                    },
                                    op: { // 如果未设置op属性可以在init中自定义实现弹窗方式
                                        width: 600,
                                        height: 400,
                                        colData: [
                                            { label: "商品编号", name: "F_ItemValue", width: 100, align: "left" },
                                            { label: "商品名称", name: "F_ItemName", width: 450, align: "left" }
                                        ],
                                        //url:'LR_SystemModule/DataItem/GetDetailList',
                                         rowdatas:[{
	"F_ItemDetailId": "1b76ceae-c96e-4afd-a5d9-96834d82d96b",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "企业豪华版",
	"F_ItemValue": "lr-2014-h",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "qyhhb",
	"F_IsDefault": null,
	"F_SortCode": 1,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-05-11 16:05:43",
	"F_CreateUserId": "bba93cbe-af5e-4a96-863f-454e739f8dc4",
	"F_CreateUserName": "李阳华",
	"F_ModifyDate": "2016-05-11 16:07:04",
	"F_ModifyUserId": "bba93cbe-af5e-4a96-863f-454e739f8dc4",
	"F_ModifyUserName": "李阳华"
}, {
	"F_ItemDetailId": "0b1aa2ca-4e8b-483f-a294-155c0404d25f",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "敏捷开发框架-个人开发版",
	"F_ItemValue": "lr-adms-01",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "mjkfkj-grkfb",
	"F_IsDefault": null,
	"F_SortCode": 1,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-11 17:08:41",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": "2016-03-11 17:11:03",
	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_ModifyUserName": "佘赐雄"
}, {
	"F_ItemDetailId": "136c4d69-bb3f-4501-b6ea-4f7d26eb29bd",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "个人豪华版",
	"F_ItemValue": "lr-2014-gh",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "grhhb",
	"F_IsDefault": null,
	"F_SortCode": 1,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-05-11 16:04:50",
	"F_CreateUserId": "bba93cbe-af5e-4a96-863f-454e739f8dc4",
	"F_CreateUserName": "李阳华",
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_ItemDetailId": "e324338a-5b51-4121-b8ea-033fefbc4a2e",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "企业基础版",
	"F_ItemValue": "lr-2014-02",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "qyjcb",
	"F_IsDefault": null,
	"F_SortCode": 1,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-05-11 16:07:57",
	"F_CreateUserId": "bba93cbe-af5e-4a96-863f-454e739f8dc4",
	"F_CreateUserName": "李阳华",
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_ItemDetailId": "0b303a3a-50a8-4c24-8624-cb59725a213d",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "企业增强版",
	"F_ItemValue": "lr-2014-zq",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "qyzqb",
	"F_IsDefault": null,
	"F_SortCode": 1,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-05-11 16:08:40",
	"F_CreateUserId": "bba93cbe-af5e-4a96-863f-454e739f8dc4",
	"F_CreateUserName": "李阳华",
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_ItemDetailId": "e44c09e3-b748-4c89-9b79-90f8d4f1fa4c",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "敏捷开发框架-个人尊享版",
	"F_ItemValue": "lr-adms-02",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "mjkfkj-grzxb",
	"F_IsDefault": null,
	"F_SortCode": 2,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-11 17:09:04",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": "2016-03-11 17:11:08",
	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_ModifyUserName": "佘赐雄"
}, {
	"F_ItemDetailId": "c47c22db-0a2d-483c-a60d-e1555e5a4a38",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "敏捷开发框架-企业基础版",
	"F_ItemValue": "lr-adms-03",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "mjkfkj-qyjcb",
	"F_IsDefault": null,
	"F_SortCode": 3,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-11 17:09:21",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": "2016-03-11 17:11:13",
	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_ModifyUserName": "佘赐雄"
}, {
	"F_ItemDetailId": "3555c469-7863-45d8-9c4e-0050708aa2e7",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "敏捷开发框架-企业增强版",
	"F_ItemValue": "lr-adms-04",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "mjkfkj-qyzqb",
	"F_IsDefault": null,
	"F_SortCode": 4,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-11 17:09:35",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": "2016-03-11 17:11:17",
	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_ModifyUserName": "佘赐雄"
}, {
	"F_ItemDetailId": "474ae670-7963-42bc-b125-b3d665348279",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "敏捷开发框架-企业豪华版",
	"F_ItemValue": "lr-adms-05",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "mjkfkj-qyhhb",
	"F_IsDefault": null,
	"F_SortCode": 5,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-11 17:09:48",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": "2016-03-11 17:11:21",
	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_ModifyUserName": "佘赐雄"
}, {
	"F_ItemDetailId": "2c403a88-cf8f-4f19-9f71-72d8afdae66f",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "敏捷开发框架-企业旗舰版",
	"F_ItemValue": "lr-adms-06",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "mjkfkj-qyqjb",
	"F_IsDefault": null,
	"F_SortCode": 6,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-11 17:10:01",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": "2016-03-11 17:11:27",
	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_ModifyUserName": "佘赐雄"
}, {
	"F_ItemDetailId": "5acc1ce1-16bd-4a9b-9c51-e1923d598ca8",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "敏捷开发框架-企业尊贵版",
	"F_ItemValue": "lr-adms-07",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "mjkfkj-qyzgb",
	"F_IsDefault": null,
	"F_SortCode": 7,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-11 17:10:15",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": "2016-03-11 17:11:31",
	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_ModifyUserName": "佘赐雄"
}, {
	"F_ItemDetailId": "4b57a8cd-46e7-481d-a26b-e3adc4f53792",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "敏捷开发框架-企业定制版",
	"F_ItemValue": "lr-adms-08",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "mjkfkj-qydzb",
	"F_IsDefault": null,
	"F_SortCode": 8,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-11 17:10:29",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": "2016-03-11 17:11:34",
	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_ModifyUserName": "佘赐雄"
}, {
	"F_ItemDetailId": "6bc83cc0-0f77-4272-85ba-f88ea55489b8",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "软件维护费用",
	"F_ItemValue": "lr-10001",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "rjwhfy",
	"F_IsDefault": null,
	"F_SortCode": 9,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-11 17:57:31",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_ItemDetailId": "0d83b8b9-98f2-44fb-bf14-90dd871595d6",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "软件服务费用",
	"F_ItemValue": "lr-10002",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "rjfwfy",
	"F_IsDefault": null,
	"F_SortCode": 10,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-11 17:58:08",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": "2016-03-11 18:05:50",
	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_ModifyUserName": "佘赐雄"
}, {
	"F_ItemDetailId": "c10435df-be9c-4ca5-8750-4b35ded81512",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "软件外包费用",
	"F_ItemValue": "lr-10003",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "rjwbfy",
	"F_IsDefault": null,
	"F_SortCode": 11,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-18 14:29:23",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_ItemDetailId": "cc8094b0-3dee-4d36-be0c-709e281ec2bc",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "软件定制费用",
	"F_ItemValue": "lr-10004",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "rjdzfy",
	"F_IsDefault": null,
	"F_SortCode": 12,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-18 14:30:29",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_ItemDetailId": "c1be1537-451c-488a-993e-8b8a8c7173ad",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "Oracle正版数据库",
	"F_ItemValue": "lr-10005",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "oraclezbsjk",
	"F_IsDefault": null,
	"F_SortCode": 13,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-18 14:32:00",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": null,
	"F_ModifyUserId": null,
	"F_ModifyUserName": null
}, {
	"F_ItemDetailId": "c5927c48-afc6-4a79-89e8-77db2f90de4c",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "SqlServer正版数据库",
	"F_ItemValue": "lr-10006",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "sqlserverzbsjk",
	"F_IsDefault": null,
	"F_SortCode": 14,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-18 14:32:36",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": "2016-03-18 14:46:01",
	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_ModifyUserName": "佘赐雄"
}, {
	"F_ItemDetailId": "f44de28f-3d78-407d-b5e5-ee567331b201",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "服务器硬件",
	"F_ItemValue": "lr-10007",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "fwqyj",
	"F_IsDefault": null,
	"F_SortCode": 15,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-18 14:34:02",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": "2016-03-18 14:46:06",
	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_ModifyUserName": "佘赐雄"
}, {
	"F_ItemDetailId": "e54aa882-5e2f-4d90-8cae-f2cb1a0a3ba1",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "PDA无线扫描枪",
	"F_ItemValue": "lr-10008",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "pdawxsmq",
	"F_IsDefault": null,
	"F_SortCode": 16,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-18 14:34:46",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": "2016-03-18 14:46:12",
	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_ModifyUserName": "佘赐雄"
}, {
	"F_ItemDetailId": "ad982d09-f182-4720-b0de-8007814784d8",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "无线打印机",
	"F_ItemValue": "lr-10009",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "wxdyj",
	"F_IsDefault": null,
	"F_SortCode": 17,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-18 14:36:38",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": "2016-03-18 14:46:17",
	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_ModifyUserName": "佘赐雄"
}, {
	"F_ItemDetailId": "68676c13-8a2e-4322-affe-67e1ac5c4f7c",
	"F_ItemId": "7d610912-447d-4e64-8316-32e399455276",
	"F_ParentId": "0",
	"F_ItemCode": null,
	"F_ItemName": "有线打印机",
	"F_ItemValue": "lr-10010",
	"F_QuickQuery": null,
	"F_SimpleSpelling": "yxdyj",
	"F_IsDefault": null,
	"F_SortCode": 18,
	"F_DeleteMark": 0,
	"F_EnabledMark": 1,
	"F_Description": null,
	"F_CreateDate": "2016-03-18 14:37:08",
	"F_CreateUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_CreateUserName": "佘赐雄",
	"F_ModifyDate": "2016-03-18 14:46:23",
	"F_ModifyUserId": "0f36148c-719f-41e0-8c8c-16ffbc40d0e0",
	"F_ModifyUserName": "佘赐雄"
}],
                                        param: { itemCode: 'Client_ProductInfo' }
                                    }
                                }
                            },
                            { label: '商品编号', name: 'F_ProductCode', width: 100, align: 'center', editType: 'label' },
                            {
                                label: '单位', name: 'F_UnitId', width: 100, align: 'center',
                                edit: {
                                    type: 'input'
                                }
                            }
                        ]
                    },
                    {
                        label: "价格信息", name: "a2", width: 80, align: "center",
                        children: [
                            {
                                label: '数量', name: 'F_Qty', width: 80, align: 'center', statistics: true,
                                edit: {
                                    type: 'input',
                                    change: function (row, rownum) {// 行数据和行号
                                        row.F_Amount = parseInt(parseFloat(row.F_Price || '0') * parseFloat(row.F_Qty || '0'));
                                        row.F_TaxAmount = parseInt((parseFloat(row.F_Price || '0') * (1 + parseFloat(row.F_TaxRate || '0') / 100)) * parseFloat(row.F_Qty || '0'));
                                        row.F_Tax = row.F_TaxAmount - row.F_Amount;
                                        $('#productgird').appGridSet('updateRow', rownum);
                                    },
                                }
                            },
                            {
                                label: '单价', name: 'F_Price', width: 80, align: 'center',
                                edit: {
                                    type: 'input',
                                    change: function (row, rownum) {// 行数据和行号
                                        row.F_Amount = parseInt(parseFloat(row.F_Price || '0') * parseFloat(row.F_Qty || '0'));
                                        row.F_TaxAmount = parseInt(parseFloat(row.F_Price || '0') * (1 + parseFloat(row.F_TaxRate || '0') / 100)) * parseFloat(row.F_Qty || '0');
                                        row.F_Tax = row.F_TaxAmount - row.F_Amount;

                                        row.F_Taxprice = parseInt(parseFloat(row.F_Price || '0') * (1 + parseFloat(row.F_TaxRate || '0') / 100));
                                        $('#productgird').appGridSet('updateRow', rownum);
                                    },
                                }
                            },
                            { label: '金额', name: 'F_Amount', width: 80, align: 'center', statistics: true },
                            {
                                label: '税率(%)', name: 'F_TaxRate', width: 80, align: 'center', editType: 'input',
                                edit: {
                                    type: 'input',
                                    change: function (row, rownum) {// 行数据和行号
                                        row.F_Amount = parseInt(parseFloat(row.F_Price || '0') * parseFloat(row.F_Qty || '0'));
                                        row.F_TaxAmount = parseInt((parseFloat(row.F_Price || '0') * (1 + parseFloat(row.F_TaxRate || '0') / 100)) * parseFloat(row.F_Qty || '0'));
                                        row.F_Tax = row.F_TaxAmount - row.F_Amount;

                                        row.F_Taxprice = parseInt(parseFloat(row.F_Price || '0') * (1 + parseFloat(row.F_TaxRate || '0') / 100));
                                        $('#productgird').appGridSet('updateRow', rownum);
                                    },
                                }
                            },
                            { label: '含税单价', name: 'F_Taxprice', width: 80, align: 'center', },
                            { label: '税额', name: 'F_Tax', width: 80, align: 'center', statistics: true },
                            { label: '含税金额', name: 'F_TaxAmount', width: 80, align: 'center', statistics: true },
                        ]
                    },
                    {
                        label: "说明信息", name: "F_Description", width: 200, align: "left",
                        edit: {
                            type: 'input'
                        }
                    }
                ],
                isEdit: true,
                height: 400,
                isMultiselect:true
            });

            // 保存数据
            $('#savaAndAdd').on('click', function () {
                acceptClick(0);
            });
            $('#save').on('click', function () {
                acceptClick(1);
            });
            
        	
        },
         
        
        
       
         /*初始化表单数据*/
        InitForm:function(){        	       	
        	alert(app.URL_REQUEST_UTILS.get('keyValue'))
        	var keyValue=app.URL_REQUEST_UTILS.get('keyValue')
       	    if(!!keyValue) {
				request.get({
					url: "/api/SystemManage/CrmOrderrmData?keyValue=" +keyValue,					
					success: function(data) {						
						$(".app-layout-wrap").appSetFormData(data.orderData)
						$('#productgird').appGridSet('refreshdata', data.orderProductData);
					}
				});
	        }
       	    
       	    /* if (!!keyValue) {
                $.appSetForm('LR_CRMModule/CrmOrder/GetFormData?keyValue=' + keyValue, function (data) {//
                    $('.app-layout-wrap').appSetFormData(data.orderData);
                    $('#productgird').appGridSet('refreshdata', data.orderProductData);
                });
            }*/
       	     
       	     
       },
       
}
    $(function () {
        pageEvent.init();
    })
})(window.jQuery, top.app)
