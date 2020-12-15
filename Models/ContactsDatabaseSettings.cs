namespace ContactsApi.Models
{
    public class ContactsDatabaseSettings : IContactsDatabaseSettings
    {
        public string TableName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
 
    public interface IContactsDatabaseSettings
    {
        string TableName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}