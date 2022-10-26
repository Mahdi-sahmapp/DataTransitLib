using DataTransit.Data.Context;
using DataTransit.Domain.Interfaces;
using DataTransit.Domain.Models;
using EFCore.BulkExtensions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataTransit.Data.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IServiceScopeFactory _scopeFactory;

        public DataRepository(IDistributedCache distributedCache, IServiceScopeFactory scopeFactory)
        {
            _distributedCache = distributedCache;
            _scopeFactory = scopeFactory;
        }

        public async Task AddToRedisAsync(IEnumerable<InputData> input)
        {
            var cashKey = "_Key";

            await _distributedCache.SetStringAsync(cashKey,
                               JsonConvert.SerializeObject(input));            
        }

        //MultiThreading
        public async Task AddToSqlAsync(List<InputData> input)
        {
            ThreadStart p = () => {
                // Separate DI scopes 
                using (var scoped = _scopeFactory.CreateScope())
                {
                    var _context = scoped.ServiceProvider.GetRequiredService<DataTransitContext>();

                    _context.BulkInsert(input);
                }
            };
            Thread thread = new Thread(new ThreadStart(p));
            thread.Start();            
        }

    }
}
