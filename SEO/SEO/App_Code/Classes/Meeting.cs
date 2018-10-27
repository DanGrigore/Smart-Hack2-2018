using System;

public class Meeting
{
    public int Id { get; set; }
    public string ManagerId { get; set; }
    public int RoomId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}