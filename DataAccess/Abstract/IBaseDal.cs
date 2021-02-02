using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBaseDal <T>
    {
        List<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        T GetById(int itemId);
    }
}
