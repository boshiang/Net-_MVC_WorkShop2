using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace NET_MVC_WorkShop2.Models
{
    public class CodeService
    {
        //string connStr = @"Data Source=DESKTOP-40A05S2;Initial Catalog=GSSWEB;User ID=sa;Password=workshop";
        //SqlConnection conn = new SqlConnection(connStr);
        private string GetDBConnectionString()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }

        public List<SelectListItem> GetBook()
        {
            DataTable dt = new DataTable();
            string sql = @"Select * 
                           FROM [dbo].[BOOK_DATA]";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCodeData(dt);
        }

        /// <summary>
        /// 取得Book_Data的部分資料
        /// </summary>
        /// <returns></returns>
        //public List<SelectListItem> GetBookData(string type)
        //{
        //    DataTable dt = new DataTable();
        //    string sql = @"Select Distinct CodeVal As CodeName, CodeId As CodeID 
        //                   From dbo.CodeTable 
        //                   Where CodeType = @Type";
        //    using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        cmd.Parameters.Add(new SqlParameter("@Type", type));
        //        SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
        //        sqlAdapter.Fill(dt);
        //        conn.Close();
        //    }
        //    return this.MapCodeData(dt);
        //}


        /// <summary>
        /// Maping 代碼資料
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<SelectListItem> MapCodeData(DataTable dt)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["BOOK_ID"].ToString() + '-' + row["BOOK_NAME"].ToString(),
                    Value = row["BOOK_ID"].ToString()
                });
            }
            return result;
        }
    }
}