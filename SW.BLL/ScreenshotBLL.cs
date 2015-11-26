using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW.DAL;
using SW.Model;

namespace SW.BLL
{
    class ScreenshotBLL
    {
        ScreenshotDAL sd = new ScreenshotDAL();
        //截图表
        /// <summary>
        /// 根据ID获取截图路径
        /// </summary>
        /// <param name="swID">软件ID</param>
        /// <returns>路径集合</returns>
        public List<string> GetByID(int ID)
        {
            return sd.GetByID(ID);
        }
        /// <summary>
        /// 添加一个截图
        /// </summary>
        /// <param name="ss">截图对象</param>
        /// <returns>操作是否成功</returns>
        public bool Add(Screenshot ss)
        {
            return sd.Add(ss);
        }
        /// <summary>
        /// 根据ID删除截图
        /// </summary>
        /// <param name="ID">截图的ID</param>
        /// <returns></returns>
        public bool Del(int ID)
        {
            return sd.Del(ID);
        }
    }
}
