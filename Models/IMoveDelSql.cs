using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomework.Models
{
    public interface IMoveDelSql
    {
        IEnumerable<MoveDep> GetAllMoveDeps();
        MoveDep GetMoveDepById(string id);
        MoveDep Add(MoveDep moveDep);
        MoveDep Update(MoveDep updateMoveDep);
        MoveDep Delete(string id);
        IEnumerable<MoveDep> GetMoveDepsByEmpId(string id);
        int CountId();


    }
}
