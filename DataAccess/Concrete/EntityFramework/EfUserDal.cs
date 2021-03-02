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
    public class EfUserDal : IUserDal
    {
        public void Add(User entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var addedUser = context.Entry(entity);
                addedUser.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(User entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var deletedUser = context.Entry(entity);
                deletedUser.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<User>().SingleOrDefault(filter);
            }
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return filter == null ? context.Set<User>().ToList() : context.Set<User>().Where(filter).ToList();
            }
        }

        public void Update(User entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var updatedUser = context.Entry(entity);
                updatedUser.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
