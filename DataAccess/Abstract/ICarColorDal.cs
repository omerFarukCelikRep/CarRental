using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarColorDal : IDal
    {
        List<CarColor> GetAll();
        void Add(CarColor car);
        void Update(CarColor car);
        void Delete(CarColor car);
    }
}
