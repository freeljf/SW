using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW.Model;
using Common;
using System.Data.SqlClient;
using System.Data;

namespace SW.DAL
{
    public class UsersDAL
    {
        /// <summary>
        /// 判断用户是否存在并返回权限
        /// </summary>
        /// <param name="name">用户名,只能是字母和数字</param>
        /// <param name="pwd">密码,只能是字母和数字</param>
        /// <returns>权限</returns>
        public int IsUser(Users model)
        {
            string sql = "select QuanXian from User where UserName=@UserName and UserPwd=@UserPwd;";
            SqlParameter[] parameters = {
                new SqlParameter("@UserName",model.UserName),
                new SqlParameter("@UserPwd",model.UserPwd)
            };

            object obj = SqlHelper.ExecuteScalar(sql, CommandType.Text, parameters);
            if (obj == null)
            {
                return 0;
            }
            else {
                return Convert.ToInt32(obj);
            }

        }
        /// <summary>
        /// 添加一个管理员
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>是否添加成功</returns>
        public bool AddUser(Users model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Users(");
            strSql.Append("UserName,UserPwd,QuanXian)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@UserPwd,@QuanXian)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserPwd", SqlDbType.NVarChar,50),
                    new SqlParameter("@QuanXian", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserPwd;
            parameters[2].Value = model.QuanXian;
            return Execute(strSql.ToString(),parameters);
        }
        /// <summary>
        /// 删除一个管理员
        /// </summary>
        /// <param name="name">要删除的管理员名字</param>
        /// <param name="QX">当前用户的权限</param>
        /// <returns>true:已删除，false：权限不足或要操作的对象不存在</returns>
        public bool DelUser(string UserName,int QuanXian)
        {
            string sql = "delete from Users where UserName=@UserName and QuanXian<@QuanXian";
            SqlParameter[] sps = {
                new SqlParameter("@UserName",UserName),
                new SqlParameter("@QuanXian",QuanXian)
            };
            return Execute(sql, sps);

        }
        /// <summary>
        /// 更新一个管理员信息
        /// </summary>
        /// <param name="UserName">要操作的对象名</param>
        /// <param name="QuanXian">当前用户的权限</param>
        /// <returns>true：操作成功，false：权限不足</returns>
        public bool UpdateUser(Users model,int QX)
        {
            if (QX > model.QuanXian)
            {
                //判断权限是否大于当前用户权限
                string sql = "UPDATE [dbo].[Users] SET[UserName] = @UserName ,[UserPwd] = @UserPwd ,[QuanXian] = @QuanXian WHERE ID=@ID and QX>@QuanXian ";
                SqlParameter[] sps = {
                new SqlParameter("@UserName",model.UserName),
                new SqlParameter("@QuanXian",model.QuanXian),
                new SqlParameter("@UserPwd",model.UserPwd),
                new SqlParameter("@QX",QX),
            };

                return Execute(sql, sps);
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取所有可以管理的管理员
        /// </summary>
        /// <param name="QuanXian">当前用户的权限</param>
        /// <returns></returns>
        public List<Users> SelectAllUsers(int QuanXian)
        {
            List<Users> li = new List<Users>();
            string sql = "select * from Users where QuanXian<@QuanXian";
            SqlParameter[] sps = { new SqlParameter("@QuanXian", QuanXian) };
            SqlDataReader sdr= SqlHelper.ExecuteReader(sql, CommandType.Text, sps);
            
            while (sdr.Read())
            {
                Users u = new Users();
                u.ID = Convert.ToInt32(sdr["ID"]);
                u.UserName = sdr["UserName"].ToString();
                u.UserPwd = sdr["UserPwd"].ToString();
                u.QuanXian = Convert.ToInt32(sdr["QuanXian"]);
                li.Add(u);
            }
            return li;
        }


        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>是否已经执行</returns>
        public bool Execute(string sql, params SqlParameter[] parameters)
        {
            int num = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
