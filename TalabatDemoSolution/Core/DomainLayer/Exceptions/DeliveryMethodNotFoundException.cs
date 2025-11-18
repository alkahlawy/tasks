using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Exceptions
{
    public sealed class DeliveryMethodNotFoundException(int id)
                    : NotFoundException($"There is no delivery method with id {id}")
    {
    }
}
