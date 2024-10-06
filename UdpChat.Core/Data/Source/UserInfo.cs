using CommunityToolkit.Mvvm.ComponentModel;
using System.Net;
namespace UdpChat.Core.Data.Source;
public partial class UserInfo : ObservableObject
{
    [ObservableProperty]
    private static int userId = 51766;
    [ObservableProperty]
    private static string username = "user";
    [ObservableProperty]
    private IPEndPoint local = new(IPAddress.Any, 0);
}
