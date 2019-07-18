var gridId = $.request('gridId');
var searchId = $.request('searchId')
var columnModel = $.currentWindow().$("#" + gridId).jqGrid('getGridParam', 'colModel');
var optionlist = undefined;//拼接的options
var router = $.request('router');
$(function () {
    $.each(columnModel, function (i) {
        var label = columnModel[i].label;
        var name = columnModel[i].name;
        var hidden = columnModel[i].hidden;
        var searchFiled = "";
        if (!!columnModel[i] && !!columnModel[i].advsearch && !!columnModel[i].advsearch.searchFiled) {
            searchFiled = columnModel[i].advsearch.searchFiled
        }
        if (!!label && hidden == false) {
            optionlist += "<option value='" + name + "' searchFiled='" + searchFiled + "'>" + label + "</option>";
        }
    });
    btn_add();
});

//渲染控件
function InitSelect() {
    $(".F_Type").select2({
        //minimumResultsForSearch: -1
    });
    $(".F_Conn").select2({
        //minimumResultsForSearch: -1
    });
    $(".F_SearchFiled").select2({
        //minimumResultsForSearch: -1
    });
}

//新增条件
function btn_add() {
    var addStr = '<tr class="F_Row">' +
                    '<td class="formValue" style="width:60px">' +
                        '<input type="button" name="F_Del" class="F_Del btn btn-danger" style="width:50px" onclick="removeRow(this)" value="移除"/>' +
                    '</td>' +
                    '<td class="formValue">' +
                        '<select name="F_Conn" class="F_Conn form-control required">' +
                            '<option value="And">And</option>' +
                            '<option value="Or">Or</option>' +
                        '</select>' +
                    '</td>' +
                    '<td class="formValue">' +
                        '<select name="F_SearchFiled" class="F_SearchFiled form-control required" onchange="changeControl(this)">' +
                            optionlist +
                        '</select>' +
                    '</td>' +
                    '<td class="formValue">' +
                        '<select name="F_Type" class="F_Type form-control required">' +
                            '<option value="0">等于</option>' +
                            '<option value="1">不等于</option>' +
                            '<option value="2">包含</option>' +
                            '<option value="3">不包含</option>' +
                            '<option value="4">大于</option>' +
                            '<option value="5">大于等于</option>' +
                            '<option value="6">小于</option>' +
                            '<option value="7">小于等于</option>' +
                        '</select>' +
                    '</td>' +
                    '<td class="formValue searchControl">' +
                        '<input type="text" name="F_Value" class="F_Value form-control required" />' +
                    '</td>' +
                '</tr>'
    $("#SearchTable").append(addStr);
    InitSelect();
}

//删除行
function removeRow(ele) {
    $(ele).parents('.F_Row').remove();
}

//重置
function btn_reset() {
    var trlist = $("#SearchTable tr");//获取所有行
    $.each(trlist, function (i, n) {
        n.remove();
    });
    btn_add();
}

//高级搜索
function btn_advSearch() {
    var searchJson = getSubmitParm();
    //将数据存储到sessionstorage
    if (searchId && searchId != "") {
        sessionStorage.setItem(searchId, JSON.stringify({ type: 1, data: JSON.stringify({ Condition: JSON.stringify(searchJson) }) }));
    }

    $.currentWindow().$('#' + $.request('gridId')).jqGrid('setGridParam', {
        postData: { keyword: "", searchFiled: "", list: JSON.stringify(searchJson) }
    }).trigger('reloadGrid');
    $.modalClose();
}

//关闭窗体
function btn_close() {
    $.modalClose();
}

//获取提交参数
function getSubmitParm() {
    var trlist = $("#SearchTable tr");//获取所有的行
    var parmlist = [];

    $.each(trlist, function (i, n) {
        var searchFiled = $(n).find(".F_SearchFiled").val();
        var opts = $(n).find(".F_SearchFiled").find("option")
        for (var i = 0; i < opts.length; i++) {
            var opt = $(opts[i])
            if (opt.attr('value') == searchFiled) {
                if (!!opt.attr('searchFiled')) {
                    searchFiled = opt.attr('searchFiled')
                }
                break;
            }
        }

        //从对象内获取对象
        var conditionobj = {};//定义一个条件对象
        conditionobj.F_condition = $(n).find(".F_Conn").val();//And Or
        conditionobj.F_searchFiled = searchFiled;//查询字段
        conditionobj.F_fvalue = $(n).find(".F_Value").val(); //查询的值
        conditionobj.F_type = $(n).find(".F_Type").val();//= <> ..
        parmlist.push(conditionobj);
    });

    return parmlist;
}

//显示SQL
function btn_showSql() {
    //获取表格内所有的行
    var parmlist = getSubmitParm();
    var sql = "";
    $.each(parmlist, function (i, n) {
        //从对象内获取每段的SQL 
        var condition = n.condition;
        var searchFiled = n.searchFiled;
        var value = n.fvalue;
        var valuePrefix = "'"
        var valueSufix = "'"
        var type = "";
        switch (n.type) {
            case '0': type = "="; break;//等于
            case '1': type = "<>"; break;//不等于
            case '2': type = "LIKE";
                valuePrefix = "'%"
                valueSufix = "%'"
                break;//包含
            case '3': type = "NOT LIKE";
                valuePrefix = "'%"
                valueSufix = "%'"
                break;//不包含
            case '4': type = ">"; break;//大于
            case '5': type = ">="; break;//大于等于
            case '6': type = "<"; break;//小于
            case '7': type = "<="; break;//小于等于
        }
        sql += " " + condition + " " + searchFiled + " " + type + " " + valuePrefix + value + valueSufix;
    });
    alert(sql)
}


function changeControl(ele) {
    var _this = $(ele);
    var advsearch = undefined;
    for (var i = 0; i < columnModel.length; i++) {
        if (columnModel[i].name == _this.val()) {
            advsearch = columnModel[i].advsearch;
        }
    }

    if (!!advsearch) {
        var searchFiled = $(ele).attr('searchFiled')
        var searchControl = $(ele).parents('.F_Row').find('.searchControl');
        var searchHTML = undefined;
        //处理显示框
        switch (advsearch.type) {
            case "select"://下拉框
                var selectdatakey = !!advsearch.datakey ? advsearch.datakey : "id";
                var selectdatavalue = !!advsearch.datavalue ? advsearch.datavalue : "text";

                searchHTML = "<select name='F_Value' class='F_Value form-control' searchFiled='" + (advsearch.searchFiled ? advsearch.searchFiled : "") + "'>"
                if (advsearch.dataset == "local") {//本地数据
                    if (advsearch.datatype == "strarr") {
                        for (var i = 0; i < advsearch.data.length; i++) {
                            searchHTML += "<option value='" + advsearch.data[i] + "'>" + advsearch.data[i] + "</option>";
                        }
                    } else if (advsearch.datatype == "objarr") {
                        for (var i = 0; i < advsearch.data.length; i++) {
                            searchHTML += "<option value='" + advsearch.data[i][selectdatakey] + "'>" + advsearch.data[i][selectdatavalue] + "</option>";
                        }
                    }
                }

                searchHTML += "</select>"
                if (!!searchHTML) {
                    searchControl.html(searchHTML);
                }
                $(".F_Value").bindSelect({
                    url: advsearch.url,
                });
                break;
            case "date":
                searchHTML = ' <input name="F_Value" type="text" class="F_Value form-control input-wdatepicker" onfocus="WdatePicker()" />'
                searchControl.html(searchHTML);
                $("#F_Value").DefalutDate()
                break;
        }


    }
}