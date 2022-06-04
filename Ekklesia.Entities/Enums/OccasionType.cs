using System.ComponentModel;

namespace Ekklesia.Entities.Enums
{
    public enum OccasionType
    {
        [Description("Reunião de Liderança")]
        REUNIAOLIDERANÇA = 1,

        [Description("Reunião de Docência")]
        REUNIAODOCENCIA = 2,

        [Description("Reunião Pedagógica")]
        REUNIAOPEDAGOGICA = 3,

        [Description("Célula")]
        CELL = 4,

        [Description("Batismo")]
        BAPTISM = 5,

        [Description("Atípico")]
        ATYPICAL = 6,

        [Description("Escola Dominical")]
        SUNDAYSCHOOL = 7,

        [Description("Culto")]
        CULT = 8,


    }
}
