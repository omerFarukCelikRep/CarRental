using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarColor : IEntity
    {
        public int CarColorID { get; set; }
        public string CarColorName { get; set; }
    }
}
