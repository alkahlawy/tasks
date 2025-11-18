using Shared.DTOs.IdentityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.OrderDtos
{
    public class OrderToReturnDto
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; } = null!;
        public DateTimeOffset OrderDate { get; set; }
        public AddressDto Address { get; set; } = null!;
        public string DelviryMethod { get; set; }=null!;
        public string OrderStatus { get; set; } = null!;
        public ICollection<OrderItemDto> Items { get; set; } = [];
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
