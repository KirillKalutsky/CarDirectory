using CarDirectory.Models;
using CarDirectory.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CarDirectory.Services
{
    public interface IAutomobileService
    {
        Task<ApiResponse> GetAutomobiles(int curPage, int pageSize);
        Task<ApiResponse> CreateAutomobile(AutomobileDto automobileDto);
        Task<ApiResponse> DeleteAutomobile(Guid automobileId);
        Task<ApiResponse> GetDBStatistics();
    }
}
