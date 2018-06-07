using System.Collections.Generic;

namespace generic.application.domain.contracts
{
    public interface IBaseRepository<T> where T: class 
    {
        IEnumerable<T> ListAll(string[] includes = null);
        int Update(T data);
        int Insert(T data);
        int Delete(T data);
        T searchById(int Id, string[] includes = null);
    }
}