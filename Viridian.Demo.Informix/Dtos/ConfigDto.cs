namespace Viridian.Demo.Informix.Dtos
{
    public class ConfigDto
    {
        public Database Database { get; set; }
    }
    
    public class Database
    {
        public string Host { get; set; }
        public long Port { get; set; }
        public string Db { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}