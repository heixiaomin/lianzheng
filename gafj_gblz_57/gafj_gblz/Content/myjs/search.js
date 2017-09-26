 
$(function () {


    getData();

        //$("#searchbtn").click(function () {
        //    alert("eeee");


        //    getData();
        //});

     

});
 

//获取地址栏参数//可以是中文参数
function getUrlParam(key) {
    // 获取参数
    var url = window.location.search;
    // 正则筛选地址栏
    var reg = new RegExp("(^|&)" + key + "=([^&]*)(&|$)");
    // 匹配目标参数
    var result = url.substr(1).match(reg);
    //返回参数值
    return result ? decodeURIComponent(result[2]) : null;
}





function getData() {
    $.ajax({
        url: "/CheckFile/Search",
        type: "get",
        data: { keywords: getUrlParam("keywords") },
        success: function (result) {
            var jsonobj = JSON.parse(result);
            parsetDate(jsonobj);
        }
    });
}

function parsetDate(jsonobj) {
    var str = "";
    $.each(jsonobj, function (index, item) {

        
        var needtr = $("<tr></tr>");    
        needtr.append("<td hidden='hidden'>" + item.userid + "</td>");
        needtr.append("<td>" + item.realname + "</td>");
        needtr.append("<td>" + item.unitname + "</td>");
        needtr.append("<td>" + item.unitname + "</td>");
        needtr.append("<td>" + item.tel + "</td>");
        
            
        needtr.append("<td><a href=\"#\">删除</a></td>");

        str += needtr.prop("outerHTML");

    });
    $("#mycontent").html(str);
}
 