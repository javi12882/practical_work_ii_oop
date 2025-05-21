namespace ConversorCalculator;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		//Routes
		Routing.RegisterRoute(nameof(PasswordRecoveryPage), typeof(PasswordRecoveryPage));
		Routing.RegisterRoute("ConversorPage", typeof(ConversorPage));
		Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
	}
}
