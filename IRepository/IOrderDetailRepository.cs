using Microsoft.AspNetCore.Mvc;
using WebApiOrder.Models;

namespace WebApiOrder.IRepository
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<object>> GetAllDataOrderDetail();
        Task<IEnumerable<object>> GetDataOrderDetailByOrderID(string orderID);
        public Task<bool> DeleteOrderDetail(string orderID);
    }
}
