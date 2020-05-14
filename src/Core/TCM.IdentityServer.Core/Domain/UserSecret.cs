using System;
using System.ComponentModel.DataAnnotations;

namespace TCM.IdentityServer.Core.Domain
{
    public class UserSecret : IConcurrencyAware
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Secret { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }

        [ConcurrencyCheck]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
    }
}