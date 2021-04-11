using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebHomework.Models
{
    public class LoginPolicy : AuthorizationHandler<NameAuthorizationRequirement>, IAuthorizationRequirement
    {
        private readonly IEmployeeSql _employee;
        public LoginPolicy(IEmployeeSql employeeSql)
        {
            _employee = employeeSql;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NameAuthorizationRequirement requirement)
        {
            if(context.User != null && context.User.HasClaim(c => c.Type==ClaimTypes.Sid))
            {
                string sid = context.User.FindFirst(c => c.Type == ClaimTypes.Sid).Value;
                var em = _employee.GetEmployeeById(sid);
                if(em!=null) context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
     }
}
