﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW.Model;
using Common;
using System.Data.SqlClient;

namespace SW.DAL
{
    public class EvaluateDAL
    {
        //评价表
        /// <summary>
        /// 根据ID获取评价
        /// </summary>
        /// <param name="swID"></param>
        /// <returns></returns>
        public List<Evaluate> GetByID(int swID)
        {
            List<Evaluate> li = new List<Evaluate>();
            string sql = "select * from Evaluate where swID=@swID";
            SqlParameter[] sps = { new SqlParameter("@swID", swID) };
            SqlDataReader sdr= SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text, sps);
            while (sdr.Read())
            {
                Evaluate e = new Evaluate();
                e.ID = Convert.ToInt32(sdr["ID"]);
                e.swID =  Convert.ToInt32(sdr["swID"]);
                e.EText = sdr["EText"].ToString();
                li.Add(e);
            }
            return li;
        }
        /// <summary>
        /// 添加一个评价
        /// </summary>
        /// <param name="e">一个评价对象</param>
        /// <returns></returns>
        public bool Add(Evaluate e)
        {
            string sql = "insert into Evaluate (swID,EText)VALUES(@swID,@EText)";
            SqlParameter[] sps = {
                new SqlParameter("@swID", e.swID),
                new SqlParameter("@EText",e.EText)
            };
           int num= SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, sps);
            if (num>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据ID删除一个评价
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>是否操作成功</returns>
        public bool Del(int ID)
        {
            string sql = "delete from Evaluate where ID=@ID";
            SqlParameter[] sps = { new SqlParameter("@ID", ID) };
            int num= SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, sps);
            if (num>0)
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
