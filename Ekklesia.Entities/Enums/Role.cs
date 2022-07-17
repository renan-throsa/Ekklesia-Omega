using System.ComponentModel;

namespace Ekklesia.Entities.Entities
{
    public enum Role
    {
        [Description("Membro")]
        MEMBRO = 1,
        [Description("Líder")]
        LIDER = 2,
        [Description("Professor(a)")]
        PROFESSOR = 3,
        [Description("Não definido(a)")]
        INDEFINIDO = 4,
    }

}
