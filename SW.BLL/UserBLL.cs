using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW.DAL;
using SW.Model;

namespace SW.BLL
{
    class UserBLL
    {
        UsersDAL ud = new UsersDAL();
        /// <summary>
        /// 判断是否存在并返回权限
        /// </summary>
        /// <param name="model">要操作的对象</param>
        /// <returns></returns>
        public int IsUser(Users model)
        {
            return ud.IsUser(model);
        }
        /// <summary>
        /// 添加一个管理员
        /// </summary>
        /// <param name="model">要添加的对象</param>
        /// <returns></returns>
        public bool AddUser(Users model)
        {
            return ud.AddUser(model);
        }
        /// <summary>
        /// 删除一个管理员
        /// </summary>
        /// <param name="name">要操作的用户名</param>
        /// <param name="QuanXian">当前用户的权限</param>
        /// <returns>是否已执行</returns>
        public bool DelUser(string name, int QuanXian)
        {
            return ud.DelUser(name, QuanXian);
        }
        /// <summary>
        /// 更新一个管理员
        /// </summary>
        /// <param name="model">要操作的对象</param>
        /// <param name="QX">当前用户的权限</param>
        /// <returns>是否已执行</returns>
        public bool UpdateUser(Users model, int QX)
        {
            return ud.UpdateUser(model,QX);
        }
        /// <summary>
        /// 获取所有可以管理的管理员
        /// </summary>
        /// <param name="QuanXian">当前用户的权限</param>
        /// <returns>集合</returns>
        public List<Users> SelectAllUsers(int QuanXian)
        {
            return ud.SelectAllUsers(QuanXian);
        }

    }
}
