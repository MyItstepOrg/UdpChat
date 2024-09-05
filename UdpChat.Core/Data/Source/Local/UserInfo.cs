using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Net;
using UdpChat.Core.Data.DTO;

namespace UdpChat.Core.Data.Source.Local;
public partial class UserInfo : ObservableObject
{
    [ObservableProperty]
    private bool isConnected = false;
    [ObservableProperty]
    private bool isNotConnected = true;
    [ObservableProperty]
    private IPEndPoint local = new(IPAddress.Parse("127.0.0.1"), 1024);
    [ObservableProperty]
    private IPEndPoint remote = new(IPAddress.Parse("127.0.0.1"), 1025);
    [ObservableProperty]
    private string message = string.Empty;
    public ObservableCollection<MessageDto> MessageHistory { get; set; } = [];
}
