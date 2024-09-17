using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpChat.Services;
public class Udp
{
    private readonly UdpClient socket;

    public Udp(IPEndPoint local) => socket = new UdpClient(local);

    public bool Send(string datagram, IPEndPoint remote)
    {
        try
        {
            byte[] data = Encoding.Unicode.GetBytes(datagram);
            this.socket.Send(data, remote);
        }
        catch (SocketException ex)
        {
            Console.WriteLine("Socket exception: " + ex.Message);
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Send exception: " + ex.Message);
            return false;
        }
        return true;
    }
    public async Task<UdpReceiveResult> Receive() => await this.socket.ReceiveAsync();
    public void Close() => this.socket.Close();
}
