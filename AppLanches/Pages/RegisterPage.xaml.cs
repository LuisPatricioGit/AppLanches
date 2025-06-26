using AppLanches.Services;
using AppLanches.Validations;

namespace AppLanches.Pages;

public partial class RegisterPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly IValidator _validator;

    public RegisterPage(ApiService apiService, IValidator validator)
    {
        InitializeComponent();
        _apiService = apiService;
        _validator = validator;
    }

    private async void BtnSignup_ClickedAsync(object sender, EventArgs e)
    {
        if (await _validator.Validate(EntName.Text, EntEmail.Text, EntPhone.Text, EntPassword.Text))
        {


            var response = await _apiService.RegistrarUsuario(EntName.Text, EntEmail.Text,
                                                          EntPhone.Text, EntPassword.Text);

            if (!response.HasError)
            {
                await DisplayAlert("Aviso", "Sua conta foi criada com sucesso !!", "OK");
                await Navigation.PushAsync(new LoginPage(_apiService, _validator));
            }
            else
            {
                await DisplayAlert("Erro", "Algo deu errado!!!", "Cancelar");
            }
        }
        else
        {
            string ErrorMessage = "";
            ErrorMessage += _validator.NameError != null ? $"\n- {_validator.NameError}" : "";
            ErrorMessage += _validator.EmailError != null ? $"\n- {_validator.EmailError}" : "";
            ErrorMessage += _validator.PhoneError != null ? $"\n- {_validator.PhoneError}" : "";
            ErrorMessage += _validator.PasswordError != null ? $"\n- {_validator.PasswordError}" : "";

            await DisplayAlert("Erro", ErrorMessage, "OK");
        }

    }

    private async void TapLogin_TappedAsync(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new LoginPage(_apiService, _validator));
    }
}