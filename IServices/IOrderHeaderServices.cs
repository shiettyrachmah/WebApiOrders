using Microsoft.AspNetCore.Mvc;
using WebApiOrder.Models;

namespace WebApiOrder.IServices
{
    public interface IOrderHeaderServices
    {
        public Task<IEnumerable<Object>> GetAllDataHeader();
        public Task<bool> DeleteOrder(string orderID);
        public Task<IEnumerable<Object>> GetDataHeaderFiltered(string? orderID, string? custName);

        public Task<OrderHeader> UpdateOrder(string orderID);
    }
}
