namespace Ekklesia.Application.Models
{
    public class SaveSundaySchoolModel
    {
        public string Theme { get; set; }
        public string Verse { get; set; }
        public int NumberOfBibles { get; set; }
        public int Visitants { get; set; }

        public SaveSundaySchoolModel()
        {
            Theme = string.Empty;
            Verse = string.Empty;
        }
    }
}
