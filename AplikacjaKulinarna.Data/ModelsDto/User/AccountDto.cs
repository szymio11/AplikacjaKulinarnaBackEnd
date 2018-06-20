using System;

namespace AplikacjaKulinarna.Data.ModelsDto.User
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}