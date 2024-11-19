using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public DateOnly BirthDate { get; set; }


    }
}
