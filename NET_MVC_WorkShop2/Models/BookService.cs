using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace NET_MVC_WorkShop2.Models
{
    public class BookService
    {
        /// <summary>
        /// 取得DB連線字串
        /// </summary>
        /// <returns></returns>
        private string GetDBConnectionString()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }


        /// <summary>
        /// 查詢書籍
        /// </summary>
        /// <returns></returns>
        public List<Models.BookData> GetBookByCondtioin(Models.BookSearch arg)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT BOOK_CLASS_NAME ,BOOK_NAME ,BOOK_BOUGHT_DATE ,CODE_NAME ,USER_ENAME
                           FROM [dbo].[BOOK_DATA] as da
                           left join [dbo].[BOOK_CLASS] as cl
                           on da.BOOK_CLASS_ID = cl.BOOK_CLASS_ID
                           left join [dbo].[BOOK_CODE] as co
                           on da.BOOK_STATUS = co.CODE_ID
                           left join [dbo].[MEMBER_M] as m
                           on da.BOOK_KEEPER = m.USER_ID
                           Where (da.BOOK_STATUS = co.CODE_ID) AND
                                 (BOOK_NAME LIKE ('%' + @Book_Name + '%')or @Book_Name='') AND
                                 (UPPER(BOOK_CLASS_NAME) LIKE UPPER('%' + @Book_Class_Name + '%')or @Book_Class_Name='') AND
                                 (CODE_NAME LIKE ('%' + @Book_Status + '%')or @Book_Status='') AND
                                 (USER_ENAME LIKE ('%' + @Book_Keeper + '%')or @Book_Keeper='')";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@Book_Name", arg.Book_Name == null ? string.Empty : arg.Book_Name));
                cmd.Parameters.Add(new SqlParameter("@Book_Class_Name", arg.Book_Class_Name == null ? string.Empty : arg.Book_Class_Name));
                cmd.Parameters.Add(new SqlParameter("@Book_Status", arg.Book_Status == null ? string.Empty : arg.Book_Status));
                cmd.Parameters.Add(new SqlParameter("@Book_Keeper", arg.Book_Keeper == null ? string.Empty : arg.Book_Keeper));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapBookDataToList(dt);
        }

        /// <summary>
        /// Book_Class_Name下拉選單
        /// </summary>
        /// <returns></returns>
        public List<Models.BookData> GetBook_Class_Name()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT BOOK_CLASS_NAME
                           FROM [dbo].[BOOK_CLASS] as cl";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            List<Models.BookData> result = new List<BookData>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new BookData()
                {
                    Book_Class_Name = row["BOOK_CLASS_NAME"].ToString()
                });
            }
            return result;
        }
        /// <summary>
        /// Book_Status下拉選單
        /// </summary>
        /// <returns></returns>
        public List<Models.BookData> GetBook_Status()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT CODE_NAME
                           FROM [dbo].[BOOK_CODE] as co";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            List<Models.BookData> result = new List<BookData>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new BookData()
                {
                    Book_Status = row["CODE_NAME"].ToString()
                });
            }
            return result;
        }
        /// <summary>
        /// Book_Keeper下拉選單
        /// </summary>
        /// <returns></returns>
        public List<Models.BookData> GetBook_Keeper()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT USER_ENAME
                           FROM [dbo].[MEMBER_M] as m";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            List<Models.BookData> result = new List<BookData>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new BookData()
                {
                    Book_Keeper = row["USER_ENAME"].ToString()
                });
            }
            return result;
        }

        /// <summary>
        /// Map資料進List
        /// </summary>
        /// <param name="BookData"></param>
        /// <returns></returns>

        private List<Models.BookData> MapBookDataToList(DataTable BookData)
        {
            List<Models.BookData> result = new List<BookData>();
            foreach (DataRow row in BookData.Rows)
            {
                result.Add(new BookData()
                {
                    Book_Class_Name = row["BOOK_CLASS_NAME"].ToString(),
                    Book_Name = row["BOOK_NAME"].ToString(),
                    Book_BoughtDate = row["BOOK_BOUGHT_DATE"].ToString(),
                    Book_Status = row["CODE_NAME"].ToString(),
                    Book_Keeper = row["USER_ENAME"].ToString()
                });
            }
            return result;
        }
    }
}
