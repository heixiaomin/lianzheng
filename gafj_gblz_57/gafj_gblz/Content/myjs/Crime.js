
$(function () {
     
    //保存
    $("#savebtn").click(function () {

        if ($("#name").val() == null || $("#name").val() == "" || $("#relation").val() == null || $("#relation").val() == "" || $("#unit_post").val() == null || $("#unit_post").val() == "") {

            alert("请将信息填写完整！");

            return;
        }
        $.post("/EnterFile/_AddCrime", {

            "c.CrimerName": $("#name").val(),
            "c.Relation": $("#relation").val(),
            "c.CrimerUnit": $("#unit_post").val(),
            "c.LawAgency": $("#law").val(),
            "c.Result": $("#result").val(),
            "c.Remark": $("#remark").val(),
            

        }, function (data) {

            if (data == "1") {
                alert("保存成功！");
                location.href = "/EnterFile/Index";
            }
            else {
                alert("保存失败,请重试！");
                location.reload();//刷新
            }
        });
    });

});