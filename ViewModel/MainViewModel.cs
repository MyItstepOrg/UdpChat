using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace UdpChat.ViewModel;
public partial class MainViewModel
{
    public bool IsConnected { get; set; } = false;
    public bool IsNotConnected { get; set; } = true;
    public string Ip { get; set; } = "127.0.0.1";
    public int Port { get; set; } = 1024;
    public string Message { get; set; } = string.Empty;

    //TODO: Connect DTO Message
    public ObservableCollection<string> MessageHistory { get; set; } = [];
    [RelayCommand]
    private async Task Connect()
    {
        
    }
    [RelayCommand]
    private async Task Disconnect()
    {
       
    }
    [RelayCommand]
    private async Task Send()
    {
        
    }
}