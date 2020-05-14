using System;
using System.Threading.Tasks;
using TCM.IdentityServer.Core;
using TCM.IdentityServer.Core.Repositories;

namespace TCM.IdentityServer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentityServerContext _context;

        public IUserRepository Users { get; set; }
        public IClaimRepository Claims { get; set; }
        public ILoginRepository Logins { get; set; }
        public ILoginRepository Secrets { get; set; }
        

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
