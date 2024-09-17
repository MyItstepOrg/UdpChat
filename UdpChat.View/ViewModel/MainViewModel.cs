using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Text;
using UdpChat.Core.Data.Dto;
using UdpChat.Core.Data.Source;
using UdpChat.Services;
using UdpChat.View.View;

namespace UdpChat.View.ViewModel;
public partial class MainViewModel : ObservableObject
{
    public required Udp udp;
    [ObservableProperty]
    UserInfo userInfo = new();
    JsonConverter jsonConverter = new();

    public MainViewModel() => this.Start();

    private async void Start()
    {
        udp = new Udp(UserInfo.Local);
        try
        {
            SendCommandToServer("#connect");
            SendCommandToServer("#getchats");
            while (true)
            {
                var result = await this.udp.Receive();
                string message = Encoding.UTF8.GetString(result.Buffer);
                DataPacket dataPacket = jsonConverter.Desirialize<DataPacket>(message);
                switch (dataPacket.Command.ToLower())
                {
                    case "#connect":

                        break;
                    case "#getchats":

                        break;
                    case "#getchatcontent":

                        break;
                    case "#sendtochat":
                        break;
                    case "#updateuserinfo":
                        break;
                    case "#createnewchat":
                        break;
                    case "#adduserstochat":
                        break;
                    default:
                        throw new Exception("Unknown command!");

                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: + {ex.Message}");
        }
    }
    private void Close() => udp.Close();
    private async void SendCommandToServer(string command)
    {
        DataPacket packet = new()
        {
            UserId = UserInfo.Id,
            Username = UserInfo.Username,
            Command = command
        };
        string json = jsonConverter.Serialize(packet);
        if (udp.Send(json, UserInfo.Remote))
        {
            try
            {
                var receive = await udp.Receive();
                string message = Encoding.Unicode.GetString(receive.Buffer);
                DataPacket dataPacket = jsonConverter.Desirialize<DataPacket>(message);
                HandleDataPacket(dataPacket);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
    private void GetChats()
    {
        DataPacket packet = new()
        {
            UserId = UserInfo.Id,
            Username = UserInfo.Username,
            Command = "#getchats"
        };
        string json = jsonConverter.Serialize(packet);
        udp.Send(json, UserInfo.Remote);
        while (true)
        {
            var receive = udp.Receive();

        }
    }
    private void HandleDataPacket(DataPacket dataPacket)
    {
        switch (dataPacket.Command.ToLower())
        {
            case "#updateuserinfo":
                UserDto userInfo = jsonConverter.Desirialize<UserDto>(dataPacket.Content);
                UserInfo.
                break;
            case "#userchats":
                break;
            case "#chatcontent":
                break;
        }
    }
    [RelayCommand]
    private void Send()
    {
        //TODO: properly send data
        if (udp.Send(UserInfo.Message, UserInfo.Remote))
        {
            UserInfo.MessageHistory.Add(new MessageDto()
            {
                Time = DateTime.Now,
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
        //TODO: proper chat load
    }
    [RelayCommand]
    private void LoadProfile() => Shell.Current.GoToAsync(nameof(ProfilePage));
}