using UdpChat.Core.Data.DTO;

namespace UdpChat.Core.Data.Dto;
public class ReceiveDataDto
{
    public List<UserDto> Users { get; set; } = [];
    public List<ChatDto> Chats { get; set; } = [];
}
