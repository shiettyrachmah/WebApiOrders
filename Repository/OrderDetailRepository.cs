using Microsoft.EntityFrameworkCore;
using WebApiOrder.DBContext;
using WebApiOrder.IRepository;
using WebApiOrder.Models;

namespace WebApiOrder.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly ApplicationDBContext _db;

        public OrderDetailRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<OrderDetail>> AddOrderDetail(List<OrderDetail> details)
        {
            _db.OrderDetail.AddRange(details);
            await _db.SaveChangesAsync();
            return details;
        }

        public async Task<bool> DeleteOrderDetail(string orderID)
        {
            _db.OrderDetail.RemoveRange(_db.OrderDetail.Where(x => x.OrderID == orderID));
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<object>> GetAllDataOrderDetail()
        {
            var result = await (from OrderDetail in _db.OrderDetail
                                join Product in _db.Product on OrderDetail.ProductID equals Product.ProductID
                                select new
                                {
                                    ProductName = Product.ProductName,
                                    ProductId = Product.ProductID,
                                    Price = Product.Price,
                                    OrderDetailID = OrderDetail.OrderDetailID,
                                    OrderID = OrderDetail.OrderID,
                                    SubTotal = OrderDetail.SubTotal,
                                    Qty = OrderDetail.Qty,
                                }).ToListAsync();
            return result;   
        }

        public async Task<IEnumerable<object>> GetDataOrderDetailByOrderID(string orderID)
        {
            var result = await (from OrderDetail in _db.OrderDetail
                               join Product in _db.Product on OrderDetail.ProductID equals Product.ProductID
                               where OrderDetail.OrderID == orderID
                               select new
                               {
                                   ProductName = Product.ProductName,
                                   ProductId = Product.ProductID,
                                   Price = Product.Price,
                                   OrderDetailID = OrderDetail.OrderDetailID,
                                   OrderID = OrderDetail.OrderID,
                                   SubTotal = OrderDetail.SubTotal,
                                   Qty = OrderDetail.Qty,
                               }).ToListAsync();
            return result;
        }
    }
}
