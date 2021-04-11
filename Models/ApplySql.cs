using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomework.Models
{
    public class ApplySql : IApplySql
    {
        private readonly MyDbContext context;
        public ApplySql(MyDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Apply> AllApply()
        {
            return context.Applies;
        }

        public IEnumerable<Apply> AllNotSure()
        {
            return context.Applies.Where(a => a.IsSure == false).ToList();
        }

        public IEnumerable<Apply> AllSure()
        {
            return context.Applies.Where(a => a.IsSure == true).ToList();
        }

        public Apply ApplyById(int id)
        {
            return context.Applies.Find(id);
        }

        public void Add(Apply apply)
        {
            context.Applies.Add(apply);
            context.SaveChanges();
        }
        public int getId()
        {
            return context.Applies.Count();
        }
        public Apply Update(Apply up)
        {
            var ap = context.Applies.Attach(up);
            ap.State = EntityState.Modified;
            context.SaveChanges();
            return up;
        }
    }
}
