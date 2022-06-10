using HappyVacation.Database;
using HappyVacation.Database.Entities;
using HappyVacation.DTOs.Messages;
using HappyVacation.DTOs.Users;
using Microsoft.EntityFrameworkCore;

namespace HappyVacation.Repositories.Messages
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MyDbContext _context;
        public MessageRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateMessage(string userId, MessageDTO message)
        {
            var newMessage = new Message()
            {
                SenderId = userId,
                ReceiverId = message.ReceiverId,
                Content = message.Content,
                DateTime = DateTime.Now
            };

            _context.Messages.Add(newMessage);
            await _context.SaveChangesAsync();

            return newMessage.Id;
        }

        public async Task<MessageVm> GetMessageById(int messageId)
        {
            var message = await _context.Messages.Where(x => x.Id == messageId)
                                .Select(x => new MessageVm()
                                {
                                    Id = x.Id,
                                    Content = x.Content,
                                    SenderId = x.SenderId,
                                    ReceiverId = x.ReceiverId,
                                    DateTime = x.DateTime
                                }).FirstOrDefaultAsync();
            return message;
        }

        public async Task<List<MessageVm>> GetMessages(string userId, string withUserId)
        {

            var messages = await _context.Messages.Where(x => (x.SenderId == userId && x.ReceiverId == withUserId) ||
                                                              (x.SenderId == withUserId && x.ReceiverId == userId))
                                                  .Select(x => new MessageVm()
                                                  {
                                                      Id = x.Id,
                                                      Content = x.Content,
                                                      SenderId = x.SenderId,
                                                      ReceiverId = x.ReceiverId,
                                                      DateTime = x.DateTime
                                                  }).ToListAsync();
            return messages;
        }

        public async Task<List<MessageVm>> GetMessagesForProvider(int userId, string withUserId)
        {
            var providerId = await _context.Providers.Where(x => x.User.Id == userId).AsNoTracking()
                                            .Select(x => x.Id).FirstOrDefaultAsync();

            var provider_chat_id = $"provider{providerId}";
            var messages = await _context.Messages.Where(x => (x.SenderId == provider_chat_id && x.ReceiverId == withUserId) ||
                                                              (x.SenderId == withUserId && x.ReceiverId == provider_chat_id))
                                                  .Select(x => new MessageVm()
                                                  {
                                                      Id = x.Id,
                                                      Content = x.Content,
                                                      SenderId = x.SenderId,
                                                      ReceiverId = x.ReceiverId,
                                                      DateTime = x.DateTime
                                                  }).ToListAsync();
            return messages;
        }

        public async Task<List<UserChatVm>> GetUserChatList(int userId)
        {
            const string DEFAULT_AVATAR_URL = "/storage/blank_avatar.png";

            var providerId = await _context.Providers.Where(x => x.User.Id == userId).AsNoTracking()
                                            .Select(x => x.Id).FirstOrDefaultAsync();

            var provider_chat_id = $"provider{providerId}";

            // get list user id from message table
            var listIds = (await _context.Messages.Where(x => x.SenderId == provider_chat_id || x.ReceiverId == provider_chat_id)
                                           .AsNoTracking()
                                           .OrderByDescending(x => x.Id)
                                           .Select(x =>
                                                        x.SenderId == provider_chat_id
                                                        ? x.ReceiverId
                                                        : x.SenderId)
                                           .AsSplitQuery()
                                           .ToListAsync())
                                           .DistinctBy(result_value => result_value);

            // get list user
            var chatUsers = new List<UserChatVm>();
            foreach (var id in listIds)
            {
                if (_context.Users.Any(x => x.Id.ToString() == id))
                {
                    chatUsers.Add(await _context.Users.Where(x => x.Id.ToString() == id)
                                                .AsNoTracking()
                                                .Select(x => new UserChatVm()
                                                {
                                                    Id = x.Id.ToString(),
                                                    FullName = $"{x.FirstName} {x.LastName}",
                                                    AvatarUrl = x.AvatarUrl,
                                                    IsConversationDeletable = false
                                                }).FirstOrDefaultAsync());
                }
                else
                {
                    chatUsers.Add(new UserChatVm()
                    {
                        Id = id,
                        FullName = id,
                        AvatarUrl = DEFAULT_AVATAR_URL,
                        IsConversationDeletable = (DateTime.Now > (await GetLastestMessageTime(userId.ToString(), id)).AddMinutes(1))
                    });
                }
            }

            return chatUsers;
        }

        private async Task<DateTime> GetLastestMessageTime(string userId, string withUserId)
        {
            var time = await _context.Messages.Where(x => (x.SenderId == userId && x.ReceiverId == withUserId) ||
                                                              (x.SenderId == withUserId && x.ReceiverId == userId))
                                                  .OrderByDescending(x => x.DateTime)
                                                  .Select(x => x.DateTime).FirstOrDefaultAsync();
            if (time == null)
            {
                return DateTime.MinValue;
            }
            return time;
        }

        public async Task<int> DeleteConversation(int userId, string withUserId)
        {
            var providerId = await _context.Providers.Where(x => x.User.Id == userId).AsNoTracking()
                                            .Select(x => x.Id).FirstOrDefaultAsync();

            var provider_chat_id = $"provider{providerId}";

            _context.Messages.RemoveRange(_context.Messages
                                            .Where(x => (x.SenderId == provider_chat_id && x.ReceiverId == withUserId) ||
                                                        (x.SenderId == withUserId && x.ReceiverId == provider_chat_id)
                                                  )
                                         );

            return await _context.SaveChangesAsync();
        }
    }
}
