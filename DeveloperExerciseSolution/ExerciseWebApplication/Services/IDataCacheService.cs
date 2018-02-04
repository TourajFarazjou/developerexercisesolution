using System;

namespace ExerciseWebApplication.Services
{
    public interface IDataCacheService
    {
        void Insert(string key, object value, DateTime absoluteExpiration);

        object Get(string key);
    }
}
