using Microsoft.AspNetCore.Mvc;
using NewClassroomsTrial.Services;
using System.Text;
using NewClassroomsTrial.Dtos;
using Newtonsoft.Json;

namespace NewClassroomsTrial.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserStatisticsService _statisticsService;
        private readonly FileGeneraterService _fileGeneraterService;

        public UserController()
        {
            _statisticsService = new UserStatisticsService();
            _fileGeneraterService = new FileGeneraterService();
        }

        [HttpPost("generate")]
        public IActionResult GenerateStatistics([FromBody] UserStatisticsDto request)
        {
            var statistics = _statisticsService.GenerateStatistics(request.Results);

            if (request.Format.ToLower() == "txt")
            {
                var text = _fileGeneraterService.GenerateText(statistics);
                var bytes = Encoding.UTF8.GetBytes(text);
                return File(bytes, "text/plain", "statistics.txt");
            }
            else if (request.Format.ToLower() == "json")
            {
                var json = JsonConvert.SerializeObject(statistics);
                var bytes = Encoding.UTF8.GetBytes(json);
                return File(bytes, "application/json", "statistics.json");
            }
            else if (request.Format.ToLower() == "xml")
            {
                var xml = _fileGeneraterService.GenerateXml(statistics);
                var bytes = Encoding.UTF8.GetBytes(xml);
                return File(bytes, "application/xml", "statistics.xml");
            }
            else
            {
                return BadRequest("Invalid format. Supported formats are 'csv', 'json', and 'xml'.");
            }
        }


    }
}
