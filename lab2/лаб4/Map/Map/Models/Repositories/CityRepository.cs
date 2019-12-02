using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Map.Models.Repositories;
using Map.Models.DB;

namespace Map.Models.Repositories
{
    class CityRepository : CreateRepository<City>
    {

        public CityRepository(MainContext context) : base(context)
        {
        }

        public override void Add(City entity)
        {
            _context.Cities.Add(entity);
        }

        public override void Delete(City entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public override void Edit(City entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override City GetById(int id)
        {
            return _context.Cities.Find(id);
        }

        public override List<City> List()
        {
            return _context.Cities.ToList();
        }

        public override List<City> List(Expression<Func<City, bool>> predicate)
        {
            return _context.Cities.Where(predicate).ToList();
        }
    }
}
