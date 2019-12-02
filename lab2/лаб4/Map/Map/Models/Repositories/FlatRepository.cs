using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using Map.Models.DB;

namespace Map.Models.Repositories
{
    class FlatRepository : CreateRepository<Flat>
    {
        public FlatRepository(MainContext context) : base(context)
        {
        }

        public override void Add(Flat entity)
        {
            _context.Flats.Add(entity);
        }

        public override void Delete(Flat entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public override void Edit(Flat entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override Flat GetById(int id)
        {
            return _context.Flats.Find(id);
        }

        public override List<Flat> List()
        {
            return _context.Flats.ToList();
        }

        public override List<Flat> List(Expression<Func<Flat, bool>> predicate)
        {
            return _context.Flats.Where(predicate).ToList();
        }
    }
}
