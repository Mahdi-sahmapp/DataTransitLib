using DataTransit.Application.Interfaces;
using DataTransit.Application.ViewModels;
using DataTransit.Domain.Interfaces;
using System.Threading.Tasks;

namespace DataTransit.Application.Services.ImportData
{
    public class ImportToSql : IImportData
    {
        private readonly IDataRepository _dataRepository;
        public ImportToSql(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task ImportAsync(InputDataViewModel inputdata)
        {
            // AddToSqlAsync runing in multithread mode
            await _dataRepository.AddToSqlAsync(inputdata.inputDatas);
        }
    }
}
