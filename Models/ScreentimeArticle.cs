using System;
using System.ComponentModel.DataAnnotations;

namespace E_Vita_APIs.Models
{
    public class ScreentimeArticle
    {
        [Key]
        public int Chat_ID { get; set; }
        public string Response_Text { get; set; }
        public DateTime Time { get; set; }
    }
}
