using System.Collections.ObjectModel;

namespace UdpChat.Core.Data.DTO
{
    public class ChatDto
    {
        public uint Id { get; set; }
        public UserDto Remote {  get; set; }
        public ObservableCollection<MessageDto> MessageHistory { get; set; }
    }
}
