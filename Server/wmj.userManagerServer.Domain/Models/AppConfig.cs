namespace wmj.userManagerServer.Domain.Models
{
    public class AppConfig
    {
        public JWtSettings Jwt { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
    }
    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }
    public class JWtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ExpireTime { get; set; }
        public int TokenKeepTime { get; set; }
    }
}
