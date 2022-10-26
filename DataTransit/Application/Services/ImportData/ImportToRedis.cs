using DataTransit.Application.Interfaces;
using DataTransit.Application.ViewModels;
using DataTransit.Domain.Interfaces;
using System.Threading.Tasks;

namespace DataTransit.Application.Services.ImportData
{
    public class ImportToRedis : IImportData
    {

        private readonly IDataRepository _dataRepository;
        public ImportToRedis(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task ImportAsync(InputDataViewModel InputData)
        {
            await _dataRepository.AddToRedisAsync(InputData.inputDatas);
        }

    }
}
