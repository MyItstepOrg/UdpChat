using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using UdpChat.Core.Data.Dto;
using UdpChat.Core.Data.DTO;
using UdpChat.Core.Data.Source.Local;
using UdpChat.Core.Data.Source.Remote;
using UdpChat.View.View;

namespace UdpChat.View.ViewModel;
public partial class MainViewModel : ObservableObject
{
    public required Udp udp;
    [ObservableProperty]
    private UserInfo userInfo = new();

    public MainViewModel() => this.Start();

    private async void Start()
    {
        this.udp = new Udp(UserInfo.Local);
        while (true)
        {
            try
            {
                if (this.udp.Send($"#connect", UserInfo.Remote))
                {
                    UserInfo.Status = true;
                    UserInfo.MessageHistory.Clear();
                    while (true)
                    {
                        var result = await this.udp.Receive();
                        string message = System.Text.Encoding.UTF8.GetString(result.Buffer);
                        if (message.StartsWith("#info")
                            && result.RemoteEndPoint == this.UserInfo.Remote)
                        {
                            List<ChatDto> chats = JsonSerializer.Deserialize<List<ChatDto>>(result.Buffer);
                            this.UserInfo.Chats.Clear();
                            foreach (var c in chats)
                                this.UserInfo.Chats.Add(c);
                        }
                        else
                            UserInfo.MessageHistory.Add(new MessageDto()
                            {
                                Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                                Content = message,
                                Sender = result.RemoteEndPoint.ToString()
                            });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: + {ex.Message}");
            }
        }
    }
    private void Close() => this.udp.Close();
    [RelayCommand]
    private void Send(IPEndPoint remote)
    {
        //TODO: properly send data
        if (this.udp.Send(UserInfo.Message, remote) && this.udp.IsConnected())
        {
            UserInfo.MessageHistory.Add(new MessageDto()
            {
                Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                Sender = "me:",
                Content = UserInfo.Message
            });
            UserInfo.Message = string.Empty;
        }
    }
    [RelayCommand]
    private void LoadChat(string chatName)
    {
        UserInfo.ChatLoaded = true;
        UserInfo.MessageHistory.Clear();
        UserInfo.Users.Clear();
        foreach (var m in UserInfo.Chats.First(c => c.Name == chatName).MessageHistory)
            UserInfo.MessageHistory.Add(m);
        foreach (var u in UserInfo.Chats.First(c => c.Name == chatName).UsersList)
            UserInfo.Users.Add(u);
    }
    [RelayCommand]
    private void LoadProfile() => Shell.Current.GoToAsync(nameof(ProfilePage));
    public ReceiveDataDto? UnpackReceiveData(string json) => JsonSerializer.Deserialize<ReceiveDataDto>(json);
}