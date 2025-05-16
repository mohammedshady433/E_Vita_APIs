using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace E_Vita_APIs.Models
{
    public class Financial
    {
        public int Id { get; set; }
        public financialStatus Status { get; set; } // Financial status of the patient
        public SqlMoney Amount { get; set; } // Amount to be paid
        public float Paid_Amount { get; set; } // for spare use 
        public PaymentMethod Method { get; set; } // Payment method used
        [ForeignKey("Patient")]
        public int PatientId { get; set; } // Foreign key to the Patient table
        public DateTime Payment_Date { get; set; } // Date of payment

    }
    public enum financialStatus
    {
        Paid = 0,
        Unpaid = 1,
        PartiallyPaid = 2,
        Hold = 3,
    }
    public enum PaymentMethod
    {
        Cash = 0,
        Card = 1,
        Insurance = 2,
        BankTransfer = 3
    }
}
