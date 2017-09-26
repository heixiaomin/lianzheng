function ExcelUpload(uppath, obj) {
    //        var uploadfile = $("#" + uppath).val();
    $("#upload_form").ajaxSubmit({

       
        success: function (data, textStatus) {
            if (data.status == 1) {
                alert(data.msg);
                $("#Path").val(data.path);
                alert($("#Path").val());
            } else {
                alert(data.msg);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        },
        url: "/Utility/Upload_Ajax.ashx?action=UpFilePath&UploadFile=" + uppath,
        type: "post",
        dataType: "json",
        async: false,
        timeout: 200000
    });
    return false;
}
 
