using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcern.Caching.Redis
{
    public class RedisSettings
    {
        public List<RedisEndpoint> Endpoints { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

    }
}
