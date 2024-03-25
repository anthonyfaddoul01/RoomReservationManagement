﻿namespace RoomManagement2.Api.Settings
{
    public class JwtSettings
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Secret { get; set; }

        public int ExpirationInDays { get; set; }
    }
}
