﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarColorService : IService
    {
        List<CarColor> GetAll();
    }
}
