﻿var dbnr= $("dbnr");
var bbv=$("bbv");
var xsyc=$("xsyc");
var xul=$("dbnr","ul")[0];
var dbimg=$("dbimg");
//初始化页面选框
function renew()
{
	var cooks=GetCookie("listhc").split("/");
	var bdbb=$("bdbb","input");
	for(var c=1;c<cooks.length;c++){var wf=cooks[c].split("_");for(var i=0;i<bdbb.length;i++){if(bdbb[i].id=="a_"+wf[0]){bdbb[i].checked=true;break;}}}
}
//初始化漂浮层
function newpos()
{
	var ouli="",alls=0;
	var cooks=GetCookie("listhc").split("/");
	for(var i=1;i<cooks.length;i++){
		alls++;var wf=cooks[i].split("_");
		ouli+="<li><img src='images/closex.gif' align='absmiddle' onclick='delli("+wf[0]+")' /> "+wf[1].replace("&%#","/")+"</li>";
	}
	xul.innerHTML=ouli;
	dbimg.innerHTML=alls;
	$("tishi").style.display=(ouli=="")?"block":"none";
	xul.style.display=(ouli=="")?"none":"block";
	//if(!alls){dbnr.style.display="none";}
}
//点击处理，增加使用其他按钮加入对比的功能，增加替换/分割符
function dblist(id,event,linkproname)
{

    if (typeof (linkproname) != "undefined" && linkproname.length > 0)
    {
        var nrid=$("link"+id);
	    var cook=GetCookie("listhc");
	    var cooks=cook.split("/");
	   	  
        //判断是否重复添加
        if(cook.indexOf("/"+id) > -1)
        {
            alert(linkproname+"已经加入档案列表");
            return;
        }
        if(cooks.length>9){alert("最多只允许添加9个档案");return;}else{SetCookie("listhc",cook+"/"+id+"_"+linkproname.replace("/","&%#"));zbyd(window.event||event);}
	   
    }
    else
    {

	    var cook=GetCookie("listhc");
	    var cooks=cook.split("/");
	    
        //修改：支持页面上有多个相同产品
        var ischecked = false;
        var nrid=document.getElementsByTagName("input");
        for(var i = 0;i<nrid.length;i++)
        {
			
            if(nrid[i].id == "a_"+id && nrid[i].checked)
            {
                //增加判断重复-liuliqiang  /
                if(cook.indexOf("/"+id) > -1)
                {
                   
                    alert(nrid[i].value+"已经加入档案列表");
                    return;
                }
                else if(cooks.length>9)
                {
                    nrid[i].checked=false;alert("最多只允许添加9个档案");return;
                }
                else
                {

                   // alert(nrid[i].id.replace("a_", ""));
                    
                    $.post("/ShareFile/_AddBeShared", { "bsid": nrid[i].id.replace("a_", "") }
                        
                    );

                    SetCookie("listhc",cook+"/"+id+"_"+nrid[i].value.replace("/","&%#"));ischecked=true;zbyd(window.event||event);
                }
            }
        }
        if(!ischecked)
	        delCookie(id);
	}
	
	newpos();
	dbnr.style.display="block";
}

 

//漂浮窗口删除
function delli(id){
    delCookie(id);
    var nrid=document.getElementsByTagName("input");
    for(var i = 0;i<nrid.length;i++)
    {
        if(nrid[i].id == "a_"+id)
        {
            nrid[i].checked = false;
        }
    }
    newpos();
}
//设置COOKIE  // 增加设置path，使各目录能取到相同的COOKIE
function SetCookie(name,value){var exp=new Date();exp.setTime(exp.getTime()+24*3600000);document.cookie=name+"="+escape(value)+";expires="+exp.toGMTString()+";path=/";}
//获得COOKIE
function GetCookie(name){var arr=document.cookie.match(new RegExp("(^| )"+name+"=([^;]*)(;|$)"));if(arr!=null){return unescape(arr[2]);}else{return "";}}
//删除COOKIE
function delCookie(id)
{
     $.post("/ShareFile/_DelBeShared?bsid=" +id, { "bsid": id } 

    );
	var cooks=GetCookie("listhc").split("/"),dstr="";
	for(var i=1;i<cooks.length;i++){if(cooks[i].split("_")[0]!=id){dstr+="/"+cooks[i];}}
	SetCookie("listhc",dstr);
}

function clears()
{
	SetCookie("listhc","")
	newpos();
	var kk=$("bdbb","input").length;
	for(var k2=0;k2<kk;k2++){
		$("bdbb","input")[k2].checked=false
	}
}
//增加点击开始对比的处理
function comparepro()
{
    var cook=GetCookie("listhc");
	var cooks=cook.split("/");
	var url = "compare";
	for(var i = 0;i<cooks.length ;i++)
	{
	    var proid = cooks[i].substr(0,cooks[i].indexOf("_"));
	    if(proid.length > 0 )
	        url += "_"+proid;
	}
	if(url.length > 7)
	{
	    window.open("/cosmetics/"+url+".htm");
	}
	else
	{
	    alert("请先选择要共享的档案");
	}
	return false;
}
//提示位置方法
function zbyd(event)
{
	var sw=50,sh=50,vw=15,vh=15,tjs=35;
	var sl=bbv.l();
	var vl=(event.pageX||(event.clientX+(document.documentElement.scrollLeft||document.body.scrollLeft)))-7;
	var st=(document.documentElement.scrollTop||document.body.scrollTop)+300;
	var vt=(event.pageY||(event.clientY+(document.documentElement.scrollTop||document.body.scrollTop)))-7;
	var spl=Math.floor(Math.abs((sl-vl)/tjs)),spt=Math.abs((st-vt)/tjs);
	xsyc.style.display="block";xsyc.l(vl);xsyc.t(vt);xsyc.w(vw);xsyc.h(vh);
	var maxTime=setInterval(function()
	{
		xsyc.l((vl+spl)<sl?vl+=spl:((vl-spl)>sl?vl-=spl:vl=sl));xsyc.t((vt+spt)<st?vt+=spt:((vt-spt)>st?vt-=spt:vt=st));
		xsyc.w(vw+2<sw?vw++:vw=sw);xsyc.h(vh+2<sh?vh++:vh=sh);
		tjs--;if(!tjs){xsyc.style.display="none";clearInterval(maxTime);}
	},10);
}
//显示/隐藏列表
function dbhidd(){dbnr.style.display=(dbnr.style.display=="block")?"none":"block";}
newpos();
renew();