using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using PagedList;

namespace NET_MVC_WorkShop2.Controllers
{
    public class BookDataController : Controller
    {
        Models.CodeService codeService = new Models.CodeService();
        //Models.BookData BookData = new Models.BookData();

        // GET: BookData
        [HttpGet()]
        public ActionResult Index()
        {
            ViewBag.book = this.codeService.GetBook();
            return View();
        }

        /// <summary>
        /// 書籍資料新增
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        public JsonResult Insert(Models.BookData book)
        {
            Models.BookService BookService = new Models.BookService();
            var result = BookService.InsertBook(book);
            TempData["message"] = "存檔成功";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 書籍資料修改
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        public JsonResult Update(Models.BookData book)
        {
            Models.BookService BookService = new Models.BookService();
            var result = BookService.UpdateBook(book);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 書籍資料刪除
        /// </summary>
        /// <param name="BookId"></param>
        /// <returns></returns>
        [HttpPost()]
        public JsonResult Delete(string BookId)
        {
            Models.BookService BookService = new Models.BookService();
            var result = BookService.DeleteBookById(BookId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 書籍資料查詢
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        public JsonResult Search(Models.BookSearch arg)
        {
            Models.BookService BookService = new Models.BookService();
            var result = BookService.GetBookByCondtioin(arg);
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// UpdateDetail修改資訊
        /// </summary>
        /// <param name="BookId"></param>
        /// <returns></returns>
        [HttpPost()]
        public JsonResult UpdateDetail(string BookId)
        {
            Models.BookService BookService = new Models.BookService();
            var result = BookService.UpdateDetail(BookId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        

        /// <summary>
        /// GetBook_Class_Name下拉選單
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public JsonResult GetBook_Class()
        {
            Models.BookService BookService = new Models.BookService();
            var result = BookService.GetBook_Class();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// GetBook_Status下拉選單
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public JsonResult GetBook_Status()
        {
            Models.BookService BookService = new Models.BookService();
            var result = BookService.GetBook_Status();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// GetBook_Keeper下拉選單
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public JsonResult GetBook_Keeper()
        {
            Models.BookService BookService = new Models.BookService();
            var result = BookService.GetBook_Keeper();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}