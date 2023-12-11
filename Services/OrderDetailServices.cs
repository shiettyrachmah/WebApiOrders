using System.Reflection.Metadata.Ecma335;
using WebApiOrder.IRepository;
using WebApiOrder.IServices;
using WebApiOrder.Models;

namespace WebApiOrder.Services
{
    public class OrderDetailServices : IOrderDetailServices
    {
        private readonly IOrderDetailRepository _repo;
        private readonly IOrderHeaderRepository _repoHeader;

        public OrderDetailServices(IOrderDetailRepository repo, IOrderHeaderRepository repoHeader)
        {
            _repo = repo;
            _repoHeader = repoHeader;
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

        public async Task<List<OrderDetail>> AddOrderDetail(List<OrderDetail> details)
        {
            return await _repo.AddOrderDetail(details);
        }

        public async Task<List<OrderDetail>> UpdateOrderDetailProduct(List<OrderDetail> orderDetails)
        {
            if(orderDetails != null)
            {
                var orderID = orderDetails[0].OrderID;

                //delete detail exist
                var result = await _repo.DeleteOrderDetail(orderID);

                if (result)
                {
                    // add new detail
                   await _repo.AddOrderDetail(orderDetails);

                    var a = orderDetails.Select(x => Convert.ToDecimal(x.SubTotal)).ToArray();
                    var totalSum = a.Sum();
                    var totalPrice =
                    //update totalprice header
                    await _repoHeader.UpdateTotalByOrderID(orderID, totalSum);
                }

                return orderDetails;
            }
            else
            {
                return null;
            }
        }
    }
}
