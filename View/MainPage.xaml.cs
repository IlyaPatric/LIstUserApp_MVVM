using LIstUserApp.ViewModel;

namespace LIstUserApp;

public partial class MainPage : ContentPage
{ 
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
		
		
    }
}