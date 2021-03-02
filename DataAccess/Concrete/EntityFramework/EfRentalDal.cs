using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : IRentalDal
    {
        public void Add(Rental entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var addedRental = context.Entry(entity);
                addedRental.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Rental entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var deletedRental = context.Entry(entity);
                deletedRental.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Rental Get(Expression<Func<Rental, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<Rental>().SingleOrDefault(filter);
            }
        }

        public List<Rental> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return filter == null ? context.Set<Rental>().ToList() : context.Set<Rental>().Where(filter).ToList();
            }
        }

        public void Update(Rental entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var updatedRental = context.Entry(entity);
                updatedRental.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
