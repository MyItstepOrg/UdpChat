using System.Net;

namespace UdpChat.Core.Data.DTO;
public class UserDto
{
    public uint Id { get; set; }
    public required IPEndPoint Address { get; set; }
    public string? Username { get; set; }
}
