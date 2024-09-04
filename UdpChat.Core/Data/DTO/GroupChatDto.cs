using System.Collections.ObjectModel;

namespace UdpChat.Core.Data.DTO
{
    public class GroupChatDto
    {
        public uint Id { get; set; }
        public string? GroupName { get; set; }
        public List<UserDto> ChatUsers { get; set; }
        public ObservableCollection<MessageDto> MessageHistory { get; set; }
        
    }
}
