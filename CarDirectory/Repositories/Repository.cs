using CarDirectory.Models;
using CarDirectory.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace CarDirectory.Repositories
{
    public abstract class Repository<T> where T : class
    {
        protected DbContext context;
        protected DbSet<T> set;
        public Repository(DbContext dbContext)
        {
            context = dbContext;
            set = dbContext.Set<T>();
        }

        public abstract Task<PagedList<T>> GetItems(int curPage, int pageSize);
        public virtual async Task<bool> DeleteItem(Guid itemId)
        {
            var item = await GetItem(itemId);

            if(item == null)
                return false;

            set.Remove(item);
            return true;
        }

        public abstract Task<Guid> InsertItem(T item);

        public virtual async Task<T> GetItem(Guid itemId) =>
            await set.FindAsync(itemId);

        public virtual async Task SaveChangesAsync() => 
            await context.SaveChangesAsync();

        public abstract Task<StatisticsDto> GetContextStatistics();
        public abstract Task<bool> IsUnique(T item);
    }
}
