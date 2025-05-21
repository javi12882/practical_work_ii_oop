namespace ConversorCalculator;

[QueryProperty(nameof(User), "User")]
public partial class ConversorPage : ContentPage
{
	public User User {get; set;}

	public ConversorPage()
	{
		InitializeComponent();
	}

	private void OnExitTapped(object sender, EventArgs e)
	{
		UserManager.SaveOperations(User);

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

	private void OnLogoutTapped(object sender, EventArgs e)
	{
		UserManager.SaveOperations(User);

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
	
	private void OnClearClicked(object sender, EventArgs e)
	{
		if(sender is Button button)
		{
			DisplayEntry.Text = "";
		}
	}

	private void OnMinusClicked(object sender, EventArgs e)
	{
		if(sender is Button button)
		{
			string text = DisplayEntry.Text;

			if (text != null)
			{
				if(text.Contains("-"))
				{
					string newText = text.Substring(1);
					DisplayEntry.Text = newText;
				}
				else {
					DisplayEntry.Text = "-" + text;
				}
			}
			else
			{
				DisplayEntry.Text = "-";
			}
		}
	}
	
	private void OnKeypadClicked(object sender, EventArgs e)
	{
		if(sender is Button button)
		{
			DisplayEntry.Text += button.Text;
		}
	}
	
	private int GetNumberOperation(string operation)
	{
		int id = -1;

		switch(operation)
		{
			case "DecimalToBinary":
				id = 1;
				break;
			case "DecimalToOctal":
				id = 2;
				break;
			case "DecimalToHexadecimal":
				id = 3;
				break;
			case "DecimalToTwoComplement":
				id = 4;
				break;
			case "BinaryToDecimal":
				id = 5;
				break;
			case "OctalToDecimal":
				id = 6;
				break;
			case "HexadecimalToDecimal":
				id = 7;
				break;
		}

		return id;
	}

	private void OnFunctionClicked(object sender, EventArgs e)
	{
		try
		{
			if (sender is Button button)
			{
				string operationText = button.Text;
				int operation = GetNumberOperation(operationText);

				Converter converter = new Converter();
				string input = DisplayEntry.Text;

				string output = converter.PerformConversion(operation, input);
				DisplayEntry.Text = output;

				User.AddOperation(input, output, operationText);
			}
		} catch(FormatException error)
		{
			DisplayAlert("Warning", error.Message, "Ok");
			DisplayEntry.Text = "";
		} catch(ArgumentOutOfRangeException error)
		{
			DisplayAlert("Warning", error.Message, "Ok");
			DisplayEntry.Text = "";
		} catch(Exception)
		{
			DisplayAlert("Error", "Fallo no esperado", "Ok");
			DisplayEntry.Text = "";
		}
	}
}

