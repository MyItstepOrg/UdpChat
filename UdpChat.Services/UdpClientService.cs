using System.Net;
using System.Net.Sockets;
using System.Text;
using UdpChat.Core.Data.Source.Local;

namespace UdpChat.Services
{
    public class UdpClientService
    {
        private UdpClient socket;
        private UserInfo userInfo;

        public UdpClientService(UserInfo userInfo)
        {
            this.userInfo = userInfo;
            socket = new UdpClient(userInfo.Local);
        }

        public void Connect()
        {
            socket.Connect(userInfo.Remote);
        }

        public bool Send(string datagram)
        {
            try
            {
                byte[] data = Encoding.Unicode.GetBytes(datagram);
                socket.Send(data);
                return true;
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
        }

        public async Task<UdpReceiveResult> Receive()
        {
            return await socket.ReceiveAsync();
        }

        public void Close() => socket.Close();
    }
}
