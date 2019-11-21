using System;
using TestAppLightpoint.DAL.EF;

namespace TestAppLightpoint.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        EFContext Context { get; }
        void Commit();
    }
}
