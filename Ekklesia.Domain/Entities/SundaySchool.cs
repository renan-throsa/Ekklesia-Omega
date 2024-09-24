namespace Ekklesia.Domain.Entities
{
    public class SundaySchool
    {
        public string Theme { get; set; }
        public string Verse { get; set; }
        public int NumberOfBibles { get; set; }
        public int Visitants { get; set; }

        public SundaySchool()
        {
            this.Theme = string.Empty;
            this.Verse = string.Empty;
        }

    }
}
