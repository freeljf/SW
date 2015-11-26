<%@ WebHandler Language="C#" Class="index" %>

using System;
using System.Web;
using SW.BLL;
using SW.Model;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public class index : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        int pageCount;
        SWBLL sb = new SWBLL();    //新建一个SWBLL类对象
        List<Software> list=sb.GetPagedSW(2,4,out pageCount);   //获取所有数据
        JavaScriptSerializer jss = new JavaScriptSerializer();
        string jsonStr = jss.Serialize(list);  //转化为json对象
        context.Response.Write(jsonStr);       //返回给前台
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}