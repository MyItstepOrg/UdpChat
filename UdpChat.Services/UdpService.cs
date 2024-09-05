using System.Net.Sockets;
using System.Net;
using System.Text;

namespace UdpChat.Services;
public class UdpService
{
    private UdpClient socket;
    public UdpService(IPEndPoint local) => socket = new UdpClient(local);
    public void Connect(IPEndPoint remote) => socket.Connect(remote);
    public async Task<UdpReceiveResult> Receive() => await this.socket.ReceiveAsync();
    public bool Send(string datagramm, IPEndPoint remote)
    {
        try
        {
            byte[] data = Encoding.Unicode.GetBytes(datagramm);
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
    public void Close() => this.socket.Close();
}
