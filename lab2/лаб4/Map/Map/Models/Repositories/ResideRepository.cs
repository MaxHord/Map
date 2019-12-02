using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Map.Models.DB;

namespace Map.Models.Repositories
{
    class ResideRepository : CreateRepository<Reside>
    {

        public ResideRepository(MainContext context) : base(context)
        {
        }

        public override void Add(Reside entity)
        {
            _context.Resides.Add(entity);
        }

        public override void Delete(Reside entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public override void Edit(Reside entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override Reside GetById(int id)
        {
            return _context.Resides.Find(id);
        }

        public override List<Reside> List()
        {
            return _context.Resides.ToList();
        }

        public override List<Reside> List(Expression<Func<Reside, bool>> predicate)
        {
            return _context.Resides.Where(predicate).ToList();
        }
    }
}
