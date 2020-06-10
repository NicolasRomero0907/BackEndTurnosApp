using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repositorios.Interfaces
{
    interface IRepo<T> where T: Modelo.BaseEntity
    {        
        void Add(T item);
        void Remove(int id);
        void Update(T item);
        T FindByID(int id);
        IEnumerable<T> FindAll();
}
}
