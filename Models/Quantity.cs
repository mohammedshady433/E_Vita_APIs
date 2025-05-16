using System.ComponentModel.DataAnnotations.Schema;

namespace E_Vita_APIs.Models
{
    public class Quantity
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        [ForeignKey("Observation")]
        public int ObservationID { get; set; }
    }
}
