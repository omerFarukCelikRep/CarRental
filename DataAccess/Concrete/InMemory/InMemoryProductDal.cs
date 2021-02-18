﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Car> _cars;
        public InMemoryProductDal()
        {
            _cars = new List<Car>
            {
                new Car { ID = 1, BrandID = 1, ColorID = 1, ModelYear = 2020, DailyPrice = 80, Description = "Az Yakar Çok Kaçar" },
                new Car { ID = 2, BrandID = 2, ColorID = 1, ModelYear = 2020, DailyPrice = 80, Description = "Az Yakar Çok Kaçar" },
                new Car { ID = 3, BrandID = 2, ColorID = 1, ModelYear = 2020, DailyPrice = 80, Description = "Az Yakar Çok Kaçar" },
                new Car { ID = 4, BrandID = 3, ColorID = 1, ModelYear = 2020, DailyPrice = 80, Description = "Az Yakar Çok Kaçar" },
                new Car { ID = 5, BrandID = 3, ColorID = 1, ModelYear = 2020, DailyPrice = 80, Description = "Az Yakar Çok Kaçar" },
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.FirstOrDefault(c => c.ID == car.ID);
            _cars.Remove(carToDelete);
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
            Car carToUpdate = _cars.FirstOrDefault(c => c.ID == car.ID);
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
