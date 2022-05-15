namespace Ekklesia.Entities.Settings
{
    public class DataBaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public DataBaseSettings()
        {
            ConnectionString = string.Empty;
            DatabaseName = string.Empty;
        }
    }
}
