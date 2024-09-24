using Ekklesia.Domain.Enums;

namespace Ekklesia.Domain.Entities
{
    public class Cult
    {
        public int NumberOfPeople { get; set; }
        public string KeyVerse { get; set; }
        public CultType CultType { get; set; }
        public bool Internal { get; set; }

        public Cult()
        {
            this.KeyVerse = string.Empty;
        }
    }
}
