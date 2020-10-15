using System.ComponentModel.DataAnnotations;

namespace ContactForm.Models
{
    public class ContactUsViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Provide a valid email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNo { get; set; }

        public string ContactPurpose { get; set; }
        public string ContactPurposeText { get; set; }

        public string Message { get; set; }
    }
}