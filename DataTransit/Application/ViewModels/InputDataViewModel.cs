using DataTransit.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransit.Application.ViewModels
{
    public class InputDataViewModel
    {
        public List<InputData> inputDatas { get; set; } = new List<InputData>();
    }
}
