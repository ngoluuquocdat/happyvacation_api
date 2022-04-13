using HappyVacation.Database;
using HappyVacation.Database.Entities;
using HappyVacation.DTOs.Common;
using HappyVacation.DTOs.Orders;
using Microsoft.EntityFrameworkCore;

namespace HappyVacation.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyDbContext _context;

        public OrderRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrder(int userId, CreateTourOrderRequest request)
        {
            var order = new Order()
            {
                UserId = userId,
                TourId = request.TourId,
                DepartureDate = DateTime.Parse(request.DepartureDate),
                Adults = request.Adults,
                Children = request.Children,
                TouristName = request.TouristName,
                TouristPhone = request.TouristPhone,
                TouristEmail = request.TouristEmail,
                OrderDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                State = "pending",
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<OrderMainInfoVm> GetOrderById(int orderId)
        {
            var query = _context.Orders.Where(x => x.Id == orderId).AsNoTracking();

            var order = await query.Select(x => new OrderMainInfoVm()
            {
                Id = x.Id,
                TourId = x.TourId,
                TourName = x.Tour.TourName,
                DepartureDate = x.DepartureDate.ToShortDateString(),
                ModifiedDate = x.ModifiedDate.ToShortDateString(),
                Duration = x.Tour.Duration,
                IsPrivate = x.Tour.IsPrivate,
                Adults = x.Adults,
                Children = x.Children,
                PricePerAdult = x.Tour.PricePerAdult,
                PricePerChild = x.Tour.PricePerChild,
                TotalPrice = x.Adults * x.Tour.PricePerAdult + x.Children * x.Tour.PricePerChild,
                ThumbnailUrl = (x.Tour.TourImages.Count() > 0) ? x.Tour.TourImages[0].Url : String.Empty,
                State = x.State,
                ProviderId = x.Tour.ProviderId,
                ProviderName = x.Tour.Provider.ProviderName
            }).FirstOrDefaultAsync();

            return order;
        }

        public async Task<PagedResult<OrderMainInfoVm>> GetUserOrders(int userId, string state = "", int page = 1, int perPage = 3)
        {
            var query = _context.Orders.Where(x => x.UserId == userId).AsNoTracking();

            if (!string.IsNullOrEmpty(state))
            {
                state = state.ToLower();
                if(state == "processed")
                {
                    query = query.Where(x => x.State == "confirmed" || x.State == "canceled");
                } 
                else
                {
                    query = query.Where(x => x.State == state);
                }
            }

            // order by modified date
            query = query.OrderByDescending(x => x.ModifiedDate);

            // paging
            // default values
            page = page == 0 ? 1 : page;
            perPage = perPage == 0 ? 3 : perPage;
            int totalCount = query.Count();
            int totalPages = ((totalCount - 1) / perPage) + 1;
            query = query.Skip((page - 1) * perPage).Take(perPage);

            var orders = await query.Select(x => new OrderMainInfoVm()
            {
                Id = x.Id,
                TourId = x.TourId,
                TourName = x.Tour.TourName,
                DepartureDate = x.DepartureDate.ToShortDateString(),
                ModifiedDate = x.ModifiedDate.ToShortDateString(),
                Duration = x.Tour.Duration,
                IsPrivate = x.Tour.IsPrivate,
                Adults = x.Adults,
                Children = x.Children,
                PricePerAdult = x.Tour.PricePerAdult,
                PricePerChild = x.Tour.PricePerChild,
                TotalPrice = x.Adults* x.Tour.PricePerAdult + x.Children* x.Tour.PricePerChild,
                ThumbnailUrl = (x.Tour.TourImages.Count() > 0) ? x.Tour.TourImages[0].Url : String.Empty,
                State = x.State,
                ProviderId = x.Tour.ProviderId,
                ProviderName = x.Tour.Provider.ProviderName
            }).ToListAsync();

            return new PagedResult<OrderMainInfoVm>()
            {
                TotalCount = totalCount,
                TotalPage = totalPages,
                Items = orders
            };
        }
    }
}
