using Microsoft.AspNetCore.Mvc;
using WebApiOrder.Models;

namespace WebApiOrder.IServices
{
    public interface IOrderDetailServices
    {
        Task<IEnumerable<object>> GetAllDataOrderDetail();
        Task<IEnumerable<object>> GetDataOrderDetailByOrderID(string OrderID);
        Task<bool> DeleteOrderDetail(string orderDetailID);
        Task<List<OrderDetail>> AddOrderDetail(List<OrderDetail> details);

        Task<List<OrderDetail>> UpdateOrderDetailProduct(List<OrderDetail> orderDetail);
    }
}
