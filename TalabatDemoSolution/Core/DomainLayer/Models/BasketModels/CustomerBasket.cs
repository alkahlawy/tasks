
namespace DomainLayer.Models.BasketModels
{
    public class CustomerBasket
    {
        public string Id { get; set; } // GUID : Created by the client [Frontend]
        public ICollection<BasketItem> BasketItems { get; set; } 
    }
}
