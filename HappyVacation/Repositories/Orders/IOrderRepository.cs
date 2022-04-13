using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Orders;

namespace HappyVacation.Repositories.Orders
{
    public interface IOrderRepository
    {
        Task<PagedResult<OrderMainInfoVm>> GetUserOrders(int userId, string state, int page, int perPage);
    }
}
