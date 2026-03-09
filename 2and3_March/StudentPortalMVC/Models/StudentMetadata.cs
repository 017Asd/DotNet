using System.ComponentModel.DataAnnotations;

namespace StudentPortalMVC.Models
{
	public class StudentMetadata
	{
		[Required(ErrorMessage = "Student name is required")]
		[StringLength(100)]
		public string FullName { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Enter a valid email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Phone number is required")]
		[RegularExpression(@"^\d{10}$", ErrorMessage = "Phone must be 10 digits")]
		public string Phone { get; set; }

		[Required]
		public string Status { get; set; }

		[Required]
		public DateOnly JoinDate { get; set; }
	}
}