using UdpChat.View.ViewModel;

namespace UdpChat.View.View;
public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}