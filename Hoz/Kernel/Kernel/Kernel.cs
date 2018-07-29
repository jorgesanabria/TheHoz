using System.Collections.Generic;
using TheHoz.Hoz.Kernel.Contracts;

namespace TheHoz.Hoz.Kernel.Kernel
{
    public class Kernel : IKernel, ITick
    {
        protected IDictionary<string, IComponent> Components;
        public Kernel()
        {
            Components = new Dictionary<string, IComponent>();
        }
        public virtual void Register(string key, IComponent component)
        {
            Components[key] = component;
        }
        public virtual IComponent Resolve<TReturn>(string key) where TReturn : class, IComponent
        {
            if (!Components.ContainsKey(key))
                throw new KernelException($"'{key}' not found");
            return Components[key] as TReturn;
        }
        public virtual void Tick()
        {
            foreach (var component in Components) component.Value.Tick();
        }
        public virtual void Initialize()
        {
            foreach (var component in Components) component.Value.Initialize(this);
        }
    }
}
