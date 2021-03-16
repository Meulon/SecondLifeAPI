using SecondLife.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SecondLife.Repositories.Repositories
{
    public interface IAnnonceRepository : IRepository<Annonce>
    {
    }

    public interface IRepository<T>
    {
        List<T> All(Expression<Func<T, bool>> condition);
        T One(Expression<Func<T, bool>> condition);
        T Add(T annonce);
        bool Exists(T annonce);
        void Update(T updatedObject);
        bool Delete(int id);
        T Get(int id);
    }
}
