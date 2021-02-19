using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            CarColorManager carColorManager = new CarColorManager(new InMemoryCarColorDal());
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (Car car in carManager.GetAll())
            {
                string brand = brandManager.GetAll().Single(b => b.BrandID == car.BrandID).BrandName;
                string carColor = carColorManager.GetAll().Single(cc => cc.ColorID == car.CarColorID).ColorName;
                Console.WriteLine(car.ID + " " + brand + " " + carColor + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Description);
            }
        }
    }
}
