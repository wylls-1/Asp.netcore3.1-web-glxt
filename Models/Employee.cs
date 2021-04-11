using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomework.Models
{
    public class Employee
    {
        [Required]
        public string EmpId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        // 1-在职，2-兼职，3-试用，4-离职，5-返聘，6-退休; 
        public int State { get; set; } = 1;
        [Required]
        public string WorkStart { get; set; }
        [Required]
        public string Job { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string DepId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Passward { get; set; } = "123456";
        [ForeignKey("DepId")]
        public virtual Department Emp_dep { get; set; }
    }
}
