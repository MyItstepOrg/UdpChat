using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Text;
using UdpChat.Core.Data.Dto;
using UdpChat.Services;
using UdpChat.View.View;

namespace UdpChat.View.ViewModel;
public partial class MainViewModel : ObservableObject
{
    public required Udp udp;
    //TODO: properly read data from json pass data to controller
    //Temporary plug
    [ObservableProperty]
    private AppSettings.AppSettings appSettings = new();
    public MainViewModel() => Start();

    private async void Start()
    {
        udp = new Udp(AppSettings.Remote);
        try
        {
            //TODO: properly pass id to the command
            udp.Connect(AppSettings.Remote, 51766);
            while (true)
            {
                var result = await udp.Receive();
                string message = Encoding.Unicode.GetString(result.Buffer);
                //TODO: handle received data packets
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Target site: {ex.TargetSite} Exception: {ex.Message}");
        }
    }
    private void Close() => udp.Close();
    [RelayCommand]
    private void Send()
    {
        DataPacket send = new()
        {
            PacketType = "message",
            SenderId = 51766,
            TimeStamp = DateTime.Now,
            Payload = new Dictionary<string, object>()
            {
                { "ChatId", AppSettings.CurrentOpenChatId },
                { "Message", AppSettings.Message }
            }
        };
        if (udp.Send(JsonProcessor.Serialize(send), AppSettings.Remote))
        {
            AppSettings.MessageHistory.Add(new MessageDto()
            {
                Time = DateTime.Now,
                Sender = "me:",
                Content = AppSettings.Message
            });
            AppSettings.Message = string.Empty;
        }
    }
    [RelayCommand]
    private void LoadChatContent(int id)
    {
        AppSettings.MessageHistory.Clear();
        AppSettings.Users.Clear();
        AppSettings.ChatLoaded = true;

        //TODO: proper chat load
    }
    [RelayCommand]
    private void LoadProfile() => Shell.Current.GoToAsync(nameof(ProfilePage));
}