using System;
using System.Text;
using Lemoras.Remora.Core.Manager;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Lemoras.Remora.Api.Manager
{
    public class CacheManager : ICacheManager
    {
        //private readonly ConnectionMultiplexer redis;
        //private readonly IDatabase db;

        public static string RedisHost;
        private readonly int _redisPort;
        //private readonly string _redisPassword;
        private readonly ConfigurationOptions _configurationOptions;

        public CacheManager()
        {
            //var aredis = ConnectionMultiplexer.Connect("localhost");
            //db = redis.GetDatabase();

            //_redisPassword = "";
            _redisPort = 6379;

            _configurationOptions = new ConfigurationOptions();
            _configurationOptions.EndPoints.Add(RedisHost, _redisPort);
            _configurationOptions.Ssl = false;
            //_configurationOptions.Password = _redisPassword;
            _configurationOptions.AbortOnConnectFail = false;
            _configurationOptions.SyncTimeout = int.MaxValue;
            _configurationOptions.DefaultVersion = new Version(2, 8, 8);
            _configurationOptions.WriteBuffer = 10000000;
            _configurationOptions.KeepAlive = 180;
        }

        public T Get<T>(string key)
        {
            using (var connection = ConnectionMultiplexer.Connect(_configurationOptions))
            {
                var db = connection.GetDatabase(-1);
                //return (T)(object)db.StringGet(key);
                return (T)ConvertToObject<T>(db.StringGet(key));
            }
        }

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time</param>
        public void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            DateTime expireDate;
            if (cacheTime == 99)
                expireDate = DateTime.Now + TimeSpan.FromSeconds(30);
            else
                expireDate = DateTime.Now + TimeSpan.FromMinutes(cacheTime);

            var value = (RedisValue)ConvertToByteArray(data);

            using (var connection = ConnectionMultiplexer.Connect(_configurationOptions))
            {
                var db = connection.GetDatabase(-1);
                db.StringSet(key, value, new TimeSpan(expireDate.Ticks));
            }
        }

        private byte[] ConvertToByteArray(object data)
        {
            if (data == null)
                return null;

            string serialize = JsonConvert.SerializeObject(data);
            return Encoding.UTF8.GetBytes(serialize);
        }

        /// <summary>
        /// Converts to object.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>System.Object.</returns>
        private T ConvertToObject<T>(byte[] data)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(data));
            }
            catch (Exception)
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }
    }
}
