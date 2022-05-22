﻿using System.ComponentModel.DataAnnotations;


namespace Messanger
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string About { get; set; }
    }
}