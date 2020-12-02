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
    public partial class GetById : ContentPage
    {
        public GetById()
        {
            InitializeComponent();
        }

        private async void btnConsultar_Clicked(object sender, EventArgs e)
        {
            int id = 0;
            int.TryParse(txtId.Text, out id);

            Alumno alumno = new Alumno();
            alumno.id = id;
            alumno = alumno.LoadById(id);

            lblName.Text = alumno.nombre;
            lblUser.Text = alumno.usuario;
            lblPassword.Text = alumno.psw;

            await DisplayAlert("Consultar", "Alumno consultado", "OK");
        }
    }
}