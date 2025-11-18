using System.ComponentModel.DataAnnotations.Schema;


namespace DomainLayer.Models.OrderModels
{
    public class Order:BaseEntity<Guid>
    {

        public Order()
        {
            
        }

        public Order(string userEmail,
                     ICollection<OrderItem> items,
                     OrderAddress address,
                     DeliveryMethod deliveryMethod,
                     decimal subTotal)
        {
            UserEmail = userEmail;
            Items = items;
            Address = address;
            DeliveryMethod = deliveryMethod;
            SubTotal = subTotal;
        }

        public string UserEmail { get; set; } = null!;

        public ICollection<OrderItem> Items { get; set; } = [];
        public OrderAddress Address { get; set; } = null!;
        public DeliveryMethod DeliveryMethod { get; set; } = null!;
        public decimal SubTotal { get; set; }
        public int DeliveryMethodId { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        [NotMapped]
        public decimal Total { get => SubTotal + DeliveryMethod.Price; }

    }
}
