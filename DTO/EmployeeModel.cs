using System.ComponentModel.DataAnnotations;

namespace Api.DTO
{
    public class EmployeeModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Range(10000, 20000)]
        public int Salary { get; set; }
        [Required]
        [DataType(dataType:DataType.Password)]
        public string Phone { get; set; }
    }

}
