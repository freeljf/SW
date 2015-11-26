using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW.DAL;
using SW.Model;

namespace SW.BLL
{
    
    class ClassifyBLL
    {
        ClassifyDAL cd = new ClassifyDAL();
        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        public List<Classify> GetAllClassify()
        {
            return cd.GetAllClassify();
        }
        /// <summary>
        /// 添加一个分类
        /// </summary>
        /// <param name="s">分类名</param>
        /// <returns>是否添加成功</returns>
        public bool Add(string s)
        {
            return cd.Add(s);
        }
        /// <summary>
        /// 删除一个分类
        /// </summary>
        /// <param name="s">分类名</param>
        /// <returns>是否成功删除</returns>
        public bool Del(string s)
        {
            return cd.Del(s);
        }
        /// <summary>
        /// 更改分类
        /// </summary>
        /// <param name="cf">要操作的对象</param>
        /// <returns>是否更改成功</returns>
        public bool UpdateClassify(Classify cf)
        {
            return cd.UpdateClassify(cf);
        }
    }
}
