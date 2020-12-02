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
    public partial class Update : ContentPage
    {
        Alumno alumno;
        public Update(Alumno xAlumno)
        {
            alumno = xAlumno;
            InitializeComponent();

            txtName.Text = alumno.nombre;
            txtPsw.Text = alumno.psw;
            txtUser.Text = alumno.usuario;
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            alumno.nombre = txtName.Text;
            alumno.psw = txtPsw.Text;
            alumno.usuario = txtUser.Text;

            alumno.Save();

            await DisplayAlert("Actualizar", "Alumno actualizado", "OK");
        }
    }
}