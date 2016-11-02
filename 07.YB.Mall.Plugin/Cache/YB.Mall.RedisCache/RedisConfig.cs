namespace YB.Mall.RedisCache
{
    public class RedisConfig
    {
        public RedisConfig()
        {
            this.Prot = 6379;
        }
        public string Host { get; set; }
        public int Prot { get; set; }
    }
}