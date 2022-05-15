using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;

namespace Ekklesia.Entities.DTOs
{
    public class IncomeDTO
    {
        public RevenueType Type { get; set; }
        public string Observation { get; set; }

        public IncomeDTO()
        {
            this.Observation = string.Empty;
        }

        public Income ToEntity()
        {
            return new Income()
            {
                Type = Type,
                Observation = Observation,
            };
        }
    }
}
