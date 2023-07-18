using Demo.DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;

namespace Demo.PeresentationLayer.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required !")]
        [MaxLength(50, ErrorMessage = "Max Length is 50 Chars")]
        [MinLength(5, ErrorMessage = "Min Length is 5 Chars")]

        public string Name { get; set; }

        [Range(20, 30, ErrorMessage = "Age Must Be Between 20 And 30")]
        public int Age { get; set; }

        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{4,10}$"
                        , ErrorMessage = "Address Must Be Like 123-Street-city-country")]

        public string Addrees { get; set; }

        [DataType(DataType.Currency)]
        [Range(4000, 8000)]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int? DepartmentId { get; set; } //ForeignKey (Allow Null)

        //Nvigational Prooerty[one]
        public Department Department { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }

    }
}
