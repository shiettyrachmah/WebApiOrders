using Microsoft.AspNetCore.Mvc;
using WebApiOrder.IRepository;
using WebApiOrder.IServices;
using WebApiOrder.Models;

namespace WebApiOrder.Services
{
    public class OrderHeaderServices : IOrderHeaderServices
    {
        private readonly IOrderHeaderRepository _repo;
        private readonly IOrderDetailRepository _repoDetail;

        public OrderHeaderServices(IOrderHeaderRepository repo, IOrderDetailRepository repoDetail)
        {
            _repo = repo;
            _repoDetail = repoDetail;
        }

        public async Task<bool> DeleteOrder(string orderID)
        {
            await _repoDetail.DeleteOrderDetail(orderID);
            var result = await _repo.DeleteOrder(orderID);
            return result;
        }

        public async Task<IEnumerable<object>> GetAllDataHeader()
        {
            return await _repo.GetAllDataHeader();
        }

        public Task<IEnumerable<object>> GetDataHeaderFiltered(string? orderID, string? custName)
        {
            if(orderID == null) 
                orderID = string.Empty;

            if (custName == null)
                custName = string.Empty;

            return _repo.GetDataHeaderFiltered(orderID, custName);
        }

        public Task<OrderHeader> UpdateOrder(string orderID)
        {
            return _repo.UpdateOrder(orderID);
        }
    }
}
