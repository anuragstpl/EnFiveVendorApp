using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Request
{
    public class UpdatePushTokenRequest : BaseEntityRequest
    {
        [JsonProperty("DevicePushToken")]
        public string DevicePushToken { get; set; }
       
        [JsonProperty("DeviceType")]
        public string DeviceType { get; set; }
    }
}
