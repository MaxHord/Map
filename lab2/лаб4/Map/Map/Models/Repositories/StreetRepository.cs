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
    class StreetRepository : CreateRepository<Street>
    {

        public StreetRepository(MainContext context) : base(context)
        {
        }

        public override void Add(Street entity)
        {
            _context.Streets.Add(entity);
        }

        public override void Delete(Street entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public override void Edit(Street entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override Street GetById(int id)
        {
            return _context.Streets.Find(id);
        }

        public override List<Street> List()
        {
            return _context.Streets.ToList();
        }

        public override List<Street> List(Expression<Func<Street, bool>> predicate)
        {
            return _context.Streets.Where(predicate).ToList();
        }
    }
}
