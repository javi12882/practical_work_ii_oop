namespace ConversorCalculator;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnSignInClicked(object sender, EventArgs e)
	{
		try
		{
			if(sender is Button button)
			{
				string username = usernameEntry.Text;
				string password = passwordEntry.Text;

				User usuarioLogged = UserManager.SignIn(username, password);

				if(usuarioLogged == null)
				{
					await DisplayAlert("Error", "El usuario indicado no existe", "OK");
				}
				else {
					await Shell.Current.GoToAsync("ConversorPage", new ShellNavigationQueryParameters {{"User", usuarioLogged
					}});

				}
			}
		} catch(InvalidOperationException error)
		{
			await DisplayAlert("ERROR", error.Message, "OK");
		} catch(ArgumentNullException error)
		{
			await DisplayAlert("ERROR", error.Message, "OK");
		}
	}

	private void OnForgotPasswordTapped(object sender, EventArgs e)
	{
		DisplayAlert("Forgot Password", "Recovery link sent.", "OK");
	}

	private async void OnCreateUserTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(RegisterPage));
	}

	private void OnExitTapped(object sender, EventArgs e)
	{
		//TODO: Pendiente revisión
		#if ANDROID
			Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
		#elif WINDOWS
			Application.Current.Quit();
		#elif MACCATALYST
			Environment.Exit(0);
		#else
			// Mostrar alerta si no se puede cerrar
			DisplayAlert("Exit", "Exit not supported on this platform.", "OK");
		#endif
	}
}

