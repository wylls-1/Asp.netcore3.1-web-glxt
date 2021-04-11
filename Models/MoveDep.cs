using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomework.Models
{
    public class MoveDep
    {
        public string Id { get; set; }
        public string EmpId { get; set; }
        public string Day { get; set; } 

        public string DepForm { get; set; }

        public string DepTo { get; set; }
        public string Reason { get; set; }
        [ForeignKey("DepForm")] 
        [Required]   
        public virtual Department MoveDep_form { get; set; }
        [ForeignKey("DepTo")]   
        [Required]
        public virtual Department MoveDep_to { get; set; }
    }
}
