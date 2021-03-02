using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            if (entity.DailyPrice > 0)
            {
                using (CarRentalContext context = new CarRentalContext())
                {
                    var addedCar = context.Entry(entity);
                    addedCar.State = EntityState.Added;
                    context.SaveChanges();
                } 
            }
            else
            {
                throw new Exception("Daily Price must bigger than zero");
            }
        }

        public void Delete(Car entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var deletedCar = context.Entry(entity);
                deletedCar.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = context.Cars.Join(context.Brands,
                    c => c.BrandID,
                    b => b.BrandID,
                    (c, b) => new
                    {
                        CarID = c.CarID,
                        BrandName = b.BrandName,
                        CarColorID = c.CarColorID,
                        ModelYear = c.ModelYear,
                        DailyPrice = c.DailyPrice,
                        Description = c.Description
                    }).Join(context.CarColors,
                    cb => cb.CarColorID,
                    cc => cc.CarColorID,
                    (cb,cc) => new CarDetailDto
                    {
                        CarID = cb.CarID,
                        BrandName = cb.BrandName,
                        CarColorName = cc.CarColorName,
                        ModelYear = cb.ModelYear,
                        DailyPrice = cb.DailyPrice,
                        Description = cb.Description
                    });

                return result.ToList();
            }
        }

        public void Update(Car entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var updatedCar = context.Entry(entity);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
