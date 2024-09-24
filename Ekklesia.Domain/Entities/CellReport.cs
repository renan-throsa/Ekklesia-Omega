namespace Ekklesia.Domain.Entities
{
    public class CellReport : Report
    {
        public int NumberOfCoordenationMeatings { get; set; }
        public int NumberOfVisitants { get; set; }
        public int NumberOfEvangelisms { get; set; }
        public int NumberOfBoardMembers { get; set; }
    }
}
