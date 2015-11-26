using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;
using System.IO;
using System.Text;

namespace Common
{
    /// <summary>
    /// NVelocityHelpers 的摘要说明
    /// </summary
    public class NVelocityHelpers
    {
        private VelocityEngine velocityEngine = null;
        private VelocityContext vc = new VelocityContext();
        /// <summary>
        /// 创建Velocity 引擎（VelocityEngine）并设置属性，默认编码为utf-8
        /// </summary>
        /// <param name="templatePath">模板相对于根目录的路径</param>
        public NVelocityHelpers(string templatePath)
        {
            //1.创建Velocity 引擎（VelocityEngine）并设置属性
            velocityEngine = new VelocityEngine();
            velocityEngine.AddProperty(RuntimeConstants.RESOURCE_LOADER, "file");           // Velocity加载类型
            velocityEngine.AddProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH,          // Velocity加载文件路径
               HttpContext.Current.Server.MapPath("~/" + templatePath + "/"));
            velocityEngine.AddProperty(RuntimeConstants.INPUT_ENCODING, "utf-8");          // 输入编码格式设置
            velocityEngine.AddProperty(RuntimeConstants.OUTPUT_ENCODING, "utf-8");         // 输出编码格式设置
            velocityEngine.Init();
        }
        /// <summary>
        /// 设置上下文对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void PutVelocity(string key, object value)
        {
            vc.Put(key, value);
        }
        /// <summary>
        /// 合并模板并输出
        /// </summary>
        /// <param name="templatFileName">模板名</param>
        public void Render(string templatFileName)
        {
            //3.创建模板
            Template template = velocityEngine.GetTemplate(templatFileName);

            //4.合并模板和上下文对象、输出
            StringWriter writer = new StringWriter();
            template.Merge(vc, writer);
            HttpContext.Current.Response.Write(writer.ToString());
            HttpContext.Current.Response.End();
        }
    }
}