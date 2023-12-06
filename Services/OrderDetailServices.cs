using System.Reflection.Metadata.Ecma335;
using WebApiOrder.IRepository;
using WebApiOrder.IServices;
using WebApiOrder.Models;

namespace WebApiOrder.Services
{
    public class OrderDetailServices : IOrderDetailServices
    {
        private readonly IOrderDetailRepository _repo;

        public OrderDetailServices(IOrderDetailRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> DeleteOrderDetail(string orderID)
        {
           return await _repo.DeleteOrderDetail(orderID);
        }

        public async Task<IEnumerable<object>> GetAllDataOrderDetail()
        {
            return await _repo.GetAllDataOrderDetail();
        }

        public async Task<IEnumerable<object>> GetDataOrderDetailByOrderID(string orderID)
        {
            return await _repo.GetDataOrderDetailByOrderID(orderID);

        }
    }
}
