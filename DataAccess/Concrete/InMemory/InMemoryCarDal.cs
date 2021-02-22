using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { CarID = 1, BrandID = 1, CarColorID = 1, ModelYear = 2020, DailyPrice = 70, Description = "Az Yakar Çok Kaçar" },
                new Car { CarID = 2, BrandID = 2, CarColorID = 2, ModelYear = 2021, DailyPrice = 80, Description = "Az Yakar Çok Kaçar" },
                new Car { CarID = 3, BrandID = 2, CarColorID = 1, ModelYear = 2020, DailyPrice = 90, Description = "Az Yakar Çok Kaçar" },
                new Car { CarID = 4, BrandID = 3, CarColorID = 2, ModelYear = 2021, DailyPrice = 95, Description = "Az Yakar Çok Kaçar" },
                new Car { CarID = 5, BrandID = 3, CarColorID = 1, ModelYear = 2020, DailyPrice = 120, Description = "Az Yakar Çok Kaçar" },
            };
        }
        public void Add(Car car)
        {
            if (!_cars.Any(c => c.CarID == car.CarID))
            {
                _cars.Add(car); 
            }
            else
            {
                throw new Exception("Car is already exist");
            }
        }

        public void Delete(Car car)
        {
            if (!_cars.Any(c => c.CarID == car.CarID))
            {
                Car carToDelete = _cars.FirstOrDefault(c => c.CarID == car.CarID);
                _cars.Remove(carToDelete); 
            }
            else
            {
                throw new Exception("Car isn't exist");
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByBrandID(int brandID)
        {
            return _cars.Where(c => c.BrandID == brandID).ToList();
        }

        public void Update(Car car)
        {
            if (!_cars.Any(c => c.CarID == car.CarID))
            {
                Car carToUpdate = _cars.FirstOrDefault(c => c.CarID == car.CarID);
                carToUpdate.BrandID = car.BrandID;
                carToUpdate.CarColorID = car.CarColorID;
                carToUpdate.ModelYear = car.ModelYear;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description; 
            }
            else
            {
                throw new Exception("Car isn't exist");
            }
        }
    }
}
