namespace ServiceLifeTime.Services
{
    public interface IScopedService
    {
        string GetGuid();
    }

    public class ScopedService : IScopedService
    {
        private Guid _guid;
        public ScopedService()
        {
            _guid = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return _guid.ToString();
        }
    }
}
