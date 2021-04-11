using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomework.Models
{
    public interface IApplySql
    {
        public IEnumerable<Apply> AllApply();
        public IEnumerable<Apply> AllNotSure();
        public IEnumerable<Apply> AllSure();
        public Apply ApplyById(int id);
        public void Add(Apply apply);
        public int getId();
        public Apply Update(Apply up);

    }
}
