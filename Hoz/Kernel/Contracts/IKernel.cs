namespace TheHoz.Hoz.Kernel.Contracts
{
    public interface IKernel
    {
        void Register(string key, IComponent component);
        IComponent Resolve<TReturn>(string key) where TReturn : class, IComponent;
    }
}
