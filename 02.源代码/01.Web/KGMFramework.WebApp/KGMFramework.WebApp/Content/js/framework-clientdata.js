﻿var clients = [];
$(function () {
    clients = $.clientsInit();
})
$.clientsInit = function () {
    var dataJson = {
        dataItems: [],
        organize: [],
        role: [],
        duty: [],
        user: [],
        authorizeMenu: [],
        authorizeButton: [],
        asseyType: [],
        supplierInfo:[],
        
    };
    var init = function () {
        $.ajax({
            url: "/ClientsData/GetClientsDataJson",
            type: "get",
            dataType: "json",
            async: false,
            success: function (data) {
                dataJson.dataItems = data.dataItems;
                dataJson.organize = data.organize; 
                dataJson.asseyType = data.asseyType;
                dataJson.supplierInfo = data.supplierInfo;
                dataJson.role = data.role;
                dataJson.duty = data.duty;
                dataJson.authorizeMenu = eval(data.authorizeMenu);
                dataJson.authorizeButton = data.authorizeButton;
            }
        });

        //根据当前用户，得到对应的仓库                      
        $.ajax({
            url: "/SystemManage/User/GetWarehouse",
            type: "get",
            dataType: "json",
            success: function (data) {
                localStorage.setItem('WarehouseId', data.Warehouse.F_Id);
                localStorage.setItem('IsAdmin', data.IsAdmin);
            }
        })
    }
    init();
    return dataJson;
}