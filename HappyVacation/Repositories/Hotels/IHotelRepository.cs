using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Hotels;

namespace HappyVacation.Repositories.Hotels
{
    public interface IHotelRepository
    {      
        Task<PagedResult<HotelMainInfoVm>> GetHotels(GetHotelRequest request);
    }
}
