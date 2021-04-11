using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomework.Models
{
    public class DepartmentSql : IDepartmentSql
    {
        private readonly MyDbContext context;
        public DepartmentSql(MyDbContext context)
        {
            this.context = context;
        }
        public Department Add(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return department;
        }

        public Department Delete(string id)
        {
            Department department = context.Departments.Find(id);
            if (department != null)
            {
                context.Departments.Remove(department);
                context.SaveChanges();
            }
            return department;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return context.Departments;
        }

        public Department GetDepartmentById(string id)
        {
            return context.Departments.Find(id);
        }

        public Department Update(Department updateDepartment)
        {
            var Department = context.Departments.Attach(updateDepartment);
            Department.State = EntityState.Modified;
            context.SaveChanges();
            return updateDepartment;
        }

    }
}
