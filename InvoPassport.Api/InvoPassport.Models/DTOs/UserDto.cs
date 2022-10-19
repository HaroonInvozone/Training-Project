using System.ComponentModel.DataAnnotations;

namespace InvoPassport.Model.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? lastName { get; set; }
        public string? JobTitle { get; set; }
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public bool? IsRevoke { get; set; }
        public bool? IsVerified { get; set; }
        public string? PassId { get; set; }
        public DateTime? PassportExpiry { get; set; }
    }
}
