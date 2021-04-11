using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebHomework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}



//实践内容2 员工人事调动管理系统
//建立一个员工人事调动管理系统, 编写应用程序完成系统开发。
//1. 建立基本表：
//员工的基本信息表：员工编号、姓名、员工状态（1-在职，2-兼职，3-试用，4-离职，5-返聘，6-退休）、到岗日期、工作岗位、职务、所在部门编号等；
//部门表：部门编号、部门名称等；
//调动信息表：序号、员工编号、调动日期、调入部门、调出部门、调动原因等；
//2. 系统应实现以下主要功能：
//（1）登录查询功能
//     系统管理员登录，浏览信息，查看员工状态、某个员工的调动信息等；
//（2）调动子系统
//     要求：实现工作关系调动，接受调动信息的录入，修改员工基本表中相应信息；
//（3）离退休处理子系统
//     要求：接受离退休信息的录入，修改员工基本表中相应信息；
//（4）系统维护
//     要求：前台提供员工基本信息的备份功能。界面友好，美观，操作方便。




