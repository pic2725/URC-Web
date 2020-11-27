using System.Collections.Generic;

namespace URC.Models
{
    public class Paged<T>
    {
        public int totalElements { get; }
        public int totalPages { get; }
        public int currentPage { get; }
        public int pageSize { get; }
        public List<T> content { get; }

        public Paged(int totalElements, int totalPages, int currentPage, int pageSize, List<T> content)
        {
            this.totalElements = totalElements;
            this.totalPages = totalPages;
            this.currentPage = currentPage;
            this.pageSize = pageSize;
            this.content = content;
        }
    }
}