using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EnFiveSales.DTO
{
    public class UserDTO
    {
        [JsonProperty("Active")]
        public bool Active { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("DeviceID")]
        public string DeviceId { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("StoreName")]
        public string StoreName { get; set; }

        [JsonProperty("StoreUserID")]
        public long StoreUserId { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("PhoneNo")]
        public string PhoneNo { get; set; }

        [JsonProperty("Categories")]
        public List<CategoryDTO> Categories { get; set; }
    }
}