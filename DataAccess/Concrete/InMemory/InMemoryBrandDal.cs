using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;

        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand { BrandID = 1, BrandName = "Toyota" },
                new Brand { BrandID = 2, BrandName = "Mercedes" },
                new Brand { BrandID = 3, BrandName = "Mitsubishi" }
            };
        }

        public void Add(Brand brand)
        {
            if (!_brands.Any(b => b.BrandID == brand.BrandID))
            {
                _brands.Add(brand);
            }
            else
            {
                throw new Exception("Brand is already exist");
            }
        }

        public void Delete(Brand brand)
        {
            if (!_brands.Any(b => b.BrandID == brand.BrandID))
            {
                Brand brandToDelete = _brands.FirstOrDefault(b => b.BrandID == brand.BrandID);
                _brands.Remove(brandToDelete);
            }
            else
            {
                throw new Exception("Brand isn't exist");
            }
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public void Update(Brand brand)
        {
            if (!_brands.Any(b => b.BrandID == brand.BrandID))
            {
                Brand brandToUpdate = _brands.FirstOrDefault(b => b.BrandID == brand.BrandID);
                brandToUpdate.BrandName = brand.BrandName;
            }
            else
            {
                throw new Exception("Brand isn't exist");
            }
        }
    }
}
