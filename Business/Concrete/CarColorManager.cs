using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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

        public IResult Add(CarColor entity)
        {
            _carColorDal.Add(entity);
            return new SuccessResult(Messages.CarColorAdded);
        }

        public IResult Delete(CarColor entity)
        {
            _carColorDal.Delete(entity);
            return new SuccessResult(Messages.CarColorDeleted);
        }

        public IDataResult<List<CarColor>> GetAll()
        {
            return new SuccessDataResult<List<CarColor>>(_carColorDal.GetAll(), Messages.CarColorsListed);
        }

        public IResult Update(CarColor entity)
        {
            _carColorDal.Update(entity);
            return new SuccessResult(Messages.CarColorUpdated);
        }
    }
}
