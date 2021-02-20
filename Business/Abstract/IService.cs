using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IService<T> where T : class, IEntity, new()
    {
        List<T> GetAll();
    }
}
