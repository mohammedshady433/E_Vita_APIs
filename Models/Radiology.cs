namespace E_Vita_APIs.Models
{
    public class Radiology
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public byte[]? Photo { get; set; }  // This stores the image as binary
        public string Note { get; set; }

    }
}
