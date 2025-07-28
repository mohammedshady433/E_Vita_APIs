using System.ComponentModel.DataAnnotations;

namespace E_Vita_APIs.Models
{
    public class Service
    {
        [Key]
        public int Service_ID { get; set; }
        public string ServiceName { get; set; }
        public int PracticionerID { get; set; }
    }
}
