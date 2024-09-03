using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UdpChat.Core.Data.Source.Local;

namespace UdpChat.View.ViewModel;
public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private UserInfo userInfo = new();

    [RelayCommand]
    private async Task Connect()
    {
        UserInfo.IsConnected = true;
        UserInfo.IsNotConnected = false;
    }
    [RelayCommand]
    private async Task Disconnect()
    {
        UserInfo.IsConnected = false;
        UserInfo.IsNotConnected = true;
    }
    [RelayCommand]
    private async Task Send()
    {

    }
}