<%@ WebHandler Language="C#" Class="soft_detail" %>

using System;
using System.Web;
using Common;
using SW.BLL;
using SW.Model;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public class soft_detail : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        SWBLL swb = new SWBLL();
        int pageCount;
        Software s = swb.GetSWByID(2);
        
        JavaScriptSerializer jss = new JavaScriptSerializer();
        string jsonStr = jss.Serialize(s);  //转化为json对象
        context.Response.Write(jsonStr);       //返回给前台

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}