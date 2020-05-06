using System;
using System.Collections.Generic;
using System.Linq;

namespace Commerce.Core.ViewModel
{
    public class PaginatedList<T>
    {
        public int TotalRecordCount { get; set; }

        public int TotalPageCount { get; set; }

        public int CurrentPageIndex { get; set; }

        public List<T> List { get; set; }
        public PaginatedList(PaginationInfoView paginationInfo, IQueryable<T> query)
        {
            TotalRecordCount = query.Count();
            var pageSize = paginationInfo.PageSize;
            TotalPageCount = (int)Math.Ceiling((float)TotalRecordCount / pageSize);



            paginationInfo.PageIndex
                = paginationInfo.PageIndex < 1 ? 1 : paginationInfo.PageIndex
                = paginationInfo.PageIndex > TotalPageCount ? 1 : paginationInfo.PageIndex;


            CurrentPageIndex = paginationInfo.PageIndex;



            var skipCount = (CurrentPageIndex - 1) * paginationInfo.PageSize;
            query = query.Skip(skipCount).Take(paginationInfo.PageSize);
            List = query.ToList();
        }

        //public PaginatedList(PaginationInfoView paginationInfo, IQueryable<T> query, IDictionary<T, T> dictionary)
        //{
        //    TotalRecordCount = query.Count();
        //    var pageSize = paginationInfo.PageSize;
        //    TotalPageCount = (int)Math.Ceiling((float)TotalRecordCount / pageSize);
        //    paginationInfo.PageIndex
        //        = paginationInfo.PageIndex < 1 ? 1 : paginationInfo.PageIndex
        //        = paginationInfo.PageIndex > TotalPageCount ? 1 : paginationInfo.PageIndex;

        //    CurrentPageIndex = paginationInfo.PageIndex;

        //    var skipCount = (CurrentPageIndex - 1) * paginationInfo.PageSize;
        //    query = query.Skip(skipCount)
        //        .Take(paginationInfo.PageSize);
        //    var list = dictionary.Values.ToList();
        //    List = list;
        //}
    }
}
