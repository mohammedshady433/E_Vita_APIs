namespace E_Vita_APIs.Models
{
    public class Encounter
    {
        public int Id { get; set; }
        public DateTime time { get; set; }
        public OUTIN_Patient type { get; set; } // OUTIN_Patient enum
        public string Reason { get; set; }

    }

}
