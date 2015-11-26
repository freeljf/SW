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
    public class SWDAL
    {


//        分页查询从第N条开始M条记录的方法
//在 MySQL 中表示为：
//select * from userlist order by userId limit n, m
//MS SQL Server 中 :
//select top(m-n) * from userList where userid not in
//(select top  n userid from userList  order by userid) order by userid
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageInde">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="pageCount">总页数</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public List<Software> GetPagedSW(int pageInde,int pageSize,out int pageCount,string type)
        {
            List<Software> li = new List<Software>();
            pageCount = 9;
            //  string sql = "select count(*) from sw;";
            int num = pageInde* pageSize;
            //pageCount = Convert.ToInt32(SqlHelper.ExecuteScalar(sql,System.Data.CommandType.Text));

            string sql1 = "SELECT * FROM sw w1 WHERE ID in (SELECT top "+ pageSize + " ID FROM ( SELECT top "+num+" ID FROM sw ORDER BY ID DESC) w ORDER BY w.ID ASC) ORDER BY  w1.ID DESC";
            SqlParameter[] sps = {
                new SqlParameter("@pageSize",pageSize),
                new SqlParameter("@num",num)
            };
            DataTable dt=SqlHelper.ExecuteDataTable(sql1, System.Data.CommandType.Text);
            
            return DtToList(dt);
        }
        public List<Software> DtToList(DataTable dt)
        {
            List<Software> li = new List<Software>();
            foreach (DataRow dr in dt.Rows)
            {
                Software s = new Software();
                s.ID = Convert.ToInt32(dr["ID"]);
                s.ClassifyID = Convert.ToInt32(dr["ClassifyID"]);
                s.swAllGrade = Convert.ToInt32(dr["swAllGrade"]);
                s.swClick = Convert.ToInt32(dr["swClick"]);
                s.swDownload = Convert.ToInt32(dr["swDownload"]);
                s.swFile = dr["swFile"].ToString();
                s.swGradeFrequency = Convert.ToInt32(dr["swGradeFrequency"]);
                s.swIcon = dr["swIcon"].ToString();
                s.swLanguage = dr["swLanguage"].ToString();
                s.swName = dr["swName"].ToString();
                s.swSize = Convert.ToDouble(dr["swSize"]);
                s.swSystem = dr["swSystem"].ToString();
                //s.swTime = Convert.ToDateTime(dr["swTime"]);
                li.Add(s);
            }
            return li;
        }
        /// <summary>
        /// 添加一个新的软件
        /// </summary>
        /// <param name="s">软件对象</param>
        /// <returns></returns>
        public bool Add(Software s)
        {
            string sql = @"INSERT INTO [dbo].[sw]
           ([swName]
           ,[swFile]
           ,[swIcon]
           ,[swSize]
           ,[swTime]
           ,[ClassifyID]
           ,[swSystem]
           ,[swLanguage]
           ,[swAllGrade]
           ,[swGradeFrequency]
           ,[swClick]
           ,[swDownload])
     VALUES
           (@swName
           ,@swFile
           ,@swIcon
           ,@swSize
           ,@swTime
           ,@ClassifyID
           ,@swSystem
           ,@swLanguage
           ,@swAllGrade
           ,@swGradeFrequency
           ,@swClick
           ,@swDownload)";
            SqlParameter[] sps = {
                new SqlParameter("@swName",s.swName),
                new SqlParameter("@swFile",s.swFile),
                new SqlParameter("@swIcon",s.swIcon),
                new SqlParameter("@swSize",s.swSize),
                new SqlParameter("@swTime",s.swTime),
                new SqlParameter("@ClassifyID",s.ClassifyID),
                new SqlParameter("@swSystem",s.swSystem),
                new SqlParameter("@swLanguage",s.swLanguage),
                new SqlParameter("@swAllGrade",s.swAllGrade),
                new SqlParameter("@swGradeFrequency",s.swGradeFrequency),
                new SqlParameter("@swClick",s.swClick),
                new SqlParameter("@swDownload",s.swDownload)
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
        /// 根据ID删除一个软件对象
        /// </summary>
        /// <param name="ID">要操作对象的ID</param>
        /// <returns>是否操作完成</returns>
        public bool Del(int ID)
        {
            string sql = "delete from sw where ID=@ID";
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
        /// <summary>
        /// 更新一个软件
        /// </summary>
        /// <param name="s">软件对象</param>
        /// <returns>是否操作成功</returns>
        public bool Update(Software s)
        {
            string sql= @"UPDATE [dbo].[sw]
   SET[swName] = @swName
      ,[swFile] = @swFile
      ,[swIcon] = @swIcon
      ,[swSize] = @swSize
      ,[swTime] = @swTime
      ,[ClassifyID] = @ClassifyID
      ,[swSystem] = @swSystem
      ,[swLanguage] = @swLanguage
      ,[swAllGrade] = @swAllGrade
      ,[swGradeFrequency] = @swGradeFrequency
      ,[swClick] = @swClick
      ,[swDownload] = @swDownload
 WHERE ID=@ID";
            SqlParameter[] sps = {
                new SqlParameter("@ID",s.ID),
                new SqlParameter("@swName",s.swName),
                new SqlParameter("@swFile",s.swFile),
                new SqlParameter("@swIcon",s.swIcon),
                new SqlParameter("@swSize",s.swSize),
                new SqlParameter("@swTime",s.swTime),
                new SqlParameter("@ClassifyID",s.ClassifyID),
                new SqlParameter("@swSystem",s.swSystem),
                new SqlParameter("@swLanguage",s.swLanguage),
                new SqlParameter("@swAllGrade",s.swAllGrade),
                new SqlParameter("@swGradeFrequency",s.swGradeFrequency),
                new SqlParameter("@swClick",s.swClick),
                new SqlParameter("@swDownload",s.swDownload)
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
        /// 通过ID获取Software对象
        /// </summary>
        /// <param name="ID">对象的ID</param>
        /// <returns>Software对象</returns>
        public Software GetSWByID(int ID)
        {
            Software s = new Software();
            string sql = "select * from sw where ID=" + ID;
            SqlDataReader dr= SqlHelper.ExecuteReader(sql, CommandType.Text);
            if (dr.Read())
            {
                
                s.ID = Convert.ToInt32(dr["ID"]);
                s.ClassifyID = Convert.ToInt32(dr["ClassifyID"]);
                s.swAllGrade = Convert.ToInt32(dr["swAllGrade"]);
                s.swClick = Convert.ToInt32(dr["swClick"]);
                s.swDownload = Convert.ToInt32(dr["swDownload"]);
                s.swFile = dr["swFile"].ToString();
                s.swGradeFrequency = Convert.ToInt32(dr["swGradeFrequency"]);
                s.swIcon = dr["swIcon"].ToString();
                s.swLanguage = dr["swLanguage"].ToString();
                s.swName = dr["swName"].ToString();
                s.swSize = Convert.ToDouble(dr["swSize"]);
                s.swSystem = dr["swSystem"].ToString();
                //s.swTime = Convert.ToDateTime(dr["swTime"]);
            }
            return s;
        }
        
        
    }
}
