using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomework.Models
{
    public class EmployeeSql : IEmployeeSql
    {
        private readonly MyDbContext context;
        public EmployeeSql(MyDbContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(string id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.Employees;
        }

        public Employee GetEmployeeById(string id)
        {
           return context.Employees.Find(id);
        }

        public Employee Update(Employee updateEmployee)
        {
            var Employee = context.Employees.Attach(updateEmployee);
            Employee.State = EntityState.Modified;
            context.SaveChanges();
            return updateEmployee;
        }
    }
}
