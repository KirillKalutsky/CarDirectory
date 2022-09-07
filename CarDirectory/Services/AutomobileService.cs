using CarDirectory.Repositories;
using CarDirectory.Models;
using CarDirectory.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using CarDirectory.Extensions;

namespace CarDirectory.Services
{
    public class AutomobileService: BaseService, IAutomobileService
    {
        private readonly Repository<Automobile> _repository;
        public AutomobileService(Repository<Automobile> automobileRepository)
        {
            _repository = automobileRepository;
        }

        public async Task<ApiResponse> CreateAutomobile(AutomobileDto automobileDto)
        {

            var automobile = automobileDto.DtoToAutomobite();

            var automobileIsUnique = await _repository.IsUnique(automobile);
            if (!automobileIsUnique)
            {
                return CreateBadRequest("Автомобиль уже находится в каталоге");
            }

            Guid automobileId = await _repository.InsertItem(automobile);

            await _repository.SaveChangesAsync();

            return CresteSuccessResponse(automobileId);
        }

        public async Task<ApiResponse> DeleteAutomobile(Guid automobileId)
        {
            var automobile = await _repository.GetItem(automobileId);

            if (automobile == null)
                return CreateNotFoundResponse($"Не найдено автомобиля с идентификатором: {automobileId}");

            await _repository.DeleteItem(automobileId);
            await _repository.SaveChangesAsync();

            return CresteSuccessResponse();
        }

        public async Task<ApiResponse> GetAutomobiles(int curPage, int pageSize)
        {
            var automobiles = await _repository.GetItems(curPage, pageSize);

            return CresteSuccessResponse(automobiles);
        }

        public async Task<ApiResponse> GetDBStatistics()
        {
            var statistics = await _repository.GetContextStatistics();

            return CresteSuccessResponse(statistics);
        }
    }
}
