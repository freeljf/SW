using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW.Model;
using SW.DAL;

namespace SW.BLL
{
    public class SWBLL
    {
        SWDAL swd = new SWDAL();
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="pageCount">输出参数 总页数</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public List<Software> GetPagedSW(int pageInde, int pageSize, out int pageCount,string type)
        {
            return swd.GetPagedSW(pageInde, pageSize, out pageCount,type);
        }
        /// <summary>
        /// 添加一个新的软件
        /// </summary>
        /// <param name="s">软件对象</param>
        /// <returns></returns>
        public bool Add(Software s)
        {
            return swd.Add(s);
        }
        /// <summary>
        /// 根据ID删除一个软件对象
        /// </summary>
        /// <param name="ID">要操作对象的ID</param>
        /// <returns>是否操作完成</returns>
        public bool Del(int ID)
        {
            return swd.Del(ID);
        }
        /// <summary>
        /// 更新一个软件
        /// </summary>
        /// <param name="s">软件对象</param>
        /// <returns>是否操作成功</returns>
        public bool Update(Software s)
        {
            return swd.Update(s);
        }
        /// <summary>
        /// 通过ID获取Software对象
        /// </summary>
        /// <param name="ID">对象的ID</param>
        /// <returns>Software对象</returns>
        public Software GetSWByID(int ID)
        {
            return swd.GetSWByID(ID);
        }
    }
}
