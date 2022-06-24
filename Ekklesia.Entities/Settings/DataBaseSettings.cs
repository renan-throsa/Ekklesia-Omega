namespace Ekklesia.Entities.Settings
{
    public class DataBaseSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string NoSqlDataBase { get; set; }

        public DataBaseSettings()
        {
            ConnectionString = string.Empty;
            Database = string.Empty;
            NoSqlDataBase = string.Empty;
        }
    }
}
