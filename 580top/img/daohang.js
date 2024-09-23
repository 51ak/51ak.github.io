

/*文章页JS*/

function init(ids,cons,dis){
   document.getElementById(ids).getElementsByTagName('li')[0].className='div_tab_active';
  document.getElementById(cons).innerHTML=document.getElementById(dis+"l1").innerHTML;
//  document.getElementById(ids).onmouseover=function(){onmousOver(ids,cons,dis);}//鼠标指向激发效果
  document.getElementById(ids).onclick=function(){onmousOver(ids,cons,dis);}//点击激发效果
}
function onmousOver(ids,cons,dis){
o = o || window.event;
var obj=o.target || o.srcElement;
if (obj.tagName=='LI'){
  if (obj.className=='div_tab_active'||obj.id=='more')return;
  var o=document.getElementById(ids).getElementsByTagName('li');
  for (var i=0;i<=o.length-1;i++){o[i].className='div_tab_default'}
  
  obj.className='div_tab_active';
  if (obj.className=='div_tab_active'){document.getElementById(cons).innerHTML=document.getElementById(dis+obj.id).innerHTML;}
}
}

function alertWin(title, msg, w, h) {
    var titleheight = "22px"; // 提示窗口标题高度 
    var bordercolor = "#57a765"; // 提示窗口的边框颜色 
    var titlecolor = "#FFFFFF"; // 提示窗口的标题颜色 
    var titlebgcolor = "#57a765"; // 提示窗口的标题背景色
    var bgcolor = "#FFFFFF"; // 提示内容的背景色

    var iWidth = document.documentElement.clientWidth;
    var iHeight = document.documentElement.clientHeight;
    var bgObj = document.createElement("div");
    bgObj.style.cssText = "position:absolute;left:0px;top:0px;width:" + iWidth + "px;height:" + Math.max(document.body.clientHeight, iHeight) + "px;filter:Alpha(Opacity=30);opacity:0.3;background-color:#000000;z-index:101;";
    document.body.appendChild(bgObj);

    var msgObj = document.createElement("div");
    msgObj.style.cssText = "position:absolute;top:" + (iHeight - h) / 2 + "px;left:" + (iWidth - w) / 2 + "px;width:" + w + "px;height:" + h + "px;text-align:left;background-color:" + bgcolor + ";padding:1px;z-index:102;";
    document.body.appendChild(msgObj);

    var table = document.createElement("table");
    msgObj.appendChild(table);
    table.style.cssText = "margin:0px;border:0px;padding:0px;";
    table.cellSpacing = 0;
    var tr = table.insertRow(-1);
    var titleBar = tr.insertCell(-1);
    titleBar.style.cssText = "width:100%;height:" + titleheight + "px;text-align:left;padding:3px;margin:0px;font:bold 13px '宋体';color:" + titlecolor + ";border:1px solid " + bordercolor + ";cursor:move;background-color:" + titlebgcolor;
    titleBar.style.paddingLeft = "10px";
    titleBar.innerHTML = title;
    var moveX = 0;
    var moveY = 0;
    var moveTop = 0;
    var moveLeft = 0;
    var moveable = false;
    var docMouseMoveEvent = document.onmousemove;
    var docMouseUpEvent = document.onmouseup;
    titleBar.onmousedown = function () {
        var evt = getEvent();
        moveable = true;
        moveX = evt.clientX;
        moveY = evt.clientY;
        moveTop = parseInt(msgObj.style.top);
        moveLeft = parseInt(msgObj.style.left);

        document.onmousemove = function () {
            if (moveable) {
                var evt = getEvent();
                var x = moveLeft + evt.clientX - moveX;
                var y = moveTop + evt.clientY - moveY;
                if (x > 0 && (x + w < iWidth) && y > 0 && (y + h < iHeight)) {
                    msgObj.style.left = x + "px";
                    msgObj.style.top = y + "px";
                }
            }
        };
        document.onmouseup = function () {
            if (moveable) {
                document.onmousemove = docMouseMoveEvent;
                document.onmouseup = docMouseUpEvent;
                moveable = false;
                moveX = 0;
                moveY = 0;
                moveTop = 0;
                moveLeft = 0;
            }
        };
    }

    var closeBtn = tr.insertCell(-1);
    closeBtn.style.cssText = "cursor:pointer; padding:2px;background-color:" + titlebgcolor;
    closeBtn.innerHTML = "<span style='font-size:15pt; color:" + titlecolor + ";'>×</span>";
    closeBtn.onclick = function () {
        document.body.removeChild(bgObj);
        document.body.removeChild(msgObj);
    }
    var msgBox = table.insertRow(-1).insertCell(-1);
    msgBox.colSpan = 2;
    msgBox.innerHTML = "<iframe src='" + msg + "'  width='100%' height='" + (h - 28) + "px' frameborder='0'/>";

    // 获得事件Event对象，用于兼容IE和FireFox
    function getEvent() {
        return window.event || arguments.callee.caller.arguments[0];
    }
}