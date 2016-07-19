using Windows.UI.Xaml.Controls;

namespace SharpTimeAndCulture
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		MainViewModel vm;

		public MainPage()
		{
			InitializeComponent();
			vm = new MainViewModel();
			DataContext = vm;
		}
	}
}
