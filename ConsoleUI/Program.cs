using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CarColorManager carColorManager = new CarColorManager(new EfCarColorDal());
            CarManager carManager = new CarManager(new EfCarDal());

            EfCarDal efCarDal = new EfCarDal();
            efCarDal.Add(new Car
            {
                BrandID = 3,
                CarColorID = 1,
                ModelYear = 2021,
                DailyPrice = 80,
                Description = "Çok Yakar"
            });

            var carList = carManager.GetAll().Join(brandManager.GetAll(),
                cm => cm.BrandID,
                bm => bm.BrandID,
                (cm, bm) => new
                {
                    cm.CarID,
                    bm.BrandName,
                    cm.CarColorID,
                    cm.ModelYear,
                    cm.DailyPrice,
                    cm.Description
                }).Join(carColorManager.GetAll(),
                cl => cl.CarColorID,
                cc => cc.CarColorID,
                (cl, cc) => new
                {
                    cl.CarID,
                    cl.BrandName,
                    cc.CarColorName,
                    cl.ModelYear,
                    cl.DailyPrice,
                    cl.Description
                }).ToList();

            foreach (var car in carList)
            {
                Console.WriteLine($"{car.CarID} {car.BrandName} {car.CarColorName} {car.ModelYear} {car.DailyPrice} {car.Description}");
            }
        }
    }
}
