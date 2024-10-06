using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Net;
using UdpChat.Core.Data.Dto;

namespace UdpChat.View.AppSettings;
public partial class AppSettings : ObservableObject
{
    [ObservableProperty]
    public int currentOpenChatId;
    [ObservableProperty]
    private bool chatLoaded = false;
    [ObservableProperty]
    private string message = string.Empty;
    public IPEndPoint Remote { get; set; } = new(IPAddress.Parse("127.0.0.1"), 1025);
    public ObservableCollection<ChatDto> Chats { get; set; } = new();
    public ObservableCollection<UserDto> Users { get; set; } = new();
    public ObservableCollection<MessageDto> MessageHistory { get; set; } = new();
}
