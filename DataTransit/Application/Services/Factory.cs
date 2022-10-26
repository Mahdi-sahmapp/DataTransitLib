using DataTransit.Application.Interfaces;
using DataTransit.Application.Services.ImportData;
using DataTransit.Data.Repository;
using DataTransit.Domain.Interfaces;
using System;

namespace DataTransit.Application.Services
{
    public class Factory : IFactory
    {
        private  IDataRepository _dataRepository;
        public Factory(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IImportData ImportData(string type)
        {
            
            switch (type)
            {
                case "SQL":                    
                    return new ImportToSql(_dataRepository);

                case "Redis":
                    return new ImportToRedis(_dataRepository);

                default: throw new ArgumentException("Invalid input type");
            }
        }
    }
}
