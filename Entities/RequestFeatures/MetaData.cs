using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class MetaData//SAYFALAMA HAKKINDA DETAYLI BİLGİ VERİR. KAÇ SAYFA VAR,BAŞKA SAYFA VAR MI VS.
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPrevious => CurrentPage > 1;//"currentPage" kullanıcının şu anda görüntülediği sayfa numarasını belirtir.
        public bool HasPage => CurrentPage < TotalPage;

    }
}
