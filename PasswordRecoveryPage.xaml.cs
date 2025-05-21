namespace ConversorCalculator;

public partial class PasswordRecoveryPage : ContentPage
{
	//int count = 0;

	public PasswordRecoveryPage()
	{
		InitializeComponent();
	}

    private async void OnRecoveryClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(MainPage));
    }

	/*private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}*/
}

