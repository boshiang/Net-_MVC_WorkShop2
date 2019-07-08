using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_MVC_WorkShop2.Service
{
    public class BookService
    {
        /// <summary>
        /// 查詢書籍
        /// </summary>
        /// <returns></returns>
        public List<NET_MVC_WorkShop2.Model.BookData> GetBookByCondtioin(NET_MVC_WorkShop2.Model.BookSearchArg arg)
        {
            NET_MVC_WorkShop2.Dao.BookDao bookDao = new Dao.BookDao();
            return bookDao.GetBookByCondtioin(arg);

        }
        /// <summary>
        /// 新增書籍
        /// </summary>
        /// <param name="book"></param>
        /// <returns>書籍編號</returns>
        public int InsertBook(NET_MVC_WorkShop2.Model.BookData book)
        {
            NET_MVC_WorkShop2.Dao.BookDao bookDao = new Dao.BookDao();
            return bookDao.InsertBook(book);
        }
        /// <summary>
        /// 修改書籍
        /// </summary>
        /// <returns>書籍編號</returns>
        public int UpdateBook(NET_MVC_WorkShop2.Model.BookData book)
        {
            NET_MVC_WorkShop2.Dao.BookDao bookDao = new Dao.BookDao();
            return bookDao.UpdateBook(book);
        }
        /// <summary>
        /// 刪除書籍
        /// </summary>

        public int DeleteBookById(string BookId)
        {
            NET_MVC_WorkShop2.Dao.BookDao bookDao = new Dao.BookDao();
            return bookDao.DeleteBookById(BookId);
        }
        /// <summary>
        /// 編輯書籍資訊
        /// </summary>
        public List<NET_MVC_WorkShop2.Model.BookData> UpdateDetail(string BookId)
        {
            NET_MVC_WorkShop2.Dao.BookDao bookDao = new Dao.BookDao();
            return bookDao.UpdateDetail(BookId);
        }
        /// <summary>
        /// Book_Class下拉選單
        /// </summary>
        /// <returns></returns>
        public List<NET_MVC_WorkShop2.Model.BookData> GetBook_Class()
        {
            NET_MVC_WorkShop2.Dao.BookDao bookDao = new Dao.BookDao();
            return bookDao.GetBook_Class();
        }
        /// <summary>
        /// Book_Status下拉選單
        /// </summary>
        /// <returns></returns>
        public List<NET_MVC_WorkShop2.Model.BookData> GetBook_Status()
        {
            NET_MVC_WorkShop2.Dao.BookDao bookDao = new Dao.BookDao();
            return bookDao.GetBook_Status();
        }
        /// <summary>
        /// Book_Keeper下拉選單
        /// </summary>
        /// <returns></returns>
        public List<NET_MVC_WorkShop2.Model.BookData> GetBook_Keeper()
        {
            NET_MVC_WorkShop2.Dao.BookDao bookDao = new Dao.BookDao();
            return bookDao.GetBook_Keeper();
        }
    }
}
