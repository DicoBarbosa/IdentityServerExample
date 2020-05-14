using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TCM.IdentityServer.Core.Domain.CustomValidation;

namespace TCM.IdentityServer.Core.Domain
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Subject { get; set; }

        [MaxLength(200)]
        public string UserName { get; set; }

        [MaxLength(200)]
        public string Password { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(11)]
        [RegularExpression("[0-9]{11}")]
        [CPF]
        public string CPF { get; set; }

        [MaxLength(14)]
        public string CNPJ { get; set; }

        [Required]
        public bool Active { get; set; }

        public bool IsCPFVerified { get; set; }
        
        public bool IsCNPJVerified { get; set; }

        [MaxLength(200)]
        public string SecurityCode { get; set; }

        public DateTime SecurityCodeExpirationDate { get; set; }

        [ConcurrencyCheck]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        public ICollection<UserClaim> Claims { get; set; }

        public ICollection<UserLogin> Logins { get; set; }

        public ICollection<UserSecret> Secrets { get; set; }

    }
}
