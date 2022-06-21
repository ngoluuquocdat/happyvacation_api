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
        private readonly string _storageFolder;
        private const string StorageFolderName = "message";
        public MessageRepository(MyDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _storageFolder = Path.Combine(webHostEnvironment.WebRootPath, StorageFolderName);
            // create the folder if it does not exist
            Directory.CreateDirectory(_storageFolder);
            _context = context;
        }

        public async Task<int> CreateMessage(string userId, MessageDTO message)
        {
            var newMessage = new Message()
            {
                SenderId = userId,
                ReceiverId = message.ReceiverId,
                Content = message.Content,
                ImageUrl = !String.IsNullOrEmpty(message.ImageUrl) ? message.ImageUrl : "",
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
                                    ImageUrl = !String.IsNullOrEmpty(x.ImageUrl) ? x.ImageUrl : "",
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
                                                      ImageUrl = !String.IsNullOrEmpty(x.ImageUrl) ? x.ImageUrl : "",
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
                                                      ImageUrl = !String.IsNullOrEmpty(x.ImageUrl) ? x.ImageUrl : "",
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
                                                    IsConversationDeletable = false,
                                                    IsUserEnabled = x.IsEnabled
                                                }).FirstOrDefaultAsync());
                }
                else
                {
                    chatUsers.Add(new UserChatVm()
                    {
                        Id = id,
                        FullName = id,
                        AvatarUrl = DEFAULT_AVATAR_URL,
                        IsConversationDeletable = (DateTime.Now > (await GetLastestMessageTime(userId.ToString(), id)).AddMinutes(1)),
                        IsUserEnabled = true
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

        public async Task<List<UserChatVm>> GetProviderChatList(int userId)
        {
            // get list provider id from message table
            var listIds = (await _context.Messages.Where(x => x.SenderId == userId.ToString() || x.ReceiverId == userId.ToString())
                                           .AsNoTracking()
                                           .OrderByDescending(x => x.Id)
                                           .Select(x =>
                                                        x.SenderId == userId.ToString()
                                                        ? x.ReceiverId
                                                        : x.SenderId)
                                           .AsSplitQuery()
                                           .ToListAsync())
                                           .DistinctBy(result_value => result_value);

            // get list provider
            var chatProviders = new List<UserChatVm>();
            foreach (var id in listIds)
            {
                chatProviders.Add(await _context.Providers.Where(x => "provider"+x.Id == id)
                                                   .AsNoTracking()
                                                   .Select(x => new UserChatVm()
                                                   {
                                                       Id = $"provider{ x.Id}",
                                                       FullName = x.ProviderName,
                                                       AvatarUrl = x.AvatarUrl,
                                                       IsConversationDeletable = false,
                                                       IsUserEnabled = x.IsEnabled
                                                   }).FirstOrDefaultAsync());

                //if (_context.Users.Any(x => x.Id.ToString() == id))
                //{
                //    chatUsers.Add(await _context.Users.Where(x => x.Id.ToString() == id)
                //                                .AsNoTracking()
                //                                .Select(x => new UserChatVm()
                //                                {
                //                                    Id = x.Id.ToString(),
                //                                    FullName = $"{x.FirstName} {x.LastName}",
                //                                    AvatarUrl = x.AvatarUrl,
                //                                    IsConversationDeletable = false,
                //                                    IsUserEnabled = x.IsEnabled
                //                                }).FirstOrDefaultAsync());
                //}
                //else
                //{
                //    chatUsers.Add(new UserChatVm()
                //    {
                //        Id = id,
                //        FullName = id,
                //        AvatarUrl = DEFAULT_AVATAR_URL,
                //        IsConversationDeletable = (DateTime.Now > (await GetLastestMessageTime(userId.ToString(), id)).AddMinutes(1)),
                //        IsUserEnabled = true
                //    });
                //}
            }

            return chatProviders;
        }

        public async Task<string> UploadImage(IFormFile image)
        {
            return await SaveImage(image);
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            // create a new random file name, security issues, reference from Microsoft doc
            var newFileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
            // create new path to save file into storage
            var newFilePath = Path.Combine(_storageFolder, newFileName);

            // save image
            using (var fileStream = new FileStream(newFilePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return $"/{StorageFolderName}/{newFileName}";
        }     
    }
}
