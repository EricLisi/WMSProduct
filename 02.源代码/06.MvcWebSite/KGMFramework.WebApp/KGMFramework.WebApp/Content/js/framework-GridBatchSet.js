
var inputmodel = $.request('inputmodel'),
    title = $.request('title')

$(function () { 
    $("#" + inputmodel + "group .formTitle").text(title) 
    switch (inputmodel) {
        case "input":
            $("#selectgroup").hide()
            $("#dategroup").hide()
            break;
        case "select":
            $("#inputgroup").hide()
            $("#dategroup").hide()
            break;
        case "date":
            $("#inputgroup").hide()
            $("#selectgroup").hide()
            break;
    }
});


