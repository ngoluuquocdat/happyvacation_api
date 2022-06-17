namespace HappyVacation.DTOs.Users
{
    public class UserChatVm
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string AvatarUrl { get; set; }
        public string LastestMessage { get; set; }
        public bool IsConversationDeletable { get; set; }
        public bool IsUserEnabled { get; set; }
    }
}
