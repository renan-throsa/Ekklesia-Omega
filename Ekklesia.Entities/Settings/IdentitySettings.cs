using System;

namespace Ekklesia.Entities.Settings
{
    public class IdentitySettings
    {
        public string ConnectionString { get; set; }
        public string SqlDataBase { get; set; }
        public IdentitySettings()
        {
            ConnectionString = String.Empty;
            SqlDataBase = String.Empty;
        }
    }
}
