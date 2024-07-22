using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class PageList
    {
        public class PagedList<T> : List<T>//meta datadan bir sayfayı ve bu sayfaya ait verileri içeren sayfalı bir liste oluşturur.
        {
            public MetaData MetaData { get; set; }
            public PagedList(List<T> items, int count, int pageNumber, int pageSize)
            {
                MetaData = new MetaData()
                {
                    TotalCount = count,
                    PageSize = pageSize,
                    CurrentPage = pageNumber,
                    TotalPage = (int)Math.Ceiling(count / (double)pageSize)
                };
                AddRange(items);
            }

            public static PagedList<T> ToPagedList(IEnumerable<T> source,
                int pageNumber,
                int pageSize)
            {
                var count = source.Count();
                var items = source
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return new PagedList<T>(items, count, pageNumber, pageSize);
            }
        }
    }
}
