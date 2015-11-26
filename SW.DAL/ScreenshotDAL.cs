using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW.Model;
using Common;

namespace SW.DAL
{
    public class ScreenshotDAL
    {
        //截图表
        /// <summary>
        /// 根据ID获取截图路径
        /// </summary>
        /// <param name="swID">软件ID</param>
        /// <returns>路径集合</returns>
        public List<string> GetByID(int ID)
        {
            List<string> li = new List<string>();
            string sql = "select SPath from Screenshot where ID=@ID";
            SqlParameter[] sps = { new SqlParameter("@ID", ID) };
            SqlDataReader sdr = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text, sps);
            while (sdr.Read())
            {
                li.Add(sdr["SPath"].ToString());
            }
            return li;
        }
        /// <summary>
        /// 添加一个截图
        /// </summary>
        /// <param name="ss">截图对象</param>
        /// <returns>操作是否成功</returns>
        public bool Add(Screenshot ss)
        {
            string sql = "insert into Screenshot(swID,SPath)VALUES(@swID,@SPath)";
            SqlParameter[] sps = {
                new SqlParameter("@swID", ss.swID),
                new SqlParameter("@SPath",ss.SPath)
            };
            int num = SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, sps);
            if (num > 0)
            {
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// 根据ID删除截图
        /// </summary>
        /// <param name="ID">截图的ID</param>
        /// <returns></returns>
        public bool Del(int ID)
        {
            string sql = "delete from Screenshot where ID=@ID";
            SqlParameter[] sps = {
                new SqlParameter("@ID", ID)
            };
            int num = SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, sps);
            if (num > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
