using HappyVacation.Database;
using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Hotels;
using HappyVacation.Services.Storage;
using Microsoft.EntityFrameworkCore;

namespace HappyVacation.Repositories.Hotels
{
    public class HotelRepository : IHotelRepository
    {
        private readonly MyDbContext _context;
        private readonly IStorageService _storageService;

        public HotelRepository(MyDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<PagedResult<HotelMainInfoVm>> GetHotels(GetHotelRequest request)
        {
            // check in and check out date
            var _checkIn = DateTime.Parse(request.CheckIn);
            var _checkOut = DateTime.Parse(request.CheckOut);
            // children list
            var children = request.Children == null ? new List<int>() : request.Children;

            // filter by place
            var hotel_query = _context.Hotels.Where(x => x.PlaceId == request.PlaceId).AsNoTracking();

            // filter by keyword
            if(!String.IsNullOrEmpty(request.Keyword))
            {
                hotel_query = hotel_query.Where(x =>
                                                    x.Province.Contains(request.Keyword) ||
                                                    x.District.Contains(request.Keyword) ||
                                                    x.Ward.Contains(request.Keyword) ||
                                                    x.Address.Contains(request.Keyword) ||
                                                    x.Name.Contains(request.Keyword)
                                                );
            }

            // paging
            int totalCount = hotel_query.Count();
            int totalPages = ((totalCount - 1) / request.PerPage) + 1;
            hotel_query = hotel_query.Skip((request.Page - 1) * request.PerPage).Take(request.PerPage);

            var hotels = await hotel_query.Select(h => new HotelMainInfoVm()
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                MinChildAge = h.MinChildAge,
                Stars = h.Stars,
                Address = $"{h.Address}, {h.Ward}, {h.District}, {h.Province}",
                Rating = (float)5,
                HasBreakfast = h.HasBreakfast,
                IsSuitable = true
            }).ToListAsync();

            for(int i = 0; i < hotels.Count; i++)
            {
                hotels[i].RemainingRooms = RemainingRooms(hotels[i].Id, _checkIn, _checkOut);
                hotels[i].RemainingCapacity = RemainingCapacity(hotels[i].Id, _checkIn, _checkOut);

                var groupSize = request.Adults + children.Count(age => age > hotels[i].MinChildAge);

                if (hotels[i].RemainingRooms < request.Rooms || hotels[i].RemainingCapacity < groupSize)
                {
                    hotels[i].IsSuitable = false;
                } 
            }

            return new PagedResult<HotelMainInfoVm>()
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                Items = hotels
            };
        }

        public int RemainingRooms(int hotelId, DateTime checkIn, DateTime checkOut)
        {
            var total = _context.Rooms.Where(r => r.HotelId == hotelId).Sum(r => r.Stock);
            var occupied = _context.BookingDetails.Where(bd =>
                                                                (bd.Booking.HotelId == hotelId) &&
                                                                !(bd.Booking.CheckIn.Date >= checkOut.Date ||
                                                                bd.Booking.CheckOut.Date <= checkIn.Date)
                                                         ).Sum(bd => bd.Quantity);
            return total - occupied;
        }

        public int RemainingCapacity(int hotelId, DateTime checkIn, DateTime checkOut)
        {
            var total = _context.Rooms.Where(r => r.HotelId == hotelId).Sum(r => r.Stock * r.MaxAdults);
            var occupied = _context.BookingDetails.Where(bd =>
                                                                (bd.Booking.HotelId == hotelId) &&
                                                                !(bd.Booking.CheckIn.Date >= checkOut.Date ||
                                                                bd.Booking.CheckOut.Date <= checkIn.Date)
                                                         ).Sum(bd => bd.Quantity * bd.Room.MaxAdults);
            return total - occupied;
        }
    }
}
