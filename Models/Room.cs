namespace E_Vita_APIs.Models
{
    public class Room
    {
        public int ID { get; set; }
        public RoomStatus availablity { get; set; }
        public int Floor { get; set; }
        public string name { get; set; }

    }
    public enum RoomType
    {
        General = 0,
        Private = 1,
        SemiPrivate = 2
    }
    public enum RoomStatus
    {
        Available = 0,
        Occupied = 1,
        UnderMaintenance = 2
    }
}