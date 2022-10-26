using DataTransit.Application.Interfaces;
using DataTransit.Application.Services.ReadData;
using DataTransit.Application.ViewModels;
using DataTransit.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransit.Application.Services
{
    public class DataTransitService : IDataTransitService
    {
        private IDataRepository _dataRepository;
        public DataTransitService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<InputDataViewModel> GetDataAsync()
        {
            IReadData _readData = new ReadExcell();
            var resualt = await _readData.GetDataAsync();
            return resualt;
        }
        
        public async Task ImportDataAsync(string dataBase)
        {
            InputDataViewModel inputdata = await GetDataAsync();
            IFactory factory = new Factory(_dataRepository);
            IImportData _importData = factory.ImportData(dataBase);
            await _importData.ImportAsync(inputdata);
        }

    }
}
