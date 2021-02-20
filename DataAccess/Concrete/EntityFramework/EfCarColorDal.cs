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
    public class EfCarColorDal : ICarColorDal
    {
        public void Add(CarColor entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var addedCarColor = context.Entry(entity);
                addedCarColor.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(CarColor entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var deletedCarColor = context.Entry(entity);
                deletedCarColor.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public CarColor Get(Expression<Func<CarColor, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<CarColor>().SingleOrDefault(filter);
            }
        }

        public List<CarColor> GetAll(Expression<Func<CarColor, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return filter == null ? context.Set<CarColor>().ToList() : context.Set<CarColor>().Where(filter).ToList();
            }
        }

        public void Update(CarColor entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var updatedCarColor = context.Entry(entity);
                updatedCarColor.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
