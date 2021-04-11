using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomework.Models
{
    public interface IEmployeeSql
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(string id);
        Employee Add(Employee employee);
        Employee Update(Employee updateEmployee);
        Employee Delete(string id);
    }
}
