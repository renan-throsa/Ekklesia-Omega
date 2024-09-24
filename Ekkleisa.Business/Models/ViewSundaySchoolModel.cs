namespace Ekklesia.Application.Models
{
    public class ViewSundaySchoolModel
    {
        public string Theme { get; set; }
        public string Verse { get; set; }
        public int NumberOfBibles { get; set; }
        public int Visitants { get; set; }

        public ViewSundaySchoolModel()
        {
            this.Theme = string.Empty;
            this.Verse = string.Empty;
        }
    }
}
