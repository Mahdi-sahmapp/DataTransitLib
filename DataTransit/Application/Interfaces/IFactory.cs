using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransit.Application.Interfaces
{
    public interface IFactory
    {        
        /// <summary>
        /// select Input storage mtype
        /// </summary>
        /// <param name="type">Valid storage type: "SQL" , "Redis"</param>
        /// <returns></returns>
        IImportData ImportData(string type);
    }
}
