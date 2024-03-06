using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPICall.Models;
using SampleAPICall.Services;

namespace SampleAPICall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RainfallMeasurementStationController : ControllerBase
    {
        private readonly RainfallMeasurementService _rainfallMeasurementService;    

        public RainfallMeasurementStationController(RainfallMeasurementService rainfullMeasurementService)
        {
            _rainfallMeasurementService = rainfullMeasurementService;
        }

        [HttpGet]
        public async Task<ActionResult<Root>> GetRainfallData()
        {
            var data = await _rainfallMeasurementService.GetRainfallMeasurementStationsAsync();
            return data;
        }
    }
}
