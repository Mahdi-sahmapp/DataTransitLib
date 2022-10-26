using DataTransit.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransit.Data.Context
{
    public class DataTransitContext : DbContext
    {
        public DataTransitContext(DbContextOptions<DataTransitContext> options) : base(options)
        {
        }
        public DbSet<InputData> Datas { get; set; }
    }
}
