using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomework.Models
{
    public class Apply
    {
        public int Id { get; set; }
        public bool IsSure { get; set; } = false;
        public string EmpId { get; set; }
        public bool IsAgree { get; set; }
        public int StateChange { get; set; }
        public string Reason { get; set; }
    }
}
