using System;
using System.Text.Json.Serialization;
using Domain.Enums;

namespace Application.DTOs.Account
{
    public class AuthResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string IpAddress { get; set; }
        public Roles Role { get; set; }
        public bool IsVerified { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string JWToken { get; set; }

        [JsonIgnore] public string RefreshToken { get; set; }
    }
}