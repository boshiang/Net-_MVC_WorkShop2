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
        public int Book_ID { get; set; }

        [DisplayName("書名")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Name { get; set; }

        [DisplayName("作者")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Author { get; set; }

        [DisplayName("出版社")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Publisher { get; set; }
        [DisplayName("內容描述")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Note { get; set; }

        [DisplayName("購書日期")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_BoughtDate { get; set; }

        [DisplayName("圖書類別")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Class_Name { get; set; }

        [DisplayName("借閱狀態")]
        public string Book_Status { get; set; }

        [DisplayName("借閱人")]
        public string Book_Keeper { get; set; }
    }
}