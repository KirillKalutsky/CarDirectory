using CarDirectory.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarDirectory.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        protected virtual ActionResult ConvertFromApiResponse(ApiResponse apiResponse)
        {
            if (apiResponse.StatusCode == StatusCodes.Status204NoContent)
                return NoContent();
                
            return StatusCode(apiResponse.StatusCode, apiResponse);
        }

    }
}
