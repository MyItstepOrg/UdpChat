using UdpChat.View.ViewModel;

namespace UdpChat.View.View;
public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }
}
