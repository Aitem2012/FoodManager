﻿namespace FoodManager.Application.DTO.JWT
{
    public class JWTData
    {
        public const string Data = "JWTConfigurations";
        public TimeSpan TokenLifeTime { get; set; }

        public string SecretKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }
    }
}
