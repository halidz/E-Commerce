using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commerce.Core.ViewModel
{
    public class PaginatedListDict<T>
    {
        public int TotalRecordCount { get; set; }

        public int TotalPageCount { get; set; }

        public int CurrentPageIndex { get; set; }

        public List<List<T>> List { get; set; }
        public PaginatedListDict(PaginationInfoView paginationInfo, IQueryable<T> query)
        {
            TotalRecordCount = query.Count();
            var pageSize = paginationInfo.PageSize;
            TotalPageCount = (int)Math.Ceiling((float)TotalRecordCount / pageSize);



            paginationInfo.PageIndex
                = paginationInfo.PageIndex < 1 ? 1 : paginationInfo.PageIndex
                = paginationInfo.PageIndex > TotalPageCount ? 1 : paginationInfo.PageIndex;


            CurrentPageIndex = paginationInfo.PageIndex;



            var skipCount = (CurrentPageIndex - 1) * paginationInfo.PageSize;
            query = query.Skip(skipCount)
                .Take(paginationInfo.PageSize);
            //var newQuery = query.Select(
            //    x => new RoleItemView
            //    {



            //    });



            var list = query.ToList();






        }

    }
}