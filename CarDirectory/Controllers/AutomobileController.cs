using CarDirectory.Services;
using Microsoft.AspNetCore.Mvc;
using CarDirectory.Models;
using CarDirectory.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace CarDirectory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutomobileController: BaseApiController
    {
        private readonly IAutomobileService automobileService;
        public AutomobileController(IAutomobileService automobileService)
        {
            this.automobileService = automobileService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAutomobiles(
            [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")] int curPage=1,
            [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")] int pageSize=10)
        {
            var response = await automobileService.GetAutomobiles(curPage, pageSize);

            return ConvertFromApiResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAutomobile([FromBody] AutomobileDto automobileDto)
        {
            var response = await automobileService.CreateAutomobile(automobileDto);

            return ConvertFromApiResponse(response);
        }

        [HttpDelete("{automobileId}")]
        public async Task<ActionResult> DeleteAutomobile([FromRoute] Guid automobileId)
        {
            var response = await automobileService.DeleteAutomobile(automobileId);

            return ConvertFromApiResponse(response);
        }

        [HttpGet("statistics")]
        public async Task<ActionResult> GetStatistics()
        {
            var response = await automobileService.GetDBStatistics();

            return ConvertFromApiResponse(response);
        }
    }
}
