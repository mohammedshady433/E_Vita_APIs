using System.ComponentModel.DataAnnotations;

namespace E_Vita_APIs.Models
{
    public class Patient
    {
        int ID { get; set; }
        string Name { get; set; }
        PhoneAttribute Phone { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        OUTIN_Patient Status { get; set; }
        DateTime DateOfBirth { get; set; }
        Gender Gender { get; set; }

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
