using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarColorDal : ICarColorDal
    {
        List<CarColor> _carColors;
        public InMemoryCarColorDal()
        {
            _carColors = new List<CarColor>
            {
                new CarColor { CarColorID = 1, CarColorName = "Mavi" },
                new CarColor { CarColorID = 2, CarColorName = "Beyaz" }
            };
        }
        public void Add(CarColor carColor)
        {
            if (!_carColors.Any(cc => cc.CarColorID == carColor.CarColorID))
            {
                _carColors.Add(carColor);
            }
            else
            {
                throw new Exception("Color is already exist");
            }
        }

        public void Delete(CarColor carColor)
        {
            if (!_carColors.Any(cc => cc.CarColorID == carColor.CarColorID))
            {
                CarColor carColorToDelete = _carColors.FirstOrDefault(cc => cc.CarColorID == carColor.CarColorID);
                _carColors.Remove(carColor);
            }
            else
            {
                throw new Exception("Color isn't exist");
            }
        }

        public CarColor Get(Expression<Func<CarColor, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarColor> GetAll()
        {
            return _carColors;
        }

        public List<CarColor> GetAll(Expression<Func<CarColor, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(CarColor carColor)
        {
            if (!_carColors.Any(cc => cc.CarColorID == carColor.CarColorID))
            {
                CarColor carColorToUpdate = _carColors.FirstOrDefault(cc => cc.CarColorID == carColor.CarColorID);
                carColorToUpdate.CarColorName = carColor.CarColorName;
            }
            else
            {
                throw new Exception("Color isn't exist");
            }
        }
    }
    
}
