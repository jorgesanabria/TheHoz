namespace TheHoz.Hoz.Kernel.Contracts
{
    public interface IComponent : ITick
    {
        void Register(IKernel locator);
        void Initialize(IKernel locator);
    }
}