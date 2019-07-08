using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_MVC_WorkShop2.Dao
{
    public class BookDao
    {
        /// <summary>
        /// 取得DB連線字串
        /// </summary>
        /// <returns></returns>
        private string GetDBConnectionString()
        {
            return NET_MVC_WorkShop2.Common.ConfigTool.GetDBConnectionString("DBConn");
        }


        /// <summary>
        /// 查詢書籍
        /// </summary>
        /// <returns></returns>
        public List<NET_MVC_WorkShop2.Model.BookData> GetBookByCondtioin(NET_MVC_WorkShop2.Model.BookSearchArg arg)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT BOOK_ID, BOOK_CLASS_NAME ,BOOK_NAME ,BOOK_BOUGHT_DATE ,CODE_NAME ,USER_ENAME
                           FROM [dbo].[BOOK_DATA] as da

                           left join [dbo].[BOOK_CLASS] as cl
                           on da.BOOK_CLASS_ID = cl.BOOK_CLASS_ID
                           left join [dbo].[BOOK_CODE] as co
                           on da.BOOK_STATUS = co.CODE_ID
                           left join [dbo].[MEMBER_M] as m
                           on da.BOOK_KEEPER = m.USER_ID

                           Where (da.BOOK_STATUS = co.CODE_ID) AND
                                 (da.BOOK_ID = @Book_ID OR @Book_ID='') AND
                                 (BOOK_NAME LIKE ('%' + @Book_Name + '%')or @Book_Name='') AND
                                 (UPPER(da.BOOK_CLASS_ID) LIKE UPPER('%' + @Book_Class_Name + '%')or @Book_Class_Name='') AND
                                 (BOOK_STATUS LIKE ('%' + @Book_Status + '%')or @Book_Status='') AND
                                 (BOOK_KEEPER LIKE ('%' + @Book_Keeper + '%')or @Book_Keeper='')
                                 ORDER BY BOOK_BOUGHT_DATE DESC";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@Book_ID", arg.Book_ID == null ? string.Empty : arg.Book_ID));
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
        /// 新增書籍
        /// </summary>
        /// <param name="book"></param>
        /// <returns>書籍編號</returns>
        public int InsertBook(NET_MVC_WorkShop2.Model.BookData book)
        {
            string sql = @" INSERT INTO [dbo].[BOOK_DATA]
                         (
        	                 BOOK_NAME, BOOK_AUTHOR, BOOK_PUBLISHER, BOOK_NOTE, BOOK_BOUGHT_DATE, BOOK_CLASS_ID , BOOK_STATUS, BOOK_KEEPER
                         )
                        VALUES
                        (
        	                 @Book_Name,@Book_Author, @Book_Publisher, @Book_Note, @Book_BoughtDate, @Book_Class_ID , @Book_Status, @Book_Keeper
                        )
                        Select SCOPE_IDENTITY()";
            int BookId;
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@Book_Name", book.Book_Name));
                cmd.Parameters.Add(new SqlParameter("@Book_Author", book.Book_Author));
                cmd.Parameters.Add(new SqlParameter("@Book_Publisher", book.Book_Publisher));
                cmd.Parameters.Add(new SqlParameter("@Book_Note", book.Book_Note));
                cmd.Parameters.Add(new SqlParameter("@Book_BoughtDate", book.Book_BoughtDate));
                cmd.Parameters.Add(new SqlParameter("@Book_Class_ID", book.Book_Class_ID));
                cmd.Parameters.Add(new SqlParameter("@Book_Status", book.Book_Status));
                cmd.Parameters.Add(new SqlParameter("@Book_Keeper", book.Book_Keeper));
                BookId = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }
            return BookId;
        }
        /// <summary>
        /// 修改書籍
        /// </summary>
        /// <returns>書籍編號</returns>
        public int UpdateBook(NET_MVC_WorkShop2.Model.BookData book)
        {
            string sql = @" UPDATE [dbo].[BOOK_DATA]
                            SET BOOK_NAME = @Book_Name, BOOK_AUTHOR = @Book_Author, BOOK_PUBLISHER = @Book_Publisher, BOOK_NOTE = @Book_Note, 
                                BOOK_BOUGHT_DATE = @Book_BoughtDate, BOOK_CLASS_ID = @Book_Class_ID, BOOK_STATUS = @Book_Status, BOOK_KEEPER = @Book_Keeper
                            WHERE BOOK_ID = @Book_ID";
            int BookID;
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@Book_ID", book.Book_ID));
                cmd.Parameters.Add(new SqlParameter("@Book_Name", book.Book_Name));
                cmd.Parameters.Add(new SqlParameter("@Book_Author", book.Book_Author));
                cmd.Parameters.Add(new SqlParameter("@Book_Publisher", book.Book_Publisher));
                cmd.Parameters.Add(new SqlParameter("@Book_Note", book.Book_Note));
                cmd.Parameters.Add(new SqlParameter("@Book_BoughtDate", book.Book_BoughtDate));
                cmd.Parameters.Add(new SqlParameter("@Book_Class_ID", book.Book_Class_ID));
                cmd.Parameters.Add(new SqlParameter("@Book_Status", book.Book_Status));
                cmd.Parameters.Add(new SqlParameter("@Book_Keeper", book.Book_Keeper));
                BookID = (int)(cmd.ExecuteNonQuery());
                conn.Close();
            }
            return BookID;
        }
        /// <summary>
        /// 刪除書籍
        /// </summary>

        public int DeleteBookById(string BookId)
        {

            string sql = "Delete FROM [dbo].[BOOK_DATA] Where Book_ID=@Book_ID";
            int BookID;
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@Book_ID", BookId));
                BookID = (int)(cmd.ExecuteNonQuery());
                conn.Close();
            }
            return BookID;
        }

        /// <summary>
        /// 編輯書籍資訊
        /// </summary>
        public List<NET_MVC_WorkShop2.Model.BookData> UpdateDetail(string BookId)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT BOOK_ID , BOOK_NAME ,BOOK_AUTHOR , BOOK_PUBLISHER , BOOK_NOTE ,BOOK_BOUGHT_DATE , da.BOOK_CLASS_ID , CODE_ID ,USER_ID
                           FROM [dbo].[BOOK_DATA] as da

                           left join [dbo].[BOOK_CLASS] as cl
                           on da.BOOK_CLASS_ID = cl.BOOK_CLASS_ID
                           left join [dbo].[BOOK_CODE] as co
                           on da.BOOK_STATUS = co.CODE_ID
                           left join [dbo].[MEMBER_M] as m
                           on da.BOOK_KEEPER = m.USER_ID

                           Where (da.BOOK_STATUS = co.CODE_ID) AND
                                 (da.BOOK_ID = @Book_ID OR @Book_ID='') AND
                                 Book_ID=@Book_ID";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@Book_ID", BookId));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapBookDataToListUpdate(dt);
        }

        /// <summary>
        /// Book_Class下拉選單
        /// </summary>
        /// <returns></returns>
        public List<NET_MVC_WorkShop2.Model.BookData> GetBook_Class()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT *
                           FROM [dbo].[BOOK_CLASS] as cl";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            List< NET_MVC_WorkShop2.Model.BookData> result = new List<NET_MVC_WorkShop2.Model.BookData>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new NET_MVC_WorkShop2.Model.BookData()
                {
                    Book_Class_ID = row["Book_Class_ID"].ToString(),
                    Book_Class_Name = row["BOOK_CLASS_NAME"].ToString()
                });
            }
            return result;
        }
        /// <summary>
        /// Book_Status下拉選單
        /// </summary>
        /// <returns></returns>
        public List<NET_MVC_WorkShop2.Model.BookData> GetBook_Status()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT *
                           FROM [dbo].[BOOK_CODE] as co";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            List< NET_MVC_WorkShop2.Model.BookData> result = new List<NET_MVC_WorkShop2.Model.BookData>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new NET_MVC_WorkShop2.Model.BookData()
                {
                    Book_Status = row["CODE_ID"].ToString(),
                    Book_Status_Name = row["CODE_NAME"].ToString()
                });
            }
            return result;
        }
        /// <summary>
        /// Book_Keeper下拉選單
        /// </summary>
        /// <returns></returns>
        public List<NET_MVC_WorkShop2.Model.BookData> GetBook_Keeper()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT *
                           FROM [dbo].[MEMBER_M] as m";


            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            List< NET_MVC_WorkShop2.Model.BookData> result = new List<NET_MVC_WorkShop2.Model.BookData>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new NET_MVC_WorkShop2.Model.BookData()
                {
                    Book_Keeper = row["USER_ID"].ToString(),
                    Book_Keeper_EName = row["USER_ENAME"].ToString()
                });
            }
            return result;
        }



        /// <summary>
        /// Map資料進List
        /// </summary>
        /// <param name="BookData"></param>
        /// <returns></returns>

        private List<NET_MVC_WorkShop2.Model.BookData> MapBookDataToList(DataTable BookData)
        {
            List< NET_MVC_WorkShop2.Model.BookData> result = new List<NET_MVC_WorkShop2.Model.BookData>();
            foreach (DataRow row in BookData.Rows)
            {
                result.Add(new NET_MVC_WorkShop2.Model.BookData()
                {
                    Book_ID = row["Book_ID"].ToString(),
                    Book_Class_Name = row["BOOK_CLASS_NAME"].ToString(),
                    Book_Name = row["BOOK_NAME"].ToString(),
                    Book_BoughtDate = Convert.ToDateTime(row["BOOK_BOUGHT_DATE"]).ToString("yyyy/MM/dd"),
                    Book_Status_Name = row["CODE_NAME"].ToString(),
                    Book_Keeper_EName = row["USER_ENAME"].ToString()
                });
            }
            return result;
        }

        /// <summary>
        /// Map資料進Update
        /// </summary>
        /// <param name="BookData"></param>
        /// <returns></returns>

        private List<NET_MVC_WorkShop2.Model.BookData> MapBookDataToListUpdate(DataTable BookData)
        {
            List< NET_MVC_WorkShop2.Model.BookData> result = new List<NET_MVC_WorkShop2.Model.BookData>();
            foreach (DataRow row in BookData.Rows)
            {
                result.Add(new NET_MVC_WorkShop2.Model.BookData()
                {
                    Book_ID = row["BOOK_ID"].ToString(),
                    Book_Name = row["BOOK_NAME"].ToString(),
                    Book_Author = row["BOOK_AUTHOR"].ToString(),
                    Book_Publisher = row["BOOK_PUBLISHER"].ToString(),
                    Book_Note = row["BOOK_NOTE"].ToString(),
                    Book_BoughtDate = Convert.ToDateTime(row["BOOK_BOUGHT_DATE"]).ToString("yyyy/MM/dd"),
                    Book_Class_ID = row["BOOK_CLASS_ID"].ToString(),
                    Book_Status = row["CODE_ID"].ToString(),
                    Book_Keeper = row["USER_ID"].ToString()
                });
            }
            return result;
        }
    }
}
