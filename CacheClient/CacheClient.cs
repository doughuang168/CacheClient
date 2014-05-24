using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeIT.MemCached;

namespace CacheClientManagement
{
    public class CacheClient
    {
        MemcachedClient _cache;
        string port = "";
        public CacheClient(string cachename, string host, string port)
        {
            this.port = port;
            //MemcachedClient.Exists(cachename)
            MemcachedClient.Setup(cachename, new string[] { host + ":" + port });
            _cache = MemcachedClient.GetInstance(cachename);
            //Console.WriteLine(_cache.Name);
            //Change client settings to values other than the default like this:
            _cache.SendReceiveTimeout  = 5000;
            _cache.ConnectTimeout      = 5000;
            _cache.MinPoolSize         = 1;
            _cache.MaxPoolSize         = 5;
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public bool Set(string key, object value)
        {
            return _cache.Set(key, value);
        }

        public bool Set(string key, object value, DateTime expiry)
        {
            return _cache.Set(key, value, expiry);
        }

        public bool Set(string key, object value, TimeSpan expiry)
        {
            return _cache.Set(key, value, expiry);
        }

        public bool Set(string key, object value, uint hash)
        {
            return _cache.Set(key, value, hash);
        }

        public bool Set(string key, object value, uint hash, DateTime expiry)
        {
            return _cache.Set(key, value, hash, expiry);
        }

        public bool Set(string key, object value, uint hash, TimeSpan expiry)
        {
            return _cache.Set(key, value, hash, expiry);
        }
        
        
    }
}
