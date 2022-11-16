namespace SunriseAutoAPI.DatabaseSettings
{
    public interface IDatabaseSetting
    {
        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
