using DataTransit.Application.Interfaces;
using DataTransit.Application.ViewModels;
using DataTransit.Domain.Models;
using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DataTransit.Application.Services.ReadData
{
    public class ReadExcell : IReadData
    {
        public async Task<InputDataViewModel> GetDataAsync()
        {
            var model = new InputDataViewModel();
            var _data = model.inputDatas;

            // get file path
            string path = Environment.CurrentDirectory;
            string Filepath = $"{path}\\ExcellFile\\Data.xlsx";          

            //check is file exists
            if (!File.Exists(Filepath)) throw new FileNotFoundException();

            try
            {
                // solve some encoding problem
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (FileStream stream = File.OpenRead(Filepath))
                {                    
                    // read stream
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        DataSet ds = reader.AsDataSet();
                        DataTable dt = ds.Tables[0];
                        var header = dt.Rows[0].ItemArray;
                        for (int i = 1; i < dt.Rows.Count; i++)
                        {
                            _data.Add(new InputData
                            {
                                Id = Convert.ToInt32(dt.Rows[i].ItemArray[0]),
                                Data = dt.Rows[i].ItemArray[1].ToString()
                            });
                        }
                        model.inputDatas = _data;
                    }
                }
            }
            catch (Exception e)
            {
                // logging Error
            }

            return model;

        }
    }
}
