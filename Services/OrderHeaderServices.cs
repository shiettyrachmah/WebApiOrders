using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Text.Json;
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

        public async Task<OrderHeader> AddOrder(string postData)
        {
            using (JsonDocument document = JsonDocument.Parse(postData))
            {
                // Access the root element of the JSON document
                JsonElement root = document.RootElement;

                JsonElement headerElement = root.GetProperty("header");
                var headerData = headerElement.GetRawText();

                JsonElement detailElement = root.GetProperty("detail");
                string detailData = detailElement.GetRawText();

                //deserialize
                if (headerData != null && detailData != null)
                {
                    OrderHeader orderHeader = JsonSerializer.Deserialize<OrderHeader>(headerData);
                    List<OrderDetail> orderDetail = JsonSerializer.Deserialize<List<OrderDetail>>(detailData);
                    
                    //getMaxHeaderID
                    var resultID = await _repo.GetHeaderLastInserted();
                    var id = resultID.OrderID.Substring(5);
                    var idInt = Convert.ToInt32(id) + 1;
                    var idLatest = "";
                    int intAdd1 = 0;

                    if(idInt.ToString().Length != 5)
                    {
                        intAdd1 =  5 - idInt.ToString().Length;

                        for(int i=0; i<intAdd1; i++)
                        {
                            idLatest += "0";
                        }
                    }

                    idLatest += idInt.ToString();
                    var newOrderID = orderHeader.CustomerID + idLatest;
                    orderHeader.OrderID = newOrderID.ToString();

                    var resultHeader = await _repo.AddOrder(orderHeader);
                    var idNew = resultHeader.OrderID;


                    foreach (var od in orderDetail)
                    {
                        od.OrderID = idNew;
                    }


                    //update detail
                    await _repoDetail.AddOrderDetail(orderDetail);
                    return resultHeader;
                }
                else
                {
                    return null;
                }
            }
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
            if (orderID == null)
                orderID = string.Empty;

            if (custName == null)
                custName = string.Empty;

            return _repo.GetDataHeaderFiltered(orderID, custName);
        }

    }
}
