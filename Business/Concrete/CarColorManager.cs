using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarColorManager : ICarColorService
    {
        ICarColorDal _carColorDal;

        public CarColorManager(ICarColorDal carColorDal)
        {
            _carColorDal = carColorDal;
        }

        public List<CarColor> GetAll()
        {
            return _carColorDal.GetAll();
        }
    }
}
