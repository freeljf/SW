using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Common;

namespace SW.DAL
{
    public class ClassifyDAL
    {
        //分类
        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        public List<Classify> GetAllClassify()
        {
            List<Classify> li = new List<Classify>();
            string sql = "select * from Classify";
            SqlDataReader sdr= SqlHelper.ExecuteReader(sql, CommandType.Text);
            while (sdr.Read())
            {
                Classify cf = new Classify();
                cf.ID = Convert.ToInt32(sdr["ID"]);
                cf.swClassify = sdr["swClassify"].ToString();
                li.Add(cf);
            }
            return li;
        }
        /// <summary>
        /// 添加一个分类
        /// </summary>
        /// <param name="s">分类名</param>
        /// <returns>是否添加成功</returns>
        public bool Add(string s)
        {
            ///不重复插入
            string sql = "delete from Classify where swClassify=@swClassify;insert into Classify (swClassify)values(@swClassify);";
            SqlParameter[] sps = { new SqlParameter("@swClassify", s) };
            int num= SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sps);
            if (num > 0)
            {
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// 删除一个分类
        /// </summary>
        /// <param name="s">分类名</param>
        /// <returns>是否成功删除</returns>
        public bool Del(string s)
        {
            string sql = "delete from Classify where swClassify=@swClassify;";
            SqlParameter[] sps = { new SqlParameter("@swClassify", s) };
            int num = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sps);
            if (num > 0)
            {
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// 更改分类
        /// </summary>
        /// <param name="cf">要操作的对象</param>
        /// <returns>是否更改成功</returns>
        public bool UpdateClassify(Classify cf)
        {
            string sql = "update Classify set swClassify=@swClassify where ID=@ID";
            SqlParameter[] sps = { new SqlParameter("@swClassify",cf.swClassify),
            new SqlParameter("@ID",cf.ID)};
            int num= SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sps);
            if (num > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
