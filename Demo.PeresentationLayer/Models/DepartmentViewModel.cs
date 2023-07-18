using Demo.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Demo.PeresentationLayer.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Code is Required")]
        public int Code { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "Max Length is 50 Chars")]
        public string Name { get; set; }
        //Nvigational Prooerty[Many]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
