using System;

namespace TheHoz.Hoz.Kernel.Entity
{
    public class KernelException : Exception
    {
        public KernelException(string message) : base(message)
        {
        }
    }
}
