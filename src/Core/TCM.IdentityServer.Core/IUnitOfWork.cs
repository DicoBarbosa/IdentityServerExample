using System;
using System.Threading.Tasks;
using TCM.IdentityServer.Core.Repositories;

namespace TCM.IdentityServer.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IClaimRepository Claims { get; }
        ILoginRepository Logins { get; }
        ILoginRepository Secrets { get; }
        Task<int> Complete();
    }
}
