using Ekklesia.Domain.Enums;

namespace Ekklesia.Domain.Entities
{
    public class Income
    {
        public RevenueType Type { get; set; }
        public string Observation { get; set; }

        public Income()
        {
            this.Observation = string.Empty;
        }
    }
}
