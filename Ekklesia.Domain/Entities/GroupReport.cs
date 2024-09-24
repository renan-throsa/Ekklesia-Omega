namespace Ekklesia.Domain.Entities
{
    public class GroupReport : Report
    {
        public int NumberOfExternalCults { get; set; }
        public int NumberOfCells { get; set; }
        public int NumberOfBaptizeds { get; set; }
        public int NumberOfCoordinationMeetings { get; set; }
    }
}
