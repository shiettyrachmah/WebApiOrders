using Microsoft.AspNetCore.Mvc;
using WebApiOrder.Models;

namespace WebApiOrder.IRepository
{
    public interface IOrderHeaderRepository
    {
        public Task<IEnumerable<Object>> GetAllDataHeader();
        public Task<IEnumerable<Object>> GetDataHeaderFiltered(string? orderID, string? custName);
        public Task<bool> DeleteOrder(string orderID);
        public Task<OrderHeader> UpdateOrder(string orderID);
    }
}
