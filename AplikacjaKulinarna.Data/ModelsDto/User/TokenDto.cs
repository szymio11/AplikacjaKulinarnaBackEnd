namespace AplikacjaKulinarna.Data.ModelsDto.User
{
    public class TokenDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public long Expires { get; set; }  
    }
}