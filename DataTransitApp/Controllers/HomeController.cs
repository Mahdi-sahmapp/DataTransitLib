using DataTransit.Application.Interfaces;
using DataTransit.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DataTransitApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Use DataTransit Library
        private readonly IDataTransitService _dataTransit;
        public HomeController(IDataTransitService dataTransit)
        {
            _dataTransit = dataTransit;
        }    
        
        public async Task<ActionResult> GetData()
        {
            var resualt = await _dataTransit.GetDataAsync();

            return Json(resualt);
        }

        public async Task ImportToRedis()
        {
            await _dataTransit.ImportDataAsync("Redis");
        }

        public async Task ImportToSql()
        {
            await _dataTransit.ImportDataAsync("SQL");
        }
        #endregion
    }
}
