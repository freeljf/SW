using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW.DAL;
using SW.Model;

namespace SW.BLL
{
    public class EvaluateBLL
    {
        EvaluateDAL ed = new EvaluateDAL();
        //评价表
        /// <summary>
        /// 根据ID获取评价
        /// </summary>
        /// <param name="swID"></param>
        /// <returns></returns>
        public List<Evaluate> GetByID(int swID)
        {
            return ed.GetByID(swID);
        }
        /// <summary>
        /// 添加一个评价
        /// </summary>
        /// <param name="e">一个评价对象</param>
        /// <returns></returns>
        public bool Add(Evaluate e)
        {
            return ed.Add(e);
        }
        /// <summary>
        /// 根据ID删除一个评价
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>是否操作成功</returns>
        public bool Del(int ID)
        {
            return ed.Del(ID);
        }

    }
}
