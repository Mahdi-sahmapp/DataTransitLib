
using DataTransit.Application.ViewModels;
using System.Threading.Tasks;

namespace DataTransit.Application.Interfaces
{
    public interface IImportData
    {
        Task ImportAsync(InputDataViewModel InputData);
    }
}
