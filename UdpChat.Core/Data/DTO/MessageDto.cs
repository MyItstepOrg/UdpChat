namespace UdpChat.Core.Data.DTO
{
    public class MessageDto
    {
        public uint Id { get; set; }
        public string? Time { get; set; }
        public string? Content { get; set; }
        public string? Sender { get; set; }

    }
}
