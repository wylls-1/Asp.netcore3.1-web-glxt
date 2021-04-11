using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHomework.Models;

namespace WebHomework.Controllers
{
    [Authorize(Roles ="user")]
    public class UserController:Controller
    {
        private readonly IEmployeeSql _employee;
        private readonly IDepartmentSql _departmentSql;
        private readonly IMoveDelSql _moveDelSql;
        private readonly IApplySql _applySql;

        public UserController(IEmployeeSql employee, IDepartmentSql departmentSql, IMoveDelSql moveDelSql,IApplySql applySql)
        {
            _employee = employee;
            _departmentSql = departmentSql;
            _moveDelSql = moveDelSql;
            _applySql = applySql;
        }
    
        public IActionResult Index(string? id)
        {
            if (string.IsNullOrEmpty(id))
                return Redirect("/home/index");
             var employee = _employee.GetEmployeeById(id);
            if (employee != null&& HttpContext.User.Identity.Name == employee.UserName)    
                return View(employee);
            
            return Redirect("/home/login");
        }

        public string Departure()
        {
            string res = Request.Form["name1"];
            string id = Request.Form["id"];
            if (_employee.GetEmployeeById(id).State == 4)
            {
                return "4";
            }
            if (_employee.GetEmployeeById(id).State == 6)
            {
                return "6";
            }
            Apply apply = new Apply();
            apply.Id = _applySql.getId() + 1;
            apply.EmpId = id;
            apply.Reason = res;
            apply.IsSure = false;
            apply.IsAgree = false;
            apply.StateChange = 4;
            _applySql.Add(apply);
            return "ok";
        }
        public string Retired()
        {
            string res = Request.Form["name2"];
            string id = Request.Form["id"];
            if (_employee.GetEmployeeById(id).State == 4)
            {
                return "4";
            }
            if (_employee.GetEmployeeById(id).State == 6)
            {
                return "6";
            }
            Apply apply = new Apply();
            apply.Id = _applySql.getId() + 1;
            apply.EmpId = id;
            apply.Reason = res;
            apply.IsSure = false;
            apply.IsAgree = false;
            apply.StateChange = 6;
            _applySql.Add(apply);
            return "ok";
        }
        public string Move()
        {
            string res = Request.Form["name3"];
            string id = Request.Form["id"];
            if (_employee.GetEmployeeById(id).State == 4)
            {
                return "4";
            }
            if (_employee.GetEmployeeById(id).State == 6)
            {
                return "6";
            }
            if (_departmentSql.GetDepartmentById(res) == null)
                return "not ok";
            Apply apply = new Apply();
            apply.Id = _applySql.getId() + 1;
            apply.EmpId = id;
            apply.Reason = res;
            apply.IsSure = false;
            apply.IsAgree = false;
            apply.StateChange = _employee.GetEmployeeById(id).State;
            _applySql.Add(apply);
            return "ok";
        }
    }
}
