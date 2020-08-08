namespace EnFiveSales.SaleEntities
{
    public class PushTokenEntities : BaseEntityRequest
    {
        public string message { get; set; }
        public string DevicePushToken { get; set; }
        public string DeviceType { get; set; }
    }
}