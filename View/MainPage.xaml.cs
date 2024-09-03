using UdpChat.ViewModel;

namespace UdpChat.View;
public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }
}
