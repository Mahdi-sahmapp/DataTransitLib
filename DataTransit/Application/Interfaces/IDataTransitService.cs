using DataTransit.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransit.Application.Interfaces
{
    public interface IDataTransitService
    {
        
        Task<InputDataViewModel> GetDataAsync();

        /// <summary>
        /// Input database type
        /// </summary>
        /// <param name="dataBase"> Valid dataBase type: "SQL" , "Redis" </param>
        /// <returns></returns>       
        Task ImportDataAsync(string dataBase);
    }
}
