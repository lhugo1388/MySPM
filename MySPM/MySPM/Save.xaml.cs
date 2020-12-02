using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
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
    public partial class Save : ContentPage
    {
        Random numeroAleatorio = new Random();

        public Save()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno.id = GeNewId();
            alumno.nombre = txtName.Text;
            alumno.psw = txtPsw.Text;
            alumno.usuario = txtUser.Text;

            alumno.Save();

            await DisplayAlert("Guardar", "Alumno guardado", "OK");
        }

        private int GeNewId()
        {
            return numeroAleatorio.Next();
        }
    }
}