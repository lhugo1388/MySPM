using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySPM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetAll : ContentPage
    {
        public ObservableCollection<Alumno> Alumnos { get; private set; }

        public GetAll()
        {          
            InitializeComponent();

            Alumnos = new ObservableCollection<Alumno>();
            grData.ItemsSource = Alumnos;
        }

        private async void btnConsultarr_Clicked(object sender, EventArgs e)
        {
            Alumnos.Clear();

            Task<List<Alumno>> tarea = Alumno.LoadAll();

            foreach(Alumno alumno in tarea.Result)
            {
                Alumnos.Add(alumno);
            }

            await DisplayAlert("Consultar", "Alumnos consultados", "OK");
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            object seleccionado = grData.SelectedItem;

            if(seleccionado == null)
            {
                await DisplayAlert("Actualizar", "Seleccione un registro", "OK");
            }
            else
            {
                Alumno alumno = (Alumno)seleccionado;
                await Navigation.PushAsync(new Update(alumno));

            }            
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            object seleccionado = grData.SelectedItem;

            if (seleccionado == null)
            {
                await DisplayAlert("Actualizar", "Seleccione un registro", "OK");
            }
            else
            {
                Alumno alumno = (Alumno)seleccionado;
                alumno.Delete();

                await DisplayAlert("Eliminar", "Alumno eliminado", "OK");

            }            
        }
    }
}