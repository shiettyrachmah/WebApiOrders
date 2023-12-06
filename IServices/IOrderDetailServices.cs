using Microsoft.AspNetCore.Mvc;
using WebApiOrder.Models;

namespace WebApiOrder.IServices
{
    public interface IOrderDetailServices
    {
        public Task<IEnumerable<object>> GetAllDataOrderDetail();
        public Task<IEnumerable<object>> GetDataOrderDetailByOrderID(string OrderID);
        public Task<bool> DeleteOrderDetail(string orderDetailID);
    }
}
