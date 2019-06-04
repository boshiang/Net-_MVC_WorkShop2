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
            ViewBag.data = "123";
            return View();
        }

        /// <summary>
        /// 書籍資料查詢
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        public JsonResult Index(Models.BookSearch arg)
        {
            Models.BookService BookService = new Models.BookService();
            ViewBag.SearchResult = BookService.GetBookByCondtioin(arg);
            var result = BookService.GetBookByCondtioin(arg);
            //return Json(result);
            return Json(result);
        }

        [HttpPost()]
        public JsonResult Search(Models.BookSearch arg)
        {
            Models.BookService BookService = new Models.BookService();
            //ViewBag.SearchResult = BookService.GetBookByCondtioin(arg);
            var result = BookService.GetBookByCondtioin(arg);
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        [HttpGet()]
        public JsonResult GetBook_Class_Name()
        {
            Models.BookService BookService = new Models.BookService();
            var result = BookService.GetBook_Class_Name();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet()]
        public JsonResult GetBook_Status()
        {
            Models.BookService BookService = new Models.BookService();
            var result = BookService.GetBook_Status();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet()]
        public JsonResult GetBook_Keeper()
        {
            Models.BookService BookService = new Models.BookService();
            var result = BookService.GetBook_Keeper();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}