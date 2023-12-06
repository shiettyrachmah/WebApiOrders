using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiOrder.DBContext;
using WebApiOrder.IRepository;
using WebApiOrder.Models;

namespace WebApiOrder.Repository
{
    public class OrderHeaderRepository : IOrderHeaderRepository
    {
        private readonly ApplicationDBContext _db;

        public OrderHeaderRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<bool> DeleteOrder(string orderID)
        {
            _db.OrderHeader.RemoveRange(_db.OrderHeader.Where(x => x.OrderID == orderID));
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<object>> GetAllDataHeader()
        {
            var result = await (from OrderHeader in _db.OrderHeader 
                                join Customer in _db.Customer on OrderHeader.CustomerID equals Customer.CustomerID
                                select new
                                {
                                    OrderID = OrderHeader.OrderID,
                                    RequiredDate = OrderHeader.RequiredDate,
                                    ShipName = OrderHeader.ShipName,
                                    TotalPrice = OrderHeader.TotalPrice,
                                    OrderDate = OrderHeader.OrderDate,
                                    CustomerID = OrderHeader.CustomerID,
                                    CustomerName = Customer.CustomerName,
                                    Address = Customer.Address,
                                    City = Customer.City
                                }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<object>> GetDataHeaderFiltered(string? orderID, string? custName)
        {
            var result = await (from OrderHeader in _db.OrderHeader
                               join Customer in _db.Customer on OrderHeader.CustomerID equals Customer.CustomerID
                               where (OrderHeader.OrderID.ToLower().Contains(orderID.ToLower()) || Customer.CustomerName == custName)
                                select new
                               {
                                   OrderID = OrderHeader.OrderID,
                                   RequiredDate = OrderHeader.RequiredDate,
                                   ShipName = OrderHeader.ShipName,
                                   TotalPrice = OrderHeader.TotalPrice,
                                   OrderDate = OrderHeader.OrderDate,
                                   CustomerID = OrderHeader.CustomerID,
                                   CustomerName = Customer.CustomerName,
                                   Address = Customer.Address,
                                   City = Customer.City
                               }).ToListAsync();

            return result;
        }

        public Task<OrderHeader> UpdateOrder(string orderID)
        {
            throw new NotImplementedException();
        }
    }
}
