using System.Threading.Tasks;

namespace ConversorCalculator;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

	private async void OnSignUpClicked(object sender, EventArgs e)
	{
		if(sender is Button button)
		{
			string username = usernameEntry.Text;
			string name = nameEntry.Text;
			string password = passwordEntry.Text;
			string confirmPassowrd = confirmPasswordEntry.Text;

			if(username == name)
			{
				await DisplayAlert("Error", "Username no puede ser igual a name", "OK");
			} 
			else if (password != confirmPassowrd) 
			{
				await DisplayAlert("Error", "Password y Confirm Password no son iguales", "OK");
			}
			else
			{
				int passwordSize = password.Length;

				if(passwordSize < 8)
				{
					await DisplayAlert("Error", "La contraseña debe ser igual o mayor a 8 carácteres", "OK");
				} else
				{
					bool tieneMayuscula = password.Any(char.IsUpper);
					bool tieneMinuscula = password.Any(char.IsLower);
					bool tieneNumero = password.Any(char.IsDigit);
					bool tieneEspecial = password.Any(c => !char.IsLetterOrDigit(c));

					if(tieneMayuscula && tieneMinuscula && tieneNumero && tieneEspecial)
					{
						if (privacyCheckBox.IsChecked)
						{
							UserManager.CreateNewUser(name, username, password);

							await Shell.Current.GoToAsync("..");
						}
						else
						{
							await DisplayAlert("Error", "Debes aceptar la política de privacidad", "OK");
						}
					} else
					{
						await DisplayAlert("Error", "La contraseña debe contener una mayúsucla," +
							 "una minúscula, un número y un carácter especial", "OK");
					}
				}
			}
		}
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

