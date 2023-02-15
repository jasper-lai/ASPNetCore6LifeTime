namespace ASPNetCore6LifeTime.Services
{
    using ASPNetCore6LifeTime.Interfaces;

    public class SampleService : ISingletonService, IScopedService, ITransientService
    {
        Guid _currentGUId;
        public SampleService()
        {
            _currentGUId = Guid.NewGuid();
        }
        public Guid GetCurrentGUID()
        {
            return _currentGUId;
        }
    }
}
