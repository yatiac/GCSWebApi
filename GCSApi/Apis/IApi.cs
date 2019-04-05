using System.Collections.Generic;

namespace GCSApi.Apis
{
    public interface IApi<T>
    {
        T Create(T data);
        T Update(T data);
        object Delete(int id);
        List<T> Get();
        T Get(int id);
    }
}
