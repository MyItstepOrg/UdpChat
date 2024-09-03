using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace UdpChat.Core.Data.Source.Local;
public partial class UserInfo : ObservableObject
{
    [ObservableProperty]
    private bool isConnected = false;
    [ObservableProperty]
    private bool isNotConnected = true;
    [ObservableProperty]
    private string ip = "127.0.0.1";
    [ObservableProperty]
    private int port = 1024;
    [ObservableProperty]
    private string message = string.Empty;

    //TODO: Connect DTO Message
    public ObservableCollection<string> MessageHistory { get; set; } = [];
}
