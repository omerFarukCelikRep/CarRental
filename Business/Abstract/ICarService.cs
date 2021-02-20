using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : IService<Car>
    {
        List<Car> GetAllByBrandId(int brandId);
        List<Car> GetAllByCarColorId(int carColorId);
        List<Car> GetCarsByDailyPrice(decimal min, decimal max);
    }
}
