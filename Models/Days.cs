namespace E_Vita_APIs.Models
{
    public class Days
    {
       
            public int Days_ID { get; set; }
            public string DayName { get; set; }

            // Navigation property for the relationship with Schedule
            public ICollection<Schedule> Schedules { get; set; }
     
    }
}
