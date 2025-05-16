using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Vita_APIs.Models
{
    public class Patient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public PhoneAttribute Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public OUTIN_Patient Status { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Practitioner> Practitioners { get; set; } = new List<Practitioner>();
        [ForeignKey("WardRound")]
        public int WardRoundId { get; set; } // Foreign key to the WardRound table


    }
    public enum OUTIN_Patient
    {
        Out_Patient=0,
        In_Patient = 1
    }
    public enum Gender
    {
        Male= 0,
        Female = 1
    }
}
