namespace TP.Repository.Repositories
{
    //public sealed class OrdersRepository: BaseRepository<Order>, IOrdersRepository
    //{
    //    #region Constructor
    //    /// <summary>
    //    /// Constructor
    //    /// </summary>
    //    public OrdersRepository(IUnityContainer container)
    //        : base(container)
    //    {
    //    }

    //    /// <summary>
    //    /// Primary database set
    //    /// </summary>
    //    protected override IDbSet<Order> DbSet
    //    {
    //        get { return db.Orders; }
    //    }

    //    readonly Dictionary<OrdersByColumn, Func<Order, object>> requestClause =
    //      new Dictionary<OrdersByColumn, Func<Order, object>>
    //            {
    //                {OrdersByColumn.OrderId, c => c.OrderId},
    //                {OrdersByColumn.OrderDate, c => c.RecCreatedDate},
    //                {OrdersByColumn.TotalItems, c => c.OrderItems.Sum(x=>x.Quantity)},
    //                {OrdersByColumn.Discount, c => c.OrderItems.Sum(x=>x.Discount)},
    //                {OrdersByColumn.SaleBy, c => c.RecCreatedBy},
    //            };
    //    #endregion

    //    public Models.ResponseModels.OrderSearchResponse GetOrdersSearchResponse(Models.RequestModels.OrderSearchRequest searchRequest)
    //    {
    //        int fromRow = (searchRequest.PageNo - 1) * searchRequest.PageSize;
    //        int toRow = searchRequest.PageSize;
    //        Expression<Func<Order, bool>> query =
    //                s => (
    //                        (
    //                         (string.IsNullOrEmpty( searchRequest.OrderId )|| s.OrderId.ToString().Equals(searchRequest.OrderId)) &&
    //                        (string.IsNullOrEmpty(searchRequest.ProductCode) || s.OrderItems.Any(x => x.ProductVariationId.ToString()==searchRequest.ProductCode))
    //                        && (searchRequest.OrderDate == null || DbFunctions.TruncateTime(s.RecCreatedDate) == DbFunctions.TruncateTime(searchRequest.OrderDate.Value))
    //                        && (s.IsDeleted!=true)
    //                        )
    //                    );
    //        IEnumerable<Order> result =
    //            searchRequest.IsAsc
    //                ? DbSet.Include(x=>x.OrderItems).Include(x=>x.AspNetUser).Where(query)
    //                    .OrderBy(requestClause[searchRequest.OrdersOrderBy])
    //                    .Skip(fromRow)
    //                    .Take(toRow)
    //                    .ToList()
    //                : DbSet.Include(x=>x.OrderItems).Include(x=>x.AspNetUser).Where(query)
    //                    .OrderByDescending(requestClause[searchRequest.OrdersOrderBy])
    //                    .Skip(fromRow)
    //                    .Take(toRow)
    //                    .ToList();

    //        return new OrderSearchResponse { Orders = result, TotalCount = DbSet.Count(), FilteredCount = DbSet.Count(query) };

    //    }
    //}
}
