using HappyVacation.DTOs.Messages;
using HappyVacation.DTOs.Users;

namespace HappyVacation.Repositories.Messages
{
    public interface IMessageRepository
    {
        Task<List<MessageVm>> GetMessages(string userId, string withUserId);
        Task<List<MessageVm>> GetMessagesForProvider(int userId, string withUserId);
        Task<MessageVm> GetMessageById(int messageId);
        Task<int> CreateMessage(string userId, MessageDTO message);

        Task<List<UserChatVm>> GetUserChatList(int userId);     // for provider
        Task<int> DeleteConversation(int userId, string withUserId);    // for provider

        Task<List<UserChatVm>> GetProviderChatList(int userId);     // for member

        Task<string> UploadImage(IFormFile image);
    }
}
