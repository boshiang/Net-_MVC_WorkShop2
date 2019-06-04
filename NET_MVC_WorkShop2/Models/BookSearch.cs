using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NET_MVC_WorkShop2.Models
{
    public class BookSearch
    {
        [DisplayName("書名")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Name { get; set; }

        [DisplayName("圖書類別")]
        [Required(ErrorMessage = "此欄位必填")]
        public string Book_Class_Name { get; set; }

        [DisplayName("借閱人")]
        public string Book_Keeper { get; set; }

        [DisplayName("借閱狀態")]
        public string Book_Status { get; set; }
    }
}