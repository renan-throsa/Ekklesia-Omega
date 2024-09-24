using System.ComponentModel;

namespace Ekklesia.Domain.Enums
{
    public enum TransactionType
    {
        [Description("Dízimo")]
        DIZIMO = 1,
        [Description("Oferta")]
        OFERTA = 2,
        [Description("Despesa")]
        DESPESA = 3,       
    }
    
}
