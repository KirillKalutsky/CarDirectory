namespace CarDirectory.Models
{
    public class PagedList<T>
    {
        private int currentPage;
        public int CurrentPage 
        { 
            get => currentPage;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Нумерация страниц начинается с 1");

                currentPage = value;
            }
        }

        private int pageSize;
        public int PageSize
        {
            get => pageSize;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Количество записей страницы - положительное число");

                pageSize = value;
            }
        }

        public List<T> Items { get; set; }
        public int TotalCount { get; }
        public int TotalPageCount { get; }
        public bool HasNext => currentPage < TotalPageCount;
        public bool HasPrevious => currentPage > 1;
        public PagedList(IQueryable<T> items, int pageNumber=1, int pageSize=10)
        {
            CurrentPage = pageNumber;
            PageSize = pageSize;
            Items = items.Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();
            TotalCount = items.Count();
            TotalPageCount = (int) Math.Ceiling(TotalCount / (double)pageSize);
        }
    }
}
