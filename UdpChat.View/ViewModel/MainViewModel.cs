using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Net.Sockets;
using UdpChat.Core.Data.DTO;
using UdpChat.Core.Data.Source.Local;
using UdpChat.Services;

namespace UdpChat.View.ViewModel;
public partial class MainViewModel : ObservableObject
{
    public required UdpService udp;
    [ObservableProperty]
    private UserInfo userInfo = new();

    [RelayCommand]
    private async Task Start()
    {
        this.udp = new UdpService(UserInfo.Local);
        try
        {
            UserInfo.MessageHistory.Clear();
            UserInfo.IsConnected = true;
            UserInfo.IsNotConnected = !UserInfo.IsConnected;
            while (true)
            {
                var result = await this.udp.Receive();
                UserInfo.MessageHistory.Add(new MessageDto()
                {
                    Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    Content = System.Text.Encoding.UTF8.GetString(result.Buffer),
                    Sender = result.RemoteEndPoint.ToString()
                });
            }
        }
        catch (SocketException ex)
        {
            Debug.WriteLine($"Socket exception: + {ex.Message}");
        }
        finally
        {
            if (UserInfo.IsConnected)
            {
                UserInfo.MessageHistory.Add(new MessageDto()
                {
                    Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    Content = "Unreachable!",
                    Sender = "SYSTEM:"
                });
                this.Close();
            }
        }
    }
    [RelayCommand]
    private void Close()
    {
        if (UserInfo.IsConnected)
        {
            this.udp.Close();
            UserInfo.IsConnected = false;
            UserInfo.IsNotConnected = !UserInfo.IsConnected;
            UserInfo.MessageHistory.Add(new MessageDto()
            {
                Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                Content = "Closing...",
                Sender = "SYSTEM:"
            });
            UserInfo.IsConnected = false;
            UserInfo.IsNotConnected = true;
        }
    }
    [RelayCommand]
    private void Send()
    {
        if(this.udp.Send(UserInfo.Message, UserInfo.Remote))
            UserInfo.MessageHistory.Add(new MessageDto()
            {
                Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                Sender = "me:",
                Content = UserInfo.Message
            });
        UserInfo.Message = string.Empty;
    }
}