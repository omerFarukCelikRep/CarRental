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

            var carList = carManager.GetAll().Join(brandManager.GetAll(),
                cm => cm.BrandID,
                bm => bm.BrandID,
                (cm, bm) => new { cm.ID, bm.BrandName, cm.CarColorID, cm.ModelYear, cm.DailyPrice, cm.Description }).Join(carColorManager.GetAll(),
                cl => cl.CarColorID,
                ccm => ccm.ColorID,
                (cl, ccm) => new { cl.ID, cl.BrandName, ccm.ColorName, cl.ModelYear, cl.DailyPrice, cl.Description });

            //foreach (Car car in carManager.GetAll())
            //{
            //    string brand = brandManager.GetAll().Single(b => b.BrandID == car.BrandID).BrandName;
            //    string carColor = carColorManager.GetAll().Single(cc => cc.ColorID == car.CarColorID).ColorName;
            //    Console.WriteLine(car.ID + " " + brand + " " + carColor + " " + car.ModelYear + " " + car.DailyPrice + " " + car.Description);
            //}

            foreach (var car in carList)
            {
                Console.WriteLine($"{car.ID} {car.BrandName} {car.ColorName} {car.ModelYear} {car.DailyPrice} {car.Description}");
            }
        }
    }
}
