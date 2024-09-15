using Ekklesia.Entities.Enums;

namespace Ekkleisa.Business.Models
{
    public class ViewOccasionMemberModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class ViewOccasionModel
    {
        public string Id { get; set; }
        public OccasionType Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ViewOccasionMemberModel Host { get; set; }
        public IList<ViewOccasionMemberModel> Attendees { get; set; }
        public string Place { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; } = string.Empty;
        public int NumberOfConvertions { get; set; }
        public int NumberOfVisitants { get; set; }
        public ViewCultModel? Cult { get; set; }
        public ViewSundaySchoolModel? SundaySchool { get; set; }
    }
}