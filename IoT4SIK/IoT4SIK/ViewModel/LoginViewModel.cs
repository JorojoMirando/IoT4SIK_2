using IoT4SIK.Model;
using IoT4SIK.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IoT4SIK.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            switch (((User)obj).typeUser)
            { 
                case Util.TypeUser.Gerente:
                    await Shell.Current.GoToAsync($"//{nameof(HomeGerencia)}");
                    break;
                case Util.TypeUser.Supervisor:
                    await Shell.Current.GoToAsync($"//{nameof(HomeGerencia)}");
                    break;
                default:
                    break;
            }
        }
    }
}
