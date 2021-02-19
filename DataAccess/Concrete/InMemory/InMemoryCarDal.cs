﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Car { ID = 1, BrandID = 1, CarColorID = 1, ModelYear = 2020, DailyPrice = 70, Description = "Az Yakar Çok Kaçar" },
                new Car { ID = 2, BrandID = 2, CarColorID = 2, ModelYear = 2021, DailyPrice = 80, Description = "Az Yakar Çok Kaçar" },
                new Car { ID = 3, BrandID = 2, CarColorID = 1, ModelYear = 2020, DailyPrice = 90, Description = "Az Yakar Çok Kaçar" },
                new Car { ID = 4, BrandID = 3, CarColorID = 2, ModelYear = 2021, DailyPrice = 95, Description = "Az Yakar Çok Kaçar" },
                new Car { ID = 5, BrandID = 3, CarColorID = 1, ModelYear = 2020, DailyPrice = 120, Description = "Az Yakar Çok Kaçar" },
            };
        }
        public void Add(Car car)
        {
            if (!_cars.Any(c => c.ID == car.ID))
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
            if (!_cars.Any(c => c.ID == car.ID))
            {
                Car carToDelete = _cars.FirstOrDefault(c => c.ID == car.ID);
                _cars.Remove(carToDelete); 
            }
            else
            {
                throw new Exception("Car isn't exist");
            }
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetCarsByBrandID(int brandID)
        {
            return _cars.Where(c => c.BrandID == brandID).ToList();
        }

        public void Update(Car car)
        {
            if (!_cars.Any(c => c.ID == car.ID))
            {
                Car carToUpdate = _cars.FirstOrDefault(c => c.ID == car.ID);
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
