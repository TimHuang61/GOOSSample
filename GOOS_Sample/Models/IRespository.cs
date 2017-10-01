using System;
using GOOS_Sample.Models.DataModels;

namespace GOOS_Sample.Models
{
    public interface IRespository<T>
    {
        void Save(T entity);

        T Read(Func<T, bool> precidate);
    }
}