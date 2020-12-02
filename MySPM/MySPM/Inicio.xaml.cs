using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySPM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();

        }

        private async void BtnGuardar_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Save());
        }

        private async void BtnConsultarTodos_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAll());
        }

        private async void BtnConsultarPorId_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetById());
        }
    }
}