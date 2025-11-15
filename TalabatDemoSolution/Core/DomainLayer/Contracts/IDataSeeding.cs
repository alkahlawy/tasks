
namespace DomainLayer.Contracts
{
    public interface IDataSeeding
    {
        public Task SeedDataAsync();
        public Task SeedIdentityDataAsync();
    }
}
