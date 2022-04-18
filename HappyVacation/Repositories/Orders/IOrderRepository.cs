using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Orders;

namespace HappyVacation.Repositories.Orders
{
    public interface IOrderRepository
    {
        Task<PagedResult<OrderMainInfoVm>> GetUserOrders(int userId, string state, int page, int perPage);
        Task<PagedResult<OrderManageInfoVm>> GetTourProviderOrders(int userId, string state, int page, int perPage, string keyword);
        Task<OrderManageInfoVm> GetOrderById(int orderId);
        Task<int> CreateOrder(int userId, CreateTourOrderRequest request);
        Task<int> ChangeOrderState(int userId, int orderId, string state);
    }
}
