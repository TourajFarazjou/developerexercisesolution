using System;
using System.Web;

namespace ExerciseWebApplication.Services
{
    public class DataCacheService : IDataCacheService
    {
        public void Insert(string key, object value, DateTime absoluteExpiration)
        {
            HttpContext.Current.Cache.Insert(key, value, null, absoluteExpiration, TimeSpan.Zero);
        }

        public object Get(string key)
        {
            return HttpContext.Current.Cache.Get(key);
        }
    }
}