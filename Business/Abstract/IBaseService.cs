using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBaseService <T>
    {
        List<T> GetAll();
        List<T> GetById(int Id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
