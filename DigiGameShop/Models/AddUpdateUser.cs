﻿namespace DigiGameShop.Models
{
    public class AddUpdateUser
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool IsEmailConfirmed { get; set; }       
    }
}