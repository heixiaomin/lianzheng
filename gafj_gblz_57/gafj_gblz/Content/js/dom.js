//版本0.1
(function(){
	//-------------------------------------小功能集合
	window.Fun={
		ie:/*@cc_on!@*/false,//是否为IE
		props:{"class":"className"},
		toarr:function(ul){var ar=[];for(var i=0,n=ul.length;i<n;i++){ar[i]=ul[i];}return ar;},//转为数组
		copy:function(o,ul){if(o._ex){return o;}else{for(var n in ul){o[n]=ul[n];}o._ex=true;return o;}},//扩展属性
		xcopy:function(o,ul){for(var n in ul){reg(n);}function reg(n){o[n]=function(){var c=Fun.toarr(arguments);return ul[n].apply(c.shift(),c);};}}//拷贝属性并将第一个参数作为新属性的this
	}
	
	//window.ie=Fun.ie;
	//window.$A=Fun.toarr;
	window.$=function(id,tag){
		var re=id&&typeof id!="string"?id:document.getElementById(id)||document;
		if(!tag){
			return Fun.copy(re,Element);
		}else{
			return Dom.find(re,tag);
		}
	}
	Element={
		find:function(tag){//查找属性集合[标签及约束 (如：li[bb>li]  *[class=bbb]  *[src=a.jpg] li[src=a.jpg]) ]
			var m=/(.+)\[(\w*)(\W+)(.*)\]/.exec(tag);
			if(!m){var re=this.getElementsByTagName(tag);for(var i=0,n=re.length;i<n;i++){Fun.copy(re[i],Element);};return re;}
		else{
			var arr=[],re=this.getElementsByTagName(m[1]==""?"*":m[1]);
			if(Fun.ie&&Fun.props[m[2]]){m[2]=Fun.props[m[2]];}
			for(var i=0,n=re.length;i<n;i++){
				if(m[3]==">"&&re[i].parentNode.id==m[2]||m[3]=="="&&re[i].getAttribute(m[2])==m[4]||m[3]=="!="&&re[i].getAttribute(m[2])!=m[4]){arr.push(Fun.copy(re[i],Element));
			}}
			m=null;return arr;
		}
	},
	attr:function(key,v){if(Fun.ie&&Fun.props[key]){key=Fun.props[key];}if(v){this.setAttribute(key,v);}else{return this.getAttribute(key);}},//获取或设置节点属性
	w:function(v){if(v){this.style.width=v+"px";}else{return this.offsetWidth||this.body.offsetWidth||0;}},	//获取或设置节点宽
	h:function(v){if(v){this.style.height=v+"px";}else{return this.offsetHeight||this.body.offsetHeight||0;}},	//获取或设置节点高
	t:function(v){if(v){this.style.top=v+"px";}else{return this.offsetTop||(this.documentElement.scrollTop||this.body.scrollTop||0);}},	//设置或返回上边距
	l:function(v){if(v){this.style.left=v+"px";}else{return this.offsetLeft||(this.documentElement.scrollLeft||this.body.scrollLeft||0);}},	//设置或返回左边距
	v:function(v){if(v){this.innerHTML?this.innerHTML=v:this.value=v;}else{return this.innerHTML||this.value||"";};},	//设置或返回值
	op:function(v){if(Fun.ie){this.filters.alpha.opacity=v;}else{this.style.opacity=(v/100);}}	//设置层的透明度
	}
	//页面功能，无法针对节点来执行的
	window.Dom=Dom={	
		addEvent:function(s,fn){this.attachEvent?this.attachEvent('on'+s,fn):this.addEventListener(s,fn,false);return this;},//添加事件[事件(要去掉前面的on),方法]
		delEvent:function(s,fn){this.detachEvent?this.detachEvent('on'+s,fn):this.removeEventListener(s,fn,false);return this;},//删除事件[事件(要去掉前面的on),方法]
		addDom:function(node,tag,first){var o=node.createElement(tag);first?node.insertBefore(o,node.firstChild):node.appendChild(o);return o;},//创建子节点[节点，要创建的TAG，插入位置]
		delDom:function(node,obj){node.removeChild(obj);},//删除子节点[父节点，要删除节点]
		addImg:function(url){var img=new Image();img.src=url;return img;},//创建缓存图片[图片地址]
		winh:function(){return Math.min(document.documentElement.clientHeight,document.body.clientHeight);},//返回浏览器可用高
		mouseX:function(event){return (event.pageX || (event.clientX +l(document)));},//返回鼠标的X座标
		mouseY:function(event){return (event.pageY || (event.clientY +t(document)));}//返回鼠标的Y座标
	}
	Fun.xcopy(Dom,Element);

})();


