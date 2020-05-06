using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commerce.Core.ViewModel
{
    public class PaginatedListN<T>

    {
        public int TotalRecordCount { get; set; }

        public int TotalPageCount { get; set; }

        public int CurrentPageIndex { get; set; }

        public List<T> List { get; set; }

        public PaginatedListN(PaginationInfoView paginationInfo, List<T> list)
        {
            TotalRecordCount = list.Count;
            var pageSize = paginationInfo.PageSize;
            TotalPageCount = (int)Math.Ceiling((float)TotalRecordCount / pageSize);


            paginationInfo.PageIndex
                = paginationInfo.PageIndex < 1 ? 1 : paginationInfo.PageIndex
                = paginationInfo.PageIndex > TotalPageCount ? 1 : paginationInfo.PageIndex;


            CurrentPageIndex = paginationInfo.PageIndex;

            var skipCount = (CurrentPageIndex - 1) * paginationInfo.PageSize;
            list = list.Skip(skipCount)
                .Take(paginationInfo.PageSize).ToList();

            List = list;
        }
    }
}
