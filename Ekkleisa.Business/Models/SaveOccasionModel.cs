using Ekklesia.Domain.Enums;

namespace Ekklesia.Application.Models
{
    public class SaveOccasionMemberModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class SaveOccasionModel
    {
        public string Id { get; set; }
        public OccasionType Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public SaveOccasionMemberModel? Host { get; set; }
        public ISet<SaveOccasionMemberModel>? Attendees { get; set; }
        public string Place { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; } = string.Empty;
        public int NumberOfConvertions { get; set; }
        public int NumberOfVisitants { get; set; }
        public SaveCultModel? Cult { get; set; }
        public SaveSundaySchoolModel? SundaySchool { get; set; }
    }
}
