using System.Collections.Generic;

namespace Restaurant.APIs.Helpers
{
    public class Pagination<T>
    {
        public Pagination(int pageIndex, int pageSize, int count, IReadOnlyList<T> result)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = result;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
