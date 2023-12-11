using Microsoft.AspNetCore.Mvc;
using WebApiOrder.Models;

namespace WebApiOrder.IRepository
{
    public interface IOrderHeaderRepository
    {
        Task<IEnumerable<Object>> GetAllDataHeader();
        Task<IEnumerable<Object>> GetDataHeaderFiltered(string? orderID, string? custName);
        Task<bool> DeleteOrder(string orderID);
        Task<OrderHeader> UpdateTotalByOrderID(string orderID, decimal valueTotal);
        Task<OrderHeader> AddOrder(OrderHeader? orderHeader);

        Task<OrderHeader> GetHeaderLastInserted();
    }
}
