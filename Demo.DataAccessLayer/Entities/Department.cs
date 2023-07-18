using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public int Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }= DateTime.Now;

        //Nvigational Prooerty[Many]
        public ICollection<Employee> Employees { get; set; }=new HashSet<Employee>();
    }
}
