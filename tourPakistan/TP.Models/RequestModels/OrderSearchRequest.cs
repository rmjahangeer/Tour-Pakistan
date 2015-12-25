using System;

namespace TP.Models.RequestModels
{
    public class OrderSearchRequest : GetPagedListRequest
    {
        public string  OrderId { get; set; }
        public DateTime ? OrderDate { get; set; }
        public string  ProductCode { get; set; }


        //public OrdersByColumn OrdersOrderBy
        //{
        //    get
        //    {
        //        return (OrdersByColumn)SortBy;
        //    }
        //    set
        //    {
        //        SortBy = (short)value;
        //    }
        //}
        public OrderSearchRequest()
        {
            SortBy = 0;
            IsAsc = false;
        }

    }
}
