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
    public class EfCustomerDal : ICustomerDal
    {
        public void Add(Customer entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var addedCustomer = context.Entry(entity);
                addedCustomer.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Customer entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var deletedCustomer = context.Entry(entity);
                deletedCustomer.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<Customer>().SingleOrDefault(filter);
            }
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return filter == null ? context.Set<Customer>().ToList() : context.Set<Customer>().Where(filter).ToList();
            }
        }

        public void Update(Customer entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var updatedCustomer = context.Entry(entity);
                updatedCustomer.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
