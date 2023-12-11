using Microsoft.AspNetCore.Mvc;
using WebApiOrder.Models;

namespace WebApiOrder.IServices
{
    public interface IOrderHeaderServices
    {
        Task<IEnumerable<Object>> GetAllDataHeader();
        Task<bool> DeleteOrder(string orderID);
        Task<IEnumerable<Object>> GetDataHeaderFiltered(string? orderID, string? custName);
        Task<OrderHeader> AddOrder(string postData);
    }
}
