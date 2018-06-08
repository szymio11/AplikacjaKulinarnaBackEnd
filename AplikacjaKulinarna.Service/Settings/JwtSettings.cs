namespace AplikacjaKulinarna.Service.Settings
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public long ExpiryMinutes { get; set; }
        public string Issuer { get; set; }
    }
}