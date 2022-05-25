using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Orders;

namespace HappyVacation.Repositories.Orders
{
    public interface IOrderRepository
    {
        Task<PagedResult<OrderMainInfoVm>> GetUserOrders(int userId, string state, int page, int perPage);
        Task<PagedResult<OrderManageInfoVm>> GetTourProviderOrders(int userId, string state, int page, int perPage, string keyword);
        Task<OrderManageInfoVm> GetOrderById(int orderId);  // for provider, response after processing order
        Task<OrderManageDetailVm> GetOrderDetailManage(int userId, int orderId);    // detail for provider
        Task<OrderDetailVm> GetOrderDetail(int userId, int orderId);          // detail for customer
        Task<int> CreateOrder(int userId, CreateTourOrderRequest request);
        Task<string> CreateOrderPayment(int userId, CreateTourOrderRequest request);
        Task<OrderPaymentInfoVm> ConfirmOrderTransaction(int orderId, string transactionId);       

        Task<int> ConfirmOrder(int userId, int orderId);
        Task<int> CancelOrder(int userId, int orderId);

        Task<int> ChangeDepartureDate(int userId, int orderId, string newDate);
    }
}
