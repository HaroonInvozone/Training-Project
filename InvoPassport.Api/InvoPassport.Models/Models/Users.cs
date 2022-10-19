using InvoPassport.Models.Models;

namespace InvoPassport.Model.Models
{
    public  class Users
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; } = string.Empty;
        public string? lastName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? JobTitle { get; set; } = string.Empty;
        public string? Role { get; set; } = string.Empty;
        public bool? IsRevoke { get; set; }
        public bool? IsVerified { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? PassId { get; set; }  
        public DateTime? PassportExpiry { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public List<Result>? Result { get; set; } 
    }
}
