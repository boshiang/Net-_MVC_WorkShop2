using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NET_MVC_WorkShop2.Models
{
    public class BookData
    {
        public string Book_ID { get; set; }

        [DisplayName("書籍分類")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Class_ID { get; set; }

        [DisplayName("書名")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Name { get; set; }

        [DisplayName("作者")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Author { get; set; }

        [DisplayName("出版社")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Publisher { get; set; }

        [DisplayName("內容簡介")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Note { get; set; }

        [DisplayName("購書日期")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_BoughtDate { get; set; }

        [DisplayName("圖書類別")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Class_Name { get; set; }

        [DisplayName("借閱狀態")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Status { get; set; }

        [DisplayName("書籍狀態")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Status_Name { get; set; }

        [DisplayName("借閱人")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Keeper { get; set; }

        [DisplayName("借閱人")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Keeper_EName { get; set; }
    }
}