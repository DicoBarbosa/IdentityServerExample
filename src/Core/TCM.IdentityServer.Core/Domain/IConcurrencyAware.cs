namespace TCM.IdentityServer.Core.Domain
{
    public interface IConcurrencyAware
    {
        string ConcurrencyStamp { get; set; }
    }
}