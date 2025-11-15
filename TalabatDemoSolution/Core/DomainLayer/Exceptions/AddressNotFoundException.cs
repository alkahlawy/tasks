
namespace DomainLayer.Exceptions
{
    public sealed class AddressNotFoundException(string userName) 
        : NotFoundException($"No addresses linked to this username: {userName}")
    {
    }
}
