using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Range(10000,20000)]
        public int Salary { get; set; }
        [Required]
        public string Phone { get; set; }   

    }
}
