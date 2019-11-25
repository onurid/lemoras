namespace Lemoras.Remora.Core.Interfaces
{
    public interface IBaseServiceFactory : IBaseTServiceFactory
    {
        IWorkContextService GetWorkContextService();
    }

    public interface IBaseTServiceFactory
    {
        TService GetService<TService>() where TService : class;
    }
}
