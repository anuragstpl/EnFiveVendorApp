using EnFiveSales.DTO;

namespace EnFiveSales.SaleEntities
{
    public class RegisterEntity : BaseEntityRequest
    {
        public UserDTO UserInfo { get; set; }
    }
}