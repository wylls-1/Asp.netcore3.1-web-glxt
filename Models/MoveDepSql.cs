using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomework.Models
{
    public class MoveDepSql : IMoveDelSql
    {
        private readonly MyDbContext context;
        public MoveDepSql(MyDbContext context)
        {
            this.context = context;
        }
        public MoveDep Add(MoveDep move)
        {
            context.MoveDeps.Add(move);
            context.SaveChanges();
            return move;
        }

        public MoveDep Delete(string id)
        {
            MoveDep department = context.MoveDeps.Find(id);
            if (department != null)
            {
                context.MoveDeps.Remove(department);
                context.SaveChanges();
            }
            return department;
        }

        public IEnumerable<MoveDep> GetAllMoveDeps()
        {
            return context.MoveDeps;
        }

        public MoveDep GetMoveDepById(string id)
        {
            return context.MoveDeps.Find(id);
        }

        public MoveDep Update(MoveDep updateMoveDep)
        {
            var MoveDep = context.MoveDeps.Attach(updateMoveDep);
            MoveDep.State = EntityState.Modified;
            context.SaveChanges();
            return updateMoveDep;
        }

        public IEnumerable<MoveDep> GetMoveDepsByEmpId(string id)
        {
            return context.MoveDeps.Where(a => a.EmpId == id).ToList();
        }
        public int CountId()
        {
            return context.MoveDeps.Count();
        }
    }
}
