using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebHomework.Models;

namespace WebHomework.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController:Controller
    {
        private readonly IEmployeeSql _employeeSql;
        private readonly IDepartmentSql _departmentSql;
        private readonly IMoveDelSql _moveDelSql;
        private readonly IApplySql _applySql;
        private Dictionary<object, IEnumerable<object>> pairs = new Dictionary<object, IEnumerable<object>>();
       
        public AdminController(IEmployeeSql employeeSql, IDepartmentSql departmentSql, IMoveDelSql moveDelSql,IApplySql applySql)
        {
            _employeeSql = employeeSql;
            _departmentSql = departmentSql;
            _moveDelSql = moveDelSql;
            _applySql = applySql;
        }


        public IActionResult BackUp()
        {
            string path1 = AppDomain.CurrentDomain.BaseDirectory + "employee.txt";
            string path2 = AppDomain.CurrentDomain.BaseDirectory + "department.txt";
            string path3 = AppDomain.CurrentDomain.BaseDirectory + "movedep.txt";
            string path4 = AppDomain.CurrentDomain.BaseDirectory + "apply.txt";
            //判断文件是否存在，没有则创建。
            if (!System.IO.File.Exists(path1))
            {
                FileStream stream = System.IO.File.Create(path1);
                stream.Close();
                stream.Dispose();
            }
            if (!System.IO.File.Exists(path2))
            {
                FileStream stream = System.IO.File.Create(path2);
                stream.Close();
                stream.Dispose();
            }
            if (!System.IO.File.Exists(path3))
            {
                FileStream stream = System.IO.File.Create(path3);
                stream.Close();
                stream.Dispose();
            }
            if (!System.IO.File.Exists(path4))
            {
                FileStream stream = System.IO.File.Create(path4);
                stream.Close();
                stream.Dispose();
            }

            //写入日志
            using (StreamWriter writer = new StreamWriter(path1, false))
            {
                var ems = _employeeSql.GetAllEmployees();
                foreach(var i in ems)
                    writer.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i.EmpId, i.Name, i.DepId,i.State,i.UserName,i.Passward);
            }
            using (StreamWriter writer = new StreamWriter(path2, false))
            {
                var k = _departmentSql.GetAllDepartments();
                foreach (var i in k)
                    writer.WriteLine("{0}\t{1}", i.Name, i.DepId);
            }
            using (StreamWriter writer = new StreamWriter(path3, false))
            {
                var k = _moveDelSql.GetAllMoveDeps();
                foreach (var i in k)
                    writer.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i.Id,i.EmpId,i.Day,i.DepForm,i.DepTo,i.Reason);
            }
            using (StreamWriter writer = new StreamWriter(path4, false))
            {
                var k = _applySql.AllApply();
                foreach (var i in k)
                    writer.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",i.Id, i.EmpId,i.StateChange,i.Reason ,i.IsSure,i.IsAgree);
            }

            return Content("<script>alert('备份成功！'); history.go(-1);</script>", "text/html;charset=utf-8");
        }

        public IActionResult Index(Dictionary<object, IEnumerable<object>>? p)
        {
            if (HttpContext.User.Identity.Name == "admin")
            {
                //ViewData["Name"] = "admin"; 
                if (p.Count()!=0&&p!=null) return View(p);
                pairs.Clear();
                pairs.Add("emp",_employeeSql.GetAllEmployees());
                pairs.Add("dep", _departmentSql.GetAllDepartments());
                pairs.Add("moveDep", _moveDelSql.GetAllMoveDeps());
                pairs.Add("apply", _applySql.AllApply());
                return View(pairs);
            }
             return Redirect("/home/login");
        }
        public string Find()
        {
            string id = Request.Form["text"];
            Employee em = _employeeSql.GetEmployeeById(id);
            var md = _moveDelSql.GetMoveDepsByEmpId(id);
            if (em == null) return null;
            string s= em.EmpId + " " + em.Name + " " + em.State + " " + em.WorkStart + " " + em.Job + " " + em.Position + " " + em.DepId;
            foreach(var i in md)
            {
                s += " " + i.Id;
                s += " " + i.EmpId;
                s += " " + i.Day;
                s += " " + i.DepForm; 
                s += " " + i.DepTo;
                s += " " + i.Reason;
            }
            return s;
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee em)
        {
            em.EmpId = Request.Form["EmpId"];
            em.Name = Request.Form["Name"];
            if(Request.Form["State"]!="")
            em.State = int.Parse(Request.Form["State"]);
            em.WorkStart = Request.Form["WorkStart"];
            em.Job = Request.Form["Job"];
            em.Position = Request.Form["Position"];
            em.DepId = Request.Form["DepId"];
            em.UserName = Request.Form["UserName"];
            em.Passward = Request.Form["Passward"];
            if (_employeeSql.GetEmployeeById(em.EmpId) == null && _departmentSql.GetDepartmentById(em.DepId) != null && em.State > 0 && em.State < 7)
            {
                _employeeSql.Add(em);
                pairs.Clear();
                pairs.Add("emp", _employeeSql.GetAllEmployees());
                pairs.Add("dep", _departmentSql.GetAllDepartments());
                pairs.Add("moveDep", _moveDelSql.GetAllMoveDeps());
                pairs.Add("apply", _applySql.AllApply());
            }
            else return Content("<script>alert('添加失败！'); history.go(-1);</script>","text/html;charset=utf-8");

            return View("Index",pairs);
        }
        [HttpGet]
        public IActionResult EditorEmployee(string id)
        {
            var em = _employeeSql.GetEmployeeById(id);
            return View(em);
        }

        [HttpPost]
        public IActionResult EditorEmployee(Employee em)
        {
            if(ModelState.IsValid)
            {
                if (_departmentSql.GetDepartmentById(em.DepId) != null)
                {
                    
                    if (em.DepId!=_employeeSql.GetEmployeeById(em.EmpId).DepId)                    _moveDelSql.Add(new MoveDep
                    {
                        Id = (_moveDelSql.CountId() + 1).ToString(),
                        EmpId = em.EmpId,
                        Day = DateTime.Now.ToShortDateString().ToString(),
                        DepForm = _employeeSql.GetEmployeeById(em.EmpId).DepId,
                        DepTo = em.DepId,
                        Reason = "不知道"
                    });
                    Employee em1 = em;
                    _employeeSql.Update(em1);
                    pairs.Clear();
                    pairs.Add("emp", _employeeSql.GetAllEmployees());
                    pairs.Add("dep", _departmentSql.GetAllDepartments());
                    pairs.Add("moveDep", _moveDelSql.GetAllMoveDeps());
                    pairs.Add("apply", _applySql.AllApply());
                    return View("index", pairs);
                }
            }
            return Content("<script>alert('修改失败'); history.go(-1);</script>", "text/html;charset=utf-8");
        }
        public IActionResult ApplySure(int id,bool flag)
        {
            Apply ap = _applySql.ApplyById(id);
            ap.IsSure = true;
            if(flag)
            {
                ap.IsAgree = true;
                var em=_employeeSql.GetEmployeeById(ap.EmpId);
                if(ap.StateChange==4)
                    em.State = 4;                
                else if (ap.StateChange == 6)
                    em.State = 6;
                else
                {
                    _moveDelSql.Add(new MoveDep
                    {
                        Id = (_moveDelSql.CountId() + 1).ToString(),
                        EmpId = em.EmpId,
                        Day = DateTime.Now.ToShortDateString().ToString(),
                        DepForm=em.DepId,
                        DepTo=ap.Reason,
                        Reason="buzhidao"
                }) ;
                    em.DepId = ap.Reason;
                }
                _employeeSql.Update(em);
            }
            else
            {
                ap.IsAgree = false;
            }
            _applySql.Update(ap);
            pairs.Clear();
            pairs.Add("emp", _employeeSql.GetAllEmployees());
            pairs.Add("dep", _departmentSql.GetAllDepartments());
            pairs.Add("moveDep", _moveDelSql.GetAllMoveDeps());
            pairs.Add("apply", _applySql.AllApply());
            return View("index", pairs);
        }
    }
}
