using HappyVacation.DTOs.Orders;

namespace HappyVacation.Services.XLSX
{
    public interface IXLSXService
    {
        Task<string> ExportTourOrder(int providerId, string exportFileName, List<OrderManageInfoVm> orders);
    }
}
