using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commerce.Core.ViewModel
{
    public class PaginatedListNew<T>

    {
        public int TotalRecordCount { get; set; }

        public int TotalPageCount { get; set; }

        public int CurrentPageIndex { get; set; }

        public List<List<T>> List { get; set; }

        public PaginatedListNew(PaginationInfoView paginationInfo,List<List<T>> list)
        {
            TotalRecordCount = list.Count();
            var pageSize = paginationInfo.PageSize;
            TotalPageCount = (int)Math.Ceiling((float)TotalRecordCount / pageSize);


            paginationInfo.PageIndex
                = paginationInfo.PageIndex < 1 ? 1 : paginationInfo.PageIndex
                = paginationInfo.PageIndex > TotalPageCount ? 1 : paginationInfo.PageIndex;


            CurrentPageIndex = paginationInfo.PageIndex;
        }
    }
}
