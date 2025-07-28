using System.ComponentModel.DataAnnotations;

namespace E_Vita_APIs.Models
{
    public class SharedNote
    {
        [Key]
        public int Note_ID { get; set; }
        public string Content { get; set; }
        public int practitionerID { get; set; }
        public string practitioner_type { get; set; }
    }
}
