using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomework.Models
{
    public interface IDepartmentSql
    {
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartmentById(string id);
        Department Add(Department department);
        Department Update(Department updateDepartment);
        Department Delete(string id);
    }
}
