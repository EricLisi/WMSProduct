var id = $.request('id');
var searchId, parmlist, router, gridId;
$(function () {
    var sessiondata = JSON.parse(sessionStorage.getItem(id))
    searchId = sessiondata.searchId;
    parmlist = sessiondata.parmlist;
    router = sessiondata.router;
    gridId = sessiondata.gridId;

    sessionStorage.removeItem(id)

    var columnModel = $.currentWindow().$("#" + gridId).jqGrid('getGridParam', 'colModel');
    $.each(columnModel, function (i) {
        var label = columnModel[i].label;
        var name = columnModel[i].name;
        var hidden = columnModel[i].hidden;
        if (!!label && hidden == false) {
            $(".sys_spec_text").append("<li data-value='" + name + "' title='" + label + "'><a>" + label + "</a><i></i></li>");
        }
    });
    $(".sys_spec_text li").addClass("active");
    $(".sys_spec_text li").click(function () {
        if (!!$(this).hasClass("active")) {
            $(this).removeClass("active");
        } else {
            $(this).addClass("active").siblings("li");
        }
    });
});
//确定导出
function AcceptClick() {
    var exportField = [];
    var filename = $("#fileName").val();
    $('.sys_spec_text ').find('li.active').each(function () {
        var value = $(this).attr('data-value');
        exportField.push(value);
    });

    var grid = $.currentWindow().$("#" + gridId)

    var columnJson = grid.jqGrid('getGridParam', 'colModel');

    //处理列数据
    $.each(columnJson, function (i, n) {
        n.formatoptions = undefined;
    })

    var s = sessionStorage.getItem(searchId);

    if (parmlist && parmlist != "") {
        if (s && s != "") {
            s = JSON.parse(s);
            var sdata = JSON.parse(s.data);
            sdata.KeyValueList = parmlist;
            s = JSON.stringify({ type: s.type, data: JSON.stringify(sdata) })
        } else {
            s = JSON.stringify({ type: 0, data: JSON.stringify({ Condition: "", KeyValueList: parmlist }) })
        }
    }


    $('#executeexcel').remove();
    var $form = $("<form id='executeexcel' method='post' action='/" + router + "/ExecuteExportExcel' style='display:none;'>");
    var $input = $("<input type='hidden' name='columnJson' value='" + JSON.stringify(columnJson) + "'><input type='hidden' name='rowJson' value='" + s + "'><input type='hidden' name='exportField' value='" + String(exportField) + "'><input type='hidden' name='filename' value='" + escape(filename ? filename : "ExportExcelFile") + "'>");
    $("body").append($form);
    $form.append($input).submit();
}