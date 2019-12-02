﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Map.Models.DB;

namespace Map.Models.Repositories
{
    class ResidentRepository : CreateRepository<Resident>
    {
        public ResidentRepository(MainContext context) : base(context)
        {
        }

        public override void Add(Resident entity)
        {
            _context.Residents.Add(entity);
        }

        public override void Delete(Resident entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public override void Edit(Resident entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override Resident GetById(int id)
        {
            return _context.Residents.Find(id);
        }

        public override List<Resident> List()
        {
            return _context.Residents.ToList();
        }

        public override List<Resident> List(Expression<Func<Resident, bool>> predicate)
        {
            return _context.Residents.Where(predicate).ToList();
        }
    }
}
