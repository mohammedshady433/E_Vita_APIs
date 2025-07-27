namespace E_Vita_APIs.Models
{
    public class Attendance
    {
            public int ID { get; set; }
            public DateTime Attend_Time { get; set; }
            public DateTime Leave_Time { get; set; }
            public DateTime Date { get; set; }

            // Foreign key to users
            public int UserID { get; set; }
            public User User { get; set; }
    }
}
