using CarDirectory.Models;

namespace CarDirectory.Services
{
    public class BaseService
    {
        protected ApiResponse CresteSuccessResponse(object data) =>
            new ApiResponse { Data = data, StatusCode = 200};

        protected ApiResponse CresteSuccessResponse() =>
            new ApiResponse { StatusCode = 204};

        protected ApiResponse CreateNotFoundResponse(string error) =>
            new ApiResponse { StatusCode = 404, Error=error};

        protected ApiResponse CreateBadRequest(string error) =>
            new ApiResponse { StatusCode = 400 , Error=error};

    }
}
