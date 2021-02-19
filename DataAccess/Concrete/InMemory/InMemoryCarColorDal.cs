using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new CarColor { ColorID = 1, ColorName = "Mavi" },
                new CarColor { ColorID = 2, ColorName = "Beyaz" }
            };
        }
        public void Add(CarColor carColor)
        {
            if (!_carColors.Any(cc => cc.ColorID == carColor.ColorID))
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
            if (!_carColors.Any(cc => cc.ColorID == carColor.ColorID))
            {
                CarColor carColorToDelete = _carColors.FirstOrDefault(cc => cc.ColorID == carColor.ColorID);
                _carColors.Remove(carColor);
            }
            else
            {
                throw new Exception("Color isn't exist");
            }
        }

        public List<CarColor> GetAll()
        {
            return _carColors;
        }

        public void Update(CarColor carColor)
        {
            if (!_carColors.Any(cc => cc.ColorID == carColor.ColorID))
            {
                CarColor carColorToUpdate = _carColors.FirstOrDefault(cc => cc.ColorID == carColor.ColorID);
                carColorToUpdate.ColorName = carColor.ColorName;
            }
            else
            {
                throw new Exception("Color isn't exist");
            }
        }
    }
    
}
