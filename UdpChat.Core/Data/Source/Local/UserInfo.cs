using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Net;
using UdpChat.Core.Data.DTO;

namespace UdpChat.Core.Data.Source.Local;
public partial class UserInfo : ObservableObject
{
    [ObservableProperty]
    private string username = "user";
    [ObservableProperty]
    private bool status = false;
    [ObservableProperty]
    private bool chatLoaded = false;
    [ObservableProperty]
    private IPEndPoint local = new(IPAddress.Any, 0);
    [ObservableProperty]
    private IPEndPoint remote = new(IPAddress.Parse("127.0.0.1"), 1025);
    [ObservableProperty]
    private string message = string.Empty;
    public ObservableCollection<ChatDto> Chats { get; set; } 
        = [new ChatDto() 
        { 
            Name = "Main", 
            UsersList = new() 
            { 
                new UserDto() 
                {
                    Username = "random user",
                    Address = new IPEndPoint(IPAddress.Any, 0) 
                } 
            } 
        }];
    public ObservableCollection<UserDto> Users { get; set; } = [];
    public ObservableCollection<MessageDto> MessageHistory { get; set; } = [];
}
