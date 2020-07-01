using System;

namespace EnFiveSales.DTO
{
    public class UserDTO
    {
        public int StoreUserID { get; set; }
        public string StoreName { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DeviceID { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}