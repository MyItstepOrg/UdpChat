using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Net;
using UdpChat.Core.Data.Dto;

namespace UdpChat.Core.Data.Source;
public partial class UserInfo : ObservableObject
{
    [ObservableProperty]
    private int id = 0;
    [ObservableProperty]
    private string username = "user";
    [ObservableProperty]
    private bool chatLoaded = false;
    [ObservableProperty]
    private IPEndPoint local = new(IPAddress.Any, 0);
    [ObservableProperty]
    private IPEndPoint remote = new(IPAddress.Parse("127.0.0.1"), 1025);
    [ObservableProperty]
    private string message = string.Empty;
    public ObservableCollection<ChatDto> Chats { get; set; } = new();
    public ObservableCollection<UserDto> Users { get; set; } = new();
    public ObservableCollection<MessageDto> MessageHistory { get; set; } = new();
}
