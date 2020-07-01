namespace EnFiveSales.SaleEntities
{
    public class PushTokenEntities : BaseEntity
    {
        public string message { get; set; }
        public string DevicePushToken { get; set; }
        public string DeviceType { get; set; }
    }
}