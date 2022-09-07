using CarDirectory.DB;
using CarDirectory.Models;
using CarDirectory.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace CarDirectory.Repositories
{
    public class AutomobileRepository:Repository<Automobile>
    {
        public AutomobileRepository(AutomobileContext context):base(context)
        {

        }

        public async override Task<StatisticsDto> GetContextStatistics()
        {
            var itemsCount = await set.CountAsync();
            var automobiles = set.OrderBy(car => car.Create);
            var first = await automobiles.FirstOrDefaultAsync();
            var last = await automobiles.LastOrDefaultAsync();
            var statistics = new StatisticsDto
            {
                FirstNoteCreate = first?.Create,
                LastNoteCreate = last?.Create,
                TotalItemCount = itemsCount
            };
            return statistics;
        }

        public override Task<PagedList<Automobile>> GetItems(int curPage, int pageSize)
        {
            var task = Task.Run(() =>
            {
                var items = set.OrderBy(car => car.Create);
                return new PagedList<Automobile>(items, curPage, pageSize);
            });
            return task;
        }

        public override async Task<Guid> InsertItem(Automobile item)
        {
            await set.AddAsync(item);
            return item.Id;
        }

        public async override Task<bool> IsUnique(Automobile item)
        {
            var car = await set
                .Where(car => car.RegisterSign.Equals(item.RegisterSign))
                .FirstOrDefaultAsync();

            return car == null;
        }
    }
}
