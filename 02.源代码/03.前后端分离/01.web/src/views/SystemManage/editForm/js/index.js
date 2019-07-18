/*
 * 模块管理主页面
 */
var refreshGirdData; // 更新数据
var selectedRow;


(function ($, app) {
    "use strict";
    var parentId = "0";
    /**
     * 页面事件
     */
    var pageEvent = {
        /**
         * 初始化事件
         */
        init: function () { 
            $('#app_layout').appLayout();
            pageEvent.initConfig();          
            pageEvent.initgrid()
           
                        
        },
        /**
         * 初始化配置
         */
        initConfig:function(){
            //错误页面路径重设
            app.APP_CONFIGRATION.ROUTER_CONFIG.ERROR_PAGE_URL = "../../../Error/index.html";
        },
       
        initgrid:function(){
        	 $('#gridtable').appgrid({
                url: top.$.rootUrl + '/LR_SystemModule/CodeRule/GetPageList',
                 //rowdatas:,
                headData: [
                    {
                        label: '输入框', name: 'input', width: 120, align: 'left',
                        edit: {
                            type: 'input',
                            init: function (data, $edit) {// 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象

                            },
                            change: function (data, num) {// 行数据和行号

                            }
                        }
                    },
                    {
                        label: '下拉框', name: 'select', width: 120, align: 'left',
                        edit: {
                            type: 'select',
                            init: function (data, $edit) {// 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象

                            },
                            change: function (row, num, item) {// 行数据和行号,下拉框选中数据

                            },
                            op: {// 下拉框设置参数 和 appselect一致
                                data: [
                                    { 'id': '1', 'text': '选项一' },
                                    { 'id': '2', 'text': '选项二' },
                                    { 'id': '3', 'text': '选项三' },
                                    { 'id': '4', 'text': '选项四' }
                                ]
                            }
                        }
                    },
                    /*{
                        label: '单选框', name: 'radio', width: 120, align: 'left',
                        edit: {
                            type: 'radio',
                            datatype: 'dataItem',
                            code: 'DbVersion',
                            init: function (data, $edit) {// 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象
                            },
                            change: function (data, num) {// 行数据和行号

                            },
                            //data: [
                            //    { 'id': '1', 'text': '选项一' },
                            //    { 'id': '2', 'text': '选项二' }
                            //],
                            dfvalue:'Oracle'// 默认选中项
                        }
                    },*/
                    {
                        label: '多选框', name: 'checkbox', width: 260, align: 'left',
                        edit: {
                            type: 'checkbox',
                            init: function (data, $edit) {// 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象

                            },
                            change: function (data, num) {// 行数据和行号

                            },
                            data: [
                                { 'id': '1', 'text': '选项一' },
                                { 'id': '2', 'text': '选项二' },
                                { 'id': '3', 'text': '选项三' },
                                { 'id': '4', 'text': '选项四' }
                            ],
                            dfvalue: '1,2'// 默认选中项
                        }
                    },
                    {
                        label: '时间', name: 'date', width: 120, align: 'left',
                        edit: {
                            type: 'datatime',
                            dateformat: '0',       // 0:yyyy-MM-dd;1:yyyy-MM-dd HH:mm,格式
                            init: function (data, $edit) {// 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象

                            },
                            change: function (data, num) {// 行数据和行号

                            }
                        }
                    },
                    {
                        label: '弹层', name: 'layer', width: 120, align: 'left',
                        edit: {
                            type: 'layer',
                            init: function (data, $edit, rownum) {// 在点击单元格的时候触发，可以用来初始化输入控件，行数据和控件对象

                            },
                            change: function (data, rownum, selectData) {// 行数据和行号,弹层选择行的数据，如果是自定义实现弹窗方式则该方法无效
                                data.layer = selectData.F_ItemValue;
                                data.layer2 = selectData.F_ItemName;
                                $('#gridtable').appGridSet('updateRow', rownum);
                            },
                            op: { // 如果未设置op属性可以在init中自定义实现弹窗方式
                                width: 900,
                                height: 400,
                                colData: [
                                    { label: "商品编号", name: "F_ItemValue", width: 100, align: "left" },
                                    { label: "商品名称", name: "F_ItemName", width: 450, align: "left" }
                                ],
                                //url: top.$.rootUrl + '/LR_SystemModule/DataItem/GetDetailList',
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
}],
                                param: { itemCode: 'Client_ProductInfo' }
                            }
                        }
                    },
                    {
                        label: '弹层2', name: 'layer2', width: 120, align: 'left'
                    }

                ],
                isEdit: true,
                isMultiselect: true,
                onAddRow: function (row, rows) {//行数据和所有行数据

                },
                onMinusRow: function (row, rows) {//行数据和所有行数据

                },
                beforeMinusRow: function (row) {// 行数据 返回false 则不许被删除
                    return true;
                }
           });          
        }
    };
    $(function () {
        pageEvent.init();
    });

})(window.jQuery, top.app);