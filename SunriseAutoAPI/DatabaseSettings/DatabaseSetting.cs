namespace SunriseAutoAPI.DatabaseSettings
{
    public class DatabaseSetting : IDatabaseSetting
    {
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
