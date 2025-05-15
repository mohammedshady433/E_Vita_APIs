namespace E_Vita_APIs.Models
{
    public class Discharge
    {
        public DateTime Date { get; set; } // Date of discharge
        public TimeOnly When { get; set; } // Time of discharge
        public string Note { get; set; } // Note from the discharge
        public DischargeType DischargeType { get; set; } // e.g. Normal, Against Medical Advice, etc.
    }
    public enum DischargeType
    {
         Regular_Discharge,
         Transfer_to_Another_Facility
        ,Against_Medical_Advice
    }
}
