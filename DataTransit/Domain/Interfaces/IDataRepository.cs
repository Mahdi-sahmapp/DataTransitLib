using DataTransit.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransit.Domain.Interfaces
{
    public interface IDataRepository
    {
        Task AddToSqlAsync(List<InputData> input);
        Task  AddToRedisAsync(IEnumerable<InputData> input);
    }
}
