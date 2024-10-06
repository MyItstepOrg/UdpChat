using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UdpChat.Core.Data.Dto;

namespace UdpChat.Services;
public class Udp
{
    private readonly UdpClient socket;

    public Udp(IPEndPoint local) => socket = new UdpClient(local);

    public async void Connect(IPEndPoint remote, int id)
    {
        try
        {
            DataPacket dataPacket = new()
            {
                PacketType = "connect",
                SenderId = id,
                TimeStamp = DateTime.Now,
            };
            Send(JsonProcessor.Serialize(dataPacket), remote);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Target site: {ex.TargetSite} Exception: {ex.Message}");
        }
    }
    public bool Send(string datagram, IPEndPoint remote)
    {
        try
        {
            byte[] data = Encoding.Unicode.GetBytes(datagram);
            socket.Send(data, remote);
            Debug.WriteLine($"Data has been succesfuly sent to server");
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Failed to send data!");
            Debug.WriteLine($"Target site: {ex.TargetSite} Exception: {ex.Message}");
            return false;
        }
        return true;
    }
    public async Task<UdpReceiveResult> Receive() => await socket.ReceiveAsync();
    public void Close() => socket.Close();
}
